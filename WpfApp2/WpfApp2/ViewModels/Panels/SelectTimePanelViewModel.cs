using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class SelectTimePanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //private int _selectedIdDocMed;
        //public int SelectedIdDocMed
        //{
        //    get
        //    {
        //        return _selectedIdDocMed;
        //    }
        //    set { _selectedIdDocMed = value; OnPropertyChanged(); IsMyOpChecked = false; }
        //}

        private void ConfirmCancle(object sender, object data)
        {
            ForCancleOpTimeView.Operation = null;
            ForCancleOpTimeView.PatientFullName = "";
            ForCancleOpTimeView.PatientNumber = "";
            ForCancleOpTimeView.Note = "Время свободно";
            ForCancleOpTimeView.Doctor = null;
            int id = Data.OperationDateTime.Get(ForCancleOpTimeView.id).Id;
            ForCancleOpTimeView.Select = new DelegateCommand(() =>
            {
                if (SelectedOpTimeView != null)
                    BuffSelectedOpTimeView = SelectedOpTimeView;
                SelectedOpTimeView = OpViewList.Where(e => e.id == id).FirstOrDefault();
                CurrentPanelSelectDoctor.ClearPanel();
                CurrentPanelSelectDoctor.PanelOpened = true;
            });
            ForCancleOpTimeView = null;
            ViewSource.View.Refresh();
        }
        #region SELECTdOCTOR
        public DelegateCommand SaveAllCommand { set; get; }
        public DelegateCommand SaveSelectDoctorRowCommand { set; get; }
        public DelegateCommand RevertSelectDoctorRowCommand { get; private set; }
        public ICommand OpenPanelSelectDoctorRow { protected set; get; }
        public DoctorSelectPanelViewModel CurrentPanelSelectDoctor { get; protected set; }
        #endregion
        #region SELECTtIME
        public DelegateCommand SaveAddTimeRowCommand { set; get; }
        public DelegateCommand RevertAddTimeRowCommand { get; private set; }
        public ICommand OpenPanelAddTimeRow { protected set; get; }
        public AddTimeRowPanelViewModel CurrentPanelSelectTime { get; protected set; }
        #endregion
        public OperationTimeView BuffSelectedOpTimeView { get; set; }
        public OperationTimeView ForCancleOpTimeView { get; set; }
        public OperationTimeView SelectedOpTimeView { get; set; }
        public ViewModelBase ParentVM { get; protected set; }
        public CollectionViewSource ViewSource { get; set; }
        public DelegateCommand AddTimeRow { get; set; }
        public class OperationTimeView
        {
            public System.DateTime Datetime { get; set; }
            public int id;
            public Operation Operation { get; set; }
            public DelegateCommand Cancle { get; set; }
            public DelegateCommand Delete { get; set; }
            public DelegateCommand Select { get; set; }
            public DelegateCommand SetUp { get; set; }
            public DelegateCommand SetDown { get; set; }
            public Doctor Doctor { get; set; }
            public string PatientFullName { get; set; }
            public string PatientNumber { get; set; }
            public string Note { get; set; }
            public OperationTimeView()
            {
                Datetime = System.DateTime.Now;
                Operation = new Operation();
                Doctor = new Doctor();
                PatientFullName = "";
                Note = "";
                //Cancle = new DelegateCommand(() => { });
                //Delete = new DelegateCommand(() => { });
                //Select = new DelegateCommand(() => { });
                //SetUp = new DelegateCommand(() => { });
                //SetDown = new DelegateCommand(() => { });
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _panelOpened = false;
        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }
        private System.DateTime _date;
        public System.DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                UpdateTimeTable();
                OnPropertyChanged();
            }
        }

        public List<OperationTimeView> OpViewList { get; set; }
        public void UpdateTimeTable()
        {
            using (var context = new MySqlContext())
            {
                OpViewList = new List<OperationTimeView>();
                //try
                //{
                var DoctorRep = new DoctorRepository(context);
                var OperationRep = new OperationRepository(context);
                var OperationDateTimeRep = new OperationDateTimeRepository(context);
                var PatientRep = new PatientsRepository(context);
                var OpViewElement = new OperationTimeView();
                var Patient = new Patient();
                //context.Set<Cities>().Where(entry => (entry.OblId == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList()
                foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day))
                {
                    OpViewElement = new OperationTimeView();
                    OpViewElement.id = opDate.Id;
                    OpViewElement.Datetime = opDate.Datetime;
                    OpViewElement.Note = opDate.Note;

                    OpViewElement.Select = new DelegateCommand(() =>
                    {
                        if (SelectedOpTimeView != null)
                            BuffSelectedOpTimeView = SelectedOpTimeView;
                        SelectedOpTimeView = OpViewList.Where(e => e.id == opDate.Id).FirstOrDefault();
                        CurrentPanelSelectDoctor.ClearPanel();
                        CurrentPanelSelectDoctor.PanelOpened = true;
                    });

                    OpViewElement.SetDown = new DelegateCommand(() =>
                    {
                        var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.id == opDate.Id).FirstOrDefault());
                        if (CurElementIndex != OpViewList.Count - 1)
                        {
                            var Buff = OpViewList[CurElementIndex].Datetime;
                            OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex + 1].Datetime;
                            OpViewList[CurElementIndex + 1].Datetime = Buff;

                            OpViewList.Sort((a, b) => a.Datetime.CompareTo(b.Datetime));

                            ViewSource.View.Refresh();
                        }
                    });

                    OpViewElement.SetUp = new DelegateCommand(() =>
                    {
                        var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.id == opDate.Id).FirstOrDefault());
                        if (CurElementIndex != 0)
                        {
                            //Operation op = Data.Operation.Get(OpViewList[CurElementIndex].Operation.Id);
                            //op.Datetime_id = OpViewList[CurElementIndex - 1].id;
                            //op = Data.Operation.Get(OpViewList[CurElementIndex - 1].Operation.Id);
                            //op.Datetime_id = OpViewList[CurElementIndex].id;

                            //OperationDateTime opData = Data.OperationDateTime.Get(OpViewList[CurElementIndex].id);
                            //opData.Datetime = OpViewList[CurElementIndex - 1].Datetime;
                            //Data.Complete();
                            //opData = Data.OperationDateTime.Get(OpViewList[CurElementIndex - 1].id);
                            //Data.Complete();

                            var Buff = OpViewList[CurElementIndex].Datetime;
                            OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex - 1].Datetime;
                            OpViewList[CurElementIndex - 1].Datetime = Buff;

                            OpViewList.Sort((a, b) => a.Datetime.CompareTo(b.Datetime));

                            ViewSource.View.Refresh();
                        }
                    });
                    OpViewElement.Delete = new DelegateCommand(() =>
                    {
                        var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            OpViewList.Remove(OpViewList.Where(e => e.id == opDate.Id).FirstOrDefault());
                            ViewSource.View.Refresh();
                        }
                    });
                    if (opDate.Operation_id != null && opDate.Operation_id != 0)
                    {
                        OpViewElement.Delete = new DelegateCommand(() =>
                        {
                            var dialogResult = MessageBox.Show("Отменить операцию?", "", MessageBoxButton.YesNo);
                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                ForCancleOpTimeView = OpViewList.Where(e => e.id == opDate.Id).FirstOrDefault();
                                MessageBus.Default.Call("SetFunctionsToReturnToOpCreation", null, null);
                                MessageBus.Default.Call("GetOperationIDForAddCancel", this, opDate.Operation_id);
                                Controller.NavigateTo<ViewModelCancelOperations>();
                                // a lot of work to do

                                //OpViewList.Remove(OpViewElement);

                                //ViewSource.View.Refresh();

                            }
                        });
                        OpViewElement.Select = new DelegateCommand(() =>
                        {
                            MessageBox.Show("Сначала отмените операцию");
                        });
                        OpViewElement.Operation = Data.Operation.Get(opDate.Operation_id.Value);
                        if (opDate.Doctor_id != null && opDate.Doctor_id.Value != 0)
                            OpViewElement.Doctor = Data.Doctor.Get(opDate.Doctor_id.Value);
                        //OpViewElement.IsFree = false;
                        Patient = Data.Patients.Get(OpViewElement.Operation.PatientId);
                        OpViewElement.PatientFullName = Patient.Sirname + " " + Patient.Name + " " + Patient.Patronimic;
                        OpViewElement.PatientNumber = Patient.Phone;
                    }
                    OpViewList.Add(OpViewElement);

                }
                OpViewList.Sort((a, b) => a.Datetime.CompareTo(b.Datetime));



                ViewSource.Source = OpViewList;
                ViewSource.View.Refresh();
            }
        }
        public void PanelClear()
        {
            if (((ViewModelAddOperation)ParentVM).Operation.Datetime_id != null)
            {
                return;
            }

            Date = (System.DateTime.Now.DayOfWeek == System.DayOfWeek.Sunday) ? System.DateTime.Now.AddDays(2) : System.DateTime.Now.AddDays(1);

            UpdateTimeTable();
            //}
            //catch (System.Exception ex)
            //{
            //    throw ex;
            //}

        }

        public SelectTimePanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            ParentVM = parentVM;
            MessageBus.Default.Subscribe("ConfirmCancle", ConfirmCancle);
            ViewSource = new CollectionViewSource();

            PanelClear();

            AddTimeRow = new DelegateCommand(
                () =>
                {

                    CurrentPanelSelectTime.ClearPanel();
                    CurrentPanelSelectTime.PanelOpened = true;

                });

            SaveAllCommand = new DelegateCommand(() =>
            {
                using (var context = new MySqlContext())
                {
                    var opDataToModify = new OperationDateTime();
                    var opDataToRemove = new OperationDateTime();
                    var test = true;
                    var OperationRep = new OperationRepository(context);
                    var OperationDateTimeRep = new OperationDateTimeRepository(context);
                    foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day))
                    {
                        test = true;
                        foreach (var opDateModified in OpViewList)
                        {
                            if (opDate.Id == opDateModified.id)
                            {
                                if ((SelectedOpTimeView != null && opDate.Id != SelectedOpTimeView.id) || SelectedOpTimeView == null)
                                {
                                    test = false;
                                    opDataToModify = Data.OperationDateTime.Get(opDate.Id);
                                    opDataToModify.Doctor_id = opDateModified.Doctor.Id;
                                    opDataToModify.Note = opDateModified.Note;
                                    opDataToModify.Operation_id = opDateModified.Operation.Id;
                                    opDataToModify.Datetime = opDateModified.Datetime;
                                    Data.Complete();
                                    break;
                                }
                            }
                        }
                        if (test && (SelectedOpTimeView != null && opDate.Id != SelectedOpTimeView.id) || (SelectedOpTimeView == null && test))
                        {
                            opDataToRemove = Data.OperationDateTime.Get(opDate.Id);
                            Data.OperationDateTime.Remove(opDataToRemove);
                            Data.Complete();
                        }
                    }
                }
                ((ViewModelAddOperation)ParentVM).SaveSelectTimeCommand.Execute();
                SelectedOpTimeView = null;
                BuffSelectedOpTimeView = null;
            });

            CurrentPanelSelectTime = new AddTimeRowPanelViewModel(this);

            RevertAddTimeRowCommand = new DelegateCommand(() =>
            {
                CurrentPanelSelectTime.PanelOpened = false;
            });

            SaveAddTimeRowCommand = new DelegateCommand(() =>
            {
                var newType = CurrentPanelSelectTime.GetPanelType();
                CurrentPanelSelectTime.PanelOpened = false;
                var OpViewElement = new OperationTimeView
                {
                    id = newType.Id,
                    Note = "Время свободно",
                    Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, newType.Datetime.Hour, newType.Datetime.Minute, newType.Datetime.Second)
                };
                OpViewElement.Select = new DelegateCommand(() =>
                {
                    if (SelectedOpTimeView != null)
                        BuffSelectedOpTimeView = SelectedOpTimeView;
                    SelectedOpTimeView = OpViewList.Where(e => e.id == OpViewElement.id).FirstOrDefault();
                    CurrentPanelSelectDoctor.ClearPanel();
                    CurrentPanelSelectDoctor.PanelOpened = true;
                });

                OpViewElement.SetDown = new DelegateCommand(() =>
                {
                    var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.id == OpViewElement.id).FirstOrDefault());
                    if (CurElementIndex != OpViewList.Count - 1)
                    {
                        var Buff = OpViewList[CurElementIndex].Datetime;
                        OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex + 1].Datetime;
                        OpViewList[CurElementIndex + 1].Datetime = Buff;

                        OpViewList.Sort((a, b) => a.Datetime.CompareTo(b.Datetime));

                        ViewSource.View.Refresh();
                    }
                });

                OpViewElement.SetUp = new DelegateCommand(() =>
                {
                    var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.id == OpViewElement.id).FirstOrDefault());
                    if (CurElementIndex != 0)
                    {
                        //Operation op = Data.Operation.Get(OpViewList[CurElementIndex].Operation.Id);
                        //op.Datetime_id = OpViewList[CurElementIndex - 1].id;
                        //op = Data.Operation.Get(OpViewList[CurElementIndex - 1].Operation.Id);
                        //op.Datetime_id = OpViewList[CurElementIndex].id;

                        //OperationDateTime opData = Data.OperationDateTime.Get(OpViewList[CurElementIndex].id);
                        //opData.Datetime = OpViewList[CurElementIndex - 1].Datetime;
                        //Data.Complete();
                        //opData = Data.OperationDateTime.Get(OpViewList[CurElementIndex - 1].id);
                        //Data.Complete();

                        var Buff = OpViewList[CurElementIndex].Datetime;
                        OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex - 1].Datetime;
                        OpViewList[CurElementIndex - 1].Datetime = Buff;

                        OpViewList.Sort((a, b) => a.Datetime.CompareTo(b.Datetime));

                        ViewSource.View.Refresh();
                    }
                });
                OpViewElement.Delete = new DelegateCommand(() =>
                {
                    var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        OpViewList.Remove(OpViewList.Where(e => e.id == OpViewElement.id).FirstOrDefault());
                        ViewSource.View.Refresh();
                    }
                });
                OpViewList.Add(OpViewElement);
                ViewSource.View.Refresh();

            });

            CurrentPanelSelectDoctor = new DoctorSelectPanelViewModel(this);

            RevertSelectDoctorRowCommand = new DelegateCommand(() =>
            {
                CurrentPanelSelectDoctor.PanelOpened = false;
                SelectedOpTimeView = BuffSelectedOpTimeView;
                BuffSelectedOpTimeView = null;
            });

            int buffForId = 0;

            SaveSelectDoctorRowCommand = new DelegateCommand(() =>
            {
                if (BuffSelectedOpTimeView != null)
                {
                    BuffSelectedOpTimeView.Note = "Время свободно";
                    BuffSelectedOpTimeView.Operation = null;
                    BuffSelectedOpTimeView.PatientFullName = "";
                    BuffSelectedOpTimeView.PatientNumber = "";
                    BuffSelectedOpTimeView.Doctor = null;
                    buffForId = BuffSelectedOpTimeView.id;
                    BuffSelectedOpTimeView.Delete = new DelegateCommand(() =>
                    {
                        var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            OpViewList.Remove(OpViewList.Where(e => e.id == buffForId).FirstOrDefault());
                            ViewSource.View.Refresh();
                        }
                    });
                    BuffSelectedOpTimeView = null;

                }
                SelectedOpTimeView.Delete = new DelegateCommand(() =>
                {
                    var elem = OpViewList.Where(e => e.id == SelectedOpTimeView.id).FirstOrDefault();
                    elem.Note = "Время свободно";
                    elem.Operation = null;
                    elem.PatientFullName = "";
                    elem.PatientNumber = "";
                    elem.Doctor = null;
                    elem.Delete = new DelegateCommand(() =>
                    {
                        var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            OpViewList.Remove(OpViewList.Where(e => e.id == elem.id).FirstOrDefault());
                            ViewSource.View.Refresh();
                        }
                    });
                    ViewSource.View.Refresh();
                });
                Patient patient = ((ViewModelAddOperation)ParentVM).CurrentPatient;
                SelectedOpTimeView.PatientFullName = patient.Sirname + " " + patient.Name + " " + patient.Patronimic;
                SelectedOpTimeView.PatientNumber = patient.Phone;
                SelectedOpTimeView.Operation = ((ViewModelAddOperation)ParentVM).Operation;
                SelectedOpTimeView.Doctor = CurrentPanelSelectDoctor.Doctors[CurrentPanelSelectDoctor.DoctorSelectedId].doc;
                SelectedOpTimeView.Note = CurrentPanelSelectDoctor.Commentary;
                CurrentPanelSelectDoctor.PanelOpened = false;
                ViewSource.View.Refresh();
            });
        }



        private string _shortText;
        public string ShortText
        {
            get { return _shortText; }
            set
            {
                _shortText = value;
                OnPropertyChanged();
            }
        }

        //private string _longText;
        //public string LongText
        //{
        //    get { return _longText; }
        //    set
        //    {
        //        _longText = value;
        //        OnPropertyChanged();
        //    }
        //}




        //public int GetPanelType()
        //{
        //    //var newType = new Anestethic();
        //    //newType.LongName = LongText;
        //    //newType.Str = ShortText;
        //    return SelectedOpTimeView;
        //}

        internal void ClearPanel()
        {
            PanelClear();
        }
    }
}
