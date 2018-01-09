using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class DoctorsDataSource
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set { _name = value; }
        }

        public DelegateCommand Archivate { get; protected set; }
        public DelegateCommand Redact { get; protected set; }

        public DoctorsDataSource(DelegateCommand Redact, string Name, DelegateCommand Archivate)
        {
            this.Redact = Redact;
            this.Archivate = Archivate;
            this.Name = Name;
        }
    }

    public class ViewModelViewDoctors : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    
        public ObservableCollection<DoctorsDataSource> _historyDataSource;
        public ObservableCollection<DoctorsDataSource> DataSource { get { return _historyDataSource; } set { _historyDataSource = value; OnPropertyChanged();  } }

        public DelegateCommand ToAddSomeoneCommand { get; protected set; }

        public string TextAddUserOrPersonalOrMed
        {
            get;
            set;
        }

        private void SetCurrentPatientID(object sender, object data)
        {
            TextAddUserOrPersonalOrMed = "Добавить Врачи";
            DataSource = new ObservableCollection<DoctorsDataSource>();

            DelegateCommand Redact = new DelegateCommand(
            () =>
            {
                    //MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    //Controller.NavigateTo<ViewModelAddAnalize>();
            }
            );

            DelegateCommand Archivate = new DelegateCommand(
            () =>
            {
                    //MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    //Controller.NavigateTo<ViewModelAddAnalize>();
            }
            );

            foreach (var Doctors in Data.Doctor.GetAll)
            {

                string initials = " " + Doctors.Name.ToCharArray()[0].ToString() + ". " + Doctors.Patronimic.ToCharArray()[0].ToString() + ". ";
                DataSource.Add(new DoctorsDataSource(Redact, Doctors.Sirname + initials, Archivate));
            }

        }

        public ViewModelViewDoctors(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            HasNavigation = true;
            MessageBus.Default.Subscribe("OpenDoctors", SetCurrentPatientID);

            ToAddSomeoneCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    //Controller.NavigateTo<ViewModelAddAnalize>();
                }
            );

        }
    }
}
