
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("научные_звания")]
    public class ScientificTitles
    {
       
        [Column(Order = 0),Key,ForeignKey("Doctor")]
        public int id_врача { set; get; }
        [Column(Order = 1), Key, ForeignKey("ScientificTitleType")]
        public int id_звания { set; get; }
        public virtual Doctor Doctor { get; set; }
        public virtual ScientificTitleType ScientificTitleType { get; set; }

    }
    public class ScientificTitlesRepository : Repository<ScientificTitles>
    {
        public ScientificTitlesRepository(DbContext context) : base(context)
        {

        }
    }

}
