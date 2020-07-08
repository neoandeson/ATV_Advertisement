using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IRoleHasMenuItemRepository : IRepository<RoleHasMenuItem>
    {

    }
    public class RoleHasMenuItemRepository : Repository<RoleHasMenuItem>, IRoleHasMenuItemRepository
    {
        public RoleHasMenuItemRepository()
        {
        }
    }
}
