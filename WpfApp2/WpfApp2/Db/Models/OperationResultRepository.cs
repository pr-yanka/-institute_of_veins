
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //[Table("итоги_операции")]
    [Table("operation_result")]
    public class OperationResult
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("description")]
        public string Str { set; get; }
        [Column("date")]
        public DateTime? Date { set; get; }
        [Column("id_next_operation")]
        public int? IdNextOperation { set; get; }
    }
    public class OperationResultRepository : Repository<OperationResult>
    {
        public OperationResultRepository(DbContext context) : base(context)
        {

        }
    }

}
