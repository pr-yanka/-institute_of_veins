using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp2.Navigation;
using WpfApp2.ViewModels;
using WpfApp2.WpfApplication1;

namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public NavigationController Controller { get; }
        public ViewModelFullMenu CurrentNavigation { get; }

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }

        private void OnOpenDialog(object parameter)
        {

        }

        public MainWindow()
        {
            this.openDialogCommand = new RelayCommand(OnOpenDialog);
            Controller = new NavigationController();
            CurrentNavigation = new ViewModelFullMenu(Controller);

            InitializeComponent();
        }
    }
}