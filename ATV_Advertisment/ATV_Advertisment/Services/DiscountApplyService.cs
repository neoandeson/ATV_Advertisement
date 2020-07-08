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
    public interface IDiscountApplyService
    {
    }

    public class DiscountApplyService : IDiscountApplyService
    {
        private readonly DiscountApplyRepository _discountApplyRepository;

        public DiscountApplyService()
        {
            _discountApplyRepository = new DiscountApplyRepository();
        }
    }
}
