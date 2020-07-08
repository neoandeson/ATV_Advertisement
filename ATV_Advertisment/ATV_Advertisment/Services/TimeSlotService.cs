using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using DataService.Repositories;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ITimeSlotService
    {
        TimeSlot GetById(int id);
        List<TimeSlot> GetAll();
        List<TimeSlot> GetAllForList();
        List<TimeSlotViewModel> GetAllForDetailList();
        Dictionary<int, string> Getoptions();
        bool IsExistCodeAndFromHour(string code, int fromHour);
        bool IsExistCode(string code);
        int DeleteTimeSlot(int id);
        int AddTimeSlot(TimeSlot input);
        int EditTimeSlot(TimeSlot input);
        TimeSlot CreateTimeSlot(TimeSlot input);
    }

    public class TimeSlotService : ITimeSlotService
    {
        private readonly TimeSlotRepository _TimeSlotRepository;
        private readonly SessionRepository _sessionRepository;
        private readonly CostRuleRepository _costRuleRepository;

        public TimeSlotService()
        {
            _TimeSlotRepository = new TimeSlotRepository();
            _sessionRepository = new SessionRepository();
            _costRuleRepository = new CostRuleRepository();
        }

        public int AddTimeSlot(TimeSlot input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _TimeSlotRepository.Exist(t => t.Code == input.Code && 
                                                                t.Name == input.Name &&
                                                                t.FromHour == input.FromHour);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _TimeSlotRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public TimeSlot CreateTimeSlot(TimeSlot input)
        {
            TimeSlot result = null;
            if (input != null)
            {
                bool isExisted = _TimeSlotRepository.Exist(t => t.Code == input.Code &&
                                                                t.Name == input.Name &&
                                                                t.FromHour == input.FromHour &&
                                                                t.StatusId == CommonStatus.ACTIVE);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    result = _TimeSlotRepository.Create(input);
                }
            }

            return result;
        }

        public bool IsExistCodeAndFromHour(string code, int fromHour)
        {
            bool result = false;
            TimeSlot timeSlot = _TimeSlotRepository.Get(q => q.Code == code && q.FromHour == fromHour).FirstOrDefault();
            if( timeSlot != null )
            {
                result = true;
            }

            return result;
        }

        public int DeleteTimeSlot(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var TimeSlot = _TimeSlotRepository.GetById(id);
            if (TimeSlot != null)
            {
                TimeSlot.StatusId = CommonStatus.DELETE;
                TimeSlot.LastUpdateDate = Utilities.GetServerDateTimeNow();
                TimeSlot.LastUpdateBy = Common.Session.GetId();
                _TimeSlotRepository.Update(TimeSlot);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditTimeSlot(TimeSlot input)
        {
            int result = CRUDStatusCode.ERROR;
            var TimeSlot = _TimeSlotRepository.GetById(input.Id);
            if (TimeSlot != null)
            {
                TimeSlot.Name = input.Name;
                TimeSlot.Code = input.Code;
                TimeSlot.FromHour = input.FromHour;
                TimeSlot.SessionCode = input.SessionCode;

                TimeSlot.LastUpdateDate = Utilities.GetServerDateTimeNow();
                TimeSlot.LastUpdateBy = Common.Session.GetId();
                _TimeSlotRepository.Update(TimeSlot);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<TimeSlot> GetAll()
        {
            return _TimeSlotRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public TimeSlot GetById(int id)
        {
            return _TimeSlotRepository.GetById(id);
        }

        public List<TimeSlot> GetAllForList()
        {
            Dictionary<string, string> sessionCodeName = _sessionRepository
                .Get(c => c.StatusId == CommonStatus.ACTIVE)
                .ToDictionary(q => q.Code, q => string.Format("{0} {1}", q.Code, q.Name));
            return _TimeSlotRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
                .OrderBy(c => c.SessionCode)
                .Select(ts => new TimeSlot() {
                    Id = ts.Id,
                    Code = ts.Code,
                    StatusId = ts.StatusId,
                    CreateDate = ts.CreateDate,
                    FromHour = ts.FromHour,
                    LastUpdateBy = ts.LastUpdateBy,
                    LastUpdateDate = ts.LastUpdateDate,
                    Name = ts.Name,
                    SessionCode = sessionCodeName.Where(s => s.Key == ts.SessionCode).FirstOrDefault().Value
                })
                .ToList();
        }

        public List<TimeSlotViewModel> GetAllForDetailList()
        {
            Dictionary<string, string> sessionCodeName = _sessionRepository
                .Get(c => c.StatusId == CommonStatus.ACTIVE)
                .ToDictionary(q => q.Code, q => string.Format("{0} | {1}", q.Code, q.Name));
            return _TimeSlotRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
                .OrderBy(c => c.SessionCode)
                .ThenBy(c => c.FromHour)
                .Select(ts => new TimeSlotViewModel()
                {
                    Id = ts.Id,
                    Code = ts.Code,
                    StatusId = ts.StatusId,
                    CreateDate = ts.CreateDate,
                    FromHour = Utilities.GetHourFormInt(ts.FromHour),
                    LastUpdateBy = ts.LastUpdateBy,
                    LastUpdateDate = ts.LastUpdateDate,
                    Name = ts.Name,
                    SessionCode = sessionCodeName.Where(s => s.Key == ts.SessionCode).FirstOrDefault().Value
                })
                .ToList();
        }

        public Dictionary<int, string> Getoptions()
        {
            var options = _TimeSlotRepository.Get(t => t.StatusId == CommonStatus.ACTIVE).ToDictionary(x => x.Id, x => x.Name);
            
            return options;
        }

        public Dictionary<int, string> GetOptionsByLengthShowType(int length, int showTypeId)
        {
            var costRule = _costRuleRepository.Get(c => c.Length == length && c.ShowTypeId == showTypeId)
                .Select(c => c.TimeSlotId);

            var options = new Dictionary<int, string>();
            options.Add(-1, "");
            var timeSlots = _TimeSlotRepository.Get(t => t.StatusId == CommonStatus.ACTIVE
                                                && costRule.Contains(t.Id))
                                                .OrderBy(t => t.FromHour);
            if (timeSlots.Count() > 0)
            {
                options = new Dictionary<int, string>();
                foreach (var ts in timeSlots)
                {
                    options.Add(ts.Id, ts.Name.Trim());
                }
            }

            return options;
        }

        public bool IsExistCode(string code)
        {
            bool result = false;
            var timeSlot = _TimeSlotRepository.Get(t => t.Code == code && t.StatusId == CommonStatus.ACTIVE).FirstOrDefault();
            if(timeSlot != null)
            {
                result = true;
            }

            return result;
        }
    }
}
