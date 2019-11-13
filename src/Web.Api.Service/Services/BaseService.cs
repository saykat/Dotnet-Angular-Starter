

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto.RequestModels;
using Web.Api.Core.Dto.ViewModels;
using Web.Api.Core.Shared;
using Web.Api.Infrastructure;
using Web.Api.Infrastructure.Repository;

namespace Web.Api.Service.Services
{
    public interface IBaseService<T, TVm, TRm>
        where T : BaseEntity
        where TVm : BaseViewModel<T>
        where TRm : BaseRequestModel<T>
    {
        Task<List<TVm>> GetAll();
        Task<TVm> Get(string id);
        Task<int> Count();
        Task<TVm> Add(T entity);
        //        Task<bool> Add(List<T> entries);
        void Edit(T entity);
        void Delete(T entity);
        //        bool Delete(string id, string userId);

    }
    public abstract class BaseService<TEntity, TViewModel, TRequestModel> : IBaseService<TEntity, TViewModel, TRequestModel>
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel<TEntity>
    where TRequestModel : BaseRequestModel<TEntity>
    {
        protected IBaseRepository<TEntity> Repository;

        protected BaseService(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual async Task<List<TViewModel>> GetAll()
        {
            var entityList = Repository.GetAll().ToList();
            var entityViewsList = entityList.ConvertAll(x => (TViewModel)Activator.CreateInstance(typeof(TViewModel), x));
            return entityViewsList;
        }

        public virtual async Task<TViewModel> Get(string id)
        {
            var entity = Repository.GetById(id);
            var entityViewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), entity);
            return entityViewModel;
        }



        public virtual async Task<TViewModel> Add(TEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id.ToString())) entity.Id = Guid.NewGuid();
            var savedEntity = Repository.Add(entity);
            return (TViewModel)Activator.CreateInstance(typeof(TViewModel), savedEntity);
        }

        //        public virtual Task<bool> Add(List<TEntity> entries)
        //        {
        //            foreach (var entry in entries)
        //            {
        //                if (string.IsNullOrWhiteSpace(entry.Id.ToString())) entry.Id = Guid.NewGuid();
        //            }
        //
        //            IEnumerable<TEntity> add = Repository.Add(entries).AsEnumerable();
        //           
        //            return save;
        //        }

        public virtual void Edit(TEntity entity)
        {
            Repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        public virtual async Task<int> Count()
        {
            return Repository.GetAll().Count();
        }

        //        public virtual bool Delete(string id, string userId)
        //        {
        //            var entity = Repository.Filter(x => x.Id == id).FirstOrDefault();
        //            bool deleted = false;
        //            if (entity != null)
        //            {
        //                entity.DeletedBy = userId;
        //                deleted = Repository.Delete(entity);
        //                Repository.Save();
        //            }
        //            return deleted;
        //        }


        //*****************to base transfar methodes *************************
        //        public virtual List<TVm> GetList(TRm requestModel)
        //        {
        //            var queryable = requestModel.GetOrderedData(Repository.Get());
        //            queryable = requestModel.SkipAndTake(queryable);
        //            var viewModels = queryable.ToList().ConvertAll(x => (TVm)Activator.CreateInstance(typeof(TVm), x));
        //            return viewModels;
        //        }
        //
        //        public virtual int Count(TRm requestModel)
        //        {
        //            var queryable = requestModel.GetOrderedData(Repository.Get());
        //            var count = queryable.Count();
        //            return count;
        //        }
        //
        //        public virtual TDVm GetDetail(string id)
        //        {
        //            var entity = Repository.Filter(x => x.Id == id).FirstOrDefault();
        //            return entity != null ? (TDVm)Activator.CreateInstance(typeof(TDVm), entity) : null;
        //        }

    }
}