
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
   // [Table("врачи_специализации")]
    [Table("doctors_specialization")]
    public class DoctorsSpecializations
    {
       
        [Column(Order = 0),Key,ForeignKey("Doctor")]
        public int id_doctor { set; get; }
        [Column(Order = 1), Key, ForeignKey("SpecializationType")]
        public int id_specialization { set; get; }
        public virtual Doctor Doctor { get; set; }
        public virtual SpecializationType SpecializationType { get; set; }

    }
    public class DoctorsSpecializationsRepository : Repository<DoctorsSpecializations>
    {
        public DoctorsSpecializationsRepository(DbContext context) : base(context)
        {

        }
    }

}
