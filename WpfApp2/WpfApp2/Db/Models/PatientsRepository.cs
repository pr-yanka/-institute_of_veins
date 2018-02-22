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
    [Table("пациент")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Required]
        [Column("имя")]
        public string Name { set; get; }

        [Required]
        [Column("фамилия")]
        public string Sirname { set; get; }

        [Required]
        [Column("отчество")]
        public string Patronimic { set; get; }

        [Required]
        [Column("пол")]
        public string Gender { set; get; }

        [Required]
        [Column("дата_рождения")]
        public DateTime Birthday { set; get; }

        [Required]
        [Column("область_проживания")]
        public int Region { set; get; }


  
        [Column("место_работы")]
        public string Work { set; get; }


        [Column("район_проживания")]
        public int? District { set; get; }

        [Required]
        [Column("город_проживания")]
        public int City { set; get; }

        [Required]
        [Column("улица_проживания")]
        public int Street
        {
            set;
            get;
        }

        [Required]
        [Column("номер_дома")]
        public string House { set; get; }

     
        [Column("номер_квартиры")]
        public int? Flat { set; get; }

        [Required]
        [Column("телефон")]
        public string Phone { set; get; }

        [Column("электронная_почта")]
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
