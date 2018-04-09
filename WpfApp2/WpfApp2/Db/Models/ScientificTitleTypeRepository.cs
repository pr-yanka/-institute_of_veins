
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{

    //[Table("виды_научных_званий")]
    [Table("academic_title_types_dictionary")]
    public class ScientificTitleType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }

    }
    public class ScientificTitleTypeRepository : Repository<ScientificTitleType>
    {
        public ScientificTitleTypeRepository(DbContext context) : base(context)
        {

        }
    }

}
