using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository()
        {
        }
    }
}
