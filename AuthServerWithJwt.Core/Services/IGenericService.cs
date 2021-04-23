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
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<TDto>> AddAsync(TDto entity);
        Response<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<TDto>> Update(TDto entity, int id);
    }
}
