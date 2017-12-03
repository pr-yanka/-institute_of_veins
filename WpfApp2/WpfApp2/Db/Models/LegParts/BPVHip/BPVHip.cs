using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    public class BPVHipStructure : LegPartStructure
    {

    }

    public class BPVHipEntry : LegPartEntry
    {
        
    }

    public class BPVHipWay
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BPVHipEntryFull : LegPartEntries
    {
        public int Id { get; set; }
        public int BPVHipWayID { get; set; }
        public int BPVHipEntryId3 { get; set; }
        public int BPVHipEntryId4 { get; set; }
        public int BPVHipEntryId5 { get; set; }
    }
}
