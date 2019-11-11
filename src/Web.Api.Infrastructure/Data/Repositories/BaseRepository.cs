using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Api.Core.Interfaces.Gateways.Repositories;
using Web.Api.Core.Shared;
using Web.Api.Infrastructure.Data;

namespace Web.Api.Infrastructure.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IQueryable<T>> ListAll();
        Task<T> GetSingleBySpec(ISpecification<T> spec);
        Task<List<T>> List(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }


    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appContext)
        {
            _appDbContext = appContext;
        }
        public virtual async Task<TEntity> GetById(int id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> ListAll()
        {
            return  _appDbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetSingleBySpec(ISpecification<TEntity> spec)
        {
            var result = await List(spec);
            return result.FirstOrDefault();
        }

        public async Task<List<TEntity>> List(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_appDbContext.Set<TEntity>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }


        public async Task<TEntity> Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }

}