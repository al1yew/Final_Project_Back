﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> GetAllAsync(Expression<Func<TEntity, bool>> ex);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> ex);
        void Remove(TEntity entity);
        Task<int> CommitAsync();
        int Commit();

    }
}
