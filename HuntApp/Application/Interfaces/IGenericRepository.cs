﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserApi.Entities;

namespace UserApi.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntitie
    {
        Task<T> GetAsync(Expression<Func<T, bool>> criteria, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> criteria = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<string[]> UpdateConcurrentlyAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
