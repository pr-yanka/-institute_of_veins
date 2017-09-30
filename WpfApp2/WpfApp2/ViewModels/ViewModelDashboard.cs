using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelDashboard : ViewModelBase
    {
        public DelegateCommand ToNewPatientCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }
        public DelegateCommand ToLoginCommand { get; protected set; }

        public ViewModelDashboard(NavigationController controller) : base(controller)
        {
            ToNewPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelNewPatient>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );

            ToLoginCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelLogin>();
                }
            );
        }

    }
}