using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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
        //[NotMapped]
        //private Visibility _isButtonsVisible;
        //[NotMapped]
        //public Visibility IsButtonsVisible
        //{
        //    get { return _isButtonsVisible; }
        //    set { _isButtonsVisible = value; OnPropertyChanged(); }
        //}




        [NotMapped]
        private string _text2;
        [NotMapped]
        private string _metric;
        [NotMapped]
        private string _text1;
        [NotMapped]
        private int? _size;
        [Column("name1")]
        public string Text1
        {
            get { return _text1; }
            set { _text1 = value; OnPropertyChanged(); OnPropertyChanged("NameContext"); }
        }
        [Column("name2")]
        public string Text2
        {
            get { return _text2; }
            set { _text2 = value; OnPropertyChanged(); OnPropertyChanged("NameContext"); }
        }

        [Required]
        [Column("is_metrics")]
        //[Column("есть_метрика")]
        public bool HasSize
        {
            get;
            set;
        }

        //[Column("id_метрики")]
        [Column("id_metrics")]
        public int? Size
        {
            get { return _size; }
            set
            {
                _size = value;

                if (_size != null)
                {
                    var Data = UnitOfWork.Instance(new MySqlContext());
                    Metrics = Data.Metrics.GetStr(Size.Value);
                }


                OnPropertyChanged();
            }
        }

        [Required]

        [Column("level_id")]
        // [Column("уровень_вложенности")]
        public int Level { get; set; }

        [NotMapped]
        public string Metrics
        {
            get { return _metric; }
            set { _metric = value; OnPropertyChanged(); OnPropertyChanged("NameContext"); }
        }

        [NotMapped]
        public bool Custom { get; internal set; }

        [NotMapped]
        public bool ToNextPart { get; internal set; }

        [Column("double_metric")]
        public virtual bool HasDoubleMetric { get; set; }


        [NotMapped]
        public string NameContext { get { return Text1 + " " + Metrics + " " + Text2; } set { } }
        //[NotMapped]
        //public DelegateCommand<object> ToDeleteStruct { get; private set; }
        //[NotMapped]
        //public DelegateCommand<object> ToRedactStruct { get; private set; }

        public override string ToString()
        {
            return Text1 + " " + Metrics + " " + Text2;
        }



        public LegPartDbStructure()
        {

            //IsButtonsVisible = Visibility.Visible;

            //NameContext = Text1 + " " + Metrics + " " + Text2;
            ToNextPart = false;
            Custom = false;
        }
    }
}
