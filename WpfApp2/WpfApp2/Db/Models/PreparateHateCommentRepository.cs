using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace WpfApp2.Db.Models
{
    //[Table("коментарий_к_непереносимости")]
    [Table("comment_on_intolerance")]

    public class PreparateHateComment
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("comment")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }

    public class PreparateHateCommentRepository : Repository<PreparateHateComment>
    {
        public PreparateHateCommentRepository(DbContext context) : base(context)
        {
            dbContext.Set<DiagnosisType>();
        }
    }
}
