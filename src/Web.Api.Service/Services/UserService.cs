using Web.Api.Core.Domain.Entities;
using Web.Api.Core.Dto.RequestModels;
using Web.Api.Core.Dto.ViewModels;
using Web.Api.Infrastructure.Repository;

namespace Web.Api.Service.Services
{
    public interface IUserService : IBaseService<User, UserViewModel, UserRequestModel>
    {

    }
    public class UserService : BaseService<User, UserViewModel, UserRequestModel>, IUserService
    {
        private IUserTestRepository _repository;

        public UserService(IUserTestRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }

    public class UserViewModel : BaseViewModel<User>
    {
        public UserViewModel(User model) : base(model)
        {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.IdentityId = model.IdentityId;
            this.UserName = model.UserName;
            this.Email = model.Email;
        }

        public string FirstName { get; set; } // EF migrations require at least private setter - won't work on auto-property
        public string LastName { get; set; }
        public string IdentityId { get; set; }
        public string UserName { get; set; } // Required by automapper
        public string Email { get; set; }
    }

    public class UserRequestModel : BaseRequestModel<User>
    {
        public UserRequestModel()
        {

        }
    }
}