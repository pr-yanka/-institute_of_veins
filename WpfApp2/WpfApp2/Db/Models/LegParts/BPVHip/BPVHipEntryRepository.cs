using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.BPVHip
{
    public class BPVHipEntryRepository : Repository<BPVHipEntry>
    {
        public BPVHipEntryRepository(DbContext context) : base(context)
        {

        }
    }

    public class BPVHipEntryFullRepository : Repository<BPVHipEntryFull>
    {
        public BPVHipEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
