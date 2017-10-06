using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddPhysicalScreen1 : ViewModelBase
    {
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToSymptomsAddCommand { get; protected set; }
        public DelegateCommand ToLegDescribeCommand { get; protected set; }
        public DelegateCommand ToAddRecomendationsCommand { get; protected set; }


        public ViewModelAddPhysicalScreen1(NavigationController controller) : base(controller)
        {

            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelSymptomsAdd>();
                }
            );

            ToLegDescribeCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelLegDescribe>();
                }
            );

            ToAddRecomendationsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelRecomendationsAdd>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
        }
    }
}
