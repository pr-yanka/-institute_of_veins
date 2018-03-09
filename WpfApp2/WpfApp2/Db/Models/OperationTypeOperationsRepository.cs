using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("тип_операции_для_операции")]
    public class OperationTypeOperations
    {
        [Column(Order = 0), Key, ForeignKey("OperationType")]
        public int? id_типОперации { set; get; }
        [Column(Order = 1), Key, ForeignKey("Operation")]
        public int? id_операции { set; get; }
        [Column(Order = 2), Key]
        public bool isLeft { set; get; }

        public virtual OperationType OperationType { get; set; }
        public virtual Operation Operation { get; set; }

    }
    public class OperationTypeOperationsRepository : Repository<OperationTypeOperations>
    {
        public OperationTypeOperationsRepository(DbContext context) : base(context)
        {

        }
    }
  
}