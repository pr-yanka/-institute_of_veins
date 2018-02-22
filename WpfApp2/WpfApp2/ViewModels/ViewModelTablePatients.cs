using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{

    public class ViewModelTablePatients : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToHistoryOverviewCommand { get; protected set; }


        private Visibility _visOfNothingFaund;
        public Visibility VisOfNothingFaund
        {
            get { return _visOfNothingFaund; }
            set
            { _visOfNothingFaund = value; OnPropertyChanged(); }
        }
        protected int CurrentPatientID;
        private void SetCurrentPatientID(object sender, object data)
        {
            CurrentPatientID = (int)data;
            MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatientID);
        }
        #region MessageBus

        private void GetListOfPatients(object sender, object data)
        {

            using (var context = new MySqlContext())
            {
                PatientsRepository PatientsRep = new PatientsRepository(context);
                FullCopy = new List<ViewModelPatient>();
                Patients = new ObservableCollection<ViewModelPatient>();
                foreach (var patient in PatientsRep.GetAll)
                {
                    Patients.Add(new ViewModelPatient((NavigationController)data, patient));
                    FullCopy.Add(new ViewModelPatient((NavigationController)data, patient));
                }
                ViewSource.Source = Patients;
            }
        }
        #endregion
        List<ViewModelPatient> FullCopy;
        public CollectionViewSource ViewSource { get; set; }
        private int lastLength = 0;

        private string _filterText;

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value; OnPropertyChanged();

                if (lastLength >= value.Length)
                {
                    //foreach(ChangeHistoryClass x in FullCopy)
                    //{
                    //    ChangeHistoryClass buf = new ChangeHistoryClass(x.Ch);
                    //    Patients.Add(buf);
                    //}
                    Patients = new ObservableCollection<ViewModelPatient>(FullCopy);
                }
                lastLength = value.Length;
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    for (int i = 0; i < Patients.Count; ++i)
                    {



                        if (Patients[i].CurrentPatient.Name.ToLower().Contains(FilterText.ToLower()))
                        {
                            Patients[i].IsFilteredName = true;
                            Patients[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Patients[i].IsFilteredName = false;
                        }
                        if (Patients[i].CurrentPatient.Age.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Patients[i].IsFilteredAge = true;
                            Patients[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Patients[i].IsFilteredAge = false;
                        }

                        if (!Patients[i].IsFilteredName && !Patients[i].IsFilteredAge)
                        {
                            Patients[i].IsVisibleTotal = false;
                        }
                        //IsFilteredAccName = false;
                        //IsFilteredAccPost = false;
                        //IsFilteredChangeType = false;
                        //IsFilteredTableChanged = false;
                        //IsFilteredPropertyChanged = false;
                        //IsFilteredOldValue = false;
                        //IsFilteredNewValue = false;


                    }
                    //if (_isSortByData == true)
                    //{

                    //    ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                    //    // Let the UI control refresh in order for Patients to take place.
                    //    ViewSource.View.Refresh();

                    //}
                    //


                    for (int i = 0; i < Patients.Count; ++i)
                    {
                        if (Patients[i].IsVisibleTotal == false)
                        {
                            Patients.Remove(Patients[i]);
                            --i;
                        }
                    }
                    if (Patients.Count == 0)
                    {
                        VisOfNothingFaund = Visibility.Visible;
                    }
                    else
                    {
                        VisOfNothingFaund = Visibility.Collapsed;
                    }
                    ViewSource.Source = Patients;


                    ViewSource.View.Refresh();
                    //  Controller.NavigateTo<ViewModelPatientsHistoy>();
                }
                else
                {
                    ViewSource.Source = Patients;
                    VisOfNothingFaund = Visibility.Collapsed;
                    foreach (var x in Patients)
                    {
                        x.IsVisibleTotal = true;
                        x.IsFilteredAge = false;
                        x.IsFilteredName = false;
                    }
                    ViewSource.View.Refresh();
                    // SetPatientsInDB(null, null);
                }
            }
        }

        private ObservableCollection<ViewModelPatient> _patients;
        public ObservableCollection<ViewModelPatient> Patients { get { return _patients; } set { _patients = value; OnPropertyChanged(); } }

        public ViewModelTablePatients(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            ViewSource = new CollectionViewSource();
            FullCopy = new List<ViewModelPatient>();
            MessageBus.Default.Subscribe("UpdateTableOfPatients", GetListOfPatients);
            Patients = new ObservableCollection<ViewModelPatient>();
            foreach (var patient in Data.Patients.GetAll)
            {
                Patients.Add(new ViewModelPatient(controller, patient));
                FullCopy.Add(new ViewModelPatient(controller, patient));
            }
            if (Patients.Count == 0)
            {
                VisOfNothingFaund = Visibility.Visible;
            }
            else
            {
                VisOfNothingFaund = Visibility.Collapsed;
            }
            ViewSource.Source = Patients;
            MessageBus.Default.Subscribe("OpenCurrentPatient", SetCurrentPatientID);

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatientID);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToHistoryOverviewCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("OpenHistoryOfPatient", this, CurrentPatientID);
                    Controller.NavigateTo<ViewModelViewHistory>();
                }
            );
        }
    }
}
