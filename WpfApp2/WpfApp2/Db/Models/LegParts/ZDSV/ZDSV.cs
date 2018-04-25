using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    public class ZDSV
    {

    }
    [Table("zdsv_structure")]
    //[Table("здсв_structure")]
    public partial class ZDSVStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<ZDSVCombo> ZDSVs1 { get; set; } = new HashSet<ZDSVCombo>();
        public virtual ICollection<ZDSVCombo> ZDSVs2 { get; set; } = new HashSet<ZDSVCombo>();
        public virtual ICollection<ZDSVCombo> ZDSVs3 { get; set; } = new HashSet<ZDSVCombo>();

        public virtual ICollection<ZDSVEntry> Entries { get; set; } = new HashSet<ZDSVEntry>();
    }
    [Table("zdsv_combo")]
    //[Table("здсв_комбо")]
    public partial class ZDSVCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual ZDSVStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual ZDSVStructure Str2 { get; set; }

        [Column("structure3")]
        public int? IdStr3 { get; set; }
        public virtual ZDSVStructure Str3 { get; set; }


        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    [Table("zdsv_sub_entry")]
    //  [Table("здсв_подзапись")]
    public class ZDSVEntry : LegPartEntry, ILegPart
    {

        [Column("metrics")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual ZDSVStructure Structure { get; set; }
        public virtual ICollection<ZDSVEntryFull> EntriesFull0 { get; set; } = new HashSet<ZDSVEntryFull>();
        public virtual ICollection<ZDSVEntryFull> EntriesFull1 { get; set; } = new HashSet<ZDSVEntryFull>();
        public virtual ICollection<ZDSVEntryFull> EntriesFull2 { get; set; } = new HashSet<ZDSVEntryFull>();
        public virtual ICollection<ZDSVEntryFull> EntriesFull3 { get; set; } = new HashSet<ZDSVEntryFull>();

    }

    [Table("posterior_accessory_vein")]
    // [Table("задняя_добавочная_сафенная_вена")]

    public class ZDSVEntryFull : LegPartEntries
    {

        public virtual ZDSVEntry ZDSVEntry1 { get; set; }
        public virtual ZDSVEntry ZDSVEntry2 { get; set; }
        public virtual ZDSVEntry ZDSVEntry3 { get; set; }
        public virtual ZDSVEntry ZDSVEntry0 { get; set; }

        [NotMapped]
        public override int? WayID { get; set; }

        public override int EntryId1 { get; set; }
        public override int? EntryId2 { get; set; }
        public override int? EntryId3 { get; set; }
 
        public override int? EntryId0 { get; set; }
        [NotMapped]
        public override int? EntryId4 { get; set; }

        [NotMapped]
        public override int? EntryId5 { get; set; }

        [NotMapped]
        public override int? EntryId6 { get; set; }

    }
}
