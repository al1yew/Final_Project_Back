﻿using Microsoft.EntityFrameworkCore;
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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
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

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null && includes.Length > 0)
            {
                foreach (string inc in includes)
                {
                    query = query.Include(inc);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByExAsync(Expression<Func<TEntity, bool>> ex, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(ex);

            if (includes != null && includes.Length > 0)
            {
                foreach (string inc in includes)
                {
                    query = query.Include(inc);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> ex, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(ex);

            if (includes != null && includes.Length > 0)
            {
                foreach (string inc in includes)
                {
                    query = query.Include(inc);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> ex)
        {
            return await _context.Set<TEntity>().AnyAsync(ex);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
