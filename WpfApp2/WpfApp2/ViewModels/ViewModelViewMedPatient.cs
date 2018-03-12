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

        public MedPatientDataSource(DelegateCommand Redact, string Name, DelegateCommand Archivate, string BtnName)
        {
            this.BtnName = BtnName;
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
            using (var context = new MySqlContext())
            {

                TextAddUserOrPersonalOrMed = "Добавить Медперсонал";
                TooltipText = "Архивация позволяет отключить медсотрудника от системы";
                DataSource = new ObservableCollection<MedPatientDataSource>();

                MedPersonalRepository medRep = new MedPersonalRepository(context);


                foreach (var Med in medRep.GetAll)
                {
                    DelegateCommand Redact = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetMedForMedEdit", this, Med.Id);
                    Controller.NavigateTo<ViewModelEditMedPersonal>();
                }
                );

                    string BtnName = "Разархивировать";
                    DelegateCommand Archivate = new DelegateCommand(
                        () =>
                        {
                            Data.MedPersonal.Get(Med.Id).isEnabled = true;
                            Data.Complete();
                            MessageBus.Default.Call("OpenMeds", this, "");
                        }
                        );
                    if (Med.isEnabled == true)
                    {
                        BtnName = "Архивировать";
                        Archivate = new DelegateCommand(
                       () =>
                       {
                           Data.MedPersonal.Get(Med.Id).isEnabled = false;
                           Data.Complete();
                           MessageBus.Default.Call("OpenMeds", this, "");
                       }
                       );
                    }
                    string initials = " " + Med.Name.ToCharArray()[0].ToString() + ". " + Med.Patronimic.ToCharArray()[0].ToString() + ". ";
                    DataSource.Add(new MedPatientDataSource(Redact, Med.Surname + initials, Archivate, BtnName));
                }
            }
        }

        public ViewModelViewMedPatient(NavigationController controller) : base(controller)
        {
            NameOfTbl = "Медперсонал";
            base.HasNavigation = true;
            HasNavigation = true;
            MessageBus.Default.Subscribe("OpenMeds", SetCurrentPatientID);

            ToAddSomeoneCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RefreshDataForMedpersonal", null, null);
                    Controller.NavigateTo<ViewModelAddMedPersonal>();
                }
            );

        }
    }
}
