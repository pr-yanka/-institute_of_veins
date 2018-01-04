using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelOperationOverview : ViewModelBase, INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        //
       // public ObservableCollection<DiagnosisDataSource> LeftDiagnosisList { get; set; }
       // public ObservableCollection<DiagnosisDataSource> RightDiagnosisList { get; set; }
       //  public ObservableCollection<string> OprTypes { get; set; }
       // public ObservableCollection<string> AnestethicTypes { get; set; }
       //   public ObservableCollection<DoctorDataSource> Doctors { get; set; }

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
        
        private void GetOperation(object sender, object data)
        {
            Operation = Data.Operation.Get((int)data);
            LeftDiagnosisList = new List<DiagnosisDataSource>();
            RightDiagnosisList = new List<DiagnosisDataSource>();
            DoctorsSelected = new List<DoctorDataSource>();
            AnesteticSelected = Data.Anestethic.Get(Operation.AnestheticId).Str;
            OprTypeSelected = Data.OperationType.Get(Operation.OperationTypeId).LongName;

            DateTime bufTime = DateTime.Parse(Operation.Time);

            Operation.Date =  new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);

           
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
        
 
        public ViewModelOperationOverview(NavigationController controller) : base(controller)
        {

            //Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, int.Parse(Hour), int.Parse(Minute), 0);
            //Operation.Time = Hour + ":" + Minute + ":" + 0;

            //Operation.PatientId = CurrentPatient.Id;
            //Operation.AnestheticId = AnesteticSelected + 1;
            //Operation.OperationTypeId = OprTypeSelected + 1;
            //Data.Operation.Add(Operation);
            //Data.Complete();

            //Data.Complete();
            //Operation = new Operation();

            MessageBus.Default.Subscribe("GetOperationForOverwiev", GetOperation);


            base.HasNavigation = false;
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
        }
    }
}
