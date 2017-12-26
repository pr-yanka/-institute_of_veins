using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelSymptomsAdd : ViewModelBase
    {
        public DelegateCommand ToAddPhysicalCommand { get; protected set; }
        public DelegateCommand ToSymptomsAddCommand { get; protected set; }

        public ViewModelSymptomsAdd(NavigationController controller) : base(controller)
        {
            base.HasNavigation = false;
            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelComplainsList>();
                }
            );
        }
    }
}
