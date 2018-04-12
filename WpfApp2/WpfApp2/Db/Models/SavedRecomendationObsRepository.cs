
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
    [Table("saved_recommendations")] 
    public class SavedRecomendationObs
    {
        [Column(Order = 0), Key, ForeignKey("Examination")]
        public int id_examination { set; get; }
        [Column(Order = 1), Key, ForeignKey("RecType")]
        public int id_recommendations { set; get; }
      

        public virtual Examination Examination { get; set; }
        public virtual RecomendationsType RecType { get; set; }
      

    }
    public class SavedRecomendationObsRepository : Repository<SavedRecomendationObs>
    {
        public SavedRecomendationObsRepository(DbContext context) : base(context)
        {

        }
    }
  
}