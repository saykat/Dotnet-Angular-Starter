using Web.Api.Core.Domain.Entities;
using Web.Api.Infrastructure.Data;

namespace Web.Api.Infrastructure.Repository
{
    public interface IUserTestRepository : IBaseRepository<User>
    {

    }

    public class UserTestRepository : BaseRepository<User>, IUserTestRepository
    {
        public UserTestRepository(AppDbContext db) : base(db)
        {
        }
    }
}