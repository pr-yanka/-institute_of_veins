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
    [Table("анализы")]
    public class Analize
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("тип_анализа")]
        public int analyzeType { set; get; }
        [Column("дата")]
        public DateTime data { set; get; }
        [Column("id_пациента")]
        public int patientId { set; get; }
        [Column("анализ")]
        public Byte[] ImageByte { set; get; }
    }
    public class AnalizeRepository : Repository<Analize>
    {


        public AnalizeRepository(DbContext context) : base(context)
        {

        }

    }

}
