
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
    [Table("бригада_медперсонал")]
    public class BrigadeMedPersonal
    {
       
        [Column(Order = 0) ,Key, ForeignKey("MedPersonal")]
        public int? id_медперсонал { set; get; }
     
        [Column(Order = 1), Key, ForeignKey("Operation")]
        public int? id_операции { set; get; }

        public virtual MedPersonal MedPersonal { get; set; }
        public virtual Operation Operation { get; set; }

    }
    public class BrigadeMedPersonalRepository : Repository<BrigadeMedPersonal>
    {
        public BrigadeMedPersonalRepository(DbContext context) : base(context)
        {

        }
    }
  
}