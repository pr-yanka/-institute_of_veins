using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
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

    public class ViewModelViewHistory : ViewModelBase
    {
        public Patient CurrentPatient { get; set; }
        public string initials { get; set; }

        public ObservableCollection<HistoryDataSource> HistoryDataSource { get; set; }

        public DelegateCommand ToAddPhysicalCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToAnalizeOverviewCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand ToAddOperationCommand { get; protected set; }
        public DelegateCommand ToAddAnalizeCommand { get; protected set; }

        protected int CurrentPatientID;

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
                        Controller.NavigateTo<ViewModelOperationOverview>();
                    }
                );
                    
                    DateTime buf1 = DateTime.Parse(Operation.Time);
                   
                    HistoryDataSource.Add(new HistoryDataSource(bufer,new DateTime( Operation.Date.Year, Operation.Date.Month, Operation.Date.Day,buf1.Hour,buf1.Minute,buf1.Second), "Операция"));
                }
            }

            foreach (var Obsled in Data.Examination.GetAll)
            {
                if (Obsled.PatientId == CurrentPatient.Id)
                {
                    DelegateCommand bufer = new DelegateCommand(
                    () =>
                    {
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
                    HistoryDataSource.Add( new HistoryDataSource(bufer, Analize.data, "Анализ"));
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

        
           

            MessageBus.Default.Subscribe("OpenHistoryOfPatient", SetCurrentPatientID);
            base.HasNavigation = false;
            ToAddPhysicalCommand = new DelegateCommand(
                () =>
                {
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

            ToAddOperationCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );

            ToAddAnalizeCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddAnalize>();
                }
            );

        }
    }
}
