
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("причины_переноса")]
    public class ReasonsOfCancleOperation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("причина")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }
    public class ReasonsOfCancleOperationRepository : Repository<ReasonsOfCancleOperation>
    {
        public ReasonsOfCancleOperationRepository(DbContext context) : base(context)
        {

        }
    }

}
