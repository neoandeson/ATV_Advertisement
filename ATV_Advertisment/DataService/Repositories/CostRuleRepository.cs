using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ICostRuleRepository : IRepository<CostRule>
    {

    }
    public class CostRuleRepository : Repository<CostRule>, ICostRuleRepository
    {
        public CostRuleRepository()
        {
        }
    }
}
