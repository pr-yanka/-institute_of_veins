using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Model;
using WpfApp2.ViewModels;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public static readonly DependencyProperty CurrentViewModelProperty = DependencyProperty.Register(
            "CurrentViewModel", typeof(object), typeof(MainWindow), new PropertyMetadata(default(object)));

        public object CurrentViewModel
        {
            get { return (object) GetValue(CurrentViewModelProperty); }
            set { SetValue(CurrentViewModelProperty, value); }
        }

        public MainWindow()
        {
            CurrentViewModel = new ViewModelLogin();
            object type = (CurrentViewModel.GetType());
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            object type = (CurrentViewModel.GetType());
            if(CurrentViewModel == null || CurrentViewModel.GetType() == typeof(ViewModelLogin))
                CurrentViewModel = new ViewModelRegistration();
            else
                CurrentViewModel = new ViewModelLogin();
                
        }
    }
}
