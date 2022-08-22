using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();

        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> ex)
        {
            return await _context.Set<TEntity>().Where(ex).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> ex)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(ex);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
