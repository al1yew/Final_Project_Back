using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsAdmin { get; set; }
        public Gender Gender { get; set; }
        public int? GenderId { get; set; }


        //for crud
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }


        //relations many to many
        public List<Basket> Baskets { get; set; }
        public List<Order> Orders { get; set; }
        public List<Wishlist> Wishlists { get; set; }
        public List<ProductReview> ProductReviews { get; set; }
        public List<Card> Cards { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
