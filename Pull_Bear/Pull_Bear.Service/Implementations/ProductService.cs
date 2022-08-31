﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Data.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Extensions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductToTagRepository _productToTagRepository;
        private readonly IProductColorSizeRepository _productColorSizeRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env, IColorRepository colorRepository, ISizeRepository sizeRepository, ICategoryRepository categoryRepository, IProductImageRepository productImageRepository, IProductToTagRepository productToTagRepository, IProductColorSizeRepository productColorSizeRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _productToTagRepository = productToTagRepository;
            _productColorSizeRepository = productColorSizeRepository;
        }

        public async Task<IQueryable<ProductListVM>> GetAllAsync(int? status, int? type)
        {
            List<ProductListVM> productListVMs = _mapper.Map<List<ProductListVM>>(await _productRepository.GetAllAsync("ProductColorSizes.Size", "ProductColorSizes.Color", "ProductToTags.Tag", "ProductImages", "Category", "BodyFit", "Gender"));

            IQueryable<ProductListVM> query = productListVMs.AsQueryable();

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
                    query = query.Where(x => x.GenderId == 1);
                }
                else if (type == 2)
                {
                    query = query.Where(x => x.GenderId == 2);
                }
                else if (type == 3)
                {
                    query = query.OrderBy(x => x.DiscountPrice);
                }
                else if (type == 4)
                {
                    query = query.OrderBy(x => x.Price);
                }
            }

            return query;
        }

        public async Task<ProductGetVM> GetById(int? id)
        {
            if (id == null)
                throw new NotFoundException($"Product Cannot be found By id = {id}");

            Product product = await _productRepository.GetAsync(x => x.Id == id && !x.IsDeleted, "ProductColorSizes.Size", "ProductColorSizes.Color", "ProductToTags.Tag", "ProductImages", "Category", "BodyFit", "Gender");

            ProductGetVM productGetVM = _mapper.Map<ProductGetVM>(product);

            return productGetVM;
        }

        public async Task CreateAsync(ProductCreateVM productCreateVM)
        {
            if (await _productRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == productCreateVM.Name.Trim().ToLower() && c.GenderId == productCreateVM.GenderId)))
                throw new RecordDublicateException($"Product Already Exists By Name = {productCreateVM.Name}");

            #region Product Color Sizes

            List<ProductColorSizeGetVM> productColorSizes = new List<ProductColorSizeGetVM>();

            for (int i = 0; i < productCreateVM.Counts.Count(); i++)
            {
                if (!(await _colorRepository.IsExistAsync(c => c.Id == productCreateVM.ColorIds[i])))
                    throw new NotFoundException($"Color cannot be found by id = {productCreateVM.ColorIds[i]}");

                if (!(await _sizeRepository.IsExistAsync(c => c.Id == productCreateVM.SizeIds[i])))
                    throw new NotFoundException($"Size cannot be found by id = {productCreateVM.SizeIds[i]}");

                ProductColorSizeGetVM productColorSize = new ProductColorSizeGetVM
                {
                    ColorId = productCreateVM.ColorIds[i],
                    SizeId = productCreateVM.SizeIds[i],
                    Count = productCreateVM.Counts[i]
                };

                productColorSizes.Add(productColorSize);
            }

            productCreateVM.ProductColorSizes = productColorSizes;

            #endregion

            #region Product Tags

            List<ProductToTagGetVM> productToTags = new List<ProductToTagGetVM>();

            for (int i = 0; i < productCreateVM.TagIds.Count; i++)
            {
                if (!(await _colorRepository.IsExistAsync(c => c.Id == productCreateVM.TagIds[i])))
                    throw new NotFoundException($"Tag cannot be found by id = {productCreateVM.TagIds[i]}");

                ProductToTagGetVM productTag = new ProductToTagGetVM
                {
                    TagId = productCreateVM.TagIds[i]
                };

                productToTags.Add(productTag);
            }

            productCreateVM.ProductToTags = productToTags;

            #endregion

            #region Category and Body Fit

            if (productCreateVM.FemaleCategoryId == null)
            {
                productCreateVM.CategoryId = (int)productCreateVM.MaleCategoryId;
                productCreateVM.MaleCategoryId = null;
                productCreateVM.FemaleCategoryId = null;
            }
            else
            {
                productCreateVM.CategoryId = (int)productCreateVM.FemaleCategoryId;
                productCreateVM.MaleCategoryId = null;
                productCreateVM.FemaleCategoryId = null;
            }

            if (productCreateVM.FemaleBodyFitId == null)
            {
                productCreateVM.BodyFitId = (int)productCreateVM.MaleBodyFitId;
                productCreateVM.FemaleBodyFitId = null;
                productCreateVM.MaleBodyFitId = null;
            }
            else
            {
                productCreateVM.BodyFitId = (int)productCreateVM.FemaleBodyFitId;
                productCreateVM.FemaleBodyFitId = null;
                productCreateVM.MaleBodyFitId = null;
            }

            #endregion

            int lastId = _productRepository.GetAllAsync().Result.Count == 0 ? 1 : _productRepository.GetAllAsync().Result.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            int lastSeria = _productRepository.GetAllAsync().Result.Count == 0 ? 1 : int.Parse(_productRepository.GetAllAsync().Result.OrderByDescending(x => x.Seria).FirstOrDefault().Seria.Substring(3));

            #region Product Images

            List<ProductImageGetVM> productImages = new List<ProductImageGetVM>();

            foreach (IFormFile file in productCreateVM.Files)
            {
                ProductImageGetVM productImage = new ProductImageGetVM
                {
                    Image = await file.CreateAsync(_env, "assets", "images", "productimages", $"{lastId + 1}")
                };

                productImages.Add(productImage);
            }

            productCreateVM.ProductImages = productImages;

            #endregion

            productCreateVM.ParentCategoryId = (int)_categoryRepository.GetAsync(c => !c.IsMain && c.Id == productCreateVM.CategoryId).Result.ParentId;

            Product product = _mapper.Map<Product>(productCreateVM);

            product.Seria = "ref" + +1;
            product.Count = productColorSizes.Sum(x => x.Count);
            product.ProductImage = await productCreateVM.ProductPhoto.CreateAsync(_env, "assets", "images", "products", $"{lastId + 1}");
            product.MainImage1 = await productCreateVM.MainPhoto1.CreateAsync(_env, "assets", "images", "products", $"{lastId + 1}");
            product.MainImage2 = await productCreateVM.MainPhoto2.CreateAsync(_env, "assets", "images", "products", $"{lastId + 1}");

            await _productRepository.AddAsync(product);
            await _productRepository.CommitAsync();
        }

        public async Task UpdateAsync(int? id, ProductUpdateVM productUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != productUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _productRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == productUpdateVM.Name.Trim().ToLower() && c.GenderId == productUpdateVM.GenderId)))
                throw new RecordDublicateException($"Product Already Exists By Name = {productUpdateVM.Name}");

            #region Product Color Sizes

            List<ProductColorSizeGetVM> productColorSizes = new List<ProductColorSizeGetVM>();

            for (int i = 0; i < productUpdateVM.Counts.Count(); i++)
            {
                if (!(await _colorRepository.IsExistAsync(c => c.Id == productUpdateVM.ColorIds[i])))
                    throw new NotFoundException($"Color cannot be found by id = {productUpdateVM.ColorIds[i]}");

                if (!(await _sizeRepository.IsExistAsync(c => c.Id == productUpdateVM.SizeIds[i])))
                    throw new NotFoundException($"Size cannot be found by id = {productUpdateVM.SizeIds[i]}");

                ProductColorSizeGetVM productColorSize = new ProductColorSizeGetVM
                {
                    ColorId = productUpdateVM.ColorIds[i],
                    SizeId = productUpdateVM.SizeIds[i],
                    Count = productUpdateVM.Counts[i]
                };

                productColorSizes.Add(productColorSize);
            }

            productUpdateVM.ProductColorSizes = productColorSizes;

            #endregion

            #region Product Tags

            List<ProductToTagGetVM> productToTags = new List<ProductToTagGetVM>();

            for (int i = 0; i < productUpdateVM.TagIds.Count; i++)
            {
                if (!(await _colorRepository.IsExistAsync(c => c.Id == productUpdateVM.TagIds[i])))
                    throw new NotFoundException($"Tag cannot be found by id = {productUpdateVM.TagIds[i]}");

                ProductToTagGetVM productTag = new ProductToTagGetVM
                {
                    TagId = productUpdateVM.TagIds[i]
                };

                productToTags.Add(productTag);
            }

            productUpdateVM.ProductToTags = productToTags;

            #endregion

            #region Category and Body Fit

            if (productUpdateVM.FemaleCategoryId == null)
            {
                productUpdateVM.CategoryId = (int)productUpdateVM.MaleCategoryId;
                productUpdateVM.MaleCategoryId = null;
                productUpdateVM.FemaleCategoryId = null;
            }
            else
            {
                productUpdateVM.CategoryId = (int)productUpdateVM.FemaleCategoryId;
                productUpdateVM.MaleCategoryId = null;
                productUpdateVM.FemaleCategoryId = null;
            }

            if (productUpdateVM.FemaleBodyFitId == null)
            {
                productUpdateVM.BodyFitId = (int)productUpdateVM.MaleBodyFitId;
                productUpdateVM.FemaleBodyFitId = null;
                productUpdateVM.MaleBodyFitId = null;
            }
            else
            {
                productUpdateVM.BodyFitId = (int)productUpdateVM.FemaleBodyFitId;
                productUpdateVM.FemaleBodyFitId = null;
                productUpdateVM.MaleBodyFitId = null;
            }

            #endregion

            #region Product Images

            List<ProductImageGetVM> productImages = new List<ProductImageGetVM>();

            foreach (IFormFile file in productUpdateVM.Files)
            {
                ProductImageGetVM productImage = new ProductImageGetVM
                {
                    Image = await file.CreateAsync(_env, "assets", "images", "productimages", $"{productUpdateVM.Id}")
                };

                productImages.Add(productImage);
            }

            productUpdateVM.ProductImages = productImages;

            #endregion

            productUpdateVM.ParentCategoryId = (int)_categoryRepository.GetAsync(c => !c.IsMain && c.Id == productUpdateVM.CategoryId).Result.ParentId;

            Product product = _mapper.Map<Product>(productUpdateVM);

            product.Count = productColorSizes.Sum(x => x.Count);
            product.ProductImage = await productUpdateVM.ProductPhoto.CreateAsync(_env, "assets", "images", "products", $"{productUpdateVM.Id}");
            product.MainImage1 = await productUpdateVM.MainPhoto1.CreateAsync(_env, "assets", "images", "products", $"{productUpdateVM.Id}");
            product.MainImage2 = await productUpdateVM.MainPhoto2.CreateAsync(_env, "assets", "images", "products", $"{productUpdateVM.Id}");

            await _productRepository.AddAsync(product);
            await _productRepository.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Product product = await _productRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (product == null)
                throw new NotFoundException($"Product Cannot be found By id = {id}");

            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _productRepository.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Product product = await _productRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (product == null)
                throw new NotFoundException($"Product Cannot be found By id = {id}");

            product.IsDeleted = false;
            product.DeletedAt = null;

            await _productRepository.CommitAsync();
        }

        public async Task<List<ProductImageGetVM>> DeleteImage(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            ProductImage productImage = await _productImageRepository.GetAsync(x => x.Id == id);

            if (productImage == null)
                throw new NotFoundException("Image cannot be found!");

            _productImageRepository.Remove(productImage);
            await _productImageRepository.CommitAsync();

            FileManager.DeleteFile(_env, productImage.Image, "assets", "images", "productimages", $"{productImage.ProductId}");

            return _mapper.Map<List<ProductImageGetVM>>(await _productImageRepository.GetAllAsync());
        }

        public async Task<List<ProductToTagGetVM>> DeleteTag(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            ProductToTag productToTag = await _productToTagRepository.GetAsync(x => x.Id == id);

            if (productToTag == null)
                throw new NotFoundException("ProductToTag cannot be found!");

            _productToTagRepository.Remove(productToTag);
            await _productToTagRepository.CommitAsync();

            return _mapper.Map<List<ProductToTagGetVM>>(await _productToTagRepository.GetAllAsync());
        }

        public async Task<List<ProductColorSizeGetVM>> DeleteColorSize(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            ProductColorSize productColorSize = await _productColorSizeRepository.GetAsync(x => x.Id == id);

            if (productColorSize == null)
                throw new NotFoundException("ProductColorSize cannot be found!");

            _productColorSizeRepository.Remove(productColorSize);
            await _productColorSizeRepository.CommitAsync();

            return _mapper.Map<List<ProductColorSizeGetVM>>(await _productColorSizeRepository.GetAllAsync());
        }

        public async Task<List<ProductColorSizeGetVM>> UpdateProductColorSize(ProductColorSizeUpdateVM productColorSizeUpdateVM)
        {
            if (productColorSizeUpdateVM == null)
                throw new BadRequestException("Something went wrong! The model passed to Post method is false!");
            //yoxlamag belke eyni adda eyni size da eledi, olari birleshdirmek lazimdi ve dbya gondermek, dla etogo est IsExistAsync
            int color = productColorSizeUpdateVM.Color ? 1 : 0;
            int size = productColorSizeUpdateVM.Size ? 1 : 0;
            int count = productColorSizeUpdateVM.Count ? 1 : 0;

            if (color + size + count > 1)
                throw new BadRequestException("You cannot update more than 1 Product-Color-Size property!");

            ProductColorSize productColorSize = await _productColorSizeRepository.GetAsync(x => x.Id == productColorSizeUpdateVM.Id);

            if (productColorSize == null)
                throw new NotFoundException("ProductColorSize cannot be found!");

            switch (1)
            {
                case int value when value == color:

                    Color clr = await _colorRepository.GetAsync(x => x.Id == productColorSizeUpdateVM.ChangeValue);

                    if (clr == null)
                        throw new NotFoundException("Selected color cannot be found in database. Enter right value from Select Option!");

                    productColorSize.ColorId = productColorSizeUpdateVM.ChangeValue;

                    await _productColorSizeRepository.CommitAsync();

                    return _mapper.Map<List<ProductColorSizeGetVM>>(await _productColorSizeRepository.GetAllAsync());

                case int value when value == size:

                    Size sz = await _sizeRepository.GetAsync(x => x.Id == productColorSizeUpdateVM.ChangeValue);

                    if (sz == null)
                        throw new NotFoundException("Selected size cannot be found in database. Enter right value from Select Option!");

                    productColorSize.SizeId = productColorSizeUpdateVM.ChangeValue;

                    await _productColorSizeRepository.CommitAsync();

                    return _mapper.Map<List<ProductColorSizeGetVM>>(await _productColorSizeRepository.GetAllAsync());

                case int value when value == count:

                    productColorSize.Count = productColorSizeUpdateVM.ChangeValue;

                    await _productColorSizeRepository.CommitAsync();

                    return _mapper.Map<List<ProductColorSizeGetVM>>(await _productColorSizeRepository.GetAllAsync());

                default:
                    throw new NotFoundException("Enter acceptable values from Select Options!!!");
            }
        }
    }
}
