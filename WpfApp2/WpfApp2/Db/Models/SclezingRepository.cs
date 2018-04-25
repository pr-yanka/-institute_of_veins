
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //  [Table("склерозирование")]
    [Table("hardening")]
    //
    public class Sclezing
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }
        [Column("ml")]
        public float? Ml { set; get; }
        [Column("percentages")]
        // [Column("проценты")]
        public float? Prcent { set; get; }

        //    [Column("вещества")]
        [Column("substance")]
        public string Veshestvo { set; get; }

        public override string ToString()
        {
            if(string.IsNullOrWhiteSpace(Str))
            { return ""; }

            return Str + " " + Ml + " мл " + Prcent + " % " + "Вещество : " + Veshestvo;
        }
    }
    public class SclezingRepository : Repository<Sclezing>
    {
        public SclezingRepository(DbContext context) : base(context)
        {

        }
    }

}
