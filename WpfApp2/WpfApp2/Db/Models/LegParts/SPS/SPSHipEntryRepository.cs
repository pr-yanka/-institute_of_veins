using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.SPS;

namespace WpfApp2.Db.Models.LegParts.SPSHip
{
    public class SPSHipEntryRepository : Repository<SPSHipEntry>
    {
        public SPSHipEntryRepository(DbContext context) : base(context)
        {

        }
    }





    public class SPSHipEntryFullRepository : Repository<SPSHipEntryFull>
    {
        public SPSHipEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}

