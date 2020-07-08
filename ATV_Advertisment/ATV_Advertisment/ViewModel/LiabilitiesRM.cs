using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class LiabilitiesRM
    {
        public string ProductName { get; set; }
        public string TimeSlot { get; set; }
        public string TimeSlotCode { get; set; }
        public string ShowTime { get; set; }
        public int TimeSlotLength { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double TotalCost { get; set; }
        public double Discount { get; set; }
        public double FinalCost { get; set; }
    }
}
