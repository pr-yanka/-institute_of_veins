using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddPathology : ViewModelBase
    {
        public DelegateCommand ToPathologyListCommand { get; protected set; }

        public ViewModelAddPathology(NavigationController controller) : base(controller)
        {
            HasNavigation = false;

            ToPathologyListCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelPathologyList>();
                }
            );

        }
    }
}
