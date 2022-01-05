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
        public virtual DbSet<WmiServerList> WmiServerList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WmiServerList>()
                .Property(e => e.Ver)
                .IsFixedLength();
        }

        public System.Data.Entity.DbSet<AllinOne.Entity.ViewModel.RESTfulResult> RESTfulResults { get; set; }
    }
}
