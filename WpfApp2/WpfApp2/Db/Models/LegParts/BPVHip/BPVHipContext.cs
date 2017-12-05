using System.Data.Entity;

namespace WpfApp2.Db.Models.BPV
{
    public class BPVHipContext : DbContext
    {
        public DbSet<BPVHipStructure> BPVEntries { get; set; }
        public BPVHipContext() : base("server=localhost;user=root;database=med_db;password=22222;") {}
    }
}
