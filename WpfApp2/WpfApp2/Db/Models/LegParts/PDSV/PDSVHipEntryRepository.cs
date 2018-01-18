using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.PDSVHip
{
    public class PDSVHipEntryRepository : Repository<PDSVHipEntry>
    {
        public PDSVHipEntryRepository(DbContext context) : base(context)
        {

        }
    }

    public class PDSVHipWayRepository : Repository<PDSVHipWay>
    {
        public PDSVHipWayRepository(DbContext context) : base(context)
    {

    }
}


public class PDSVHipEntryFullRepository : Repository<PDSVHipEntryFull>
    {
        public PDSVHipEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
