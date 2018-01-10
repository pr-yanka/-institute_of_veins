using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class MedPatientDataSource
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

        public MedPatientDataSource(DelegateCommand Redact, string Name, DelegateCommand Archivate)
        {
            this.Redact = Redact;
            this.Archivate = Archivate;
            this.Name = Name;
        }
    }

    public class ViewModelViewMedPatient : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ObservableCollection<MedPatientDataSource> _historyDataSource;

        public ObservableCollection<MedPatientDataSource> DataSource { get { return _historyDataSource; } set { _historyDataSource = value; OnPropertyChanged(); } }

        public DelegateCommand ToAddSomeoneCommand { get; protected set; }

        public string TextAddUserOrPersonalOrMed
        {
            get;
            set;
        }

        private void SetCurrentPatientID(object sender, object data)
        {
            TextAddUserOrPersonalOrMed = "Добавить Мед";
            DataSource = new ObservableCollection<MedPatientDataSource>();

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

            foreach (var Med in Data.MedPersonal.GetAll)
            {
                string initials = " " + Med.Name.ToCharArray()[0].ToString() + ". " + Med.Patronimic.ToCharArray()[0].ToString() + ". ";
                DataSource.Add(new MedPatientDataSource(Redact, Med.Surname + initials, Archivate));
            }

        }

        public ViewModelViewMedPatient(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            HasNavigation = true;
            MessageBus.Default.Subscribe("OpenMeds", SetCurrentPatientID);

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
