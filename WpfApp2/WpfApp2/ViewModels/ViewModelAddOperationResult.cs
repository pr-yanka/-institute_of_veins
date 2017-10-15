using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddOperationResult : ViewModelBase
    {
        public ViewModelAddOperationResult(NavigationController controller) : base(controller)
        {
            HasNavigation = false;
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
