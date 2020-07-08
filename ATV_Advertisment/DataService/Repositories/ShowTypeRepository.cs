using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IShowTypeRepository : IRepository<ShowType>
    {

    }
    public class ShowTypeRepository : Repository<ShowType>, IShowTypeRepository
    {
        public ShowTypeRepository()
        {
        }
    }
}
