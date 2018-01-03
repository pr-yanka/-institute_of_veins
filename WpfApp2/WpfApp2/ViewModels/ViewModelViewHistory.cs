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
    public class HistoryDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;

            }
            set { _date = value; OnPropertyChanged(); }
        }
        public DelegateCommand Command { get; protected set; }
        public string Type { get; set; }

        public HistoryDataSource(DelegateCommand Command, DateTime date, string Type)
        {
            this.Command = Command;
            this.Date = Date;
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
                    HistoryDataSource buf = new HistoryDataSource(bufer, Analize.data, "Операция");
                }
            }
        }

        public ViewModelViewHistory(NavigationController controller) : base(controller)
        {

            HistoryDataSource = new ObservableCollection<ViewModels.HistoryDataSource>();

           

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
