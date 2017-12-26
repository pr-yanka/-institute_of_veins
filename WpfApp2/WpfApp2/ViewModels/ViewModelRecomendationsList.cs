using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelRecomendationsList : ViewModelBase
    {
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }

        public ViewModelRecomendationsList(NavigationController controller) : base(controller)
        {
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
        }
    }
}
