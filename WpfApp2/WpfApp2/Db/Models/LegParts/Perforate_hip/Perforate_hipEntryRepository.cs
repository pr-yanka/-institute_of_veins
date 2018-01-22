using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.Perforate_hip
{
    public class Perforate_hipEntryRepository : Repository<Perforate_hipEntry>
    {
        public Perforate_hipEntryRepository(DbContext context) : base(context)
        {

        }
    }

    


public class Perforate_hipEntryFullRepository : Repository<Perforate_hipEntryFull>
    {
        public Perforate_hipEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
