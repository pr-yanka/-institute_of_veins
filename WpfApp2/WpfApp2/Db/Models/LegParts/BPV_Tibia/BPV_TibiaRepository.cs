using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class BPV_TibiaRepository : Repository<BPV_TibiaStructure>
    {
        public BPV_TibiaRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<BPV_TibiaStructure> LevelStructures(int level)
        {
            return dbContext.Set<BPV_TibiaStructure>().Where(bpvhip => bpvhip.Level == level).ToList();
        }
    }
}