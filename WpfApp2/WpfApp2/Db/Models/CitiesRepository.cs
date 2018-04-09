
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
   // [Table("справочник_города")]
    [Table("city_dictionary")]
    public class Cities
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }
        //Region  [Column("Область")]
        [Column("region")]
        public int OblId { set; get; }


        public override string ToString()
        {
            return Str;
        }
    }
    public class CitiesRepository : Repository<Cities>
    {
        public CitiesRepository(DbContext context) : base(context)
        {

        }
    }

}
