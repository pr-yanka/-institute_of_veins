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
    public struct docsAndMeds
    {
        public bool isDoc;
        public int id;
        public string name;
        //public MedPersonal Med;
        public docsAndMeds(bool isDoc, int id, string name)
        {
            this.isDoc = isDoc;
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            //if ()
            //  string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ".";
            return name;
        }
    }
    public class OperationStruct
    {

        public DateTime Date { get; set; }
        public Operation Operation;
        public string Patient { get; set; }
        public string OpType { get; set; }
        public string Anestetic { get; set; }
        public DelegateCommand ToOperation { get; set; }
        public DelegateCommand ToOperationResult { get; set; }
        public Visibility IsOpResult { get; set; }

        public bool IsFilteredPt { get; set; }
        public bool IsFilteredOpType { get; set; }
        public bool IsFilteredAnestetic { get; set; }
        public bool IsFilteredDate { get; set; }
        public bool IsVisibleTotal { get; set; }


        public OperationStruct(DelegateCommand ToOperation, Operation Op, DelegateCommand ToOpRes)
        {
            if (Op.итоги_операции != null)
            {
                IsOpResult = Visibility.Visible;

                ToOperationResult = ToOpRes;
            }
            else
            {
                IsOpResult = Visibility.Collapsed;
            }

            IsFilteredPt = false;
            IsFilteredOpType = false;
            IsFilteredAnestetic = false;
            IsFilteredDate = false;
            IsVisibleTotal = true;
            Operation = Op;
            this.ToOperation = ToOperation;
            DateTime buf1 = DateTime.Parse(Op.Time);
            Date = new DateTime(Op.Date.Year, Op.Date.Month, Op.Date.Day, buf1.Hour, buf1.Minute, buf1.Second);
            // Date = Op.Date.Day.ToString() + "." + Op.Date.Month.ToString() + "." + Op.Date.Year.ToString();
            // Time = buf1.Hour.ToString() + ":" + buf1.Minute.ToString();

            using (var context = new MySqlContext())
            {
                PatientsRepository PtRep = new PatientsRepository(context);
                AnestethicRepository AnestethicRep = new AnestethicRepository(context);
                OperationTypeRepository OperationTypeRep = new OperationTypeRepository(context);
                var CurrentPatient = PtRep.Get(Op.PatientId);
                Patient = CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

                //if (!string.IsNullOrWhiteSpace(OperationTypeRep.Get(Op.OperationTypeId).ShortName))
                //    OpType = OperationTypeRep.Get(Op.OperationTypeId).ShortName;
                //else
                //{
                //    OpType = OperationTypeRep.Get(Op.OperationTypeId).LongName;
                //}

                Anestetic = AnestethicRep.Get(Op.AnestheticId).Str;
            }

        }

    }

    public class ViewModelCalendarOperations : ViewModelBase, INotifyPropertyChanged
    {
        private Visibility _visOfNothingFaund;
        public Visibility VisOfNothingFaund
        {
            get { return _visOfNothingFaund; }
            set
            { _visOfNothingFaund = value; OnPropertyChanged(); }
        }
        private int _sortId;

        public int SortId
        {
            get { return _sortId; }
            set
            {
                _sortId = value;
                SetSelectedMedOrDocOps();
                Controller.NavigateTo<ViewModelCalendarOperations>();
                OnPropertyChanged();
            }
        }
        public DelegateCommand FilterTextCommand { get; protected set; }
        private Visibility _isMyOpVisible;
        public Visibility isMyOpVisible { get { return _isMyOpVisible; } set { _isMyOpVisible = value; OnPropertyChanged(); } }

        private bool _isCompletedOp;
        private bool _isSortByData;
        int CurrentAcaunt;

        public bool IsCompletedOp
        {
            get { return _isCompletedOp; }
            set
            {
                _isCompletedOp = value;


                SetSelectedMedOrDocOps();
                Controller.NavigateTo<ViewModelCalendarOperations>();
                OnPropertyChanged();
            }
        }
        private bool _isMyOpChecked;

        public bool IsMyOpChecked
        {
            get { return _isMyOpChecked; }
            set
            {
                _isMyOpChecked = value; OnPropertyChanged();
                if (value)
                    SetCurrentACCOp(null, null);


            }
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
        public CollectionViewSource ViewSource { get; set; }
        private int _selectedIdDocMed;
        public int SelectedIdDocMed
        {
            get
            {
                return _selectedIdDocMed;
            }
            set { _selectedIdDocMed = value; OnPropertyChanged(); IsMyOpChecked = false; }
        }
        //    IsMyOpChecked
        private docsAndMeds _selectedDocOrMed;

        public docsAndMeds SelectedDocOrMed
        {
            get { return _selectedDocOrMed; }
            set { _selectedDocOrMed = value; OnPropertyChanged(); SetSelectedMedOrDocOps(); }
        }

        private ObservableCollection<docsAndMeds> _docsAndMedsList;

        public ObservableCollection<docsAndMeds> DocsAndMedsList
        {
            get { return _docsAndMedsList; }
            set { _docsAndMedsList = value; OnPropertyChanged(); }
        }
        private void SetSelectedMedOrDocOps()
        {
           
            using (var context = new MySqlContext())
            {
                try
                {

                    MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);
                    DoctorRepository DocsRep = new DoctorRepository(context);


                    OperationRepository OperationRp = new OperationRepository(context);
                    //bool testC = false;


                    BrigadeRepository BrigadeRep = new BrigadeRepository(context);
                    BrigadeMedPersonalRepository BrigadeMedRep = new BrigadeMedPersonalRepository(context);
                    // Accaunt CurrentAc;



                    Operations = new ObservableCollection<OperationStruct>();



                    bool test = true;

                    var Operationsbuf = new ObservableCollection<OperationStruct>();
                    foreach (var Operation in OperationRp.GetAll)
                    {

                        test = true;
                        if (SelectedDocOrMed.id == 0)
                        {
                            test = false;
                        }
                        else if (SelectedDocOrMed.isDoc)
                            foreach (var Brigade in BrigadeRep.GetAll)
                            {

                                if (Brigade.id_операции == Operation.Id && SelectedDocOrMed.id == Brigade.id_врача)
                                {
                                    test = false;
                                }
                            }
                        else if (!SelectedDocOrMed.isDoc)
                            foreach (var Brigade in BrigadeMedRep.GetAll)
                            {
                                if (Brigade.id_операции == Operation.Id && SelectedDocOrMed.id == Brigade.id_медперсонал)
                                {
                                    test = false;
                                }
                            }


                        if (!test)
                        {
                            DelegateCommand bufer = new DelegateCommand(
                            () =>
                            {
                                MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);
                                Controller.NavigateTo<ViewModelOperationOverview>();
                            });
                            DelegateCommand bufer2 = new DelegateCommand(
                            () =>
                            {

                            });

                            if (Operation.итоги_операции != null)
                            {
                                bufer2 = new DelegateCommand(
                           () =>
                           {
                               MessageBus.Default.Call("GetOprForOprResultOverview", this, Operation.Id);
                               Controller.NavigateTo<ViewModelOperationResultOverview>();
                           });
                            }




                            if (Operation.OpResult != null && IsCompletedOp == false) { }
                            else if (Operation.OpCancle == null)
                            {
                                DateTime buf1 = DateTime.Parse(Operation.Time);
                                Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, buf1.Hour, buf1.Minute, buf1.Second);
                                TimeSpan span = Operation.Date - DateTime.Now;

                                if (_sortId == 0 && Operation.Date.Year == DateTime.Now.Year && Operation.Date.Month == DateTime.Now.Month && Operation.Date.Day == DateTime.Now.Day)
                                {
                                    Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                }
                                else if (_sortId == 1 && span.Days >= 0 && span.Days <= 3 && span.Hours > 0)
                                {

                                    if (span.Days == 0 && span.Hours == 0)
                                    { }
                                    else
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                    }
                                }
                                else if (_sortId == 2 && span.Days >= 0 && span.Days <= 7 && span.Hours > 0)
                                {
                                    if (span.Days == 0 && span.Hours == 0)
                                    {
                                    }
                                    else
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                    }
                                }
                                else if (_sortId == 3 && span.Days >= 0 && span.Days <= 32 && span.Hours > 0)
                                {
                                    if (span.Days == 0 && span.Hours == 0)
                                    {
                                    }
                                    else
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                    }
                                }
                                else if (_sortId == 4)
                                {
                                    Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                }

                            }

                        }

                    }

                    if (Operations.Count == 0)
                    {
                        VisOfNothingFaund = Visibility.Visible;
                    }
                    else
                    {
                        VisOfNothingFaund = Visibility.Collapsed;
                    }
                    ViewSource.Source = Operations;


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
                    FilterTextCommand.Execute();
                    Controller.NavigateTo<ViewModelCalendarOperations>();
                }
                catch (Exception exc)
                {
                    Operations = new ObservableCollection<OperationStruct>();
                    ViewSource.Source = Operations;
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
            }
            _filterText = "";
            OnPropertyChanged("FilterText");
        }


        private void SetVisibilityMyOp(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                try
                {
                    MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);
                    DoctorRepository DocsRep = new DoctorRepository(context);
                    isMyOpVisible = Visibility.Collapsed;
                    DocsAndMedsList = new ObservableCollection<docsAndMeds>();
                    DocsAndMedsList.Add(new docsAndMeds(false, 0, "всех"));


                    foreach (var x in DocsRep.GetAll)
                    {

                        DocsAndMedsList.Add(new docsAndMeds(true, x.Id, x.Sirname + " " + x.Name.ToCharArray()[0].ToString() + ". " + x.Patronimic.ToCharArray()[0].ToString() + "."));

                    }

                    foreach (var x in MedPersonalRep.GetAll)
                    {

                        DocsAndMedsList.Add(new docsAndMeds(false, x.Id, x.Surname + " " + x.Name.ToCharArray()[0].ToString() + ". " + x.Patronimic.ToCharArray()[0].ToString() + "."));

                    }
                    SelectedDocOrMed = DocsAndMedsList[0];

                    // Controller.NavigateTo<ViewModelCalendarOperations>();
                }
                catch { }
            }
        }

        private void SetCurrentACCOp(object sender, object data)
        {
          
            using (var context = new MySqlContext())
            {
                try
                {

                    DocsAndMedsList = new ObservableCollection<docsAndMeds>();



                    MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);
                    DoctorRepository DocsRep = new DoctorRepository(context);

                    DocsAndMedsList.Add(new docsAndMeds(false, 0, "всех"));

                    foreach (var x in DocsRep.GetAll)
                    {

                        DocsAndMedsList.Add(new docsAndMeds(true, x.Id, x.Sirname + " " + x.Name.ToCharArray()[0].ToString() + ". " + x.Patronimic.ToCharArray()[0].ToString() + "."));

                    }

                    foreach (var x in MedPersonalRep.GetAll)
                    {

                        DocsAndMedsList.Add(new docsAndMeds(false, x.Id, x.Surname + " " + x.Name.ToCharArray()[0].ToString() + ". " + x.Patronimic.ToCharArray()[0].ToString() + "."));

                    }



                    OperationRepository OperationRp = new OperationRepository(context);
                    bool testC = false;


                    BrigadeRepository BrigadeRep = new BrigadeRepository(context);
                    BrigadeMedPersonalRepository BrigadeMedRep = new BrigadeMedPersonalRepository(context);
                    Accaunt CurrentAc;

                    if (data != null)
                    {
                        CurrentAcaunt = (int)data;

                        CurrentAc = Data.Accaunt.Get((int)data);
                        if (CurrentAc.isAdmin != null && CurrentAc.isAdmin.Value)
                        {
                            isMyOpVisible = Visibility.Collapsed;
                            SelectedIdDocMed = 0;
                            SelectedDocOrMed = DocsAndMedsList[0];
                        }
                        else
                        {
                            isMyOpVisible = Visibility.Visible;
                            for (int i = 0; i < DocsAndMedsList.Count; ++i)
                            {
                                if (CurrentAc.isDoctor != null && CurrentAc.isDoctor.Value && DocsAndMedsList[i].isDoc == true && DocsAndMedsList[i].id == CurrentAc.idврач)
                                { SelectedIdDocMed = i; }
                                else if (CurrentAc.isMedPersonal != null && CurrentAc.isMedPersonal.Value && DocsAndMedsList[i].isDoc == false && DocsAndMedsList[i].id == CurrentAc.idмедперсонал)
                                {
                                    SelectedIdDocMed = i;
                                    SelectedIdDocMed = 0;
                                }

                            }
                        }
                    }
                    else
                    {
                        CurrentAc = Data.Accaunt.Get(CurrentAcaunt);
                        if (CurrentAc.isAdmin != null && CurrentAc.isAdmin.Value)
                        {
                            isMyOpVisible = Visibility.Collapsed;
                            SelectedIdDocMed = 0;
                            SelectedDocOrMed = DocsAndMedsList[0];
                        }
                        else
                        {
                            isMyOpVisible = Visibility.Visible;
                            for (int i = 0; i < DocsAndMedsList.Count; ++i)
                            {
                                if (CurrentAc.isDoctor != null && CurrentAc.isDoctor.Value && DocsAndMedsList[i].isDoc == true && DocsAndMedsList[i].id == CurrentAc.idврач)
                                { SelectedIdDocMed = i; }
                                else if (CurrentAc.isMedPersonal != null && CurrentAc.isMedPersonal.Value && DocsAndMedsList[i].isDoc == false && DocsAndMedsList[i].id == CurrentAc.idмедперсонал)
                                {
                                    SelectedIdDocMed = i;
                                }

                            }
                        }
                    }




                    if (CurrentAc == null || (CurrentAc.isAdmin != null && CurrentAc.isAdmin.Value))
                    {
                        isMyOpVisible = Visibility.Collapsed;
                        SelectedIdDocMed = 0;
                        SelectedDocOrMed = DocsAndMedsList[0];
                    }
                    else
                    {
                        Operations = new ObservableCollection<OperationStruct>();

                        bool test = true;

                        var Operationsbuf = new ObservableCollection<OperationStruct>();
                        foreach (var Operation in OperationRp.GetAll)
                        {

                            test = true;
                            if (CurrentAc.isDoctor != null && CurrentAc.isDoctor.Value)
                                foreach (var Brigade in BrigadeRep.GetAll)
                                {

                                    if (Brigade.id_операции == Operation.Id && CurrentAc.idврач == Brigade.id_врача)
                                    {
                                        test = false;
                                    }
                                }
                            else if (CurrentAc.isMedPersonal != null && CurrentAc.isMedPersonal.Value)
                                foreach (var Brigade in BrigadeMedRep.GetAll)
                                {
                                    if (Brigade.id_операции == Operation.Id && CurrentAc.idмедперсонал == Brigade.id_медперсонал)
                                    {
                                        test = false;
                                    }
                                }


                            if (!test)
                            {
                                DelegateCommand bufer = new DelegateCommand(
                                () =>
                                {
                                    MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);
                                    Controller.NavigateTo<ViewModelOperationOverview>();
                                }
                            );
                                DelegateCommand bufer2 = new DelegateCommand(
                        () =>
                        {

                        });

                                if (Operation.итоги_операции != null)
                                {
                                    bufer2 = new DelegateCommand(
                               () =>
                               {
                                   MessageBus.Default.Call("GetOprForOprResultOverview", this, Operation.Id);
                                   Controller.NavigateTo<ViewModelOperationResultOverview>();
                               });
                                }


                                if (Operation.OpResult != null && IsCompletedOp == false) { }
                                else if (Operation.OpCancle == null)
                                {
                                    DateTime buf1 = DateTime.Parse(Operation.Time);
                                    Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, buf1.Hour, buf1.Minute, buf1.Second);
                                    TimeSpan span = Operation.Date - DateTime.Now;
                                    if (span.Days <= 2 && span.Days >= 0 && Operation.Date > DateTime.Now)
                                    {
                                        Operationsbuf.Add(new OperationStruct(bufer, Operation, bufer2));
                                        testC = true;
                                    }
                                    if (_sortId == 0 && Operation.Date.Year == DateTime.Now.Year && Operation.Date.Month == DateTime.Now.Month && Operation.Date.Day == DateTime.Now.Day)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                    }
                                    else if (_sortId == 1 && span.Days >= 0 && span.Days <= 3 && span.Hours > 0)
                                    {

                                        if (span.Days == 0 && span.Hours == 0)
                                        { }
                                        else
                                        {
                                            Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                        }
                                    }
                                    else if (_sortId == 2 && span.Days >= 0 && span.Days <= 7 && span.Hours > 0)
                                    {
                                        if (span.Days == 0 && span.Hours == 0)
                                        {
                                        }
                                        else
                                        {
                                            Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                        }
                                    }
                                    else if (_sortId == 3 && span.Days >= 0 && span.Days <= 32 && span.Hours > 0)
                                    {
                                        if (span.Days == 0 && span.Hours == 0)
                                        {
                                        }
                                        else
                                        {
                                            Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                        }
                                    }
                                    else if (_sortId == 4)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation, bufer2));
                                    }

                                }

                            }

                        }

                        if (Operations.Count == 0)
                        {
                            VisOfNothingFaund = Visibility.Visible;
                        }
                        else
                        {
                            VisOfNothingFaund = Visibility.Collapsed;
                        }
                        ViewSource.Source = Operations;


                        if (testC)
                        {


                            //Operationsbuf = Operations;
                            CollectionViewSource viewSourceBuf = new CollectionViewSource();
                            viewSourceBuf.Source = Operationsbuf;
                            viewSourceBuf.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));
                            viewSourceBuf.View.Refresh();
                            var bff = viewSourceBuf.View.GetEnumerator();
                            bff.MoveNext();
                            Operation bffs = ((OperationStruct)bff.Current).Operation;
                            // TimeSpan span = bffs.Date - DateTime.Now;
                            //   if (span.)
                            //   int t = ((Operation)viewSourceBuf.View.GetEnumerator().Current).Id;

                            MessageBus.Default.Call("GetAcaunt", bffs, CurrentAcaunt);
                            MessageBus.Default.Call("SetAlertVisibility", this, Visibility.Visible);



                        }
                        else
                        {
                            MessageBus.Default.Call("GetAcaunt", null, CurrentAcaunt);
                            MessageBus.Default.Call("SetAlertVisibility", this, Visibility.Collapsed);
                        }
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
                        FilterTextCommand.Execute();
                        _isMyOpChecked = true;
                        OnPropertyChanged("IsMyOpChecked");
                        Controller.NavigateTo<ViewModelCalendarOperations>();
                    }
                }
                catch (Exception exc)
                {
                    Operations = new ObservableCollection<OperationStruct>();
                    ViewSource.Source = Operations;
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
            }
            _filterText = "";
            OnPropertyChanged("FilterText");
        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public ObservableCollection<OperationStruct> _operations;
        public ObservableCollection<OperationStruct> Operations { get { return _operations; } set { _operations = value; OnPropertyChanged(); } }
        private string _filterText;
        public string FilterText { get { return _filterText; } set { _filterText = value; OnPropertyChanged(); FilterTextCommand.Execute(); } }



        public ViewModelCalendarOperations(NavigationController controller) : base(controller)
        {
            VisOfNothingFaund = Visibility.Collapsed;
            Operations = new ObservableCollection<OperationStruct>();
            ViewSource = new CollectionViewSource();
            ViewSource.Source = Operations;
            IsSortByData = true;
            _sortId = 4;
            SelectedIdDocMed = 1;

            MessageBus.Default.Subscribe("SetCurrentACCOp", SetCurrentACCOp);
            MessageBus.Default.Subscribe("SetVisibilityMyOp", SetVisibilityMyOp);
            base.HasNavigation = true;

            FilterTextCommand = new DelegateCommand(
              () =>
              {
                  int count = 0;
                  if (!string.IsNullOrWhiteSpace(FilterText))
                  {
                      for (int i = 0; i < Operations.Count; ++i)
                      {


                          if (Operations[i].Patient.ToLower().Contains(FilterText.ToLower()))
                          {
                              Operations[i].IsFilteredPt = true;
                              Operations[i].IsVisibleTotal = true; ++count;
                          }
                          else
                          {
                              Operations[i].IsFilteredPt = false;
                          }
                          if (Operations[i].OpType.ToLower().Contains(FilterText.ToLower()))
                          {
                              Operations[i].IsFilteredOpType = true;
                              Operations[i].IsVisibleTotal = true; ++count;
                          }
                          else
                          {
                              Operations[i].IsFilteredOpType = false;
                          }
                          if (Operations[i].Date.ToString().ToLower().Contains(FilterText.ToLower()))
                          {
                              Operations[i].IsFilteredDate = true;
                              Operations[i].IsVisibleTotal = true; ++count;
                          }
                          else
                          {
                              Operations[i].IsFilteredDate = false;
                          }
                          if (Operations[i].Anestetic.ToLower().Contains(FilterText.ToLower()))
                          {
                              Operations[i].IsFilteredAnestetic = true;
                              Operations[i].IsVisibleTotal = true; ++count;
                          }
                          else
                          {
                              Operations[i].IsFilteredAnestetic = false;
                          }
                          if (!Operations[i].IsFilteredDate && !Operations[i].IsFilteredOpType && !Operations[i].IsFilteredPt && !Operations[i].IsFilteredAnestetic)
                          {
                              Operations[i].IsVisibleTotal = false;
                          }


                      }
                      if (_isSortByData == true)
                      {

                          ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                          // Let the UI control refresh in order for changes to take place.
                          ViewSource.View.Refresh();

                      }
                      if (Operations.Count == 0 || count == 0)
                      {
                          VisOfNothingFaund = Visibility.Visible;
                      }
                      else
                      {
                          ViewSource.Source = Operations;
                          ViewSource.View.Refresh();
                          VisOfNothingFaund = Visibility.Collapsed;
                      }


                      Controller.NavigateTo<ViewModelCalendarOperations>();
                  }
                  else
                  {
                      foreach (var x in Operations)
                      {
                          x.IsFilteredAnestetic = false;
                          x.IsFilteredDate = false;
                          x.IsFilteredOpType = false;
                          x.IsFilteredPt = false;
                          x.IsVisibleTotal = true;
                      }
                      ViewSource.Source = Operations;
                      ViewSource.View.Refresh();
                      Controller.NavigateTo<ViewModelCalendarOperations>();
                  }

              }
          );

            ToPhysicalCommand = new DelegateCommand(
            () =>
            {
                Controller.NavigateTo<ViewModelOperationOverview>();
            }
        );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
    }
}
