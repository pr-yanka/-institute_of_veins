
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("pathology")]
    public class Patology
    {
        [Column("id"), Key]
        public int id { set; get; }
        [Column("id_pathology")]
        public int id_патологии { set; get; }
        [Column("id_patient")]
        public int id_пациента { set; get; }
        [Column("is_archivated")]
        public bool isArchivatied { set; get; }
        //[Column("месяц_появления")]
        [Column("appearing_month")]
        public DateTime? MonthAppear { set; get; }
        // [Column("месяц_исчезнование")]
        [Column("disappearing_month")]
        public DateTime? MonthDisappear { set; get; }
        [Column("disappearing_year")]
        public DateTime? YearDisappear { set; get; }
        [Column("appearing_year")]
        public DateTime? YearAppear { set; get; }

    }
    public class PatologyRepository : Repository<Patology>
    {
        public PatologyRepository(DbContext context) : base(context)
        {

        }
    }

}
