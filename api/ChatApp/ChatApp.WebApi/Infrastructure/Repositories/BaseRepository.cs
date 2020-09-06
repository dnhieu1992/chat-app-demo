using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ChatApp.WebApi.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Properties
        private ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;
        #endregion
        #region Constructor
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        #endregion
        #region Methods
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }
        public virtual T FindById(object id)
        {
            return _dbSet.Find(id);
        }
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public virtual void DeleteById(object id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }
        #endregion
    }
}
