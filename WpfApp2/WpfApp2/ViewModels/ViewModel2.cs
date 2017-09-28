using System.ComponentModel;
using System.Windows.Input;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModel2 : ViewModelBase
    {
        public  ICommand MyCommand { get; }

        public ViewModel2(NavigationController controller) : base(controller)
        {
            
        }

        protected override void Executed(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            Controller.NavigateTo<ViewModel1>();
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