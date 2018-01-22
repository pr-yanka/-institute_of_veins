using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.ZDSV
{
    public class ZDSVEntryRepository : Repository<ZDSVEntry>
    {
        public ZDSVEntryRepository(DbContext context) : base(context)
        {

        }
    }




public class ZDSVEntryFullRepository : Repository<ZDSVEntryFull>
    {
        public ZDSVEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
