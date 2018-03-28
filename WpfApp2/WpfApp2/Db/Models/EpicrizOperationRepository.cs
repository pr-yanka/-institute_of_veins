
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
    [Table("епикриз_операция")]
    public class EpicrizOperation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("Документ")]
        public Byte[] DocTemplate { set; get; }

        //[Column("Первая_нога")]
        //public int FirstIsRightIfNull { set; get; }

        [Column("Количество_дней")]
        public int CountDays { set; get; }

        [Column("id_антикоагулянта")]
        public int? AnticogulantId { set; get; }
        [Column("id_склезирование")]
        public int? SclezingId { set; get; }


        [Column("ЭВЛ_ВТ")]
        public float VT { set; get; }


        [Column("ЭВЛ_ДЖСМ")]
        public float DJSM { set; get; }

        [Column("id_врача")]
        public int DoctorId { set; get; }

        [Column("Световод")]
        public string Light { set; get; }
        [Column("Комментарий")]
        public string Commentary { set; get; }
    }

    public class EpicrizOperationRepository : Repository<EpicrizOperation>
    {
        public EpicrizOperationRepository(DbContext context) : base(context)
        {

        }
    }
}