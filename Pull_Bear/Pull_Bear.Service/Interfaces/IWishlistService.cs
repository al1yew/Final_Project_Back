using Pull_Bear.Service.ViewModels.WishlistVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IWishlistService
    {
        Task<bool> AddToWishlist(int? id);
        Task<List<WishlistVM>> DeleteFromWishlist(int? id);
        Task<List<WishlistVM>> GetWishlists();

    }
}
