using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.ViewModels
{
    public class ViewModelFullMenu : ViewModelBase
    {
        public DelegateCommand ToLoginCommand { get; protected set; }
        public DelegateCommand ToCalendarOperationsCommand { get; protected set; }
        public DelegateCommand ToPhysicalTableCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }

        public ViewModelFullMenu(NavigationController controller) : base(controller)
        {
            base.HasNavigation = false;

            ToLoginCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelLogin>();
                });

            ToCalendarOperationsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCalendarOperations>();
                });

            ToPhysicalTableCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelPhysicalTable>();
                });

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelTablePatients>();
                });
        }
    }
}