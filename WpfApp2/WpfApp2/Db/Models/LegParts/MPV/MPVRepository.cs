using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class MPVRepository : Repository<MPVStructure>
    {
        public MPVRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<MPVStructure> LevelStructures(int level)
        {
            return dbContext.Set<MPVStructure>().Where(mpv => mpv.Level == level).ToList();
        }
    }
}