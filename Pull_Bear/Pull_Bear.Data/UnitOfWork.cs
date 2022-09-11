using Pull_Bear.Core;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppUserRepository _appUserRepository;
        private readonly BodyFitRepository _bodyFitRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ColorRepository _colorRepository;
        private readonly ProductColorSizeRepository _productColorSizeRepository;
        private readonly ProductImageRepository _productImageRepository;
        private readonly ProductToTagRepository _productToTagRepository;
        private readonly ProductRepository _productRepository;
        private readonly SettingRepository _settingRepository;
        private readonly SizeRepository _sizeRepository;
        private readonly TagRepository _tagRepository;
        private readonly BasketRepository _basketRepository;
        private readonly WishlistRepository _wishlistRepository;
        private readonly ProductReviewRepository _productReviewRepository;
        private readonly CardRepository _cardRepository;
        private readonly AddressRepository _addressRepository;
        private readonly OrderRepository _orderRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAppUserRepository AppUserRepository => _appUserRepository != null ? _appUserRepository : new AppUserRepository(_context);

        public IBodyFitRepository BodyFitRepository => _bodyFitRepository != null ? _bodyFitRepository : new BodyFitRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository != null ? _categoryRepository : new CategoryRepository(_context);

        public IColorRepository ColorRepository => _colorRepository != null ? _colorRepository : new ColorRepository(_context);

        public IProductColorSizeRepository ProductColorSizeRepository => _productColorSizeRepository != null ? _productColorSizeRepository : new ProductColorSizeRepository(_context);

        public IProductImageRepository ProductImageRepository => _productImageRepository != null ? _productImageRepository : new ProductImageRepository(_context);

        public IProductToTagRepository ProductToTagRepository => _productToTagRepository != null ? _productToTagRepository : new ProductToTagRepository(_context);

        public IProductRepository ProductRepository => _productRepository != null ? _productRepository : new ProductRepository(_context);

        public ISettingRepository SettingRepository => _settingRepository != null ? _settingRepository : new SettingRepository(_context);

        public ISizeRepository SizeRepository => _sizeRepository != null ? _sizeRepository : new SizeRepository(_context);

        public ITagRepository TagRepository => _tagRepository != null ? _tagRepository : new TagRepository(_context);

        public IBasketRepository BasketRepository => _basketRepository != null ? _basketRepository : new BasketRepository(_context);

        public IWishlistRepository WishlistRepository => _wishlistRepository != null ? _wishlistRepository : new WishlistRepository(_context);

        public IProductReviewRepository ProductReviewRepository => _productReviewRepository != null ? _productReviewRepository : new ProductReviewRepository(_context);

        public ICardRepository CardRepository => _cardRepository != null ? _cardRepository : new CardRepository(_context);

        public IAddressRepository AddressRepository => _addressRepository != null ? _addressRepository : new AddressRepository(_context);

        public IOrderRepository OrderRepository => _orderRepository != null ? _orderRepository : new OrderRepository(_context);


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
