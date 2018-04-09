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
    
    //[Table("анализы")]
    [Table("analyzes")]
    public class Analize
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("analysis_type")]
        public int analyzeType { set; get; }
        [Column("date")]
        public DateTime data { set; get; }
        [Column("id_patient")]
        public int patientId { set; get; }
        [Column("analysis")]
        public Byte[] ImageByte { set; get; }
    }
    public class AnalizeRepository : Repository<Analize>
    {


        public AnalizeRepository(DbContext context) : base(context)
        {

        }

    }

}
