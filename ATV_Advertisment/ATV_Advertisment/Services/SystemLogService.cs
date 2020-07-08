using DataService.Infrastructure;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ISystemLogService
    {
        
    }

    public class SystemLogService : ISystemLogService
    {
        private readonly SystemLogRepository _systemLogRepository;

        public SystemLogService()
        {
            _systemLogRepository = new SystemLogRepository();
        }

        public void Log(SystemLog input)
        {
            _systemLogRepository.Add(input);
        }
    }
}
