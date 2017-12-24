using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;
using System.Windows;

namespace WpfApp2.ViewModels
{
    public class ViewModelTablePatients : ViewModelBase
    {
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToHistoryOverviewCommand { get; protected set; }

        public List<ViewModelPatient> Patients { get; set; }
        public ViewModelTablePatients(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
           
            Patients = new List<ViewModelPatient>();
            foreach(var patient in Data.Patients.GetAll)
            {
                Patients.Add(new ViewModelPatient(controller, patient));
            }

            /*Patients = new List<ViewModelPatient>();

            foreach (var p in Data.Patients.GetAll)
                Patients.Add( new ViewModelPatient( Controller, p));*/
          

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToHistoryOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelViewHistory>();
                }
            );
        }
    }
}
