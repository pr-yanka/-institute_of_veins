using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;

namespace WpfApp2.Db.Models.LegParts
{
    public class Perforate_shinRepository : Repository<Perforate_shinStructure>
    {
        public Perforate_shinRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Perforate_shinStructure> LevelStructures(int level)
        {
            return dbContext.Set<Perforate_shinStructure>().Where(Perforate_shin => Perforate_shin.Level == level).ToList();
        }
    }
}