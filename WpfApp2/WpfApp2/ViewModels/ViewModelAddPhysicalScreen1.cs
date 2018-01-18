using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;
using System.Windows.Input;
using WpfApp2.DialogPreOperation;
using WpfApp2.DialogService;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.Messaging;
using WpfApp2.Db.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddPhysical : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<string> BpvLeftstr
        {
            get
            {
                return _bpvLeftstr;
            }
            set
            {
                _bpvLeftstr = value;
                OnPropertyChanged();
            }
        }

        public List<string> SFSLeftstr
        {
            get
            {
                return _sfsLeftstr;
            }
            set
            {
                _sfsLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> SFSRightstr
        {
            get
            {
                return _sfsRightstr;
            }
            set
            {
                _sfsRightstr = value;
                OnPropertyChanged();
            }
        }

        public SFSHipEntryFull RightSFSEntryFull { get; private set; }
        public SFSHipEntryFull LeftSFSEntryFull { get; private set; }
        private List<string> _sfsRightstr;
        private List<string> _sfsLeftstr;
        private List<string> _bpvLeftstr;
        private ObservableCollection<Visibility> _isVisibleBPVleft;
        public ObservableCollection<Visibility> IsVisibleBPVleft
        {
            get
            {
                return _isVisibleBPVleft;
            }
            set
            {
                _isVisibleBPVleft = value;
                OnPropertyChanged();
            }
        }
        public List<string> BpvRightstr
        {
            get
            {
                return _bpvRightstr;
            }
            set
            {
                _bpvRightstr = value;
                OnPropertyChanged();
            }
        }

        private List<string> _bpvRightstr;


        private ObservableCollection<Visibility> _isVisibleSFSleft;
        public ObservableCollection<Visibility> IsVisibleSFSleft
        {
            get
            {
                return _isVisibleSFSleft;
            }
            set
            {
                _isVisibleSFSleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleSFSRight;
        public ObservableCollection<Visibility> IsVisibleSFSRight
        {
            get
            {
                return _isVisibleSFSRight;
            }
            set
            {
                _isVisibleSFSRight = value;
                OnPropertyChanged();
            }
        }





        private ObservableCollection<Visibility> _isVisibleBPVRight;
        public ObservableCollection<Visibility> IsVisibleBPVRight
        {
            get
            {
                return _isVisibleBPVRight;
            }
            set
            {
                _isVisibleBPVRight = value;
                OnPropertyChanged();
            }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                float buf = 0f;
                if (value.Contains(",")) { _weight = value; }
                else if (value == "")
                { _weight = ""; }
                else if (float.TryParse(value, out buf)) { _weight = buf.ToString(); }

                if (float.TryParse(Weight, out buf) && float.TryParse(Growth, out buf)) ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100)); OnPropertyChanged();
            }
        }

        private string _growth;
        public string Growth
        {
            get { return _growth; }
            set
            {
                float buf = 0f;
                if (value.Contains(",")) { _growth = value; } else if (value == "") { _growth = ""; } else if (float.TryParse(value, out buf)) { _growth = buf.ToString(); }
                if (float.TryParse(Weight, out buf) && float.TryParse(Growth, out buf)) ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100)); OnPropertyChanged();
            }
        }

        private double _itm;
        public double ITM { get { return Math.Round(_itm, 3); } set { if (float.Parse(Growth) != 0) _itm = value; OnPropertyChanged(); } }

        private string _textTip;
        public string TextTip { get { return _textTip; } set { _textTip = value; OnPropertyChanged(); } }
        public DelegateCommand IMTCOUNT { get; protected set; }
        public DelegateCommand ClickOnTextTip { get; protected set; }

        public DelegateCommand ClickOnWeight { get; protected set; }
        public DelegateCommand ClickOnGrowth { get; protected set; }

        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToSymptomsAddCommand { get; protected set; }

        public DelegateCommand ToRightBPVHipCommand { get; protected set; }
        public DelegateCommand ToLeftBPVHipCommand { get; protected set; }

        public DelegateCommand ToLeftPDSVCommand { get; protected set; }
        public DelegateCommand ToLeftZDSVCommand { get; protected set; }
        public DelegateCommand ToLeftPerforateCommand { get; protected set; }

        public DelegateCommand ToLeftTibiaPerforateCommand { get; protected set; }
        public DelegateCommand ToLeftBPVTibiaCommand { get; protected set; }
        public DelegateCommand ToLeftSPSCommand { get; protected set; }

        public DelegateCommand ToRightSFSCommand { get; protected set; }
        public DelegateCommand ToLeftSFSCommand { get; protected set; }

        public DelegateCommand ToRightPDSVCommand { get; protected set; }
        public DelegateCommand ToRightZDSVCommand { get; protected set; }
        public DelegateCommand ToRightPerforateCommand { get; protected set; }
        public DelegateCommand ToLeftDiagCommand { get; protected set; }
        public DelegateCommand ToRightDiagCommand { get; protected set; }
        public DelegateCommand ToRightTibiaPerforateCommand { get; protected set; }
        public DelegateCommand ToRightBPVTibiaCommand { get; protected set; }
        public DelegateCommand ToRightSPSCommand { get; protected set; }

        public DelegateCommand ToAddRecomendationsCommand { get; protected set; }

        public DelegateCommand ToDiagnosisCommand { get; protected set; }

        public Patient CurrentPatient { get; protected set; }
        public string initials { get; protected set; }

        public List<ComplainsDataSource> ComplainsList { get; set; }
        public List<RecomendationsDataSource> RecomendationsList { get; set; }
        public List<DiagnosisDataSource> DiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> LeftDiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> RightDiagnosisList { get; set; }

        private void SetComplainsList(object sender, object data)
        {
            ComplainsList = (List<ComplainsDataSource>)data;
        }
        private void SetRecomendationsList(object sender, object data)
        {
            RecomendationsList = (List<RecomendationsDataSource>)data;
        }
        private void SetDiagnosisList(object sender, object data)
        {
            DiagnosisList = (List<DiagnosisDataSource>)data;
        }

        private void SetCurrentPatientID(object sender, object data)
        {
            Weight = "0";
            Growth = "0";
            TextTip = "Текст пометки";
            CurrentPatient = Data.Patients.Get((int)data);
            initials = " " + CurrentPatient.Sirname.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

        }

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }


        public BPVHipEntryFull LeftBPVEntryFull { get; protected set; }
        public BPVHipEntryFull RightBPVEntryFull { get; protected set; }

        public BPVHipViewModel LeftBPVHip { get; protected set; }
        public SFSViewModel LeftSFS { get; protected set; }
        public PDSVViewModel LeftPDSV { get; protected set; }
        public ZDSVViewModel LeftZDSV { get; protected set; }
        public HipPerforateViewModel LeftPerforate { get; protected set; }
        public TibiaPerforateViewModel LeftTibiaPerforate { get; protected set; }
        public BPVTibiaViewModel LeftBPVTibia { get; protected set; }
        public SPSViewModel LeftSPS { get; protected set; }

        public BPVHipViewModel RightBPVHip { get; protected set; }
        public SFSViewModel RightSFS { get; protected set; }
        public PDSVViewModel RightPDSV { get; protected set; }
        public ZDSVViewModel RightZDSV { get; protected set; }
        public HipPerforateViewModel RightPerforate { get; protected set; }
        public TibiaPerforateViewModel RightTibiaPerforate { get; protected set; }
        public BPVTibiaViewModel RightBPVTibia { get; protected set; }
        public SPSViewModel RightSPS { get; protected set; }

        private void FinishAdding(object parameter)
        {

            DialogViewModelBase vm =
                new DialogYesNo.DialogYesNoViewModel("Назначить операцию?");
            DialogResult result =
                DialogService.DialogService.OpenDialog(vm, parameter as Window);

            if (result == DialogResult.Yes)
            {
                vm = new DialogPreOperationViewModel();
                result = DialogService.DialogService.OpenDialog(vm, parameter as Window);
            }
        }

        private void SetRightDiagnosisList(object sender, object data)
        {
            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            foreach (var diag in (List<DiagnosisDataSource>)data)
            { RightDiagnosisList.Add(diag); }
        }
        private void SetLeftDiagnosisList(object sender, object data)
        {
            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            foreach (var diag in (List<DiagnosisDataSource>)data)
            { LeftDiagnosisList.Add(diag); }

        }
        public ViewModelAddPhysical(NavigationController controller) : base(controller)
        {
            BpvLeftstr = new List<string>();
            BpvRightstr = new List<string>();
            SFSLeftstr = new List<string>();
            SFSRightstr = new List<string>();
            var IsVisibleBPVleftBuf = new ObservableCollection<Visibility>();
            IsVisibleBPVRight = new ObservableCollection<Visibility>();
            IsVisibleBPVleft = new ObservableCollection<Visibility>();
            IsVisibleSFSRight = new ObservableCollection<Visibility>();
            IsVisibleSFSleft = new ObservableCollection<Visibility>();

            for (int i = 0; i < 6; ++i)
            {
                IsVisibleBPVleftBuf.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleBPVRight.Add(Visibility.Collapsed);
            }

            for (int i = 0; i < 6; ++i)
            {
                IsVisibleSFSleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleSFSRight.Add(Visibility.Collapsed);
            }

            IsVisibleBPVleft = IsVisibleBPVleftBuf;

            MessageBus.Default.Subscribe("LegDataSaved", Handler);
            MessageBus.Default.Subscribe("GetCurrentPatientIdForOperation", SetCurrentPatientID);

            MessageBus.Default.Subscribe("SetRightDiagnosisListForObsled", SetRightDiagnosisList);
            MessageBus.Default.Subscribe("SetLeftDiagnosisListForObsled", SetLeftDiagnosisList);

            MessageBus.Default.Subscribe("SetRecomendationsList", SetRecomendationsList);
            MessageBus.Default.Subscribe("SetDiagnosisList", SetDiagnosisList);
            MessageBus.Default.Subscribe("SetComplainsList", SetComplainsList);
            TextTip = "Текст пометки";
            Controller = controller;
            base.HasNavigation = false;

            this.openDialogCommand = new RelayCommand(FinishAdding);

            ClickOnWeight = new DelegateCommand(
                () =>
                {
                    if (Weight == "0")
                        Weight = "";
                }
            );
            ClickOnGrowth = new DelegateCommand(
                () =>
                {
                    if (Growth == "0")
                        Growth = "";
                }
            );


            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelSymptomsAdd>();
                }
            );
            ToLeftDiagCommand = new DelegateCommand(
             () =>
             {
                 MessageBus.Default.Call("SetleftOrRightForObsled", this, "Left");
                 Controller.NavigateTo<ViewModelDiagnosisList>();
             }
         );
            ToRightDiagCommand = new DelegateCommand(
               () =>
               {
                   MessageBus.Default.Call("SetleftOrRightForObsled", this, "Right");
                   Controller.NavigateTo<ViewModelDiagnosisList>();
               });

            //БПВ
            LeftBPVHip = new BPVHipViewModel(Controller, LegSide.Left);
            RightBPVHip = new BPVHipViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftBPVHip);
            Controller.AddLegPartVM(RightBPVHip);

            ToLeftBPVHipCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftBPVHip;
                    Controller.NavigateTo<BPVHipViewModel>(LegSide.Left);
                }
            );

            ToRightBPVHipCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightBPVHip;
                    Controller.NavigateTo<BPVHipViewModel>(LegSide.Right);
                }
            );

            //БПВ голень
            //BPVTibia

            LeftBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Left);
            RightBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Right);

            ToLeftBPVTibiaCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftBPVTibia;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightBPVTibiaCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightBPVTibia;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //Бедро перфорант

            LeftPerforate = new HipPerforateViewModel(Controller, LegSide.Left);
            RightPerforate = new HipPerforateViewModel(Controller, LegSide.Right);

            ToLeftPerforateCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftPerforate;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightPerforateCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightPerforate;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //ПДСВ

            LeftPDSV = new PDSVViewModel(Controller, LegSide.Left);
            RightPDSV = new PDSVViewModel(Controller, LegSide.Right);

            ToLeftPDSVCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftPDSV;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightPDSVCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightPDSV;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //СФС

            LeftSFS = new SFSViewModel(Controller, LegSide.Left);
            RightSFS = new SFSViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftSFS);
            Controller.AddLegPartVM(RightSFS);

            ToLeftSFSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftSFS;
                    Controller.NavigateTo<SFSViewModel>(LegSide.Left);
                }
            );

            ToRightSFSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightSFS;
                    Controller.NavigateTo<SFSViewModel>(LegSide.Right);
                }
            );

            //СПС

            LeftSPS = new SPSViewModel(Controller, LegSide.Left);
            RightSPS = new SPSViewModel(Controller, LegSide.Right);
            IMTCOUNT = new DelegateCommand(
            () =>
            {
                ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100));
            }
          );
            ToLeftSPSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftSPS;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightSPSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightSPS;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //Перфорант голени

            LeftTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Left);
            RightTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Right);

            ToLeftTibiaPerforateCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftTibiaPerforate;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightTibiaPerforateCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightTibiaPerforate;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //ЗДСВ

            LeftZDSV = new ZDSVViewModel(Controller, LegSide.Left);
            RightZDSV = new ZDSVViewModel(Controller, LegSide.Right);

            ToLeftZDSVCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftZDSV;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightZDSVCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightZDSV;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //

            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelComplainsList>();
                }
            );

            ToDiagnosisCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDiagnosisList>();
                }
            );

            ToAddRecomendationsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelRecomendationsList>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("UpdateTableOfPatients", this, controller);
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );
            ClickOnTextTip = new DelegateCommand(
                () =>
                {
                    if (TextTip == "Текст пометки")
                        TextTip = "";
                    //Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
        }

        struct SaveSet
        {
            public List<string> stringList;
            public ObservableCollection<Visibility> listVisibility;
            public SaveSet(List<string> stringList, ObservableCollection<Visibility> listVisibility)
            {
                this.listVisibility = listVisibility;
                this.stringList = stringList;
            }
        }

        private SaveSet SaveViewModel(LegPartViewModel sender)
        {
            List<string> bufBpvLeftStr = new List<string>();



            //to do тут должно быть сохранение


            var IsVisibleBPVleftbuf = new ObservableCollection<Visibility>();


            // IsVisibleBPVleftbuf.Add(Visibility.Visible);

            for (int i = 0; i < sender.LegSections.Count; ++i)
            {
                if (sender.LegSections[i].SelectedValue == null || sender.LegSections[i].SelectedValue.ToNextPart)
                {

                    IsVisibleBPVleftbuf.Add(Visibility.Collapsed);
                }
                else
                {
                    if (sender.LegSections[i].SelectedValue.HasSize || sender.LegSections[i].HasDoubleSize)
                    {
                        if (sender.LegSections[i].HasDoubleSize)
                        {
                            bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + "*" + sender.LegSections[i].CurrentEntry.Size2 + sender.LegSections[i].SelectedValue.Metrics + " " + sender.LegSections[i].SelectedValue.Text2 + " " + sender.LegSections[i].CurrentEntry.Comment);

                        }
                        else
                        {
                            bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + sender.LegSections[i].SelectedValue.Metrics + " " + sender.LegSections[i].SelectedValue.Text2 + " " + sender.LegSections[i].CurrentEntry.Comment);
                        }
                    }
                    else
                    {
                        bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].SelectedValue.Text2 + " " + sender.LegSections[i].CurrentEntry.Comment);
                    }
                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }
            }
            SaveSet result = new SaveSet(bufBpvLeftStr, IsVisibleBPVleftbuf);
            return result;

        }


        //  public ObservableCollection<>
        //кто присылает и что присылает
        private void Handler(object sender, object data)
        {
            Type senderType = sender.GetType();
            LegPartViewModel senderVM = (LegPartViewModel)sender;
            BPVHipEntryFull bpv = new BPVHipEntryFull();

            //sender проверять какого типа
            if (senderType == typeof(SFSViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    SFSLeftstr = new List<string>();
                    LeftSFSEntryFull = new SFSHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftSFS = (SFSViewModel)sender;
                    SaveSet result = SaveViewModel(LeftSFS);
                    SFSLeftstr = result.stringList;
                    IsVisibleSFSleft = result.listVisibility;
                }

                else
                {
                     SFSRightstr = new List<string>();
                     RightSFSEntryFull = new SFSHipEntryFull();
                     //to do тут должно быть сохранение
                     RightSFS = (SFSViewModel)sender;
                     SaveSet result = SaveViewModel(RightSFS);
                     SFSRightstr = result.stringList;
                     IsVisibleSFSRight = result.listVisibility;
                }
            if (senderType == typeof(BPVHipViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {



                    //List<string> bufBpvLeftStr = new List<string>();
                    //BpvLeftstr = new List<string>();

                    LeftBPVEntryFull = new BPVHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftBPVHip = (BPVHipViewModel)sender;
                    SaveSet result = SaveViewModel(LeftBPVHip);
                    BpvLeftstr = result.stringList;
                    IsVisibleBPVleft = result.listVisibility;


                }
                else
                {




                    BpvRightstr = new List<string>();


                    RightBPVHip = (BPVHipViewModel)sender;

                    SaveSet result = SaveViewModel(RightBPVHip);
                    BpvRightstr = result.stringList;
                    IsVisibleBPVRight = result.listVisibility;


                }

        }
    }
}
