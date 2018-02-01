
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
    [Table("диагноз_обследование")]
    public class DiagnosisObs
    {
        [Column(Order = 0), Key, ForeignKey("Examination")]
        public int? id_обследование_ноги { set; get; }
        [Column(Order = 1), Key, ForeignKey("DiagnosisType")]
        public int? id_диагноз { set; get; }
        [Column(Order = 2), Key]
        public bool isLeft { set; get; }

        public virtual Examination Examination { get; set; }
        public virtual DiagnosisType DiagnosisType { get; set; }
      

    }
    public class DiagnosisObsRepository : Repository<DiagnosisObs>
    {
        public DiagnosisObsRepository(DbContext context) : base(context)
        {

        }
    }
  
}