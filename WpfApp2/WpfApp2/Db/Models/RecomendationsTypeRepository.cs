using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{//changes_types_dictionary
 // [Table("виды_рекомендаций")] 
    [Table("recommendations_types_dictionary")]
    public class RecomendationsType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("description")]
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
