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

}