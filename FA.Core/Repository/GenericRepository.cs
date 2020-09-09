using FA.Core.Model;
using FA.Project.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FA.Core.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly TMSContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TMSContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public int Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in
                includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // orderBy ~ q => q.OrderByDescending(c => c.Title)
            return orderBy != null ? orderBy(query) : query;
        }

        //public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = _dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in
        //        includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    // orderBy ~ q => q.OrderByDescending(c => c.Title)
        //    return orderBy != null ? orderBy(query) : query;
        //}

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public bool Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        //public void Add(T entity)
        //{
        //    _dbSet.Add(entity);
        //    _context.SaveChanges();
        //}

        //public void Delete(T entity)
        //{
        //    _dbSet.Remove(entity);
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    if (Find(id) == null)
        //    {
        //        throw new ArgumentNullException("Not found!");
        //    }
        //    else
        //    {
        //        var entity = _dbSet.Find(id);
        //        _dbSet.Remove(entity);
        //        _context.SaveChanges();
        //    }
        //}

        //public T Find(int id)
        //{
        //    return (T)_dbSet.Find(id);
        //}

        //public IList<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}

        //public void Update(T entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}
    }
}
