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
    public partial class SPSHipStructure : LegPartDbStructure, ILegPart
    {
        [Column("двойная_метрика")]
        public override bool HasDoubleMetric { get; set; }

        public virtual ICollection<SPSHipCombo> SPSs1 { get; set; } = new HashSet<SPSHipCombo>();
        public virtual ICollection<SPSHipCombo> SPSs2 { get; set; } = new HashSet<SPSHipCombo>();
        public virtual ICollection<SPSHipCombo> SPSs3 { get; set; } = new HashSet<SPSHipCombo>();
        public virtual ICollection<SPSHipEntry> Entries { get; set; } = new HashSet<SPSHipEntry>();
    }

    [Table("спс_комбо")]
    public partial class SPSHipCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual SPSHipStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual SPSHipStructure Str2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
        public virtual SPSHipStructure Str3 { get; set; }

       

        public override string ToString()
        {
            return Str1.ToString();
        }
    }


    [Table("спс_подзапись")]
    public class SPSHipEntry : LegPartEntry, ILegPart
    {
        public virtual SPSHipStructure Structure { get; set; }


        public override float Size { get; set; }

        public override float Size2 { get; set; }

        public virtual ICollection<SPSHipEntryFull> EntriesFull1 { get; set; } = new HashSet<SPSHipEntryFull>();
        public virtual ICollection<SPSHipEntryFull> EntriesFull2 { get; set; } = new HashSet<SPSHipEntryFull>();
        public virtual ICollection<SPSHipEntryFull> EntriesFull3 { get; set; } = new HashSet<SPSHipEntryFull>();
    
    }



    [Table("сафено_поплитеальное_соустье")]
    public class SPSHipEntryFull : LegPartEntries
    {

        public virtual SPSHipEntry SPSHipEntry1 { get; set; }
        public virtual SPSHipEntry SPSHipEntry2 { get; set; }
        public virtual SPSHipEntry SPSHipEntry3 { get; set; }
        


        public override int EntryId1 { get; set; }
        public override int EntryId2 { get; set; }
        public override int EntryId3 { get; set; }
      
    }
}
