
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
    [Table("выписка_операция")]
    public class StatementOperation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("Документ")]
        public Byte[] DocTemplate { set; get; }

        [Column("Первая_нога")]
        public int FirstIsRightIfNull { set; get; }

        [Column("Количество_дней")]
        public int CountDays { set; get; }

        [Column("id_врача")]
        public int DoctorId { set; get; }

    }

    public class StatementOperationRepository : Repository<StatementOperation>
    {
        public StatementOperationRepository(DbContext context) : base(context)
        {

        }
    }
}