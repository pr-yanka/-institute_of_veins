using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace WpfApp2.Db.Models
{
    [Table("сахарный_диабет_комментарий")]
    public class SugarDiabetComment
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("название")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }

    public class SugarDiabetCommentRepository : Repository<SugarDiabetComment>
    {
        public SugarDiabetCommentRepository(DbContext context) : base(context)
        {
           
        }
    }
}
