using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelOperationResultOverview : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public string HeaderName { get; set; }

        public string ResultOrOtmenaName { get; set; }
        public string operationType { get; set; }
        public string PlanedOpr { get; set; }

        public string comment { get; set; }
        public DateTime Date { get; set; }
        public Visibility visibilityOfNextOP { get; set; }

        public Operation Operation { get; set; }

        private List<OperationTypesDataSource> _leftOperationList;
        private List<OperationTypesDataSource> _rightOperationList;

        public List<OperationTypesDataSource> LeftOperationList
        {
            get
            {
                return _leftOperationList;
            }
            set
            {
                _leftOperationList = value; OnPropertyChanged();
            }
        }
        public List<OperationTypesDataSource> RightOperationList
        {
            get
            {
                return _rightOperationList;
            }
            set
            {
                _rightOperationList = value; OnPropertyChanged();
            }
        }


        private List<OperationTypesDataSource> _leftOperationListPlaned;
        private List<OperationTypesDataSource> _rightOperationListPlaned;

        public List<OperationTypesDataSource> LeftOperationListPlaned
        {
            get
            {
                return _leftOperationListPlaned;
            }
            set
            {
                _leftOperationListPlaned = value; OnPropertyChanged();
            }
        }
        public List<OperationTypesDataSource> RightOperationListPlaned
        {
            get
            {
                return _rightOperationListPlaned;
            }
            set
            {
                _rightOperationListPlaned = value; OnPropertyChanged();
            }
        }

        private void GetOperationResult(object sender, object data)
        {
            RightOperationList = new List<OperationTypesDataSource>();
            LeftOperationList = new List<OperationTypesDataSource>();
            RightOperationListPlaned = new List<OperationTypesDataSource>();
            LeftOperationListPlaned = new List<OperationTypesDataSource>();
            Operation = Data.Operation.Get((int)data);
            OperationResult oprresult = Data.OperationResult.Get(Operation.operation_result.Value);
            HeaderName = "Итоги операции";
            ResultOrOtmenaName = "Операция проведена";
            int i1 = 0;
            int i2 = 0;
            string leftP = "";
            string rightP = "";
            if (oprresult.IdNextOperation != null)
            {

                // PlanedOpr = Data.OperationType.Get(Data.Operation.Get(oprresult.IdNextOperation.Value).OperationTypeId).LongName;

                 i1 = 0;
                 i2 = 0;
                leftP = "";
                rightP = "";
                foreach (var Diagnosis in Data.OperationTypeOperations.GetAll)
                {
                    if (Diagnosis.id_operation == Data.Operation.Get(oprresult.IdNextOperation.Value).Id)
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
                            //     var buf1 = new OperationTypesDataSource(Data.OperationType.Get(Diagnosis.id_типОперации.Value));
                            //   buf1.IsChecked = true;
                            // LeftOperationListPlaned.Add(buf1);
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
                            //var buf2 = new OperationTypesDataSource(Data.OperationType.Get(Diagnosis.id_типОперации.Value));
                            //buf2.IsChecked = true;
                            //RightOperationListPlaned.Add(buf2);
                        }
                    }

                }
                if (Operation.OnWhatLegOp == "0")
                {
                    PlanedOpr = "\nНа левую нижнюю конечность : " + leftP;
                }
                if (Operation.OnWhatLegOp == "1")
                {
                    PlanedOpr = "\nНа правую нижнюю конечность : " + rightP;
                }
                if (Operation.OnWhatLegOp == "2")
                {
                    PlanedOpr = "\nНа левую нижнюю конечность : " + leftP + " " + "\nНа правую нижнюю конечность : " + rightP; 
                }


                visibilityOfNextOP = Visibility.Visible;
            }
            else
            {
                visibilityOfNextOP = Visibility.Hidden;
            }
            comment = oprresult.Str;
            //DateTime bufTime = DateTime.Parse(Operation.Time);
            // operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;

            i1 = 0;
            i2 = 0;
            leftP = "";
            rightP = "";
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
            if (Operation.OnWhatLegOp == "0")
            {
                operationType = "На левую нижнюю конечность :" + leftP;
            }
            if (Operation.OnWhatLegOp == "1")
            {
                operationType = "На правую нижнюю конечность :" + rightP;
            }
            if (Operation.OnWhatLegOp == "2")
            {
                operationType = "На левую нижнюю конечность :" + leftP + " " + "На правую нижнюю конечность :" + rightP;
            }
            //Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Data.OperationDateTime.Get(Operation.Datetime_id.Value).Datetime;

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
