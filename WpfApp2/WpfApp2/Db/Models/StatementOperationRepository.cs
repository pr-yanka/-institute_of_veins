
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
    // [Table("выписка_операция")]
    [Table("statement_operation")]
    public class StatementOperation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("document")]
        public Byte[] DocTemplate { set; get; }

        [Column("first_leg")]
        public int FirstIsRightIfNull { set; get; }

        [Column("days_count")]
        public int CountDays { set; get; }

        [Column("id_doctor")]
        public int DoctorId { set; get; }

    }

    public class StatementOperationRepository : Repository<StatementOperation>
    {
        public StatementOperationRepository(DbContext context) : base(context)
        {

        }
    }
}