using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ISystemConfigRepository : IRepository<SystemConfig>
    {

    }
    public class SystemConfigRepository : Repository<SystemConfig>, ISystemConfigRepository
    {
        public SystemConfigRepository()
        {
        }
    }
}
