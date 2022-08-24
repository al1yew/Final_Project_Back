using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IQueryable<CategoryListVM> GetAllAsync(int? status, int? type)
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(_categoryRepository.GetAllAsync().Result);

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
            }

            return query;
        }

        public List<CategoryListVM> GetMainAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(_categoryRepository.GetAllByExAsync(c => !c.IsDeleted && c.IsMain).Result);

            return categoryListVMs;
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
            if (await _categoryRepository.IsExistAsync(c => !c.IsDeleted && c.Name.ToLower() == categoryCreateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Category Already Exist By Name = {categoryCreateVM.Name}");

            Category category = _mapper.Map<Category>(categoryCreateVM);

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task UpdateAsync(int? id, CategoryUpdateVM categoryUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != categoryUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (!categoryUpdateVM.IsMain)
            {
                if (await _categoryRepository.IsExistAsync(c => c.Id == categoryUpdateVM.ParentId && c.IsMain && !c.IsDeleted))
                    throw new BadRequestException($"You Cannot set Parent Category to category you are updating!");
            }

            if (await _categoryRepository.IsExistAsync(c => c.Id != categoryUpdateVM.Id && c.Name.ToLower() == categoryUpdateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Category Already Exist By Name = {categoryUpdateVM.Name}");

            Category dbCategory = await _categoryRepository.GetAsync(c => !c.IsDeleted && c.Id == categoryUpdateVM.Id);

            if (dbCategory == null)
                throw new NotFoundException($"Category Cannot be found By id = {id}");

            dbCategory.Name = categoryUpdateVM.Name.Trim();
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



    }
}
