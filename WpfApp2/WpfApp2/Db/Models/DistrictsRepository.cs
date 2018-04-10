
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //[Table("справочник_районы")]
    [Table("district_dictionary")]
    public class Districts
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
    public class DistrictsRepository : Repository<Districts>
    {
 
        public DistrictsRepository(DbContext context) : base(context)
        {

        }
    }

}
