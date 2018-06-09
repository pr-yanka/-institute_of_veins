using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.DialogService;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class OperationTypePanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase ParentVM { get; protected set; }
        public DialogViewModelBase ParentVMD { get; protected set; }
        
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



        public OperationTypePanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            ParentVM = parentVM;

        }

        public OperationTypePanelViewModel(DialogViewModelBase parentVMD) : base(null)
        {
            ParentVMD = parentVMD;
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

        private string _longText;
        public string LongText
        {
            get { return _longText; }
            set
            {
                _longText = value;
                OnPropertyChanged();
            }
        }

        public OperationType GetPanelType()
        {
            var newType = new OperationType();
            newType.LongName = LongText;
            newType.ShortName = ShortText;
            return newType;
        }

        internal void ClearPanel()
        {
            LongText = "";
            ShortText = "";
        }
    }
}
