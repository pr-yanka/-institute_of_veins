using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp2.LegParts.DialogConfirmStructure;
using WpfApp2.LegParts.VMs;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts
{
    public class LegPartViewModel : ViewModelBase
    {
        public bool PanelOpened { get; set; }

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

       // private ICommand _openPanelCommand = null;
        public ICommand OpenPanelCommand { set; private get; }

        public SizePanelViewModel CurrentPanelViewModel;

        private UserControl _panel;
        public UserControl Panel
        {
            set { _panel = value; }
        }

        public DelegateCommand AnimationCompleted {get; set; }

        private void OpenPanel(object parameter)
        {
            PanelOpened = true;
            /*Storyboard storyboard1 = new Storyboard();

            DelegateCommand AnimationCompleted = new DelegateCommand(
                () => { PanelOpened = true; }
            );

            ((UIElement)_panel).RenderTransform = (Transform)new TranslateTransform();
            DoubleAnimation doubleAnimation1 = new DoubleAnimation();
            doubleAnimation1.Duration = new Duration(new TimeSpan(0, 0, 2));
            doubleAnimation1.To = -200;
            doubleAnimation1.AutoReverse = true;
            doubleAnimation1.RepeatBehavior = RepeatBehavior.Forever;

            Storyboard.SetTarget((Timeline)doubleAnimation1, (DependencyObject)_panel.RenderTransform);
            Storyboard.SetTargetProperty((Timeline)doubleAnimation1, new PropertyPath("X"));
            ((ICollection<Timeline>)storyboard1.Children).Add((Timeline)doubleAnimation1);*/

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
            //this._openPanelCommand = new RelayCommand(OpenPanel);
            OpenPanelCommand = new DelegateCommand(() => { PanelOpened = true; });
            PanelOpened = false;

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
