using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public class BPVHipRepository : ILegPartRepository, LegPart
    {
        

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

        public IEnumerable<LegPart> GetAll
        {
            get
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

        public void Add(LegPart entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LegPart> entities)
        {
            throw new NotImplementedException();
        }

        public LegPart Get(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(LegPart entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LegPart> entities)
        {
            throw new NotImplementedException();
        }
    }
}
