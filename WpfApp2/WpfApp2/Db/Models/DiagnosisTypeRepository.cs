using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace WpfApp2.Db.Models
{
    [Table("вид_диагноз")]
    public class DiagnosisType
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

    public class DiagnosisTypeRepository : Repository<DiagnosisType>
    {
        public DiagnosisTypeRepository(DbContext context) : base(context)
        {
          
        }
    }
}
