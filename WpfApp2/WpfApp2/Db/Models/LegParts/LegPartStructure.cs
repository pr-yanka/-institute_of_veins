using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    public abstract class LegPartStructure
    {
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public bool HasSize { get; set; }
        public string Size { get; set; }
        public int Level { get; set; }
    }
}
