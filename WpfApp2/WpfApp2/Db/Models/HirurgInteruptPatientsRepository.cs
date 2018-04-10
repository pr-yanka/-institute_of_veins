
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
    //[Table("хирургическое_вмешательство_пациенты")]
    [Table("surgery_patient")]
    //surgery
    public class HirurgInteruptPatients
    {
        [Column(Order = 0), Key]
        public int id_intervention { set; get; }
        // public int id_вмешательства { set; get; }
        [Column(Order = 1), Key]
        public int id_patient { set; get; }
        //   public int id_пациента { set; get; }



    }
    public class HirurgInteruptPatientsRepository : Repository<HirurgInteruptPatients>
    {
        public HirurgInteruptPatientsRepository(DbContext context) : base(context)
        {

        }
    }

}