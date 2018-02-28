using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    [Table("буквы")]
    public class Letters
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("буква")]
        public string Leter { get; set; }

        [Column("хвостик")]
        public string Text1 { get; set; }

        [NotMapped]
        public string NameContext { get { return Text1; } set { } }



        public override string ToString()
        {
            return Text1;
        }


    }
    public class LettersRepository : Repository<Letters>
    {
        public LettersRepository(DbContext context) : base(context)
        {

        }
    }
}
