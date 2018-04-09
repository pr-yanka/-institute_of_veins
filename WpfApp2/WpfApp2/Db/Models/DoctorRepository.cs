
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
    //[Table("врачи")]
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
                
        [Column("name")]
        public string Name { set; get; }
              
        [Column("surname")]
        public string Sirname { set; get; }

        [Column("patronimic")]
        public string Patronimic { set; get; }

        [Column("additional_Information")]
        public string Aditional { set; get; }
        [Column("enabled/disabled")]
        public bool? isEnabled { set; get; }

        [Column("category")]
        public int? категория { set; get; }


    
        //[Column("id_категории")]
        //public int CategoryId { set; get; }

        //[Column("id_звания")]
        //public int RankId  { set; get; }



    }
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(DbContext context) : base(context)
        {

        }
    }
  
}