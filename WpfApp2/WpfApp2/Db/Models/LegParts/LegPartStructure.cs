using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.Messaging;

namespace WpfApp2.Db.Models
{
    public abstract class LegPartDbStructure : INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [NotMapped]
        private string _text1;

        [Column("название1")]
        public string Text1
        {
            get { return _text1; }
            set { _text1 = value; OnPropertyChanged(); OnPropertyChanged("NameContext"); }
        }
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

        [Column("двойная_метрика")]
        public virtual bool HasDoubleMetric { get; set; }


        [NotMapped]
        public string NameContext { get { return Text1 + " " + Metrics + " " + Text2; } set { } }

        [NotMapped]
        public DelegateCommand<object> ToRedactStruct { get; private set; }

        public override string ToString()
        {
            return Text1 + " " + Metrics + " " + Text2;
        }



        public LegPartDbStructure()
        {

            ToRedactStruct = new DelegateCommand<object>((combox) =>
       {
           ComboBox x = combox as ComboBox;
           x.IsDropDownOpen = false;
           MessageBus.Default.Call("OpenStructRedact", this, null);


       }
   );
            //NameContext = Text1 + " " + Metrics + " " + Text2;
            ToNextPart = false;
            Custom = false;
        }
    }
}
