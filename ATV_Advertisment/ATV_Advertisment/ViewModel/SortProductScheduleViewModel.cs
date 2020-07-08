using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class SortProductScheduleViewModel
    {
        public int Id { get; set; }

        public int ContractDetailId { get; set; }

        public string ProductName { get; set; }

        public string ShowTime { get; set; }

        public string ShowDate { get; set; }

        public int Quantity { get; set; }

        public string TimeSlot { get; set; }

        public int TimeSlotLength { get; set; }

        public int OrderNumber { get; set; }

        public int ShowTimeInt { get; set; }
    }

    public class SearchPSSModel
    {
        public int ContractDetailId { get; set; }
        public DateTime SearchDate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; } 
    }
}
