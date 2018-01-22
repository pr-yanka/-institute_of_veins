using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class ZDSVRepository : Repository<ZDSVStructure>
    {
        public ZDSVRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ZDSVStructure> LevelStructures(int level)
        {
            return dbContext.Set<ZDSVStructure>().Where(bpvhip => bpvhip.Level == level).ToList();
        }
    }
}