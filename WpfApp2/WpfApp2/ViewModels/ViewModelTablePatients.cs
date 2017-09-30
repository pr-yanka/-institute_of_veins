using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelTablePatients : ViewModelBase
    {
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        public ViewModelTablePatients(NavigationController controller) : base(controller)
        {
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
        }
    }
}
