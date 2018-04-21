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
    public class BPV_Tibia
    {

    }

    //[Table("бпв_на_голени_structure")]
    [Table("bpw_tibia_structure")]
    public partial class BPV_TibiaStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<BPV_TibiaCombo> BPVs1 { get; set; } = new HashSet<BPV_TibiaCombo>();
        public virtual ICollection<BPV_TibiaCombo> BPVs2 { get; set; } = new HashSet<BPV_TibiaCombo>();
        public virtual ICollection<BPV_TibiaCombo> BPVs3 { get; set; } = new HashSet<BPV_TibiaCombo>();
        public virtual ICollection<BPV_TibiaCombo> BPVs4 { get; set; } = new HashSet<BPV_TibiaCombo>();


        public virtual ICollection<BPV_TibiaEntry> Entries { get; set; } = new HashSet<BPV_TibiaEntry>();
    }

    //  [Table("бпв_на_голени_комбо")]

    [Table("bpw_tibia_combo")]
    public partial class BPV_TibiaCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual BPV_TibiaStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual BPV_TibiaStructure Str2 { get; set; }

        [Column("structure3")]
        public int? IdStr3 { get; set; }
        public virtual BPV_TibiaStructure Str3 { get; set; }

        [Column("structure4")]
        public int? IdStr4 { get; set; }
        public virtual BPV_TibiaStructure Str4 { get; set; }



        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    
    // [Table("бпв_на_голени_подзапись")]
    [Table("bpw_tibia_sub_entry")]
    public class BPV_TibiaEntry : LegPartEntry, ILegPart
    {

        [Column("metrics")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }


        public virtual BPV_TibiaStructure Structure { get; set; }

        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull1 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull2 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull3 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull4 { get; set; } = new HashSet<BPV_TibiaEntryFull>();

    }



    //[Table("бпв_на_голени")]
    [Table("bpw_tibia")]
    
    public class BPV_TibiaEntryFull : LegPartEntries
    {

        public virtual BPV_TibiaEntry BPV_TibiaEntry1 { get; set; }
        public virtual BPV_TibiaEntry BPV_TibiaEntry2 { get; set; }
        public virtual BPV_TibiaEntry BPV_TibiaEntry3 { get; set; }
        public virtual BPV_TibiaEntry BPV_TibiaEntry4 { get; set; }
        [NotMapped]
        public override int? EntryId0 { get; set; }
        [NotMapped]
        public override int? WayID { get; set; }

        public override int EntryId1 { get; set; }
        public override int? EntryId2 { get; set; }
        public override int? EntryId3 { get; set; }
        public override int? EntryId4 { get; set; }

        [NotMapped]
        public override int? EntryId5 { get; set; }

        [NotMapped]
        public override int? EntryId6 { get; set; }
    }
}
