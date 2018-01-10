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
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class PatologyDataSource
    {
        public string Name { get; set; }
        public string DateAppear { get; set; }
        public string DateDisapear { get; set; }
        public DelegateCommand ArchiveCommand { get; set; }
        public DelegateCommand RedactCommand { get; set; }
        private Patology Patology;


        public PatologyDataSource(string Name, string DateAppear, string DateDisapear, DelegateCommand ArchiveCommand, DelegateCommand RedactCommand, Patology Patology)
        {
            this.Name = Name;
            this.DateAppear = DateAppear;
            this.DateDisapear = DateDisapear;
            this.ArchiveCommand = ArchiveCommand;
            this.RedactCommand = RedactCommand;
            this.Patology = Patology;
        }
    }
    public class ViewModelPathologyList : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion




        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        public DelegateCommand ToAddPathologyCommand { get; protected set; }

        private ObservableCollection<PatologyDataSource> _patologyList;
        public ObservableCollection<PatologyDataSource> PatologyList { get { return _patologyList; } set { _patologyList = value; OnPropertyChanged(); } }

        public Patient CurrentPatient { get; set; }

        private void GetPatientForPatology(object sender, object data)
        {
            PatologyList = new ObservableCollection<PatologyDataSource>();
            using (var context = new MySqlContext())
            {
                PatologyTypeRepository ptTRep = new PatologyTypeRepository(context);
                PatologyRepository ptRep = new PatologyRepository(context);
                PatientsRepository ptentRep = new PatientsRepository(context);
                CurrentPatient = ptentRep.Get((int)data);
                foreach (var Patology in ptRep.GetAll)
                {
                    //Patology sadasew
                    if (Patology.id_пациента == CurrentPatient.Id)
                    {
                        foreach (var PatoType in ptTRep.GetAll)
                        {
                            if (PatoType.Id == Patology.id_патологии)
                            {
                                string DateAppear = Patology.MonthAppear.Value.Month.ToString() + "/" + Patology.YearAppear.Value.Year.ToString();
                                string DateDisappear = "";
                                try
                                {
                                    DateDisappear = Patology.MonthDisappear.Value.Month.ToString() + "/" + Patology.YearDisappear.Value.Year.ToString();
                                }
                                catch {  }
                                DelegateCommand ToRedactP = new DelegateCommand(
                                    () =>
                                    {
                                        MessageBus.Default.Call("GetPatologyForRedactPatology", this, Patology);
                                        Controller.NavigateTo<ViewModelRedactPathology>();
                                       
                                    }
                                    );
                                DelegateCommand ToArchiveP = new DelegateCommand(
                                    () =>
                                    {

                                        MessageBus.Default.Call("GetPatologyForArchivePatology", this, Patology);
                                        Controller.NavigateTo<ViewModelArchivePathology>();
                                    }
                                    );
                                PatologyList.Add(new PatologyDataSource(PatoType.Str, DateAppear, DateDisappear, ToArchiveP, ToRedactP, Patology));
                            }
                        }

                    }
                }
            }

        }



        public ViewModelPathologyList(NavigationController controller) : base(controller)
        {
            HasNavigation = true;

            MessageBus.Default.Subscribe("GetPatientForPatology", GetPatientForPatology);

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToAddPathologyCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForAddPatology", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddPathology>();
                }
            );
        }
    }
}
