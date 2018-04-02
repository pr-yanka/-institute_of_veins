
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("итоги_операции")]
    public class OperationResult
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("описание")]
        public string Str { set; get; }
        [Column("дата")]
        public DateTime? Date { set; get; }
        [Column("id_следущей_операции")]
        public int? IdNextOperation { set; get; }
    }
    public class OperationResultRepository : Repository<OperationResult>
    {
        public OperationResultRepository(DbContext context) : base(context)
        {

        }
    }

}
