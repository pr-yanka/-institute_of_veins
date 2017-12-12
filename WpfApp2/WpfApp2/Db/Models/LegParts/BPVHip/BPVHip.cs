using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    public class BPVHip
    {

    }

    [Table("БПВ_на_бедре_структура")]
    public partial class BPVHipStructure :LegPartStructure, ILegPart
    {
        
    }

    [Table("БПВ_на_бедре_комбо")]
    public partial class BPVHipCombo : ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }

        [Column("структура4")]
        public int? IdStr4 { get; set; }

        [Column("структура5")]
        public int? IdStr5 { get; set; }
    }

    /*
    public class BPVHipStructureRepository : IRepository<BPVHipStructure>
    {
        private BPVHipContext _context;

        public BPVHipStructureRepository()
        {
            _context = new BPVHipContext();

        }
        public IEnumerable<BPVHipStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(BPVHipStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(BPVHipStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(BPVHipStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public BPVHipStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/

    public class BPVHipEntry : LegPartEntry
    {
        
    }
        
    public class BPVHipWay
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BPVHipEntryFull : LegPartEntries
    {
        public int Id { get; set; }
        public int BPVHipWayID { get; set; }
        public int BPVHipEntryId3 { get; set; }
        public int BPVHipEntryId4 { get; set; }
        public int BPVHipEntryId5 { get; set; }
    }
}
