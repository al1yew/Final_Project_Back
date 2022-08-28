using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Extensions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
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
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
        }

        public IQueryable<ProductListVM> GetAllAsync(int? status, int? type)
        {
            List<Product> products = _productRepository.GetAllAsync("ProductColorSizes.Size", "ProductColorSizes.Color", "Category", "BodyFit", "Gender").Result;

            List<ProductListVM> productListVMs = _mapper.Map<List<ProductListVM>>(products);

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
            Product product = await _productRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (id == null)
                throw new NotFoundException($"Product Cannot be found By id = {id}");

            ProductGetVM productGetVM = _mapper.Map<ProductGetVM>(product);

            return productGetVM;
        }

        public async Task CreateAsync(ProductCreateVM productCreateVM)
        {
            if (await _productRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == productCreateVM.Name.Trim().ToLower() && c.GenderId == productCreateVM.GenderId)))
                throw new RecordDublicateException($"Product Already Exists By Name = {productCreateVM.Name}");

            Product product = _mapper.Map<Product>(productCreateVM);

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
