
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //[Table("виды_специализаций")]
    [Table("specialization_types_dictionary")]
    public class SpecializationType
    {
        [Key]
        [Column("id")]
        public int id_специлизации { set; get; }
        [Column("name")]
        public string Str { set; get; }
        
    }
    public class SpecializationTypeRepository : Repository<SpecializationType>
    {
        public SpecializationTypeRepository(DbContext context) : base(context)
        {

        }
    }

}
