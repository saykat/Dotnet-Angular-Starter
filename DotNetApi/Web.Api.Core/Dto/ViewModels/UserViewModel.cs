using Web.Api.Core.Domain.Entities;

namespace Web.Api.Core.Dto.ViewModels
{
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
}