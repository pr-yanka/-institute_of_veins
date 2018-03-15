using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.DialogService;
using WpfApp2.Messaging;

namespace WpfApp2.DialogPreOperation
{
    class DialogPreOperationViewModel : DialogViewModelBase
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

        public string Commentary { get; set; }
        public ObservableCollection<OperationType> OpTypes { get; set; }
        public int SelectedOpTypeID { get; set; }
        public DialogPreOperationViewModel()
        {
            SelectedOpTypeID = 0;
            Commentary = "";
            using (var context = new MySqlContext())
            {
                OperationTypeRepository OptRep = new OperationTypeRepository(context);
                OpTypes = new ObservableCollection<OperationType>(OptRep.GetAll.ToList());
            }

            this.confirmCommand = new RelayCommand(OnReturnClicked);
            this.returnCommand = new RelayCommand(OnConfirmClicked);
        }

        private void OnReturnClicked(object parameter)
        {
            try
            {
                if (OpTypes.Count != 0)
                {
                    MessageBus.Default.Call("GetOpTypeAndCommentaryFromDialog", OpTypes[SelectedOpTypeID].Id, Commentary);
                }
            }
            catch { }
            this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
        }

        private void OnConfirmClicked(object parameter)
        {
            
            this.CloseDialogWithResult(parameter as Window, DialogResult.Return);
        }
    }
}
