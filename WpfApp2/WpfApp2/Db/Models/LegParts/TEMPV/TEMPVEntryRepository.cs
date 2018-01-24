using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.TEMPV
{
    public class TEMPVEntryRepository : Repository<TEMPVEntry>
    {
        public TEMPVEntryRepository(DbContext context) : base(context)
        {

        }
    }

    public class TEMPVWayRepository : Repository<TEMPVWay>
    {
        public TEMPVWayRepository(DbContext context) : base(context)
    {

    }
}


public class TEMPVEntryFullRepository : Repository<TEMPVEntryFull>
    {
        public TEMPVEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
