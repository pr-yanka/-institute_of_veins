using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    public abstract class LegPartDbStructure
    {
        /*
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public bool HasSize { get; set; }
        public string Size { get; set; }
        public int Level { get; set; }*/

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("название1")]
        public string Text1 { get; set; }

        [Column("название2")]
        public string Text2 { get; set; }

        [Required]
        [Column("есть_метрика")]
        public bool HasSize
        {
            get;
            set;
        }

        [Column("id_метрики")]
        public int? Size { get; set; }

        [Required]
        [Column("уровень_вложенности")]
        public int Level { get; set; }

        [NotMapped]
        public string Metrics { get; internal set; }

        [NotMapped]
        public bool Custom { get; internal set; }

        [NotMapped]
        public bool ToNextPart { get; internal set; }

        [NotMapped]
        public virtual bool HasDoubleMetric { get; }

        public override string ToString()
        {
            return Text1 + " " + Metrics + " " + Text2;
        }

        public LegPartDbStructure()
        {
            ToNextPart = false;
            Custom = false;
        }
}
}
