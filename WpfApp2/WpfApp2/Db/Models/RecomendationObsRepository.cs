
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
    [Table("рекомендации")]
    public class RecomendationObs
    {
        [Column(Order = 0), Key, ForeignKey("Examination")]
        public int id_обследования { set; get; }
        [Column(Order = 1), Key, ForeignKey("RecType")]
        public int id_рекомендации { set; get; }
      

        public virtual Examination Examination { get; set; }
        public virtual RecomendationsType RecType { get; set; }
      

    }
    public class RecomendationObsRepository : Repository<RecomendationObs>
    {
        public RecomendationObsRepository(DbContext context) : base(context)
        {

        }
    }
  
}