using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models.PPV
{
    [Table("ppv_structure")]
    // [Table("ппв_structure")]
    public partial class PPVStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get; set; }

        public virtual ICollection<PPVCombo> PPVs1 { get; set; } = new HashSet<PPVCombo>();
        public virtual ICollection<PPVCombo> PPVs2 { get; set; } = new HashSet<PPVCombo>();

        public virtual ICollection<PPVEntry> Entries { get; set; } = new HashSet<PPVEntry>();
    }
    [Table("ppv_combo")]
    // [Table("ппв_комбо")]
    public partial class PPVCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual PPVStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual PPVStructure Str2 { get; set; }




        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    [Table("ppv_sub_entry")]
    //[Table("ппв_подзапись")]
    public class PPVEntry : LegPartEntry, ILegPart
    {
        public virtual PPVStructure Structure { get; set; }


        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual ICollection<PPVEntryFull> EntriesFull1 { get; set; } = new HashSet<PPVEntryFull>();
        public virtual ICollection<PPVEntryFull> EntriesFull2 { get; set; } = new HashSet<PPVEntryFull>();

    }

    [Table("popliteal_perforating_vein")]
    //[Table("подколенная_перфорантная_вена")]
    public class PPVEntryFull : LegPartEntries
    {

        public virtual PPVEntry PPVEntry1 { get; set; }
        public virtual PPVEntry PPVEntry2 { get; set; }

        [NotMapped]
        public override int? WayID { get; set; }

        public override int EntryId1 { get; set; }
        public override int? EntryId2 { get; set; }

        [NotMapped]
        public override int? EntryId3 { get; set; }

        [NotMapped]
        public override int? EntryId4 { get; set; }

        [NotMapped]
        public override int? EntryId5 { get; set; }

        [NotMapped]
        public override int? EntryId6 { get; set; }

    }
}
