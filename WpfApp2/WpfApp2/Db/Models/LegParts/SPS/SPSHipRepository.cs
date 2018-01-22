using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.SPS;

namespace WpfApp2.Db.Models.LegParts
{
    public class SPSHipRepository : Repository<SPSHipStructure>
    {
        public SPSHipRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SPSHipStructure> LevelStructures(int level)
        {
            return dbContext.Set<SPSHipStructure>().Where(SPShip => SPShip.Level == level).ToList();
        }
    }
}