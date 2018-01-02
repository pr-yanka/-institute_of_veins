using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.LegParts.VMs;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class OperationTypePanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ViewModelBase _parentVM;

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
            _parentVM = parentVM;
            //Dimentions = new ObservableCollection<Metrics>(Data.Metrics.GetAll);
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
        //public ObservableCollection<Metrics> Dimentions { get; set; }


    }
}
