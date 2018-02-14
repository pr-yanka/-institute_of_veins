using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ChangeHistoryClass
    {

        public DateTime Date { get; set; }

        public ChangeHistory Ch;

        public string AccName { get; set; }
        public string AccPost { get; set; }
        public string ChangeType { get; set; }
        public string TableChanged { get; set; }
        public string PropertyChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }


        public bool IsFilteredDate { get; set; }
        public bool IsFilteredAccName { get; set; }
        public bool IsFilteredAccPost { get; set; }
        public bool IsFilteredChangeType { get; set; }
        public bool IsFilteredTableChanged { get; set; }
        public bool IsFilteredPropertyChanged { get; set; }
        public bool IsFilteredOldValue { get; set; }
        public bool IsFilteredNewValue { get; set; }


        public bool IsVisibleTotal { get; set; }



        public ChangeHistoryClass(ChangeHistory Ch)
        {
            this.Ch = Ch;


            IsVisibleTotal = true;
            IsFilteredDate = false;
            IsFilteredAccName = false;
            IsFilteredAccPost = false;
            IsFilteredChangeType = false;
            IsFilteredTableChanged = false;
            IsFilteredPropertyChanged = false;
            IsFilteredOldValue = false;
            IsFilteredNewValue = false;


            // TEST
            OldValue = Ch.OldValue;
            NewValue = Ch.NewValue;
            TableChanged = Ch.TblName;
            PropertyChanged = Ch.TblCollumnName;




            // Date = Op.Date.Day.ToString() + "." + Op.Date.Month.ToString() + "." + Op.Date.Year.ToString();
            // Time = buf1.Hour.ToString() + ":" + buf1.Minute.ToString();
            Date = Ch.DataChanged;
            using (var context = new MySqlContext())
            {
                AccauntRepository acRep = new AccauntRepository(context);
                ChangesInDBTypeRepository chindbRep = new ChangesInDBTypeRepository(context);
                Accaunt CurAcc = acRep.Get(Ch.AccID);

                AccName = CurAcc.Name;


                if (CurAcc.isAdmin != null && CurAcc.isAdmin.Value)
                {
                    AccPost = "Администратор";
                }
                else if (CurAcc.isDoctor != null && CurAcc.isDoctor.Value)
                {
                    AccPost = "Врач";
                }
                else if (CurAcc.isMedPersonal != null && CurAcc.isMedPersonal.Value)
                {
                    AccPost = "Медперсонал";
                }

                ChangeType = chindbRep.Get(Ch.ChangeType).Str;
                //var CurrentPatient = PtRep.Get(Ex.PatientId.Value);
                //Patient = CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";


            }

        }

    }
    public class ViewModelChangesHistoy : ViewModelBase, INotifyPropertyChanged
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
      
        public ObservableCollection<ChangeHistoryClass> _exams;
        public ObservableCollection<ChangeHistoryClass> Changes { get { return _exams; } set { _exams = value; OnPropertyChanged(); } }
        private string _filterText;
        public string FilterText { get { return _filterText; } set { _filterText = value; OnPropertyChanged();


                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    for (int i = 0; i < Changes.Count; ++i)
                    {



                        if (Changes[i].AccName.ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredAccName = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredAccName = false;
                        }
                        if (Changes[i].AccPost.ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredAccPost = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredAccPost = false;
                        }
                        if (Changes[i].Date.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredDate = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredDate = false;
                        }
                        if (Changes[i].ChangeType.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredChangeType = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredChangeType = false;
                        }



                        if (Changes[i].TableChanged.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredTableChanged = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredTableChanged = false;
                        }

                        if (Changes[i].PropertyChanged.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredPropertyChanged = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredPropertyChanged = false;
                        }



                        if (Changes[i].OldValue.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredOldValue = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredOldValue = false;
                        }


                        if (Changes[i].NewValue.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredNewValue = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredNewValue = false;
                        }

                        if (!Changes[i].IsFilteredDate && !Changes[i].IsFilteredNewValue && !Changes[i].IsFilteredOldValue &&
                        !Changes[i].IsFilteredPropertyChanged && !Changes[i].IsFilteredTableChanged &&
                        !Changes[i].IsFilteredChangeType && !Changes[i].IsFilteredAccName && !Changes[i].IsFilteredAccPost)
                        {
                            Changes[i].IsVisibleTotal = false;
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

                    //    // Let the UI control refresh in order for changes to take place.
                    //    ViewSource.View.Refresh();

                    //}
                  //  ViewSource.Source = Changes;
                    ViewSource.View.Refresh();
                    //  Controller.NavigateTo<ViewModelChangesHistoy>();
                }
                else
                {
                    foreach(ChangeHistoryClass x in Changes)
                    {
                        x.IsVisibleTotal = true;
                        x.IsFilteredDate = false;
                        x.IsFilteredAccName = false;
                        x.IsFilteredAccPost = false;
                        x.IsFilteredChangeType = false;
                        x.IsFilteredTableChanged = false;
                        x.IsFilteredPropertyChanged = false;
                        x.IsFilteredOldValue = false;
                        x.IsFilteredNewValue = false;
                    }
                    ViewSource.View.Refresh();
                    // SetChangesInDB(null, null);
                }





            } }

        //private void FilterActivater()
        //{


        //}

        private void SetChangesInDB(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                try
                {

                    //DocsAndMedsList = new List<docsAndMeds>();







                    ChangeHistoryRepository ChangeRp = new ChangeHistoryRepository(context);



                    Changes = new ObservableCollection<ChangeHistoryClass>();



                    //  bool test = true;

                    //  var Examsbuf = new ObservableCollection<ChangeHistory>();
                    foreach (var Ch in ChangeRp.GetAll)
                    {


                        Changes.Add(new ChangeHistoryClass(Ch));

                        ////DelegateCommand bufer = new DelegateCommand(
                        //() =>
                        //{
                        //    MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, Exam.PatientId);
                        //    MessageBus.Default.Call("GetObsForOverview", this, Exam.Id.Value);
                        //    Controller.NavigateTo<ViewModelAddPhysical>();

                        //}
                        //);




                        //Exams.Add(new ObsStruct(bufer, Exam));




                    }




                    ViewSource.Source = Changes;


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
                //    Controller.NavigateTo<ViewModelChangesHistoy>();
                }
                catch (Exception exc)
                {
                    Changes = new ObservableCollection<ChangeHistoryClass>();
                    ViewSource.Source = Changes;
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
            }
        }

        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand FilterTextCommand { get; protected set; }
        public ViewModelChangesHistoy(NavigationController controller) : base(controller)
        {
            ViewSource = new CollectionViewSource();
            MessageBus.Default.Subscribe("SetChangesForChangesTable", SetChangesInDB);
            base.HasNavigation = true;

            _isSortByData = true;
            Changes = new ObservableCollection<ChangeHistoryClass>();
            FilterTextCommand = new DelegateCommand(
              () =>
              {

                

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
