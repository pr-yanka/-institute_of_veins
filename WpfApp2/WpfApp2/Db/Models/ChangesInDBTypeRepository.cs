

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{//[Table("виды_изменений")]
    [Table("changes_types_dictionary")]
    public class ChangesInDBType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }

    public class ChangesInDBTypeRepository : Repository<ChangesInDBType>
    {
        public ChangesInDBTypeRepository(DbContext context) : base(context)
        {
            //dbContext.Set<DiagnosisType>();
        }
    }
}
