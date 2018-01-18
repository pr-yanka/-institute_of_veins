using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.SFSHip
{
    public class SFSHipEntryRepository : Repository<SFSHipEntry>
    {
        public SFSHipEntryRepository(DbContext context) : base(context)
        {

        }
    }





    public class SFSHipEntryFullRepository : Repository<SFSHipEntryFull>
    {
        public SFSHipEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}

