using System.Data.Entity;

namespace WpfApp2.Db.Models.BPV
{
    public class BPVHipContext : DbContext
    {
        public DbSet<BPVHipStructure> BPVEntries { get; set; }

        //: base("name=MyConnection")

        //public BPVHipContext(string conn = "server=localhost; user=root;database=test_med;password=22222") { }
        public BPVHipContext() : base("server=localhost;user=root;database=med_db;password=22222;") {}
        //public BPVHipContext() : base("server=localhost; user=root;database=test_med;password=22222") { }
    }
}
