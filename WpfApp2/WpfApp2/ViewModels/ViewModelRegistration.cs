using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelRegistration : ViewModelBase
    {
        public DelegateCommand ToLoginCommand { get; protected set; }

        public ViewModelRegistration(NavigationController controller) : base(controller)
        {
            ToLoginCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelLogin>();
                }
            );
        }
    }
}