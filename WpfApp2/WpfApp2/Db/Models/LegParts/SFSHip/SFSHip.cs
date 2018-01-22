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
    public class SFSHip
    {
        
    }

    [Table("сфс_структура")]
    public partial class SFSHipStructure : LegPartDbStructure, ILegPart
    {
        [Column("двойная_метрика")]
        public override bool HasDoubleMetric { get; set; }

        public virtual ICollection<SFSHipCombo> SFSs1 { get; set; } = new HashSet<SFSHipCombo>();
        public virtual ICollection<SFSHipCombo> SFSs2 { get; set; } = new HashSet<SFSHipCombo>();
        public virtual ICollection<SFSHipCombo> SFSs3 { get; set; } = new HashSet<SFSHipCombo>();
        public virtual ICollection<SFSHipCombo> SFSs4 { get; set; } = new HashSet<SFSHipCombo>();
        public virtual ICollection<SFSHipCombo> SFSs5 { get; set; } = new HashSet<SFSHipCombo>();
        public virtual ICollection<SFSHipCombo> SFSs6 { get; set; } = new HashSet<SFSHipCombo>();
        public virtual ICollection<SFSHipEntry> Entries { get; set; } = new HashSet<SFSHipEntry>();
    }

    [Table("сфс_комбо")]
    public partial class SFSHipCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual SFSHipStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual SFSHipStructure Str2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
        public virtual SFSHipStructure Str3 { get; set; }

        [Column("структура4")]
        public int? IdStr4 { get; set; }
        public virtual SFSHipStructure Str4 { get; set; }

        [Column("структура5")]
        public int? IdStr5 { get; set; }
        public virtual SFSHipStructure Str5 { get; set; }

        [Column("структура6")]
        public int? IdStr6 { get; set; }
        public virtual SFSHipStructure Str6 { get; set; }

        public override string ToString()
        {
            return Str1.ToString();
        }   
    }

  
    [Table("сфс_подзапись")]
    public class SFSHipEntry : LegPartEntry, ILegPart
    {
        public virtual SFSHipStructure Structure { get; set; }

      
        public override float Size { get; set; }
     
        public override float Size2 { get; set; }

        public virtual ICollection<SFSHipEntryFull> EntriesFull1 { get; set; } = new HashSet<SFSHipEntryFull>();
        public virtual ICollection<SFSHipEntryFull> EntriesFull2 { get; set; } = new HashSet<SFSHipEntryFull>();
        public virtual ICollection<SFSHipEntryFull> EntriesFull3 { get; set; } = new HashSet<SFSHipEntryFull>();
        public virtual ICollection<SFSHipEntryFull> EntriesFull4 { get; set; } = new HashSet<SFSHipEntryFull>();
        public virtual ICollection<SFSHipEntryFull> EntriesFull5 { get; set; } = new HashSet<SFSHipEntryFull>();
        public virtual ICollection<SFSHipEntryFull> EntriesFull6 { get; set; } = new HashSet<SFSHipEntryFull>();

    }



    [Table("сафено-феморальное соустье")]
    public class SFSHipEntryFull : LegPartEntries
    {
      
        public virtual SFSHipEntry SFSHipEntry1 { get; set; }
        public virtual SFSHipEntry SFSHipEntry2 { get; set; }
        public virtual SFSHipEntry SFSHipEntry3 { get; set; }
        public virtual SFSHipEntry SFSHipEntry4 { get; set; }
        public virtual SFSHipEntry SFSHipEntry5 { get; set; }
        public virtual SFSHipEntry SFSHipEntry6 { get; set; }
   
      

        public override int EntryId1 { get; set; }
        public override int EntryId2 { get; set; }
        public override int EntryId3 { get; set; }
        public override int EntryId4 { get; set; }
        public override int EntryId5 { get; set; }
        public override int EntryId6 { get; set; }
    }
}
