using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    //[Table("program_version")]
    [Table("program_version")]
    public class ProgramVersion
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("version")]
        public int Version { set; get; }
    }

    public class ProgramVersionRepository : Repository<ProgramVersion>
    {
        public ProgramVersionRepository(DbContext context) : base(context)
        {

        }
    }
}