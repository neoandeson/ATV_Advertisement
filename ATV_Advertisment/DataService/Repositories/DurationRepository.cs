using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IDurationRepository : IRepository<Duration>
    {

    }
    public class DurationRepository : Repository<Duration>, IDurationRepository
    {
        public DurationRepository()
        {
        }
    }
}
