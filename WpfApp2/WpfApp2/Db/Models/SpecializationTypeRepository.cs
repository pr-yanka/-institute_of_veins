
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("виды_специализаций")]
    public class SpecializationType
    {
        [Key]
        [Column("id")]
        public int id_специлизации { set; get; }
        [Column("название")]
        public string Str { set; get; }
        
    }
    public class SpecializationTypeRepository : Repository<SpecializationType>
    {
        public SpecializationTypeRepository(DbContext context) : base(context)
        {

        }
    }

}
