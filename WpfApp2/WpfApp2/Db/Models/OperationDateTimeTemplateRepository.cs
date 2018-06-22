
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    [Table("operation_date_time_template")]
    public class OperationDateTimeTemplate
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("timeRow")]
        public DateTime TimeRow { set; get; }

      

    }

    public class OperationDateTimeTemplateRepository : Repository<OperationDateTimeTemplate>
    {
        public OperationDateTimeTemplateRepository(DbContext context) : base(context)
        {

        }
    }
}