using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    class MainWindowViewModel
    {
        public NavigationController Controller { get; }
        public ViewModelFullMenu CurrentNavigation { get; }



        public MainWindowViewModel()
        {
            Controller = new NavigationController();
            CurrentNavigation = new ViewModelFullMenu(Controller);
        }
    }
}
