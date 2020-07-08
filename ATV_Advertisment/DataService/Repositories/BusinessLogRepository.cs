using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IBusinessLogRepository : IRepository<BusinessLog>
    {

    }
    public class BusinessLogRepository : Repository<BusinessLog>, IBusinessLogRepository
    {
        public BusinessLogRepository()
        {
        }
    }
}
