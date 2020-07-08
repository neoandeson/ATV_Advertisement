using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class ProductScheduleViewModel
    {
        public string ShowDate { get; set; }
        public int Quantity { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public int Discount { get; set; }
        public int TotalCost { get; set; }
    }
}
