using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IContractRepository : IRepository<Contract>
    {

    }
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository()
        {
        }
    }
}
