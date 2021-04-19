using AuthServerWithJwt.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Core.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsyn(int Id);
        Task<Response<IQueryable<TDto>>> GetAll();
        Task<Response<TDto>> Add(TEntity entity);
        Response<IEnumerable<TDto>> Get(Expression<Func<TEntity, bool>> predicate);
        Task<Response<NoDataDto>> Remove(TEntity entity);
        Task<Response<TDto>> Update(TEntity entity);
    }
}
