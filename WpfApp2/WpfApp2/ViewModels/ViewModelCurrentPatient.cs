using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelCurrentPatient : ViewModelBase
    {
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

        private void SetCurrentPatientID(object sender, object data)
        {
            
            CurrentPatient = Data.Patients.Get((int)data);
            PatientBirthday = CurrentPatient.Birthday.Day.ToString() + "." 
            + CurrentPatient.Birthday.Month.ToString() + "." + CurrentPatient.Birthday.Year.ToString();

        }

        public ViewModelCurrentPatient(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("GetCurrentPatientId", SetCurrentPatientID);

            base.HasNavigation = true;



            ToNewOperationCommand = new DelegateCommand(
                () =>
                {
                   
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );

            ToPathologyListCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelPathologyList>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
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

