using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class TEMPVRepository : Repository<TEMPVStructure>
    {
        public TEMPVRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<TEMPVStructure> LevelStructures(int level)
        {
            return dbContext.Set<TEMPVStructure>().Where(TEMPV => TEMPV.Level == level).ToList();
        }
    }
}