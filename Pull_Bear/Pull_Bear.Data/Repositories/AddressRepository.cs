using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {

        }
    }
}
