using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models.GV
{
    [Table("гв_структура")]
    public partial class GVStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get; set; }

        public virtual ICollection<GVCombo> GVs1 { get; set; } = new HashSet<GVCombo>();
        public virtual ICollection<GVCombo> GVs2 { get; set; } = new HashSet<GVCombo>();
       
        public virtual ICollection<GVEntry> Entries { get; set; } = new HashSet<GVEntry>();
    }

    [Table("гв_комбо")]
    public partial class GVCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual GVStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual GVStructure Str2 { get; set; }


       

        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    [Table("гв_подзапись")]
    public class GVEntry : LegPartEntry, ILegPart
    {
        public virtual GVStructure Structure { get; set; }


        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual ICollection<GVEntryFull> EntriesFull1 { get; set; } = new HashSet<GVEntryFull>();
        public virtual ICollection<GVEntryFull> EntriesFull2 { get; set; } = new HashSet<GVEntryFull>();
       
    }

    [Table("глубокие_вены")]
    public class GVEntryFull : LegPartEntries
    {

        public virtual GVEntry GVEntry1 { get; set; }
        public virtual GVEntry GVEntry2 { get; set; }
        

        public override int EntryId1 { get; set; }
        public override int EntryId2 { get; set; }
       
    }
}