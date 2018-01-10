
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("виды_научных_званий")]
    public class ScientificTitleType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("название")]
        public string Str { set; get; }
        
    }
    public class ScientificTitleTypeRepository : Repository<ScientificTitleType>
    {
        public ScientificTitleTypeRepository(DbContext context) : base(context)
        {

        }
    }

}
