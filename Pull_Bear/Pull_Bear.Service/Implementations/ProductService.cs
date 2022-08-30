using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
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
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env, IColorRepository colorRepository, ISizeRepository sizeRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IQueryable<ProductListVM>> GetAllAsync(int? status, int? type)
        {
            List<ProductListVM> productListVMs = _mapper.Map<List<ProductListVM>>(await _productRepository.GetAllAsync("ProductColorSizes.Size", "ProductColorSizes.Color", "Category", "BodyFit", "Gender"));

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

            Product product = await _productRepository.GetAsync(x => x.Id == id && !x.IsDeleted, "ProductColorSizes.Size", "ProductColorSizes.Color", "Category", "BodyFit", "Gender");

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

            #region Product Images

            List<ProductImageGetVM> productImages = new List<ProductImageGetVM>();

            foreach (IFormFile file in productCreateVM.Files)
            {
                ProductImageGetVM productImage = new ProductImageGetVM
                {
                    Image = await file.CreateAsync(_env, "assets", "images", "products")
                };

                productImages.Add(productImage);
            }

            productCreateVM.ProductImages = productImages;

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

            productCreateVM.ParentCategoryId = (int)_categoryRepository.GetAsync(c => !c.IsMain && c.Id == productCreateVM.CategoryId).Result.ParentId;

            Product product = _mapper.Map<Product>(productCreateVM);

            int seria = int.Parse(_productRepository.GetAllAsync().Result.OrderByDescending(x => x.Seria).FirstOrDefault().ToString()[4..]);

            product.Seria = "ref" + seria;
            product.Count = productColorSizes.Sum(x => x.Count);
            product.ProductImage = await productCreateVM.ProductPhoto.CreateAsync(_env, "assets", "images", "products");
            product.MainImage1 = await productCreateVM.MainPhoto1.CreateAsync(_env, "assets", "images", "products");
            product.MainImage2 = await productCreateVM.MainPhoto2.CreateAsync(_env, "assets", "images", "products");

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
             && (c.Name.ToLower() == productUpdateVM.Name.Trim().ToLower() && c.GenderId == productUpdateVM.GenderId && c.Id != productUpdateVM.Id)))
                throw new RecordDublicateException($"Product Already Exists By Name = {productUpdateVM.Name}");

            Product dbProduct = await _productRepository.GetAsync(c => !c.IsDeleted && c.Id == productUpdateVM.Id);

            if (dbProduct == null)
                throw new NotFoundException($"Product Cannot be found By id = {id}");

            dbProduct.Name = productUpdateVM.Name.Trim();
            dbProduct.GenderId = productUpdateVM.GenderId;
            dbProduct.IsUpdated = true;
            dbProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

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
    }
}
