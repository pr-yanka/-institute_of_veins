
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("вещество")]
    public class Veshestvo
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
    public class VeshestvoRepository : Repository<Veshestvo>
    {
        public VeshestvoRepository(DbContext context) : base(context)
        {

        }
    }

}
