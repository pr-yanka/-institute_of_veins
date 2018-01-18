using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public abstract class LegPartEntry
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_структуры")]
        public int StructureID { get; set; }
        [Column("комментарий")]
        public string Comment { get; set; }
        [NotMapped]
        public virtual float Size { get; set; }
        [NotMapped]
        public virtual float Size2 { get; set; }

    }
   
}
