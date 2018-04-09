
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //[Table("причины_переноса")]
    [Table("delay_reasons_dictionary")]
    public class ReasonsOfCancelOperation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("reason")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }
    public class ReasonsOfCancelOperationRepository : Repository<ReasonsOfCancelOperation>
    {
        public ReasonsOfCancelOperationRepository(DbContext context) : base(context)
        {

        }
    }

}
