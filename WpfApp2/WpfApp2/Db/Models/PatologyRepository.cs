
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("патологии")]
    public class Patology {

        [Column(Order = 0), Key, ForeignKey("PatologyType")]
        public int id_патологии { set; get; }
        [Column(Order = 1), Key, ForeignKey("Patient")]
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
        public virtual Patient Patient { get; set; }
        public virtual PatologyType PatologyType { get; set; }
    }
    public class PatologyRepository : Repository<Patology>
    {
        public PatologyRepository(DbContext context) : base(context)
        {

        }
    }

}
