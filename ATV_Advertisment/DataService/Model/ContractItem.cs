namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractItem")]
    public partial class ContractItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string ContractCode { get; set; }

        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int DurationSecond { get; set; }

        public int NumberOfShow { get; set; }

        public double TotalCost { get; set; }

        public int ShowTypeId { get; set; }

        public int StatusId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int? LastUpdateBy { get; set; }
    }
}
