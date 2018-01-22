using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.BPV_Tibia
{
    public class BPV_TibiaEntryRepository : Repository<BPV_TibiaEntry>
    {
        public BPV_TibiaEntryRepository(DbContext context) : base(context)
        {

        }
    }

    


public class BPV_TibiaEntryFullRepository : Repository<BPV_TibiaEntryFull>
    {
        public BPV_TibiaEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
