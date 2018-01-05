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
using WpfApp2.Db.Models;
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
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            protected set
            {
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

        public ICommand OpenPanelCommand { protected set; get; }
        public ICommand ClosePanelCommand { protected set; get; }

        public SizePanelViewModel CurrentPanelViewModel { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand AnimationCompleted { get; set; }

        protected LegSectionViewModel _lastSender;
        protected Type _lastSenderType;

        public static bool handled = false;
        public UIElement ui;
        //public Storyboard myS { get; set; }
        private void OpenHandler(object sender, object data)
        {
            if (!handled)
            {
                var currentPart = (LegSectionViewModel)sender;
                _lastSender = (LegSectionViewModel)sender;
                _lastSenderType = (Type)data;
                handled = true;
                CurrentPanelViewModel.PanelOpened = true;
            }
        }

        private LegPartDbStructure GetPanelStructure()
        {

            var newStr = (LegPartDbStructure)Activator.CreateInstance(_lastSender.SelectedValue.GetType());
            var panel = CurrentPanelViewModel;
            newStr.Text1 = panel.Text1;
            newStr.Text2 = panel.Text2;
            newStr.HasSize = panel.HasSize;
            if (panel.HasSize)
            {
                newStr.Size = panel.SelectedMetric.Id;
                newStr.Metrics = panel.SelectedMetric.Str;
            }
            else newStr.Size = null;
            newStr.Level = _lastSender.ListNumber;
            newStr.Custom = true;

            return newStr;
        }


        private void CloseHandler(object sender, object data)
        {
            CurrentPanelViewModel.PanelOpened = false;
        }

        public void Initialization()
        {
            CurrentPanelViewModel = new SizePanelViewModel(this);
            OpenPanelCommand = new DelegateCommand(() => {
                CurrentPanelViewModel.PanelOpened = true;
            });

            ClosePanelCommand = new DelegateCommand(() => {
                CurrentPanelViewModel.PanelOpened = false;
                handled = false;
                var newStruct = GetPanelStructure();

                _lastSender.StructureSource.Add(newStruct);
                _lastSender.SelectedValue = newStruct;
                _lastSender.DeleteCustom();

            });

            CurrentPanelViewModel.PanelOpened = false;
            //when user picks custom structure
            MessageBus.Default.Subscribe("OpenCustom", OpenHandler);

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

                    List<int?> ids = new List<int?>();

                    foreach (var leg in LegSections)
                    {
                        //никогда так не делайте
                        if (leg.IsVisible == Visibility.Visible && leg.ListNumber != 1 && leg.SelectedValue != null)
                            ids.Add(leg.SelectedValue.Id);
                    }

                    var combo = Data.BPVCombos.FindCombo(LegSections[0].SelectedValue.Id, ids);

                    MessageBus.Default.Call("LegDataSaved", this, this.GetType());
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );


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
            var vm = (LegPartViewModel)data;
        }

        private void FinishAdding(object parameter)
        {
            var vm = new DialogConfirmStructureViewModel();
            var result = DialogService.DialogService.OpenDialog(vm, parameter as Window);
        }
    }
}
