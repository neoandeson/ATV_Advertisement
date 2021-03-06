namespace DataService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleHasMenuItem")]
    public partial class RoleHasMenuItem
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Role Role { get; set; }
    }
}
