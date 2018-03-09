
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("склезирование")]
    public class Sclezing
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("название")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }
    public class SclezingRepository : Repository<Sclezing>
    {
        public SclezingRepository(DbContext context) : base(context)
        {

        }
    }

}
