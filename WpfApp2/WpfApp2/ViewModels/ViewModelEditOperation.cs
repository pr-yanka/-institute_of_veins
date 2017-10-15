using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelEditOperation : ViewModelBase
    {
        public DelegateCommand ToOperationCommand { get; protected set; }

        public ViewModelEditOperation(NavigationController controller) : base(controller)
        {
            HasNavigation = false;

            ToOperationCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );

        }
    }
}
