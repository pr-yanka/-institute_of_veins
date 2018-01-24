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
    public class TEMPV
    {

    }

    [Table("те_мпв_структура")]
    public partial class TEMPVStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<TEMPVCombo> TEMPVs1 { get; set; } = new HashSet<TEMPVCombo>();
        public virtual ICollection<TEMPVCombo> TEMPVs2 { get; set; } = new HashSet<TEMPVCombo>();
        public virtual ICollection<TEMPVCombo> TEMPVs3 { get; set; } = new HashSet<TEMPVCombo>();
         public virtual ICollection<TEMPVEntry> Entries { get; set; } = new HashSet<TEMPVEntry>();
    }

    [Table("те_мпв_комбо")]
    public partial class TEMPVCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual TEMPVStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual TEMPVStructure Str2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
        public virtual TEMPVStructure Str3 { get; set; }

      

        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    /*
    public class TEMPVStructureRepository : IRepository<TEMPVStructure>
    {
        private TEMPVContext _context;

        public TEMPVStructureRepository()
        {
            _context = new TEMPVContext();

        }
        public IEnumerable<TEMPVStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(TEMPVStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEMPVStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEMPVStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public TEMPVStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/
    [Table("те_мпв_подзапись")]
    public class TEMPVEntry : LegPartEntry, ILegPart
    {

        [Column("метрика")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual TEMPVStructure Structure { get; set; }

        public virtual ICollection<TEMPVEntryFull> EntriesFull1 { get; set; } = new HashSet<TEMPVEntryFull>();
        public virtual ICollection<TEMPVEntryFull> EntriesFull2 { get; set; } = new HashSet<TEMPVEntryFull>();
        public virtual ICollection<TEMPVEntryFull> EntriesFull3 { get; set; } = new HashSet<TEMPVEntryFull>();
      
    }

    [Table("ход_в_фасциальном_футляре")]
    public class TEMPVWay : da_Way
    {

        public virtual ICollection<TEMPVEntryFull> EntriesFull { get; set; } = new HashSet<TEMPVEntryFull>();

    }

    [Table("бедренное_продолжение_малой_подкожной_вены")]
    public class TEMPVEntryFull : LegPartEntries
    {
        public virtual TEMPVWay TEMPVWay { get; set; }
        public virtual TEMPVEntry TEMPVEntry1 { get; set; }
        public virtual TEMPVEntry TEMPVEntry2 { get; set; }
        public virtual TEMPVEntry TEMPVEntry3 { get; set; }

        [Column("id_хода_ФФ")]
        public override int WayID { get; set; }


        [Column("протяженность_ФФ")]
        public float FF_Length { get; set; }

        public override int EntryId1 { get; set; }
        public override int EntryId2 { get; set; }
        public override int EntryId3 { get; set; }
    }
}
