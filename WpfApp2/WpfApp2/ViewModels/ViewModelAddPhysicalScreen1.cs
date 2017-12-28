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

        private float _weight;
        public float Weight { get { return _weight; } set { _weight = value; ITM = Weight / ((Growth / 100) * (Growth / 100)); OnPropertyChanged(); } }
        private float _growth;
        public float Growth { get { return _growth; } set { _growth = value; ITM = Weight / ((Growth / 100) * (Growth/100)); OnPropertyChanged(); } }

        private double _itm;
        public double ITM { get { return Math.Round(_itm,3) ; } set { _itm = value; OnPropertyChanged(); } }

        private string _textTip;
        public string TextTip { get { return _textTip; } set { _textTip = value; OnPropertyChanged();} }
        public DelegateCommand ClickOnTextTip { get; protected set; }
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

            CurrentPatient = Data.Patients.Get((int)data);
            initials = " "+CurrentPatient.Sirname.ToCharArray()[0].ToString()+". "+ CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

        }

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }

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


        public ViewModelAddPhysical(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("LegDataSaved", Handler);
            MessageBus.Default.Subscribe("GetCurrentPatientIdForOperation", SetCurrentPatientID);

            MessageBus.Default.Subscribe("SetRecomendationsList", SetRecomendationsList);
            MessageBus.Default.Subscribe("SetDiagnosisList", SetDiagnosisList);
            MessageBus.Default.Subscribe("SetComplainsList", SetComplainsList);
            TextTip = "Текст пометки";
            Controller = controller;
            base.HasNavigation = false;

            this.openDialogCommand = new RelayCommand(FinishAdding);

            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelSymptomsAdd>();
                }
            );


            //БПВ
            LeftBPVHip = new BPVHipViewModel(Controller, LegSide.Left);
            RightBPVHip = new BPVHipViewModel(Controller, LegSide.Right);

            ToLeftBPVHipCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftBPVHip;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightBPVHipCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightBPVHip;
                    Controller.NavigateTo<LegPartViewModel>();
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

            ToLeftSFSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftSFS;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightSFSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightSFS;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //СПС

            LeftSPS = new SPSViewModel(Controller, LegSide.Left);
            RightSPS = new SPSViewModel(Controller, LegSide.Right);

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
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );
            ClickOnTextTip = new DelegateCommand(
                () =>
                {
                    TextTip = "";
                    //Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
        }


        
            //кто присылает и что присылает
            private void Handler(object sender, object data)
        {
            Type senderType = sender.GetType();
            LegPartViewModel senderVM = (LegPartViewModel) sender;

            //sender проверять какого типа
            if (senderType == typeof(SFSViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                    LeftSFS = (SFSViewModel)sender;
                else
                    RightSFS = (SFSViewModel)sender;

            if (senderType == typeof(BPVHipViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                    LeftBPVHip = (BPVHipViewModel)sender;
                else
                    RightBPVHip = (BPVHipViewModel)sender;

        }
    }
}
