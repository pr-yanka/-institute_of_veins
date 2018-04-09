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
    public class BPVHip
    {
        
    }

    [Table("bpv_hip_structure")]
    public partial class BPVHipStructure :LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<BPVHipCombo> BPVs1 { get; set; } = new HashSet<BPVHipCombo>();
        public virtual ICollection<BPVHipCombo> BPVs2 { get; set; } = new HashSet<BPVHipCombo>();
        public virtual ICollection<BPVHipCombo> BPVs3 { get; set; } = new HashSet<BPVHipCombo>();
        public virtual ICollection<BPVHipCombo> BPVs4 { get; set; } = new HashSet<BPVHipCombo>();
        public virtual ICollection<BPVHipCombo> BPVs5 { get; set; } = new HashSet<BPVHipCombo>();

        public virtual ICollection<BPVHipEntry> Entries { get; set; } = new HashSet<BPVHipEntry>();
    }

    [Table("bpv_hip_combo")]
   // [Table("БПВ_на_бедре_комбо")]
    public partial class BPVHipCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("structure1")]
        public int IdStr1 { get; set; }

        public virtual BPVHipStructure Str1 { get; set; }

        [Column("structure2")]
        public int? IdStr2 { get; set; }

        public virtual BPVHipStructure Str2 { get; set; }

        [Column("structure3")]
        public int? IdStr3 { get; set; }
        public virtual BPVHipStructure Str3 { get; set; }

        [Column("structure4")]
        public int? IdStr4 { get; set; }
        public virtual BPVHipStructure Str4 { get; set; }

        [Column("structure5")]
        public int? IdStr5 { get; set; }
        public virtual BPVHipStructure Str5 { get; set; }

        public override string ToString()
        {
            return Str1.ToString();
        }   
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

    [Table("bpv_hip_sub_entry")]
   // [Table("БПВ_на_бедре_подзапись")]
    public class BPVHipEntry : LegPartEntry, ILegPart
    {

        [Column("metrics")]
        public override float Size { get; set; }
      
        [NotMapped]
        public override float Size2 { get; set; }
       

        public virtual BPVHipStructure Structure { get; set; }

        public virtual ICollection<BPVHipEntryFull> EntriesFull1 { get; set; } = new HashSet<BPVHipEntryFull>();
        public virtual ICollection<BPVHipEntryFull> EntriesFull2 { get; set; } = new HashSet<BPVHipEntryFull>();
        public virtual ICollection<BPVHipEntryFull> EntriesFull3 { get; set; } = new HashSet<BPVHipEntryFull>();
        public virtual ICollection<BPVHipEntryFull> EntriesFull4 { get; set; } = new HashSet<BPVHipEntryFull>();
        public virtual ICollection<BPVHipEntryFull> EntriesFull5 { get; set; } = new HashSet<BPVHipEntryFull>();

    }
    [Table("bpv_hip_way")]
  // [Table("вид_БПВ_хода")]
    public class BPVHipWay : da_Way
    {
      
        public virtual ICollection<BPVHipEntryFull> EntriesFull { get; set; } = new HashSet<BPVHipEntryFull>();

    }
    [Table("big_saphenous_vein_on_hip")]
   // [Table("большая_подкожная_вена_на_бедре")]
    public class BPVHipEntryFull : LegPartEntries
    {
        public virtual BPVHipWay BPVHipWay { get; set; }
        public virtual BPVHipEntry BPVHipEntry1 { get; set; }
        public virtual BPVHipEntry BPVHipEntry2 { get; set; }
        public virtual BPVHipEntry BPVHipEntry3 { get; set; }
        public virtual BPVHipEntry BPVHipEntry4 { get; set; }
        public virtual BPVHipEntry BPVHipEntry5 { get; set; }

      

      
             
        public override int EntryId1 { get; set; }
        public override int? EntryId2 { get; set; }
        public override int? EntryId3 { get; set; }
        public override int? EntryId4 { get; set; }
        public override int? EntryId5 { get; set; }
       

        [NotMapped]
        public override int? EntryId6 { get; set; }
    }
}
