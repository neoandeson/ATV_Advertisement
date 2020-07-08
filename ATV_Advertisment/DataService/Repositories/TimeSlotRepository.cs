using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {

    }
    public class TimeSlotRepository : Repository<TimeSlot>, ITimeSlotRepository
    {
        public TimeSlotRepository()
        {
        }
    }
}
