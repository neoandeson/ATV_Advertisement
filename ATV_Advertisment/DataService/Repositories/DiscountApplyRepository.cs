using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface IDiscountApplyRepository : IRepository<DiscountApply>
    {

    }
    public class DiscountApplyRepository : Repository<DiscountApply>, IDiscountApplyRepository
    {
        public DiscountApplyRepository()
        {
        }
    }
}
