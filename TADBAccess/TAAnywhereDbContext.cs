using DomainModels.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADBAccess
{
    public class TAAnywhereDbContext: DbContext

    {
        public TAAnywhereDbContext():base("TADBConnection")
        { }
        public DbSet<TATravelType> TATravelTypes { get; set; }
        public DbSet<TAPurpose> TAPurposes { get; set; }
        public DbSet<TAEmployee> TAEmployees { get; set; }
        public DbSet<TAHeader> TAHeaders { get; set; }
        public DbSet<Resource> TAI18NResource
        { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("ORCL");
            
        }

    }
}
