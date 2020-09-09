﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Model
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //T Find(int id);
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //void Delete(int id);
        //IList<T> GetAll();

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        int Create(TEntity entity);

        Task<int> CreateAsync(TEntity entity);

        bool Update(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        // Expression<Func<TEntity, bool>> filter ~ x => x.Name.Contains(searchString)
        // Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy ~ q => q.OrderByDescending(c => c.Title);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    }
}
