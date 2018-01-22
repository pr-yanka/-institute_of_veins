﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    public class Perforate_hip
    {
        
    }

    [Table("перфорант_бедро_структура")]
    public partial class Perforate_hipStructure :LegPartDbStructure, ILegPart
    {
        [NotMapped]
        public override bool HasDoubleMetric { get { return false; } }

        public virtual ICollection<Perforate_hipCombo> BPVs1 { get; set; } = new HashSet<Perforate_hipCombo>();
        public virtual ICollection<Perforate_hipCombo> BPVs2 { get; set; } = new HashSet<Perforate_hipCombo>();
        public virtual ICollection<Perforate_hipCombo> BPVs3 { get; set; } = new HashSet<Perforate_hipCombo>();
        public virtual ICollection<Perforate_hipCombo> BPVs4 { get; set; } = new HashSet<Perforate_hipCombo>();
        public virtual ICollection<Perforate_hipCombo> BPVs5 { get; set; } = new HashSet<Perforate_hipCombo>();

        public virtual ICollection<Perforate_hipEntry> Entries { get; set; } = new HashSet<Perforate_hipEntry>();
    }

    [Table("перфорант_бедро_комбо")]
    public partial class Perforate_hipCombo : LegPartCombo, ILegPart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("структура1")]
        public int IdStr1 { get; set; }

        public virtual Perforate_hipStructure Str1 { get; set; }

        [Column("структура2")]
        public int? IdStr2 { get; set; }

        public virtual Perforate_hipStructure Str2 { get; set; }

        [Column("структура3")]
        public int? IdStr3 { get; set; }
        public virtual Perforate_hipStructure Str3 { get; set; }

        [Column("структура4")]
        public int? IdStr4 { get; set; }
        public virtual Perforate_hipStructure Str4 { get; set; }

        [Column("структура5")]
        public int? IdStr5 { get; set; }
        public virtual Perforate_hipStructure Str5 { get; set; }

        public override string ToString()
        {
            return Str1.ToString();
        }   
    }

    /*
    public class Perforate_hipStructureRepository : IRepository<Perforate_hipStructure>
    {
        private Perforate_hipContext _context;

        public Perforate_hipStructureRepository()
        {
            _context = new Perforate_hipContext();

        }
        public IEnumerable<Perforate_hipStructure> List
        {
            get
            {
                //yield return _context.Structures;
                return null;
            }

        }

        public void Add(Perforate_hipStructure entity)
        {
            //_context.Structures.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Perforate_hipStructure entity)
        {
            //_context.Structures.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Perforate_hipStructure entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public Perforate_hipStructure FindById(int Id)
        {
            //var result = (from r in _context.Structures where r.Id == Id select r).FirstOrDefault();
            //return result;
            return null;
        }
    }*/
    [Table("перфорант_бедро_подзапись")]
    public class Perforate_hipEntry : LegPartEntry, ILegPart
    {

        [Column("метрика")]
        public override float Size { get; set; }

        public virtual Perforate_hipStructure Structure { get; set; }

        public virtual ICollection<Perforate_hipEntryFull> EntriesFull1 { get; set; } = new HashSet<Perforate_hipEntryFull>();
        public virtual ICollection<Perforate_hipEntryFull> EntriesFull2 { get; set; } = new HashSet<Perforate_hipEntryFull>();
        public virtual ICollection<Perforate_hipEntryFull> EntriesFull3 { get; set; } = new HashSet<Perforate_hipEntryFull>();
        public virtual ICollection<Perforate_hipEntryFull> EntriesFull4 { get; set; } = new HashSet<Perforate_hipEntryFull>();
        public virtual ICollection<Perforate_hipEntryFull> EntriesFull5 { get; set; } = new HashSet<Perforate_hipEntryFull>();

    }



    [Table("перфорант_бедра_и_несафенные_вены")]
    public class Perforate_hipEntryFull : LegPartEntries
    {

        public virtual Perforate_hipEntry Perforate_hipEntry1 { get; set; }
        public virtual Perforate_hipEntry Perforate_hipEntry2 { get; set; }
        public virtual Perforate_hipEntry Perforate_hipEntry3 { get; set; }
        public virtual Perforate_hipEntry Perforate_hipEntry4 { get; set; }
        public virtual Perforate_hipEntry Perforate_hipEntry5 { get; set; }
        public int Id { get; set; }



        public int Perforate_hipEntryId1 { get; set; }
        public int Perforate_hipEntryId2 { get; set; }
        public int Perforate_hipEntryId3 { get; set; }
        public int Perforate_hipEntryId4 { get; set; }
        public int Perforate_hipEntryId5 { get; set; }
    }
}