using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {

    }
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository()
        {
        }
    }
}
