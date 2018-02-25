using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp2.Db.Models.LegParts;
using WpfApp2.LegParts.DialogConfirmStructure;
using WpfApp2.LegParts.VMs;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts
{
    public class LegPartViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public string mode = "Normal";
        public string Comment { get; set; }

        public da_Way SelectedWayType { get; set; }


        private float _fF_length;
        public float FF_length { get { return _fF_length; } set { _fF_length = value; OnPropertyChanged(); } }







        private bool _isEmpty = true;
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            set
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
            set { this._title = value; OnPropertyChanged(); }
        }

        private int _levelCount = 1;
        public int LevelCount
        {
            get { return _levelCount; }
            set { this._levelCount = value; OnPropertyChanged(); }
        }

        public List<string> Source { get; } = new List<string>();



        //private LegSectionViewModel _selectedSection;

        //public LegSectionViewModel SelectedSection
        //{
        //    get { return _selectedSection; }
        //    set { _selectedSection = value; }
        //}



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

        private ICommand _сlosePanelCommand;

        private Visibility _isRedactVis;
       private Visibility _iSAddVis;

       public Visibility IsRedactVis
        {
            get { return _isRedactVis; }
            set { _isRedactVis = value; OnPropertyChanged(); }
        }
        public Visibility ISAddVis
        {
            get { return _iSAddVis; }
            set { _iSAddVis = value; OnPropertyChanged(); }
        }

        public ICommand ClosePanelCommand
        {
            get { return _сlosePanelCommand; }
            set { _сlosePanelCommand = value; OnPropertyChanged(); }
        }
        public ICommand SavePanelCommand { protected set; get; }


        private SizePanelViewModel _currentPanelViewModel;
        public SizePanelViewModel CurrentPanelViewModel
        {
            get { return _currentPanelViewModel; }
            set { _currentPanelViewModel = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand AnimationCompleted { get; set; }

        protected static LegSectionViewModel _lastSender;

        protected static Type _lastSenderType;

        public static bool handled = false;
        public UIElement ui;
        //public Storyboard myS { get; set; }
        private void OpenHandler(object sender, object data)
        {
            if (!handled)
            {
                var curPanel = ((LegPartViewModel)Controller.LegViewModel).CurrentPanelViewModel;
                var currentPart = (LegSectionViewModel)sender;


                _lastSender = currentPart;

                //  _lastSenderNewAnswer


                _lastSenderType = (Type)data;
                handled = true;
                curPanel.PanelOpened = true;
            }
        }
        private void OpenStructRedact(object sender, object data)
        {
            if (Controller.CurrentViewModel.Controller.LegViewModel == this)
            {
                IsRedactVis = Visibility.Visible;
                ISAddVis = Visibility.Collapsed;
                ClosePanelCommand = new DelegateCommand(() =>
                {
                    CurrentPanelViewModel.PanelOpened = false;
                    handled = false;

                });


                CurrentLegSide = CurrentLegSide;

                CurrentPanelViewModel.PanelOpened = true;
                LegPartDbStructure structure = (LegPartDbStructure)sender;

                if (structure.Text1 != null)
                    CurrentPanelViewModel.Text1 = structure.Text1;
                if (structure.Text2 != null)
                    CurrentPanelViewModel.Text2 = structure.Text2;
                if (structure.HasSize)
                {
                    CurrentPanelViewModel.HasSize = true;
                    foreach (Metrics x in CurrentPanelViewModel.Dimentions)
                    {
                        if (x.Str == structure.Metrics)
                        {
                            CurrentPanelViewModel.SelectedMetricText = x.Str;
                            CurrentPanelViewModel.SelectedMetric = x;
                        }
                    }
                    if (structure.HasDoubleMetric)
                    {
                        CurrentPanelViewModel.HasDoubleSize = true;
                    }
                    // bool test = true;
                    //foreach (var metric in Data.Metrics.GetAll)
                    //{
                    //    if (metric.Str == panel.SelectedMetricText)
                    //    {
                    //        test = false;
                    //        newStr.Size = metric.Id;
                    //        newStr.Metrics = metric.Str;
                    //        break;
                    //    }
                    //}
                    //if (test)
                    //{
                    //    Metrics newMetric = new Metrics();
                    //    newMetric.Str = panel.SelectedMetricText;
                    //    Data.Metrics.Add(newMetric);
                    //    Data.Complete();
                    //    newStr.Size = newMetric.Id;
                    //    newStr.Metrics = newMetric.Str;
                    //}



                    //  CurrentPanelViewModel.


                }



                // CurrentPanelViewModel.Text1 = section.Se


            }
        }
        public LegPartDbStructure GetPanelStructure()
        {
            var newStr = (LegPartDbStructure)Activator.CreateInstance(LegSections[0].StructureSource[0].GetType());
            var panel = CurrentPanelViewModel;

            newStr.Text1 = panel.Text1;
            newStr.Text2 = panel.Text2;
            newStr.HasSize = panel.HasSize;
            newStr.HasDoubleMetric = panel.HasDoubleSize;




            if (panel.HasSize)
            {
                bool test = true;
                foreach (var metric in Data.Metrics.GetAll)
                {
                    if (metric.Str == panel.SelectedMetricText)
                    {
                        test = false;
                        newStr.Size = metric.Id;
                        newStr.Metrics = metric.Str;
                        break;
                    }
                }
                if (test)
                {
                    Metrics newMetric = new Metrics();
                    newMetric.Str = panel.SelectedMetricText;
                    Data.Metrics.Add(newMetric);
                    Data.Complete();
                    newStr.Size = newMetric.Id;
                    newStr.Metrics = newMetric.Str;
                }

            }
            else newStr.Size = null;
            newStr.Level = _lastSender.ListNumber;
            newStr.Custom = true;

            return newStr;


        }

        private void SetModeHandler(object sender, object data)
        {

            mode = (string)data;

        }
        private void CloseHandler(object sender, object data)
        {

            CurrentPanelViewModel.PanelOpened = false;

        }

        public void Initialization()
        {

            MessageBus.Default.Subscribe("OpenStructRedact", OpenStructRedact);
            MessageBus.Default.Subscribe("SetMode", SetModeHandler);
            CurrentPanelViewModel = new SizePanelViewModel(this);


            ClosePanelCommand = new DelegateCommand(() =>
            {
                if (_lastSender.SelectedValue == null)
                {
                    foreach (var structr in _lastSender.StructureSource)
                    {
                        if (structr.Text1 == "" && structr.Text2 == "")
                        {
                            _lastSender.SelectedValue = structr;
                        }
                    }
                }
                else
                {
                    LegSections[_lastSender.ListNumber - 1].SelectedValue = _lastSender.SelectedValue;
                }
                CurrentPanelViewModel.PanelOpened = false;
                handled = false;

            });



            CurrentPanelViewModel.PanelOpened = false;
            //when user picks custom structure
            MessageBus.Default.Subscribe("OpenCustom", OpenHandler);

            _hasNavigation = false;

            OpenPanelCommand = new DelegateCommand(() =>
            {
                IsRedactVis = Visibility.Collapsed;
                ISAddVis = Visibility.Visible;
                CurrentLegSide = CurrentLegSide;
                CurrentPanelViewModel.PanelOpened = true;
                ClosePanelCommand = new DelegateCommand(() =>
                {
                    if (_lastSender.SelectedValue == null)
                    {
                        foreach (var structr in _lastSender.StructureSource)
                        {
                            if (structr.Text1 == "" && structr.Text2 == "")
                            {
                                _lastSender.SelectedValue = structr;
                            }
                        }
                    }
                    else
                    {
                        LegSections[_lastSender.ListNumber - 1].SelectedValue = _lastSender.SelectedValue;
                    }
                    CurrentPanelViewModel.PanelOpened = false;
                    handled = false;

                });
            });
            RevertCommand = new DelegateCommand(
                () =>
                {
                    // IsEmpty = false;
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );


        }

        public LegPartViewModel(NavigationController controller, LegSide side) : base(controller)
        {
            IsRedactVis = Visibility.Collapsed;
            ISAddVis = Visibility.Visible;
            Initialization();
            LegSections = new List<LegSectionViewModel>();
            LostFocusOnProtiagnosy = new DelegateCommand<object>(
     (sender) =>
     {

         if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
             ((TextBox)sender).Text = "0";



     }
 ); ClickOnProtiagnosy = new DelegateCommand<object>(
    (sender) =>
    {

        if (((TextBox)sender).Text == "0")
            ((TextBox)sender).Text = "";



    }
);

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

        private string _summary;
        public string Summary
        {
            get
            {
                var str = "";
                foreach (var section in LegSections)
                {
                    if (section.Text1 != "")
                        str += section.Text1 + " ";
                    if (section.HasSize)
                    {
                        str += section.Size + " " + section.CurrentEntry.Size.ToString() + " ";
                        str += section.SizeToText;
                    }
                    if (section.Text2 != "")
                        str += section.Text2;

                    if (section.CurrentEntry.Comment != "")
                    {
                        str += "\n";
                        str += section.CurrentEntry.Comment;
                    }

                    str += "\n";
                }
                _summary = str;
                return str;
            }
            set
            {
                _summary = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand<object> LostFocus { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }
        public DelegateCommand<object> LostFocusOnProtiagnosy { get; private set; }
        public DelegateCommand<object> ClickOnProtiagnosy { get; private set; }
    }
}
