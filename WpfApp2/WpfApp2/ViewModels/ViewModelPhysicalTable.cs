using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelPhysicalTable : ViewModelBase
    {
        public DelegateCommand ToPhysicalCommand { get; protected set; }

        public ViewModelPhysicalTable(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
    }
}
