using ATV_Advertisment.Common;
using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IDurationService
    {
        Duration GetById(int id);
        List<Duration> GetAll();
        Dictionary<int, int> Getoptions();
        int DeleteDuration(int id);
        int AddDuration(Duration input);
        int EditDuration(Duration input);
    }

    public class DurationService : IDurationService
    {
        private readonly DurationRepository _DurationRepository;

        public DurationService()
        {
            _DurationRepository = new DurationRepository();
        }

        public int AddDuration(Duration input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _DurationRepository.Exist(t => t.Length == input.Length);
                if (!isExisted)
                {
                    input.StatusId = CommonStatus.ACTIVE;
                    input.CreateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    input.LastUpdateBy = Common.Session.GetId();
                    _DurationRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public int DeleteDuration(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var Duration = _DurationRepository.GetById(id);
            if (Duration != null)
            {
                Duration.StatusId = CommonStatus.DELETE;
                Duration.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Duration.LastUpdateBy = Common.Session.GetId();
                _DurationRepository.Update(Duration);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditDuration(Duration input)
        {
            int result = CRUDStatusCode.ERROR;
            var Duration = _DurationRepository.GetById(input.Id);
            if (Duration != null)
            {
                bool isExisted = _DurationRepository.Exist(t => t.Length == input.Length);
                if (!isExisted)
                {
                    Duration.Length = input.Length;

                    Duration.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    Duration.LastUpdateBy = Common.Session.GetId();
                    _DurationRepository.Update(Duration);
                    result = CRUDStatusCode.SUCCESS;
                }
                result = CRUDStatusCode.EXISTED;
            }

            return result;
        }

        public List<Duration> GetAll()
        {
            return _DurationRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).OrderBy(c => c.Length).ToList();
        }

        public Duration GetById(int id)
        {
            return _DurationRepository.GetById(id);
        }

        public Dictionary<int, int> Getoptions()
        {
            var options = _DurationRepository.GetAll().ToDictionary(x => x.Length, x => x.Length);
            return options;
        }
    }
}
