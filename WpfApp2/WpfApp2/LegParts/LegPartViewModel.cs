using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp2.LegParts.DialogConfirmStructure;
using WpfApp2.LegParts.VMs;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts
{
    public class LegPartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _isEmpty = true;
        public bool IsEmpty {
            get
            {
                return _isEmpty;
            }
            protected set {
                _isEmpty = value;
                OnPropertyChanged();  
            }
        }

        public LegSide CurrentLegSide { get; protected set; }

        public string ButtonText
        {
            get
            {
                if (!IsEmpty) return "Редактировать";
                else return "Заполнить";
            }
        }

        private bool _panelOpened = false;

        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }

        protected string _title;
        public string Title
        {
            get { return _title; }
            set { this._title = value; }
        }

        private int _levelCount = 1;
        public int LevelCount
        {
            get { return _levelCount; }
            set { this._levelCount = value; }
        }

        public List<string> Source { get; } = new List<string>();
        
        public virtual List<LegSectionViewModel> LegSections { get; set; }

        public DelegateCommand RevertCommand { set; get; }
        public DelegateCommand SaveCommand { set; get; }

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }

        public ICommand OpenPanelCommand { set; private get; }
        public ICommand ClosePanelCommand { set; private get; }

        public SizePanelViewModel CurrentPanelViewModel;

        private UserControl _panel;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserControl Panel
        {
            set { _panel = value; }
        }

        public DelegateCommand AnimationCompleted {get; set; }

        public static bool handled = false;
        public UIElement ui;
        //public Storyboard myS { get; set; }
        private void OpenHandler(object sender, object data)
        {
            if (!handled)
            {
                
                handled = true;
                //var myS = (Storyboard) App.Current.FindResource("Open");
                PanelOpened = true;
                //myS.Begin();
            }
            
            //OpenPanelCommand.Execute(true);
        }

        private void CloseHandler(object sender, object data)
        {
            ClosePanelCommand.Execute(true);
        }

        public void Initialization()
        {
            OpenPanelCommand = new DelegateCommand(() => { PanelOpened = true; });
            ClosePanelCommand = new DelegateCommand(() => { PanelOpened = false; });
            PanelOpened = false;
            //when user picks custom structure
            MessageBus.Default.Subscribe("OpenCustom", OpenHandler);
            MessageBus.Default.Subscribe("CloseCustom", OpenHandler);

            //_sections = new List<BPVHipSectionViewModel>();
            _hasNavigation = false;

            RevertCommand = new DelegateCommand(
                () =>
                {
                    IsEmpty = false;
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            SaveCommand = new DelegateCommand(
                () =>
                {
                    IsEmpty = false;

                    MessageBus.Default.Call("LegDataSaved", this, this.GetType());
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            CurrentPanelViewModel = new SizePanelViewModel(this.Controller);
        }

        public LegPartViewModel(NavigationController controller, LegSide side) : base(controller)
        {
            Initialization();
            CurrentLegSide = side;
            //MessageBus.Default.Subscribe("LegPart", Handler);
            
            Controller = controller;       
        }

        public LegPartViewModel(NavigationController controller) : base(controller)
        {
            //MessageBus.Default.Subscribe("LegPart", Handler);
            
            //_sections = new List<BPVHipSectionViewModel>();
            Controller = controller;
        }

        private void Handler(object sender, object data)
        {
            var vm = (LegPartViewModel) data;
        }

        private void FinishAdding(object parameter)
        {
            var vm = new DialogConfirmStructureViewModel();
            var result = DialogService.DialogService.OpenDialog(vm, parameter as Window);
        }
}
}
