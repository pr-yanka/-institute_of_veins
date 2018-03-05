
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
    [Table("алергологичный_анамнез_пациенты")]
    public class AlergicAnevrizmPatients
    {
        [Column(Order = 0), Key]
        public int id_анамнеза { set; get; }
        [Column(Order = 1), Key]
        public int id_пациента { set; get; }
     

      

    }
    public class AlergicAnevrizmPatientsRepository : Repository<AlergicAnevrizmPatients>
    {
        public AlergicAnevrizmPatientsRepository(DbContext context) : base(context)
        {

        }
    }
  
}