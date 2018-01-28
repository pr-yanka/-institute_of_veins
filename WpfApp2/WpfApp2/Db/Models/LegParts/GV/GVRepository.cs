using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.GV;
using WpfApp2.Db.Models.SPS;

namespace WpfApp2.Db.Models.LegParts
{
    public class GVRepository : Repository<GVStructure>
    {
        public GVRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<GVStructure> LevelStructures(int level)
        {
            return dbContext.Set<GVStructure>().Where(GV => GV.Level == level).ToList();
        }
    }
}