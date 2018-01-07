using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelCancelOperations : ViewModelBase
    {
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }

        public string OtmenOrProv { get; set; }
        public string DateText { get; set; }
        public string comment { get; set; }
        public string operationType { get; set; }
        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        private int operationId;
        public string TextResultCancle { get; set; }
        private void GetOperationid(object sender, object data)
        {
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            Date = DateTime.Now;
            operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            TextResultCancle = "Отмена операции";
            DateText = "Операция отменена :";
            OtmenOrProv = "Отмененная ";
        }
        public ViewModelCancelOperations(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("GetOperationIDForAddCancel", GetOperationid);
            HasNavigation = false;
            ToOperationCommand = new DelegateCommand(
                () =>
                {


                    var buf = new CancelOperation();
                    //  buf.Reason = comment;
                    Data.CancelOperation.Add(buf);
                    Operation.отмена_операции = buf.Id;
                    Data.Complete();
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
