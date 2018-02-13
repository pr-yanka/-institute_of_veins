using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class HistoryDataSource
    {
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;

            }
            set { _date = value; }
        }

        public DelegateCommand Command { get; protected set; }
        public string Type { get; set; }

        public HistoryDataSource(DelegateCommand Command, DateTime date, string Type)
        {
            this.Command = Command;
            this.Date = date;
            this.Type = Type;

        }
    }

    public class ViewModelViewHistory : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Patient CurrentPatient { get; set; }
        public string initials { get; set; }
        public ObservableCollection<HistoryDataSource> _historyDataSource;
        public ObservableCollection<HistoryDataSource> HistoryDataSource { get { return _historyDataSource; } set { _historyDataSource = value; OnPropertyChanged();  } }

        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToAddPhysicalCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToAnalizeOverviewCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand ToAddOperationCommand { get; protected set; }
        public DelegateCommand ToAddAnalizeCommand { get; protected set; }

        protected int CurrentPatientID;
        private bool _isCanceledOprVisible;
        public bool isCanceledOprVisible { get { return _isCanceledOprVisible; } set { _isCanceledOprVisible = value;  OnPropertyChanged(); MessageBus.Default.Call("OpenHistoryOfPatient", this, CurrentPatient.Id); } }


        private void SetCurrentPatientID(object sender, object data)
        {
            CurrentPatient = Data.Patients.Get((int)data);
            initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";
            HistoryDataSource = new ObservableCollection<HistoryDataSource>();

            foreach (var Operation in Data.Operation.GetAll)
            {
                if (Operation.PatientId == CurrentPatient.Id)
                {
                    DelegateCommand bufer = new DelegateCommand(
                    () =>
                    {
                        //MessageBus.Default.Call("GetPatientForAnalizeOverview", this, CurrentPatient.Id);
                        // MessageBus.Default.Call("GetAnalizeForAnalizeOverview", this, Operation.Id);
                        MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);
                        Controller.NavigateTo<ViewModelOperationOverview>();
                    }
                );

                    DateTime buf1 = DateTime.Parse(Operation.Time);
                    if (Operation.отмена_операции != null && isCanceledOprVisible == false) { }
                    else
                        HistoryDataSource.Add(new HistoryDataSource(bufer, new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, buf1.Hour, buf1.Minute, buf1.Second), "Операция"));
                }
            }

            foreach (var Obsled in Data.Examination.GetAll)
            {
                if (Obsled.PatientId == CurrentPatient.Id)
                {
                    DelegateCommand bufer = new DelegateCommand(
                    () =>
                    {
                        MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, CurrentPatient.Id);
                        MessageBus.Default.Call("GetObsForOverview", this, Obsled.Id.Value);
                        Controller.NavigateTo<ViewModelAddPhysical>();
                        // MessageBus.Default.Call("GetPatientForAnalizeOverview", this, CurrentPatient.Id);
                        //MessageBus.Default.Call("GetAnalizeForAnalizeOverview", this, Analize.Id);
                        //Controller.NavigateTo<ViewModelAnalizeOverview>();
                    }
                );
                    HistoryDataSource.Add(new HistoryDataSource(bufer, Obsled.Date, "Обследование"));
                }
            }

            foreach (var Analize in Data.Analize.GetAll)
            {
                if (Analize.patientId == CurrentPatient.Id)
                {
                    DelegateCommand bufer = new DelegateCommand(
                    () =>
                    {
                        MessageBus.Default.Call("GetPatientForAnalizeOverview", this, CurrentPatient.Id);
                        MessageBus.Default.Call("GetAnalizeForAnalizeOverview", this, Analize.Id);
                        Controller.NavigateTo<ViewModelAnalizeOverview>();
                    }
                );
                    HistoryDataSource.Add(new HistoryDataSource(bufer, Analize.data, "Анализ"));
                }
            }


            for (int i = 0; i < HistoryDataSource.Count; i++)
            {
                for (int j = 0; j < HistoryDataSource.Count - i - 1; j++)
                {
                    if (HistoryDataSource[j].Date < HistoryDataSource[j + 1].Date)
                    {
                        var temp = HistoryDataSource[j];
                        HistoryDataSource[j] = HistoryDataSource[j + 1];
                        HistoryDataSource[j + 1] = temp;
                    }
                }
            }

        }

        public ViewModelViewHistory(NavigationController controller) : base(controller)
        {



            base.HasNavigation = true;
            HasNavigation = true;
            MessageBus.Default.Subscribe("OpenHistoryOfPatient", SetCurrentPatientID);

            ToAddPhysicalCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, CurrentPatient.Id);

                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToAnalizeOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAnalizeOverview>();
                }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );

            ToPhysicalOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelPhysicalOverview>();
                }
            );
            ToCurrentPatientCommand = new DelegateCommand(
               () =>
               {
                   MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                   Controller.NavigateTo<ViewModelCurrentPatient>();
               }
           );

            ToAddOperationCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetCurrentPatientForOperation", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );

            ToAddAnalizeCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddAnalize>();
                }
            );

        }
    }
}
