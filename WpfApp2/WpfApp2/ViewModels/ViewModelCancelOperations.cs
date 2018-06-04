using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelCancelOperations : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region DelegateCommands
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand OtherReasonCommand { get; protected set; }
        #endregion

        private Visibility _visibilityOfOtherReason;
        public Visibility VisibilityOfOtherReason { get { return _visibilityOfOtherReason; } set
            {
                _visibilityOfOtherReason = value; OnPropertyChanged();
            } }
        private Visibility _visibilityOfReasons;
        public Visibility VisibilityOfReasons
        {
            get { return _visibilityOfReasons; }
            set
            {
                _visibilityOfReasons = value; OnPropertyChanged();
            }
        }
        private string _isOtherReason;
        public string IsOtherReason { get { return _isOtherReason; } set { _isOtherReason = value; OnPropertyChanged(); } }
        public string OtmenOrProv { get; set; }
        public string DateText { get; set; }
        public int ReasonSelected { get; set; }
        public ObservableCollection<string> CancelsReasons { get; set; }
        public string operationType { get; set; }
        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        public string OtherReasonText { get; set; }
        private int operationId;
        public string TextResultCancle { get; set; }
        private void GetOperationid(object sender, object data)
        {
            ReasonSelected = 0;
            VisibilityOfOtherReason = Visibility.Hidden;
            VisibilityOfReasons = Visibility.Visible;
            IsOtherReason = "NO";
            CancelsReasons = new ObservableCollection<string>();
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            Date = DateTime.Now;
            //operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            TextResultCancle = "Отмена операции";
            DateText = "Операция отменена";
            OtmenOrProv = "Отмененная ";

            foreach(var Reason in Data.ReasonsOfCancleOperation.GetAll)
            {
                CancelsReasons.Add(Reason.Str);
            }

        }
        private void SetFunctionsToReturnToOpOwervier(object sender, object data)
        {
            ToOperationCommand = new DelegateCommand(
              () =>
              {
                  var buf = new CancelOperation();
                  if (IsOtherReason != "Yes")
                  {
                      buf.Reason = ReasonSelected + 1;
                  }
                  else
                  {
                      ReasonsOfCancelOperation buf1 = new ReasonsOfCancelOperation();
                      if (OtherReasonText == null)
                          OtherReasonText = "";
                      buf1.Str = OtherReasonText;
                      Data.ReasonsOfCancleOperation.Add(buf1);
                      buf.Reason = buf1.Id;
                      Data.Complete();


                  }
                  buf.TransferDate = DateTime.Now;
                  Data.CancelOperation.Add(buf);
                  Operation.cancel_operations = buf.Id;
                  Data.Complete();
                  if (Operation.Datetime_id != null && Operation.Datetime_id != 0)
                  {
                      var opDate = Data.OperationDateTime.Get(Operation.Datetime_id.Value);
                      opDate.Doctor_id = null;
                      opDate.Note = "Время свободно";
                      opDate.Operation_id = null;
                      Data.Complete();
                  }
                  MessageBus.Default.Call("SetCurrentACCOp", this, null);
                  MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                  Controller.NavigateTo<ViewModelOperationOverview>();
              }
          );
            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }

        private void SetFunctionsToReturnToOpCreation(object sender, object data)
        {
            ToOperationCommand = new DelegateCommand(
                () =>
                {
                    var buf = new CancelOperation();
                    if (IsOtherReason != "Yes")
                    {
                        buf.Reason = ReasonSelected + 1;
                    }
                    else
                    {
                        ReasonsOfCancelOperation buf1 = new ReasonsOfCancelOperation();
                        if (OtherReasonText == null)
                            OtherReasonText = "";
                        buf1.Str = OtherReasonText;
                        Data.ReasonsOfCancleOperation.Add(buf1);
                        buf.Reason = buf1.Id;
                        Data.Complete();


                    }
                    buf.TransferDate = DateTime.Now;
                    Data.CancelOperation.Add(buf);
                    Operation.cancel_operations = buf.Id;
                    Data.Complete();
                    if (Operation.Datetime_id != null && Operation.Datetime_id != 0)
                    {
                        var opDate = Data.OperationDateTime.Get(Operation.Datetime_id.Value);
                        opDate.Doctor_id = null;
                        opDate.Note = "Время свободно";
                        opDate.Operation_id = null;
                        Data.Complete();
                    }
                    MessageBus.Default.Call("SetCurrentACCOp", this, null);
                    MessageBus.Default.Call("ConfirmCancle", null, null);
                    //MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
        }


        public ViewModelCancelOperations(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("GetOperationIDForAddCancel", GetOperationid);

            MessageBus.Default.Subscribe("SetFunctionsToReturnToOpOwervier", SetFunctionsToReturnToOpOwervier);
            MessageBus.Default.Subscribe("SetFunctionsToReturnToOpCreation", SetFunctionsToReturnToOpCreation);
            HasNavigation = false;
            OtherReasonCommand = new DelegateCommand(
                () =>
                {
                    IsOtherReason = "Yes";
                    VisibilityOfOtherReason = Visibility.Visible;
                    VisibilityOfReasons = Visibility.Hidden;
                }
            );
            ToOperationCommand = new DelegateCommand(
                () =>
                {
                    var buf = new CancelOperation();
                    if (IsOtherReason != "Yes")
                    {
                        buf.Reason = ReasonSelected + 1;
                    }else
                    {
                        ReasonsOfCancelOperation buf1 = new ReasonsOfCancelOperation();
                        if (OtherReasonText == null)
                            OtherReasonText = "";
                        buf1.Str = OtherReasonText;
                        Data.ReasonsOfCancleOperation.Add(buf1);
                        buf.Reason = buf1.Id;
                        Data.Complete();
                       

                    }
                    buf.TransferDate = DateTime.Now;
                    Data.CancelOperation.Add(buf);
                    Operation.cancel_operations = buf.Id;
                    Data.Complete();
                    if (Operation.Datetime_id != null && Operation.Datetime_id != 0)
                    {
                        var opDate = Data.OperationDateTime.Get(Operation.Datetime_id.Value);
                        opDate.Doctor_id = null;
                        opDate.Note = "Время свободно";
                        opDate.Operation_id = null;
                        Data.Complete();
                    }
                    MessageBus.Default.Call("SetCurrentACCOp", this, null);
                    MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
    }
}
