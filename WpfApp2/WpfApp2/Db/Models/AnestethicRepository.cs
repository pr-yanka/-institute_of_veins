
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfApp2.Db.Models
{
   // [Table("виды_анестезика")]
    [Table("anesthesia_dictionary")]
    public class Anestethic
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }
    public class AnestethicRepository : Repository<Anestethic>
    {
        public AnestethicRepository(DbContext context) : base(context)
        {

        }
    }
  
}