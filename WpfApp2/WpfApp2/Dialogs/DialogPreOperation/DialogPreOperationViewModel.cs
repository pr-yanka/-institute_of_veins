using Microsoft.Practices.Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.DialogService;
using WpfApp2.Messaging;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.DialogPreOperation
{
    class DialogPreOperationViewModel : DialogViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand confirmCommand = null;
        public ICommand ConfirmCommand
        {
            get { return confirmCommand; }
            set { confirmCommand = value; }
        }
        public DelegateCommand RevertCommand { set; get; }
        public DelegateCommand SaveCommand { set; get; }
        public ICommand OpenPanelCommand { protected set; get; }
        private ICommand returnCommand = null;
        public ICommand ReturnCommand
        {
            get { return returnCommand; }
            set { returnCommand = value; }
        }
        public OperationTypePanelViewModel CurrentPanelViewModel { get; protected set; }
        public string Commentary { get; set; }
        private ObservableCollection<OperationType> _opTypes;
        public ObservableCollection<OperationType> OpTypes
        {
            get { return _opTypes; }
            set
            {
                _opTypes = value;
                OnPropertyChanged();
            }
        }
        private int _selectedOpTypeID;
        public int SelectedOpTypeID
        {
            get { return _selectedOpTypeID; }
            set
            {
                _selectedOpTypeID = value;
                OnPropertyChanged();
            }
        }
        public DialogPreOperationViewModel()
        {

            CurrentPanelViewModel = new OperationTypePanelViewModel(this);
            SelectedOpTypeID = 0;
            Commentary = "";
            using (var context = new MySqlContext())
            {
                OperationTypeRepository OptRep = new OperationTypeRepository(context);
                OpTypes = new ObservableCollection<OperationType>(OptRep.GetAll.ToList());
            }

            this.confirmCommand = new RelayCommand(OnReturnClicked);
            this.returnCommand = new RelayCommand(OnConfirmClicked);

            OpenPanelCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {
                OperationType newType = CurrentPanelViewModel.GetPanelType();
                MessageBus.Default.Call("AddOperationTypeForDialogBox", this, newType);
                using (var context = new MySqlContext())
                {
                    OperationTypeRepository OptRep = new OperationTypeRepository(context);
                    OpTypes = new ObservableCollection<OperationType>(OptRep.GetAll.ToList());
                }
                SelectedOpTypeID = OpTypes.Count - 1;
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = false;
            });

            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = false;
            });
        }

        private void OnReturnClicked(object parameter)
        {
            try
            {
                if (OpTypes.Count != 0)
                {
                    MessageBus.Default.Call("GetOpTypeAndCommentaryFromDialog", OpTypes[SelectedOpTypeID].Id, Commentary);
                    this.CloseDialogWithResult(parameter as Window, DialogResult.Yes);
                }
                else
                {
                    MessageBox.Show("Добавьте тип операции");
                }
            }
            catch { }
        }

        private void OnConfirmClicked(object parameter)
        {

            this.CloseDialogWithResult(parameter as Window, DialogResult.Return);
        }
    }
}