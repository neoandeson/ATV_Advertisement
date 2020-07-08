using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class ProductScheduleShowViewModel
    {
        public int Id { get; set; }

        public int ContractDetailId { get; set; }

        public string ProductName { get; set; }

        public string ShowTime { get; set; }

        public string ShowDate { get; set; }

        public int Quantity { get; set; }

        public string TimeSlot { get; set; }

        public int TimeSlotLength { get; set; }

        public string Cost { get; set; }

        public string Discount { get; set; }

        public string TotalCost { get; set; }
    }
}
