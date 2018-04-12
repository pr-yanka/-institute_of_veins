
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
    //[Table("обследование_ноги")]
    [Table("saved_examination_leg")]
    public class SavedExaminationLeg
    {
        [Key]
        [Column("id_examination_saved")]
        public int Id { set; get; }
        //[Column("id_СФС")]
        [Column("id_SFS")]
        public int? SFSid { set; get; }
        [Column("id_BPV_on_hip")]
        //    [Column("id_БПВ_на_бедре")]
        public int? BPVHip { set; get; }
        [Column("id_PDSV")]
        //[Column("id_ПДСВ")]
        public int? PDSVid { set; get; }
        [Column("id_ZDSV")]
        //[Column("id_ЗДСВ")]
        public int? ZDSVid { set; get; }
        [Column("id_perforate_hip")]
        //[Column("id_перфоранты_бедра")]
        public int? PerforateHipid { set; get; }
        [Column("id_BPV_on_shin")]
        //[Column("id_БПВ_на_голени")]
        public int? BPVTibiaid { set; get; }
        [Column("id_tibia_perforate")]
       // [Column("id_перфорант_голени")]
        public int? TibiaPerforateid { set; get; }
    //    [Column("id_СПС")]
        [Column("id_SPS")]
        public int? SPSid { set; get; }
       // [Column("id_МПВ")]
        [Column("id_MPV")]
        public int? MPVid { set; get; }
        //[Column("id_ТЕ_МПВ")]
        [Column("id_TE_MPV")]
        public int? TEMPVid { set; get; }
       // [Column("id_ППВ")]
        [Column("id_PPV")]
        public int? PPVid { set; get; }


       // [Column("Примечание")]
        [Column("note")]
        public string additionalText { set; get; }
        [Column("id_deep_veins")]
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
    public class SavedExaminationLegRepository : Repository<SavedExaminationLeg>
    {
        public SavedExaminationLegRepository(DbContext context) : base(context)
        {

        }
    }
  
}