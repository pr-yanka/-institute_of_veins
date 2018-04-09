
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    // [Table("епикриз_операция")]
    [Table("epicrisis_operation")]
    //epicrisis operation
    public class EpicrizOperation
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("document")]
        public Byte[] DocTemplate { set; get; }

        //[Column("Первая_нога")]
        //public int FirstIsRightIfNull { set; get; }

        //[Column("Количество_дней")]
        [Column("days_count")]
        public int CountDays { set; get; }

        [Column("id_anticoagulant")]
        public int? AnticogulantId { set; get; }

        //[Column("id_склезирование")]
        [Column("id_hardening")]
        public int? SclezingId { set; get; }

        //[Column("ЭВЛ_ВТ")]
        [Column("EVL_VT")]
        public float VT { set; get; }


        // [Column("ЭВЛ_ДЖСМ")]

        [Column("EVL_DJSM")]
        public float DJSM { set; get; }

        [Column("id_doctor")]
        public int DoctorId { set; get; }
        [Column("fiber")]
        //[Column("Световод")]
        //light guide
        public string Light { set; get; }
        [Column("comment")]
        public string Commentary { set; get; }
    }

    public class EpicrizOperationRepository : Repository<EpicrizOperation>
    {
        public EpicrizOperationRepository(DbContext context) : base(context)
        {

        }
    }
}