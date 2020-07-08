namespace DataService.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ATVEntities : DbContext
    {
        public ATVEntities()
            : base("name=ATVEntities")
        {
        }

        public virtual DbSet<BusinessLog> BusinessLogs { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractItem> ContractItems { get; set; }
        public virtual DbSet<CostRule> CostRules { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DiscountApply> DiscountApplies { get; set; }
        public virtual DbSet<Duration> Durations { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<ProductScheduleShow> ProductScheduleShows { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleHasMenuItem> RoleHasMenuItems { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<ShowType> ShowTypes { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.RoleHasMenuItems)
                .WithRequired(e => e.MenuItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductScheduleShow>()
                .Property(e => e.ShowTime)
                .IsUnicode(false);

            modelBuilder.Entity<ProductScheduleShow>()
                .Property(e => e.TimeSlotCode)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleHasMenuItems)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.Code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TimeSlot>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<TimeSlot>()
                .Property(e => e.SessionCode)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
