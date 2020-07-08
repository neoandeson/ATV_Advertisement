using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {

    }
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository()
        {
        }
    }
}
