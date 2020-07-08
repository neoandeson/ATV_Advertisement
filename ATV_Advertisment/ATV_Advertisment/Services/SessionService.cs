using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ISessionService
    {
        Session GetById(int id);
        List<Session> GetAll();
        Dictionary<string, string> Getoptions();
        List<string> GetSessionCodeAndName();
        bool IsExistCode(string code);
        int DeleteSession(int id);
        int AddSession(Session input);
        int EditSession(Session input);
    }

    public class SessionService : ISessionService
    {
        private readonly SessionRepository _SessionRepository;

        public SessionService()
        {
            _SessionRepository = new SessionRepository();
        }

        public int AddSession(Session input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                var session = _SessionRepository.Get(t => t.Name == input.Name || t.Code == input.Code).FirstOrDefault();
                if (session == null)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Common.Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Common.Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _SessionRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                } else if (session != null && session.StatusId == CommonStatus.DELETE)
                {
                    session.Name = input.Name;
                    session.StatusId = CommonStatus.ACTIVE;
                    _SessionRepository.Update(session);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public int DeleteSession(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var Session = _SessionRepository.GetById(id);
            if (Session != null)
            {
                Session.StatusId = CommonStatus.DELETE;
                Session.LastUpdateDate = Common.Utilities.GetServerDateTimeNow();
                Session.LastUpdateBy = Common.Session.GetId();
                _SessionRepository.Update(Session);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditSession(Session input)
        {
            int result = CRUDStatusCode.ERROR;
            var Session = _SessionRepository.GetById(input.Id);
            if (Session != null)
            {
                Session.Name = input.Name;

                Session.LastUpdateDate = Common.Utilities.GetServerDateTimeNow();
                Session.LastUpdateBy = Common.Session.GetId();
                _SessionRepository.Update(Session);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<Session> GetAll()
        {
            return _SessionRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public Session GetById(int id)
        {
            return _SessionRepository.GetById(id);
        }

        public Dictionary<string, string> Getoptions()
        {
            var options = _SessionRepository.Get(s => s.StatusId == CommonStatus.ACTIVE).ToDictionary(x => x.Code, x => string.Format("{0} | {1}", x.Code, x.Name));
            return options;
        }

        public List<string> GetSessionCodeAndName()
        {
            return _SessionRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).Select(q => q.Code + " | " + q.Name).ToList();
        }

        public bool IsExistCode(string code)
        {
            return _SessionRepository.Exist(c => c.Code == code && c.StatusId != CommonStatus.DELETE);
        }
    }
}
