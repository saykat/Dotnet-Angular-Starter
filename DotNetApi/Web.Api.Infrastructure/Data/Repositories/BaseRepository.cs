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
        T GetById(string id);
        IQueryable<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }


    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public AppDbContext _context;

        public BaseRepository(AppDbContext appContext)
        {
            _context = appContext;
        }
        public virtual  TEntity GetById(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public  IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
       
        public  TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void  Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }

}