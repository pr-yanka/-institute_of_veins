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
        public bool HasSize { get; set; }

        [Column("id_метрики")]
        public int? Size { get; set; }
        [Required]
        [Column("уровень_вложенности")]
        public int Level { get; set; }

        public override string ToString()
        {
            return Text1 + " " + Size + " " + Text2;
        }
    }

    public abstract class LegPartStructure
    {
        private LegPartDbStructure _structure;

        public LegPartStructure(LegPartDbStructure structure)
        {
            _structure = structure;
        }

        public int Id { get { return _structure.Id; } set { _structure.Id = value; } }
        public string Text1 { get { return _structure.Text1; } set { _structure.Text1 = value; } }
        public string Text2 { get { return _structure.Text2; } set { _structure.Text2 = value; } }
        public bool HasSize { get {return _structure.HasSize; } set { _structure.HasSize = value; } }
        public int Level { get { return _structure.Level; } set { _structure.Level = value; } }
        public string Metrics { get; set; }

        public override string ToString()
        {
            return Text1 + " " + Metrics + " " + Text2;
        }
    }
}
