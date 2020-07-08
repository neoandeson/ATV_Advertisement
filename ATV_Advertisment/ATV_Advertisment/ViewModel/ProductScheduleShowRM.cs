using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class ProductScheduleShowRM
    {
        public DateTime ShowDate { get; set; }
        public int ShowTimeInt { get; set; }
        public string TimeSlot { get; set; }
        public string ShowTime { get; set; }
        public string ProductName { get; set; }
        public int TimeSlotLength { get; set; }
    }
}
