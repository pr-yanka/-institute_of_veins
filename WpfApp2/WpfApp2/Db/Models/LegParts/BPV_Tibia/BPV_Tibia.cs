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

    [Table("бпв_на_голени_структура")]
    public partial class BPV_TibiaStructure :LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<BPV_TibiaCombo> BPVs1 { get; set; } = new HashSet<BPV_TibiaCombo>();
        public virtual ICollection<BPV_TibiaCombo> BPVs2 { get; set; } = new HashSet<BPV_TibiaCombo>();
        public virtual ICollection<BPV_TibiaCombo> BPVs3 { get; set; } = new HashSet<BPV_TibiaCombo>();
        public virtual ICollection<BPV_TibiaCombo> BPVs4 { get; set; } = new HashSet<BPV_TibiaCombo>();
      

        public virtual ICollection<BPV_TibiaEntry> Entries { get; set; } = new HashSet<BPV_TibiaEntry>();
    }

    [Table("бпв_на_голени_комбо")]
    public partial class BPV_TibiaCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual BPV_TibiaStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual BPV_TibiaStructure Str2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
        public virtual BPV_TibiaStructure Str3 { get; set; }

        [Column("структура4")]
        public int? IdStr4 { get; set; }
        public virtual BPV_TibiaStructure Str4 { get; set; }

      

        public override string ToString()
        {
            return Str1.ToString();
        }   
    }

    /*
    public class BPV_TibiaStructureRepository : IRepository<BPV_TibiaStructure>
    {
        private BPV_TibiaContext _context;

        public BPV_TibiaStructureRepository()
        {
            _context = new BPV_TibiaContext();

        }
        public IEnumerable<BPV_TibiaStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(BPV_TibiaStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(BPV_TibiaStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(BPV_TibiaStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public BPV_TibiaStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/
    [Table("бпв_на_голени_подзапись")]
    public class BPV_TibiaEntry : LegPartEntry, ILegPart
    {

        [Column("метрика")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }
       

        public virtual BPV_TibiaStructure Structure { get; set; }

        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull1 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull2 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull3 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
        public virtual ICollection<BPV_TibiaEntryFull> EntriesFull4 { get; set; } = new HashSet<BPV_TibiaEntryFull>();
      
    }



    [Table("бпв_на_голени")]
    public class BPV_TibiaEntryFull : LegPartEntries
    {

        public virtual BPV_TibiaEntry BPV_TibiaEntry1 { get; set; }
        public virtual BPV_TibiaEntry BPV_TibiaEntry2 { get; set; }
        public virtual BPV_TibiaEntry BPV_TibiaEntry3 { get; set; }
        public virtual BPV_TibiaEntry BPV_TibiaEntry4 { get; set; }
     

        public override int EntryId1 { get; set; }
        public override int EntryId2 { get; set; }
        public override int EntryId3 { get; set; }
        public override int EntryId4 { get; set; }
         }
}
