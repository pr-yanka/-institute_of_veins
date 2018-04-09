
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfApp2.Db.Models
{//blood transfusion patients 
     [Table("blood_transfer_patient")]
    public class BloodExchangePatients
    {
        [Column(Order = 0), Key]
        public int id_transfer { set; get; }
        [Column(Order = 1), Key]
        public int id_patient { set; get; }
        [Column(Order = 2)]
        public string comment { set; get; }

      

    }
    public class BloodExchangePatientsRepository : Repository<BloodExchangePatients>
    {
        public BloodExchangePatientsRepository(DbContext context) : base(context)
        {

        }
    }
  
}