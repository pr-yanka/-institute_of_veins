using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelOperationOverview : ViewModelBase, INotifyPropertyChanged
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
        public DelegateCommand ToCreateEpicrizCommand { get; protected set; }
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToAddOperationResultCommand { get; protected set; }
        public DelegateCommand ToCancleOperationCommand { get; protected set; }
        public Patient CurrentPatient { get; protected set; }
        public string initials { get; protected set; }
        #endregion

        #region Bindings
        public string OperationResults { get; set; }

        public string ResultButtonName { get; set; }
        public Visibility VisiBIlityOfAddCancle { get; set; }
        public Visibility VisiBIlityOfAddResult { get; set; }

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
        private List<DiagnosisDataSource> _leftDiagnosisList;
        private List<DiagnosisDataSource> _rightDiagnosisList;
        private List<DoctorDataSource> _doctorsSelected;
        public List<DiagnosisDataSource> LeftDiagnosisList
        {
            get
            {
                return _leftDiagnosisList;
            }
            set
            {
                _leftDiagnosisList = value; OnPropertyChanged();
            }
        }
        public List<DiagnosisDataSource> RightDiagnosisList
        {
            get
            {
                return _rightDiagnosisList;
            }
            set
            {
                _rightDiagnosisList = value; OnPropertyChanged();
            }
        }
        public List<DoctorDataSource> DoctorsSelected
        {
            get
            {
                return _doctorsSelected;
            }
            set
            {
                _doctorsSelected = value; OnPropertyChanged();
            }
        }
        public Operation Operation { get; set; }

        public string AnesteticSelected { get; set; }
        public string OprTypeSelected { get; set; }

        #endregion
        private Visibility _isRightLegInOperation;

        private Visibility _isLeftLegInOperation;


        public Visibility IsRightLegInOperation
        {
            get
            {

                return _isRightLegInOperation;

            }
            set { _isRightLegInOperation = value; OnPropertyChanged(); }
        }

        public Visibility IsLeftLegInOperation
        {
            get
            {

                return _isLeftLegInOperation;

            }
            set { _isLeftLegInOperation = value; OnPropertyChanged(); }
        }
        private void GetOperation(object sender, object data)
        {
            Operation = Data.Operation.Get((int)data);



            //DateTime bufTime = DateTime.Parse(Operation.Time);

            //Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);


            if (Operation.operation_result == null)
            {
                OperationResults = "Операция еще не проведена";
                VisiBIlityOfAddResult = Visibility.Visible;
                VisiBIlityOfAddCancle = Visibility.Visible;
                ResultButtonName = "Добавить итоги";
                ToAddOperationResultCommand = new DelegateCommand(() =>
                {
                    MessageBus.Default.Call("GetOperationIDForAddOperationResult", this, Operation.Id);
                    Controller.NavigateTo<ViewModelAddOperationResult>();
                });
            }
            else
            {
                OperationResults = "Операция проведена";
                VisiBIlityOfAddResult = Visibility.Visible;
                VisiBIlityOfAddCancle = Visibility.Hidden;
                ResultButtonName = "Добавить итоги";
                ToAddOperationResultCommand = new DelegateCommand(() =>
                {
                    MessageBus.Default.Call("GetOperationIDForAddOperationResult", this, Operation.Id);
                    Controller.NavigateTo<ViewModelAddOperationResult>();
                });
            }

            if (Operation.operation_result != null)
            {

                OperationResults = "Итоги добавлены";
                VisiBIlityOfAddResult = Visibility.Visible;
                VisiBIlityOfAddCancle = Visibility.Hidden;
                ResultButtonName = "Посмотреть итоги";
                ToAddOperationResultCommand = new DelegateCommand(() =>
                {
                    //MessageBus.Default.Call("GetOprForOprResultOverview", this, Operation.Id);
                    //Controller.NavigateTo<ViewModelOperationResultOverview>();
                    MessageBus.Default.Call("GetOperationIDForAddOperationResult", this, Operation.Id);
                    Controller.NavigateTo<ViewModelAddOperationResult>();

                });
            }

            if (Operation.cancel_operations != null)
            {
                OperationResults = "Операция отменена";
                VisiBIlityOfAddResult = Visibility.Hidden;
                VisiBIlityOfAddCancle = Visibility.Hidden;
            }
            LeftDiagnosisList = new List<DiagnosisDataSource>();
            RightDiagnosisList = new List<DiagnosisDataSource>();
            DoctorsSelected = new List<DoctorDataSource>();
            RightOperationList = new List<OperationTypesDataSource>();
            LeftOperationList = new List<OperationTypesDataSource>();
            AnesteticSelected = Data.Anestethic.Get(Operation.AnestheticId).Str;


            //OprTypeSelected = OperationTypeRep.Get(Operation.OperationTypeId).LongName;


            CurrentPatient = Data.Patients.Get(Operation.PatientId);


            initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";


            foreach (var Brigade in Data.Brigade.GetAll)
            {
                if (Brigade.id_operation == Operation.Id)
                {
                    var doctor = Data.Doctor.Get(Brigade.id_doctor.Value);
                    var buf = new DoctorDataSource(doctor.Name, doctor.Sirname, doctor.Patronimic, true, doctor.Id);
                    buf.IsChecked = true;
                    DoctorsSelected.Add(buf);
                }
            }
            foreach (var Brigade in Data.BrigadeMedPersonal.GetAll)
            {
                if (Brigade.id_operation == Operation.Id)
                {
                    var medPersonal = Data.MedPersonal.Get(Brigade.id_med_staff.Value);
                    var buf = new DoctorDataSource(medPersonal.Name, medPersonal.Surname, medPersonal.Patronimic, false, medPersonal.Id);
                    buf.IsChecked = true;
                    DoctorsSelected.Add(buf);
                }
            }



            foreach (var Diagnosis in Data.Diagnosis.GetAll)
            {
                if (Diagnosis.id_operation == Operation.Id)
                {
                    if (Diagnosis.isLeft == true)
                    {
                        var buf1 = new DiagnosisDataSource(Data.DiagnosisTypes.Get(Diagnosis.id_diagnosis.Value));
                        buf1.IsChecked = true;
                        LeftDiagnosisList.Add(buf1);
                    }
                    else
                    {
                        var buf2 = new DiagnosisDataSource(Data.DiagnosisTypes.Get(Diagnosis.id_diagnosis.Value));
                        buf2.IsChecked = true;
                        RightDiagnosisList.Add(buf2);
                    }
                }
            }




            foreach (var Diagnosis in Data.OperationTypeOperations.GetAll)
            {
                if (Diagnosis.id_operation == Operation.Id)
                {
                    if (Diagnosis.isLeft == true)
                    {
                        var buf1 = new OperationTypesDataSource(Data.OperationType.Get(Diagnosis.id_operation_type.Value));
                        buf1.IsChecked = true;
                        LeftOperationList.Add(buf1);
                    }
                    else
                    {
                        var buf2 = new OperationTypesDataSource(Data.OperationType.Get(Diagnosis.id_operation_type.Value));
                        buf2.IsChecked = true;
                        RightOperationList.Add(buf2);
                    }
                }
            }
            if (Operation.OnWhatLegOp == "0")
            {
                IsLeftLegInOperation = Visibility.Visible;
                IsRightLegInOperation = Visibility.Collapsed;
            }
            if (Operation.OnWhatLegOp == "1")
            {
                IsLeftLegInOperation = Visibility.Collapsed;
                IsRightLegInOperation = Visibility.Visible;
            }
            if (Operation.OnWhatLegOp == "2")
            {
                IsLeftLegInOperation = Visibility.Visible;
                IsRightLegInOperation = Visibility.Visible;
            }
        }


        public ViewModelOperationOverview(NavigationController controller) : base(controller)
        {

            MessageBus.Default.Subscribe("GetOperationForOverwiev", GetOperation);


            base.HasNavigation = false;
            #region DelegateCommands

            ToCreateEpicrizCommand = new DelegateCommand(() =>
            {
                MessageBus.Default.Call("GetOperationIDForAddEpicriz", DoctorsSelected, Operation.Id);
                Controller.NavigateTo<ViewModelAddEpicriz>();
            });


            ToAddOperationResultCommand = new DelegateCommand(() =>
            {
                MessageBus.Default.Call("GetOperationIDForAddOperationResult", this, Operation.Id);
                Controller.NavigateTo<ViewModelAddOperationResult>();
            });


            ToCancleOperationCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetFunctionsToReturnToOpOwervier", null, null);
                    MessageBus.Default.Call("GetOperationIDForAddCancel", this, Operation.Id);
                    Controller.NavigateTo<ViewModelCancelOperations>();
                }
            );
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientId", this, Operation.PatientId);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
            #endregion
        }
    }
}
