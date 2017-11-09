using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.WpfApplication1;

namespace WpfApp2.ViewModels
{
    class MainWindowViewModel
    {
        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }

        private void OnOpenDialog(object parameter)
        {

        }

        public MainWindowViewModel()
        {
            this.openDialogCommand = new RelayCommand(OnOpenDialog);
        }
    }
}
