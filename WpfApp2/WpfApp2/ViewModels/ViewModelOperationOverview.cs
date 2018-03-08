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
            using (var context = new MySqlContext())
            {
                OperationTypeOperationsRepository OperationOpRep = new OperationTypeOperationsRepository(context);
                DiagnosisRepository DiagnosisRep = new DiagnosisRepository(context);
                DiagnosisTypeRepository DiagnosisTypeRep = new DiagnosisTypeRepository(context);
                MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);
                DoctorRepository DoctorRep = new DoctorRepository(context);
                OperationRepository OperationRp = new OperationRepository(context);

                AnestethicRepository AnestethicRep = new AnestethicRepository(context);
                OperationTypeRepository OperationTypeRep = new OperationTypeRepository(context);
                PatientsRepository PatientsRep = new PatientsRepository(context);

                BrigadeRepository BrigadeRep = new BrigadeRepository(context);
                BrigadeMedPersonalRepository BrigadeMedRep = new BrigadeMedPersonalRepository(context);

                Operation = OperationRp.Get((int)data);



                DateTime bufTime = DateTime.Parse(Operation.Time);

                Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);


                if (Operation.Date > DateTime.Now)
                {
                    OperationResults = "Операция еще не проведена";
                    VisiBIlityOfAddResult = Visibility.Hidden;
                    VisiBIlityOfAddCancle = Visibility.Visible;

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

                if (Operation.итоги_операции != null)
                {

                    OperationResults = "Итоги добавлены";
                    VisiBIlityOfAddResult = Visibility.Visible;
                    VisiBIlityOfAddCancle = Visibility.Hidden;
                    ResultButtonName = "Посмотреть итоги";
                    ToAddOperationResultCommand = new DelegateCommand(() =>
                    {
                        MessageBus.Default.Call("GetOprForOprResultOverview", this, Operation.Id);
                        Controller.NavigateTo<ViewModelOperationResultOverview>();

                    });
                }

                if (Operation.отмена_операции != null)
                {
                    OperationResults = "Операция перенесена";
                    VisiBIlityOfAddResult = Visibility.Hidden;
                    VisiBIlityOfAddCancle = Visibility.Hidden;
                }
                LeftDiagnosisList = new List<DiagnosisDataSource>();
                RightDiagnosisList = new List<DiagnosisDataSource>();
                DoctorsSelected = new List<DoctorDataSource>();
                RightOperationList = new List<OperationTypesDataSource>();
                LeftOperationList = new List<OperationTypesDataSource>();
                AnesteticSelected = AnestethicRep.Get(Operation.AnestheticId).Str;


                //OprTypeSelected = OperationTypeRep.Get(Operation.OperationTypeId).LongName;


                CurrentPatient = PatientsRep.Get(Operation.PatientId);


                initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";


                foreach (var Brigade in BrigadeRep.GetAll)
                {
                    if (Brigade.id_операции == Operation.Id)
                    {
                        var buf = new DoctorDataSource(DoctorRep.Get(Brigade.id_врача.Value).Name, DoctorRep.Get(Brigade.id_врача.Value).Sirname, DoctorRep.Get(Brigade.id_врача.Value).Patronimic, true, DoctorRep.Get(Brigade.id_врача.Value).Id);
                        buf.IsChecked = true;
                        DoctorsSelected.Add(buf);
                    }
                }
                foreach (var Brigade in BrigadeMedRep.GetAll)
                {
                    if (Brigade.id_операции == Operation.Id)
                    {
                        var buf = new DoctorDataSource(MedPersonalRep.Get(Brigade.id_медперсонал.Value).Name, MedPersonalRep.Get(Brigade.id_медперсонал.Value).Surname, MedPersonalRep.Get(Brigade.id_медперсонал.Value).Patronimic, false, MedPersonalRep.Get(Brigade.id_медперсонал.Value).Id);
                        buf.IsChecked = true;
                        DoctorsSelected.Add(buf);
                    }
                }



                foreach (var Diagnosis in DiagnosisRep.GetAll)
                {
                    if (Diagnosis.id_операции == Operation.Id)
                    {
                        if (Diagnosis.isLeft == true)
                        {
                            var buf1 = new DiagnosisDataSource(DiagnosisTypeRep.Get(Diagnosis.id_диагноз.Value));
                            buf1.IsChecked = true;
                            LeftDiagnosisList.Add(buf1);
                        }
                        else
                        {
                            var buf2 = new DiagnosisDataSource(DiagnosisTypeRep.Get(Diagnosis.id_диагноз.Value));
                            buf2.IsChecked = true;
                            RightDiagnosisList.Add(buf2);
                        }
                    }
                }




                foreach (var Diagnosis in OperationOpRep.GetAll)
                {
                    if (Diagnosis.id_операции == Operation.Id)
                    {
                        if (Diagnosis.isLeft == true)
                        {
                            var buf1 = new OperationTypesDataSource(OperationTypeRep.Get(Diagnosis.id_типОперации.Value));
                            buf1.IsChecked = true;
                            LeftOperationList.Add(buf1);
                        }
                        else
                        {
                            var buf2 = new OperationTypesDataSource(OperationTypeRep.Get(Diagnosis.id_типОперации.Value));
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
