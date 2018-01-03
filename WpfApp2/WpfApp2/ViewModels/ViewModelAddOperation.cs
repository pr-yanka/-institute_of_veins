using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class DoctorDataSource : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool? _isChecked;
        public bool? IsChecked
        {
            get
            {
                if (_isChecked == null)
                    return false;
                else return _isChecked;
            }
            set { _isChecked = value; MessageBus.Default.Call("UpdateSelectedDoctors", this, null); OnPropertyChanged(); }
        }
        public Doctor Data { get; set; }

        public string initials { get; set; }

        public DoctorDataSource(Doctor Doctor)
        {
            this.Data = Doctor;
            initials = " " + Doctor.Name.ToCharArray()[0].ToString() + ". " + Doctor.Patronimic.ToCharArray()[0].ToString() + ".";
            IsChecked = false;
        }
    }
    public class ViewModelAddOperation : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void UpdateSelectedDoctors(object sender, object data)
        {

            DoctorsSelected = new ObservableCollection<DoctorDataSource>();
            foreach (var doctor in Doctors)
            {
                if (doctor.IsChecked == true)
                { DoctorsSelected.Add(doctor); }
            }
        }
        public ObservableCollection<DiagnosisDataSource> LeftDiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> RightDiagnosisList { get; set; }
        public ObservableCollection<string> OprTypes { get; set; }
        public ObservableCollection<string> AnestethicTypes { get; set; }
        public ObservableCollection<DoctorDataSource> Doctors { get; set; }

        private Brush _textBox_Minute;
        private Brush _textBox_Hour;


        public Brush TextBoxMinute { get { return _textBox_Minute; } set { _textBox_Minute = value; OnPropertyChanged(); } }

        public Brush TextBoxHour { get { return _textBox_Hour; } set { _textBox_Hour = value; OnPropertyChanged(); } }



        private ObservableCollection<DoctorDataSource> _doctorsSelected;




        public ObservableCollection<DoctorDataSource> DoctorsSelected
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
        private void SetRightDiagnosisList(object sender, object data)
        {
            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            foreach (var diag in (List<DiagnosisDataSource>)data)
            { RightDiagnosisList.Add(diag); }
        }
        private void SetLeftDiagnosisList(object sender, object data)
        {
            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            foreach (var diag in (List<DiagnosisDataSource>)data)
            { LeftDiagnosisList.Add(diag); }

        }
        public Operation Operation { get; set; }
        string _minute;
        string _hour;
        bool TimeCheckMinute;
        public string Minute
        {
            get { return _minute; }
            set
            {
                _minute = value; int buf = 0;
                if (int.TryParse(_minute, out buf))
                {
                    if (buf > 60 || buf < 0)
                    {
                        TextBoxMinute = Brushes.Red;
                        TimeCheckMinute = false;
                    }else
                    { TimeCheckMinute = true; TextBoxMinute = Brushes.Gray; }
                }
                else { TextBoxMinute = Brushes.Red; TimeCheckMinute = false; }
                OnPropertyChanged();
            }
        }
        
        public string Hour { get { return _hour; } set { _hour = value;
                int buf = 0;
                if (int.TryParse(_hour, out buf))
                {
                    if (buf > 24 || buf < 0)
                    {
                        TextBoxHour = Brushes.Red;
                        
                        TimeCheckHour = false;
                    }
                    else
                    { TimeCheckHour = true; TextBoxHour = Brushes.Gray; }
                }
                else { TextBoxHour = Brushes.Red; TimeCheckHour = false; }
                OnPropertyChanged(); 
            } }


        bool TimeCheckHour;
        public int AnesteticSelected { get; set; }
        public int OprTypeSelected { get; set; }

        public string ButtonSaveText { get; set; }
        public DelegateCommand ToLeftDiagCommand { get; protected set; }
        public DelegateCommand ToRightDiagCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public Patient CurrentPatient { get; set; }
        public string initials { get; set; }
        private void SetCurrentPatientID(object sender, object data)
        {

            CurrentPatient = Data.Patients.Get((int)data);
            initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

        }

        public ViewModelAddOperation(NavigationController controller) : base(controller)
        {
           
            TextBoxMinute = Brushes.Gray;
            TextBoxHour = Brushes.Gray;
            Minute = "0";
            Hour = "0";
            TimeCheckHour = true;
            TimeCheckMinute = true;
            ButtonSaveText = "Назначить операцию";
            MessageBus.Default.Subscribe("SetCurrentPatientForOperation", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetRightDiagnosisListForOperation", SetRightDiagnosisList);
            MessageBus.Default.Subscribe("SetLeftDiagnosisListForOperation", SetLeftDiagnosisList);
            MessageBus.Default.Subscribe("UpdateSelectedDoctors", UpdateSelectedDoctors);
            OprTypes = new ObservableCollection<string>();
            AnestethicTypes = new ObservableCollection<string>();
            Doctors = new ObservableCollection<DoctorDataSource>();
            Controller = controller;
            HasNavigation = false;
            Operation = new Operation();
            Operation.Date = DateTime.Now;
            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();


            foreach (var Doctor in Data.Doctor.GetAll)
            {
                Doctors.Add(new DoctorDataSource(Doctor));
            }
            foreach (var OprType in Data.OperationType.GetAll)
            {
                OprTypes.Add(OprType.LongName);
            }
            foreach (var AnestethicType in Data.Anestethic.GetAll)
            {
                AnestethicTypes.Add(AnestethicType.Str);
            }
            ToCurrentPatientCommand = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelCurrentPatient>(); }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                // TextBoxMinute = Brushes.Red;
                // TextBoxHour = Brushes.Red;
                if (LeftDiagnosisList.Count == 0 || RightDiagnosisList.Count == 0 || DoctorsSelected.Count == 0 || TimeCheckHour == false || TimeCheckMinute == false)
                {

                    MessageBox.Show("Не все заполнено");
                }
                else
                {
                    Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, int.Parse(Hour), int.Parse(Minute), 0);
                    Operation.Time = Hour + ":" + Minute+":"+ 0;

                        Operation.PatientId = CurrentPatient.Id;
                        Operation.AnestheticId = AnesteticSelected + 1;
                        Operation.OperationTypeId = OprTypeSelected + 1;
                        Data.Operation.Add(Operation);
                        Data.Complete();
                        foreach (var Doctor in DoctorsSelected)
                        {
                            Brigade buf = new Brigade();
                            buf.id_врача = Doctor.Data.Id;
                            buf.id_операции = Operation.Id;
                            Data.Brigade.Add(buf);


                        }
                        Data.Complete();
                        foreach (var diagnozL in LeftDiagnosisList)
                        {
                            
                            Diagnosis buf = new Diagnosis();
                            buf.id_диагноз = diagnozL.Data.Id;
                            buf.id_операции = Operation.Id;
                            buf.isLeft = true;

                            Data.Diagnosis.Add(buf);

                        }
                        Data.Complete();
                        foreach (var diagnozR in RightDiagnosisList)
                        {

                            Diagnosis buf = new Diagnosis();
                            buf.id_диагноз = diagnozR.Data.Id;
                            buf.id_операции = Operation.Id;
                            buf.isLeft = false;

                            Data.Diagnosis.Add(buf);

                        }

                        Data.Complete();
                        Operation = new Operation();
                        Controller.NavigateTo<ViewModelOperationOverview>();
                    }
                }
            );
           
            ToLeftDiagCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetleftOrRight", this, "Left");
                    Controller.NavigateTo<ViewModelDiagnosisListForOperation>();
                }
            );
            ToRightDiagCommand = new DelegateCommand(
               () =>
               {
                   MessageBus.Default.Call("SetleftOrRight", this, "Right");
                   Controller.NavigateTo<ViewModelDiagnosisListForOperation>();
               }
           );
        }
    }
}
