﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models.GV
{
    [Table("gv_structure")]
    //[Table("гв_structure")]
    public partial class GVStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get; set; }

        public virtual ICollection<GVCombo> GVs1 { get; set; } = new HashSet<GVCombo>();
        public virtual ICollection<GVCombo> GVs2 { get; set; } = new HashSet<GVCombo>();
       
        public virtual ICollection<GVEntry> Entries { get; set; } = new HashSet<GVEntry>();
    }
    [Table("gv_combo")]
   // [Table("гв_комбо")]
    public partial class GVCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual GVStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual GVStructure Str2 { get; set; }


       

        public override string ToString()
        {
            return Str1.ToString();
        }
    }
    [Table("gv_sub_entry")]
   // [Table("гв_подзапись")]
    public class GVEntry : LegPartEntry, ILegPart
    {
        public virtual GVStructure Structure { get; set; }


        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual ICollection<GVEntryFull> EntriesFull1 { get; set; } = new HashSet<GVEntryFull>();
        public virtual ICollection<GVEntryFull> EntriesFull2 { get; set; } = new HashSet<GVEntryFull>();
       
    }
    [Table("deep_veins")]
    //[Table("глубокие_вены")]
    public class GVEntryFull : LegPartEntries
    {
        [NotMapped]
        public override int? EntryId0 { get; set; }
        [NotMapped]
        public override int? WayID { get; set; }

        public virtual GVEntry GVEntry1 { get; set; }
        public virtual GVEntry GVEntry2 { get; set; }
        

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