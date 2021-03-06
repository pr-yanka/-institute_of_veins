﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    public class MPV
    {

    }
    [Table("mpv_structure")]
    //[Table("мпв_structure")]
    public partial class MPVStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<MPVCombo> MPVs1 { get; set; } = new HashSet<MPVCombo>();
        public virtual ICollection<MPVCombo> MPVs2 { get; set; } = new HashSet<MPVCombo>();
        public virtual ICollection<MPVCombo> MPVs3 { get; set; } = new HashSet<MPVCombo>();
        public virtual ICollection<MPVCombo> MPVs4 { get; set; } = new HashSet<MPVCombo>();
        public virtual ICollection<MPVEntry> Entries { get; set; } = new HashSet<MPVEntry>();
    }
    [Table("mpv_combo")]
    //[Table("мпв_комбо")]
    public partial class MPVCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual MPVStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual MPVStructure Str2 { get; set; }

        [Column("structure3")]
        public int? IdStr3 { get; set; }
        public virtual MPVStructure Str3 { get; set; }

        [Column("structure4")]
        public int? IdStr4 { get; set; }
        public virtual MPVStructure Str4 { get; set; }


        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    /*
    public class MPVStructureRepository : IRepository<MPVStructure>
    {
        private MPVContext _context;

        public MPVStructureRepository()
        {
            _context = new MPVContext();

        }
        public IEnumerable<MPVStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(MPVStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(MPVStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(MPVStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public MPVStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/
    [Table("mpv_sub_entry")]
    //   [Table("мпв_подзапись")]
    public class MPVEntry : LegPartEntry, ILegPart
    {

        [Column("metrics")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual MPVStructure Structure { get; set; }

        public virtual ICollection<MPVEntryFull> EntriesFull1 { get; set; } = new HashSet<MPVEntryFull>();
        public virtual ICollection<MPVEntryFull> EntriesFull2 { get; set; } = new HashSet<MPVEntryFull>();
        public virtual ICollection<MPVEntryFull> EntriesFull3 { get; set; } = new HashSet<MPVEntryFull>();
        public virtual ICollection<MPVEntryFull> EntriesFull4 { get; set; } = new HashSet<MPVEntryFull>();

    }
    [Table("mpv_way")]
    //[Table("вид_мпв_хода")]
    public class MPVWay : da_Way
    {

        public virtual ICollection<MPVEntryFull> EntriesFull { get; set; } = new HashSet<MPVEntryFull>();

    }
    [Table("small_saphenous_vein")]
    //[Table("малая_подкожная_вена")]
    public class MPVEntryFull : LegPartEntries
    {
        public virtual MPVWay MPVWay { get; set; }
        public virtual MPVEntry MPVEntry1 { get; set; }
        public virtual MPVEntry MPVEntry2 { get; set; }
        public virtual MPVEntry MPVEntry3 { get; set; }
        public virtual MPVEntry MPVEntry4 { get; set; }

        [NotMapped]
        public override int? EntryId0 { get; set; }

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
