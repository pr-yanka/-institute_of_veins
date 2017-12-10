using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public interface ILegPartRepository : IRepository<BPVHipStructure>
    {
        LegPartEntries Entries { get; set; }
        LegPartEntry Entry { get; set; }
        LegPartStructure Structure { get; set; }
    }
}
