using System;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelOperationResultOverview : ViewModelBase
    {
        public string HeaderName { get; set; }

        public string ResultOrOtmenaName { get; set; }
        public string operationType { get; set; }
        public string PlanedOpr { get; set; }

        public string comment { get; set; }
        public DateTime Date { get; set; }
        public Visibility visibilityOfNextOP { get; set; }

        public Operation Operation { get; set; }

        private void GetOperationResult(object sender, object data)
        {

            Operation = Data.Operation.Get((int)data);
            OperationResult oprresult = Data.OperationResult.Get(Operation.итоги_операции.Value);
            HeaderName = "Итоги операции";
            ResultOrOtmenaName = "Операция проведена :";
            if (oprresult.IdNextOperation != null)
            {
                PlanedOpr = Data.OperationType.Get(Data.Operation.Get(oprresult.IdNextOperation.Value).OperationTypeId).LongName;
                visibilityOfNextOP = Visibility.Visible;
            }
            else
            {
                visibilityOfNextOP = Visibility.Hidden;
            }
            comment = oprresult.Str;
            DateTime bufTime = DateTime.Parse(Operation.Time);
            operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Operation.Date;

        }




        public ViewModelOperationResultOverview(NavigationController controller) : base(controller)
        {
            HasNavigation = false;

            MessageBus.Default.Subscribe("GetOprForOprResultOverview", GetOperationResult);

            ToOperationCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }

            );
        }

        public DelegateCommand ToOperationCommand { get; protected set; }
    }
}
