using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class TEMPVVayTypePanelViewModel : ViewModelBase, INotifyPropertyChanged
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



        public TEMPVVayTypePanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            ParentVM = parentVM;

        }

        private string _shortText;
        public string ShortText
        {
            get { return _shortText; }
            set
            {
                _shortText = value;
                OnPropertyChanged();
            }
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

        public TEMPVWay GetPanelType()
        {
            var newType = new TEMPVWay();
            //newType.LongName = LongText;
            newType.Name = ShortText;
            return newType;
        }

        internal void ClearPanel()
        {
            //LongText = "";
            ShortText = "";
        }
    }
}
