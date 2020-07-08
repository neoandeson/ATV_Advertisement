using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class PricingFMProductRM
    {
        public string SessionCode { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string TSName { get; set; }
        public int FromHour { get; set; }
        public double T30 { get; set; }
        public double T60 { get; set; }
    }
}
