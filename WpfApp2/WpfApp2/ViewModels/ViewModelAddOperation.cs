using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddOperation : ViewModelBase
    {
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }


        public ViewModelAddOperation(NavigationController controller) : base(controller)
        {
            Controller = controller;
            HasNavigation = false;

            ToCurrentPatientCommand = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelCurrentPatient>(); }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelOperationOverview>(); }
            );
        }
    }
}
