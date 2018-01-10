
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
    [Table("медперсонал")]
    public class MedPersonal
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("имя")]
        public string Name { set; get; }
        [Column("фамилия")]
        public string Surname { set; get; }
        [Column("отчество")]
        public string Patronimic { set; get; }
        [Column("enabled/disabled")]
        public bool? isEnabled { set; get; }








    }
    public class MedPersonalRepository : Repository<MedPersonal>
    {
        public MedPersonalRepository(DbContext context) : base(context)
        {

        }
    }

}