using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace WpfApp2.Db.Models
{

    // [Table("вид_диагноз")]
    [Table("diagnosis_types_dictionary")]
    public class DiagnosisType
    {
        [Key]
        [Column("id_type")]
        public int Id { set; get; }
        [Column("description")]
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
            dbContext.Set<DiagnosisType>();
        }
    }
}
