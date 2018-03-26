
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
    [Table("заключения_обследования")]
    public class StatementObs
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("Документ")]
        public Byte[] DocTemplate { set; get; }

      

        //[Column("id_врача")]
        //public int DoctorId { set; get; }

    }

    public class StatementObsRepository : Repository<StatementObs>
    {
        public StatementObsRepository(DbContext context) : base(context)
        {

        }
    }
}