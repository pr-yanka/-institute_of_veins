
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //  [Table("отмена_операции")]
    [Table("cancel_operations")]
    public class CancelOperation { 
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("transfer_date")]
        public DateTime TransferDate { set; get; }
        [Column("reason"),ForeignKey("ReasonCancle")]
        public int Reason { set; get; }
        // [Column("операция_отменена")]
        [Column("operation_canceled")]
        public bool isCancled { set; get; }
        public virtual ReasonsOfCancelOperation ReasonCancle { get; set; }
    }
    public class CancelOperationRepository : Repository<CancelOperation>
    {
        public CancelOperationRepository(DbContext context) : base(context)
        {

        }
    }

}
