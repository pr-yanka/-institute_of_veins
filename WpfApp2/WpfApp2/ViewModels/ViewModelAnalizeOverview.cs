using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAnalizeOverview : ViewModelBase
    {
        public DelegateCommand ToCurrentPatient;

        public ViewModelAnalizeOverview(NavigationController controller) : base(controller)
        {
            HasNavigation = true;
            Controller = controller;

            ToCurrentPatient = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelCurrentPatient>(); }
            );
        }
    }
}
