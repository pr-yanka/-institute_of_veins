using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelEditPatient : ViewModelBase
    {
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        public ViewModelEditPatient(NavigationController controller) : base(controller)
        {
            base.HasNavigation = false;

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

        }
    }
}
