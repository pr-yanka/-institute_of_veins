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

        public DelegateCommand ToRightSFSCommand { get; protected set; }
        public DelegateCommand ToLeftSFSCommand { get; protected set; }

        public DelegateCommand ToRightPDSVCommand { get; protected set; }
        public DelegateCommand ToRightZDSVCommand { get; protected set; }
        public DelegateCommand ToRightPerforateCommand { get; protected set; }

        public DelegateCommand ToAddRecomendationsCommand { get; protected set; }

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

        public BPVHipViewModel RightBPVHip { get; protected set; }
        public SFSViewModel RightSFS { get; protected set; }
        public PDSVViewModel RightPDSV { get; protected set; }
        public ZDSVViewModel RightZDSV { get; protected set; }
        public HipPerforateViewModel RightPerforate { get; protected set; }

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
            LeftBPVHip = new BPVHipViewModel(Controller, LegSide.Left);
            RightBPVHip = new BPVHipViewModel(Controller, LegSide.Right);
            LeftPDSV = new PDSVViewModel(Controller, LegSide.Left);
            LeftZDSV = new ZDSVViewModel(Controller, LegSide.Left);
            LeftPerforate = new HipPerforateViewModel(Controller, LegSide.Left);

            LeftSFS = new SFSViewModel(Controller, LegSide.Left);
            RightSFS = new SFSViewModel(Controller, LegSide.Right);
            RightPDSV = new PDSVViewModel(Controller, LegSide.Right);
            RightZDSV = new ZDSVViewModel(Controller, LegSide.Right);
            RightPerforate = new HipPerforateViewModel(Controller, LegSide.Right);

            Controller = controller;
            base.HasNavigation = false;

            this.openDialogCommand = new RelayCommand(FinishAdding);

            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelSymptomsAdd>();
                }
            );

            ToRightBPVHipCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightBPVHip;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToLeftBPVHipCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftBPVHip;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

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

            ToLeftZDSVCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = LeftZDSV;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightSFSCommand = new DelegateCommand(
                () =>
                {
                    Controller.LegViewModel = RightZDSV;
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

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

            ToAddRecomendationsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelRecomendationsAdd>();
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
