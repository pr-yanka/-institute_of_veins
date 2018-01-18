using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class SFSHipRepository : Repository<SFSHipStructure>
    {
        public SFSHipRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<SFSHipStructure> LevelStructures(int level)
        {
            return dbContext.Set<SFSHipStructure>().Where(sfship => sfship.Level == level).ToList();
        }
    }
}