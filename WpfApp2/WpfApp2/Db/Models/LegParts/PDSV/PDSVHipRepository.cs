using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class PDSVHipRepository : Repository<PDSVHipStructure>
    {
        public PDSVHipRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<PDSVHipStructure> LevelStructures(int level)
        {
            return dbContext.Set<PDSVHipStructure>().Where(bpvhip => bpvhip.Level == level).ToList();
        }
    }
}