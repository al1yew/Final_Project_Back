using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Data.Repositories
{
    public class BodyFitRepository : Repository<BodyFit>, IBodyFitRepository
    {
        public BodyFitRepository(AppDbContext context) : base(context)
        {

        }
    }
}
