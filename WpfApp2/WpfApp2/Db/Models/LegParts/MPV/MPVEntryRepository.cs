using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.MPV
{
    public class MPVEntryRepository : Repository<MPVEntry>
    {
        public MPVEntryRepository(DbContext context) : base(context)
        {

        }
    }

    public class MPVWayRepository : Repository<MPVWay>
    {
        public MPVWayRepository(DbContext context) : base(context)
    {

    }
}


public class MPVEntryFullRepository : Repository<MPVEntryFull>
    {
        public MPVEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
