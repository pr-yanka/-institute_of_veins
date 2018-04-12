﻿using Microsoft.Practices.Prism.Commands;
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