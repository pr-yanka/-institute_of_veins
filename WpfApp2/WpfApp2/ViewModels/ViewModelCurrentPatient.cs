using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
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

        public ViewModelCurrentPatient(NavigationController controller) : base(controller)
        {
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
                    Controller.NavigateTo<ViewModelEditPatient>();
                }
            );

            ToNewPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysicalScreen1>();
                }
                );

            ToViewHistoryCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelViewHistory>();
                });
        }
    }
}

