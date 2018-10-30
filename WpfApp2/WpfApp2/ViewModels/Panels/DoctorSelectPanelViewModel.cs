using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class DoctorSelectPanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase ParentVM { get; protected set; }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Docs> _doctors;
        public ObservableCollection<Docs> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }

        private int _doctorSelectedId;
        public int DoctorSelectedId
        {
            get { return _doctorSelectedId; }
            set
            {
                _doctorSelectedId = value;
                OnPropertyChanged();
            }
        }
        private bool _panelOpened = false;
        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }

        private string _commentary;
        public string Commentary
        {
            get { return _commentary; }
            set
            {
                _commentary = value;
                OnPropertyChanged();
            }
        }

        public DoctorSelectPanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            DoctorSelectedId = 0;
            Doctors = new ObservableCollection<Docs>();

            foreach (var doc in Data.Doctor.GetAll)
            {
                if (doc.isEnabled.Value)
                {
                    Doctors.Add(new Docs(doc));
                }
            }
            DoctorSelectedId = Doctors.Count - 1;
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
            if (DoctorSelectedId == -1 || DoctorSelectedId > Doctors.Count - 1)
                return "";
            return Doctors[DoctorSelectedId].ToString();
        }

        internal void ClearPanel()
        {
            DoctorSelectedId = 0;
            Doctors = new ObservableCollection<Docs>();

            foreach (var doc in Data.Doctor.GetAll)
            {
                if (doc.isEnabled.Value)
                {
                    Doctors.Add(new Docs(doc));
                }
            }
            DoctorSelectedId = Doctors.Count - 1;
            //LongText = "";
            ShortText = "";
        }
    }
}
