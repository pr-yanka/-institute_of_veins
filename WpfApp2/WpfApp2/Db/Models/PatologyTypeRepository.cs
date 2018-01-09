using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("виды_патологий")]
    public class PatologyType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("описание")]
        public string Str { set; get; }
    }

    public class PatologyTypeRepository : Repository<PatologyType>
    {
        public PatologyTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
