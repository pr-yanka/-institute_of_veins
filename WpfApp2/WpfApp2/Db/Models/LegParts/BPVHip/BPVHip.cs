using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;
using System.Data.Entity;
using WpfApp2.Db.Models.BPV;

namespace WpfApp2.Db.Models
{
    [Table("БПВ_на_бедре_структура")]
    public partial class BPVHipStructure : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Text1 { get; set; }
        [Required]
        public string Text2 { get; set; }
        [Required]
        public bool HasSize { get; set; }
        [Required]
        public float Size { get; set; }
        [Required]
        public int Level { get; set; }
    }

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
                return _context.Structures;
            }

        }

        public void Add(BPVHipStructure entity)
        {
            _context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(BPVHipStructure entity)
        {
            _context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(BPVHipStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public BPVHipStructure FindById(int Id)
        {
            var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            return result;
        }

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
