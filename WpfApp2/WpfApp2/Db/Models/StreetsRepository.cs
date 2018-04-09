
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("street_dictionary")]
    //[Table("справочник_улицы")]
    public class Streets
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }
        [Column("city")]
        public int IdCity { set; get; }
        public override string ToString()
        {
            return Str;
        }
    }
    public class StreetsRepository : Repository<Streets>
    {
        public StreetsRepository(DbContext context) : base(context)
        {

        }
    }

}
