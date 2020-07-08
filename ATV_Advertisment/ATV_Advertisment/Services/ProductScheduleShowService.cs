using ATV_Advertisment.Common;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Services
{
    public interface IProductScheduleShowService
    {
        ProductScheduleShow GetById(int id);
        List<ProductScheduleShow> GetAllByContractDetailId(int contractDetailId);
        List<ProductScheduleShowViewModel> GetAllVMForList(int contractDetailId);
        List<SortProductScheduleViewModel> GetAllVMSearchingList(SearchPSSModel searchModel);
        DateTime[] GetAllSelectedDatesByContractDetailIdAndTimeSlotCode(int contractDetailId, string timeSlotCode);
        int DeleteProductScheduleShow(int id);
        int AddProductScheduleShow(ProductScheduleShow input);
        int EditProductScheduleShow(ProductScheduleShow input);
        int EditProductFileName(int contractItemId, string productName);
    }

    public class ProductScheduleShowService : IProductScheduleShowService
    {
        private readonly ProductScheduleShowRepository _ProductScheduleShowRepository;
        private readonly SessionRepository _sessionRepository;

        public ProductScheduleShowService()
        {
            _ProductScheduleShowRepository = new ProductScheduleShowRepository();
            _sessionRepository = new SessionRepository();
        }

        public int AddProductScheduleShow(ProductScheduleShow input)
        {
            int result = CRUDStatusCode.ERROR;
            if (input != null)
            {
                bool isExisted = _ProductScheduleShowRepository.Exist(t => t.ContractDetailId == input.ContractDetailId &&
                                                                t.TimeSlotLength == input.TimeSlotLength &&
                                                                t.TimeSlot == input.TimeSlot &&
                                                                t.ShowDate == input.ShowDate);
                if (!isExisted)
                {
                    _ProductScheduleShowRepository.Add(input);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        /// <summary>
        /// Hard delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteProductScheduleShow(int id)
        {
            int result = CRUDStatusCode.ERROR;
            var ProductScheduleShow = _ProductScheduleShowRepository.GetById(id);
            if (ProductScheduleShow != null)
            {
                _ProductScheduleShowRepository.Delete(ProductScheduleShow);
                result = CRUDStatusCode.SUCCESS;
            }

            return result;
        }

        public int EditProductScheduleShow(ProductScheduleShow input)
        {
            int result = CRUDStatusCode.ERROR;
            var ProductScheduleShow = _ProductScheduleShowRepository.GetById(input.Id);
            if (ProductScheduleShow != null)
            {
                ProductScheduleShow.ContractDetailId = input.ContractDetailId;
                ProductScheduleShow.Cost = input.Cost;
                ProductScheduleShow.ProductName = input.ProductName;
                ProductScheduleShow.ShowTime = input.ShowTime;
                ProductScheduleShow.Quantity = input.Quantity;
                ProductScheduleShow.TimeSlotLength = input.TimeSlotLength;
                ProductScheduleShow.ShowDate = input.ShowDate;
                ProductScheduleShow.TimeSlot = input.TimeSlot;
                ProductScheduleShow.TotalCost = input.TotalCost;
                ProductScheduleShow.Discount = input.Discount;
                ProductScheduleShow.OrderNumber = input.OrderNumber;

                bool isExisted = _ProductScheduleShowRepository.Exist(t => t.ContractDetailId == input.ContractDetailId &&
                                                                t.ProductName == input.ProductName &&
                                                                t.ShowDate == input.ShowDate &&
                                                                t.TimeSlot == input.TimeSlot &&
                                                                t.Quantity == input.Quantity &&
                                                                t.TimeSlotLength == input.TimeSlotLength &&
                                                                t.OrderNumber == input.OrderNumber);
                if (!isExisted)
                {
                    _ProductScheduleShowRepository.Update(ProductScheduleShow);
                    result = CRUDStatusCode.SUCCESS;
                }
                else
                {
                    result = CRUDStatusCode.EXISTED;
                }
            }

            return result;
        }

        public List<ProductScheduleShow> GetAllByContractDetailId(int contractDetailId)
        {
            return _ProductScheduleShowRepository.Get(c => c.ContractDetailId == contractDetailId).ToList();
        }

        public ProductScheduleShow GetById(int id)
        {
            return _ProductScheduleShowRepository.GetById(id);
        }

        public List<ProductScheduleShowViewModel> GetAllVMForList(int contractDetailId)
        {
            return _ProductScheduleShowRepository.Get(c => c.ContractDetailId == contractDetailId)
                .OrderBy(c => c.ShowDate)//TODO timeslotid.ThenBy(c => c.)
                .Select(ts => new ProductScheduleShowViewModel()
                {
                    Id = ts.Id,
                    ContractDetailId = ts.ContractDetailId,
                    Quantity = ts.Quantity,
                    ProductName = ts.ProductName,
                    ShowTime = ts.ShowTime,
                    ShowDate = ts.ShowDate.ToShortDateString(),
                    TimeSlot = ts.TimeSlot,
                    TimeSlotLength = ts.TimeSlotLength,
                    Cost = Utilities.DoubleMoneyToText(ts.Cost),
                    TotalCost = Utilities.DoubleMoneyToText(ts.TotalCost),
                    Discount = ts.Discount.ToString()
                })
                .ToList();
        }

        public List<ProductScheduleShowRM> GetAllForRptByDate(DateTime date)
        {
            return _ProductScheduleShowRepository.Get(p => p.ShowDate == date)
                .OrderBy(c => c.ShowDate).ThenBy(c => c.ShowTime).ThenBy(c => c.TimeSlotLength)
                .Select(ts => new ProductScheduleShowRM()
                {
                    ProductName = ts.ProductName,
                    ShowTime = ts.ShowTime,
                    //TODO Check Remove
                    //ShowDate = ts.ShowDate,
                    TimeSlot = ts.TimeSlot,
                    TimeSlotLength = ts.TimeSlotLength,
                })
                .ToList();
        }

        public DateTime[] GetAllSelectedDatesByContractDetailIdAndTimeSlotCode(int contractDetailId, string timeslotCode)
        {
            return _ProductScheduleShowRepository.Get(p => p.ContractDetailId == contractDetailId && p.TimeSlotCode == timeslotCode)
                .OrderBy(p => p.ShowDate)
                .Select(q => q.ShowDate)
                .Distinct()
                .ToArray();
        }

        public List<SortProductScheduleViewModel> GetAllVMSearchingList(SearchPSSModel searchModel)
        {
            var tmp = _ProductScheduleShowRepository.Get(s => s.ShowDate.Day == searchModel.SearchDate.Day
                                                                && s.ShowDate.Month == searchModel.SearchDate.Month
                                                                && s.ShowDate.Year == searchModel.SearchDate.Year)
                .OrderBy(s => s.ShowTimeInt)
                .ThenBy(s => s.OrderNumber)
                .Select(s => new SortProductScheduleViewModel
                {
                    Id = s.Id,
                    ContractDetailId = s.ContractDetailId,
                    ShowTime = s.ShowTime,
                    ShowTimeInt = s.ShowTimeInt.Value,
                    OrderNumber = s.OrderNumber,
                    ShowDate = Utilities.DateToFormatVNDate(s.ShowDate),
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    TimeSlot = s.TimeSlot,
                    TimeSlotLength = s.TimeSlotLength
                }).ToList();
            return tmp;
        }

        public int EditProductFileName(int contractItemId, string productName)
        {
            int result = CRUDStatusCode.ERROR;
                if(contractItemId != 0)
                {
                    List<ProductScheduleShow> productScheduleShows = _ProductScheduleShowRepository.Get(p => p.ContractDetailId == contractItemId).ToList();
                    foreach (var pss in productScheduleShows)
                    {
                        pss.ProductName = productName;
                        _ProductScheduleShowRepository.Update(pss);
                    }
                }
                result = CRUDStatusCode.SUCCESS;

            return result;
        }
    }
}
