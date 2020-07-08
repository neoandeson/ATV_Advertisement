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
    public interface ICustomerService
    {
        List<Customer> GetAll();
        List<string> GetAllCustomerCode();
        Customer GetByCode(string code);
        string GetNameByCode(string code);
        bool IsExistCode(string code);
        bool DeleteCustomer(int customerId);
        bool AddCustomer(Customer input);
        bool EditCustomer(Customer input);
    }

    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public bool DeleteCustomer(int customerId)
        {
            bool result = false;
            var customer = _customerRepository.GetById(customerId);
            if(customer != null)
            {
                customer.StatusId = CommonStatus.DELETE;
                customer.LastUpdateDate = Utilities.GetServerDateTimeNow();
                customer.LastUpdateBy = Common.Session.GetId();
                _customerRepository.Update(customer);
                result = true;
            }

            return result;
        }

        public bool EditCustomer(Customer input)
        {
            bool result = false;
            var customer = _customerRepository.GetById(input.Id);
            if (customer != null)
            {
                customer.Code = input.Code;
                customer.Name = input.Name;
                customer.Address = input.Address;
                customer.Phone1 = input.Phone1;
                customer.Phone2 = input.Phone2;
                customer.Fax = input.Fax;
                customer.TaxCode = input.TaxCode;
                customer.Email = input.Email;

                customer.LastUpdateDate = Utilities.GetServerDateTimeNow();
                customer.LastUpdateBy = Common.Session.GetId();
                _customerRepository.Update(customer);
                result = true;
            }

            return result;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).ToList();
        }

        public bool AddCustomer(Customer customer)
        {
            bool result = false;
            if(customer != null)
            {
                var customers = _customerRepository.Get(c => c.Name == customer.Name && c.TaxCode == customer.TaxCode).ToList();
                if(customers.Count == 0)
                {
                    customer.StatusId = CommonStatus.ACTIVE;
                    customer.LastUpdateDate = Utilities.GetServerDateTimeNow();
                    customer.LastUpdateBy = Common.Session.GetId();
                    _customerRepository.Add(customer);
                    result = true;
                }
            }
             
            return result;
        }

        public List<string> GetAllCustomerCode()
        {
            return _customerRepository.Get(c => c.StatusId == CommonStatus.ACTIVE).Select(c => c.Code).ToList();
        }

        public Customer GetByCode(string code)
        {
            return _customerRepository.Get(c => c.Code == code).FirstOrDefault();
        }

        public bool IsExistCode(string code)
        {
            return _customerRepository.Exist(c => c.Code == code);
        }

        public string GetNameByCode(string code)
        {
            string result = "";
            var customer = _customerRepository.Get(c => c.Code == code).FirstOrDefault();
            if (customer != null)
            {
                result = customer.Name;
            }

            return result;
        }

        public Dictionary<string, string> GetOptions()
        {
            var options = _customerRepository.GetAll().ToDictionary(x => x.Code, x => x.Code);
            return options;
        }
    }
}
