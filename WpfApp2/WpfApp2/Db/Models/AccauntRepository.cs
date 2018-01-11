
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
    [Table("аккаунты")]
    public class Accaunt
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("врач")]
        public bool? isDoctor { set; get; }
        [Column("админ")]
        public bool? isAdmin { set; get; }
        [Column("медперсонал")]
        public bool? isMedPersonal { set; get; }
        [Column("секретарь")]
        public bool? isSecretar { set; get; }
        [Column("enabled/disabled")]
        public bool? isEnabled { set; get; }


        [Column("имя")]
        public string Name { set; get; }
        [Column("пароль")]
        public string Password { set; get; }
    }

    public class AccauntRepository : Repository<Accaunt>
    {
        public AccauntRepository(DbContext context) : base(context)
        {

        }
    }
}