using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Enums;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Extensions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IQueryable<CategoryListVM>> GetAllAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllAsync("Gender", "Children", "Parent"));

            return categoryListVMs.AsQueryable();
        }

        public async Task<IQueryable<CategoryListVM>> GetAllAsync(int? status, int? type)
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllAsync("Gender", "Children", "Parent"));

            IQueryable<CategoryListVM> query = categoryListVMs.AsQueryable();

            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = query.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = query.Where(b => !b.IsDeleted);
                }
            }

            if (type != null && type > 0)
            {
                if (type == 1)
                {
                    query = query.Where(c => !c.IsMain);
                }
                else if (type == 2)
                {
                    query = query.Where(c => c.IsMain);
                }
                else if (type == 3)
                {
                    query = query.Where(c => c.GenderId == 2);
                }
                else if (type == 4)
                {
                    query = query.Where(c => c.GenderId == 1);
                }
            }

            return query;
        }


        public async Task<CategoryGetVM> GetById(int? id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (id == null)
                throw new NotFoundException($"Category Cannot be found By id = {id}");

            CategoryGetVM categoryGetVM = _mapper.Map<CategoryGetVM>(category);

            return categoryGetVM;
        }

        public async Task CreateAsync(CategoryCreateVM categoryCreateVM)
        {
            if (await _categoryRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == categoryCreateVM.Name.Trim().ToLower() && c.GenderId == categoryCreateVM.GenderId)))
                throw new RecordDublicateException($"Category Already Exists By Name = {categoryCreateVM.Name}");

            if (categoryCreateVM.FemaleParentId == null)
            {
                categoryCreateVM.ParentId = categoryCreateVM.MaleParentId;
                categoryCreateVM.MaleParentId = null;
            }
            else
            {
                categoryCreateVM.ParentId = categoryCreateVM.FemaleParentId;
                categoryCreateVM.FemaleParentId = null;
            }

            Category category = _mapper.Map<Category>(categoryCreateVM);

            if (category.IsMain)
            {
                category.Image = await categoryCreateVM.Photo.CreateAsync(_env, "assets", "images", "categories");
            }

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task UpdateAsync(int? id, CategoryUpdateVM categoryUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != categoryUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _categoryRepository.IsExistAsync(c => !c.IsDeleted
             && (c.Name.ToLower() == categoryUpdateVM.Name.Trim().ToLower() && c.GenderId == categoryUpdateVM.GenderId && c.Id != categoryUpdateVM.Id)))
                throw new RecordDublicateException($"Category Already Exists By Name = {categoryUpdateVM.Name}");

            if (categoryUpdateVM.FemaleParentId == null)
            {
                categoryUpdateVM.ParentId = categoryUpdateVM.MaleParentId;
                categoryUpdateVM.MaleParentId = null;
            }
            else
            {
                categoryUpdateVM.ParentId = categoryUpdateVM.FemaleParentId;
                categoryUpdateVM.FemaleParentId = null;
            }

            Category dbCategory = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == categoryUpdateVM.Id);

            if (dbCategory == null)
                throw new NotFoundException($"Category Cannot be found By id = {id}");

            if (categoryUpdateVM.Photo != null)
            {
                if (dbCategory.Image != null)
                {
                    FileManager.DeleteFile(_env, dbCategory.Image, "assets", "images", "categories");
                }

                dbCategory.Image = await categoryUpdateVM.Photo.CreateAsync(_env, "assets", "images", "categories");
            }

            dbCategory.Name = categoryUpdateVM.Name.Trim();
            dbCategory.GenderId = categoryUpdateVM.GenderId;
            dbCategory.IsMain = categoryUpdateVM.IsMain;
            dbCategory.ParentId = categoryUpdateVM.IsMain ? null : categoryUpdateVM.ParentId;
            dbCategory.IsUpdated = true;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Category category = await _categoryRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (category == null)
                throw new NotFoundException($"Category Cannot be found By id = {id}");

            if (category.IsMain)
            {
                List<Category> children = await _categoryRepository.GetAllByExAsync(c => c.ParentId == category.Id && !c.IsDeleted);

                foreach (Category child in children)
                {
                    child.IsDeleted = true;
                    child.DeletedAt = DateTime.UtcNow.AddHours(4);
                }
            }

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Category category = await _categoryRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (category == null)
                throw new NotFoundException($"Category Cannot be found By id = {id}");

            if (category.IsMain)
            {
                List<Category> children = await _categoryRepository.GetAllByExAsync(c => c.ParentId == category.Id && c.IsDeleted);

                foreach (Category child in children)
                {
                    child.IsDeleted = false;
                    child.DeletedAt = null;
                }
            }

            category.IsDeleted = false;
            category.DeletedAt = null;

            await _categoryRepository.CommitAsync();
        }

        public async Task<List<CategoryListVM>> GetChildrenMaleAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => !c.IsDeleted && !c.IsMain && c.GenderId == 2));

            return categoryListVMs;
        }

        public async Task<List<CategoryListVM>> GetChildrenFemaleAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => !c.IsDeleted && !c.IsMain && c.GenderId == 1));

            return categoryListVMs;
        }

        public async Task<List<CategoryListVM>> GetMainMaleAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => !c.IsDeleted && c.IsMain && c.GenderId == 2));

            return categoryListVMs;
        }

        public async Task<List<CategoryListVM>> GetMainFemaleAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => !c.IsDeleted && c.IsMain && c.GenderId == 1));

            return categoryListVMs;
        }

        public async Task<List<CategoryListVM>> GetMainAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => !c.IsDeleted && c.IsMain));

            return categoryListVMs;
        }

        public async Task<List<CategoryListVM>> GetChildrenAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => !c.IsDeleted && !c.IsMain, "Parent"));

            return categoryListVMs;
        }

    }
}
