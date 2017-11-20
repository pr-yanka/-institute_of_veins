using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WpfApp2.LegParts.DialogConfirmStructure;
using WpfApp2.LegParts.VMs;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts
{
    public class LegPartViewModel : ViewModelBase
    {
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

        private ICommand _openPanelCommand = null;
        public ICommand OpenPanelCommand { set; get; }

        public SizePanelViewModel CurrentPanelViewModel;

        private void OpenPanel(object parameter)
        {
            //переписать в хaml темплейт?
            /*
            if (e.ClickCount != 2)
                return;

            Storyboard sb = this.FindResource("Open") as Storyboard;
            sb.Completed += (o, args) =>
            {
                ShadowOverlay.Visibility = Visibility.Visible;
                MainGrid.IsEnabled = false;
            };
            Storyboard.SetTarget(sb, this.newControl1);
            sb.Begin();
            */
        }

        public LegPartViewModel(NavigationController controller) : base(controller)
        {
            this._openPanelCommand = new RelayCommand(OpenPanel);

            //_sections = new List<BPVHipSectionViewModel>();
            _hasNavigation = false;
            Controller = controller;

            RevertCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            SaveCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            CurrentPanelViewModel = new SizePanelViewModel(this.Controller);
        }

        private void FinishAdding(object parameter)
        {
            var vm = new DialogConfirmStructureViewModel();
            var result = DialogService.DialogService.OpenDialog(vm, parameter as Window);
        }
}
}
