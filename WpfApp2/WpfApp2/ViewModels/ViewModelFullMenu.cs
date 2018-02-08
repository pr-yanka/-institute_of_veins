using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.ViewModels
{
    public class ViewModelFullMenu : ViewModelBase, INotifyPropertyChanged

    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region DelegateCommands
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand OtherReasonCommand { get; protected set; }
        #endregion


        public DelegateCommand ToLoginCommand { get; protected set; }
        public DelegateCommand ToCalendarOperationsCommand { get; protected set; }
        public DelegateCommand ToAdminPanelCommand { get; protected set; }
        public DelegateCommand ToPhysicalTableCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }
        public DelegateCommand ToMainMenuCommand { get; protected set; }

        private Visibility _panelAdminVisibility;
        private Visibility _calendarOperationVisibility;
        private Visibility _isAlertActiv;

        public Visibility PanelAdminVisibility { get { return _panelAdminVisibility; } set { _panelAdminVisibility = value; OnPropertyChanged(); } }

        public Visibility CalendarOperationVisibility { get { return _calendarOperationVisibility; } set { _calendarOperationVisibility = value; OnPropertyChanged(); } }

        public Visibility IsAlertActiv { get { return _isAlertActiv; } set { _isAlertActiv = value; OnPropertyChanged(); } }


        private void SaveLogs(object sender, object data)
        {
            List<ChangeHistory> logs = (List<ChangeHistory>)data;

            foreach (ChangeHistory log in logs)
            {
                if (log != null)
                    Data.ChangeHistory.Add(log);
            }

            Data.Complete();
        }
        // 
        private void SetAlertVisibility(object sender, object data)
        {
            IsAlertActiv = (Visibility)data;
        }
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
            MessageBus.Default.Subscribe("SaveLogs", SaveLogs);
            MessageBus.Default.Subscribe("SetAlertVisibility", SetAlertVisibility);
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
                    MessageBus.Default.Call("SetCurrentACCOp", this, null);
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