using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelCreateOperation : ViewModelBase
    {
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        public ViewModelCreateOperation(NavigationController controller) : base(controller)
        {
            HasNavigation = false;

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
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
