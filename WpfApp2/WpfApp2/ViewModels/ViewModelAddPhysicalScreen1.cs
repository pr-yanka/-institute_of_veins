using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;
using System.Windows.Input;
using WpfApp2.DialogPreOperation;
using WpfApp2.DialogService;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.Messaging;
using WpfApp2.Db.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.SPS;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddPhysical : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        #region TEMPV binds

        private ObservableCollection<Visibility> _isVisibleTEMPVleft;
        public ObservableCollection<Visibility> IsVisibleTEMPVleft
        {
            get
            {
                return _isVisibleTEMPVleft;
            }
            set
            {
                _isVisibleTEMPVleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleTEMPVRight;
        public ObservableCollection<Visibility> IsVisibleTEMPVRight
        {
            get
            {
                return _isVisibleTEMPVRight;
            }
            set
            {
                _isVisibleTEMPVRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> TEMPVLeftstr
        {
            get
            {
                return _TEMPVLeftstr;
            }
            set
            {
                _TEMPVLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> TEMPVRightstr
        {
            get
            {
                return _TEMPVRightstr;
            }
            set
            {
                _TEMPVRightstr = value;
                OnPropertyChanged();
            }
        }
        public TEMPVEntryFull RightTEMPVEntryFull { get; private set; }
        public TEMPVEntryFull LeftTEMPVEntryFull { get; private set; }

        private List<string> _TEMPVRightstr;
        private List<string> _TEMPVLeftstr;

        #endregion

        #region MPV binds

        private ObservableCollection<Visibility> _isVisibleMPVleft;
        public ObservableCollection<Visibility> IsVisibleMPVleft
        {
            get
            {
                return _isVisibleMPVleft;
            }
            set
            {
                _isVisibleMPVleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleMPVRight;
        public ObservableCollection<Visibility> IsVisibleMPVRight
        {
            get
            {
                return _isVisibleMPVRight;
            }
            set
            {
                _isVisibleMPVRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> MPVLeftstr
        {
            get
            {
                return _MPVLeftstr;
            }
            set
            {
                _MPVLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> MPVRightstr
        {
            get
            {
                return _MPVRightstr;
            }
            set
            {
                _MPVRightstr = value;
                OnPropertyChanged();
            }
        }
        public MPVEntryFull RightMPVEntryFull { get; private set; }
        public MPVEntryFull LeftMPVEntryFull { get; private set; }

        private List<string> _MPVRightstr;
        private List<string> _MPVLeftstr;

        #endregion

        #region Perforate_shin binds

        private ObservableCollection<Visibility> _isVisiblePerforate_shinleft;
        public ObservableCollection<Visibility> IsVisiblePerforate_shinleft
        {
            get
            {
                return _isVisiblePerforate_shinleft;
            }
            set
            {
                _isVisiblePerforate_shinleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisiblePerforate_shinRight;
        public ObservableCollection<Visibility> IsVisiblePerforate_shinRight
        {
            get
            {
                return _isVisiblePerforate_shinRight;
            }
            set
            {
                _isVisiblePerforate_shinRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> Perforate_shinLeftstr
        {
            get
            {
                return _Perforate_shinLeftstr;
            }
            set
            {
                _Perforate_shinLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> Perforate_shinRightstr
        {
            get
            {
                return _Perforate_shinRightstr;
            }
            set
            {
                _Perforate_shinRightstr = value;
                OnPropertyChanged();
            }
        }
        public Perforate_shinEntryFull RightPerforate_shinEntryFull { get; private set; }
        public Perforate_shinEntryFull LeftPerforate_shinEntryFull { get; private set; }

        private List<string> _Perforate_shinRightstr;
        private List<string> _Perforate_shinLeftstr;

        #endregion

        #region BPV_Tibia binds
        public BPV_TibiaEntryFull RightBPV_TibiaEntryFull { get; private set; }
        public BPV_TibiaEntryFull LeftBPV_TibiaEntryFull { get; private set; }
        private List<string> _BPV_TibiaRightstr;
        private List<string> _BPV_TibiaLeftstr;
        public List<string> BPV_TibiaLeftstr
        {
            get
            {
                return _BPV_TibiaLeftstr;
            }
            set
            {
                _BPV_TibiaLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> BPV_TibiaRightstr
        {
            get
            {
                return _BPV_TibiaRightstr;
            }
            set
            {
                _BPV_TibiaRightstr = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleBPV_Tibialeft;
        private ObservableCollection<Visibility> _isVisibleBPV_Tibiaright;

        public ObservableCollection<Visibility> IsVisibleBPV_Tibiaright
        {
            get
            {
                return _isVisibleBPV_Tibiaright;
            }
            set
            {
                _isVisibleBPV_Tibiaright = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Visibility> IsVisibleBPV_Tibialeft
        {
            get
            {
                return _isVisibleBPV_Tibialeft;
            }
            set
            {
                _isVisibleBPV_Tibialeft = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region SPS binds

        private ObservableCollection<Visibility> _isVisibleSPSleft;
        public ObservableCollection<Visibility> IsVisibleSPSleft
        {
            get
            {
                return _isVisibleSPSleft;
            }
            set
            {
                _isVisibleSPSleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleSPSRight;
        public ObservableCollection<Visibility> IsVisibleSPSRight
        {
            get
            {
                return _isVisibleSPSRight;
            }
            set
            {
                _isVisibleSPSRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> SPSLeftstr
        {
            get
            {
                return _SPSLeftstr;
            }
            set
            {
                _SPSLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> SPSRightstr
        {
            get
            {
                return _SPSRightstr;
            }
            set
            {
                _SPSRightstr = value;
                OnPropertyChanged();
            }
        }
        public SPSHipEntryFull RightSPSEntryFull { get; private set; }
        public SPSHipEntryFull LeftSPSEntryFull { get; private set; }

        private List<string> _SPSRightstr;
        private List<string> _SPSLeftstr;

        #endregion

        #region SFS binds

        private ObservableCollection<Visibility> _isVisibleSFSleft;
        public ObservableCollection<Visibility> IsVisibleSFSleft
        {
            get
            {
                return _isVisibleSFSleft;
            }
            set
            {
                _isVisibleSFSleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleSFSRight;
        public ObservableCollection<Visibility> IsVisibleSFSRight
        {
            get
            {
                return _isVisibleSFSRight;
            }
            set
            {
                _isVisibleSFSRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> SFSLeftstr
        {
            get
            {
                return _sfsLeftstr;
            }
            set
            {
                _sfsLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> SFSRightstr
        {
            get
            {
                return _sfsRightstr;
            }
            set
            {
                _sfsRightstr = value;
                OnPropertyChanged();
            }
        }
        public SFSHipEntryFull RightSFSEntryFull { get; private set; }
        public SFSHipEntryFull LeftSFSEntryFull { get; private set; }

        private List<string> _sfsRightstr;
        private List<string> _sfsLeftstr;

        #endregion

        #region PDsV binds
        public PDSVHipEntryFull RightPDSVEntryFull { get; private set; }
        public PDSVHipEntryFull LeftPDSVEntryFull { get; private set; }
        private List<string> _pdsvRightstr;
        private List<string> _pdsvLeftstr;
        public List<string> PDSVLeftstr
        {
            get
            {
                return _pdsvLeftstr;
            }
            set
            {
                _pdsvLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> PDSVRightstr
        {
            get
            {
                return _pdsvRightstr;
            }
            set
            {
                _pdsvRightstr = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisiblePDSVleft;
        private ObservableCollection<Visibility> _isVisiblePDSVright;

        public ObservableCollection<Visibility> IsVisiblePDSVright
        {
            get
            {
                return _isVisiblePDSVright;
            }
            set
            {
                _isVisiblePDSVright = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Visibility> IsVisiblePDSVleft
        {
            get
            {
                return _isVisiblePDSVleft;
            }
            set
            {
                _isVisiblePDSVleft = value;
                OnPropertyChanged();
            }
        }

        #endregion
        #region ZDSV binds

        private ObservableCollection<Visibility> _isVisibleZDSVright;
        public ObservableCollection<Visibility> IsVisibleZDSVright
        {
            get
            {
                return _isVisibleZDSVright;
            }
            set
            {
                _isVisibleZDSVright = value;
                OnPropertyChanged();
            }
        }

        public ZDSVEntryFull RightZDSVEntryFull { get; private set; }
        public ZDSVEntryFull LeftZDSVEntryFull { get; private set; }
        private List<string> _ZDSVRightstr;
        private List<string> _ZDSVLeftstr;
        public List<string> ZDSVLeftstr
        {
            get
            {
                return _ZDSVLeftstr;
            }
            set
            {
                _ZDSVLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> ZDSVRightstr
        {
            get
            {
                return _ZDSVRightstr;
            }
            set
            {
                _ZDSVRightstr = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Visibility> _isVisibleZDSVleft;
        public ObservableCollection<Visibility> IsVisibleZDSVleft
        {
            get
            {
                return _isVisibleZDSVleft;
            }
            set
            {
                _isVisibleZDSVleft = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region PerforateHIp binds

        private ObservableCollection<Visibility> _isVisiblePerforateHIPright;
        public ObservableCollection<Visibility> IsVisiblePerforateHIPright
        {
            get
            {
                return _isVisiblePerforateHIPright;
            }
            set
            {
                _isVisiblePerforateHIPright = value;
                OnPropertyChanged();
            }
        }

        public Perforate_hipEntryFull RightPerforate_hipEntryFull { get; private set; }
        public Perforate_hipEntryFull LeftPerforate_hipEntryFull { get; private set; }
        private List<string> _Perforate_hipRightstr;
        private List<string> _Perforate_hipLeftstr;
        public List<string> Perforate_hipLeftstr
        {
            get
            {
                return _Perforate_hipLeftstr;
            }
            set
            {
                _Perforate_hipLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> Perforate_hipRightstr
        {
            get
            {
                return _Perforate_hipRightstr;
            }
            set
            {
                _Perforate_hipRightstr = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Visibility> _isVisiblePerforateHIPleft;
        public ObservableCollection<Visibility> IsVisiblePerforateHIPleft
        {
            get
            {
                return _isVisiblePerforateHIPleft;
            }
            set
            {
                _isVisiblePerforateHIPleft = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Bpv binds
        public BPVHipEntryFull LeftBPVEntryFull { get; protected set; }
        public BPVHipEntryFull RightBPVEntryFull { get; protected set; }
        public List<string> BpvLeftstr
        {
            get
            {
                return _bpvLeftstr;
            }
            set
            {
                _bpvLeftstr = value;
                OnPropertyChanged();
            }
        }
        private List<string> _bpvLeftstr;
        private ObservableCollection<Visibility> _isVisibleBPVleft;
        public ObservableCollection<Visibility> IsVisibleBPVleft
        {
            get
            {
                return _isVisibleBPVleft;
            }
            set
            {
                _isVisibleBPVleft = value;
                OnPropertyChanged();
            }
        }
        public List<string> BpvRightstr
        {
            get
            {
                return _bpvRightstr;
            }
            set
            {
                _bpvRightstr = value;
                OnPropertyChanged();
            }
        }

        private List<string> _bpvRightstr;







        private ObservableCollection<Visibility> _isVisibleBPVRight;
        public ObservableCollection<Visibility> IsVisibleBPVRight
        {
            get
            {
                return _isVisibleBPVRight;
            }
            set
            {
                _isVisibleBPVRight = value;
                OnPropertyChanged();
            }
        }
        #endregion


        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                float buf = 0f;
                if (value.Contains(",")) { _weight = value; }
                else if (value == "")
                { _weight = ""; }
                else if (float.TryParse(value, out buf)) { _weight = buf.ToString(); }

                if (float.TryParse(Weight, out buf) && float.TryParse(Growth, out buf)) ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100)); OnPropertyChanged();
            }
        }

        private string _growth;
        public string Growth
        {
            get { return _growth; }
            set
            {
                float buf = 0f;
                if (value.Contains(",")) { _growth = value; } else if (value == "") { _growth = ""; } else if (float.TryParse(value, out buf)) { _growth = buf.ToString(); }
                if (float.TryParse(Weight, out buf) && float.TryParse(Growth, out buf)) ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100)); OnPropertyChanged();
            }
        }

        private double _itm;
        public double ITM { get { return Math.Round(_itm, 3); } set { if (float.Parse(Growth) != 0) _itm = value; OnPropertyChanged(); } }

        private string _textTip;
        public string TextTip { get { return _textTip; } set { _textTip = value; OnPropertyChanged(); } }
        public DelegateCommand IMTCOUNT { get; protected set; }
        public DelegateCommand ClickOnTextTip { get; protected set; }

        public DelegateCommand ClickOnWeight { get; protected set; }
        public DelegateCommand ClickOnGrowth { get; protected set; }

        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToSymptomsAddCommand { get; protected set; }

        public DelegateCommand ToRightBPVHipCommand { get; protected set; }
        public DelegateCommand ToLeftBPVHipCommand { get; protected set; }


        public DelegateCommand ToLeftMPVCommand { get; protected set; }
        public DelegateCommand ToRightMPVCommand { get; protected set; }

        public DelegateCommand ToLeftTEMPVCommand { get; protected set; }
        public DelegateCommand ToRightTEMPVCommand { get; protected set; }

        public DelegateCommand ToLeftPDSVCommand { get; protected set; }
        public DelegateCommand ToLeftZDSVCommand { get; protected set; }
        public DelegateCommand ToLeftPerforateCommand { get; protected set; }

        public DelegateCommand ToLeftTibiaPerforateCommand { get; protected set; }
        public DelegateCommand ToLeftBPVTibiaCommand { get; protected set; }
        public DelegateCommand ToLeftSPSCommand { get; protected set; }

        public DelegateCommand ToRightSFSCommand { get; protected set; }
        public DelegateCommand ToLeftSFSCommand { get; protected set; }

        public DelegateCommand ToRightPDSVCommand { get; protected set; }
        public DelegateCommand ToRightZDSVCommand { get; protected set; }
      
        public DelegateCommand ToRightPerforateCommand { get; protected set; }
        public DelegateCommand ToLeftDiagCommand { get; protected set; }
        public DelegateCommand ToRightDiagCommand { get; protected set; }
        public DelegateCommand ToRightTibiaPerforateCommand { get; protected set; }
        public DelegateCommand ToRightBPVTibiaCommand { get; protected set; }
        public DelegateCommand ToRightSPSCommand { get; protected set; }

        public DelegateCommand ToAddRecomendationsCommand { get; protected set; }

        public DelegateCommand ToDiagnosisCommand { get; protected set; }

        public Patient CurrentPatient { get; protected set; }
        public string initials { get; protected set; }

        public List<ComplainsDataSource> ComplainsList { get; set; }
        public List<RecomendationsDataSource> RecomendationsList { get; set; }
        public List<DiagnosisDataSource> DiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> LeftDiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> RightDiagnosisList { get; set; }

        private void SetComplainsList(object sender, object data)
        {
            ComplainsList = (List<ComplainsDataSource>)data;
        }
        private void SetRecomendationsList(object sender, object data)
        {
            RecomendationsList = (List<RecomendationsDataSource>)data;
        }
        private void SetDiagnosisList(object sender, object data)
        {
            DiagnosisList = (List<DiagnosisDataSource>)data;
        }

        private void SetCurrentPatientID(object sender, object data)
        {
            Weight = "0";
            Growth = "0";
            TextTip = "Текст пометки";
            CurrentPatient = Data.Patients.Get((int)data);
            initials = " " + CurrentPatient.Sirname.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

        }

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }




        public BPVHipViewModel LeftBPVHip { get; protected set; }
        public SFSViewModel LeftSFS { get; protected set; }
        public PDSVViewModel LeftPDSV { get; protected set; }
        public ZDSVViewModel LeftZDSV { get; protected set; }
        public HipPerforateViewModel LeftPerforate { get; protected set; }
        public TibiaPerforateViewModel LeftTibiaPerforate { get; protected set; }
        public BPVTibiaViewModel LeftBPVTibia { get; protected set; }
        public SPSViewModel LeftSPS { get; protected set; }
        public MPVViewModel LeftMPV { get; protected set; }
        public MPVViewModel RightMPV { get; protected set; }

        public TEMPVViewModel LeftTEMPV { get; protected set; }
        public TEMPVViewModel RightTEMPV { get; protected set; }

        public BPVHipViewModel RightBPVHip { get; protected set; }
        public SFSViewModel RightSFS { get; protected set; }

        public PDSVViewModel RightPDSV { get; protected set; }
        public ZDSVViewModel RightZDSV { get; protected set; }
        public HipPerforateViewModel RightPerforate { get; protected set; }
        public TibiaPerforateViewModel RightTibiaPerforate { get; protected set; }
        public BPVTibiaViewModel RightBPVTibia { get; protected set; }
        public SPSViewModel RightSPS { get; protected set; }

        private void FinishAdding(object parameter)
        {

            DialogViewModelBase vm =
                new DialogYesNo.DialogYesNoViewModel("Назначить операцию?");
            DialogResult result =
                DialogService.DialogService.OpenDialog(vm, parameter as Window);

            if (result == DialogResult.Yes)
            {
                vm = new DialogPreOperationViewModel();
                result = DialogService.DialogService.OpenDialog(vm, parameter as Window);
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
        public ViewModelAddPhysical(NavigationController controller) : base(controller)
        {
            MPVLeftstr = new List<string>();
            MPVRightstr = new List<string>();
            TEMPVLeftstr = new List<string>();
            TEMPVRightstr = new List<string>();

            Perforate_shinLeftstr = new List<string>();
            Perforate_shinRightstr = new List<string>();
            SPSLeftstr = new List<string>();
            SPSRightstr = new List<string>();

            PDSVLeftstr = new List<string>();
            PDSVRightstr = new List<string>();
            BpvLeftstr = new List<string>();
            BpvRightstr = new List<string>();
            SFSLeftstr = new List<string>();
            SFSRightstr = new List<string>();

            ZDSVLeftstr = new List<string>();
            ZDSVRightstr = new List<string>();
            Perforate_hipLeftstr = new List<string>();
            Perforate_hipRightstr = new List<string>();
            BPV_TibiaLeftstr = new List<string>();
            BPV_TibiaRightstr = new List<string>();

            var IsVisibleBPVleftBuf = new ObservableCollection<Visibility>();
            //
            IsVisibleTEMPVleft = new ObservableCollection<Visibility>();
            IsVisibleTEMPVRight = new ObservableCollection<Visibility>();
            IsVisibleMPVleft = new ObservableCollection<Visibility>();
            IsVisibleMPVRight = new ObservableCollection<Visibility>();
            //
            IsVisiblePerforate_shinleft = new ObservableCollection<Visibility>();
            IsVisiblePerforate_shinRight = new ObservableCollection<Visibility>();
            IsVisibleSPSleft = new ObservableCollection<Visibility>();
            IsVisibleSPSRight = new ObservableCollection<Visibility>();
            //
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleMPVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleMPVRight.Add(Visibility.Collapsed);
            }


            for (int i = 0; i < 6; ++i)
            {
                IsVisibleTEMPVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleTEMPVRight.Add(Visibility.Collapsed);
            }

            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePerforate_shinleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePerforate_shinRight.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleSPSleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleSPSRight.Add(Visibility.Collapsed);
            }
            //
            IsVisibleBPV_Tibialeft = new ObservableCollection<Visibility>();
            IsVisibleBPV_Tibiaright = new ObservableCollection<Visibility>();
            IsVisiblePerforateHIPleft = new ObservableCollection<Visibility>();
            IsVisiblePerforateHIPright = new ObservableCollection<Visibility>();
            IsVisibleZDSVleft = new ObservableCollection<Visibility>();
            IsVisibleZDSVright = new ObservableCollection<Visibility>();
            //
            IsVisiblePDSVleft = new ObservableCollection<Visibility>();
            IsVisiblePDSVright = new ObservableCollection<Visibility>();
            IsVisibleBPVRight = new ObservableCollection<Visibility>();
            IsVisibleBPVleft = new ObservableCollection<Visibility>();
            IsVisibleSFSRight = new ObservableCollection<Visibility>();
            IsVisibleSFSleft = new ObservableCollection<Visibility>();
            //
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleBPV_Tibialeft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleBPV_Tibiaright.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePerforateHIPleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePerforateHIPright.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleZDSVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleZDSVright.Add(Visibility.Collapsed);
            }
            //
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePDSVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePDSVright.Add(Visibility.Collapsed);
            }


            for (int i = 0; i < 6; ++i)
            {
                IsVisibleBPVleftBuf.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleBPVRight.Add(Visibility.Collapsed);
            }

            for (int i = 0; i < 6; ++i)
            {
                IsVisibleSFSleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleSFSRight.Add(Visibility.Collapsed);
            }

            IsVisibleBPVleft = IsVisibleBPVleftBuf;

            MessageBus.Default.Subscribe("LegDataSaved", Handler);
            MessageBus.Default.Subscribe("GetCurrentPatientIdForOperation", SetCurrentPatientID);

            MessageBus.Default.Subscribe("SetRightDiagnosisListForObsled", SetRightDiagnosisList);
            MessageBus.Default.Subscribe("SetLeftDiagnosisListForObsled", SetLeftDiagnosisList);

            MessageBus.Default.Subscribe("SetRecomendationsList", SetRecomendationsList);
            MessageBus.Default.Subscribe("SetDiagnosisList", SetDiagnosisList);
            MessageBus.Default.Subscribe("SetComplainsList", SetComplainsList);
            TextTip = "Текст пометки";
            Controller = controller;
            base.HasNavigation = false;

            this.openDialogCommand = new RelayCommand(FinishAdding);

            ClickOnWeight = new DelegateCommand(
                () =>
                {
                    if (Weight == "0")
                        Weight = "";
                }
            );
            ClickOnGrowth = new DelegateCommand(
                () =>
                {
                    if (Growth == "0")
                        Growth = "";
                }
            );


            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelSymptomsAdd>();
                }
            );
            ToLeftDiagCommand = new DelegateCommand(
             () =>
             {
                 MessageBus.Default.Call("SetleftOrRightForObsled", this, "Left");
                 Controller.NavigateTo<ViewModelDiagnosisList>();
             }
         );
            ToRightDiagCommand = new DelegateCommand(
               () =>
               {
                   MessageBus.Default.Call("SetleftOrRightForObsled", this, "Right");
                   Controller.NavigateTo<ViewModelDiagnosisList>();
               });

            //БПВ
            LeftBPVHip = new BPVHipViewModel(Controller, LegSide.Left);
            RightBPVHip = new BPVHipViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftBPVHip);
            Controller.AddLegPartVM(RightBPVHip);

            ToLeftBPVHipCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstBPV", this, this);
                    Controller.LegViewModel = LeftBPVHip;
                    Controller.NavigateTo<BPVHipViewModel>(LegSide.Left);
                }
            );

            ToRightBPVHipCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstBPV", this, this);
                    Controller.LegViewModel = RightBPVHip;
                    Controller.NavigateTo<BPVHipViewModel>(LegSide.Right);
                }
            );

            //БПВ голень
            //BPVTibia

            LeftBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Left);
            RightBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftBPVTibia);
            Controller.AddLegPartVM(RightBPVTibia);

            ToLeftBPVTibiaCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstBPV_Tibia", this, this);
                    Controller.LegViewModel = LeftBPVTibia;
                    Controller.NavigateTo<BPVTibiaViewModel>(LegSide.Left);
                }
            );

            ToRightBPVTibiaCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstBPV_Tibia", this, this);
                    Controller.LegViewModel = RightBPVTibia;
                    Controller.NavigateTo<BPVTibiaViewModel>(LegSide.Right);
                }
            );

            //Бедро перфорант

            LeftPerforate = new HipPerforateViewModel(Controller, LegSide.Left);
            RightPerforate = new HipPerforateViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftPerforate);
            Controller.AddLegPartVM(RightPerforate);
            ToLeftPerforateCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPerforateHip", this, this);
                    Controller.LegViewModel = LeftPerforate;
                    Controller.NavigateTo<HipPerforateViewModel>(LegSide.Left);
                }
            );

            ToRightPerforateCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPerforateHip", this, this);
                    Controller.LegViewModel = RightPerforate;
                    Controller.NavigateTo<HipPerforateViewModel>(LegSide.Right);
                }
            );

            //ПДСВ
            LeftPDSV = new PDSVViewModel(Controller, LegSide.Left);
            RightPDSV = new PDSVViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftPDSV);
            Controller.AddLegPartVM(RightPDSV);

            ToLeftPDSVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPDSV", this, this);
                    Controller.LegViewModel = LeftPDSV;
                    Controller.NavigateTo<PDSVViewModel>(LegSide.Left);
                }
            );

            ToRightPDSVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPDSV", this, this);
                    Controller.LegViewModel = RightPDSV;
                    Controller.NavigateTo<PDSVViewModel>(LegSide.Right);
                }
            );

            //СФС

            LeftSFS = new SFSViewModel(Controller, LegSide.Left);
            RightSFS = new SFSViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftSFS);
            Controller.AddLegPartVM(RightSFS);

            ToLeftSFSCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstSFS", this, this);
                    Controller.LegViewModel = LeftSFS;
                    Controller.NavigateTo<SFSViewModel>(LegSide.Left);
                }
            );

            ToRightSFSCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstSFS", this, this);
                    Controller.LegViewModel = RightSFS;
                    Controller.NavigateTo<SFSViewModel>(LegSide.Right);
                }
            );

            //СПС

            LeftSPS = new SPSViewModel(Controller, LegSide.Left);
            RightSPS = new SPSViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftSPS);
            Controller.AddLegPartVM(RightSPS);
            IMTCOUNT = new DelegateCommand(
            () =>
            {
                ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100));
            }
          );
            ToLeftSPSCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstSPS", this, this);
                    Controller.LegViewModel = LeftSPS;
                    Controller.NavigateTo<SPSViewModel>(LegSide.Left);
                }
            );

            ToRightSPSCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstSPS", this, this);
                    Controller.LegViewModel = RightSPS;
                    Controller.NavigateTo<SPSViewModel>(LegSide.Right);
                }
            );

            //Перфорант голени

            LeftTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Left);
            RightTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftTibiaPerforate);
            Controller.AddLegPartVM(RightTibiaPerforate);
            ToLeftTibiaPerforateCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPerforateTibia", this, this);
                    Controller.LegViewModel = LeftTibiaPerforate;
                    Controller.NavigateTo<TibiaPerforateViewModel>(LegSide.Left);
                }
            );

            ToRightTibiaPerforateCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPerforateTibia", this, this);
                    Controller.LegViewModel = RightTibiaPerforate;
                    Controller.NavigateTo<TibiaPerforateViewModel>(LegSide.Right);
                }
            );

            //ЗДСВ

            LeftZDSV = new ZDSVViewModel(Controller, LegSide.Left);
            RightZDSV = new ZDSVViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftZDSV);
            Controller.AddLegPartVM(RightZDSV);

            ToLeftZDSVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstZDSV", this, this);
                    Controller.LegViewModel = LeftZDSV;
                    Controller.NavigateTo<ZDSVViewModel>(LegSide.Left);
                }
            );

            ToRightZDSVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstZDSV", this, this);
                    Controller.LegViewModel = RightZDSV;
                    Controller.NavigateTo<ZDSVViewModel>(LegSide.Right);
                }
            );

            //
            //МПВ

            LeftMPV = new MPVViewModel(Controller, LegSide.Left);
            RightMPV = new MPVViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftMPV);
            Controller.AddLegPartVM(RightMPV);

            ToLeftMPVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstMPV", this, this);
                    Controller.LegViewModel = LeftMPV;
                    Controller.NavigateTo<MPVViewModel>(LegSide.Left);
                }
            );

            ToRightMPVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstMPV", this, this);
                    Controller.LegViewModel = RightMPV;
                    Controller.NavigateTo<MPVViewModel>(LegSide.Right);
                }
            );

            //ТЕМПВ

            LeftTEMPV = new TEMPVViewModel(Controller, LegSide.Left);
            RightTEMPV = new TEMPVViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftTEMPV);
            Controller.AddLegPartVM(RightTEMPV);

            ToLeftTEMPVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.LegViewModel = LeftTEMPV;
                    Controller.NavigateTo<TEMPVViewModel>(LegSide.Left);
                }
            );

            ToRightTEMPVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.LegViewModel = RightTEMPV;
                    Controller.NavigateTo<TEMPVViewModel>(LegSide.Right);
                }
            );

            //
            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelComplainsList>();
                }
            );

            ToDiagnosisCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDiagnosisList>();
                }
            );

            ToAddRecomendationsCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelRecomendationsList>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("UpdateTableOfPatients", this, controller);
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );
            ClickOnTextTip = new DelegateCommand(
                () =>
                {
                    if (TextTip == "Текст пометки")
                        TextTip = "";
                    //Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
        }

        struct SaveSet
        {
            public List<string> stringList;
            public ObservableCollection<Visibility> listVisibility;
            public SaveSet(List<string> stringList, ObservableCollection<Visibility> listVisibility)
            {
                this.listVisibility = listVisibility;
                this.stringList = stringList;
            }
        }

        private void SaveAll()
        {
            RightBPV_TibiaEntryFull = (BPV_TibiaEntryFull)SaveFullEntry(RightBPVTibia, RightBPV_TibiaEntryFull);
            LeftBPV_TibiaEntryFull = (BPV_TibiaEntryFull)SaveFullEntry(LeftBPVTibia, LeftBPV_TibiaEntryFull);
            RightPerforate_hipEntryFull = (Perforate_hipEntryFull)SaveFullEntry(RightPerforate, RightPerforate_hipEntryFull);
            LeftPerforate_hipEntryFull = (Perforate_hipEntryFull)SaveFullEntry(LeftPerforate, LeftPerforate_hipEntryFull);
            RightZDSVEntryFull = (ZDSVEntryFull)SaveFullEntry(RightZDSV, RightZDSVEntryFull);
            LeftZDSVEntryFull = (ZDSVEntryFull)SaveFullEntry(LeftZDSV, LeftZDSVEntryFull);
            RightPDSVEntryFull = (PDSVHipEntryFull)SaveFullEntry(RightPDSV, RightPDSVEntryFull);
            LeftPDSVEntryFull = (PDSVHipEntryFull)SaveFullEntry(LeftPDSV, LeftPDSVEntryFull);
            RightBPVEntryFull = (BPVHipEntryFull)SaveFullEntry(RightBPVHip, RightBPVEntryFull);
            LeftBPVEntryFull = (BPVHipEntryFull)SaveFullEntry(LeftBPVHip, LeftBPVEntryFull);
            RightSFSEntryFull = (SFSHipEntryFull)SaveFullEntry(RightSFS, RightSFSEntryFull);
            LeftSFSEntryFull = (SFSHipEntryFull)SaveFullEntry(LeftSFS, LeftSFSEntryFull);

            RightSPSEntryFull = (SPSHipEntryFull)SaveFullEntry(RightSPS, RightSPSEntryFull);
            LeftSPSEntryFull = (SPSHipEntryFull)SaveFullEntry(LeftSPS, LeftSPSEntryFull);

            RightPerforate_shinEntryFull = (Perforate_shinEntryFull)SaveFullEntry(RightTibiaPerforate, RightPerforate_shinEntryFull);
            LeftPerforate_shinEntryFull = (Perforate_shinEntryFull)SaveFullEntry(LeftTibiaPerforate, LeftPerforate_shinEntryFull);

            RightTEMPVEntryFull = (TEMPVEntryFull)SaveFullEntry(RightTEMPV, RightTEMPVEntryFull);
            LeftTEMPVEntryFull = (TEMPVEntryFull)SaveFullEntry(LeftTEMPV, LeftTEMPVEntryFull);

            RightMPVEntryFull = (MPVEntryFull)SaveFullEntry(RightMPV, RightMPVEntryFull);
            LeftMPVEntryFull = (MPVEntryFull)SaveFullEntry(LeftMPV, LeftMPVEntryFull);

        }

        private LegPartEntries SaveFullEntry(LegPartViewModel Part, LegPartEntries FullEntry)
        {

            LegPartEntries LeftSFSEntryFullbuf = FullEntry;
            foreach (var section in Part.LegSections)
            {
                if (section.SelectedValue == null)
                { continue; }
                LegPartEntry newSFSentry = (LegPartEntry)section.CurrentEntry;
                newSFSentry.StructureID = section.SelectedValue.Id;
                if (Part is PDSVViewModel)
                {

                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                }
                else if (Part is SFSViewModel)
                {
                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                }
                else if (Part is BPVHipViewModel)
                {
                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                }
                else if (Part is BPVTibiaViewModel)
                {
                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                }
                else if (Part is HipPerforateViewModel)
                {
                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                }
                else if (Part is ZDSVViewModel)
                {
                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                }

                else if (Part is SPSViewModel)
                {
                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                }
                else if (Part is TibiaPerforateViewModel)
                {
                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                }
                else if (Part is MPVViewModel)
                {
                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
                }
                else if (Part is TEMPVViewModel)
                {
                    ((TEMPVEntryFull)LeftSFSEntryFullbuf).FF_Length = Part.FF_length;
                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                }

                Data.Complete();
                if (section.ListNumber == 1)
                {
                    LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;
                }
                if (section.ListNumber == 2)
                {
                    LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;
                }
                if (section.ListNumber == 3)
                {
                    LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                }
                if (section.ListNumber == 4)
                {
                    LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                }
                if (section.ListNumber == 5)
                {
                    LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                }
                if (section.ListNumber == 6)
                {
                    LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                }
            }
            if (Part.SelectedWayType != null)
            {
                LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
            }
          
             
          
            return LeftSFSEntryFullbuf;
        }


        private SaveSet SaveViewModel(LegPartViewModel sender)
        {
            List<string> bufBpvLeftStr = new List<string>();



            //to do тут должно быть сохранение


            var IsVisibleBPVleftbuf = new ObservableCollection<Visibility>();


            // IsVisibleBPVleftbuf.Add(Visibility.Visible);

            for (int i = 0; i < sender.LegSections.Count; ++i)
            {
                if (sender.LegSections[i].SelectedValue == null || sender.LegSections[i].SelectedValue.ToNextPart)
                {

                    IsVisibleBPVleftbuf.Add(Visibility.Collapsed);
                }
                else
                {
                    if (sender.LegSections[i].SelectedValue.HasSize || sender.LegSections[i].HasDoubleSize)
                    {
                        if (sender.LegSections[i].HasDoubleSize)
                        {
                            bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + "*" + sender.LegSections[i].CurrentEntry.Size2 + sender.LegSections[i].SelectedValue.Metrics + " " + sender.LegSections[i].SelectedValue.Text2 + " " + sender.LegSections[i].CurrentEntry.Comment);

                        }
                        else
                        {
                            bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + sender.LegSections[i].SelectedValue.Metrics + " " + sender.LegSections[i].SelectedValue.Text2 + " " + sender.LegSections[i].CurrentEntry.Comment);
                        }
                    }
                    else
                    {
                        bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].SelectedValue.Text2 + " " + sender.LegSections[i].CurrentEntry.Comment);
                    }
                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }
            }
            SaveSet result = new SaveSet(bufBpvLeftStr, IsVisibleBPVleftbuf);
            return result;

        }


        //  public ObservableCollection<>
        //кто присылает и что присылает
        private void Handler(object sender, object data)
        {
            Type senderType = sender.GetType();
            LegPartViewModel senderVM = (LegPartViewModel)sender;
            //  BPVHipEntryFull bpv = new BPVHipEntryFull();
            if (senderType == typeof(MPVViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    MPVLeftstr = new List<string>();
                    LeftMPVEntryFull = new MPVEntryFull();
                    //to do тут должно быть сохранение
                    LeftMPV = (MPVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftMPV);
                    MPVLeftstr = result.stringList;
                    IsVisibleMPVleft = result.listVisibility;

                }

                else
                {
                    MPVRightstr = new List<string>();
                    RightMPVEntryFull = new MPVEntryFull();
                    //to do тут должно быть сохранение
                    RightMPV = (MPVViewModel)sender;
                    SaveSet result = SaveViewModel(RightMPV);
                    MPVRightstr = result.stringList;
                    IsVisibleMPVRight = result.listVisibility;

                }
            if (senderType == typeof(TEMPVViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    TEMPVLeftstr = new List<string>();
                    LeftTEMPVEntryFull = new TEMPVEntryFull();
                    //to do тут должно быть сохранение
                    LeftTEMPV = (TEMPVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftTEMPV);
                    TEMPVLeftstr = result.stringList;
                    IsVisibleTEMPVleft = result.listVisibility;

                }

                else
                {
                    TEMPVRightstr = new List<string>();
                    RightTEMPVEntryFull = new TEMPVEntryFull();
                    //to do тут должно быть сохранение
                    RightTEMPV = (TEMPVViewModel)sender;
                    SaveSet result = SaveViewModel(RightTEMPV);
                    TEMPVRightstr = result.stringList;
                    IsVisibleTEMPVRight = result.listVisibility;

                }
            //sender проверять какого типа
            if (senderType == typeof(SFSViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    SFSLeftstr = new List<string>();
                    LeftSFSEntryFull = new SFSHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftSFS = (SFSViewModel)sender;
                    SaveSet result = SaveViewModel(LeftSFS);
                    SFSLeftstr = result.stringList;
                    IsVisibleSFSleft = result.listVisibility;

                }

                else
                {
                    SFSRightstr = new List<string>();
                    RightSFSEntryFull = new SFSHipEntryFull();
                    //to do тут должно быть сохранение
                    RightSFS = (SFSViewModel)sender;
                    SaveSet result = SaveViewModel(RightSFS);
                    SFSRightstr = result.stringList;
                    IsVisibleSFSRight = result.listVisibility;

                }

            //


            if (senderType == typeof(SPSViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    SPSLeftstr = new List<string>();
                    LeftSPSEntryFull = new SPSHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftSPS = (SPSViewModel)sender;
                    SaveSet result = SaveViewModel(LeftSPS);
                    SPSLeftstr = result.stringList;
                    IsVisibleSPSleft = result.listVisibility;

                }

                else
                {
                    SPSRightstr = new List<string>();
                    RightSPSEntryFull = new SPSHipEntryFull();
                    //to do тут должно быть сохранение
                    RightSPS = (SPSViewModel)sender;
                    SaveSet result = SaveViewModel(RightSPS);
                    SPSRightstr = result.stringList;
                    IsVisibleSPSRight = result.listVisibility;

                }


            if (senderType == typeof(TibiaPerforateViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    Perforate_shinLeftstr = new List<string>();
                    LeftPerforate_shinEntryFull = new Perforate_shinEntryFull();
                    //to do тут должно быть сохранение
                    LeftTibiaPerforate = (TibiaPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(LeftTibiaPerforate);
                    Perforate_shinLeftstr = result.stringList;
                    IsVisiblePerforate_shinleft = result.listVisibility;

                }

                else
                {
                    Perforate_shinRightstr = new List<string>();
                    RightPerforate_shinEntryFull = new Perforate_shinEntryFull();
                    //to do тут должно быть сохранение
                    RightTibiaPerforate = (TibiaPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(RightTibiaPerforate);
                    Perforate_shinRightstr = result.stringList;
                    IsVisiblePerforate_shinRight = result.listVisibility;

                }



            //




            if (senderType == typeof(BPVHipViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftBPVEntryFull = new BPVHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftBPVHip = (BPVHipViewModel)sender;
                    SaveSet result = SaveViewModel(LeftBPVHip);
                    BpvLeftstr = result.stringList;
                    IsVisibleBPVleft = result.listVisibility;

                }
                else
                {
                    RightBPVEntryFull = new BPVHipEntryFull();
                    BpvRightstr = new List<string>();
                    RightBPVHip = (BPVHipViewModel)sender;
                    SaveSet result = SaveViewModel(RightBPVHip);
                    BpvRightstr = result.stringList;
                    IsVisibleBPVRight = result.listVisibility;

                }

            if (senderType == typeof(PDSVViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftPDSVEntryFull = new PDSVHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftPDSV = (PDSVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftPDSV);
                    PDSVLeftstr = result.stringList;
                    IsVisiblePDSVleft = result.listVisibility;
                    //SaveAll();


                }
                else
                {
                    RightPDSVEntryFull = new PDSVHipEntryFull();
                    //to do тут должно быть сохранение
                    RightPDSV = (PDSVViewModel)sender;
                    SaveSet result = SaveViewModel(RightPDSV);
                    PDSVRightstr = result.stringList;
                    IsVisiblePDSVright = result.listVisibility;

                }

            //
            if (senderType == typeof(ZDSVViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftZDSVEntryFull = new ZDSVEntryFull();
                    //to do тут должно быть сохранение
                    LeftZDSV = (ZDSVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftZDSV);
                    ZDSVLeftstr = result.stringList;
                    IsVisibleZDSVleft = result.listVisibility;

                }
                else
                {
                    RightZDSVEntryFull = new ZDSVEntryFull();
                    //to do тут должно быть сохранение
                    RightZDSV = (ZDSVViewModel)sender;
                    SaveSet result = SaveViewModel(RightZDSV);
                    ZDSVRightstr = result.stringList;
                    IsVisibleZDSVright = result.listVisibility;

                }
            if (senderType == typeof(HipPerforateViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftPerforate_hipEntryFull = new Perforate_hipEntryFull();
                    //to do тут должно быть сохранение
                    LeftPerforate = (HipPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(LeftPerforate);
                    Perforate_hipLeftstr = result.stringList;
                    IsVisiblePerforateHIPleft = result.listVisibility;

                }
                else
                {
                    RightPerforate_hipEntryFull = new Perforate_hipEntryFull();
                    //to do тут должно быть сохранение
                    RightPerforate = (HipPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(RightPerforate);
                    Perforate_hipRightstr = result.stringList;
                    IsVisiblePerforateHIPright = result.listVisibility;

                }
            if (senderType == typeof(BPVTibiaViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftBPV_TibiaEntryFull = new BPV_TibiaEntryFull();
                    //to do тут должно быть сохранение
                    LeftBPVTibia = (BPVTibiaViewModel)sender;
                    SaveSet result = SaveViewModel(LeftBPVTibia);
                    BPV_TibiaLeftstr = result.stringList;
                    IsVisibleBPV_Tibialeft = result.listVisibility;

                }
                else
                {
                    RightBPV_TibiaEntryFull = new BPV_TibiaEntryFull();
                    //to do тут должно быть сохранение
                    RightBPVTibia = (BPVTibiaViewModel)sender;
                    SaveSet result = SaveViewModel(RightBPVTibia);
                    BPV_TibiaRightstr = result.stringList;
                    IsVisibleBPV_Tibiaright = result.listVisibility;

                }
            //

        }
    }
}
