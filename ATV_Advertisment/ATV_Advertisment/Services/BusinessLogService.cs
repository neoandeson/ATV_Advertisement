using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATV_Advertisment.Services
{
    public interface IBusinessLogService
    {
        void Log(BusinessLog input);
        List<BusinessLog> GetLoggingByDate(int day, int month, int year);
        List<BusinessLog> GetLoggingByMonth(int month, int year);
    }

    public class BusinessLogService : IBusinessLogService
    {
        private readonly BusinessLogRepository _businessLogRepository;

        public BusinessLogService()
        {
            _businessLogRepository = new BusinessLogRepository();
        }

        public List<BusinessLog> GetLoggingByDate(int day, int month, int year)
        {
            return _businessLogRepository.Get(l => l.DateAct.Day == day && l.DateAct.Month == month && l.DateAct.Year == year).ToList();
        }

        public List<BusinessLog> GetLoggingByMonth(int month, int year)
        {
            return _businessLogRepository.Get(l => l.DateAct.Month == month && l.DateAct.Year == year).ToList();
        }

        public void Log(BusinessLog input)
        {
            _businessLogRepository.Add(input);
        }
    }
}
