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
    public class DoctorSelectPanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase ParentVM { get; protected set; }

        private bool _panelOpened = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Docs> _doctors;
        public ObservableCollection<Docs> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }
        public int DoctorSelectedId { get; set; }

        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }



        public DoctorSelectPanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            using (var context = new MySqlContext())
            {
                DoctorRepository DoctorRep = new DoctorRepository(context);
                Doctors = new ObservableCollection<Docs>();

                foreach (var doc in DoctorRep.GetAll)
                {
                    Doctors.Add(new Docs(doc));
                }
            }
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

        public string GetPanelValue()
        {

            //newType.LongName = LongText;
            
            return Doctors[DoctorSelectedId].ToString();
        }

        internal void ClearPanel()
        {
            //LongText = "";
            ShortText = "";
        }
    }
}
