using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class Perforate_hipRepository : Repository<Perforate_hipStructure>
    {
        public Perforate_hipRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Perforate_hipStructure> LevelStructures(int level)
        {
            return dbContext.Set<Perforate_hipStructure>().Where(Perforate_hip => Perforate_hip.Level == level).ToList();
        }
    }
}