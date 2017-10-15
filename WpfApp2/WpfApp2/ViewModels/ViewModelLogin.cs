using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelLogin : ViewModelBase
    {
        public DelegateCommand ToRegistrationCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }

        public ViewModelLogin(NavigationController controller) : base(controller)
        {
            HasNavigation = false;
            
            ToRegistrationCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelRegistration>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );
        }
    }
}
