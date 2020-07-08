using ATV_Advertisment.Common;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface ISystemConfigService
    {
        SystemConfig GetById(int id);
        SystemConfig GetByName(string name);
        
        int EditSystemConfig(SystemConfig input);

        string GetLastContractNumberAsString();
        void ResetLastContractNumber();
        int UseLastContractNumber();
    }

    public class SystemConfigService : ISystemConfigService
    {
        private readonly SystemConfigRepository _SystemConfigRepository;
        private readonly SessionRepository _sessionRepository;

        public SystemConfigService()
        {
            _SystemConfigRepository = new SystemConfigRepository();
            _sessionRepository = new SessionRepository();
        }

        public int EditSystemConfig(SystemConfig input)
        {
            int result = CRUDStatusCode.ERROR;
            var SystemConfig = _SystemConfigRepository.GetById(input.Id);
            if (SystemConfig != null)
            {
                SystemConfig.Name = input.Name;
                SystemConfig.ValueString = input.ValueString;
                SystemConfig.ValueNumber = input.ValueNumber;

                _SystemConfigRepository.Update(SystemConfig);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public SystemConfig GetById(int id)
        {
            return _SystemConfigRepository.GetById(id);
        }

        public SystemConfig GetByName(string name)
        {
            return _SystemConfigRepository.Get(s => s.Name == name).FirstOrDefault();
        }

        public string GetLastContractNumberAsString()
        {
            string result = "";
            var contractNumberInMonth = _SystemConfigRepository.Get(s => s.Name == "ContractNumberInMonth").FirstOrDefault();
            if (contractNumberInMonth != null)
            {
                if(int.Parse(contractNumberInMonth.ValueString) != Utilities.GetServerDateTimeNow().Month)
                {
                    ResetLastContractNumber();
                    contractNumberInMonth = _SystemConfigRepository.Get(s => s.Name == "ContractNumberInMonth").FirstOrDefault();
                }
                DateTime serverDatetime = Utilities.GetServerDateTimeNow();

                result = "HD" 
                    + contractNumberInMonth.ValueNumber.Value.ToString("000") 
                    + serverDatetime.Month.ToString("00")
                    + serverDatetime.ToString("yy");
            }

            return result;
        }

        public void ResetLastContractNumber()
        {
            var contractNumberInMonth = _SystemConfigRepository.Get(s => s.Name == "ContractNumberInMonth").FirstOrDefault();
            if(contractNumberInMonth != null)
            {
                contractNumberInMonth.ValueNumber = 1;
                contractNumberInMonth.ValueString = Utilities.GetServerDateTimeNow().Month.ToString("00");
                EditSystemConfig(contractNumberInMonth);
            }
        }

        public int UseLastContractNumber()
        {
            int result = CRUDStatusCode.ERROR;
            var SystemConfig = _SystemConfigRepository.Get(s => s.Name == "ContractNumberInMonth").FirstOrDefault();
            if (SystemConfig != null)
            {
                SystemConfig.ValueNumber += 1;

                _SystemConfigRepository.Update(SystemConfig);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }
    }
}
