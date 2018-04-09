
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
    [Table("drug_intolerance_patient")]
    //[Table("непереносимость_припаратов_пациента")]
    public class PreparateHatePatients
    {
        [Column(Order = 0), Key]
        public int id_patient { set; get; }
        [Column(Order = 1), Key]
        public int id_drug { set; get; }
        //   public int id_припарат { set; get; }
        [Column(Order = 2)]
        public string comment { set; get; }



    }
    public class PreparateHatePatientsRepository : Repository<PreparateHatePatients>
    {
        public PreparateHatePatientsRepository(DbContext context) : base(context)
        {

        }
    }

}