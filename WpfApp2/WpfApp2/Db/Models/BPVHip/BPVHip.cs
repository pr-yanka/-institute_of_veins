using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    public class BPVHipStructure
    {
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public bool HasSize { get; set; }
        public string Size { get; set; }
        public int Level { get; set; }
    }

    public class BPVHipEntry
    {
        public int Id { get; set; }
        //если в бд int - как тут хранить?
        public int BPVHipStructureID { get; set; }
        public string Comment { get; set; }
        public string Size { get; set; }
    }

    public class BPVHipWay
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BPVHipEntryFull
    {
        public int Id { get; set; }
        public int BPVHipWayID { get; set; }
        public int BPVHipEntryId1 { get; set; }
        public int BPVHipEntryId2 { get; set; }
        public int BPVHipEntryId3 { get; set; }
        public int BPVHipEntryId4 { get; set; }
        public int BPVHipEntryId5 { get; set; }
    }
}
