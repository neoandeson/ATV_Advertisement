using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IContractItemlRepository : IRepository<ContractItem>
    {

    }
    public class ContractItemlRepository : Repository<ContractItem>, IContractItemlRepository
    {
        public ContractItemlRepository()
        {
        }
    }
}
