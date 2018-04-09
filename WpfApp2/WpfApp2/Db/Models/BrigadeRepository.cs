
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
    //[Table("бригада")]
    [Table("brigade")]
    public class Brigade
    {
       
        [Column(Order = 0) ,Key, ForeignKey("Doctor")]
        public int? id_doctor { set; get; }
     
        [Column(Order = 1), Key, ForeignKey("Operation")]
        public int? id_operation { set; get; }

        public virtual Doctor Doctor { get; set; }
        public virtual Operation Operation { get; set; }

    }
    public class BrigadeRepository : Repository<Brigade>
    {
        public BrigadeRepository(DbContext context) : base(context)
        {

        }
    }
  
}