
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfApp2.Db.Models
{
    [Table("операции")]
    public class Operation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("id_пациента")]
        public int PatientId { set; get; }
        [Column("дата_операции")]
        public DateTime Date { set; get; }
        [Column("время_операции")]
        public string Time { set; get; }
        [Column("на_какую_ногу_операция")]
        public string OnWhatLegOp { set; get; }
        [Column("id_вида_анестетика")]
        public int AnestheticId { set; get; }
        [Column("NB!")]
        public string NB { set; get; }
        [Column(Order = 0), ForeignKey("OpCancle")]
        public int? отмена_операции { set; get; }
        [Column(Order = 1), ForeignKey("OpResult")]
        public int? итоги_операции { set; get; }
        [Column("id_выписки")]
        public int? StatementId { set; get; }
        //StatementId
        public virtual OperationResult OpResult { get; set; }
        public virtual CancelOperation OpCancle { get; set; }

    }
    public class OperationRepository : Repository<Operation>
    {
        public OperationRepository(DbContext context) : base(context)
        {

        }
    }
  
}