
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
    // [Table("обследование")]
    [Table("saved_examination")]
    public class SavedExamination
    {
        [Key]
        [Column("id")]
        public int? Id { set; get; }
        [Column("id_patient")]
        public int? PatientId { set; get; }
        [Column("examination_date")]
        public DateTime? Date { set; get; }
        //  [Column("вес")]
        [Column("weight")]
        public float weight { set; get; }

        //[Column("рост")]
        [Column("height")]
        public float height { set; get; }
        //[Column("id_обследования_правой_ноги")]
        [Column("id_examination_right_leg")]
        public int? idRightLegExamination { set; get; }
        //[Column("id_обследования_левой_ноги")]
        [Column("id_examination_left_leg")]
        public int? idLeftLegExamination { set; get; }
        [Column("id_doctor")]
        public int? DoctorID { set; get; }
        [Column("NB!")]
        public string NB { set; get; }
        //statementOverviewId
        //[Column("id_заключения")]
        [Column("id_conclusion")]
        public int? statementOverviewId { set; get; }
        //  [Column("id_осмотра")]
        [Column("id_overview")]
        public int? hirurgOverviewId { set; get; }
        // [Column("нужна_операция")]
        [Column("need_operation")]
        public bool? isNeedOperation { set; get; }
        //[Column("вид_операции")]
        [Column("operation_type")]
        public int? OperationType { set; get; }
        //[Column("комментарий_к_операции")]
        [Column("comment_operation")]
        public string Comment { set; get; }
        [Column("id_current_examination")]
        public int? id_current_examination { set; get; }

    }
    public class SavedExaminationRepository : Repository<SavedExamination>
    {
        public SavedExaminationRepository(DbContext context) : base(context)
        {

        }
    }

}