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
        public DbSet<BPVHipStructure> BPVStructures { get; set; }
        public MySqlContext() : base("server=localhost;user=root;database=med_db;password=22222;") {
            
        }
    }
}
