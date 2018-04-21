using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.LegParts.DialogConfirmStructure;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts
{
    public class LegPartViewModel : ViewModelBase, INotifyPropertyChanged
    {



        public string mode = "Normal";
        private string _comment; public string commentSave;
        public string Comment { get { return _comment; } set { _comment = value; OnPropertyChanged(); } }

        public da_Way SelectedWayType { get; set; }
        public da_Way SelectedWayTypeSave { get; set; }


        public float FF_lengthSave;
        private float _fF_length;
        public float FF_length { get { return _fF_length; } set { _fF_length = value; OnPropertyChanged(); } }



        public virtual ViewModelBase CurrentPanelViewModelWaySelect { get; set; }
        private bool _panelOpened;
        public bool PanelOpened
        {
            get
            {
                return _panelOpened;
            }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }



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
        public virtual List<LegSectionViewModel> LegSectionsSaved { get; set; }
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
            try
            {
                if (Controller.CurrentViewModel.Controller.LegViewModel == this)
                {
                    LevelSelected = ((LegSectionViewModel)sender).StructureSource[0].Level;
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
                         if (_lastSender.ListNumber == 0)
                         {
                             MessageBus.Default.Call("SetAdditionalStructDefault", _lastSender.SelectedValue, null);
                         }
                         else
                         {
                             LegSections[_lastSender.ListNumber - 1].SelectedValue = _lastSender.SelectedValue;
                         }
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
            }
            catch
            {
                CurrentPanelViewModel.PanelOpened = false;
                handled = false;
            }
        }


        LegPartDbStructure LegPrt;

        public int LevelSelected;

        public bool testOnUnique(LegPartDbStructure structure)
        {
            //if (structure.HasDoubleMetric == CurrentPanelViewModel.SavedLegPrt.HasDoubleMetric
            //       && structure.HasSize == CurrentPanelViewModel.SavedLegPrt.HasSize
            //       && structure.Metrics == CurrentPanelViewModel.SavedLegPrt.Metrics
            //        && structure.NameContext == CurrentPanelViewModel.SavedLegPrt.NameContext
            //          && structure.Size == CurrentPanelViewModel.SavedLegPrt.Size
            //            && structure.Text1 == CurrentPanelViewModel.SavedLegPrt.Text1
            //              && structure.Text2 == CurrentPanelViewModel.SavedLegPrt.Text2
            //              && structure.ToNextPart == CurrentPanelViewModel.SavedLegPrt.ToNextPart
            //              && structure.Custom == CurrentPanelViewModel.SavedLegPrt.Custom)
            //{
            //    return true;
            //}
            //if (structure == null)
            //    return false;
            if (Controller.CurrentViewModel.Controller.LegViewModel == this)
            {
                if (LevelSelected != 0)
                {
                    foreach (var x in LegSections[LevelSelected - 1].StructureSource)
                    {
                        if (mode == "Edit")
                        {
                            if (x.HasDoubleMetric == CurrentPanelViewModel.HasDoubleSize
                                && x.HasSize == CurrentPanelViewModel.HasSize
                                 && (x.Text1 == CurrentPanelViewModel.Text1 || (string.IsNullOrWhiteSpace(x.Text1) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text1)))
                                   && (x.Text2 == CurrentPanelViewModel.Text2 || (string.IsNullOrWhiteSpace(x.Text2) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text2)))
                                && x.Id != structure.Id)
                            {
                                if (x.HasSize == true)
                                {
                                    if ((x.Metrics == CurrentPanelViewModel.SelectedMetricText || string.IsNullOrWhiteSpace(x.Metrics) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.SelectedMetricText)))
                                    {
                                        MessageBox.Show("Такое описание уже существует!");

                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }


                                MessageBox.Show("Такое описание уже существует!");

                                return false;

                            }
                        }
                        else
                        {
                            if (x.HasDoubleMetric == CurrentPanelViewModel.HasDoubleSize
                                   && x.HasSize == CurrentPanelViewModel.HasSize
                                   && (x.Text1 == CurrentPanelViewModel.Text1 || (string.IsNullOrWhiteSpace(x.Text1) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text1)))
                                   && (x.Text2 == CurrentPanelViewModel.Text2 || (string.IsNullOrWhiteSpace(x.Text2) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text2))))

                            {

                                if (x.HasSize == true)
                                {
                                    if ((x.Metrics == CurrentPanelViewModel.SelectedMetricText || string.IsNullOrWhiteSpace(x.Metrics) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.SelectedMetricText)))
                                    {
                                        MessageBox.Show("Такое описание уже существует!");

                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }


                                MessageBox.Show("Такое описание уже существует!");

                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }
        public bool IsStructEdited(LegPartDbStructure structure)
        {


            if (CurrentPanelViewModel.mode != "Edit")
            {







                return true;
            }

            bool test = false;
            if ((CurrentPanelViewModel.Text1 != structure.Text1))
            {
                if (structure.Text1 == null && CurrentPanelViewModel.Text1 == "" || structure.Text1 == "" && CurrentPanelViewModel.Text1 == null) { }
                else
                {
                    test = true;
                }
            }


            if ((CurrentPanelViewModel.Text2 != structure.Text2))
            {
                if (structure.Text2 == null && CurrentPanelViewModel.Text2 == "" || structure.Text2 == "" && CurrentPanelViewModel.Text2 == null) { }
                else
                {
                    test = true;
                }

            }

            if (CurrentPanelViewModel.HasSize != structure.HasSize)
            {
                test = true;

            }
            if (structure.Metrics != CurrentPanelViewModel.SelectedMetricText && CurrentPanelViewModel.HasSize == true)
            {
                test = true;
            }

            if (structure.HasDoubleMetric != CurrentPanelViewModel.HasDoubleSize)
            {
                test = true;
            }

            if (test == false)
            {
                //CurrentPanelViewModel.SelectedMetricText = "";

                //CurrentPanelViewModel.HasDoubleSize = false;
                //CurrentPanelViewModel.HasSize = false;
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
                LevelSelected = structure.Level;
                CurrentPanelViewModel.LegPrt = structure;
                CurrentPanelViewModel.SavedLegPrt = structure;
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

            if (panel.SelectedMetricText == null)
            { panel.SelectedMetricText = ""; }


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
            CurrentPanelViewModel.SelectedMetricText = "";

            CurrentPanelViewModel.HasDoubleSize = false;
            CurrentPanelViewModel.HasSize = false;
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
            PanelOpened = false;
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
                    bool test = true;
                    try
                    {
                        FF_length = FF_lengthSave;
                        SelectedWayType = SelectedWayTypeSave;
                        if (LegSectionsSaved != null)
                        {
                            Comment = commentSave;
                            for (int i = 0; i < LegSections.Count; i++)
                            {
                                LegSections[i].Comment = LegSectionsSaved[i].Comment;
                                LegSections[i].Size = LegSectionsSaved[i].Size;
                                LegSections[i].Size2 = LegSectionsSaved[i].Size2;
                                LegSections[i].Text1 = LegSectionsSaved[i].Text1;
                                LegSections[i].Text2 = LegSectionsSaved[i].Text2;
                                LegSections[i].SelectedValue = LegSectionsSaved[i].SelectedValue;
                                LegSections[i].CurrentEntry = LegSectionsSaved[i].CurrentEntry;
                                if (LegSections[i].SelectedValue != null)
                                {
                                    test = false;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < LegSections.Count; i++)
                            {
                                if (LegSections[i].SelectedValue != null)
                                {
                                    test = false;
                                }
                            }
                        }
                    }
                    catch { }
                    if (!test)
                        IsEmpty = false;
                    else
                        IsEmpty = true;
                    MessageBus.Default.Call("SetAllDefaultForCreateObsled", null, null);
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
         {
             ((TextBox)sender).Text = "0";
             FF_length = 0;
         }


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
