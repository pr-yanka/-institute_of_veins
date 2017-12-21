using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models.SPS
{
    [Table("спс_структура")]
    public partial class SPSStructure : LegPartDbStructure, ILegPart
    {
        [Required]
        [Column("двойная_метрика")]
        public bool DoubleMetric{ get; set; }
    }

    [Table("спс_комбо")]
    public partial class BPVHipCombo : ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
    }
}
