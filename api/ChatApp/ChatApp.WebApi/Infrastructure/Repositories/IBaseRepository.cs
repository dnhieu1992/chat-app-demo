using System;
using System.Linq;
using System.Linq.Expressions;

namespace ChatApp.WebApi.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        T FindById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entiy);
        void DeleteById(object id);

    }
}
