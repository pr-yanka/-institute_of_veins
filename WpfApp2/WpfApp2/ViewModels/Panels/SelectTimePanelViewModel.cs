using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            int id = Data.OperationDateTime.Get(ForCancleOpTimeView.Id).Id;
            //ForCancleOpTimeView.Select = new DelegateCommand(() =>
            //{
            //    if (SelectedOpTimeView != null)
            //        BuffSelectedOpTimeView = SelectedOpTimeView;
            //    using (var context = new MySqlContext())
            //    {
            //        var timeItem = context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Datetime.Year == SelectedOpTimeView.Datetime.Year && e.Datetime.Month == SelectedOpTimeView.Datetime.Month && e.Datetime.Day == SelectedOpTimeView.Datetime.Day).FirstOrDefault();
            //        if (timeItem == null)
            //        {
            //            foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == SelectedOpTimeView.Datetime.Year && e.Datetime.Month == SelectedOpTimeView.Datetime.Month && e.Datetime.Day == SelectedOpTimeView.Datetime.Day))
            //            {
            //                Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate.Id));
            //            }
            //        }
            //    }
            //    SelectedOpTimeView = OpViewList.Where(e => e.Id == id).FirstOrDefault();
            //    CurrentPanelSelectDoctor.ClearPanel();
            //    CurrentPanelSelectDoctor.PanelOpened = true;
            //});
            int buffForId = ForCancleOpTimeView.Id;
            // ForCancleOpTimeView.Delete = new DelegateCommand(() =>
            //{
            //    var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
            //    if (dialogResult == MessageBoxResult.Yes)
            //    {
            //        using (var context1 = new MySqlContext())
            //        {
            //            OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
            //            var ourOpTime = timeOpRep.GetAll.Where(e => e.Operation_id == null && e.Id == buffForId).FirstOrDefault();
            //            ////ViewSource.View.Refresh();


            //            bool test = true;
            //            //  OperationDateTime timeItem;

            //            var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == ourOpTime.Datetime.Hour && e.Datetime.Minute == ourOpTime.Datetime.Minute).FirstOrDefault();
            //            if (timeItem == null)
            //            {
            //                test = false;
            //            }

            //            if (!test)
            //            {
            //                var opDataToRemove = Data.OperationDateTime.Get(ourOpTime.Id);
            //                Data.OperationDateTime.Remove(opDataToRemove);
            //                Data.Complete();
            //                OpViewList.Remove(OpViewList.Where(e => e.id == ourOpTime.Id).FirstOrDefault());
            //                //ViewSource.View.Refresh();
            //            }
            //            else
            //            {
            //                MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
            //            }
            //        }

            //    }
            //});

            ForCancleOpTimeView = null;
            ////ViewSource.View.Refresh();
            LoadTimeTable();
            UpdateTimeTable();
        }
        #region SELECTdOCTOR
        public DelegateCommand SaveAllCommand { set; get; }
        public DelegateCommand SaveSelectDoctorRowCommand { set; get; }
        public DelegateCommand RevertSelectDoctorRowCommand { get; private set; }
        public ICommand OpenPanelSelectDoctorRow { protected set; get; }
        public DoctorSelectPanelViewModel CurrentPanelSelectDoctor { get; protected set; }
        #endregion
        #region SELECTtIME
        public DelegateCommand SaveTemplateCommand { get; private set; }
        public DelegateCommand SaveAddTimeRowCommand { set; get; }
        public DelegateCommand RevertAddTimeRowCommand { get; private set; }
        public ICommand OpenPanelAddTimeRow { protected set; get; }
        public AddTimeRowPanelViewModel CurrentPanelSelectTime { get; protected set; }
        #endregion
        public OperationTimeView BuffSelectedOpTimeView { get; set; }
        public OperationTimeView ForCancleOpTimeView { get; set; }
        public OperationTimeView SelectedOpTimeViewCopy { get; set; }
        public OperationTimeView SelectedOpTimeView { get; set; }
        public ViewModelBase ParentVM { get; protected set; }
        public CollectionViewSource ViewSource { get; set; }
        public DelegateCommand AddTimeRow { get; set; }
        public class OperationTimeView : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                //если PropertyChanged не нулевое - оно будет разбужено
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private System.DateTime _datetime;
            private int _id;
            private string _patientFullName;
            private string _patientNumber;
            private string _note;
            private Operation _operation;
            private DelegateCommand _delete;
            private DelegateCommand _select;
            private DelegateCommand _setUp;
            private DelegateCommand _setDown;
            private Doctor _doctor;
            public Doctor Doctor
            {
                get
                {
                    return _doctor;
                }
                set
                {
                    _doctor = value;
                    OnPropertyChanged();
                }
            }
            public Operation Operation
            {
                get
                {
                    return _operation;
                }
                set
                {
                    _operation = value;
                    OnPropertyChanged();
                }
            }
            public DelegateCommand Delete
            {
                get
                {
                    return _delete;
                }
                set
                {
                    _delete = value;
                    OnPropertyChanged();
                }
            }
            public DelegateCommand Select
            {
                get
                {
                    return _select;
                }
                set
                {
                    _select = value;
                    OnPropertyChanged();
                }
            }
            public DelegateCommand SetUp
            {
                get
                {
                    return _setUp;
                }
                set
                {
                    _setUp = value;
                    OnPropertyChanged();
                }
            }
            public DelegateCommand SetDown
            {
                get
                {
                    return _setDown;
                }
                set
                {
                    _setDown = value;
                    OnPropertyChanged();
                }
            }

            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
            public string PatientFullName
            {
                get
                {
                    return _patientFullName;
                }
                set
                {
                    _patientFullName = value;
                    OnPropertyChanged();
                }
            }
            public System.DateTime Datetime
            {
                get
                {
                    return _datetime;
                }
                set
                {
                    _datetime = value;
                    OnPropertyChanged();
                }
            }
            public string PatientNumber
            {
                get
                {
                    return _patientNumber;
                }
                set
                {
                    _patientNumber = value;
                    OnPropertyChanged();
                }
            }
            public string Note
            {
                get
                {
                    return _note;
                }
                set
                {
                    _note = value;
                    OnPropertyChanged();
                }
            }


            public OperationTimeView(int id, System.DateTime Datetime)
            {
                this.Id = id;
                this.Datetime = Datetime;
                PatientFullName = "";
                Note = "Время свободно";

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
        private bool _saveChangesBtnVis;
        public bool SaveChangesBtnVis
        {
            get { return _saveChangesBtnVis; }
            set
            {
                _saveChangesBtnVis = value;

                OnPropertyChanged();
            }
        }
        public ObservableCollection<OperationTimeView> _opViewList;
        public ObservableCollection<OperationTimeView> OpViewList { get { return _opViewList; } set { _opViewList = value; OnPropertyChanged(); } }

        private void SetDefaultFunctions(ref OperationTimeView opViewElement)
        {
            var opCopy = opViewElement;
            opViewElement.Select = new DelegateCommand(() =>
            {
                if (SelectedOpTimeView != null)
                {
                    BuffSelectedOpTimeView = SelectedOpTimeView;
                    if (((ViewModelAddOperation)ParentVM).Operation.Datetime_id != null && ((ViewModelAddOperation)ParentVM).Operation.Datetime_id != 0)
                    {
                        var OpDate = Data.OperationDateTime.Get(((ViewModelAddOperation)ParentVM).Operation.Datetime_id.Value);
                        if (OpDate != null)
                        {
                            Data.OperationDateTime.Remove(OpDate);
                            Data.Complete();
                            using (var context = new MySqlContext())
                            {
                                var timeItem = context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Datetime.Year == OpDate.Datetime.Year && e.Datetime.Month == OpDate.Datetime.Month && e.Datetime.Day == OpDate.Datetime.Day).FirstOrDefault();
                                if (timeItem == null)
                                {
                                    foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == OpDate.Datetime.Year && e.Datetime.Month == OpDate.Datetime.Month && e.Datetime.Day == OpDate.Datetime.Day))
                                    {
                                        Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate.Id));
                                    }
                                }
                                Data.Complete();
                            }
                        }
                    }
                }
                SelectedOpTimeView = OpViewList.Where(e => e.Id == opCopy.Id && e.Datetime == opCopy.Datetime).FirstOrDefault();
                SelectedOpTimeView.Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, SelectedOpTimeView.Datetime.Hour, SelectedOpTimeView.Datetime.Minute, 0);
                CurrentPanelSelectDoctor.ClearPanel();
                CurrentPanelSelectDoctor.PanelOpened = true;
            });

            opViewElement.SetDown = new DelegateCommand(() =>
            {
                var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.Id == opCopy.Id && e.Datetime == opCopy.Datetime).FirstOrDefault());
                if (CurElementIndex != OpViewList.Count - 1)
                {
                    var Buff = OpViewList[CurElementIndex].Datetime;
                    OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex + 1].Datetime;
                    OpViewList[CurElementIndex + 1].Datetime = Buff;
                    OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));
                    //OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));
                }
            });

            opViewElement.SetUp = new DelegateCommand(() =>
            {
                var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.Id == opCopy.Id && e.Datetime == opCopy.Datetime).FirstOrDefault());
                if (CurElementIndex != 0)
                {
                    var Buff = OpViewList[CurElementIndex].Datetime;
                    OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex - 1].Datetime;
                    OpViewList[CurElementIndex - 1].Datetime = Buff;

                    OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));

                    //ViewSource.View.Refresh();
                }
            });

            opViewElement.Delete = new DelegateCommand(() =>
            {
                var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    OpViewList.Remove(OpViewList.Where(e => e.Id == opCopy.Id && e.Datetime == opCopy.Datetime).FirstOrDefault());
                    //bool test = true;
                    //  OperationDateTime timeItem;
                    //using (var context1 = new MySqlContext())
                    //{
                    //    OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
                    //    var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == opViewElement.Datetime.Hour && e.Datetime.Minute == opViewElement.Datetime.Minute).FirstOrDefault();
                    //    if (timeItem == null)
                    //    {
                    //        test = false;
                    //    }

                    //    if (!test)
                    //    {
                    //        var opDataToRemove = Data.OperationDateTime.Get(opViewElement.id);
                    //        Data.OperationDateTime.Remove(opDataToRemove);
                    //        Data.Complete();
                    //        OpViewList.Remove(OpViewList.Where(e => e.id == opViewElement.id).FirstOrDefault());
                    //        //ViewSource.View.Refresh();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
                    //    }
                    //}
                }
            });
        }

        public void LoadTimeTable()
        {
            using (var context = new MySqlContext())
            {
                OpViewList = new ObservableCollection<OperationTimeView>();
                //try
                //{
                //bool ultraTest = false;
                var DoctorRep = new DoctorRepository(context);
                var OperationRep = new OperationRepository(context);
                var OperationDateTimeRep = new OperationDateTimeRepository(context);
                var PatientRep = new PatientsRepository(context);
                var OpDateTimeTemplateRep = new OperationDateTimeTemplateRepository(context);
                OperationTimeView opViewElement;

                //context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day)
                foreach (var opDate in OpDateTimeTemplateRep.GetAll.ToArray())
                {

                    opViewElement = new OperationTimeView(opDate.Id, new System.DateTime(Date.Year, Date.Month, Date.Day, opDate.TimeRow.Hour, opDate.TimeRow.Minute, 0));

                    SetDefaultFunctions(ref opViewElement);

                    OpViewList.Add(opViewElement);

                }
                OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));



                //ViewSource.Source = OpViewList;

                //ViewSource.View.Refresh();
            }
        }

        public void UpdateTimeTable()
        {
            using (var context = new MySqlContext())
            {
                var OpTimesOnCurrentDay = context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day);
                if (OpTimesOnCurrentDay.FirstOrDefault() != null)
                {
                    SaveChangesBtnVis = true;
                    OperationTimeView opViewElement;
                    var Patient = new Patient();
                    OpViewList = new ObservableCollection<OperationTimeView>();
                    foreach (var opDate in OpTimesOnCurrentDay)
                    {
                        if (opDate.Operation_id != null && opDate.Operation_id != 0)
                        {
                            opViewElement = new OperationTimeView(opDate.Id, opDate.Datetime);

                            SetDefaultFunctions(ref opViewElement);

                            opViewElement.Delete = new DelegateCommand(() =>
                            {
                                var dialogResult = MessageBox.Show("Отменить операцию?", "", MessageBoxButton.YesNo);

                                if (dialogResult == MessageBoxResult.Yes)
                                {
                                    ForCancleOpTimeView = OpViewList.Where(e => e.Operation != null && e.Operation.Id == opDate.Operation_id && opDate.Datetime.Hour == e.Datetime.Hour && opDate.Datetime.Minute == e.Datetime.Minute).FirstOrDefault();
                                    MessageBus.Default.Call("SetFunctionsToReturnToOpCreation", null, null);
                                    MessageBus.Default.Call("GetOperationIDForAddCancel", this, opDate.Operation_id);
                                    Controller.NavigateTo<ViewModelCancelOperations>();
                                    // a lot of work to do
                                }
                            });

                            opViewElement.Select = new DelegateCommand(() =>
                            {
                                MessageBox.Show("Сначала отмените операцию");
                            });

                            opViewElement.Operation = Data.Operation.Get(opDate.Operation_id.Value);

                            if (opDate.Doctor_id != null && opDate.Doctor_id.Value != 0)
                                opViewElement.Doctor = Data.Doctor.Get(opDate.Doctor_id.Value);
                            //opViewElement.IsFree = false;

                            Patient = Data.Patients.Get(opViewElement.Operation.PatientId);
                            opViewElement.PatientFullName = Patient.Sirname + " " + Patient.Name.ToCharArray()[0] + ". " + Patient.Patronimic.ToCharArray()[0] + ".";
                            opViewElement.PatientNumber = Patient.Phone;
                            opViewElement.Note = opDate.Note;
                        }
                        else
                        {
                            opViewElement = new OperationTimeView(opDate.Id, opDate.Datetime);
                            SetDefaultFunctions(ref opViewElement);
                        }
                        OpViewList.Add(opViewElement);

                        //}
                    }
                    OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));
                }
                else
                {
                    SaveChangesBtnVis = false;
                    LoadTimeTable();
                }
                if (SelectedOpTimeViewCopy != null && SelectedOpTimeViewCopy.Datetime.Year == Date.Year && SelectedOpTimeViewCopy.Datetime.Month == Date.Month && SelectedOpTimeViewCopy.Datetime.Day == Date.Day)
                {
                    SaveChangesBtnVis = true;
                    var itemSelected = OpViewList.Where(e => e.Datetime.Hour == SelectedOpTimeViewCopy.Datetime.Hour && e.Datetime.Minute == SelectedOpTimeViewCopy.Datetime.Minute).FirstOrDefault();
                    if (itemSelected != null)
                    {
                        itemSelected.Delete = SelectedOpTimeViewCopy.Delete;
                        itemSelected.Doctor = SelectedOpTimeViewCopy.Doctor;
                        itemSelected.Note = SelectedOpTimeViewCopy.Note;
                        itemSelected.Operation = SelectedOpTimeViewCopy.Operation;
                        itemSelected.PatientFullName = SelectedOpTimeViewCopy.PatientFullName;
                        itemSelected.Datetime = SelectedOpTimeViewCopy.Datetime;
                        itemSelected.PatientNumber = SelectedOpTimeViewCopy.PatientNumber;
                    }
                    else
                    {
                        var opViewElement = new OperationTimeView(SelectedOpTimeViewCopy.Id, SelectedOpTimeViewCopy.Datetime);
                        SetDefaultFunctions(ref opViewElement);
                        opViewElement.Delete = SelectedOpTimeViewCopy.Delete;
                        opViewElement.Doctor = SelectedOpTimeViewCopy.Doctor;
                        opViewElement.Note = SelectedOpTimeViewCopy.Note;
                        opViewElement.Operation = SelectedOpTimeViewCopy.Operation;
                        opViewElement.PatientFullName = SelectedOpTimeViewCopy.PatientFullName;
                        opViewElement.Datetime = SelectedOpTimeViewCopy.Datetime;
                        opViewElement.PatientNumber = SelectedOpTimeViewCopy.PatientNumber;
                        OpViewList.Add(opViewElement);
                        OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));
                    }
                }
            }
        }
        //                if (SelectedOpTimeViewCopy != null && SelectedOpTimeViewCopy.Datetime.Year == Date.Year && SelectedOpTimeViewCopy.Datetime.Month == Date.Month && SelectedOpTimeViewCopy.Datetime.Day == Date.Day)
        //                {
        //                    var itemSelected = OpViewList.Where(e => e.id == SelectedOpTimeViewCopy.id).FirstOrDefault();
        //// itemSelected.Cancle = SelectedOpTimeViewCopy.Cancle;
        //itemSelected.Delete = SelectedOpTimeViewCopy.Delete;
        //                    itemSelected.Doctor = SelectedOpTimeViewCopy.Doctor;
        //                    itemSelected.Note = SelectedOpTimeViewCopy.Note;
        //                    itemSelected.Operation = SelectedOpTimeViewCopy.Operation;
        //                    itemSelected.PatientFullName = SelectedOpTimeViewCopy.PatientFullName;
        //                    itemSelected.Datetime = SelectedOpTimeViewCopy.Datetime;
        //                    itemSelected.PatientNumber = SelectedOpTimeViewCopy.PatientNumber;
        //                }


        //{

        //    using (var context = new MySqlContext())
        //    {
        //        OperationTimeView opViewElement;
        //        var Patient = new Patient();
        //        if (OpViewList != null)
        //        {
        //            foreach (var time in OpViewList)
        //            {
        //                time.Note = "Время свободно";
        //                time.Operation = null;
        //                time.PatientFullName = "";
        //                time.PatientNumber = "";
        //                time.Doctor = null;
        //                time.Delete = new DelegateCommand(() =>
        //                {
        //                    var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
        //                    if (dialogResult == MessageBoxResult.Yes)
        //                    {
        //                        bool test = true;
        //                        //  OperationDateTime timeItem;
        //                        using (var context1 = new MySqlContext())
        //                        {
        //                            OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
        //                            var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == time.Datetime.Hour && e.Datetime.Minute == time.Datetime.Minute).FirstOrDefault();
        //                            if (timeItem == null)
        //                            {
        //                                test = false;
        //                            }

        //                            if (!test)
        //                            {
        //                                var opDataToRemove = Data.OperationDateTime.Get(time.id);
        //                                Data.OperationDateTime.Remove(opDataToRemove);
        //                                Data.Complete();
        //                                OpViewList.Remove(OpViewList.Where(e => e.id == time.id).FirstOrDefault());
        //                                //ViewSource.View.Refresh();
        //                            }
        //                            else
        //                            {
        //                                MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
        //                            }
        //                        }
        //                    }
        //                });
        //                time.Select = new DelegateCommand(() =>
        //                {
        //                    if (SelectedOpTimeView != null)
        //                        BuffSelectedOpTimeView = SelectedOpTimeView;
        //                    SelectedOpTimeView = OpViewList.Where(e => e.id == time.id).FirstOrDefault();
        //                    SelectedOpTimeView.Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, SelectedOpTimeView.Datetime.Hour, SelectedOpTimeView.Datetime.Minute, 0);
        //                    CurrentPanelSelectDoctor.ClearPanel();
        //                    CurrentPanelSelectDoctor.PanelOpened = true;
        //                });
        //            }

        //            foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day))
        //            {
        //                //if (opDate.Operation_id != null && opDate.Operation_id != 0 && opDate.Datetime.Year == Date.Year && opDate.Datetime.Month == Date.Month && opDate.Datetime.Day == Date.Day)
        //                //{
        //                opViewElement = OpViewList.Where(e => e.Datetime.Hour == opDate.Datetime.Hour && e.Datetime.Minute == opDate.Datetime.Minute).FirstOrDefault();
        //                opViewElement.Delete = new DelegateCommand(() =>
        //                {
        //                    var dialogResult = MessageBox.Show("Отменить операцию?", "", MessageBoxButton.YesNo);
        //                    if (dialogResult == MessageBoxResult.Yes)
        //                    {
        //                        ForCancleOpTimeView = OpViewList.Where(e => e.Operation != null && e.Operation.Id == opDate.Operation_id && opDate.Datetime.Hour == e.Datetime.Hour && opDate.Datetime.Minute == e.Datetime.Minute).FirstOrDefault();
        //                        MessageBus.Default.Call("SetFunctionsToReturnToOpCreation", null, null);
        //                        MessageBus.Default.Call("GetOperationIDForAddCancel", this, opDate.Operation_id);
        //                        Controller.NavigateTo<ViewModelCancelOperations>();
        //                        // a lot of work to do

        //                        //OpViewList.Remove(opViewElement);

        //                        ////ViewSource.View.Refresh();

        //                    }
        //                });
        //                opViewElement.Select = new DelegateCommand(() =>
        //                {
        //                    MessageBox.Show("Сначала отмените операцию");
        //                });
        //                opViewElement.Operation = Data.Operation.Get(opDate.Operation_id.Value);
        //                if (opDate.Doctor_id != null && opDate.Doctor_id.Value != 0)
        //                    opViewElement.Doctor = Data.Doctor.Get(opDate.Doctor_id.Value);
        //                //opViewElement.IsFree = false;
        //                Patient = Data.Patients.Get(opViewElement.Operation.PatientId);
        //                opViewElement.PatientFullName = Patient.Sirname + " " + Patient.Name + " " + Patient.Patronimic;
        //                opViewElement.PatientNumber = Patient.Phone;
        //                opViewElement.Note = opDate.Note;
        //                //}
        //            }
        //        }
        //    }
        //    if (SelectedOpTimeViewCopy != null && SelectedOpTimeViewCopy.Datetime.Year == Date.Year && SelectedOpTimeViewCopy.Datetime.Month == Date.Month && SelectedOpTimeViewCopy.Datetime.Day == Date.Day)
        //    {
        //        var itemSelected = OpViewList.Where(e => e.id == SelectedOpTimeViewCopy.id).FirstOrDefault();
        //        // itemSelected.Cancle = SelectedOpTimeViewCopy.Cancle;
        //        itemSelected.Delete = SelectedOpTimeViewCopy.Delete;
        //        itemSelected.Doctor = SelectedOpTimeViewCopy.Doctor;
        //        itemSelected.Note = SelectedOpTimeViewCopy.Note;
        //        itemSelected.Operation = SelectedOpTimeViewCopy.Operation;
        //        itemSelected.PatientFullName = SelectedOpTimeViewCopy.PatientFullName;
        //        itemSelected.Datetime = SelectedOpTimeViewCopy.Datetime;
        //        itemSelected.PatientNumber = SelectedOpTimeViewCopy.PatientNumber;
        //    }
        //    //if (OpViewList != null)
        //    //ViewSource.View.Refresh();
        //}



        public void PanelClear()
        {
            if (((ViewModelAddOperation)ParentVM).Operation.Datetime_id != null)
            {
                return;
            }



            Date = (System.DateTime.Now.DayOfWeek == System.DayOfWeek.Saturday) ? System.DateTime.Now.AddDays(2) : System.DateTime.Now.AddDays(1);
            LoadTimeTable();
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

            //using (var context = new MySqlContext())
            //{
            //    var OperationDateTimeRep = new OperationDateTimeRepository(context);
            //    foreach (var opDate1 in OperationDateTimeRep.GetAll)
            //    {
            //        if (opDate1.Operation_id == null || opDate1.Operation_id == 0)
            //        {
            //            foreach (var opDate2 in OperationDateTimeRep.GetAll)
            //            {
            //                if (opDate1.Id != opDate2.Id && (opDate1.Operation_id == null || opDate1.Operation_id == 0) && (opDate2.Operation_id == null || opDate2.Operation_id == 0) && opDate1.Datetime == opDate2.Datetime)
            //                {
            //                    Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate2.Id));
            //                    Data.Complete();
            //                }
            //            }
            //        }
            //    }
            //}

            MessageBus.Default.Subscribe("ConfirmCancle", ConfirmCancle);
            ViewSource = new CollectionViewSource();
            //SelectedOpTimeViewCopy = new OperationTimeView();
            PanelClear();
            AddTimeRow = new DelegateCommand(() =>
            {

                CurrentPanelSelectTime.ClearPanel();
                CurrentPanelSelectTime.PanelOpened = true;

            });

            SaveTemplateCommand = new DelegateCommand(() =>
            {
                var dialogResult = MessageBox.Show("Сохранить шаблон?", "", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    foreach (var OpTime in Data.OperationDateTimeTemplate.GetAll)
                    {
                        Data.OperationDateTimeTemplate.Remove(OpTime);
                    }
                    Data.Complete();
                    OperationDateTimeTemplate TimeRow;
                    foreach (var OpTime in OpViewList)
                    {
                        TimeRow = new OperationDateTimeTemplate
                        {
                            TimeRow = new System.DateTime(1, 1, 1, OpTime.Datetime.Hour, OpTime.Datetime.Minute, 0)
                        };
                        Data.OperationDateTimeTemplate.Add(TimeRow);
                    }
                    Data.Complete();
                }
            });

            SaveAllCommand = new DelegateCommand(() =>
            {
                using (var context = new MySqlContext())
                {
                    OperationDateTime ToModify;
                    bool testToDelete = true;
                    //var timeItem1 = context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day).FirstOrDefault();
                    //if (timeItem1 == null)
                    //{
                    //    ((ViewModelAddOperation)ParentVM).SaveSelectTimeCommand.Execute();
                    //    return;
                    //}
                    foreach (var OpTimeInDb in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day))
                    {
                        foreach (var OpTime in OpViewList)
                        {
                            if (OpTimeInDb.Id == OpTime.Id && (SelectedOpTimeView == null || OpTime.Id != SelectedOpTimeView.Id))
                            {
                                testToDelete = false;
                                ToModify = Data.OperationDateTime.Get(OpTimeInDb.Id);
                                ToModify.Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, OpTime.Datetime.Hour, OpTime.Datetime.Minute, OpTime.Datetime.Second);
                                ToModify.Note = OpTime.Note;
                                Data.Complete();
                            }
                            if (OpTime.Id == 0)
                            {
                                ToModify = new OperationDateTime
                                {
                                    Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, OpTime.Datetime.Hour, OpTime.Datetime.Minute, OpTime.Datetime.Second),
                                    Note = OpTime.Note,
                                };
                                if (OpTime.Doctor != null)
                                    ToModify.Doctor_id = OpTime.Doctor.Id;
                                if (OpTime.Operation != null)
                                    ToModify.Operation_id = OpTime.Operation.Id;
                                Data.OperationDateTime.Add(ToModify);
                                Data.Complete();
                                OpTime.Id = ToModify.Id;
                            }
                        }

                        if (testToDelete)
                        {
                            Data.OperationDateTime.Remove(Data.OperationDateTime.Get(OpTimeInDb.Id));
                            Data.Complete();
                        }
                        testToDelete = true;
                    }



                    // //using (var context = new MySqlContext())
                    // //{

                    //  // var opDataToModify = new OperationDateTime();
                    //    var opDataToRemove = new OperationDateTime();
                    //    var test = true;
                    //    var OperationRep = new OperationRepository(context);
                    //    var OperationDateTimeRep = new OperationDateTimeRepository(context);
                    //    foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day))
                    //    {
                    //        test = true;
                    //        foreach (var opDateModified in OpViewList)
                    //        {
                    //            if (opDate.Id == opDateModified.id)
                    //            {
                    //                if ((SelectedOpTimeView != null && opDate.Id != SelectedOpTimeView.id) || SelectedOpTimeView == null)
                    //                {
                    //                    test = false;
                    //                    opDataToModify = Data.OperationDateTime.Get(opDate.Id);
                    //                    opDataToModify.Doctor_id = opDateModified.Doctor.Id;
                    //                    opDataToModify.Note = opDateModified.Note;
                    //                    opDataToModify.Operation_id = opDateModified.Operation.Id;
                    //                    opDataToModify.Datetime = opDateModified.Datetime;
                    //                    Data.Complete();
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //        if (test && (SelectedOpTimeView != null && opDate.Id != SelectedOpTimeView.id) || (SelectedOpTimeView == null && test))
                    //        {
                    //            opDataToRemove = Data.OperationDateTime.Get(opDate.Id);
                    //            Data.OperationDateTime.Remove(opDataToRemove);
                    //            Data.Complete();
                    //        }
                    //    }
                    //}

                    if (SelectedOpTimeView != null) /*&& ((ViewModelAddOperation)ParentVM).Operation.Datetime_id == null)*/
                    {
                        //var timeItem = context.Set<OperationDateTime>().Where(e => e.Operation_id == null && e.Datetime.Hour == SelectedOpTimeView.Datetime.Hour && e.Datetime.Minute == SelectedOpTimeView.Datetime.Minute).FirstOrDefault();
                        //if (timeItem == null)
                        // {

                        OperationDateTime TimeRow;
                        var timeItem = context.Set<OperationDateTime>().Where(e => e.Operation_id == null && e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day);
                        foreach (var Optime in OpViewList.Where(e => e.Operation == null))
                        {
                            if (timeItem.Where(e => e.Datetime.Hour == Optime.Datetime.Hour && e.Datetime.Minute == Optime.Datetime.Minute).FirstOrDefault() == null)
                            {
                                TimeRow = new OperationDateTime
                                {
                                    Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, Optime.Datetime.Hour, Optime.Datetime.Minute, Optime.Datetime.Second),
                                    Note = Optime.Note,
                                };
                                Data.OperationDateTime.Add(TimeRow);
                                Data.Complete();
                            }
                        }
                        var timeForSelectedInDb = timeItem.Where(e => e.Datetime.Hour == SelectedOpTimeView.Datetime.Hour && e.Datetime.Minute == SelectedOpTimeView.Datetime.Minute).FirstOrDefault();
                        if (timeForSelectedInDb != null)
                        {
                            timeForSelectedInDb = Data.OperationDateTime.Get(timeForSelectedInDb.Id);
                            timeForSelectedInDb.Datetime = SelectedOpTimeView.Datetime;
                            timeForSelectedInDb.Note = SelectedOpTimeView.Note;
                            timeForSelectedInDb.Doctor_id = SelectedOpTimeView.Doctor.Id;
                            timeForSelectedInDb.Operation_id = SelectedOpTimeView.Operation.Id;
                            Data.Complete();
                            SelectedOpTimeView.Id = timeForSelectedInDb.Id;
                            //Data.Complete();
                        }
                        else
                        {
                            TimeRow = new OperationDateTime
                            {
                                Datetime = SelectedOpTimeView.Datetime,
                                Note = SelectedOpTimeView.Note,
                                Doctor_id = SelectedOpTimeView.Doctor.Id,
                                Operation_id = SelectedOpTimeView.Operation.Id
                            };
                            Data.OperationDateTime.Add(TimeRow);
                            Data.Complete();
                            SelectedOpTimeView.Id = TimeRow.Id;
                        }


                        // }
                    }
                }

                ((ViewModelAddOperation)ParentVM).SaveSelectTimeCommand.Execute();
                //SelectedOpTimeView = null;
                //BuffSelectedOpTimeView = null;
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

                var opViewElement = new OperationTimeView(0, new System.DateTime(Date.Year, Date.Month, Date.Day, newType.Datetime.Hour, newType.Datetime.Minute, newType.Datetime.Second));

                SetDefaultFunctions(ref opViewElement);

                OpViewList.Add(opViewElement);

                OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));
                //opViewElement.Select = new DelegateCommand(() =>
                //{
                //    if (SelectedOpTimeView != null)
                //        BuffSelectedOpTimeView = SelectedOpTimeView;
                //    SelectedOpTimeView = OpViewList.Where(e => e.id == opViewElement.id && e.Datetime == opViewElement.Datetime).FirstOrDefault();
                //    CurrentPanelSelectDoctor.ClearPanel();
                //    CurrentPanelSelectDoctor.PanelOpened = true;
                //});

                //opViewElement.SetDown = new DelegateCommand(() =>
                //{
                //    var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.id == opViewElement.id && e.Datetime == opViewElement.Datetime).FirstOrDefault());
                //    if (CurElementIndex != OpViewList.Count - 1)
                //    {
                //        var Buff = OpViewList[CurElementIndex].Datetime;
                //        OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex + 1].Datetime;
                //        OpViewList[CurElementIndex + 1].Datetime = Buff;

                //        OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));

                //        //ViewSource.View.Refresh();
                //    }
                //});

                //opViewElement.SetUp = new DelegateCommand(() =>
                //{
                //    var CurElementIndex = OpViewList.IndexOf(OpViewList.Where(e => e.id == opViewElement.id && e.Datetime == opViewElement.Datetime).FirstOrDefault());
                //    if (CurElementIndex != 0)
                //    {
                //        var Buff = OpViewList[CurElementIndex].Datetime;
                //        OpViewList[CurElementIndex].Datetime = OpViewList[CurElementIndex - 1].Datetime;
                //        OpViewList[CurElementIndex - 1].Datetime = Buff;

                //        OpViewList = new ObservableCollection<OperationTimeView>(OpViewList.OrderBy(i => i.Datetime));
                //    }
                //});
                //opViewElement.Delete = new DelegateCommand(() =>
                //{
                //    var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                //    if (dialogResult == MessageBoxResult.Yes)
                //    {
                //        OpViewList.Remove(OpViewList.Where(e => e.id == opViewElement.id && e.Datetime == opViewElement.Datetime).FirstOrDefault());
                //    }
                //});
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
                    buffForId = BuffSelectedOpTimeView.Id;
                    BuffSelectedOpTimeView = null;
                }

                SelectedOpTimeView.Delete = new DelegateCommand(() =>
                {
                    var elem = OpViewList.Where(e => e.Datetime == SelectedOpTimeView.Datetime).FirstOrDefault();
                    elem.Note = "Время свободно";
                    elem.Operation = null;
                    elem.PatientFullName = "";
                    elem.PatientNumber = "";
                    elem.Doctor = null;
                    SetDefaultFunctions(ref elem);
                    if (((ViewModelAddOperation)ParentVM).Operation.Datetime_id != null && ((ViewModelAddOperation)ParentVM).Operation.Datetime_id != 0)
                    {
                        var OpDate = Data.OperationDateTime.Get(((ViewModelAddOperation)ParentVM).Operation.Datetime_id.Value);
                        if (OpDate != null)
                        {
                            OpDate.Doctor_id = null;
                            OpDate.Note = "Время свободно";
                            OpDate.Operation_id = null;
                            Data.Complete();
                            using (var context = new MySqlContext())
                            {
                                var timeItem = context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Datetime.Year == OpDate.Datetime.Year && e.Datetime.Month == OpDate.Datetime.Month && e.Datetime.Day == OpDate.Datetime.Day).FirstOrDefault();
                                if (timeItem == null)
                                {
                                    foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == OpDate.Datetime.Year && e.Datetime.Month == OpDate.Datetime.Month && e.Datetime.Day == OpDate.Datetime.Day))
                                    {
                                        Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate.Id));
                                    }
                                }
                                Data.Complete();
                            }
                        }
                    }
                    SelectedOpTimeViewCopy = null;
                    SelectedOpTimeView = null;

                    ////ViewSource.View.Refresh();
                    UpdateTimeTable();
                });
                Patient patient = ((ViewModelAddOperation)ParentVM).CurrentPatient;
                SelectedOpTimeView.PatientFullName = patient.Sirname + " " + patient.Name.ToCharArray()[0] + ". " + patient.Patronimic.ToCharArray()[0] + ".";
                SelectedOpTimeView.PatientNumber = patient.Phone;
                SelectedOpTimeView.Operation = ((ViewModelAddOperation)ParentVM).Operation;
                SelectedOpTimeView.Doctor = CurrentPanelSelectDoctor.Doctors[CurrentPanelSelectDoctor.DoctorSelectedId].doc;
                SelectedOpTimeView.Note = CurrentPanelSelectDoctor.Commentary;
                CurrentPanelSelectDoctor.PanelOpened = false;

                SelectedOpTimeViewCopy = new OperationTimeView(SelectedOpTimeView.Id, SelectedOpTimeView.Datetime);
                SelectedOpTimeViewCopy.Delete = SelectedOpTimeView.Delete;
                SelectedOpTimeViewCopy.Doctor = SelectedOpTimeView.Doctor;
                SelectedOpTimeViewCopy.Note = SelectedOpTimeView.Note;
                SelectedOpTimeViewCopy.Operation = SelectedOpTimeView.Operation;
                SelectedOpTimeViewCopy.PatientFullName = SelectedOpTimeView.PatientFullName;
                SelectedOpTimeViewCopy.PatientNumber = SelectedOpTimeView.PatientNumber;
                SaveChangesBtnVis = true;
                ////ViewSource.View.Refresh();
                //                UpdateTimeTable();
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
