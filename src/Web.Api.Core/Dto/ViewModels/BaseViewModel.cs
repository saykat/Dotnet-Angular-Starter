using System;
using Web.Api.Core.Shared;

namespace Web.Api.Core.Dto.ViewModels
{
    public class BaseViewModel<T> where T: BaseEntity
    {
        public BaseViewModel(T model)
        {
            Id = model.Id;
            CreatedUserId = model.CreatedUserId;
            CreationTime = model.CreationTime;
            ModifiedUserId = model.ModifiedUserId;
            ModificationTime = model.ModificationTime;
            IsDeleted = model.IsDeleted;
            DeletedUserId = model.DeletedUserId;
            DeletionTime = model.DeletionTime;
        }


        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? CreatedUserId { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now.ToUniversalTime();
        public Guid? ModifiedUserId { get; set; }
        public DateTime? ModificationTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? DeletedUserId { get; set; }
        public DateTime? DeletionTime { get; set; }

    }
}