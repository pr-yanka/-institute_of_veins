using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModel1 : ViewModelBase
    {
        public ICommand MyCommand { get; }

        public ViewModel1(NavigationController controller) : base(controller)
        {
        }

        protected override void Executed(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            Controller.NavigateTo<ViewModel2>();
        }
    }
}
