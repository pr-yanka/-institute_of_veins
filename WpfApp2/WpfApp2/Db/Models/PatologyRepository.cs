
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("патологии")]
    public class Patology {
        [Column("id"),Key]
        public int id { set; get; }
        [Column("id_патологии")]
        public int id_патологии { set; get; }
        [Column("id_пациента")]
        public int id_пациента { set; get; }
        [Column("архивирована")]
        public bool isArchivatied { set; get; }
        [Column("месяц_появления")]
        public DateTime? MonthAppear { set; get; }
        [Column("месяц_исчезнование")]
        public DateTime? MonthDisappear { set; get; }
        [Column("год_исчезнование")]
        public DateTime? YearDisappear { set; get; }
        [Column("год_появления")]
        public DateTime? YearAppear { set; get; }
     
    }
    public class PatologyRepository : Repository<Patology>
    {
        public PatologyRepository(DbContext context) : base(context)
        {

        }
    }

}
