using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddAnalize : ViewModelBase
    {
        public DelegateCommand ToCurrentPatient { get; protected set; }

        public ViewModelAddAnalize(NavigationController controller) : base(controller)
        {
            ToCurrentPatient = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelCurrentPatient>(); }
            );
        }
    }
}
