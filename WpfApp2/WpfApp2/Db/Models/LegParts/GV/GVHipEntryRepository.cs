using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.GV;

namespace WpfApp2.Db.Models.LegParts.GV
{
    public class GVEntryRepository : Repository<GVEntry>
    {
        public GVEntryRepository(DbContext context) : base(context)
        {

        }
    }





    public class GVEntryFullRepository : Repository<GVEntryFull>
    {
        public GVEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}

