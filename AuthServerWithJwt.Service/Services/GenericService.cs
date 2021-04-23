using AuthServerWithJwt.Core;
using AuthServerWithJwt.Core.Services;
using AuthServerWithJwt.Core.UnitOfWork;
using AuthServerWithJwt.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            this._unitOfWork = unitOfWork;
            this._genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _genericRepository.AddAsync(newEntity);
            await _unitOfWork.CommitAsyn();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return Response<TDto>.Success(newDto, 200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());

            return Response<IEnumerable<TDto>>.Success(products, 200);
        }

        public async Task<Response<TDto>> GetByIdAsyn(int Id)
        {
            var product = ObjectMapper.Mapper.Map<TDto>(await _genericRepository.GetByIdAsyn(Id));
            if (product == null) return Response<TDto>.Fail("id is was found", 200, true);
            return Response<TDto>.Success(product, 200);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var removeEntity = await _genericRepository.GetByIdAsyn(id);
            if (removeEntity == null) return Response<NoDataDto>.Fail("id is not found", 404, true);
            var t = Task.Run(() => _genericRepository.Remove(removeEntity));
            t.Wait();
            await _unitOfWork.CommitAsyn();

            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<TDto>> Update(TDto entity,int id)
        {
            var existEntity = await _genericRepository.GetByIdAsyn(id);
            if (existEntity == null) return Response<TDto>.Fail("id is not found", 404, true);

            var updatedEntity=_genericRepository.Update(ObjectMapper.Mapper.Map<TEntity>(existEntity));
            _unitOfWork.Commit();

            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(updatedEntity),204);
        }

        public  Response<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _genericRepository.Where(predicate);

            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>( entities.ToList()),200);
        }
    }
}
