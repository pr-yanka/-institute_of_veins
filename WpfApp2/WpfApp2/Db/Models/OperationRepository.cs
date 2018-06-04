
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
    [Table("operations")]
    //[Table("операции")]
    public class Operation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("id_patient")]
        public int PatientId { set; get; }

        //  [Column("operation_date")]
        //[NotMapped]
        //public DateTime Date { set; get; }

        ////  [Column("operation_time")]
        //[NotMapped]
        //public string Time { set; get; }

        [Column("datetime_id")]
        public int? Datetime_id { set; get; }
        
        [Column("on_which_leg_operation")]
        public string OnWhatLegOp { set; get; }
        [Column("id_type_anesthetic")]
        public int AnestheticId { set; get; }
        [Column("NB!")]
        public string NB { set; get; }
        [Column(Order = 0), ForeignKey("OpCancle")]
        public int? cancel_operations { set; get; }
        [Column(Order = 1), ForeignKey("OpResult")]
        public int? operation_result { set; get; }
        [Column("id_statement")]
        public int? StatementId { set; get; }
        [Column("id_epicrisis")]
        public int? EpicrizId { set; get; }
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