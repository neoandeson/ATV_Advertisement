using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Advertisment.ViewModel
{
    public class ContractItemViewModel
    {
        public int Id { get; set; }

        public string ContractCode { get; set; }

        public string ProductName { get; set; }

        public int DurationSecond { get; set; }

        public int NumberOfShow { get; set; }

        public string TotalCost { get; set; }

        public int StatusId { get; set; }

        public string ShowTypeId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int? LastUpdateBy { get; set; }
    }
}
