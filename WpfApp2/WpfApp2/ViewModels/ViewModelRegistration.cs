using System.ComponentModel;
using System.Windows.Input;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelRegistration : ViewModelBase
    {
        public  ICommand MyCommand { get; }

        public ViewModelRegistration(NavigationController controller) : base(controller)
        {
            
        }

        protected override void Executed(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            Controller.NavigateTo<ViewModelLogin>();
        }

        private string testString = "TEST YESS!!";
        private NavigationController navigationController;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Test
            {
                get { return testString; }
                set { testString = value; PropertyChanged("Test", null); }
            }
    }
}