using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("виды_рекомендаций")]
    public class RecomendationsType
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

    public class RecomendationsTypeRepository : Repository<RecomendationsType>
    {
        public RecomendationsTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
