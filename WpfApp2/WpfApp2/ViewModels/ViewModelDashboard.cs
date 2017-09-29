using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelDashboard : ViewModelBase
    {
        public DelegateCommand ToLoginCommand { get; protected set; }

        public ViewModelDashboard(NavigationController controller) : base(controller)
        {
        }

    }
}