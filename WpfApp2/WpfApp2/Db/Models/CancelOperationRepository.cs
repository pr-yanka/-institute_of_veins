
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("отмена_операции")]
    public class CancelOperation { 
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("дата_переноса")]
        public DateTime TransferDate { set; get; }
        [Column("причина"),ForeignKey("ReasonCancle")]
        public int Reason { set; get; }
        [Column("операция_отменена")]
        public bool isCancled { set; get; }
        public virtual ReasonsOfCancleOperation ReasonCancle { get; set; }
    }
    public class CancelOperationRepository : Repository<CancelOperation>
    {
        public CancelOperationRepository(DbContext context) : base(context)
        {

        }
    }

}
