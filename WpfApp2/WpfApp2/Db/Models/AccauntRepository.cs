using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    //  [Table("аккаунты")]
    [Table("accounts")]
    public class Accaunt
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        //doctor  [Column("врач")]
        [Column("doctor")]
        public bool? isDoctor { set; get; }
        //[Column("админ")]
        [Column("admin")]
        public bool? isAdmin { set; get; }
        [Column("med_staff")]
        //[Column("медперсонал")]
        public bool? isMedPersonal { set; get; }
        //[Column("секретарь")]
        [Column("secretary")]
        public bool? isSecretar { set; get; }
        [Column("enabled/disabled")]
        public bool? isEnabled { set; get; }

        [Column("id_doctor")]
        // [Column("idврач")]
        public int? idврач { set; get; }
        [Column("id_med_staff")]
        //[Column("idмедперсонал")]
        public int? idмедперсонал { set; get; }
        //[Column("имя")]
        [Column("name")]
        public string Name { set; get; }
        [Column("password")]
        //[Column("пароль")]
        public string Password { set; get; }
    }

    public class AccauntRepository : Repository<Accaunt>
    {
        public AccauntRepository(DbContext context) : base(context)
        {

        }
    }
}