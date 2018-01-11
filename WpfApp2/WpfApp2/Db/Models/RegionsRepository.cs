
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("справочник_область")]
    public class Regions
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
    public class RegionsRepository : Repository<Regions>
    {
        public RegionsRepository(DbContext context) : base(context)
        {

        }
    }

}
