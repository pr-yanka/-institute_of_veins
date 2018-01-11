using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelCurrentPatient : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public DelegateCommand ToEditPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToNewOperationCommand { get; protected set; }
        public DelegateCommand ToNewPhysicalCommand { get; protected set; }
        public DelegateCommand ToAddAnalysesCommand { get; protected set; }
        public DelegateCommand ToViewHistoryCommand { get; protected set; }
        public DelegateCommand ToPathologyListCommand { get; protected set; }
        public DelegateCommand ToAddAnalizeCommand { get; protected set; }

        //protected int CurrentPatientID;  

        public string PatientBirthday { get; set; }

        private Patient currentPatient;

        public Patient CurrentPatient
        {
            get { return currentPatient; }
            set { currentPatient = value; }
        }
        private Visibility _isDistrict;
        public Visibility IsDistrict { get { return _isDistrict; } set { _isDistrict = value; OnPropertyChanged(); } }

        public string Town { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }



        private void SetCurrentPatientID(object sender, object data)
        {

           
            using (var context = new MySqlContext())
            {
                PatientsRepository PatientsRep = new PatientsRepository(context);

                CurrentPatient = PatientsRep.Get((int)data);
                PatientBirthday = CurrentPatient.Birthday.Day.ToString() + "."
                + CurrentPatient.Birthday.Month.ToString() + "." + CurrentPatient.Birthday.Year.ToString();


                CitiesRepository ctRep = new CitiesRepository(context);
                RegionsRepository regRep = new RegionsRepository(context);
                DistrictsRepository distRep = new DistrictsRepository(context);
                StreetsRepository strtRep = new StreetsRepository(context);
                Town = ctRep.Get(CurrentPatient.City).Str;
                if (CurrentPatient.District != null)
                {
                    District = distRep.Get(CurrentPatient.District.Value).Str;
                    IsDistrict = Visibility.Visible;
                }
                else
                {
                    IsDistrict = Visibility.Hidden;
                }
                Region = regRep.Get(CurrentPatient.Region).Str;
                Street = strtRep.Get(CurrentPatient.Street).Str;

            }

        }

        public ViewModelCurrentPatient(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("GetCurrentPatientId", SetCurrentPatientID);

            base.HasNavigation = true;



            ToNewOperationCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetCurrentPatientForOperation", this, currentPatient.Id);
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );

            ToPathologyListCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForPatology", this, currentPatient.Id);

                    Controller.NavigateTo<ViewModelPathologyList>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("UpdateTableOfPatients", this, controller);
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToEditPatientCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientIdForEdit", this, currentPatient.Id);
                    Controller.NavigateTo<ViewModelEditPatient>();
                }
            );

            ToNewPhysicalCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
                );

            ToViewHistoryCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("OpenHistoryOfPatient", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelViewHistory>();
                });

            ToAddAnalizeCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddAnalize>();
                });
        }
    }
}

