using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;
using System.Windows.Input;
using WpfApp2.DialogPreOperation;
using WpfApp2.DialogService;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.Messaging;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddPhysical : ViewModelBase
    {
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
