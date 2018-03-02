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
using WpfApp2.Db.Models.GV;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.GV;
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



        //private void RebuildFromFirstToLast()
        //{
        //    if (Controller.CurrentViewModel.Controller.LegViewModel == this && mode == "Normal")
        //    {

        //        //if (Controller.CurrentViewModel.Controller.LegViewModel is PDSVViewModel)
        //        //{


        //        //    MessageBus.Default.Call("RebuildFirstPDSV", null, null);


        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is SFSViewModel)
        //        //{

        //        //    MessageBus.Default.Call("RebuildFirstSFS", this, LegSections[0]);



        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is BPVHipViewModel)
        //        //{

        //        //    MessageBus.Default.Call("RebuildFirstBPV", this, LegSections[0]);


        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is BPVTibiaViewModel)
        //        //{

        //        //    MessageBus.Default.Call("RebuildFirstBPV_Tibia", null, null);


        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is HipPerforateViewModel)
        //        //{
        //        //    MessageBus.Default.Call("RebuildFirstPerforateHip", null, null);




        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is ZDSVViewModel)
        //        //{
        //        //    MessageBus.Default.Call("RebuildFirstZDSV", null, null);

        //        //}

        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is SPSViewModel)
        //        //{
        //        //    MessageBus.Default.Call("RebuildFirstSPS", null, null);
        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is TibiaPerforateViewModel)
        //        //{

        //        //    MessageBus.Default.Call("RebuildFirstPerforateTibia", null, null);

        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is MPVViewModel)
        //        //{
        //        //    MessageBus.Default.Call("RebuildFirstMPV", null, null);


        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is TEMPVViewModel)
        //        //{

        //        //    MessageBus.Default.Call("RebuildFirstTEMPV", null, null);

        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is PPVViewModel)
        //        //{
        //        //    MessageBus.Default.Call("RebuildFirstPPV", null, null);


        //        //}
        //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is GVViewModel)
        //        //{
        //        //    MessageBus.Default.Call("RebuildFirstGV", null, null);


        //        //}

        //    }

        //}



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


        //public virtual ObservableCollection<LegSectionViewModel> LegSections { get; set; }
        public virtual ObservableCollection<LegSectionViewModel> LegSections { get; set; }

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
        private ICommand _savePanelCommand;


        public ICommand ClosePanelCommand
        {
            get { return _сlosePanelCommand; }
            set { _сlosePanelCommand = value; OnPropertyChanged(); }
        }



        private ICommand buff;
        public ICommand SavePanelCommand
        {
            get { return _savePanelCommand; }
            set { _savePanelCommand = value; OnPropertyChanged(); }
        }


        private SizePanelViewModel _currentPanelViewModel;
        public SizePanelViewModel CurrentPanelViewModel
        {
            get { return _currentPanelViewModel; }
            set { _currentPanelViewModel = value; OnPropertyChanged(); }
        }



        private DelegateCommand SaveEditPanelCommand;

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

        private void OpenHandler(object sender, object data)
        {
            CurrentPanelViewModel.TextSaveBTN = "Добавить";
            CurrentPanelViewModel.mode = "Add";
            CurrentPanelViewModel.TextCancleOrResetBTN = "Вернуться";
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
            if (!handled)
            {

                var curPanel = ((LegPartViewModel)Controller.LegViewModel).CurrentPanelViewModel;
                var currentPart = (LegSectionViewModel)sender;


                _lastSender = currentPart;




                _lastSenderType = (Type)data;
                handled = true;
                curPanel.PanelOpened = true;
            }
        }


        LegPartDbStructure LegPrt;


        public bool IsStructEdited(LegPartDbStructure structure)
        {
            if (CurrentPanelViewModel.mode != "Edit")
            {
                return false;
            }

            bool test = false;
            if (CurrentPanelViewModel.Text1 != structure.Text1)
            {
                test = true;
            }


            if (CurrentPanelViewModel.Text2 != structure.Text2)
            {
                test = true;
            }

            if (CurrentPanelViewModel.HasSize != structure.HasSize)
            {

                if (structure.Metrics != CurrentPanelViewModel.SelectedMetricText)
                {
                    test = true;
                }

                if (structure.HasDoubleMetric != CurrentPanelViewModel.HasDoubleSize)
                {
                    test = true;
                }
            }


            return test;
        }


        private void OpenStructRedact(object sender, object data)
        {
            if (Controller.CurrentViewModel.Controller.LegViewModel == this)
            {
                //IsRedactVis = Visibility.Visible;
                //ISAddVis = Visibility.Collapsed;

                buff = SavePanelCommand;

                //var curPanel = ((LegPartViewModel)Controller.LegViewModel).CurrentPanelViewModel;
                var currentPart = (LegSectionViewModel)sender;


                LegPartDbStructure structure = currentPart.SelectedValue;
                CurrentPanelViewModel.LegPrt = structure;
                CurrentPanelViewModel.mode = "Edit";
                LegPrt = structure;
                CurrentLegSide = CurrentLegSide;




                _lastSender = currentPart;




                _lastSenderType = (Type)data;

                CurrentPanelViewModel.PanelOpened = true;

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



                }
                CurrentPanelViewModel.TextSaveBTN = "Вернуться";
                CurrentPanelViewModel.TextCancleOrResetBTN = "Сбросить";

                // CurrentPanelViewModel.Text1 = section.Se
                //SavePanelCommand = new DelegateCommand(() =>
                //{
                //    var panel = CurrentPanelViewModel;
                //    if (!string.IsNullOrWhiteSpace(panel.Text1) || !string.IsNullOrWhiteSpace(panel.Text2))
                //    {
                //        //CurrentLegSide = CurrentLegSide;
                //        CurrentPanelViewModel.PanelOpened = false;
                //        handled = false;
                //        LegPartDbStructure newStruct = GetPanelStructureForEdit();
                //        newStruct.Custom = false;
                //        //   LegPartDbStructure.legPrt. = newStruct;\

                //        //if (Controller.CurrentViewModel.Controller.LegViewModel is PDSVViewModel)
                //        //{
                //        //    foreach (var x in Data.PDSVHips.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }

                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is SFSViewModel)
                //        //{

                //        //    foreach (var x in Data.SFSHips.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is BPVHipViewModel)
                //        //{
                //        //    foreach (var x in Data.BPVHips.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is BPVTibiaViewModel)
                //        //{
                //        //    foreach (var x in Data.BPV_Tibia.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is HipPerforateViewModel)
                //        //{

                //        //    foreach (var x in Data.Perforate_hip.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is ZDSVViewModel)
                //        //{
                //        //    foreach (var x in Data.ZDSV.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}

                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is SPSViewModel)
                //        //{
                //        //    foreach (var x in Data.SPS.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is TibiaPerforateViewModel)
                //        //{
                //        //    foreach (var x in Data.Perforate_shin.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is MPVViewModel)
                //        //{
                //        //    foreach (var x in Data.MPV.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is TEMPVViewModel)
                //        //{
                //        //    foreach (var x in Data.TEMPV.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is PPVViewModel)
                //        //{
                //        //    foreach (var x in Data.PPV.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        //else if (Controller.CurrentViewModel.Controller.LegViewModel is GVViewModel)
                //        //{
                //        //    foreach (var x in Data.GV.GetAll)
                //        //    {
                //        //        if (x.Id == LegPrt.Id)
                //        //        {
                //        //            LegPrt = x;
                //        //            break;
                //        //        }
                //        //    }
                //        //}


                //        //LegPrt.HasDoubleMetric = newStruct.HasDoubleMetric;
                //        //LegPrt.HasSize = newStruct.HasSize;
                //        //LegPrt.Level = newStruct.Level;
                //        //LegPrt.Metrics = newStruct.Metrics;
                //        //LegPrt.NameContext = newStruct.NameContext;
                //        //LegPrt.Size = newStruct.Size;
                //        //LegPrt.Text1 = newStruct.Text1;
                //        //LegPrt.Text2 = newStruct.Text2;
                //        //LegPrt.ToNextPart = newStruct.ToNextPart;


                //        //SavePanelCommand


                //        //Data.MPV.Add((MPVStructure)newStruct);

                //        Data.Complete();
                //        //         MessageBus.Default.Call("RebuildFirstPDSV", null, null);
                //        RebuildFromFirstToLast();

                //        //MessageBus.Default.Call("RebuildLegSectionViewModel", this, CurrentPanelViewModel.legPrt);
                //        //  _lastSender.StructureSource.Add(newStruct);
                //        // _lastSender.SelectedValue = newStruct;
                //        CurrentPanelViewModel.PanelOpened = false;
                //        handled = false;
                //        SavePanelCommand = buff;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Не все поля заполнены");
                //    }
                //});



                ClosePanelCommand = new DelegateCommand(() =>
                {



                    if (structure.Text1 != null)
                        CurrentPanelViewModel.Text1 = structure.Text1;
                    else
                        CurrentPanelViewModel.Text1 = "";
                    if (structure.Text2 != null)
                        CurrentPanelViewModel.Text2 = structure.Text2;
                    else
                        CurrentPanelViewModel.Text2 = "";
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
                    }
                    else
                    {

                        CurrentPanelViewModel.SelectedMetricText = "";

                        CurrentPanelViewModel.HasDoubleSize = false;
                        CurrentPanelViewModel.HasSize = false;
                    }
                    CurrentPanelViewModel.TextSaveBTN = "Вернуться";


                });

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

        //public LegPartDbStructure GetPanelStructureForEdit()
        //{
        //    var newStr = (LegPartDbStructure)Activator.CreateInstance(LegSections[0].StructureSource[0].GetType());
        //    var panel = CurrentPanelViewModel;

        //    newStr.Text1 = panel.Text1;
        //    newStr.Text2 = panel.Text2;
        //    newStr.HasSize = panel.HasSize;
        //    newStr.HasDoubleMetric = panel.HasDoubleSize;




        //    if (panel.HasSize)
        //    {
        //        bool test = true;
        //        foreach (var metric in Data.Metrics.GetAll)
        //        {
        //            if (metric.Str == panel.SelectedMetricText)
        //            {
        //                test = false;
        //                newStr.Size = metric.Id;
        //                newStr.Metrics = metric.Str;
        //                break;
        //            }
        //        }
        //        if (test)
        //        {
        //            Metrics newMetric = new Metrics();
        //            newMetric.Str = panel.SelectedMetricText;
        //            Data.Metrics.Add(newMetric);
        //            Data.Complete();
        //            newStr.Size = newMetric.Id;
        //            newStr.Metrics = newMetric.Str;
        //        }

        //    }
        //    else newStr.Size = null;
        //    newStr.Level = CurrentPanelViewModel.LegPrt.Level;
        //    newStr.Custom = true;

        //    return newStr;


        //}

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
                //IsRedactVis = Visibility.Collapsed;
                //ISAddVis = Visibility.Visible;
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
            //IsRedactVis = Visibility.Collapsed;
            //ISAddVis = Visibility.Visible;
            Initialization();
            LegSections = new ObservableCollection<LegSectionViewModel>();
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
