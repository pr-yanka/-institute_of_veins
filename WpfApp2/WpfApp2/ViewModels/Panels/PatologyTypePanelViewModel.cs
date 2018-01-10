using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.LegParts.VMs;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class PatologyTypePanelViewModel : ViewModelBase, INotifyPropertyChanged
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

        

        public PatologyTypePanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            ParentVM = parentVM;
            
        }

     
        private string _newPtName;
        public string NewPtName
        {
            get { return _newPtName; }
            set
            {
                _newPtName = value;
                OnPropertyChanged();
            }
        }

        public PatologyType GetPanelType()
        {
            var newType = new PatologyType();
            newType.Str = NewPtName;
            return newType;
        }

        internal void ClearPanel()
        {
            NewPtName = "";
        }
    }
}
