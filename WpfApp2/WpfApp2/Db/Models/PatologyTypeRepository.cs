using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("pathology_types_dictionary")]
    public class PatologyType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("description")]
        public string Str { set; get; }
    }

    public class PatologyTypeRepository : Repository<PatologyType>
    {
        public PatologyTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
