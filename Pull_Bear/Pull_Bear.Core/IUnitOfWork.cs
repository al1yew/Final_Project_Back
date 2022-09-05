using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pull_Bear.Core.Repositories;

namespace Pull_Bear.Core
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUserRepository { get; }
        IBodyFitRepository BodyFitRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IColorRepository ColorRepository { get; }
        IProductColorSizeRepository ProductColorSizeRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductToTagRepository ProductToTagRepository { get; }
        IProductRepository ProductRepository { get; }
        ISettingRepository SettingRepository { get; }
        ISizeRepository SizeRepository { get; }
        ITagRepository TagRepository { get; }
        IBasketRepository BasketRepository { get; }
        IWishlistRepository WishlistRepository { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
