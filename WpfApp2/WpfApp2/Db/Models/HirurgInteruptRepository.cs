
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
    [Table("хирургическое_вмешательство")]
    public class HirurgInterupt
    {

        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("Название")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }


    }
    public class HirurgInteruptRepository : Repository<HirurgInterupt>
    {
        public HirurgInteruptRepository(DbContext context) : base(context)
        {

        }
    }
  
}