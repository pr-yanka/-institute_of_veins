using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ObsStruct
    {

        public DateTime Date { get; set; }
        public Examination Ex;
        public string Patient { get; set; }
        public string IsOperationSeted { get; set; }
        public bool IsFilteredPt { get; set; }
        public bool IsFilteredOpSeted { get; set; }
        public bool IsFilteredDate { get; set; }
        public bool IsVisibleTotal { get; set; }
        public DelegateCommand ToObs { get; set; }
        public DelegateCommand ToPt { get; set; }

        public ObsStruct(DelegateCommand ToObs, DelegateCommand ToPt, Examination Ex, Patient CurrentPatient)
        {
            this.Ex = Ex;
            this.ToObs = ToObs;
            this.ToPt = ToPt;
            IsVisibleTotal = true;
            IsFilteredPt = false;
            IsFilteredOpSeted = false;
            IsFilteredDate = false;
            Date = Ex.Date;
            // Date = Op.Date.Day.ToString() + "." + Op.Date.Month.ToString() + "." + Op.Date.Year.ToString();
            // Time = buf1.Hour.ToString() + ":" + buf1.Minute.ToString();


            IsOperationSeted = Ex.isNeedOperation ? "Да" : "Нет";

        
                Patient = CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";


           

        }

    }
    public class ViewModelPhysicalTable : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private bool _isSortByData;
        public CollectionViewSource ViewSource { get; set; }
        private Visibility _visOfNothingFaund;
        public Visibility VisOfNothingFaund
        {
            get { return _visOfNothingFaund; }
            set
            { _visOfNothingFaund = value; OnPropertyChanged(); }
        }
        public bool IsSortByData
        {
            get { return _isSortByData; }
            set
            {
                _isSortByData = value; if (_isSortByData == true)
                {

                    ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                    // Let the UI control refresh in order for changes to take place.
                    ViewSource.View.Refresh();

                }
                else
                {
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
                OnPropertyChanged();
            }
        }
        private int _sortId;

        public int SortId
        {
            get { return _sortId; }
            set
            {
                _sortId = value;
                SetSelectedMedOrDocOps(null, null);
                Controller.NavigateTo<ViewModelPhysicalTable>();
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ObsStruct> _exams;
        public ObservableCollection<ObsStruct> Exams { get { return _exams; } set { _exams = value; OnPropertyChanged(); } }
        private string _filterText;
        public string FilterText { get { return _filterText; } set { _filterText = value; OnPropertyChanged(); FilterTextCommand.Execute(); } }

        //private void FilterActivater()
        //{


        //}

        private void SetSelectedMedOrDocOps(object sender, object data)
        {
            try
            {

                //DocsAndMedsList = new List<docsAndMeds>();

                Exams = new ObservableCollection<ObsStruct>();

                //bool test = true;

                var Examsbuf = new ObservableCollection<ObsStruct>();
                foreach (var Exam in Data.Examination.GetAll)
                {
                    DelegateCommand buferToPt = new DelegateCommand(
                        () =>
                        {
                             
                        MessageBus.Default.Call("OpenCurrentPatient", this, Exam.PatientId);
                        Controller.NavigateTo<ViewModelCurrentPatient>();
   
                        }
                    );


                    DelegateCommand bufer = new DelegateCommand(
                    () =>
                    {
                        MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, Exam.PatientId);
                        MessageBus.Default.Call("GetObsForOverview", this, Exam.Id.Value);
                        Controller.NavigateTo<ViewModelAddPhysical>();

                    }
                );



                    TimeSpan span = Exam.Date - DateTime.Now;


                    if (_sortId == 0 && Exam.Date.Year == DateTime.Now.Year && Exam.Date.Month == DateTime.Now.Month && Exam.Date.Day == DateTime.Now.Day)
                    {
                        var CurrentPatient = Data.Patients.Get(Exam.PatientId.Value);
                        Exams.Add(new ObsStruct(bufer, buferToPt, Exam, CurrentPatient));
                    }
                    else if (_sortId == 1 && span.Days > 0 && span.Days <= 3)
                    {
                        var CurrentPatient = Data.Patients.Get(Exam.PatientId.Value);
                        Exams.Add(new ObsStruct(bufer, buferToPt, Exam, CurrentPatient));
                    }
                    else if (_sortId == 2 && span.Days > 0 && span.Days <= 7)
                    {
                        var CurrentPatient = Data.Patients.Get(Exam.PatientId.Value);
                        Exams.Add(new ObsStruct(bufer, buferToPt, Exam, CurrentPatient));
                    }
                    else if (_sortId == 3 && span.Days > 0 && span.Days <= 32)
                    {
                        var CurrentPatient = Data.Patients.Get(Exam.PatientId.Value);
                        Exams.Add(new ObsStruct(bufer, buferToPt, Exam, CurrentPatient));
                    }
                    else if (_sortId == 4)
                    {
                        var CurrentPatient = Data.Patients.Get(Exam.PatientId.Value);
                        Exams.Add(new ObsStruct(bufer, buferToPt, Exam, CurrentPatient));
                    }



                }



                if (Exams.Count == 0)
                {
                    VisOfNothingFaund = Visibility.Visible;
                }
                else
                {
                    VisOfNothingFaund = Visibility.Collapsed;
                }

                ViewSource.Source = Exams;


                if (_isSortByData == true)
                {

                    ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                    // Let the UI control refresh in order for changes to take place.
                    ViewSource.View.Refresh();

                }
                else
                {
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
                Controller.NavigateTo<ViewModelPhysicalTable>();
            }
            catch (Exception exc)
            {
                Exams = new ObservableCollection<ObsStruct>();
                ViewSource.Source = Exams;
                ViewSource.SortDescriptions.Clear();
                ViewSource.View.Refresh();
            }
            _filterText = "";
            OnPropertyChanged("FilterText");
        }

        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand FilterTextCommand { get; protected set; }
        public ViewModelPhysicalTable(NavigationController controller) : base(controller)
        {
            VisOfNothingFaund = Visibility.Collapsed;
            ViewSource = new CollectionViewSource();
            MessageBus.Default.Subscribe("SetObsForObsTable", SetSelectedMedOrDocOps);
            base.HasNavigation = true;
            _sortId = 4;
            _isSortByData = true;
            Exams = new ObservableCollection<ObsStruct>();
            FilterTextCommand = new DelegateCommand(
              () =>
              {
                 
                  int count = 0;

                  if (!string.IsNullOrWhiteSpace(FilterText))
                  {
                      for (int i = 0; i < Exams.Count; ++i)
                      {




                          if (Exams[i].Patient.ToLower().Contains(FilterText.ToLower()))
                          {
                              Exams[i].IsFilteredPt = true;
                              Exams[i].IsVisibleTotal = true;
                              ++count;
                          }
                          else
                          {
                              Exams[i].IsFilteredPt = false;
                          }
                          if (Exams[i].IsOperationSeted.ToLower().Contains(FilterText.ToLower()))
                          {
                              Exams[i].IsFilteredOpSeted = true;
                              Exams[i].IsVisibleTotal = true; ++count;
                          }
                          else
                          {
                              Exams[i].IsFilteredOpSeted = false;
                          }
                          if (Exams[i].Date.ToString().ToLower().Contains(FilterText.ToLower()))
                          {
                              Exams[i].IsFilteredDate = true;
                              Exams[i].IsVisibleTotal = true; ++count;
                          }
                          else
                          {
                              Exams[i].IsFilteredDate = false;
                          }
                          if (!Exams[i].IsFilteredDate && !Exams[i].IsFilteredOpSeted && !Exams[i].IsFilteredPt)
                          {
                              Exams[i].IsVisibleTotal = false;
                          }


                      }
                      if (_isSortByData == true)
                      {

                          ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                          // Let the UI control refresh in order for changes to take place.
                          ViewSource.View.Refresh();

                      }
                      if (Exams.Count == 0 || count == 0)
                      {
                          VisOfNothingFaund = Visibility.Visible;
                      }
                      else
                      {
                          ViewSource.Source = Exams;
                          ViewSource.View.Refresh();
                          VisOfNothingFaund = Visibility.Collapsed;
                      }
                      Controller.NavigateTo<ViewModelPhysicalTable>();
                  }
                  else
                  {
                      SetSelectedMedOrDocOps(null, null);
                  }

              }
          );
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
    }
}
