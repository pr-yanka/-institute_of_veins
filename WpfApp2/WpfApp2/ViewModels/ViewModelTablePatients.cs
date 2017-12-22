using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelTablePatients : ViewModelBase
    {
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToHistoryOverviewCommand { get; protected set; }

        public ObservableCollection<Patient> PatientsCollection { get; set; }

        public ViewModelTablePatients(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            PatientsCollection = new ObservableCollection<Patient>(Data.Patients.GetAll);

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
