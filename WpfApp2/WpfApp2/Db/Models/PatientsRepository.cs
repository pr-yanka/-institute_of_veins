using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    [Table("patient")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

     
        [Column("blood_group")]
        public string BloodGroup { set; get; }
        [Column("diabetes")]
        public string Sugar { set; get; }
        [Column("is_positive_blood_group")]
        public bool? IsPositiveGroupType { set; get; }

        [Column("outpatient_card_document_id")]
        public int? Амбулаторная_карта_документ_id { set; get; }


        [Required]
        [Column("name")]
        public string Name { set; get; }

        [Required]
        [Column("surname")]
        public string Sirname { set; get; }

        [Required]
        [Column("patronimic")]
        public string Patronimic { set; get; }

        [Required]
        [Column("gender")]
        public string Gender { set; get; }

        [Required]
        [Column("birthday")]
        public DateTime Birthday { set; get; }

        [Required]
        //[Column("область_проживания")]
        [Column("region")]
        public int Region { set; get; }


        //  [Column("место_работы")]
        [Column("work")]
        public string Work { set; get; }


        //[Column("район_проживания")]
        [Column("district")]
        public int? District { set; get; }

        [Required]
        //[Column("город_проживания")]
        [Column("city")]
        public int City { set; get; }

        [Required]
        //[Column("улица_проживания")]
        [Column("street")]
        public int Street
        {
            set;
            get;
        }

        [Required]
       // [Column("номер_дома")]
        [Column("house_number")]
        public string House { set; get; }

     
        [Column("flat_number")]
        public int? Flat { set; get; }

        [Required]
        [Column("phone")]
        public string Phone { set; get; }

        [Column("email")]
        public string Email { set; get; }

        [NotMapped]
        public int Age {
            get { return DateTime.Now.Year - Birthday.Year; }
        }
    }

    public class PatientsRepository : Repository<Patient>
    {
        public PatientsRepository(DbContext context) : base(context)
        {
            
        }
    }
}
