using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.DialogService;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddOperationResult : ViewModelBase
    {
        public string TextResultCancle { get; set; }
        public string comment { get; set; }
        public string operationType { get; set; }
        public string OtmenOrProv { get; set; }
        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        public string DateText { get; set; }
        private int operationId;

        private void GetOperationid(object sender, object data)
        {
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            DateTime bufTime = DateTime.Parse(Operation.Time);

            Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Operation.Date;

            int i1 = 0;
            int i2 = 0;
            string leftP = "";
            string rightP = "";
            foreach (var Diagnosis in Data.OperationTypeOperations.GetAll)
            {
                if (Diagnosis.id_операции == Operation.Id)
                {
                    if (Diagnosis.isLeft == true)
                    {
                        if (i1 != 0)
                            leftP += ", " + Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                        else
                        {
                            leftP += Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                        }
                        i1++;
                    }
                    else
                    {
                        if (i2 != 0)
                            rightP += ", " + Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                        else
                        {
                            rightP += Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                        }
                        i2++;
                    }
                }
            }
            if (Operation.OnWhatLegOp == "0")
            {
                operationType = "На левую ногу :" + leftP;
            }
            if (Operation.OnWhatLegOp == "1")
            {
                operationType = "На правую ногу :" + rightP;
            }
            if (Operation.OnWhatLegOp == "2")
            {
                operationType = "На левую ногу :" + leftP + " " + "На правую ногу :" + rightP;
            }
            TextResultCancle = "Итоги операции";
            DateText = "Операция проведена :";
            OtmenOrProv = "Проведённая ";
        }

        public ViewModelAddOperationResult(NavigationController controller) : base(controller)
        {
            comment = "";
            MessageBus.Default.Subscribe("GetOperationIDForAddOperationResult", GetOperationid);
            HasNavigation = false;
            ToOperationCommand = new DelegateCommand(
                () =>
                {


                    var result = MessageBox.Show("Назначить ещё одну операцию", "", MessageBoxButton.YesNo);
                    if (result == System.Windows.MessageBoxResult.Yes)
                    {

                        // Closes the parent form.
                        var buf = new OperationResult();
                        buf.Str = comment;
                        Data.OperationResult.Add(buf);
                        Operation.итоги_операции = buf.Id;
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
                        Data.OperationResult.Add(buf);
                        Operation.итоги_операции = buf.Id;
                        Data.Complete();
                        MessageBus.Default.Call("SetCurrentACCOp", this, null);
                        MessageBus.Default.Call("GetOprForOprResultOverview", this, operationId);
                        Controller.NavigateTo<ViewModelOperationResultOverview>();

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
