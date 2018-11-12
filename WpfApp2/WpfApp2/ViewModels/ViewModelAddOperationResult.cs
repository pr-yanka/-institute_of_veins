using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.DialogService;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddOperationResult : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public string TextResultCancle { get; set; }
        private string _comment;//{ get; set; }
        public string comment
        {
            get { return _comment; }
            set
            {
                _comment = value;

                OnPropertyChanged();
            }
        }
        private string _operationType;
        public string OperationType
        {
            get { return _operationType; }
            set
            {
                _operationType = value;

                OnPropertyChanged();
            }
        }
        private DateTime _date;
        public string OtmenOrProv { get; set; }
        public Operation Operation { get; set; }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;

                OnPropertyChanged();
            }
        }
        public string DateText { get; set; }
        private int operationId;

        private void GetOperationid(object sender, object data)
        {
            comment = "";
            
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            //DateTime bufTime = DateTime.Parse(Operation.Time);

            //Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Data.OperationDateTime.Get(Operation.Datetime_id.Value).Datetime;

            int i1 = 0;
            int i2 = 0;
            string leftP = "";
            string rightP = "";
            foreach (var Diagnosis in Data.OperationTypeOperations.GetAll)
            {
                if (Diagnosis.id_operation == Operation.Id)
                {
                    if (Diagnosis.isLeft == true)
                    {
                        if (i1 != 0)
                            leftP += ", " + Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str;
                        else
                        {
                            leftP += Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str;
                        }
                        i1++;
                    }
                    else
                    {
                        if (i2 != 0)
                            rightP += ", " + Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str;
                        else
                        {
                            rightP += Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str;
                        }
                        i2++;
                    }
                }
            }
            OperationType = "";
            OperationType += "Проведённая операция:";
            if (Operation.OnWhatLegOp == "0")
            {
                OperationType += "\nНа левую нижнюю конечность : " + leftP;
            }
            if (Operation.OnWhatLegOp == "1")
            {
                OperationType += "\nНа правую нижнюю конечность : " + rightP;
            }
            if (Operation.OnWhatLegOp == "2")
            {
                OperationType += "\nНа левую нижнюю конечность : " + leftP + " " + "\nНа правую нижнюю конечность : " + rightP;
            }
            TextResultCancle = "Итоги операции";
            DateText = "Операция проведена";
            OtmenOrProv = "Проведённая ";
            if (Operation.operation_result != null)
            {
                var operationResult = Data.OperationResult.Get(Operation.operation_result.Value);
                comment = operationResult.Str;
                if (operationResult.Date != null)
                {
                    Date = operationResult.Date.Value;
                }
            }
        }

        public ViewModelAddOperationResult(NavigationController controller) : base(controller)
        {
            comment = "";
            MessageBus.Default.Subscribe("GetOperationIDForAddOperationResult", GetOperationid);
            HasNavigation = false;
            ToOperationCommand = new DelegateCommand(
                () =>
                {

                    if (Operation.operation_result != null)
                    {
                        var Res = Data.OperationResult.Get(Operation.operation_result.Value);
                        if (Res.IdNextOperation == null)
                        {
                            var result1 = MessageBox.Show("Назначить ещё одну операцию?", "", MessageBoxButton.YesNo);
                            if (result1 == System.Windows.MessageBoxResult.Yes)
                            {

                                // Closes the parent form.
                                var buf = Data.OperationResult.Get(Res.Id);
                                buf.Str = comment;
                                buf.Date = Date;
                                //Operation.итоги_операции = buf.Id;
                                Data.Complete();
                                MessageBus.Default.Call("SetCurrentACCOp", this, null);
                                MessageBus.Default.Call("SetCurrentPatientForOperation", this, Operation.PatientId);
                                MessageBus.Default.Call("SetOperationResult", this, buf);
                                Controller.NavigateTo<ViewModelAddOperation>();


                            }
                            else
                            {
                                var buf = Data.OperationResult.Get(Res.Id);
                                buf.Str = comment;
                                buf.Date = Date;
                                // Data.OperationResult.Add(buf);
                                //   Operation.итоги_операции = buf.Id;
                                Data.Complete();
                                MessageBus.Default.Call("SetCurrentACCOp", this, null);
                                MessageBus.Default.Call("GetOprForOprResultOverview", this, operationId);
                                MessageBus.Default.Call("GetOperationForOverwiev", null, operationId);
                                Controller.NavigateTo<ViewModelOperationOverview>();

                            }
                        }
                        else
                        {
                            var buf = Data.OperationResult.Get(Res.Id);
                            buf.Str = comment;
                            buf.Date = Date;
                            Data.Complete();
                            MessageBus.Default.Call("SetCurrentACCOp", this, null);
                            MessageBus.Default.Call("GetOprForOprResultOverview", this, operationId);
                            //       MessageBus.Default.Call("GetOperationForOverwiev", null, operationId);
                            Controller.NavigateTo<ViewModelOperationOverview>();
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("Назначить ещё одну операцию?", "", MessageBoxButton.YesNo);
                        if (result == System.Windows.MessageBoxResult.Yes)
                        {

                            // Closes the parent form.
                            var buf = new OperationResult();
                            buf.Str = comment;
                            buf.Date = Date;
                            Data.OperationResult.Add(buf);
                            Operation.operation_result = buf.Id;
                            Data.Complete();
                            MessageBus.Default.Call("SetCurrentACCOp", this, null);
                            MessageBus.Default.Call("SetCurrentPatientForOperation", this, Operation.PatientId);
                            MessageBus.Default.Call("SetOperationResult", this, buf);
                            Controller.NavigateTo<ViewModelAddOperation>();


                        }
                        else
                        {
                            var buf = new OperationResult();
                            buf.Str = comment;
                            buf.Date = Date;
                            Data.OperationResult.Add(buf);
                            Operation.operation_result = buf.Id;
                            Data.Complete();
                            MessageBus.Default.Call("SetCurrentACCOp", this, null);
                            MessageBus.Default.Call("GetOprForOprResultOverview", this, operationId);
                            MessageBus.Default.Call("GetOperationForOverwiev", null, operationId);
                            Controller.NavigateTo<ViewModelOperationOverview>();

                        }
                    }

                }
            );
            ToCreateStatementCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetOperationResultForCreateStatement", this, operationId);
                    Controller.NavigateTo<ViewModelCreateStatement>();
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
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToCreateStatementCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
    }
}
