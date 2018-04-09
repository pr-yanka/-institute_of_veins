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
    //  [Table("диагноз")]
    //  diagnosis

    [Table("diagnosis")]
    public class Diagnosis
    {
     
        [Column(Order = 0), Key, ForeignKey("DiagnosisType")]
        public int? id_diagnosis { set; get; }
        [Column(Order = 1), Key, ForeignKey("Operation")]
        public int? id_operation { set; get; }
        [Column(Order = 2), Key]
        public bool isLeft { set; get; }
     
        public virtual DiagnosisType DiagnosisType { get; set; }
        public virtual Operation Operation { get; set; }

    }
    public class DiagnosisRepository : Repository<Diagnosis>
    {
        public DiagnosisRepository(DbContext context) : base(context)
        {

        }
    }
  
}