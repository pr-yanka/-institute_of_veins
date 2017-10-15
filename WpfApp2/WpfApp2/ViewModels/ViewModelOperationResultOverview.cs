using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelOperationResultOverview : ViewModelBase
    {
        public ViewModelOperationResultOverview(NavigationController controller) : base(controller)
        {
            HasNavigation = true;

            ToOperationCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }

        public DelegateCommand ToOperationCommand { get; protected set; }
    }
}
