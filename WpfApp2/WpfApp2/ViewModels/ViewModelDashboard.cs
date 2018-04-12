using Microsoft.Practices.Prism.Commands;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelDashboard : ViewModelBase, INotifyPropertyChanged

    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public string AccauntName { get; set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand ToNewPatientCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }
        public DelegateCommand ToLoginCommand { get; protected set; }
        public DelegateCommand ToPhysicalTableCommand { get; protected set; }
        public DelegateCommand ToCalendarOperationsCommand { get; protected set; }

        private Visibility _alertOpOperation;


        public Visibility AlertOpOperation { get { return _alertOpOperation; } set { _alertOpOperation = value; OnPropertyChanged(); } }


        public string NextOpText { get; set; }
        private void SetAlterOperation(object sender, object data)
        {

        }

        private void GetAcaunt(object sender, object data)
        {
            Operation op = new Operation();
            if (sender != null)
            {
                op = (Operation)sender;
                NextOpText = "   Ваша следущая операция назначена на " + DateTime.Parse(op.Time).Hour + ":" + DateTime.Parse(op.Time).Minute;
                AlertOpOperation = Visibility.Visible;

                ToOperationOverviewCommand = new DelegateCommand(
             () =>
             {
                 MessageBus.Default.Call("GetOperationForOverwiev", this, op.Id);
                 Controller.NavigateTo<ViewModelOperationOverview>();
             }
         );
            }
            else
            {
                ToOperationOverviewCommand = new DelegateCommand(
           () =>
           {

           }
       );
                AlertOpOperation = Visibility.Collapsed;
            }

            AccauntName = Data.Accaunt.Get((int)data).Name;

            DelaySaveCheck();
        }

        private async void DelaySaveCheck()
        {
            try
            {
                await Task.Delay(1000);
                var savedExam = Data.SavedExamination.GetAll.ToList();
                if (savedExam.Count != 0 && savedExam[0].PatientId != null)
                {


                    MessageBoxResult dialogResult = MessageBox.Show("Была сохранена резервная копия обследования, желаете ли её восстановить?", "", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        if (savedExam[0].PatientId != null)
                        {
                            var patient = Data.Patients.Get(savedExam[0].PatientId.Value);

                            MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, patient.Id);
                            MessageBus.Default.Call("GetObsFromSavedOverview", this, savedExam[0].Id.Value);
                            Controller.NavigateTo<ViewModelAddPhysical>();
                        }
                    }
                    else
                    {
                        foreach (var x in Data.SavedExamination.GetAll)
                        {
                            x.height = 0;
                            x.weight = 0;
                            x.Comment = "";
                            x.Date = null;
                            x.DoctorID = null;
                            x.hirurgOverviewId = null;
                            x.isNeedOperation = null;
                            x.NB = "";
                            x.OperationType = null;
                            x.PatientId = null;
                            x.statementOverviewId = null;
                            x.id_current_examination = null;
                        }
                        foreach (var x in Data.SavedExaminationLeg.GetAll)
                        {

                            //if (x.PDSVid != null)
                            //{
                            //    var legPrt = Data.PDSVFull.Get(x.PDSVid.Value);
                            //    //Data.PDSVHipEntries.Remove(Data.PDSVHipEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.PDSVHipEntries.Remove(Data.PDSVHipEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.PDSVHipEntries.Remove(Data.PDSVHipEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.PDSVHipEntries.Remove(Data.PDSVHipEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.PDSVHipEntries.Remove(Data.PDSVHipEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.PDSVHipEntries.Remove(Data.PDSVHipEntries.Get(legPrt.EntryId6.Value));

                            //    Data.PDSVFull.Remove(legPrt);
                            //}
                            //if (x.ZDSVid != null)
                            //{
                            //    var legPrt = Data.ZDSVFull.Get(x.ZDSVid.Value);
                            //    //Data.ZDSVEntries.Remove(Data.ZDSVEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.ZDSVEntries.Remove(Data.ZDSVEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.ZDSVEntries.Remove(Data.ZDSVEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.ZDSVEntries.Remove(Data.ZDSVEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.ZDSVEntries.Remove(Data.ZDSVEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.ZDSVEntries.Remove(Data.ZDSVEntries.Get(legPrt.EntryId6.Value));

                            //    Data.ZDSVFull.Remove(legPrt);
                            //}
                            //if (x.BPVTibiaid != null)
                            //{
                            //    var legPrt = Data.BPV_TibiaFull.Get(x.BPVTibiaid.Value);
                            //    //Data.BPV_TibiaEntries.Remove(Data.BPV_TibiaEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.BPV_TibiaEntries.Remove(Data.BPV_TibiaEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.BPV_TibiaEntries.Remove(Data.BPV_TibiaEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.BPV_TibiaEntries.Remove(Data.BPV_TibiaEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.BPV_TibiaEntries.Remove(Data.BPV_TibiaEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.BPV_TibiaEntries.Remove(Data.BPV_TibiaEntries.Get(legPrt.EntryId6.Value));

                            //    Data.BPV_TibiaFull.Remove(legPrt);
                            //}


                            //if (x.BPVHip != null)
                            //{
                            //    var legPrt = Data.BPVHipsFull.Get(x.BPVHip.Value);
                            //    //Data.BPVHipEntries.Remove(Data.BPVHipEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.BPVHipEntries.Remove(Data.BPVHipEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.BPVHipEntries.Remove(Data.BPVHipEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.BPVHipEntries.Remove(Data.BPVHipEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.BPVHipEntries.Remove(Data.BPVHipEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.BPVHipEntries.Remove(Data.BPVHipEntries.Get(legPrt.EntryId6.Value));

                            //    Data.BPVHipsFull.Remove(legPrt);

                            //}
                            ////      Data.BPVHipsFull.Remove(Data.BPVHipsFull.Get(x.BPVHip.Value));

                            //if (x.GVid != null)
                            //{
                            //    var legPrt = Data.GVFull.Get(x.GVid.Value);
                            //    //Data.GVEntries.Remove(Data.GVEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.GVEntries.Remove(Data.GVEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.GVEntries.Remove(Data.GVEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.GVEntries.Remove(Data.GVEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.GVEntries.Remove(Data.GVEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.GVEntries.Remove(Data.GVEntries.Get(legPrt.EntryId6.Value));

                            //    Data.GVFull.Remove(legPrt);
                            //}
                            //// Data.GVFull.Remove(Data.GVFull.Get(x.GVid.Value));

                            //if (x.MPVid != null)
                            //{
                            //    var legPrt = Data.MPVFull.Get(x.MPVid.Value);
                            //    //Data.MPVEntries.Remove(Data.MPVEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.MPVEntries.Remove(Data.MPVEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.MPVEntries.Remove(Data.MPVEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.MPVEntries.Remove(Data.MPVEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.MPVEntries.Remove(Data.MPVEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.MPVEntries.Remove(Data.MPVEntries.Get(legPrt.EntryId6.Value));

                            //    Data.MPVFull.Remove(legPrt);
                            //}
                            //// Data.MPVFull.Remove();

                            //if (x.PerforateHipid != null)
                            //{
                            //    var legPrt = Data.Perforate_hipFull.Get(x.PerforateHipid.Value);
                            //    //Data.Perforate_hipEntries.Remove(Data.Perforate_hipEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.Perforate_hipEntries.Remove(Data.Perforate_hipEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.Perforate_hipEntries.Remove(Data.Perforate_hipEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.Perforate_hipEntries.Remove(Data.Perforate_hipEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.Perforate_hipEntries.Remove(Data.Perforate_hipEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.Perforate_hipEntries.Remove(Data.Perforate_hipEntries.Get(legPrt.EntryId6.Value));

                            //    Data.Perforate_hipFull.Remove(legPrt);
                            //}
                            ////  Data.Perforate_hipFull.Remove(Data.Perforate_hipFull.Get(x.PerforateHipid.Value));

                            //if (x.TibiaPerforateid != null)
                            //{
                            //    var legPrt = Data.Perforate_shinFull.Get(x.TibiaPerforateid.Value);
                            //    //Data.Perforate_shinEntries.Remove(Data.Perforate_shinEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.Perforate_shinEntries.Remove(Data.Perforate_shinEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.Perforate_shinEntries.Remove(Data.Perforate_shinEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.Perforate_shinEntries.Remove(Data.Perforate_shinEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.Perforate_shinEntries.Remove(Data.Perforate_shinEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.Perforate_shinEntries.Remove(Data.Perforate_shinEntries.Get(legPrt.EntryId6.Value));

                            //    Data.Perforate_shinFull.Remove(legPrt);
                            //}
                            ////Data.Perforate_shinFull.Remove(Data.Perforate_shinFull.Get(x.TibiaPerforateid.Value));

                            //if (x.PPVid != null)
                            //{
                            //    var legPrt = Data.PPVFull.Get(x.PPVid.Value);
                            //    //Data.PPVEntries.Remove(Data.PPVEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.PPVEntries.Remove(Data.PPVEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.PPVEntries.Remove(Data.PPVEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.PPVEntries.Remove(Data.PPVEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.PPVEntries.Remove(Data.PPVEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.PPVEntries.Remove(Data.PPVEntries.Get(legPrt.EntryId6.Value));

                            //    Data.PPVFull.Remove(legPrt);
                            //}
                            ////  Data.PPVFull.Remove(Data.PPVFull.Get(x.PPVid.Value));

                            //if (x.SFSid != null)
                            //{
                            //    var legPrt = Data.SFSFull.Get(x.SFSid.Value);
                            //    //Data.SFSHipEntries.Remove(Data.SFSHipEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.SFSHipEntries.Remove(Data.SFSHipEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.SFSHipEntries.Remove(Data.SFSHipEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.SFSHipEntries.Remove(Data.SFSHipEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.SFSHipEntries.Remove(Data.SFSHipEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.SFSHipEntries.Remove(Data.SFSHipEntries.Get(legPrt.EntryId6.Value));

                            //    Data.SFSFull.Remove(legPrt);
                            //}
                            ////     Data.SFSFull.Remove(Data.SFSFull.Get(x.SFSid.Value));

                            //if (x.SPSid != null)
                            //{
                            //    var legPrt = Data.SPSHipFull.Get(x.SPSid.Value);
                            //    //Data.SPSEntries.Remove(Data.SPSEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.SPSEntries.Remove(Data.SPSEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.SPSEntries.Remove(Data.SPSEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.SPSEntries.Remove(Data.SPSEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.SPSEntries.Remove(Data.SPSEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.SPSEntries.Remove(Data.SPSEntries.Get(legPrt.EntryId6.Value));

                            //    Data.SPSHipFull.Remove(legPrt);
                            //}
                            ////  Data.SPSHipFull.Remove(Data.SPSHipFull.Get(x.SPSid.Value));

                            //if (x.TEMPVid != null)
                            //{
                            //    var legPrt = Data.TEMPVFull.Get(x.TEMPVid.Value);
                            //    //Data.TEMPVEntries.Remove(Data.TEMPVEntries.Get(legPrt.EntryId1));
                            //    //if (legPrt.EntryId2 != null)
                            //    //    Data.TEMPVEntries.Remove(Data.TEMPVEntries.Get(legPrt.EntryId2.Value));
                            //    //if (legPrt.EntryId3 != null)
                            //    //    Data.TEMPVEntries.Remove(Data.TEMPVEntries.Get(legPrt.EntryId3.Value));
                            //    //if (legPrt.EntryId4 != null)
                            //    //    Data.TEMPVEntries.Remove(Data.TEMPVEntries.Get(legPrt.EntryId4.Value));
                            //    //if (legPrt.EntryId5 != null)
                            //    //    Data.TEMPVEntries.Remove(Data.TEMPVEntries.Get(legPrt.EntryId5.Value));
                            //    //if (legPrt.EntryId6 != null)
                            //    //    Data.TEMPVEntries.Remove(Data.TEMPVEntries.Get(legPrt.EntryId6.Value));

                            //    Data.TEMPVFull.Remove(legPrt);
                            //}
                            // Data.TEMPVFull.Remove(Data.TEMPVFull.Get(x.TEMPVid.Value));



                            x.A = null;
                            x.additionalText = "";

                            x.BPVHip = null;
                            x.BPVTibiaid = null;
                            x.C = null;
                            x.E = null;
                            x.GVid = null;
                            x.MPVid = null;
                            x.P = null;
                            x.PDSVid = null;
                            x.PerforateHipid = null;
                            x.PPVid = null;
                            x.SFSid = null;
                            x.SPSid = null;
                            x.TEMPVid = null;
                            x.TibiaPerforateid = null;
                            x.ZDSVid = null;
                        }
                        foreach (var x in Data.SavedComplanesObs.GetAll)
                        {
                            Data.SavedComplanesObs.Remove(x);
                        }
                        foreach (var x in Data.SavedDiagnosisObs.GetAll)
                        {
                            Data.SavedDiagnosisObs.Remove(x);
                        }
                        foreach (var x in Data.SavedRecomendationObs.GetAll)
                        {
                            Data.SavedRecomendationObs.Remove(x);
                        }
                    }
                }
            }
            catch { }

        }
        public ViewModelDashboard(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;


            MessageBus.Default.Subscribe("GetAcaunt", GetAcaunt);

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    //    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );

            ToNewPatientCommand = new DelegateCommand(
                () =>
                {

                    MessageBus.Default.Call("UpdateDictionariesOfLocationForNewPatient", this, "");

                    Controller.NavigateTo<ViewModelNewPatient>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    //   MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("UpdateTableOfPatients", this, controller);
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );

            ToLoginCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelLogin>();
                }
            );

            ToPhysicalTableCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetObsForObsTable", null, null);
                    Controller.NavigateTo<ViewModelPhysicalTable>();
                }
            );

            ToCalendarOperationsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelCalendarOperations>();
                }
            );

        }

    }
}