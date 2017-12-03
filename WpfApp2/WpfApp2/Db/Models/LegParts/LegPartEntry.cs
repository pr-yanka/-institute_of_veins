using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public abstract class LegPartEntry
    {
        public int Id { get; set; }
        public int StructureID { get; set; }
        public string Comment { get; set; }
        public string Size { get; set; }
    }
}
