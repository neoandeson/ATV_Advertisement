using DataService.Infrastructure;
using DataService.Model;

namespace DataService.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {

    }
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository()
        {
        }
    }
}
