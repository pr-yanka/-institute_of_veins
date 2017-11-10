using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelLegDescribe : ViewModelBase
    {
        public DelegateCommand ToAddPhysicalCommand { get; protected set; }

        public ViewModelLegDescribe(NavigationController controller) : base(controller)
        {
            base.HasNavigation = false;
            ToAddPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
        }
    }
}
