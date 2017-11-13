using System.Windows;
using System.Windows.Input;
using WpfApp2.DialogService;

namespace WpfApp2.LegParts.DialogConfirmStructure
{
    class DialogConfirmStructureViewModel : DialogViewModelBase
    {
        private ICommand confirmCommand = null;
        public ICommand ConfirmCommand
        {
            get { return confirmCommand; }
            set { confirmCommand = value; }
        }

        private ICommand returnCommand = null;
        public ICommand ReturnCommand
        {
            get { return returnCommand; }
            set { returnCommand = value; }
        }

        public DialogConfirmStructureViewModel()
        {
            this.confirmCommand = new RelayCommand(OnReturnClicked);
            this.returnCommand = new RelayCommand(OnConfirmClicked);
        }

        private void OnReturnClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.Confirm);
        }

        private void OnConfirmClicked(object parameter)
        {
            this.CloseDialogWithResult(parameter as Window, DialogResult.Return);
        }
    }
}
