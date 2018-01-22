using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.Perforate_shin
{
    public class Perforate_shinEntryRepository : Repository<Perforate_shinEntry>
    {
        public Perforate_shinEntryRepository(DbContext context) : base(context)
        {

        }
    }

    


public class Perforate_shinEntryFullRepository : Repository<Perforate_shinEntryFull>
    {
        public Perforate_shinEntryFullRepository(DbContext context) : base(context)
        {

        }
    }
}
