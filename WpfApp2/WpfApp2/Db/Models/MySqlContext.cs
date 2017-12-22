using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    public class MySqlContext : DbContext
    {
        public DbSet<BPVHipStructure> BPVHipStructures { get; set; }
        public DbSet<BPVHipCombo> BPVHipCombos { get; set; }
        public DbSet<Metrics> Metrics { get; set; }
        public DbSet<Patient> Petients { get; set; }
        public MySqlContext() : base("server=localhost;user=root;database=med_db;password=22222;") {
            
        }
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BPVHipStructure>().Ignore(t => t.Metrics);
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
