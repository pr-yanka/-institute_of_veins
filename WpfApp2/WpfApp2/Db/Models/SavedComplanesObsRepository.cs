
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
  //  [Table("жалобы")] 
    [Table("saved_complains")]
    public class SavedComplanesObs
    {
        [Column(Order = 0), Key, ForeignKey("Examination")]
        public int id_Examination { set; get; }
        [Column(Order = 1), Key, ForeignKey("CompType")]
        public int id_Complains { set; get; }
      

        public virtual Examination Examination { get; set; }
        public virtual ComplainsType CompType { get; set; }
      

    }
    public class SavedComplanesObsRepository : Repository<SavedComplanesObs>
    {
        public SavedComplanesObsRepository(DbContext context) : base(context)
        {

        }
    }
  
}