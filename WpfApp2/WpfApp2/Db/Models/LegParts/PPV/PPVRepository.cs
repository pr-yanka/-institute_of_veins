using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.PPV;
using WpfApp2.Db.Models.SPS;

namespace WpfApp2.Db.Models.LegParts
{
    public class PPVRepository : Repository<PPVStructure>
    {
        public PPVRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<PPVStructure> LevelStructures(int level)
        {
            return dbContext.Set<PPVStructure>().Where(PPV => PPV.Level == level).ToList();
        }
    }
}