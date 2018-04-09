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
    [Table("sps_structure")]
   // [Table("спс_structure")]
    public partial class SPSHipStructure : LegPartDbStructure, ILegPart
    {
        [Column("double_metric")]
        public override bool HasDoubleMetric { get; set; }

        public virtual ICollection<SPSHipCombo> SPSs1 { get; set; } = new HashSet<SPSHipCombo>();
        public virtual ICollection<SPSHipCombo> SPSs2 { get; set; } = new HashSet<SPSHipCombo>();
        public virtual ICollection<SPSHipCombo> SPSs3 { get; set; } = new HashSet<SPSHipCombo>();
        public virtual ICollection<SPSHipEntry> Entries { get; set; } = new HashSet<SPSHipEntry>();
    }

    [Table("sps_combo")]
    //[Table("спс_комбо")]
    public partial class SPSHipCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual SPSHipStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual SPSHipStructure Str2 { get; set; }

        [Column("structure3")]
        public int? IdStr3 { get; set; }
        public virtual SPSHipStructure Str3 { get; set; }

       

        public override string ToString()
        {
            return Str1.ToString();
        }
    }


    [Table("sps_hip_sub_entry")]
    //[Table("спс_голень_подзапись")]
    public class SPSHipEntry : LegPartEntry, ILegPart
    {
        public virtual SPSHipStructure Structure { get; set; }


        public override float Size { get; set; }

        public override float Size2 { get; set; }

        public virtual ICollection<SPSHipEntryFull> EntriesFull1 { get; set; } = new HashSet<SPSHipEntryFull>();
        public virtual ICollection<SPSHipEntryFull> EntriesFull2 { get; set; } = new HashSet<SPSHipEntryFull>();
        public virtual ICollection<SPSHipEntryFull> EntriesFull3 { get; set; } = new HashSet<SPSHipEntryFull>();
    
    }


    [Table("sapheno_apical_fistula")]
   // [Table("сафено_поплитеальное_соустье")]
    public class SPSHipEntryFull : LegPartEntries
    {

        public virtual SPSHipEntry SPSHipEntry1 { get; set; }
        public virtual SPSHipEntry SPSHipEntry2 { get; set; }
        public virtual SPSHipEntry SPSHipEntry3 { get; set; }

        [NotMapped]
        public override int? WayID { get; set; }

        public override int EntryId1 { get; set; }
        public override int? EntryId2 { get; set; }
        public override int? EntryId3 { get; set; }
     
        [NotMapped]
        public override int? EntryId4 { get; set; }

        [NotMapped]
        public override int? EntryId5 { get; set; }

        [NotMapped]
        public override int? EntryId6 { get; set; }

    }
}
