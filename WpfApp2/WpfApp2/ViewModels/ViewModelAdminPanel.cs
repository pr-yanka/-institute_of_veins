using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAdminPanel : ViewModelBase
    {
        #region DelegateCommands
        public DelegateCommand ToUsersCommand { get; protected set; }
        public DelegateCommand ToMedPersonalCommand { get; protected set; }
        public DelegateCommand ToDoctorsCommand { get; protected set; }
        #endregion

        public ViewModelAdminPanel(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            HasNavigation = true;

            ToUsersCommand = new DelegateCommand(
                () =>
                {

                    MessageBus.Default.Call("OpenUsers", this, "");
                    Controller.NavigateTo<ViewModelViewUsers>();
                });
            ToMedPersonalCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("OpenMeds", this, "");
                    Controller.NavigateTo<ViewModelViewMedPatient>();
                });

            ToDoctorsCommand = new DelegateCommand(
            () =>
            {
                //OpenUsers
                MessageBus.Default.Call("OpenDoctors", this, "");

                Controller.NavigateTo<ViewModelViewDoctors>();
            });
        }
    }
}
