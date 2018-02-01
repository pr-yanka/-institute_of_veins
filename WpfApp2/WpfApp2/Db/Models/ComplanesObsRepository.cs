
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
    [Table("жалобы")]
    public class ComplanesObs
    {
        [Column(Order = 0), Key, ForeignKey("Examination")]
        public int id_обследования { set; get; }
        [Column(Order = 1), Key, ForeignKey("CompType")]
        public int id_жалобы { set; get; }
      

        public virtual Examination Examination { get; set; }
        public virtual ComplainsType CompType { get; set; }
      

    }
    public class ComplanesObsRepository : Repository<ComplanesObs>
    {
        public ComplanesObsRepository(DbContext context) : base(context)
        {

        }
    }
  
}