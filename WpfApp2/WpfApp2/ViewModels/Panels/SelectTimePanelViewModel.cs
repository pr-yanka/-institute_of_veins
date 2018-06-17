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
            int buffForId = ForCancleOpTimeView.id;
           // ForCancleOpTimeView.Delete = new DelegateCommand(() =>
            //{
            //    var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
            //    if (dialogResult == MessageBoxResult.Yes)
            //    {
            //        using (var context1 = new MySqlContext())
            //        {
            //            OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
            //            var ourOpTime = timeOpRep.GetAll.Where(e => e.Operation_id == null && e.Id == buffForId).FirstOrDefault();
            //            //ViewSource.View.Refresh();


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
            //                ViewSource.View.Refresh();
            //            }
            //            else
            //            {
            //                MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
            //            }
            //        }

            //    }
            //});

            ForCancleOpTimeView = null;
            //ViewSource.View.Refresh();
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
            public int id;
            public Operation Operation { get; set; }
            //public DelegateCommand Cancle { get; set; }
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
                //Datetime = System.DateTime.Now;
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





        public void LoadTimeTable()
        {
            using (var context = new MySqlContext())
            {
                OpViewList = new List<OperationTimeView>();
                //try
                //{
                bool ultraTest = false;
                var DoctorRep = new DoctorRepository(context);
                var OperationRep = new OperationRepository(context);
                var OperationDateTimeRep = new OperationDateTimeRepository(context);
                var PatientRep = new PatientsRepository(context);
                var OpViewElement = new OperationTimeView();
                //context.Set<OperationDateTime>().Where(e => e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day)
                foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Operation_id == null || e.Operation_id == 0))
                {

                    foreach (var item in OpViewList)
                    {
                        if (item.id != opDate.Id && opDate.Datetime.Hour == item.Datetime.Hour && opDate.Datetime.Minute == item.Datetime.Minute)
                        {
                            Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate.Id));
                            ultraTest = true;
                        }
                    }
                    Data.Complete();

                    if (ultraTest)
                    {
                        continue;
                    }

                    OpViewElement = new OperationTimeView();
                    OpViewElement.id = opDate.Id;
                    OpViewElement.Datetime = opDate.Datetime;
                    OpViewElement.Note = opDate.Note;

                    OpViewElement.Select = new DelegateCommand(() =>
                    {
                        if (SelectedOpTimeView != null)
                            BuffSelectedOpTimeView = SelectedOpTimeView;
                        SelectedOpTimeView = OpViewList.Where(e => e.id == opDate.Id).FirstOrDefault();
                        SelectedOpTimeView.Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, SelectedOpTimeView.Datetime.Hour, SelectedOpTimeView.Datetime.Minute, 0);
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
                            bool test = true;
                            //  OperationDateTime timeItem;
                            using (var context1 = new MySqlContext())
                            {
                                OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
                                var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == OpViewElement.Datetime.Hour && e.Datetime.Minute == OpViewElement.Datetime.Minute).FirstOrDefault();
                                if (timeItem == null)
                                {
                                    test = false;
                                }

                                if (!test)
                                {
                                    var opDataToRemove = Data.OperationDateTime.Get(OpViewElement.id);
                                    Data.OperationDateTime.Remove(opDataToRemove);
                                    Data.Complete();
                                    OpViewList.Remove(OpViewList.Where(e => e.id == OpViewElement.id).FirstOrDefault());
                                    ViewSource.View.Refresh();
                                }
                                else
                                {
                                    MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
                                }
                            }
                        }

                    });


                    OpViewList.Add(OpViewElement);

                }
                OpViewList.Sort((a, b) => a.Datetime.CompareTo(b.Datetime));



                ViewSource.Source = OpViewList;
                ViewSource.View.Refresh();
            }
        }
        public void UpdateTimeTable()
        {

            using (var context = new MySqlContext())
            {
                var OpViewElement = new OperationTimeView();
                var Patient = new Patient();
                if (OpViewList != null)
                {
                    foreach (var time in OpViewList)
                    {
                        time.Note = "Время свободно";
                        time.Operation = null;
                        time.PatientFullName = "";
                        time.PatientNumber = "";
                        time.Doctor = null;
                        time.Delete = new DelegateCommand(() =>
                        {
                            var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                bool test = true;
                                //  OperationDateTime timeItem;
                                using (var context1 = new MySqlContext())
                                {
                                    OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
                                    var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == time.Datetime.Hour && e.Datetime.Minute == time.Datetime.Minute).FirstOrDefault();
                                    if (timeItem == null)
                                    {
                                        test = false;
                                    }

                                    if (!test)
                                    {
                                        var opDataToRemove = Data.OperationDateTime.Get(time.id);
                                        Data.OperationDateTime.Remove(opDataToRemove);
                                        Data.Complete();
                                        OpViewList.Remove(OpViewList.Where(e => e.id == time.id).FirstOrDefault());
                                        ViewSource.View.Refresh();
                                    }
                                    else
                                    {
                                        MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
                                    }
                                }
                            }
                        });
                        time.Select = new DelegateCommand(() =>
                        {
                            if (SelectedOpTimeView != null)
                                BuffSelectedOpTimeView = SelectedOpTimeView;
                            SelectedOpTimeView = OpViewList.Where(e => e.id == time.id).FirstOrDefault();
                            SelectedOpTimeView.Datetime = new System.DateTime(Date.Year, Date.Month, Date.Day, SelectedOpTimeView.Datetime.Hour, SelectedOpTimeView.Datetime.Minute, 0);
                            CurrentPanelSelectDoctor.ClearPanel();
                            CurrentPanelSelectDoctor.PanelOpened = true;
                        });
                    }

                    foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Year == Date.Year && e.Datetime.Month == Date.Month && e.Datetime.Day == Date.Day))
                    {
                        //if (opDate.Operation_id != null && opDate.Operation_id != 0 && opDate.Datetime.Year == Date.Year && opDate.Datetime.Month == Date.Month && opDate.Datetime.Day == Date.Day)
                        //{
                        OpViewElement = OpViewList.Where(e => e.Datetime.Hour == opDate.Datetime.Hour && e.Datetime.Minute == opDate.Datetime.Minute).FirstOrDefault();
                        OpViewElement.Delete = new DelegateCommand(() =>
                        {
                            var dialogResult = MessageBox.Show("Отменить операцию?", "", MessageBoxButton.YesNo);
                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                ForCancleOpTimeView = OpViewList.Where(e => e.Operation != null && e.Operation.Id == opDate.Operation_id && opDate.Datetime.Hour == e.Datetime.Hour && opDate.Datetime.Minute == e.Datetime.Minute).FirstOrDefault();
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
                        OpViewElement.Note = opDate.Note;
                        //}
                    }
                }
            }
            if (SelectedOpTimeViewCopy != null && SelectedOpTimeViewCopy.Datetime.Year == Date.Year && SelectedOpTimeViewCopy.Datetime.Month == Date.Month && SelectedOpTimeViewCopy.Datetime.Day == Date.Day)
            {
                var itemSelected = OpViewList.Where(e => e.id == SelectedOpTimeViewCopy.id).FirstOrDefault();
                // itemSelected.Cancle = SelectedOpTimeViewCopy.Cancle;
                itemSelected.Delete = SelectedOpTimeViewCopy.Delete;
                itemSelected.Doctor = SelectedOpTimeViewCopy.Doctor;
                itemSelected.Note = SelectedOpTimeViewCopy.Note;
                itemSelected.Operation = SelectedOpTimeViewCopy.Operation;
                itemSelected.PatientFullName = SelectedOpTimeViewCopy.PatientFullName;
                itemSelected.Datetime = SelectedOpTimeViewCopy.Datetime;
                itemSelected.PatientNumber = SelectedOpTimeViewCopy.PatientNumber;
            }
            if (OpViewList != null)
                ViewSource.View.Refresh();
        }
        public void PanelClear()
        {
            if (((ViewModelAddOperation)ParentVM).Operation.Datetime_id != null)
            {
                return;
            }

            Date = (System.DateTime.Now.DayOfWeek == System.DayOfWeek.Sunday) ? System.DateTime.Now.AddDays(2) : System.DateTime.Now.AddDays(1);
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
            SelectedOpTimeViewCopy = new OperationTimeView();
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

                    if (SelectedOpTimeView != null && ((ViewModelAddOperation)ParentVM).Operation.Datetime_id == null)
                    {
                        opDataToModify = Data.OperationDateTime.Get(SelectedOpTimeView.id);
                        opDataToModify.Doctor_id = SelectedOpTimeView.Doctor.Id;
                        opDataToModify.Note = SelectedOpTimeView.Note;
                        opDataToModify.Operation_id = SelectedOpTimeView.Operation.Id;
                        opDataToModify.Datetime = SelectedOpTimeView.Datetime;
                        Data.Complete();

                        var timeItem = context.Set<OperationDateTime>().Where(e => e.Operation_id == null && e.Datetime.Hour == SelectedOpTimeView.Datetime.Hour && e.Datetime.Minute == SelectedOpTimeView.Datetime.Minute).FirstOrDefault();
                        if (timeItem == null)
                        {
                            var TimeRow = new OperationDateTime
                            {
                                Datetime = opDataToModify.Datetime,
                                Note = "Время свободно"
                            };
                            Data.OperationDateTime.Add(TimeRow);
                            Data.Complete();
                        }

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
                        bool test = true;
                        //  OperationDateTime timeItem;
                        using (var context1 = new MySqlContext())
                        {
                            OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
                            var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == OpViewElement.Datetime.Hour && e.Datetime.Minute == OpViewElement.Datetime.Minute).FirstOrDefault();
                            if (timeItem == null)
                            {
                                test = false;
                            }

                            if (!test)
                            {
                                var opDataToRemove = Data.OperationDateTime.Get(OpViewElement.id);
                                Data.OperationDateTime.Remove(opDataToRemove);
                                Data.Complete();
                                OpViewList.Remove(OpViewList.Where(e => e.id == OpViewElement.id).FirstOrDefault());
                                ViewSource.View.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
                            }
                        }
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
                    //BuffSelectedOpTimeView.Delete = new DelegateCommand(() =>
                    //{
                    //    var dialogResult = MessageBox.Show("Удалить?", "", MessageBoxButton.YesNo);
                    //    if (dialogResult == MessageBoxResult.Yes)
                    //    {
                    //        using (var context1 = new MySqlContext())
                    //        {
                    //            OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
                    //            var ourOpTime = timeOpRep.GetAll.Where(e => e.Operation_id == null && e.Id == buffForId).FirstOrDefault();
                    //            //ViewSource.View.Refresh();


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
                    //                ViewSource.View.Refresh();
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
                    //            }
                    //        }

                    //    }
                    //});
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
                            bool test = true;
                            //  OperationDateTime timeItem;
                            using (var context1 = new MySqlContext())
                            {
                                OperationDateTimeRepository timeOpRep = new OperationDateTimeRepository(context1);
                                var timeItem = timeOpRep.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Hour == elem.Datetime.Hour && e.Datetime.Minute == elem.Datetime.Minute).FirstOrDefault();
                                if (timeItem == null)
                                {
                                    test = false;
                                }

                                if (!test)
                                {
                                    var opDataToRemove = Data.OperationDateTime.Get(elem.id);
                                    Data.OperationDateTime.Remove(opDataToRemove);
                                    Data.Complete();
                                    OpViewList.Remove(OpViewList.Where(e => e.id == elem.id).FirstOrDefault());
                                    ViewSource.View.Refresh();
                                }
                                else
                                {
                                    MessageBox.Show("На это время назначена операция" + timeItem.Datetime);
                                }
                            }
                        }
                    });

                    SelectedOpTimeViewCopy = null;
                    SelectedOpTimeView = null;
                    //ViewSource.View.Refresh();
                    UpdateTimeTable();
                });
                Patient patient = ((ViewModelAddOperation)ParentVM).CurrentPatient;
                SelectedOpTimeView.PatientFullName = patient.Sirname + " " + patient.Name + " " + patient.Patronimic;
                SelectedOpTimeView.PatientNumber = patient.Phone;
                SelectedOpTimeView.Operation = ((ViewModelAddOperation)ParentVM).Operation;
                SelectedOpTimeView.Doctor = CurrentPanelSelectDoctor.Doctors[CurrentPanelSelectDoctor.DoctorSelectedId].doc;
                SelectedOpTimeView.Note = CurrentPanelSelectDoctor.Commentary;
                CurrentPanelSelectDoctor.PanelOpened = false;

                SelectedOpTimeViewCopy = new OperationTimeView();
                // SelectedOpTimeViewCopy.Cancle = SelectedOpTimeView.Cancle;
                SelectedOpTimeViewCopy.id = SelectedOpTimeView.id;
                SelectedOpTimeViewCopy.Delete = SelectedOpTimeView.Delete;
                SelectedOpTimeViewCopy.Doctor = SelectedOpTimeView.Doctor;
                SelectedOpTimeViewCopy.Note = SelectedOpTimeView.Note;
                SelectedOpTimeViewCopy.Operation = SelectedOpTimeView.Operation;
                SelectedOpTimeViewCopy.PatientFullName = SelectedOpTimeView.PatientFullName;
                SelectedOpTimeViewCopy.Datetime = SelectedOpTimeView.Datetime;
                SelectedOpTimeViewCopy.PatientNumber = SelectedOpTimeView.PatientNumber;

                //ViewSource.View.Refresh();
                UpdateTimeTable();
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
