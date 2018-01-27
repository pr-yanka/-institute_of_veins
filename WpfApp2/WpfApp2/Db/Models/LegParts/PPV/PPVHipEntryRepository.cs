using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.PPV;

namespace WpfApp2.Db.Models.LegParts.PPV
{
    public class PPVEntryRepository : Repository<PPVEntry>
    {
        public PPVEntryRepository(DbContext context) : base(context)
        {

        }
    }





    public class PPVEntryFullRepository : Repository<PPVEntryFull>
    {
        public PPVEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}

