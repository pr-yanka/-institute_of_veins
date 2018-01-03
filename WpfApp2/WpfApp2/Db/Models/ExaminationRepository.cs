
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
    [Table("обследование")]
    public class Examination
    {
        [Key]
        [Column("id")]
        public int? Id { set; get; }
        [Column("id_пациента")]
        public int? PatientId { set; get; }
        [Column("дата_обследования")]
        public DateTime Date { set; get; }
        [Column("вес")]
        public float OperationTypeId { set; get; }
        [Column("рост")]
        public float AnestheticId { set; get; }
        [Column("id_обследования_правой_ноги")]
        public int? idRightLegExamination { set; get; }
        [Column("id_обследования_левой_ноги")]
        public int? idLeftLegExamination { set; get; }
        [Column("id_врача")]
        public int? DoctorID { set; get; }
        [Column("NB!")]
        public string NB { set; get; }
        
        [Column("нужна_операция")]
        public bool isNeedOperation { set; get; }
        [Column("вид_операции")]
        public int? OperationType { set; get; }
        [Column("комментарий_к_операции")]
        public string Comment { set; get; }


    }
    public class ExaminationRepository : Repository<Examination>
    {
        public ExaminationRepository(DbContext context) : base(context)
        {

        }
    }
  
}