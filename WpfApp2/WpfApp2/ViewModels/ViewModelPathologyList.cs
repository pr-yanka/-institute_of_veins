using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelPathologyList : ViewModelBase
    {
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToAddPathologyCommand { get; protected set; }

        public ViewModelPathologyList(NavigationController controller) : base(controller)
        {
            HasNavigation = true;

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToAddPathologyCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
        }
    }
}
