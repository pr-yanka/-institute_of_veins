
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
    [Table("обследование_ноги")]
    public class ExaminationLeg
    {
        [Key]
        [Column("id_обследования")]
        public int Id { set; get; }
        [Column("id_СФС")]
        public int? SFSid { set; get; }
        [Column("id_БПВ_на_бедре")]
        public int? BPVHip { set; get; }
        [Column("id_ПДСВ")]
        public int? PDSVid { set; get; }
        [Column("id_ЗДСВ")]
        public int? ZDSVid { set; get; }
        [Column("id_перфоранты_бедра")]
        public int? PerforateHipid { set; get; }
        [Column("id_БПВ_на_голени")]
        public int? BPVTibiaid { set; get; }
        [Column("id_перфорант_голени")]
        public int? TibiaPerforateid { set; get; }
        [Column("id_СПС")]
        public int? SPSid { set; get; }

        [Column("id_МПВ")]
        public int? MPVid { set; get; }
        [Column("id_ТЕ_МПВ")]
        public int? TEMPVid { set; get; }
        [Column("id_ППВ")]
        public int? PPVid { set; get; }


        [Column("Примечание")]
        public string additionalText { set; get; }
        [Column("id_глубокие_вены")]
        public int? GVid { set; get; }
        
        [Column(Order = 0), ForeignKey("Cs")]
        public int? C { set; get; }
        [Column(Order = 1), ForeignKey("Es")]
        public int? E { set; get; }
        [Column(Order = 2), ForeignKey("As")]
        public int? A { set; get; }
        [Column(Order = 3), ForeignKey("Ps")]
        public int? P { set; get; }

        public virtual Letters Cs { get; set; }
        public virtual Letters Es { get; set; }
        public virtual Letters As { get; set; }
        public virtual Letters Ps { get; set; }

    }
    public class ExaminationLegRepository : Repository<ExaminationLeg>
    {
        public ExaminationLegRepository(DbContext context) : base(context)
        {

        }
    }
  
}