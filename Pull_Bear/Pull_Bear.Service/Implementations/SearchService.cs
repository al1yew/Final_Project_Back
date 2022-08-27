﻿using AutoMapper;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Data.Repositories;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.SearchVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pull_Bear.Service.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBodyFitRepository _bodyFitRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public SearchService(ICategoryRepository categoryRepository, IMapper mapper, IBodyFitRepository bodyFitRepository, IColorRepository colorRepository, ISizeRepository sizeRepository, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _bodyFitRepository = bodyFitRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _tagRepository = tagRepository;
        }

        public SearchListVM GetAllAsync(string search)
        {
            SearchListVM searchVM = new SearchListVM
            {
                Categories = _mapper.Map<List<CategoryListVM>>(_categoryRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()), "Gender", "Children", "Parent").Result),
                BodyFits = _mapper.Map<List<BodyFitListVM>>(_bodyFitRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()), "Gender").Result),
                Colors = _mapper.Map<List<ColorListVM>>(_colorRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower())).Result),
                Sizes = _mapper.Map<List<SizeListVM>>(_sizeRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower())).Result),
                Tags = _mapper.Map<List<TagListVM>>(_tagRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower())).Result)
            };

            return searchVM;
        }
    }
}
