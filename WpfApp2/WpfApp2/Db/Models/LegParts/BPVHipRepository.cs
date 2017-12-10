using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.BPV;

namespace WpfApp2.Db.Models.LegParts
{
    public class BPVHipRepository : Repository<BPVHipStructure>, ILegPartRepository
    {
        public BPVHipRepository(DbContext context) : base(context)
        {
        }

        public LegPartEntries Entries
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public LegPartEntry Entry
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public LegPartStructure Structure
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}