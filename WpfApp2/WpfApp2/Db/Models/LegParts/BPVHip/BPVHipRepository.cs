using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models.LegParts
{
    //public class BPVHipAdditionalStructureRepository : Repository<BPVHipAdditionalStructure>
    //{
    //    public BPVHipAdditionalStructureRepository(DbContext context) : base(context)
    //    {

    //    }
    //}
    public class BPVHipRepository : Repository<BPVHipStructure>
    {
        public BPVHipRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<BPVHipStructure> LevelStructures(int level)
        {
            return dbContext.Set<BPVHipStructure>().Where(bpvhip => bpvhip.Level == level).ToList();
        }
    }
}