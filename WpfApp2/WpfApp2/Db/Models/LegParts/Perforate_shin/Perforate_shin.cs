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
    public class Perforate_shin
    {

    }
    [Table("perforate_shin_structure")]
    //[Table("перфорант_голень_structure")]
    public partial class Perforate_shinStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<Perforate_shinCombo> BPVs1 { get; set; } = new HashSet<Perforate_shinCombo>();
        public virtual ICollection<Perforate_shinCombo> BPVs2 { get; set; } = new HashSet<Perforate_shinCombo>();
        public virtual ICollection<Perforate_shinCombo> BPVs3 { get; set; } = new HashSet<Perforate_shinCombo>();
        public virtual ICollection<Perforate_shinCombo> BPVs4 { get; set; } = new HashSet<Perforate_shinCombo>();
        public virtual ICollection<Perforate_shinCombo> BPVs5 { get; set; } = new HashSet<Perforate_shinCombo>();

        public virtual ICollection<Perforate_shinEntry> Entries { get; set; } = new HashSet<Perforate_shinEntry>();
    }
    [Table("perforate_shin_combo")]
    //[Table("перфорант_голень_комбо")]
    public partial class Perforate_shinCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure_1")]
        public int IdStr1 { get; set; }

        public virtual Perforate_shinStructure Str1 { get; set; }

        [Column("structure_2")]
        public int? IdStr2 { get; set; }

        public virtual Perforate_shinStructure Str2 { get; set; }

        [Column("structure_3")]
        public int? IdStr3 { get; set; }
        public virtual Perforate_shinStructure Str3 { get; set; }

        [Column("structure_4")]
        public int? IdStr4 { get; set; }
        public virtual Perforate_shinStructure Str4 { get; set; }

        [Column("structure_5")]
        public int? IdStr5 { get; set; }
        public virtual Perforate_shinStructure Str5 { get; set; }

        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    /*
    public class Perforate_shinStructureRepository : IRepository<Perforate_shinStructure>
    {
        private Perforate_shinContext _context;

        public Perforate_shinStructureRepository()
        {
            _context = new Perforate_shinContext();

        }
        public IEnumerable<Perforate_shinStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(Perforate_shinStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Perforate_shinStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Perforate_shinStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public Perforate_shinStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/
    [Table("perforate_shin_sub_entry")]
    //   [Table("перфорант_голень_sub_entry")]
    public class Perforate_shinEntry : LegPartEntry, ILegPart
    {

        [Column("metrics")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual Perforate_shinStructure Structure { get; set; }

        public virtual ICollection<Perforate_shinEntryFull> EntriesFull1 { get; set; } = new HashSet<Perforate_shinEntryFull>();
        public virtual ICollection<Perforate_shinEntryFull> EntriesFull2 { get; set; } = new HashSet<Perforate_shinEntryFull>();
        public virtual ICollection<Perforate_shinEntryFull> EntriesFull3 { get; set; } = new HashSet<Perforate_shinEntryFull>();
        public virtual ICollection<Perforate_shinEntryFull> EntriesFull4 { get; set; } = new HashSet<Perforate_shinEntryFull>();
        public virtual ICollection<Perforate_shinEntryFull> EntriesFull5 { get; set; } = new HashSet<Perforate_shinEntryFull>();

    }


    [Table("perforate_shin")]
    //[Table("перфорант_голень")]
    public class Perforate_shinEntryFull : LegPartEntries
    {
        [NotMapped]
        public override int? WayID { get; set; }

        public virtual Perforate_shinEntry Perforate_shinEntry1 { get; set; }
        public virtual Perforate_shinEntry Perforate_shinEntry2 { get; set; }
        public virtual Perforate_shinEntry Perforate_shinEntry3 { get; set; }
        public virtual Perforate_shinEntry Perforate_shinEntry4 { get; set; }
        public virtual Perforate_shinEntry Perforate_shinEntry5 { get; set; }

        [Column("sub_entry_1")]
        public override int EntryId1 { get; set; }
        [Column("sub_entry_2")]
        public override int? EntryId2 { get; set; }
        [Column("sub_entry_3")]
        public override int? EntryId3 { get; set; }
        [Column("sub_entry_4")]
        public override int? EntryId4 { get; set; }
        [Column("sub_entry_5")]
        public override int? EntryId5 { get; set; }


        [NotMapped]
        public override int? EntryId6 { get; set; }



    }
}
