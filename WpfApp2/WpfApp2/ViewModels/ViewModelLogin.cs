﻿using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;
using WpfApp2.Db.Models.BPV;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.ViewModels
{
    public class ViewModelLogin : ViewModelBase
    {
        public DelegateCommand ToRegistrationCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }

        public BPVHipRepository rep;

        public ViewModelLogin(NavigationController controller) : base(controller)
        {
            HasNavigation = false;
            
            ToRegistrationCommand = new DelegateCommand(
                () =>
                {
                    //Controller.NavigateTo<ViewModelRegistration>();
                    Controller.NavigateTo<ViewModelRegistration>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            //rep = new BPVHipRepository(new BPVHipContext());
            //using (BPVHipContext dbContext = new BPVHipContext())
            //{
            //    bool exists = dbContext.Database.Exists();
            //}
            //rep = new BPVHipRepository(new BPVHipContext());
           // var st = rep.Get(1);

        }
    }
}
