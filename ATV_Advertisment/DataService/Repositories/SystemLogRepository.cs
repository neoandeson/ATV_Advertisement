using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ISystemLogRepository : IRepository<SystemLog>
    {

    }
    public class SystemLogRepository : Repository<SystemLog>, ISystemLogRepository
    {
        public SystemLogRepository()
        {
        }
    }
}
