using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IProductScheduleShowRepository : IRepository<ProductScheduleShow>
    {

    }
    public class ProductScheduleShowRepository : Repository<ProductScheduleShow>, IProductScheduleShowRepository
    {
        public ProductScheduleShowRepository()
        {
        }
    }
}
