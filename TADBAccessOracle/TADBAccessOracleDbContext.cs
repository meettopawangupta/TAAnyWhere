using DomainModels.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TADBAccessOracle
{
    public class TADBAccessOracleDbContext : DbContext
    {
        public TADBAccessOracleDbContext():base("OracleDbContext")
        { }
        public DbSet<TATravelType> TATravelTypes { get; set; }
        public DbSet<TAPurpose> TAPurposes { get; set; }
        public DbSet<TAEmployee> TAEmployees { get; set; }
        public DbSet<TAHeader> TAHeaders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("ORCL");
        }

    }

}
