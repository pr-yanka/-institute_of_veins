
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("световод")]
    public class Svetovod
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
    public class SvetovodRepository : Repository<Svetovod>
    {
        public SvetovodRepository(DbContext context) : base(context)
        {

        }
    }

}
