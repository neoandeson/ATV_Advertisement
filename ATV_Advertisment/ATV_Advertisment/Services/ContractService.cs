using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IContractService
    {
        Contract GetById(int id);
        Contract GetByCode(string code);
        List<Contract> GetAll();
        List<ContractViewModel> GetAllVMForList();
        int DeleteContract(int id);
        Contract AddContract(Contract input);
        int EditContract(Contract input);
        int CancelContract(int id);
        double UpdateContractCost(string contractCode);
    }

    public class ContractService : IContractService
    {
        private readonly ContractRepository _ContractRepository;
        private readonly ContractItemService _contractItemService;
        private readonly CustomerService _customerService;
        private readonly ShowTypeRepository _contractTypeRepository;

        public ContractService()
        {
            _ContractRepository = new ContractRepository();
            _contractItemService = new ContractItemService();
            _contractTypeRepository = new ShowTypeRepository();
            _customerService = new CustomerService();
        }

        public Contract AddContract(Contract input)
        {
            Contract result = null;
            if (input != null)
            {
                //TODO: Define if seperative contract
                //bool isExisted = _ContractRepository.Exist(t => t.Length == input.Length);
                //if (!isExisted)
                input.StatusId = CommonStatus.ACTIVE;
                input.CustomerName = _customerService.GetNameByCode(input.CustomerCode);
                input.CreateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateDate = Utilities.GetServerDateTimeNow();
                input.LastUpdateBy = Common.Session.GetId();
                result = _ContractRepository.Create(input);
            }

            return result;
        }

        public int CancelContract(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var Contract = _ContractRepository.GetById(id);
            if (Contract != null)
            {
                Contract.StatusId = CommonStatus.CANCEL;

                Contract.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Contract.LastUpdateBy = Common.Session.GetId();
                _ContractRepository.Update(Contract);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        /// <summary>
        /// Onyly mark as cancel 
        /// must not print on schedule
        /// optional when print report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteContract(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var Contract = _ContractRepository.GetById(id);
            if (Contract != null)
            {
                Contract.StatusId = CommonStatus.CANCEL;

                Contract.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Contract.LastUpdateBy = Common.Session.GetId();
                _ContractRepository.Update(Contract);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditContract(Contract input)
        {
            int result = CRUDStatusCode.ERROR;
            var Contract = _ContractRepository.GetById(input.Id);
            if (Contract != null)
            {
                //TODO: Define if seperative contract
                //bool isExisted = _ContractRepository.Exist(t => t. == input.Length);
                //if (!isExisted)
                Contract.Cost = input.Cost;
                Contract.SumCost = input.SumCost;
                Contract.Discount = input.Discount;
                Contract.CustomerCode = input.CustomerCode;
                Contract.StartDate = input.StartDate;
                Contract.EndDate = input.EndDate;

                Contract.LastUpdateDate = Utilities.GetServerDateTimeNow();
                Contract.LastUpdateBy = Common.Session.GetId();
                _ContractRepository.Update(Contract);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public List<Contract> GetAll()
        {
            return _ContractRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public Contract GetByCode(string code)
        {
            return _ContractRepository.Get(c => c.Code == code).FirstOrDefault();
        }

        public Contract GetById(int id)
        {
            return _ContractRepository.GetById(id);
        }

        public List<ContractViewModel> GetAllVMForList()
        {
            Dictionary<int, string> contractTypes = _contractTypeRepository
                .Get(c => c.StatusId == CommonStatus.ACTIVE)
                .ToDictionary(q => q.Id, q => q.Type);

            return _ContractRepository.Get(c => c.StatusId == CommonStatus.ACTIVE)
                .OrderByDescending(c => c.CreateDate)
                .Select(c => new ContractViewModel()
                {
                    Id = c.Id,
                    ContractCode = c.Code,
                    CustomerCode = c.CustomerCode,
                    StartDate = c.StartDate.Value.ToString("dd/MM/yyyy"),
                    EndDate = c.EndDate.Value.ToString("dd/MM/yyyy")
                })
                .ToList();
        }

        public double UpdateContractCost(string contractCode)
        {
            double result = 0;

            Contract contract = GetByCode(contractCode);
            if (contract != null)
            {
                List<ContractItem> contractDetails = _contractItemService.GetAllByContractCode(contractCode);
                foreach (var cd in contractDetails)
                {
                    result += cd.TotalCost;
                }

                contract.Cost = result;
                EditContract(contract);
            }

            return result;
        }

        public void UpdatContractCostInfo(string contractCode, double cost, double sumCost, double discount)
        {
            Contract contract = GetByCode(contractCode);
            if (contract != null)
            {
                contract.Cost = cost;
                contract.SumCost = sumCost;
                contract.Discount = discount;

                EditContract(contract);
            }
        }

        //Report
        public static DateTime GetServerDateTimeNow()
        {
            DateTime dt;
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
            {
                var cmd = new SqlCommand("SELECT GETDATE()", conn);
                conn.Open();

                dt = (DateTime)cmd.ExecuteScalar();
            };
            return dt;
        }

        public List<RevenueRM> GetRevenueRptByMonth(DateTime exportMonth)
        {
            return _ContractRepository.Get(p => p.StartDate.Value.Month == exportMonth.Month
                                                && p.StartDate.Value.Year == exportMonth.Year
                                                && p.EndDate.Value.Month == exportMonth.Month
                                                && p.EndDate.Value.Year == exportMonth.Year
                                                && p.StatusId == CommonStatus.ACTIVE)
                .OrderBy(c => c.Code)
                .Select(con => new RevenueRM()
                {
                    Code = con.Code,
                    CustomerName = con.CustomerName,
                    Cost = con.SumCost,
                    TotalCost = con.Cost
                })
                .ToList();
        }

        public List<RevenueRM> GetRevenueRptByMonths(DateTime fromMonth, DateTime toMonth)
        {
            return _ContractRepository.Get(p => p.StartDate.Value.Month == fromMonth.Month
                                                && p.StartDate.Value.Year == fromMonth.Year
                                                && p.EndDate.Value.Month == toMonth.Month
                                                && p.EndDate.Value.Year == toMonth.Year)
                .OrderBy(c => c.Code)
                .Select(con => new RevenueRM()
                {
                    Code = con.Code,
                    CustomerName = con.CustomerName,
                    Cost = con.SumCost,
                    TotalCost = con.Cost
                })
                .ToList();
        }

        public Dictionary<string, string> GetOptionsByCustomerCodeAndMonth(string customerCode, DateTime fromMonth, DateTime toMonth)
        {
            var firstDayOfMonth = new DateTime(fromMonth.Year, fromMonth.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var options = new Dictionary<string, string>();
            options.Add("", "");
            var contracts = _ContractRepository.Get(c => c.CustomerCode == customerCode
                                                    && c.StatusId == CommonStatus.ACTIVE
                                                    && (c.StartDate < lastDayOfMonth && c.EndDate >= firstDayOfMonth));
            if(contracts.Count() > 0)
            {
                foreach (var con in contracts)
                {
                    options.Add(con.Code.Trim(), con.Code.Trim());
                }
            }
            return options;
        }
    }
}
