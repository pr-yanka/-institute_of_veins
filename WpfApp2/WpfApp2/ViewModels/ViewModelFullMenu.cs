using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.ViewModels
{
    public class ViewModelFullMenu : ViewModelBase
    {
        public DelegateCommand ToLoginCommand { get; protected set; }
        public DelegateCommand ToCalendarOperationsCommand { get; protected set; }
        public DelegateCommand ToAdminPanelCommand { get; protected set; }
        public DelegateCommand ToPhysicalTableCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }
        public DelegateCommand ToMainMenuCommand { get; protected set; }
        public Visibility PanelAdminVisibility { get; protected set; }
        public Visibility CalendarOperationVisibility { get; protected set; }
        // 
        private void SetVisibilityPanelAdmin(object sender, object data)
        {
            PanelAdminVisibility = (Visibility)data;
        }
        private void SetVisibilityForDocsOrMed(object sender, object data)
        {
            CalendarOperationVisibility = (Visibility)data;
        }



        public ViewModelFullMenu(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("SetVisibilityPanelAdmin", SetVisibilityPanelAdmin);
            MessageBus.Default.Subscribe("SetVisibilityForDocsOrMed", SetVisibilityForDocsOrMed);
            base.HasNavigation = false;
            ToMainMenuCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                });
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

                    MessageBus.Default.Call("UpdateTableOfPatients", this, controller);
                    Controller.NavigateTo<ViewModelTablePatients>();
                });
            ToAdminPanelCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAdminPanel>();
                });
        }
    }
}