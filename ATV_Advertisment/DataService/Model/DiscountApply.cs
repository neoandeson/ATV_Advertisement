namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountApply")]
    public partial class DiscountApply
    {
        public int Id { get; set; }

        public double ApplyPrice { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public double Percentage { get; set; }
    }
}
