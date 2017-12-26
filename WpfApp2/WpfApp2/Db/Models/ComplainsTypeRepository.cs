using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("виды_жалоб")]
    public class ComplainsType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("описание")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }

    public class ComplainsTypeRepository : Repository<ComplainsType>
    {
        public ComplainsTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
