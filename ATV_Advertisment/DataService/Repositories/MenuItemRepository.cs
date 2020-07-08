using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {

    }
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository()
        {
        }
    }
}
