using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AllinOne.Entity
{
    public partial class AllinOneModel : DbContext
    {
        public AllinOneModel()
            : base("name=AllinOneEntity")
        {
        }

        public virtual DbSet<SysSerialNumber> SysSerialNumber { get; set; }
        public virtual DbSet<WmiServerCpu> WmiServerCpu { get; set; }
        public virtual DbSet<WmiServerList> WmiServerList { get; set; }
        public virtual DbSet<WmiServerMain> WmiServerMain { get; set; }
        public virtual DbSet<WmiServerMemory> WmiServerMemory { get; set; }
        public virtual DbSet<WmiServerDisk> WmiServerDisk { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WmiServerList>()
                .Property(e => e.Ver)
                .IsFixedLength();
        }

        public DbSet<ViewModel.RESTfulResult> RESTfulResults { get; set; }
    }
}
