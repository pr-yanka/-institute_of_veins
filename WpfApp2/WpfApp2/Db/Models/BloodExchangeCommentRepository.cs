using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace WpfApp2.Db.Models
{
    [Table("коментарий_к_переливанию")]
    public class BloodExchangeComment
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("коментарий")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }

    public class BloodExchangeCommentRepository : Repository<BloodExchangeComment>
    {
        public BloodExchangeCommentRepository(DbContext context) : base(context)
        {
            dbContext.Set<DiagnosisType>();
        }
    }
}
