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
    public struct OperationStruct
    {

        public DateTime Date { get; set; }
        public Operation Operation;
        public string Patient { get; set; }
        public string OpType { get; set; }
        public string Anestetic { get; set; }
        public DelegateCommand ToOperation { get; set; }


        public OperationStruct(DelegateCommand ToOperation, Operation Op)
        {
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

                if (!string.IsNullOrWhiteSpace(OperationTypeRep.Get(Op.OperationTypeId).ShortName))
                    OpType = OperationTypeRep.Get(Op.OperationTypeId).ShortName;
                else
                {
                    OpType = OperationTypeRep.Get(Op.OperationTypeId).LongName;
                }

                Anestetic = AnestethicRep.Get(Op.AnestheticId).Str;
            }

        }

    }

    public class ViewModelCalendarOperations : ViewModelBase, INotifyPropertyChanged
    {
        private int _sortId;

        public int SortId
        {
            get { return _sortId; }
            set
            {
                _sortId = value;


                MessageBus.Default.Call("SetCurrentACCOp", this, CurrentAcaunt);
                Controller.NavigateTo<ViewModelCalendarOperations>();

                OnPropertyChanged();
            }
        }



        private bool _isCompletedOp;
        private bool _isSortByData;
        int CurrentAcaunt;

        public bool IsCompletedOp
        {
            get { return _isCompletedOp; }
            set
            {
                _isCompletedOp = value;


                MessageBus.Default.Call("SetCurrentACCOp", this, CurrentAcaunt);
                Controller.NavigateTo<ViewModelCalendarOperations>();
                OnPropertyChanged();
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

        private void SetCurrentACCOp(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                try
                {
                    MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);


                    OperationRepository OperationRp = new OperationRepository(context);
                    bool testC = false;


                    BrigadeRepository BrigadeRep = new BrigadeRepository(context);
                    BrigadeMedPersonalRepository BrigadeMedRep = new BrigadeMedPersonalRepository(context);
                    Accaunt CurrentAc;

                    if (data != null)
                    {
                        CurrentAcaunt = (int)data;
                        CurrentAc = Data.Accaunt.Get((int)data);
                    }
                    else
                    {
                        CurrentAc = Data.Accaunt.Get(CurrentAcaunt);
                    }


                    Operations = new ObservableCollection<OperationStruct>();

                    if (CurrentAc != null)
                    {
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



                                if (Operation.OpResult != null && IsCompletedOp == false) { }
                                else if (Operation.OpCancle == null)
                                {
                                    DateTime buf1 = DateTime.Parse(Operation.Time);
                                    Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, buf1.Hour, buf1.Minute, buf1.Second);
                                    TimeSpan span = Operation.Date - DateTime.Now;
                                    if (span.Days <= 2 && span.Days >= 0 && Operation.Date > DateTime.Now)
                                    {
                                        Operationsbuf.Add(new OperationStruct(bufer, Operation));
                                        testC = true;
                                    }
                                    if (_sortId == 0 && Operation.Date.Year == DateTime.Now.Year && Operation.Date.Month == DateTime.Now.Month && Operation.Date.Day == DateTime.Now.Day)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation));
                                    }
                                    else if (_sortId == 1 && span.Days > 0 && span.Days <= 3)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation));
                                    }
                                    else if (_sortId == 2 && span.Days > 0 && span.Days <= 7)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation));
                                    }
                                    else if (_sortId == 3 && span.Days > 0 && span.Days <= 32)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation));
                                    }
                                    else if (_sortId == 4)
                                    {
                                        Operations.Add(new OperationStruct(bufer, Operation));
                                    }

                                }

                            }

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



        public ViewModelCalendarOperations(NavigationController controller) : base(controller)
        {
            Operations = new ObservableCollection<OperationStruct>();
            ViewSource = new CollectionViewSource();
            ViewSource.Source = Operations;
            IsSortByData = true;
            _sortId = 4;
            MessageBus.Default.Subscribe("SetCurrentACCOp", SetCurrentACCOp);
            base.HasNavigation = true;



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
