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
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToAddOperationResultCommand { get; protected set; }
        public DelegateCommand ToCancleOperationCommand { get; protected set; }
        public Patient CurrentPatient { get; protected set; }
        public string initials { get; protected set; }
        #endregion

        #region Bindings
        public string OperationResults { get; set; }
        public Visibility VisiBIlityOfAddResult { get; set; }
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

        private void GetOperation(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                OperationRepository OperationRp = new OperationRepository(context);
                Operation = OperationRp.Get((int)data);
            }
            if (Operation.итоги_операции != null)
            {
                OperationResults = "Операция проведена";

            }
            else
            { OperationResults = "Итоги ещё не добавлены!"; }
            if (Operation.отмена_операции != null)
            {
                OperationResults = "Операция перенесена";

            }
            LeftDiagnosisList = new List<DiagnosisDataSource>();
            RightDiagnosisList = new List<DiagnosisDataSource>();
            DoctorsSelected = new List<DoctorDataSource>();
            AnesteticSelected = Data.Anestethic.Get(Operation.AnestheticId).Str;
            OprTypeSelected = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            CurrentPatient = Data.Patients.Get(Operation.PatientId);
            initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

            DateTime bufTime = DateTime.Parse(Operation.Time);

            Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);


            if (Operation.Date > DateTime.Now || Operation.итоги_операции != null || Operation.отмена_операции != null)
            { VisiBIlityOfAddResult = Visibility.Hidden; }
            else
            {
                VisiBIlityOfAddResult = Visibility.Visible;
            }
            foreach (var Brigade in Data.Brigade.GetAll)
            {
                if (Brigade.id_операции == Operation.Id)
                {
                    var buf = new DoctorDataSource(Data.Doctor.Get(Brigade.id_врача.Value));
                    buf.IsChecked = true;
                    DoctorsSelected.Add(buf);
                }
            }
            //foreach (var diagnozL in LeftDiagnosisList)
            foreach (var Diagnosis in Data.Diagnosis.GetAll)
            {
                if (Diagnosis.id_операции == Operation.Id)
                {
                    if (Diagnosis.isLeft == true)
                    {
                        var buf1 = new DiagnosisDataSource(Data.DiagnosisTypes.Get(Diagnosis.id_диагноз.Value));
                        buf1.IsChecked = true;
                        LeftDiagnosisList.Add(buf1);
                    }
                    else
                    {
                        var buf2 = new DiagnosisDataSource(Data.DiagnosisTypes.Get(Diagnosis.id_диагноз.Value));
                        buf2.IsChecked = true;
                        RightDiagnosisList.Add(buf2);
                    }
                }
            }


        }

       

        public ViewModelOperationOverview(NavigationController controller) : base(controller)
        {

            MessageBus.Default.Subscribe("GetOperationForOverwiev", GetOperation);


            base.HasNavigation = false;
            #region DelegateCommands
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
