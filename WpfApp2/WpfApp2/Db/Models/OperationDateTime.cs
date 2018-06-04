
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("operation_date_time")]
    public class OperationDateTime
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        
        [Column("datetime")]
        public DateTime Datetime { set; get; }

        [Column("operation_id")]
        public int? Operation_id { set; get; }
        [Column("note")]
        public string Note { set; get; }
        //[Column("patient_id")]
        //public int Patient_id { set; get; }

        [Column("doctor_id")]
        public int? Doctor_id { set; get; }

    }

    public class OperationDateTimeRepository : Repository<OperationDateTime>
    {
        public OperationDateTimeRepository(DbContext context) : base(context)
        {

        }
    }
}