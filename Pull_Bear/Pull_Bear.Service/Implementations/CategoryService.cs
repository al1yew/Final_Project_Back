using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
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

        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (category == null)
                throw new NotFoundException($"Cannot find category by id = {id}");

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();
        }

        public async Task<List<CategoryListVM>> GetAllAsync()
        {
            List<CategoryListVM> categoryListVMs = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllAsync(x => !x.IsDeleted));

            return categoryListVMs;
        }

        public async Task<CategoryGetVM> GetById(int id)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            CategoryGetVM categoryGetVM = _mapper.Map<CategoryGetVM>(category);

            return categoryGetVM;
        }

        public async Task PostAsync(CategoryCreateVM categoryCreateVM)
        {
            Category category = _mapper.Map<Category>(categoryCreateVM);

            //category.image = nese

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.CommitAsync();
        }

        public async Task UpdateAsync(int id, CategoryUpdateVM categoryUpdateVM)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            category.Name = categoryUpdateVM.Name;
            category.IsMain = categoryUpdateVM.IsMain;
            category.ParentId = categoryUpdateVM.ParentId;
            //category.image = nese krc

            category.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _categoryRepository.CommitAsync();
        }
    }
}
