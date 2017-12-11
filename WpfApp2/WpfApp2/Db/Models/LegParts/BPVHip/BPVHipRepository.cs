using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class BPVHipRepository : Repository<BPVHipStructure>
    {
        public BPVHipRepository(DbContext context) : base(context)
        {
        }
        
    }
}