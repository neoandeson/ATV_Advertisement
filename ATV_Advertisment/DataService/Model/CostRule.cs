namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CostRule")]
    public partial class CostRule
    {
        public int Id { get; set; }

        public int TimeSlotId { get; set; }

        public int Length { get; set; }

        public double Price { get; set; }

        public int ShowTypeId { get; set; }
    }
}
