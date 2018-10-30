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

        private string _btnName;
        public string BtnName
        {
            get
            {
                return _btnName;

            }
            set { _btnName = value; }
        }

        public DelegateCommand Archivate { get; protected set; }
        public DelegateCommand Redact { get; protected set; }

        public DoctorsDataSource(DelegateCommand Redact, string Name, DelegateCommand Archivate, string BtnName)
        {
            this.BtnName = BtnName;
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
        private string _nameOfTbl;
        public string NameOfTbl
        {
            get
            {
                return _nameOfTbl;

            }
            set { _nameOfTbl = value; OnPropertyChanged(); }
        }
        public string TooltipText { get; set; }

        public ObservableCollection<DoctorsDataSource> _historyDataSource;

        public ObservableCollection<DoctorsDataSource> DataSource { get { return _historyDataSource; } set { _historyDataSource = value; OnPropertyChanged(); } }

        public DelegateCommand ToAddSomeoneCommand { get; protected set; }

        public string TextAddUserOrPersonalOrMed
        {
            get;
            set;
        }

        private void SetCurrentPatientID(object sender, object data)
        {
        
               TextAddUserOrPersonalOrMed = "Добавить врача";
            TooltipText = "Архивация позволяет отключить врача от системы";
            DataSource = new ObservableCollection<DoctorsDataSource>();

            foreach (var Doctors in Data.Doctor.GetAll)
            {
                DelegateCommand Redact = new DelegateCommand(
                () =>
                {

                    MessageBus.Default.Call("GetDoctorForEditDoctor", this, Doctors.Id);
                    Controller.NavigateTo<ViewModelEditDoctor>();
                }
                );
                string BtnName = "Разархивировать";
                DelegateCommand Archivate = new DelegateCommand(
                    () =>
                    {
                        Data.Doctor.Get(Doctors.Id).isEnabled = true;
                        Data.Complete();
                        MessageBus.Default.Call("OpenDoctors", this, "");
                    }
                    );
                if (Doctors.isEnabled == true)
                {
                    BtnName = "Архивировать";
                    Archivate = new DelegateCommand(
                    () =>
                    {
                        Data.Doctor.Get(Doctors.Id).isEnabled = false;
                        Data.Complete();
                        MessageBus.Default.Call("OpenDoctors", this, "");
                    }
                    );
                }
                string initials = " " + Doctors.Name.ToCharArray()[0].ToString() + ". " + Doctors.Patronimic.ToCharArray()[0].ToString() + ". ";
                DataSource.Add(new DoctorsDataSource(Redact, Doctors.Sirname + initials, Archivate, BtnName));
            }
        }

        public ViewModelViewDoctors(NavigationController controller) : base(controller)
        {
            NameOfTbl = "Врачи";
            base.HasNavigation = true;
            HasNavigation = true;
            MessageBus.Default.Subscribe("OpenDoctors", SetCurrentPatientID);

            ToAddSomeoneCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RefreshDataForNewDoctors", this, "");
                    //MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddDoctor>();
                }
            );

        }
    }
}
