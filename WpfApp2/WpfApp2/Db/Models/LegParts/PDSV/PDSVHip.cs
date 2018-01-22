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
    public class PDSVHip
    {

    }

    [Table("пдсв_структура")]
    public partial class PDSVHipStructure : LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<PDSVHipCombo> PDSVs1 { get; set; } = new HashSet<PDSVHipCombo>();
        public virtual ICollection<PDSVHipCombo> PDSVs2 { get; set; } = new HashSet<PDSVHipCombo>();
        public virtual ICollection<PDSVHipCombo> PDSVs3 { get; set; } = new HashSet<PDSVHipCombo>();

        public virtual ICollection<PDSVHipEntry> Entries { get; set; } = new HashSet<PDSVHipEntry>();
    }

    [Table("пдсв_комбо")]
    public partial class PDSVHipCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual PDSVHipStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual PDSVHipStructure Str2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
        public virtual PDSVHipStructure Str3 { get; set; }


        public override string ToString()
        {
            return Str1.ToString();
        }
    }

    /*
    public class PDSVHipStructureRepository : IRepository<PDSVHipStructure>
    {
        private PDSVHipContext _context;

        public PDSVHipStructureRepository()
        {
            _context = new PDSVHipContext();

        }
        public IEnumerable<PDSVHipStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(PDSVHipStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(PDSVHipStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(PDSVHipStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public PDSVHipStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/
    [Table("пдсв_подзапись")]
    public class PDSVHipEntry : LegPartEntry, ILegPart
    {

        [Column("метрика")]
        public override float Size { get; set; }
        [NotMapped]
        public override float Size2 { get; set; }

        public virtual PDSVHipStructure Structure { get; set; }

        public virtual ICollection<PDSVHipEntryFull> EntriesFull1 { get; set; } = new HashSet<PDSVHipEntryFull>();
        public virtual ICollection<PDSVHipEntryFull> EntriesFull2 { get; set; } = new HashSet<PDSVHipEntryFull>();
        public virtual ICollection<PDSVHipEntryFull> EntriesFull3 { get; set; } = new HashSet<PDSVHipEntryFull>();

    }

    [Table("вид_пдсв_хода")]
    public class PDSVHipWay : da_Way
    {

        public virtual ICollection<PDSVHipEntryFull> EntriesFull { get; set; } = new HashSet<PDSVHipEntryFull>();

    }

    [Table("передняя_добавочная_сафенная_вена")]
    public class PDSVHipEntryFull : LegPartEntries
    {
        public virtual PDSVHipWay PDSVHipWay { get; set; }
        public virtual PDSVHipEntry PDSVHipEntry1 { get; set; }
        public virtual PDSVHipEntry PDSVHipEntry2 { get; set; }
        public virtual PDSVHipEntry PDSVHipEntry3 { get; set; }


        public override int WayID { get; set; }

        public override int EntryId1 { get; set; }
        public override int EntryId2 { get; set; }
        public override int EntryId3 { get; set; }

    }
}
