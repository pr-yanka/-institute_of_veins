using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.LegParts;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.ViewModels
{
    public class DoctorDataSource : INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
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
        public bool isDoctor;
        public int id;
        public string Surname { get; set; }

        public string initials { get; set; }

        public DoctorDataSource(string Name, string Surname, string Patronimic, bool isDoctor, int id)
        {
            this.id = id;
            this.isDoctor = isDoctor;
            this.Surname = Surname;
            initials = " " + Name.ToCharArray()[0].ToString() + ". " + Patronimic.ToCharArray()[0].ToString() + ".";
            IsChecked = false;
        }
    }
    public class ViewModelAddOperation : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify Realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region everyth connected with panel

        public DelegateCommand RevertCommand { set; get; }
        public DelegateCommand SaveCommand { set; get; }

        public ICommand OpenPanelCommand { protected set; get; }

        public OperationTypePanelViewModel CurrentPanelViewModel { get; protected set; }

        public static bool Handled = false;
        public UIElement UI;

        public DelegateCommand NewOpTypeCommand { get; set; }

        private void OpenHandler(object sender, object data)
        {
            if (!Handled)
            {
                Handled = true;
                CurrentPanelViewModel.PanelOpened = true;
            }
        }

        #endregion

        #region Bindings
        public ObservableCollection<DiagnosisDataSource> LeftDiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> RightDiagnosisList { get; set; }

        private ObservableCollection<string> _oprTypes;
        private ObservableCollection<string> _anestethicTypes;

        public ObservableCollection<string> OprTypes { get { return _oprTypes; } set { _oprTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<string> AnestethicTypes { get { return _anestethicTypes; } set { _anestethicTypes = value; OnPropertyChanged(); } }

        public ObservableCollection<int> OprTypesId { get; set; }
        public ObservableCollection<int> AnestethicTypesID { get; set; }
        public List<DoctorDataSource> Doctors { get; set; }

        private Brush _textBox_Minute;
        private Brush _textBox_Hour;


        public Brush TextBoxMinute { get { return _textBox_Minute; } set { _textBox_Minute = value; OnPropertyChanged(); } }

        public Brush TextBoxHour { get { return _textBox_Hour; } set { _textBox_Hour = value; OnPropertyChanged(); } }

        private DateTime _minuteHour;
        public DateTime MinuteHour { get { return _minuteHour; } set { _minuteHour = value; OnPropertyChanged(); } }


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

        public Operation Operation { get; set; }
    
        bool TimeCheckMinute;

        private OperationResult OperationResult { get; set; }

        bool TimeCheckHour;
        public int AnesteticSelected { get; set; }
        private int _oprTypeSelected;
        public int OprTypeSelected { get { return _oprTypeSelected; } set { _oprTypeSelected = value; OnPropertyChanged(); } }

        public string ButtonSaveText { get; set; }
        public DelegateCommand ToLeftDiagCommand { get; protected set; }
        public DelegateCommand ToRightDiagCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }

        public Patient CurrentPatient { get; set; }
        public string initials { get; set; }
        #endregion

        #region MessageBus
        bool isSetOperResult = false;
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
        private void SetOperResult(object sender, object data)
        {
            isSetOperResult = true;
            var buf = (OperationResult)data;
            OperationResult = Data.OperationResult.Get(buf.Id);
        }

        private void UpdateSelectedDoctors(object sender, object data)
        {
            DoctorsSelected = new ObservableCollection<DoctorDataSource>();
            if (Doctors != null)
            {
                foreach (var doctor in Doctors)
                {
                    if (doctor.IsChecked == true)
                    { DoctorsSelected.Add(doctor); }
                }
            }
        }
        private void SetCurrentPatientID(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);
                DoctorRepository DoctorRep = new DoctorRepository(context);
                Operation = new Operation();
                Operation.Date = DateTime.Now;
                CurrentPatient = Data.Patients.Get((int)data);
                initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

                OprTypes = new ObservableCollection<string>();
                AnestethicTypes = new ObservableCollection<string>();
                Doctors = new List<DoctorDataSource>();
                OprTypesId = new ObservableCollection<int>();
                AnestethicTypesID = new ObservableCollection<int>();
                foreach (var Doctor in DoctorRep.GetAll)
                {
                    if (Doctor.isEnabled.Value)
                    {
                        Doctors.Add(new DoctorDataSource(Doctor.Name, Doctor.Sirname, Doctor.Patronimic, true, Doctor.Id));
                    }
                }
                foreach (var Meds in MedPersonalRep.GetAll)
                {
                    if (Meds.isEnabled.Value)
                    {
                        Doctors.Add(new DoctorDataSource(Meds.Name, Meds.Surname, Meds.Patronimic, false, Meds.Id));
                    }
                }
                foreach (var OprType in Data.OperationType.GetAll)
                {
                    OprTypes.Add(OprType.LongName);
                    OprTypesId.Add(OprType.Id);
                }
                foreach (var AnestethicType in Data.Anestethic.GetAll)
                {
                    AnestethicTypes.Add(AnestethicType.Str);
                    AnestethicTypesID.Add(AnestethicType.Id);
                }
            }
        }
        #endregion

        public ViewModelAddOperation(NavigationController controller) : base(controller)
        {

            TextBoxMinute = Brushes.Gray;
            TextBoxHour = Brushes.Gray;
            MinuteHour = DateTime.Now;
            TimeCheckHour = true;
            TimeCheckMinute = true;
            ButtonSaveText = "Назначить операцию";


            MessageBus.Default.Subscribe("SetOperationResult", SetOperResult);
            MessageBus.Default.Subscribe("SetCurrentPatientForOperation", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetRightDiagnosisListForOperation", SetRightDiagnosisList);
            MessageBus.Default.Subscribe("SetLeftDiagnosisListForOperation", SetLeftDiagnosisList);
            MessageBus.Default.Subscribe("UpdateSelectedDoctors", UpdateSelectedDoctors);

            Controller = controller;
            HasNavigation = false;
            Operation = new Operation();
            Operation.Date = DateTime.Now;
            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();



            ToCurrentPatientCommand = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelCurrentPatient>(); }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {

                    if (LeftDiagnosisList.Count == 0 || RightDiagnosisList.Count == 0 || DoctorsSelected.Count == 0 || TimeCheckHour == false || TimeCheckMinute == false)
                    {

                        MessageBox.Show("Не всё заполнено!");
                    }
                    else
                    {

                        Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, MinuteHour.Hour, MinuteHour.Minute, 0);
                        Operation.Time = MinuteHour.Hour + ":" + MinuteHour.Minute + ":" + 0;

                        Operation.PatientId = CurrentPatient.Id;
                        Operation.AnestheticId = AnestethicTypesID[AnesteticSelected];
                        Operation.OperationTypeId = OprTypesId[OprTypeSelected];
                        Data.Operation.Add(Operation);
                        Data.Complete();
                        foreach (var Doctor in DoctorsSelected)
                        {
                            if (Doctor.isDoctor)
                            {
                                Brigade buf = new Brigade();
                                buf.id_врача = Doctor.id;
                                buf.id_операции = Operation.Id;
                                Data.Brigade.Add(buf);
                            }else
                            {
                                BrigadeMedPersonal buf = new BrigadeMedPersonal();
                                buf.id_медперсонал = Doctor.id;
                                buf.id_операции = Operation.Id;
                                Data.BrigadeMedPersonal.Add(buf);
                            }

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
                        if (isSetOperResult == true)
                        {
                            OperationResult.IdNextOperation = Operation.Id;
                            Data.Complete();
                            isSetOperResult = false;
                        }
                        MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);
                        Controller.NavigateTo<ViewModelOperationOverview>();
                        Data.Complete();
                        Operation = new Operation();
                        OperationResult = new OperationResult();
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
            //for right panel
            CurrentPanelViewModel = new OperationTypePanelViewModel(this);
            OpenPanelCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {
             
            
                var newType = CurrentPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.LongName) && !string.IsNullOrWhiteSpace(newType.ShortName))
                {
                    CurrentPanelViewModel.PanelOpened = false;
                    Handled = false;
                    Data.OperationType.Add((newType));
                    Data.Complete();
                    MessageBus.Default.Call("SetCurrentPatientForOperation", this, CurrentPatient.Id);
                    OprTypeSelected = OprTypes.Count - 1;
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });

            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });
        }
    }
}
