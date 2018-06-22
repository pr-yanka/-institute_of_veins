using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class AddTimeRowPanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase ParentVM { get; protected set; }

        private bool _panelOpened = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }

        

        public AddTimeRowPanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            ParentVM = parentVM;
            
        }

 

        //private string _longText;
        //public string LongText
        //{
        //    get { return _longText; }
        //    set
        //    {
        //        _longText = value;
        //        OnPropertyChanged();
        //    }
        //}
        private System.DateTime _date;
        public System.DateTime Date
        {
            get
            {
                return _date;
            }
            set { _date = value; OnPropertyChanged();   }
        }
        public OperationDateTime GetPanelType()
        {
            var TimeRow = new OperationDateTime
            {
                Datetime = Date,
                Note = "Время свободно"
            };
            //Data.OperationDateTime.Add(TimeRow);
            //Data.Complete();
            return TimeRow;
        }

        internal void ClearPanel()
        {
            //LongText = "";
            Date = ((SelectTimePanelViewModel)ParentVM).Date;
        }
    }
}
