using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Repositories
{
    public class ProductColorSizeRepository : Repository<ProductColorSize>, IProductColorSizeRepository
    {
        public ProductColorSizeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
