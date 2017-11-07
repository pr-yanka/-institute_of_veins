﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelViewHistory : ViewModelBase
    {
        public DelegateCommand ToAddPhysicalCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToAnalizeOverviewCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }

        public ViewModelViewHistory(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            ToAddPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysicalScreen1>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToAnalizeOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAnalizeOverview>();
                }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );

            ToPhysicalOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelPhysicalOverview>();
                }
            );


        }
    }
}
