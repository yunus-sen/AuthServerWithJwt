using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AuthServerWithJwt.Core
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsyn(int Id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);

    }
}
