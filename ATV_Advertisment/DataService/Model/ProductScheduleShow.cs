namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductScheduleShow")]
    public partial class ProductScheduleShow
    {
        public int Id { get; set; }

        public int ContractDetailId { get; set; }

        [Required]
        [StringLength(80)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(5)]
        public string ShowTime { get; set; }

        public int? ShowTimeInt { get; set; }

        public DateTime ShowDate { get; set; }

        public int ShowTypeId { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string TimeSlot { get; set; }

        [StringLength(10)]
        public string TimeSlotCode { get; set; }

        public int TimeSlotLength { get; set; }

        public double Cost { get; set; }

        public double Discount { get; set; }

        public double TotalCost { get; set; }

        public int OrderNumber { get; set; }

        public bool IsAdvanced { get; set; }
    }
}
