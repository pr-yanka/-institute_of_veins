using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;
using System.Windows.Data;
using System.Globalization;

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
        private bool _isVisible;
        private bool _isDoctor;

        public bool IsVisible
        {
            get
            {

                return _isVisible;

            }
            set { _isVisible = value; OnPropertyChanged(); }
        }




        public bool isDoctor
        {
            get
            {

                return _isDoctor;

            }
            set { _isDoctor = value; OnPropertyChanged(); }
        }
        public int id;
        public string Surname { get; set; }

        public string initials { get; set; }

        public DoctorDataSource(string Name, string Surname, string Patronimic, bool isDoctor, int id)
        {
            IsVisible = true;
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

        public DelegateCommand GetLeftFromLastObs { set; get; }
        public DelegateCommand GetRightFromLastObs { set; get; }

        public DelegateCommand RevertCommand { set; get; }
        public DelegateCommand SaveCommand { set; get; }
        public DelegateCommand SaveAnesteticCommand { set; get; }
        public DelegateCommand RevertAnesteticCommand { get; private set; }
        public ICommand OpenPanelCommand { protected set; get; }
        public ICommand OpenPanelAnesteticCommand { protected set; get; }
        public OperationTypePanelViewModel CurrentPanelViewModel { get; protected set; }

        public AnetheticTypePanelViewModel CurrentPanelAnestViewModel { get; protected set; }
        #region SELECTtIME
        public DelegateCommand SaveSelectTimeCommand { set; get; }
        public DelegateCommand RevertSelectTimeCommand { get; private set; }
        public ICommand OpenPanelSelectTime { protected set; get; }
        public SelectTimePanelViewModel CurrentPanelSelectTime { get; protected set; }
        #endregion
        public static bool Handled = false;
        public UIElement UI;




        public DelegateCommand NewOpTypeCommand { get; set; }
        public DelegateCommand NewAnetheticTypeCommand { get; set; }

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
        public CollectionViewSource LeftDiagnosisList { get; set; }
        public CollectionViewSource RightDiagnosisList { get; set; }

        public CollectionViewSource LeftOperationList { get; set; }
        public CollectionViewSource RightOperationList { get; set; }


        private ObservableCollection<string> _oprTypes;
        private ObservableCollection<string> _anestethicTypes;

        public ObservableCollection<string> OprTypes { get { return _oprTypes; } set { _oprTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<string> AnestethicTypes { get { return _anestethicTypes; } set { _anestethicTypes = value; OnPropertyChanged(); } }

        public ObservableCollection<int> OprTypesId { get; set; }
        public ObservableCollection<int> AnestethicTypesID { get; set; }
        public ObservableCollection<DoctorDataSource> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }

        private ObservableCollection<DoctorDataSource> _doctors;

        private Brush _textBox_Minute;
        private Brush _textBox_Hour;

        private bool _showDoctors;

        private bool _showMeds;

        private bool _showDoctorsSelected;

        private bool _showMedsSelected;

        public bool ShowDoctorsSelected
        {
            get { return _showDoctorsSelected; }
            set
            {

                _showDoctorsSelected = value;
                OnPropertyChanged();
                DoctorsSelected = new ObservableCollection<DoctorDataSource>();
                if (Doctors != null)
                {
                    foreach (var doctor in Doctors)
                    {
                        if (doctor.IsChecked == true)
                        {

                            if (doctor.isDoctor == true && ShowDoctorsSelected == true)
                                DoctorsSelected.Add(doctor);
                            if (doctor.isDoctor == false && ShowMedsSelected == true)
                                DoctorsSelected.Add(doctor);
                        }
                    }
                }
            }
        }
        public bool ShowMedsSelected
        {
            get { return _showMedsSelected; }
            set
            {

                _showMedsSelected = value;
                OnPropertyChanged();
                DoctorsSelected = new ObservableCollection<DoctorDataSource>();
                if (Doctors != null)
                {
                    foreach (var doctor in Doctors)
                    {
                        if (doctor.IsChecked == true)
                        {

                            if (doctor.isDoctor == true && ShowDoctorsSelected == true)
                                DoctorsSelected.Add(doctor);
                            if (doctor.isDoctor == false && ShowMedsSelected == true)
                                DoctorsSelected.Add(doctor);
                        }
                    }
                }
            }
        }


        public bool ShowDoctors
        {
            get { return _showDoctors; }
            set
            {

                _showDoctors = value; OnPropertyChanged();
                if (ShowDoctors == false)
                {
                    foreach (var doc in Doctors)
                    {
                        if (doc.isDoctor == true)
                            doc.IsVisible = false;
                    }
                }
                else
                {
                    foreach (var doc in Doctors)
                    {
                        if (doc.isDoctor == true)
                            doc.IsVisible = true;
                    }
                }

            }
        }

        public bool ShowMeds
        {
            get { return _showMeds; }
            set
            {
                _showMeds = value; OnPropertyChanged();
                if (ShowMeds == false)
                {
                    foreach (var doc in Doctors)
                    {
                        if (doc.isDoctor == false)
                            doc.IsVisible = false;
                    }
                }
                else
                {
                    foreach (var doc in Doctors)
                    {
                        if (doc.isDoctor == false)
                            doc.IsVisible = true;
                    }
                }
            }
        }



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

        private Brush _button_time_B;

        public Brush Button_time_B { get { return _button_time_B; } set { _button_time_B = value; OnPropertyChanged(); } }

        bool TimeCheckHour;
        private int _anesteticSelected;
        public int AnesteticSelected { get { return _anesteticSelected; } set { _anesteticSelected = value; OnPropertyChanged(); } }
        private int _oprTypeSelected;
        public int OprTypeSelected { get { return _oprTypeSelected; } set { _oprTypeSelected = value; OnPropertyChanged(); } }

        private string _textForTime;
        public string TextForDate { get { return _textForTime; } set { _textForTime = value; OnPropertyChanged(); } }

        public string ButtonSaveText { get; set; }
        public DelegateCommand ToLeftDiagCommand { get; protected set; }
        public DelegateCommand ToRightDiagCommand { get; protected set; }
        public DelegateCommand ToLeftOprCommand { get; protected set; }
        public DelegateCommand ToRightOprCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }

        public Patient CurrentPatient { get; set; }
        public string initials { get; set; }
        #endregion

        private int _selectedLegId;

        public int SelectedLegId
        {
            get
            {

                return _selectedLegId;

            }
            set { _selectedLegId = value; OnPropertyChanged(); }
        }
        #region MessageBus
        bool isSetOperResult = false;


        private void AddOperationTypeForDialogBox(object sender, object data)
        {
            Data.OperationType.Add(data as OperationType);
            Data.Complete();
        }


        private void SetRightDiagnosisList(object sender, object data)
        {
            var RightDiagnosisList1 = new ObservableCollection<DiagnosisDataSource>();
            foreach (var diag in (List<DiagnosisDataSource>)data)
            { RightDiagnosisList1.Add(diag); }
            RightDiagnosisList.Source = RightDiagnosisList1;
            RightDiagnosisList.View.Refresh();
            Controller.NavigateTo<ViewModelAddOperation>();
        }
        private void SetLeftDiagnosisList(object sender, object data)
        {
            var LeftDiagnosisList1 = new ObservableCollection<DiagnosisDataSource>();
            foreach (var diag in (List<DiagnosisDataSource>)data)
            { LeftDiagnosisList1.Add(diag); }
            LeftDiagnosisList.Source = LeftDiagnosisList1;
            LeftDiagnosisList.View.Refresh();
            Controller.NavigateTo<ViewModelAddOperation>();
        }


        private void SetRightOpList(object sender, object data)
        {
            var RightDiagnosisList1 = new ObservableCollection<OperationTypesDataSource>();
            foreach (var diag in (List<OperationTypesDataSource>)data)
            { RightDiagnosisList1.Add(diag); }
            RightOperationList.Source = RightDiagnosisList1;
            RightOperationList.View.Refresh();
            Controller.NavigateTo<ViewModelAddOperation>();
        }
        private void SetLeftOpList(object sender, object data)
        {
            var LeftDiagnosisList1 = new ObservableCollection<OperationTypesDataSource>();
            foreach (var diag in (List<OperationTypesDataSource>)data)
            { LeftDiagnosisList1.Add(diag); }
            LeftOperationList.Source = LeftDiagnosisList1;
            LeftOperationList.View.Refresh();
            Controller.NavigateTo<ViewModelAddOperation>();
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
            ShowDoctorsSelected = ShowDoctorsSelected;
            ShowMedsSelected = ShowMedsSelected;
        }
        private void SetCurrentPatientID(object sender, object data)
        {
            CurrentPanelSelectTime.SelectedOpTimeView = null;
            CurrentPanelSelectTime.SelectedOpTimeViewCopy = null;
            CurrentPanelSelectTime.BuffSelectedOpTimeView = null;
            Button_time_B = Brushes.Gray;
            CurrentPanelViewModel.PanelOpened = true;

            TextForDate = "Время не выбрано";
            using (var context = new MySqlContext())
            {
                LeftDiagnosisList = new CollectionViewSource();

                RightDiagnosisList = new CollectionViewSource();

                LeftOperationList = new CollectionViewSource();

                RightOperationList = new CollectionViewSource();


                MessageBus.Default.Call("SetClearDiagnosisListLeftRightOperation", null, null);
                MessageBus.Default.Call("SetClearOperationListLeftRightOperation", null, null);

                MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);
                DoctorRepository DoctorRep = new DoctorRepository(context);
                Operation = new Operation();
                // Operation.Date = DateTime.Now;
                CurrentPatient = Data.Patients.Get((int)data);
                initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

                OprTypes = new ObservableCollection<string>();
                AnestethicTypes = new ObservableCollection<string>();
                Doctors = new ObservableCollection<DoctorDataSource>();
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
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
        public ViewModelAddOperation(NavigationController controller) : base(controller)
        {
            Doctors = new ObservableCollection<DoctorDataSource>();
            DoctorsSelected = new ObservableCollection<DoctorDataSource>();

            ShowDoctors = true;

            ShowMeds = true;
            ShowMedsSelected = true;
            ShowDoctorsSelected = true;
            TextBoxMinute = Brushes.Gray;
            TextBoxHour = Brushes.Gray;
            MinuteHour = DateTime.Now;
            TimeCheckHour = true;
            TimeCheckMinute = true;
            ButtonSaveText = "Назначить операцию";


            MessageBus.Default.Subscribe("AddOperationTypeForDialogBox", AddOperationTypeForDialogBox);
            MessageBus.Default.Subscribe("SetOperationResult", SetOperResult);
            MessageBus.Default.Subscribe("SetCurrentPatientForOperation", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetRightDiagnosisListForOperation", SetRightDiagnosisList);
            MessageBus.Default.Subscribe("SetLeftDiagnosisListForOperation", SetLeftDiagnosisList);
            MessageBus.Default.Subscribe("UpdateSelectedDoctors", UpdateSelectedDoctors);

            MessageBus.Default.Subscribe("SetRightOperationListForOperation", SetRightOpList);
            MessageBus.Default.Subscribe("SetLeftOperationListForOperation", SetLeftOpList);




            Controller = controller;
            HasNavigation = false;
            Operation = new Operation();
            // Operation.Date = DateTime.Now;
            LeftDiagnosisList = new CollectionViewSource();
            RightDiagnosisList = new CollectionViewSource();
            LeftOperationList = new CollectionViewSource();
            RightOperationList = new CollectionViewSource();




            using (var context = new MySqlContext())
            {
                var timeItem = Data.OperationDateTime.GetAll.Where(e => e.Operation_id == 0);
                foreach (var OpTImeWithNULL in timeItem)
                {
                    if (Data.OperationDateTime.GetAll.Where(e => e.Operation_id != null && e.Operation_id != 0 && e.Datetime.Year == OpTImeWithNULL.Datetime.Year && e.Datetime.Month == OpTImeWithNULL.Datetime.Month && e.Datetime.Day == OpTImeWithNULL.Datetime.Day).FirstOrDefault() == null)
                    {
                        foreach (var opDate in Data.OperationDateTime.GetAll.Where(e => e.Datetime.Year == OpTImeWithNULL.Datetime.Year && e.Datetime.Month == OpTImeWithNULL.Datetime.Month && e.Datetime.Day == OpTImeWithNULL.Datetime.Day))
                        {
                            Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate.Id));
                        }
                    }
                    else
                    {
                        var opDate1 = Data.OperationDateTime.Get(OpTImeWithNULL.Id);
                        opDate1.Doctor_id = null;
                        opDate1.Note = "Время свободно";
                        opDate1.Operation_id = null;
                        Data.Complete();
                    }
                }
                Data.Complete();
            }




            GetLeftFromLastObs = new DelegateCommand(
                () =>
                {
                    using (var context = new MySqlContext())
                    {
                        DiagnosisObsRepository DiagObsRep = new DiagnosisObsRepository(context);
                        ExaminationRepository ExamRep = new ExaminationRepository(context);
                        var ExamsOfCurrPatient = ExamRep.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                        if (ExamsOfCurrPatient.Count > 0)
                        {
                            DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                            var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                            List<DiagnosisObs> DiagOfCurrPatienLt = DiagObsRep.GetAll.ToList().Where(s => s.id_leg_examination == ExamsOfCurrPatientLatest[0].Id && s.isLeft == true).ToList();
                            //  List<DiagnosisObs> DiagOfCurrPatientRt = DiagObsRep.GetAll.ToList().Where(s => s.id_обследование_ноги == ExamsOfCurrPatientLatest[0].Id && s.isLeft == false).ToList();

                            //   MessageBus.Default.Call("SetDiagnosisListRight", null, DiagOfCurrPatientRt);
                            MessageBus.Default.Call("SetDiagnosisListLeft", null, DiagOfCurrPatienLt);


                            // ExaminationLeg leftLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                            // ExaminationLeg rightLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);

                            // Letters bufLetter = new Letters();
                            Controller.NavigateTo<ViewModelAddOperation>();

                        }
                        else
                        {
                            MessageBox.Show("Нет диагноза слева последнего обследования");
                        }

                    }
                }
            );
            GetRightFromLastObs = new DelegateCommand(
                () =>
                {
                    using (var context = new MySqlContext())
                    {
                        DiagnosisObsRepository DiagObsRep = new DiagnosisObsRepository(context);
                        ExaminationRepository ExamRep = new ExaminationRepository(context);
                        var ExamsOfCurrPatient = ExamRep.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                        if (ExamsOfCurrPatient.Count > 0)
                        {
                            DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                            var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                            //  List<DiagnosisObs> DiagOfCurrPatienLt = DiagObsRep.GetAll.ToList().Where(s => s.id_обследование_ноги == ExamsOfCurrPatientLatest[0].Id && s.isLeft == true).ToList();
                            List<DiagnosisObs> DiagOfCurrPatientRt = DiagObsRep.GetAll.ToList().Where(s => s.id_leg_examination == ExamsOfCurrPatientLatest[0].Id && s.isLeft == false).ToList();

                            MessageBus.Default.Call("SetDiagnosisListRight", null, DiagOfCurrPatientRt);
                            // MessageBus.Default.Call("SetDiagnosisListLeft", null, DiagOfCurrPatienLt);


                            // ExaminationLeg leftLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                            // ExaminationLeg rightLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);

                            // Letters bufLetter = new Letters();
                            Controller.NavigateTo<ViewModelAddOperation>();

                        }
                        else
                        {
                            MessageBox.Show("Нет диагноза справа последнего обследования");
                        }
                    }
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    if (Operation.Datetime_id != null && Operation.Datetime_id != 0)
                    {
                        var OpDate = Data.OperationDateTime.Get(Operation.Datetime_id.Value);
                        OpDate.Doctor_id = null;
                        OpDate.Note = "Время свободно";
                        OpDate.Operation_id = null;
                        Data.Complete();
                        using (var context = new MySqlContext())
                        {
                            var timeItem1 = context.Set<OperationDateTime>().Where(e => e.Operation_id != null && e.Datetime.Year == OpDate.Datetime.Year && e.Datetime.Month == OpDate.Datetime.Month && e.Datetime.Day == OpDate.Datetime.Day).FirstOrDefault();
                            if (timeItem1 == null)
                            {
                                foreach (var opDate in context.Set<OperationDateTime>().Where(e => e.Datetime.Year == OpDate.Datetime.Year && e.Datetime.Month == OpDate.Datetime.Month && e.Datetime.Day == OpDate.Datetime.Day))
                                {
                                    Data.OperationDateTime.Remove(Data.OperationDateTime.Get(opDate.Id));
                                }
                            }
                            Data.Complete();
                        }

                        CurrentPanelSelectTime.SelectedOpTimeView = null;
                        CurrentPanelSelectTime.SelectedOpTimeViewCopy = null;
                        CurrentPanelSelectTime.BuffSelectedOpTimeView = null;
                    }
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    bool test = false;
                    if (SelectedLegId == 0)
                    {
                        //  ObservableCollection<OperationTypesDataSource> aray = (ObservableCollection<OperationTypesDataSource>)LeftOperationList.Source;
                        if (LeftOperationList.Source == null ||
                        ((ObservableCollection<OperationTypesDataSource>)LeftOperationList.Source).Count == 0 ||
                        ((ObservableCollection<DiagnosisDataSource>)LeftDiagnosisList.Source).Count == 0 ||
                        LeftDiagnosisList.Source == null || RightDiagnosisList.Source == null ||
                        ((ObservableCollection<DiagnosisDataSource>)RightDiagnosisList.Source).Count == 0 ||
                        ((ObservableCollection<DiagnosisDataSource>)LeftDiagnosisList.Source).Count == 0 ||
                        DoctorsSelected.Count == 0 || TimeCheckHour == false || TimeCheckMinute == false || Operation.Datetime_id == null)
                        {
                            MessageBox.Show("Не всё заполнено!");
                            if (Operation.Datetime_id == null)
                            {
                                Button_time_B = Brushes.Red;
                            }
                            else
                            {
                                Button_time_B = Brushes.Gray;
                            }
                        }
                        else
                        {
                            test = true;
                        }
                    }
                    else if (SelectedLegId == 1)
                    {

                        if (RightOperationList.Source == null || ((ObservableCollection<OperationTypesDataSource>)RightOperationList.Source).Count == 0 || RightDiagnosisList.Source == null || ((ObservableCollection<DiagnosisDataSource>)RightDiagnosisList.Source).Count == 0 || ((ObservableCollection<DiagnosisDataSource>)LeftDiagnosisList.Source).Count == 0 || DoctorsSelected.Count == 0 || TimeCheckHour == false || TimeCheckMinute == false || Operation.Datetime_id == null)
                        {
                            MessageBox.Show("Не всё заполнено!");
                        }
                        else
                        {
                            test = true;
                        }

                    }
                    else if (RightOperationList.Source == null || ((ObservableCollection<OperationTypesDataSource>)RightOperationList.Source).Count == 0 || LeftOperationList.Source == null || ((ObservableCollection<OperationTypesDataSource>)LeftOperationList.Source).Count == 0 || LeftDiagnosisList.Source == null || RightDiagnosisList.Source == null || ((ObservableCollection<DiagnosisDataSource>)LeftDiagnosisList.Source).Count == 0 || ((ObservableCollection<DiagnosisDataSource>)RightDiagnosisList.Source).Count == 0 || DoctorsSelected.Count == 0 || TimeCheckHour == false || TimeCheckMinute == false || Operation.Datetime_id == null)
                    {
                        MessageBox.Show("Не всё заполнено!");
                    }
                    else
                    {
                        test = true;

                    }
                    if (test)
                    {

                        // Operation.Date = new DateTime(Operation.Date.Year,// Operation.Date.Month,// Operation.Date.Day, MinuteHour.Hour, MinuteHour.Minute, 0);
                        // Operation.Time = MinuteHour.Hour + ":" + MinuteHour.Minute + ":" + 0;
                        var opDate = Data.OperationDateTime.Get(Operation.Datetime_id.Value);

                        Operation.PatientId = CurrentPatient.Id;
                        Operation.AnestheticId = AnestethicTypesID[AnesteticSelected];
                        Operation.OnWhatLegOp = SelectedLegId.ToString();
                        Data.Operation.Add(Operation);
                        Data.Complete();
                        opDate.Operation_id = Operation.Id;

                        using (var context = new MySqlContext())
                        {

                            //    var opDataToRemove = new OperationDateTime();
                            //    var test = true;
                            //    var OperationRep = new OperationRepository(context);
                            var OperationDateTimeRep = new OperationDateTimeRepository(context);
                            var SelectedOpDate = OperationDateTimeRep.Get(Operation.Datetime_id.Value);
                            opDate.Doctor_id = SelectedOpDate.Doctor_id;
                            opDate.Note = SelectedOpDate.Note;
                        }


                        foreach (var Doctor in DoctorsSelected)
                        {
                            if (Doctor.isDoctor)
                            {
                                Brigade buf = new Brigade();
                                buf.id_doctor = Doctor.id;
                                buf.id_operation = Operation.Id;
                                Data.Brigade.Add(buf);
                                Data.Complete();
                            }
                            else
                            {
                                BrigadeMedPersonal buf = new BrigadeMedPersonal();
                                buf.id_med_staff = Doctor.id;
                                buf.id_operation = Operation.Id;
                                Data.BrigadeMedPersonal.Add(buf);
                                Data.Complete();
                            }

                        }


                        if (LeftOperationList.Source != null)
                        {
                            foreach (var OpL in (ObservableCollection<OperationTypesDataSource>)LeftOperationList.Source)
                            {

                                OperationTypeOperations buf = new OperationTypeOperations();
                                buf.id_operation_type = OpL.Data.Id;
                                buf.id_operation = Operation.Id;
                                buf.isLeft = true;

                                Data.OperationTypeOperations.Add(buf);
                                Data.Complete();
                            }
                        }
                        if (RightOperationList.Source != null)
                        {
                            foreach (var OpR in (ObservableCollection<OperationTypesDataSource>)RightOperationList.Source)
                            {

                                OperationTypeOperations buf = new OperationTypeOperations();
                                buf.id_operation_type = OpR.Data.Id;
                                buf.id_operation = Operation.Id;
                                buf.isLeft = false;

                                Data.OperationTypeOperations.Add(buf);
                                Data.Complete();
                            }
                        }

                        if (LeftDiagnosisList.Source != null)
                        {
                            foreach (var diagnozL in (ObservableCollection<DiagnosisDataSource>)LeftDiagnosisList.Source)
                            {

                                Diagnosis buf = new Diagnosis();
                                buf.id_diagnosis = diagnozL.Data.Id;
                                buf.id_operation = Operation.Id;
                                buf.isLeft = true;

                                Data.Diagnosis.Add(buf);
                                Data.Complete();
                            }
                        }








                        if (RightDiagnosisList.Source != null)
                        {

                            foreach (var diagnozR in (ObservableCollection<DiagnosisDataSource>)RightDiagnosisList.Source)
                            {

                                Diagnosis buf = new Diagnosis();
                                buf.id_diagnosis = diagnozR.Data.Id;
                                buf.id_operation = Operation.Id;
                                buf.isLeft = false;

                                Data.Diagnosis.Add(buf);
                                Data.Complete();

                            }
                        }

                        //       Data.Complete();
                        if (isSetOperResult == true)
                        {
                            OperationResult.IdNextOperation = Operation.Id;
                            Data.Complete();
                            isSetOperResult = false;
                        }

                        CurrentPanelSelectTime.SelectedOpTimeView = null;
                        CurrentPanelSelectTime.SelectedOpTimeViewCopy = null;
                        CurrentPanelSelectTime.BuffSelectedOpTimeView = null;

                        MessageBus.Default.Call("SetCurrentACCOp", this, null);
                        MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);

                        Controller.NavigateTo<ViewModelOperationOverview>();
                        //    Data.Complete();
                        Operation = new Operation();
                        OperationResult = new OperationResult();
                    }
                }
            );
            IsLeftLegInOperation = Visibility.Visible;
            IsRightLegInOperation = Visibility.Visible;
            ToLeftOprCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetleftOrRightOpForOp", this, "Left");
                    Controller.NavigateTo<ViewModelOperationListForOperation>();
                }
            );
            ToRightOprCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetleftOrRightOpForOp", this, "Right");
                    Controller.NavigateTo<ViewModelOperationListForOperation>();
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
            #region Select time comands
            CurrentPanelSelectTime = new SelectTimePanelViewModel(this);
            OpenPanelSelectTime = new DelegateCommand(() =>
            {
                CurrentPanelSelectTime.ClearPanel();
                CurrentPanelSelectTime.PanelOpened = true;
            });
            RevertSelectTimeCommand = new DelegateCommand(() =>
            {
                CurrentPanelSelectTime.PanelOpened = false;
                Handled = false;
                //if (Operation.Datetime_id == null || Operation.Datetime_id == 0)
                //{
                CurrentPanelSelectTime.SelectedOpTimeView = null;
                CurrentPanelSelectTime.SelectedOpTimeViewCopy = null;
                CurrentPanelSelectTime.BuffSelectedOpTimeView = null;
                //}
            });
            TextForDate = "Время не выбрано";
            SaveSelectTimeCommand = new DelegateCommand(() =>
            {
                if (CurrentPanelSelectTime.SelectedOpTimeView != null)
                {
                    Button_time_B = Brushes.Gray;
                    Operation.Datetime_id = CurrentPanelSelectTime.SelectedOpTimeView.Id;

                    TextForDate = CurrentPanelSelectTime.SelectedOpTimeView.Datetime.ToString("HH:mm\ndd MMMM yyyy\n", CultureInfo.GetCultureInfo("ru-ru"));
                    string buff = FirstCharToUpper(CurrentPanelSelectTime.SelectedOpTimeView.Datetime.ToString("dddd", CultureInfo.GetCultureInfo("ru-ru")));
                    //buff = buff.First().ToString().ToUpper() + buff.Substring(1);
                    TextForDate += buff;
                }
                else
                {
                    Operation.Datetime_id = null;
                    TextForDate = "Время не выбрано";
                }
                CurrentPanelSelectTime.PanelOpened = false;
            });
            #endregion
            #region Anestetic New type comands
            CurrentPanelAnestViewModel = new AnetheticTypePanelViewModel(this);
            OpenPanelAnesteticCommand = new DelegateCommand(() =>
            {
                CurrentPanelAnestViewModel.ClearPanel();
                CurrentPanelAnestViewModel.PanelOpened = true;
            });
            SaveAnesteticCommand = new DelegateCommand(() =>
            {
                var newType = CurrentPanelAnestViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentPanelAnestViewModel.PanelOpened = false;
                    Handled = false;
                    Data.Anestethic.Add((newType));
                    Data.Complete();
                    AnestethicTypes = new ObservableCollection<string>();
                    foreach (var OprType in Data.Anestethic.GetAll)
                    {
                        AnestethicTypes.Add(OprType.Str);
                        AnestethicTypesID.Add(OprType.Id);
                    }
                    AnesteticSelected = AnestethicTypes.Count - 1;
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertAnesteticCommand = new DelegateCommand(() =>
            {
                CurrentPanelAnestViewModel.PanelOpened = false;
                Handled = false;
            });
            #endregion
            SaveCommand = new DelegateCommand(() =>
            {

                if (SelectedLegId == 0)
                {
                    IsLeftLegInOperation = Visibility.Visible;
                    IsRightLegInOperation = Visibility.Collapsed;
                }
                else if (SelectedLegId == 1)
                {
                    IsLeftLegInOperation = Visibility.Collapsed;
                    IsRightLegInOperation = Visibility.Visible;
                }
                else
                {
                    IsLeftLegInOperation = Visibility.Visible;
                    IsRightLegInOperation = Visibility.Visible;

                }
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = false;

            });

            RevertCommand = new DelegateCommand(() =>
            {
                Controller.NavigateTo<ViewModelCurrentPatient>();
            });
        }
    }
}
