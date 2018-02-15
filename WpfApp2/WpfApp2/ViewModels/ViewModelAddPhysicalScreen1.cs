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
using WpfApp2.Db.Models.PPV;
using WpfApp2.Db.Models.GV;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using WpfApp2.Db.Models.LegParts.PDSVHip;
using System.Linq;
using WpfApp2.Db.Models.LegParts.SFSHip;
using WpfApp2.Db.Models.LegParts.BPVHip;
using WpfApp2.Db.Models.LegParts.BPV_Tibia;
using WpfApp2.Db.Models.LegParts.Perforate_hip;
using WpfApp2.Db.Models.LegParts.ZDSV;
using WpfApp2.Db.Models.LegParts.SPSHip;
using WpfApp2.Db.Models.LegParts.Perforate_shin;
using WpfApp2.Db.Models.LegParts.MPV;
using WpfApp2.Db.Models.LegParts.TEMPV;
using WpfApp2.Db.Models.LegParts.GV;
using WpfApp2.Db.Models.LegParts.PPV;
using WpfApp2.ViewModels.Panels;

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


        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public DelegateCommand OpenCommand { protected set; get; }

        public DoctorSelectPanelViewModel CurrentPanelViewModel { get; protected set; }


        public static bool Handled = false;

        public UIElement UI;

        private int OpTypeFromDialog;

        private string OpCommentFromDialog;

        private void GetOpTypeAndCommentaryFromDialog(object sender, object data)
        {
            OpTypeFromDialog = (int)sender;
            OpCommentFromDialog = (string)data;
        }

        private void OpenHandler(object sender, object data)
        {
            if (!Handled)
            {
                Handled = true;
                CurrentPanelViewModel.PanelOpened = true;
            }
        }

        //


        public string LeftAdditionalText { get; set; }
        public string RightAdditionalText { get; set; }

        #region GV binds

        private ObservableCollection<Visibility> _isVisibleGVleft;
        public ObservableCollection<Visibility> IsVisibleGVleft
        {
            get
            {
                return _isVisibleGVleft;
            }
            set
            {
                _isVisibleGVleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleGVRight;
        public ObservableCollection<Visibility> IsVisibleGVRight
        {
            get
            {
                return _isVisibleGVRight;
            }
            set
            {
                _isVisibleGVRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> GVLeftstr
        {
            get
            {
                return _GVLeftstr;
            }
            set
            {
                _GVLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> GVRightstr
        {
            get
            {
                return _GVRightstr;
            }
            set
            {
                _GVRightstr = value;
                OnPropertyChanged();
            }
        }
        public GVEntryFull RightGVEntryFull { get; private set; }
        public GVEntryFull LeftGVEntryFull { get; private set; }

        private List<string> _GVRightstr;
        private List<string> _GVLeftstr;

        #endregion

        #region PPV binds

        private ObservableCollection<Visibility> _isVisiblePPVleft;
        public ObservableCollection<Visibility> IsVisiblePPVleft
        {
            get
            {
                return _isVisiblePPVleft;
            }
            set
            {
                _isVisiblePPVleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisiblePPVRight;
        public ObservableCollection<Visibility> IsVisiblePPVRight
        {
            get
            {
                return _isVisiblePPVRight;
            }
            set
            {
                _isVisiblePPVRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> PPVLeftstr
        {
            get
            {
                return _PPVLeftstr;
            }
            set
            {
                _PPVLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> PPVRightstr
        {
            get
            {
                return _PPVRightstr;
            }
            set
            {
                _PPVRightstr = value;
                OnPropertyChanged();
            }
        }
        public PPVEntryFull RightPPVEntryFull { get; private set; }
        public PPVEntryFull LeftPPVEntryFull { get; private set; }

        private List<string> _PPVRightstr;
        private List<string> _PPVLeftstr;

        #endregion

        #region CEAP binds

        private ObservableCollection<Visibility> _isVisibleCEAPleft;
        public ObservableCollection<Visibility> IsVisibleCEAPleft
        {
            get
            {
                return _isVisibleCEAPleft;
            }
            set
            {
                _isVisibleCEAPleft = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Visibility> _isVisibleCEAPRight;
        public ObservableCollection<Visibility> IsVisibleCEAPRight
        {
            get
            {
                return _isVisibleCEAPRight;
            }
            set
            {
                _isVisibleCEAPRight = value;
                OnPropertyChanged();
            }
        }

        public List<string> CEAPLeftstr
        {
            get
            {
                return _CEAPLeftstr;
            }
            set
            {
                _CEAPLeftstr = value;
                OnPropertyChanged();
            }
        }
        public List<string> CEAPRightstr
        {
            get
            {
                return _CEAPRightstr;
            }
            set
            {
                _CEAPRightstr = value;
                OnPropertyChanged();
            }
        }

        private List<string> _CEAPRightstr;
        private List<string> _CEAPLeftstr;

        #endregion

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
        public DelegateCommand LostOnTextTip { get; private set; }
        public DelegateCommand LostFocusOnGrowth { get; private set; }
        public DelegateCommand ClickOnWeight { get; protected set; }
        public DelegateCommand ClickOnGrowth { get; protected set; }

        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }

        public DelegateCommand ToPhysicalOverviewCommand { get; protected set; }
        public DelegateCommand ToPhysicalChirurgOverviewCommand { get; private set; }
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
            MessageBus.Default.Call("SetClearDiagnosisListLeftRightObsled", null, null);
            MessageBus.Default.Call("SetClearRecomendationListObsledovanie", null, null);
            MessageBus.Default.Call("SetClearComplanesListObsledovanie", null, null);
            Clear(null, null);
            Weight = "0";
            Growth = "0";
            TextTip = "Текст пометки";
            CurrentPatient = Data.Patients.Get((int)data);
            initials = " " + CurrentPatient.Sirname.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

        }

        private ICommand openDialogCommand = null;

        public DelegateCommand LostFocusOnWeight { get; private set; }

        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }




        public BPVHipViewModel LeftBPVHip { get; protected set; }
        public SFSViewModel LeftSFS { get; protected set; }
        public PDSVViewModel LeftPDSV { get; set; }
        public ZDSVViewModel LeftZDSV { get; protected set; }
        public HipPerforateViewModel LeftPerforate { get; protected set; }
        public TibiaPerforateViewModel LeftTibiaPerforate { get; protected set; }
        public BPVTibiaViewModel LeftBPVTibia { get; protected set; }
        public SPSViewModel LeftSPS { get; protected set; }
        public MPVViewModel LeftMPV { get; protected set; }
        public MPVViewModel RightMPV { get; protected set; }


        public PPVViewModel LeftPPV { get; protected set; }
        public PPVViewModel RightPPV { get; protected set; }

        public TEMPVViewModel LeftTEMPV { get; protected set; }
        public TEMPVViewModel RightTEMPV { get; protected set; }

        public BPVHipViewModel RightBPVHip { get; protected set; }
        public SFSViewModel RightSFS { get; protected set; }
        public LettersViewModel LeftCEAR { get; protected set; }
        public LettersViewModel RightCEAR { get; protected set; }
        public PDSVViewModel RightPDSV { get; protected set; }
        public ZDSVViewModel RightZDSV { get; protected set; }
        public HipPerforateViewModel RightPerforate { get; protected set; }
        public TibiaPerforateViewModel RightTibiaPerforate { get; protected set; }
        public BPVTibiaViewModel RightBPVTibia { get; protected set; }
        public SPSViewModel RightSPS { get; protected set; }
        public DelegateCommand ToLeftCEARCommand { get; private set; }
        public DelegateCommand ToRightCEARCommand { get; private set; }
        public DelegateCommand ToLeftPPVCommand { get; private set; }
        public DelegateCommand ToRightPPVCommand { get; private set; }
        public GVViewModel LeftGV { get; private set; }
        public GVViewModel RightGV { get; private set; }
        public DelegateCommand ToLeftGVCommand { get; private set; }
        public DelegateCommand ToRightGVCommand { get; private set; }
        public string Doctor { get; private set; }

        private void FinishAdding(object parameter)
        {
            if (LeftGV.IsEmpty == true)
            {
                MessageBox.Show("ГВ слева не заполнено");
            }
            else if (RightGV.IsEmpty == true)
            {
                MessageBox.Show("ГВ справа не заполнено");
            }

            else if (LeftPDSV.IsEmpty == true)
            {
                MessageBox.Show("ПДСВ слева не заполнено");
            }
            else if (RightPDSV.IsEmpty == true)
            {
                MessageBox.Show("ПДСВ справа не заполнено");
            }
            else if (RightZDSV.IsEmpty == true)
            {
                MessageBox.Show("ЗДСВ справа не заполнено");
            }
            else if (LeftZDSV.IsEmpty == true)
            {
                MessageBox.Show("ЗДСВ слева не заполнено");
            }
            else if (RightPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты бедра и несафенные вены справа не заполнено");
            }
            else if (LeftPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты бедра и несафенные вены слева не заполнено");
            }
            else if (RightTibiaPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты голени справа не заполнено");
            }
            else if (LeftTibiaPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты голени слева не заполнено");
            }
            else if (RightTEMPV.IsEmpty == true)
            {
                MessageBox.Show("ТЕ МПВ справа не заполнено");
            }
            else if (LeftTEMPV.IsEmpty == true)
            {
                MessageBox.Show("ТЕ МПВ слева не заполнено");
            }
            else if (RightPPV.IsEmpty == true)
            {
                MessageBox.Show("ППВ справа не заполнено");
            }
            else if (LeftPPV.IsEmpty == true)
            {
                MessageBox.Show("ППВ слева не заполнено");
            }
            else if (string.IsNullOrWhiteSpace(RightAdditionalText))
            {
                MessageBox.Show("Примечание справа не заполнено");
            }
            else if (string.IsNullOrWhiteSpace(LeftAdditionalText))
            {
                MessageBox.Show("Примечание слева не заполнено");
            }



            else if (LeftCEAR.LegSections[0].SelectedValue == null)
            {
                MessageBox.Show("C слева не заполнено");
            }
            else if (LeftCEAR.LegSections[1].SelectedValue == null)
            {
                MessageBox.Show("E слева не заполнено");
            }
            else if (LeftCEAR.LegSections[2].SelectedValue == null)
            {
                MessageBox.Show("A слева не заполнено");
            }
            else if (LeftCEAR.LegSections[3].SelectedValue == null)
            {
                MessageBox.Show("P слева не заполнено");
            }

            else if (RightCEAR.LegSections[0].SelectedValue == null)
            {
                MessageBox.Show("C справа не заполнено");
            }
            else if (RightCEAR.LegSections[1].SelectedValue == null)
            {
                MessageBox.Show("E справа не заполнено");
            }
            else if (RightCEAR.LegSections[2].SelectedValue == null)
            {
                MessageBox.Show("A справа не заполнено");
            }
            else if (RightCEAR.LegSections[3].SelectedValue == null)
            {
                MessageBox.Show("P справа не заполнено");
            }


            else
            {


                if (mode == "EDIT")
                {
                    using (var context = new MySqlContext())
                    {

                        SaveAll();


                        ExaminationRepository ExamRep = new ExaminationRepository(context);
                        ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);




                        Examination examnTotal = Data.Examination.Get(obsid);
                        ExaminationLeg leftLegExams = Data.ExaminationLeg.Get(examnTotal.idLeftLegExamination.Value);
                        ExaminationLeg rightLegExams = Data.ExaminationLeg.Get(examnTotal.idRightLegExamination.Value);


                        if (!LeftBPVHip.IsEmpty)
                            leftLegExams.BPVHip = LeftBPVEntryFull.Id;

                        if (!LeftBPVTibia.IsEmpty)
                            leftLegExams.BPVTibiaid = LeftBPV_TibiaEntryFull.Id;


                        if (!LeftGV.IsEmpty)
                            leftLegExams.GVid = LeftGVEntryFull.Id;

                        if (!LeftMPV.IsEmpty)
                            leftLegExams.MPVid = LeftMPVEntryFull.Id;

                        if (!LeftPDSV.IsEmpty)
                            leftLegExams.PDSVid = LeftPDSVEntryFull.Id;

                        if (!LeftPerforate.IsEmpty)
                            leftLegExams.PerforateHipid = LeftPerforate_hipEntryFull.Id;

                        if (!LeftPPV.IsEmpty)
                            leftLegExams.PPVid = LeftPPVEntryFull.Id;

                        if (!LeftSFS.IsEmpty)
                            leftLegExams.SFSid = LeftSFSEntryFull.Id;

                        if (!LeftSPS.IsEmpty)
                            leftLegExams.SPSid = LeftSPSEntryFull.Id;

                        if (!LeftTEMPV.IsEmpty)
                            leftLegExams.TEMPVid = LeftTEMPVEntryFull.Id;

                        if (!LeftTibiaPerforate.IsEmpty)
                            leftLegExams.TibiaPerforateid = LeftPerforate_shinEntryFull.Id;

                        if (!LeftZDSV.IsEmpty)
                            leftLegExams.ZDSVid = LeftZDSVEntryFull.Id;

                        leftLegExams.additionalText = LeftAdditionalText;
                        if (LeftCEAR.LegSections[0].SelectedValue != null)
                            leftLegExams.C = LeftCEAR.LegSections[0].SelectedValue.Id;
                        if (LeftCEAR.LegSections[1].SelectedValue != null)
                            leftLegExams.E = LeftCEAR.LegSections[1].SelectedValue.Id;
                        if (LeftCEAR.LegSections[2].SelectedValue != null)
                            leftLegExams.A = LeftCEAR.LegSections[2].SelectedValue.Id;
                        if (LeftCEAR.LegSections[3].SelectedValue != null)
                            leftLegExams.P = LeftCEAR.LegSections[3].SelectedValue.Id;


                        if (!RightBPVHip.IsEmpty)
                            rightLegExams.BPVHip = RightBPVEntryFull.Id;

                        if (!RightBPVTibia.IsEmpty)
                            rightLegExams.BPVTibiaid = RightBPV_TibiaEntryFull.Id;


                        if (!RightGV.IsEmpty)
                            rightLegExams.GVid = RightGVEntryFull.Id;

                        if (!RightMPV.IsEmpty)
                            rightLegExams.MPVid = RightMPVEntryFull.Id;

                        if (!RightPDSV.IsEmpty)
                            rightLegExams.PDSVid = RightPDSVEntryFull.Id;

                        if (!RightPerforate.IsEmpty)
                            rightLegExams.PerforateHipid = RightPerforate_hipEntryFull.Id;

                        if (!RightPPV.IsEmpty)
                            rightLegExams.PPVid = RightPPVEntryFull.Id;

                        if (!RightSFS.IsEmpty)
                            rightLegExams.SFSid = RightSFSEntryFull.Id;

                        if (!RightSPS.IsEmpty)
                            rightLegExams.SPSid = RightSPSEntryFull.Id;

                        if (!RightTEMPV.IsEmpty)
                            rightLegExams.TEMPVid = RightTEMPVEntryFull.Id;

                        if (!RightTibiaPerforate.IsEmpty)
                            rightLegExams.TibiaPerforateid = RightPerforate_shinEntryFull.Id;

                        if (!RightZDSV.IsEmpty)
                            rightLegExams.ZDSVid = RightZDSVEntryFull.Id;

                        rightLegExams.additionalText = RightAdditionalText;
                        if (RightCEAR.LegSections[0].SelectedValue != null)
                            rightLegExams.C = RightCEAR.LegSections[0].SelectedValue.Id;
                        if (RightCEAR.LegSections[1].SelectedValue != null)
                            rightLegExams.E = RightCEAR.LegSections[1].SelectedValue.Id;
                        if (RightCEAR.LegSections[2].SelectedValue != null)
                            rightLegExams.A = RightCEAR.LegSections[2].SelectedValue.Id;
                        if (RightCEAR.LegSections[3].SelectedValue != null)
                            rightLegExams.P = RightCEAR.LegSections[3].SelectedValue.Id;



                        examnTotal.PatientId = CurrentPatient.Id;
                        //examnTotal.Date = DateTime.Now;

                        examnTotal.weight = float.Parse(Weight);
                        examnTotal.NB = TextTip;
                        examnTotal.height = float.Parse(Growth);

                        //examnTotal.idLeftLegExamination = leftLegExams.Id;
                        //examnTotal.idRightLegExamination = rightLegExams.Id;

                        Data.Complete();
                        bool test = false;
                        if (LeftDiagnosisList != null)
                        {

                            foreach (var dgOp in Data.DiagnosisObs.GetAll)
                            {

                                if (dgOp.id_обследование_ноги == examnTotal.Id && dgOp.isLeft == true)
                                {
                                    test = true;
                                    foreach (var diag in LeftDiagnosisList)
                                    {
                                        if (diag.IsChecked.Value && dgOp.id_диагноз == diag.Data.Id)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                }
                                if (test)
                                {
                                    Data.DiagnosisObs.Remove(dgOp);
                                    Data.Complete();
                                }
                            }
                            test = false;
                            // Data.Complete();

                            foreach (var diag in LeftDiagnosisList)
                            {
                                if (diag.IsChecked.Value)
                                {

                                    test = true;
                                    foreach (var dgOp in Data.DiagnosisObs.GetAll)
                                    {

                                        if (dgOp.id_диагноз == diag.Data.Id && dgOp.id_обследование_ноги == examnTotal.Id && dgOp.isLeft == true)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                    if (test)
                                    {
                                        var newDiag = new DiagnosisObs();
                                        newDiag.id_диагноз = diag.Data.Id;
                                        newDiag.id_обследование_ноги = examnTotal.Id;
                                        newDiag.isLeft = true;
                                        Data.DiagnosisObs.Add(newDiag);
                                        Data.Complete();
                                    }
                                }
                            }

                        }
                        test = false;
                        if (RightDiagnosisList != null)
                        {
                            foreach (var dgOp in Data.DiagnosisObs.GetAll)
                            {

                                if (dgOp.id_обследование_ноги == examnTotal.Id && dgOp.isLeft == false)
                                {
                                    test = true;
                                    foreach (var diag in RightDiagnosisList)
                                    {
                                        if (diag.IsChecked.Value && dgOp.id_диагноз == diag.Data.Id)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                }
                                if (test)
                                {
                                    Data.DiagnosisObs.Remove(dgOp);
                                    Data.Complete();
                                }
                            }
                            test = false;
                            //Data.Complete();
                            foreach (var diag in RightDiagnosisList)
                            {
                                if (diag.IsChecked.Value)
                                {
                                    test = true;
                                    foreach (var dgOp in Data.DiagnosisObs.GetAll)
                                    {
                                        if (dgOp.id_диагноз == diag.Data.Id && dgOp.id_обследование_ноги == examnTotal.Id && dgOp.isLeft == false)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                    if (test)
                                    {
                                        var newDiag = new DiagnosisObs();
                                        newDiag.id_диагноз = diag.Data.Id;
                                        newDiag.id_обследование_ноги = examnTotal.Id;
                                        newDiag.isLeft = false;
                                        Data.DiagnosisObs.Add(newDiag);
                                        Data.Complete();
                                    }
                                }
                            }
                        }
                        test = false;
                        if (RecomendationsList != null)
                        {

                            foreach (var dgOp in Data.RecomendationObs.GetAll)
                            {

                                if (dgOp.id_обследования == examnTotal.Id)
                                {
                                    test = true;
                                    foreach (var diag in RecomendationsList)
                                    {
                                        if (diag.IsChecked.Value && dgOp.id_рекомендации == diag.Data.Id)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                }
                                if (test)
                                {
                                    Data.RecomendationObs.Remove(dgOp);
                                    Data.Complete();
                                }
                            }

                            //   Data.Complete();
                            test = false;

                            foreach (var rec in RecomendationsList)
                            {
                                if (rec.IsChecked.Value)
                                {
                                    test = true;
                                    foreach (var rcOp in Data.RecomendationObs.GetAll)
                                    {
                                        if (rcOp.id_рекомендации == rec.Data.Id && rcOp.id_обследования == examnTotal.Id.Value)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                    if (test)
                                    {
                                        var newRec = new RecomendationObs();
                                        newRec.id_рекомендации = rec.Data.Id;
                                        newRec.id_обследования = examnTotal.Id.Value;
                                        Data.RecomendationObs.Add(newRec);
                                        Data.Complete();
                                    }
                                }
                            }
                        }
                        test = false;
                        if (ComplainsList != null)
                        {
                            foreach (var dgOp in Data.ComplanesObs.GetAll)
                            {

                                if (dgOp.id_обследования == examnTotal.Id)
                                {
                                    test = true;
                                    foreach (var diag in ComplainsList)
                                    {
                                        if (diag.IsChecked.Value && dgOp.id_жалобы == diag.Data.Id)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                }
                                if (test)
                                {
                                    Data.ComplanesObs.Remove(dgOp);
                                    Data.Complete();
                                }
                            }

                            //  Data.Complete();

                            test = false;


                            foreach (var cmp in ComplainsList)
                            {
                                if (cmp.IsChecked.Value)
                                {
                                    test = true;
                                    foreach (var cmOp in Data.ComplanesObs.GetAll)
                                    {
                                        if (cmOp.id_жалобы == cmp.Data.Id && cmOp.id_обследования == examnTotal.Id.Value)
                                        {
                                            test = false;
                                            break;
                                        }
                                    }
                                    if (test)
                                    {
                                        var newcmp = new ComplanesObs();
                                        newcmp.id_жалобы = cmp.Data.Id;
                                        newcmp.id_обследования = examnTotal.Id.Value;
                                        Data.ComplanesObs.Add(newcmp);
                                        Data.Complete();
                                    }
                                }
                            }
                        }
                        //   Data.Complete();


                    }
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                    mode = "Normal";

                }
                else
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
                    Examination examnTotal = new Examination();
                    ExaminationLeg leftLegExams = new ExaminationLeg();
                    ExaminationLeg rightLegExams = new ExaminationLeg();
                    SaveAll();
                    if (result == DialogResult.Yes)
                    {
                        examnTotal.isNeedOperation = true;
                        examnTotal.OperationType = OpTypeFromDialog;
                        examnTotal.Comment = OpCommentFromDialog;
                    }
                    else
                        examnTotal.isNeedOperation = false;
                    if (!LeftBPVHip.IsEmpty)
                        leftLegExams.BPVHip = LeftBPVEntryFull.Id;

                    if (!LeftBPVTibia.IsEmpty)
                        leftLegExams.BPVTibiaid = LeftBPV_TibiaEntryFull.Id;


                    if (!LeftGV.IsEmpty)
                        leftLegExams.GVid = LeftGVEntryFull.Id;

                    if (!LeftMPV.IsEmpty)
                        leftLegExams.MPVid = LeftMPVEntryFull.Id;

                    if (!LeftPDSV.IsEmpty)
                        leftLegExams.PDSVid = LeftPDSVEntryFull.Id;

                    if (!LeftPerforate.IsEmpty)
                        leftLegExams.PerforateHipid = LeftPerforate_hipEntryFull.Id;

                    if (!LeftPPV.IsEmpty)
                        leftLegExams.PPVid = LeftPPVEntryFull.Id;

                    if (!LeftSFS.IsEmpty)
                        leftLegExams.SFSid = LeftSFSEntryFull.Id;

                    if (!LeftSPS.IsEmpty)
                        leftLegExams.SPSid = LeftSPSEntryFull.Id;

                    if (!LeftTEMPV.IsEmpty)
                        leftLegExams.TEMPVid = LeftTEMPVEntryFull.Id;

                    if (!LeftTibiaPerforate.IsEmpty)
                        leftLegExams.TibiaPerforateid = LeftPerforate_shinEntryFull.Id;

                    if (!LeftZDSV.IsEmpty)
                        leftLegExams.ZDSVid = LeftZDSVEntryFull.Id;

                    leftLegExams.additionalText = LeftAdditionalText;
                    if (LeftCEAR.LegSections[0].SelectedValue != null)
                        leftLegExams.C = LeftCEAR.LegSections[0].SelectedValue.Id;
                    if (LeftCEAR.LegSections[1].SelectedValue != null)
                        leftLegExams.E = LeftCEAR.LegSections[1].SelectedValue.Id;
                    if (LeftCEAR.LegSections[2].SelectedValue != null)
                        leftLegExams.A = LeftCEAR.LegSections[2].SelectedValue.Id;
                    if (LeftCEAR.LegSections[3].SelectedValue != null)
                        leftLegExams.P = LeftCEAR.LegSections[3].SelectedValue.Id;


                    if (!RightBPVHip.IsEmpty)
                        rightLegExams.BPVHip = RightBPVEntryFull.Id;

                    if (!RightBPVTibia.IsEmpty)
                        rightLegExams.BPVTibiaid = RightBPV_TibiaEntryFull.Id;


                    if (!RightGV.IsEmpty)
                        rightLegExams.GVid = RightGVEntryFull.Id;

                    if (!RightMPV.IsEmpty)
                        rightLegExams.MPVid = RightMPVEntryFull.Id;

                    if (!RightPDSV.IsEmpty)
                        rightLegExams.PDSVid = RightPDSVEntryFull.Id;

                    if (!RightPerforate.IsEmpty)
                        rightLegExams.PerforateHipid = RightPerforate_hipEntryFull.Id;

                    if (!RightPPV.IsEmpty)
                        rightLegExams.PPVid = RightPPVEntryFull.Id;

                    if (!RightSFS.IsEmpty)
                        rightLegExams.SFSid = RightSFSEntryFull.Id;

                    if (!RightSPS.IsEmpty)
                        rightLegExams.SPSid = RightSPSEntryFull.Id;

                    if (!RightTEMPV.IsEmpty)
                        rightLegExams.TEMPVid = RightTEMPVEntryFull.Id;

                    if (!RightTibiaPerforate.IsEmpty)
                        rightLegExams.TibiaPerforateid = RightPerforate_shinEntryFull.Id;

                    if (!RightZDSV.IsEmpty)
                        rightLegExams.ZDSVid = RightZDSVEntryFull.Id;

                    rightLegExams.additionalText = RightAdditionalText;
                    if (RightCEAR.LegSections[0].SelectedValue != null)
                        rightLegExams.C = RightCEAR.LegSections[0].SelectedValue.Id;
                    if (RightCEAR.LegSections[1].SelectedValue != null)
                        rightLegExams.E = RightCEAR.LegSections[1].SelectedValue.Id;
                    if (RightCEAR.LegSections[2].SelectedValue != null)
                        rightLegExams.A = RightCEAR.LegSections[2].SelectedValue.Id;
                    if (RightCEAR.LegSections[3].SelectedValue != null)
                        rightLegExams.P = RightCEAR.LegSections[3].SelectedValue.Id;

                    Data.ExaminationLeg.Add(leftLegExams);
                    Data.Complete();
                    Data.ExaminationLeg.Add(rightLegExams);
                    Data.Complete();

                    examnTotal.PatientId = CurrentPatient.Id;
                    examnTotal.Date = DateTime.Now;
                    if (result == DialogResult.Yes)
                        examnTotal.isNeedOperation = true;
                    else
                        examnTotal.isNeedOperation = false;
                    examnTotal.weight = float.Parse(Weight);
                    examnTotal.NB = TextTip;
                    examnTotal.height = float.Parse(Growth);
                    examnTotal.idLeftLegExamination = leftLegExams.Id;
                    examnTotal.idRightLegExamination = rightLegExams.Id;
                    Data.Examination.Add(examnTotal);
                    Data.Complete();
                    if (LeftDiagnosisList != null)
                        foreach (var diag in LeftDiagnosisList)
                        {
                            if (diag.IsChecked.Value)
                            {
                                var newDiag = new DiagnosisObs
                                {
                                    id_диагноз = diag.Data.Id,
                                    id_обследование_ноги = examnTotal.Id,
                                    isLeft = true
                                };
                                Data.DiagnosisObs.Add(newDiag);
                                Data.Complete();
                            }
                        }
                    if (RightDiagnosisList != null)
                        foreach (var diag in RightDiagnosisList)
                        {
                            if (diag.IsChecked.Value)
                            {
                                var newDiag = new DiagnosisObs
                                {
                                    id_диагноз = diag.Data.Id,
                                    id_обследование_ноги = examnTotal.Id,
                                    isLeft = false
                                };
                                Data.DiagnosisObs.Add(newDiag);
                                Data.Complete();
                            }
                        }

                    if (RecomendationsList != null)
                        foreach (var rec in RecomendationsList)
                        {
                            if (rec.IsChecked.Value)
                            {
                                var newRec = new RecomendationObs
                                {
                                    id_рекомендации = rec.Data.Id,
                                    id_обследования = examnTotal.Id.Value
                                };
                                Data.RecomendationObs.Add(newRec);
                                Data.Complete();
                            }
                        }
                    if (ComplainsList != null)

                        foreach (var cmp in ComplainsList)
                        {
                            if (cmp.IsChecked.Value)
                            {
                                var newcmp = new ComplanesObs();
                                newcmp.id_жалобы = cmp.Data.Id;
                                newcmp.id_обследования = examnTotal.Id.Value;
                                Data.ComplanesObs.Add(newcmp);
                                Data.Complete();
                            }
                        }
                    //  Data.Complete();
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }





            }
        }

        void BuildStr(ref Paragraph p4, LegPartViewModel LegPart, bool isNormal)
        {

            if (!isNormal)
                p4.Append(LegPart.Title + ": ").Font("Times new roman").FontSize(11.0).UnderlineStyle(UnderlineStyle.singleLine);
            else
            {
                p4.Append(LegPart.Title + ": ").Font("Times new roman").FontSize(11.0);

            }
            if (!LegPart.IsEmpty)
            {

                if (LegPart.SelectedWayType != null && !string.IsNullOrWhiteSpace(LegPart.SelectedWayType.Name))
                    p4.Append("Вид хода :" + LegPart.SelectedWayType.Name + ";").Font("Times new roman").FontSize(11.0);
                if (LegPart is TEMPVViewModel)
                    p4.Append("Протяжность :" + ((TEMPVViewModel)LegPart).FF_length + ";").Font("Times new roman").FontSize(11.0);


                foreach (var section in LegPart.LegSections)
                {
                    if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                    {
                        if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                            p4.Append("«" + section.SelectedValue.Text1).Font("Times new roman").FontSize(11.0);


                        if (section.SelectedValue.HasSize || section.HasDoubleSize)
                        {
                            if (section.HasDoubleSize)
                            {
                                p4.Append(" " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + "»").Font("Times new roman").FontSize(11.0);

                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                    p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + "»").Font("Times new roman").FontSize(11.0);
                                else
                                {
                                    p4.Append(" " + section.CurrentEntry.Size + "»").Font("Times new roman").FontSize(11.0);

                                }
                            }
                        }
                        else
                        {
                            p4.Append("»").Font("Times new roman").FontSize(11.0);
                        }

                        if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                            p4.Append("«" + section.SelectedValue.Text2 + "»").Font("Times new roman").FontSize(11.0);
                        if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                        {
                            p4.Append("«" + section.CurrentEntry.Comment + "»").Font("Times new roman").FontSize(11.0);

                        }

                    }
                }
            }
            p4.Append("\n");
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
        int docsCreated = 0;
        private void CreateStatement(string docName)
        {
            using (DocX document = DocX.Create(docName))
            {
                // Insert a new Paragraph.
                Paragraph p = document.InsertParagraph();
                Paragraph p1 = document.InsertParagraph();
                Paragraph p2 = document.InsertParagraph();
                Paragraph p3 = document.InsertParagraph();
                Paragraph p4 = document.InsertParagraph();
                Paragraph p5 = document.InsertParagraph();
                Paragraph p6 = document.InsertParagraph();
                Paragraph p7 = document.InsertParagraph();
                Paragraph p8 = document.InsertParagraph();

                p.Append("Консультативное заключение\n").Font("Times new roman").Bold().FontSize(14.0).Alignment = Alignment.center;
                p1.Append("«" + CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic + "»,«" + CurrentPatient.Birthday.Day + "." + CurrentPatient.Birthday.Month + "." + CurrentPatient.Birthday.Year + "»                            Дата: «" + DateTime.Now + "»\n").Font("Times new roman").FontSize(12.0);
                p2.Append("Допплерография вен нижних конечностей:\n").Font("Times new roman").Bold().FontSize(14.0);
                p3.Append("Правая нижняя конечность:\n").Font("Times new roman").Bold().FontSize(11.0);
                BuildStr(ref p4, RightSFS, false);
                BuildStr(ref p4, RightBPVHip, true);
                BuildStr(ref p4, RightPDSV, true);
                BuildStr(ref p4, RightZDSV, false);
                BuildStr(ref p4, RightPerforate, false);
                BuildStr(ref p4, RightBPVTibia, true);
                BuildStr(ref p4, RightTibiaPerforate, false);
                BuildStr(ref p4, RightSPS, false);
                BuildStr(ref p4, RightMPV, true);
                BuildStr(ref p4, RightTEMPV, true);
                BuildStr(ref p4, RightPPV, true);
                BuildStr(ref p4, RightGV, false);

                if (!string.IsNullOrWhiteSpace(RightAdditionalText))
                    p4.Append("«" + RightAdditionalText + "»\n").Font("Times new roman").FontSize(11.0);

                p4.Append("Левая нижняя конечность:\n").Font("Times new roman").Bold().FontSize(11.0);
                BuildStr(ref p4, LeftSFS, false);
                BuildStr(ref p4, LeftBPVHip, true);
                BuildStr(ref p4, LeftPDSV, true);
                BuildStr(ref p4, LeftZDSV, false);
                BuildStr(ref p4, LeftPerforate, false);
                BuildStr(ref p4, LeftBPVTibia, true);
                BuildStr(ref p4, LeftTibiaPerforate, false);
                BuildStr(ref p4, LeftSPS, false);
                BuildStr(ref p4, LeftMPV, true);
                BuildStr(ref p4, LeftTEMPV, true);
                BuildStr(ref p4, LeftPPV, true);
                BuildStr(ref p4, LeftGV, false);

                if (!string.IsNullOrWhiteSpace(LeftAdditionalText))
                    p4.Append("«" + LeftAdditionalText + "»\n").Font("Times new roman").FontSize(11.0);

                p4.Append("Заключение:\n").Font("Times new roman").Bold().FontSize(11.0);

                p4.Append("Заключение справа: ").Font("Times new roman").FontSize(11.0);
                foreach (var letter in RightCEAR.LegSections)
                {
                    if (letter.SelectedValue != null)
                    {
                        p4.Append("«" + letter.SelectedValue.Leter + letter.SelectedValue.Text1 + "»").Font("Times new roman").FontSize(11.0);

                    }
                }



                p4.Append("\nЗаключение слева: ").Font("Times new roman").FontSize(11.0);
                foreach (var letter in LeftCEAR.LegSections)
                {
                    if (letter.SelectedValue != null)
                    {
                        p4.Append("«" + letter.SelectedValue.Leter + letter.SelectedValue.Text1 + "»").Font("Times new roman").FontSize(11.0);

                    }
                }

                p4.Append("\nРекомендовано : ").Font("Times new roman").FontSize(11.0).UnderlineStyle(UnderlineStyle.singleLine);
                if (RecomendationsList != null)
                    foreach (var rec in RecomendationsList)
                    {
                        if (rec.IsChecked == true)
                        {
                            p4.Append("«" + rec.Data.Str + "»").Font("Times new roman").FontSize(11.0);

                        }
                    }
                //   p4.Append("Сафено-феморальное соустье").Font("Times new roman").FontSize(11.0).UnderlineStyle(UnderlineStyle.singleLine);
                //foreach (var section in RightSFS.LegSections)
                //{
                //    if (section.SelectedValue != null)
                //        p4.Append(" «" + section.SelectedValue.Text1 + "»").Font("Times new roman").FontSize(11.0);
                //}

                // Save this document.
                document.Save();
                // Release this document from memory.

            }
            Process.Start("WINWORD.EXE", docName);
        }
        private bool TestAllFIelds()
        {
            bool test = true;
            if (LeftGV.IsEmpty == true)
            {
                MessageBox.Show("ГВ слева не заполнено");
                test = false;
            }
            else if (RightGV.IsEmpty == true)
            {
                MessageBox.Show("ГВ справа не заполнено");
                test = false;
            }

            else if (LeftPDSV.IsEmpty == true)
            {
                MessageBox.Show("ПДСВ слева не заполнено"); test = false;
            }
            else if (RightPDSV.IsEmpty == true)
            {
                MessageBox.Show("ПДСВ справа не заполнено"); test = false;
            }
            else if (RightZDSV.IsEmpty == true)
            {
                MessageBox.Show("ЗДСВ справа не заполнено"); test = false;
            }
            else if (LeftZDSV.IsEmpty == true)
            {
                MessageBox.Show("ЗДСВ слева не заполнено"); test = false;
            }
            else if (RightPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты бедра и несафенные вены справа не заполнено"); test = false;
            }
            else if (LeftPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты бедра и несафенные вены слева не заполнено"); test = false;
            }
            else if (RightTibiaPerforate.IsEmpty == true)
            {
                test = false;
                MessageBox.Show("Перфоранты голени справа не заполнено");
            }
            else if (LeftTibiaPerforate.IsEmpty == true)
            {
                MessageBox.Show("Перфоранты голени слева не заполнено"); test = false;
            }
            else if (RightTEMPV.IsEmpty == true)
            {
                MessageBox.Show("ТЕ МПВ справа не заполнено"); test = false;
            }
            else if (LeftTEMPV.IsEmpty == true)
            {
                MessageBox.Show("ТЕ МПВ слева не заполнено"); test = false;
            }
            else if (RightPPV.IsEmpty == true)
            {
                MessageBox.Show("ППВ справа не заполнено"); test = false;
            }
            else if (LeftPPV.IsEmpty == true)
            {
                MessageBox.Show("ППВ слева не заполнено"); test = false;
            }
            else if (string.IsNullOrWhiteSpace(RightAdditionalText))
            {
                MessageBox.Show("Примечание справа не заполнено"); test = false;
            }
            else if (string.IsNullOrWhiteSpace(LeftAdditionalText))
            {
                MessageBox.Show("Примечание слева не заполнено"); test = false;
            }
            else if (LeftCEAR.LegSections[0].SelectedValue == null)
            {
                MessageBox.Show("C слева не заполнено"); test = false;
            }
            else if (LeftCEAR.LegSections[1].SelectedValue == null)
            {
                MessageBox.Show("E слева не заполнено"); test = false;
            }
            else if (LeftCEAR.LegSections[2].SelectedValue == null)
            {
                MessageBox.Show("A слева не заполнено"); test = false;
            }
            else if (LeftCEAR.LegSections[3].SelectedValue == null)
            {
                MessageBox.Show("P слева не заполнено"); test = false;
            }

            else if (RightCEAR.LegSections[0].SelectedValue == null)
            {
                MessageBox.Show("C справа не заполнено"); test = false;
            }
            else if (RightCEAR.LegSections[1].SelectedValue == null)
            {
                MessageBox.Show("E справа не заполнено"); test = false;
            }
            else if (RightCEAR.LegSections[2].SelectedValue == null)
            {
                MessageBox.Show("A справа не заполнено"); test = false;
            }
            else if (RightCEAR.LegSections[3].SelectedValue == null)
            {
                MessageBox.Show("P справа не заполнено"); test = false;
            }
            return test;
        }
        public string CreateStrForOverview(LegPartViewModel LegPart)
        {
            string p4 = "";
            if (LegPart.SelectedWayType != null && !string.IsNullOrWhiteSpace(LegPart.SelectedWayType.Name))
                p4 += "Вид хода :" + LegPart.SelectedWayType.Name + " ";
            if (LegPart is TEMPVViewModel)
                p4 += "Протяжность :" + ((TEMPVViewModel)LegPart).FF_length + " ";


            foreach (var section in LegPart.LegSections)
            {
                if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                {
                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                        p4 += " «" + section.SelectedValue.Text1;


                    if (section.SelectedValue.HasSize || section.HasDoubleSize)
                    {
                        if (section.HasDoubleSize)
                        {
                            p4 += " " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + "»";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                p4 += " " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + "»";
                            else
                            {
                                p4 += " " + section.CurrentEntry.Size + "»";

                            }

                        }
                    }
                    else
                    {
                        p4 += "»";
                    }

                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                        p4 += " «" + section.SelectedValue.Text2 + "»";
                    if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                    {
                        p4 += " «" + section.CurrentEntry.Comment + "»";

                    }


                    //

                    //

                }
            }
            return p4;

        }
        int togleforCreateStatement = 0;
        public ViewModelAddPhysical(NavigationController controller) : base(controller)
        {
            CurrentPanelViewModel = new DoctorSelectPanelViewModel(this);
            using (var context = new MySqlContext())
            {
                DoctorRepository DoctorRep = new DoctorRepository(context);
                CurrentPanelViewModel.Doctors = new ObservableCollection<Docs>();

                foreach (var doc in DoctorRep.GetAll)
                {
                    CurrentPanelViewModel.Doctors.Add(new Docs(doc));
                }
            }
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {
                Doctor = CurrentPanelViewModel.GetPanelValue();

                CurrentPanelViewModel.PanelOpened = false;

                Handled = false;

                int togle = 0;
                // string fileName = System.IO.Path.GetTeWmpPath() + Guid.NewGuid().ToString() + ".docx";
                string fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга.docx";
                byte[] bte = Data.doc_template.Get(3).DocTemplate;
                //File.WriteAllBytes(fileName, bte);
                for (; ; )
                {
                    try
                    {

                        File.WriteAllBytes(fileName, bte);

                        break;
                    }
                    catch
                    {
                        togle += 1;
                        fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга" + togle + ".docx";
                    }
                }


                using (DocX document = DocX.Load(fileName))
                {


                    document.ReplaceText("ФИО", CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic);
                    document.ReplaceText("Возраст", CurrentPatient.Age.ToString());
                    document.ReplaceText("«ИМТ»", ITM.ToString());
                    if (!string.IsNullOrWhiteSpace(TextTip))
                        document.ReplaceText("«NB_»", TextTip);
                    else
                        document.ReplaceText("«NB_»", "");


                    document.ReplaceText("«Дата»", DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString());






                    string complanes = "";
                    if (ComplainsList != null)
                        foreach (var rec in ComplainsList)
                        {
                            if (rec.IsChecked == true)
                            {
                                complanes += " «" + rec.Data.Str + "»";

                            }
                        }
                    document.ReplaceText("«Жалобы»", complanes);

                    string lettersLeft = "";
                    string lettersRight = "";

                    using (var context = new MySqlContext())
                    {
                        ExaminationRepository ExamRep = new ExaminationRepository(context);
                        ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);
                        LettersRepository LettersRep = new LettersRepository(context);
                        var ExamsOfCurrPatient = ExamRep.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                        if (ExamsOfCurrPatient.Count > 0)
                        {
                            DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                            var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                            ExaminationLeg leftLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                            ExaminationLeg rightLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);
                            Letters bufLetter = new Letters();
                            if (LeftCEAR.LegSections[0].SelectedValue != null)
                            {
                                bufLetter = LeftCEAR.LegSections[0].SelectedValue;
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (LeftCEAR.LegSections[1].SelectedValue != null)
                            {
                                bufLetter = LeftCEAR.LegSections[1].SelectedValue;
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (LeftCEAR.LegSections[2].SelectedValue != null)
                            {
                                bufLetter = LeftCEAR.LegSections[2].SelectedValue;
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (LeftCEAR.LegSections[3].SelectedValue != null)
                            {
                                bufLetter = LeftCEAR.LegSections[3].SelectedValue;
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }

                            if (RightCEAR.LegSections[0].SelectedValue != null)
                            {
                                bufLetter = RightCEAR.LegSections[0].SelectedValue;
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (RightCEAR.LegSections[1].SelectedValue != null)
                            {
                                bufLetter = RightCEAR.LegSections[1].SelectedValue;
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (RightCEAR.LegSections[2].SelectedValue != null)
                            {
                                bufLetter = RightCEAR.LegSections[2].SelectedValue;
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (RightCEAR.LegSections[3].SelectedValue != null)
                            {
                                bufLetter = RightCEAR.LegSections[3].SelectedValue;
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }

                        }

                    }



                    document.ReplaceText("«Заключение_справа»", lettersRight);
                    document.ReplaceText("«Заключение_cлева»", lettersLeft);
                    //буквы_1
                    //буквы_2

                    document.ReplaceText("«Врач»", Doctor);

                    //область

                    document.ReplaceText("«CFCRight»", CreateStrForOverview(RightSFS));

                    document.ReplaceText("«BPVRight»", CreateStrForOverview(RightBPVHip));

                    document.ReplaceText("«ПДСВRight»", CreateStrForOverview(RightPDSV));

                    document.ReplaceText("«ЗДСВRight»", CreateStrForOverview(RightZDSV));

                    document.ReplaceText("«ПБНВRight»", CreateStrForOverview(RightPerforate));

                    document.ReplaceText("«БПВ_на_голениRight»", CreateStrForOverview(RightBPVTibia));

                    document.ReplaceText("«Перфоранты_голениRight»", CreateStrForOverview(RightTibiaPerforate));

                    document.ReplaceText("«СПСRight»", CreateStrForOverview(RightSPS));
                    document.ReplaceText("«МПВRight»", CreateStrForOverview(RightMPV));

                    document.ReplaceText("«ТЕ_МПВRight»", CreateStrForOverview(RightTEMPV));

                    document.ReplaceText("«ППВRight»", CreateStrForOverview(RightPPV));

                    document.ReplaceText("«Глубокие_веныRight»", CreateStrForOverview(RightGV));

                    document.ReplaceText("«Примечание_справа»", RightAdditionalText);






                    document.ReplaceText("«CFCLeft»", CreateStrForOverview(LeftSFS));

                    document.ReplaceText("«BPVLeft»", CreateStrForOverview(LeftBPVHip));

                    document.ReplaceText("«ПДСВLeft»", CreateStrForOverview(LeftPDSV));

                    document.ReplaceText("«ЗДСВLeft»", CreateStrForOverview(LeftZDSV));

                    document.ReplaceText("«ПБНВLeft»", CreateStrForOverview(LeftPerforate));

                    document.ReplaceText("«БПВ_на_голениLeft»", CreateStrForOverview(LeftBPVTibia));

                    document.ReplaceText("«Перфоранты_голениLeft»", CreateStrForOverview(LeftTibiaPerforate));

                    document.ReplaceText("«СПСLeft»", CreateStrForOverview(LeftSPS));

                    document.ReplaceText("«МПВLeft»", CreateStrForOverview(LeftMPV));

                    document.ReplaceText("«ТЕ_МПВLeft»", CreateStrForOverview(LeftTEMPV));

                    document.ReplaceText("«ППВLeft»", CreateStrForOverview(LeftPPV));

                    document.ReplaceText("«Глубокие_веныLeft»", CreateStrForOverview(LeftGV));

                    document.ReplaceText("«Примечание_слева»", LeftAdditionalText);

                    //
                    string recomendations = "";
                    if (RecomendationsList != null)
                        foreach (var rec in RecomendationsList)
                        {
                            if (rec.IsChecked == true)
                            {
                                recomendations += "«" + rec.Data.Str + "»";

                            }
                        }


                    document.ReplaceText("«Рекомендации»", recomendations);

                    document.Save();
                    //Release this document from memory.
                    Process.Start("WINWORD.EXE", fileName);
                }




            });
            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });
            TextTip = "";
            GVLeftstr = new List<string>();
            GVRightstr = new List<string>();


            PPVLeftstr = new List<string>();
            PPVRightstr = new List<string>();

            CEAPLeftstr = new List<string>();
            CEAPRightstr = new List<string>();
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

            IsVisibleGVleft = new ObservableCollection<Visibility>();
            IsVisibleGVRight = new ObservableCollection<Visibility>();


            IsVisiblePPVleft = new ObservableCollection<Visibility>();
            IsVisiblePPVRight = new ObservableCollection<Visibility>();

            IsVisibleCEAPleft = new ObservableCollection<Visibility>();
            IsVisibleCEAPRight = new ObservableCollection<Visibility>();

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
                IsVisibleGVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleGVRight.Add(Visibility.Collapsed);
            }


            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePPVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePPVRight.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleCEAPleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleCEAPRight.Add(Visibility.Collapsed);
            }
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

            MessageBus.Default.Subscribe("GetObsForOverview", GetObsForOverview);
            MessageBus.Default.Subscribe("ClearObsledovanie", Clear);
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

            LostFocusOnWeight = new DelegateCommand(
              () =>
              {
                  if (string.IsNullOrWhiteSpace(Weight))
                      Weight = "0";
              }
          );
            LostFocusOnGrowth = new DelegateCommand(
            () =>
            {
                if (string.IsNullOrWhiteSpace(Growth))
                    Growth = "0";
            }
        );
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

            ToPhysicalOverviewCommand = new DelegateCommand(
                () =>
                {
                    if (TestAllFIelds())
                    {
                        string docName = "";
                        //string docName = "Консультативное_заключение";
                        if (togleforCreateStatement == 0)
                            docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + ".docx";
                        else
                            docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togleforCreateStatement + ".docx";

                        for (; ; )
                        {
                            try
                            {

                                CreateStatement(docName);


                                togleforCreateStatement += 1;
                                docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togleforCreateStatement + ".docx";


                                break;
                            }
                            catch (Exception ex)
                            {
                                togleforCreateStatement += 1;
                                docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togleforCreateStatement + ".docx";
                            }
                        }




                    }
                }
            );

            ToPhysicalChirurgOverviewCommand = new DelegateCommand(
              () =>
              {
                  if (TestAllFIelds())
                  {
                      //int togle = 0;
                      //////string docName = "Консультативное_заключение";
                      //string docName = System.IO.Path.GetTempPath() + "Осмотр_хирурга" + ".docx";
                      //for (; ; )
                      //{
                      //    try
                      //    {

                      //        CreateChirurgOverview(docName);

                      //        break;
                      //    }
                      //    catch
                      //    {
                      //        togle += 1;
                      //        docName = System.IO.Path.GetTempPath() + "Осмотр_хирурга" + togle + ".docx";
                      //    }
                      //}
                      //doc_templates docTemp = new doc_templates();
                      //byte[] bte = File.ReadAllBytes(@"Осмотр_хирурга.docx");
                      //docTemp.DocTemplate = bte;
                      //Data.doc_template.Add(docTemp);
                      //Data.Complete();

                      OpenCommand.Execute();



                      //MessageBus.Default.Call("GetOperationResultForCreateStatement", this, operationId);
                      // Controller.NavigateTo<ViewModelCreateStatement>();
                  }




              }
          );


            ToSymptomsAddCommand = new DelegateCommand(
                () =>
                {



                    Controller.NavigateTo<ViewModelSymptomsAdd>();
                }
            );
            OpTypeFromDialog = 0;
            OpCommentFromDialog = "";
            MessageBus.Default.Subscribe("GetOpTypeAndCommentaryFromDialog", GetOpTypeAndCommentaryFromDialog);
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


            //PPV

            LeftPPV = new PPVViewModel(Controller, LegSide.Left);
            RightPPV = new PPVViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftPPV);
            Controller.AddLegPartVM(RightPPV);
            ToLeftPPVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPPV", this, this);
                    Controller.LegViewModel = LeftPPV;
                    Controller.NavigateTo<PPVViewModel>(LegSide.Left);
                }
            );

            ToRightPPVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstPPV", this, this);
                    Controller.LegViewModel = RightPPV;
                    Controller.NavigateTo<PPVViewModel>(LegSide.Right);
                }
            );
            //GV

            LeftGV = new GVViewModel(Controller, LegSide.Left);
            RightGV = new GVViewModel(Controller, LegSide.Right);
            Controller.AddLegPartVM(LeftGV);
            Controller.AddLegPartVM(RightGV);
            ToLeftGVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstGV", this, this);
                    Controller.LegViewModel = LeftGV;
                    Controller.NavigateTo<GVViewModel>(LegSide.Left);
                }
            );

            ToRightGVCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("RebuildFirstGV", this, this);
                    Controller.LegViewModel = RightGV;
                    Controller.NavigateTo<GVViewModel>(LegSide.Right);
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

            // //CEAP

            LeftCEAR = new LettersViewModel(Controller, LegSide.Left);
            RightCEAR = new LettersViewModel(Controller, LegSide.Right);

            Controller.AddLegPartVM(LeftCEAR);
            Controller.AddLegPartVM(RightCEAR);

            ToLeftCEARCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.LegViewModel = LeftCEAR;
                    MessageBus.Default.Call("RebuildFirstCEAP", this, null);
                    Controller.NavigateTo<LettersViewModel>(LegSide.Left);
                }
            );

            ToRightCEARCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.LegViewModel = RightCEAR;
                    MessageBus.Default.Call("RebuildFirstCEAP", this, null);
                    Controller.NavigateTo<LettersViewModel>(LegSide.Right);
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
            LostOnTextTip = new DelegateCommand(
                () =>
                {
                    if (string.IsNullOrWhiteSpace(TextTip))
                        TextTip = "Текст пометки";
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

            RightBPV_TibiaEntryFull = new BPV_TibiaEntryFull();
            LeftBPV_TibiaEntryFull = new BPV_TibiaEntryFull();
            RightPerforate_hipEntryFull = new Perforate_hipEntryFull();
            LeftPerforate_hipEntryFull = new Perforate_hipEntryFull();
            RightZDSVEntryFull = new ZDSVEntryFull();
            LeftZDSVEntryFull = new ZDSVEntryFull();
            RightPDSVEntryFull = new PDSVHipEntryFull();
            LeftPDSVEntryFull = new PDSVHipEntryFull();
            RightBPVEntryFull = new BPVHipEntryFull();
            LeftBPVEntryFull = new BPVHipEntryFull();
            RightSFSEntryFull = new SFSHipEntryFull();
            LeftSFSEntryFull = new SFSHipEntryFull();
            RightSPSEntryFull = new SPSHipEntryFull();
            LeftSPSEntryFull = new SPSHipEntryFull();
            RightPerforate_shinEntryFull = new Perforate_shinEntryFull();
            LeftPerforate_shinEntryFull = new Perforate_shinEntryFull();
            RightTEMPVEntryFull = new TEMPVEntryFull();
            LeftTEMPVEntryFull = new TEMPVEntryFull();
            RightMPVEntryFull = new MPVEntryFull();
            LeftMPVEntryFull = new MPVEntryFull();
            RightPPVEntryFull = new PPVEntryFull();
            LeftPPVEntryFull = new PPVEntryFull();
            RightGVEntryFull = new GVEntryFull();
            LeftGVEntryFull = new GVEntryFull();

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


            RightPPVEntryFull = (PPVEntryFull)SaveFullEntry(RightPPV, RightPPVEntryFull);
            LeftPPVEntryFull = (PPVEntryFull)SaveFullEntry(LeftPPV, LeftPPVEntryFull);

            RightGVEntryFull = (GVEntryFull)SaveFullEntry(RightGV, RightGVEntryFull);
            LeftGVEntryFull = (GVEntryFull)SaveFullEntry(LeftGV, LeftGVEntryFull);


            bool test = true;
            if (!RightBPVHip.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.BPVHipsFull.GetAll)
                {
                    if (hfull.EntryId1 == RightBPVEntryFull.EntryId1
                    && hfull.EntryId2 == RightBPVEntryFull.EntryId2
                    && hfull.EntryId3 == RightBPVEntryFull.EntryId3
                    && hfull.EntryId4 == RightBPVEntryFull.EntryId4
                    && hfull.EntryId5 == RightBPVEntryFull.EntryId5
                    && hfull.WayID == RightBPVEntryFull.WayID)
                    {
                        test = false;
                        RightBPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.BPVHipsFull.Add(RightBPVEntryFull);
                    Data.Complete();
                }
            }


            if (!RightBPVTibia.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.BPV_TibiaFull.GetAll)
                {
                    if (hfull.EntryId1 == RightBPV_TibiaEntryFull.EntryId1
                    && hfull.EntryId2 == RightBPV_TibiaEntryFull.EntryId2
                    && hfull.EntryId3 == RightBPV_TibiaEntryFull.EntryId3
                    && hfull.EntryId4 == RightBPV_TibiaEntryFull.EntryId4)
                    {
                        test = false;
                        RightBPV_TibiaEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.BPV_TibiaFull.Add(RightBPV_TibiaEntryFull);
                    Data.Complete();
                }

            }

            if (!RightGV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.GVFull.GetAll)
                {
                    if (hfull.EntryId1 == RightGVEntryFull.EntryId1
                    && hfull.EntryId2 == RightGVEntryFull.EntryId2)
                    {
                        test = false;
                        RightGVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.GVFull.Add(RightGVEntryFull);
                    Data.Complete();
                }
            }

            if (!RightMPV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.MPVFull.GetAll)
                {
                    if (hfull.EntryId1 == RightMPVEntryFull.EntryId1
                    && hfull.EntryId2 == RightMPVEntryFull.EntryId2
                    && hfull.EntryId3 == RightMPVEntryFull.EntryId3
                    && hfull.EntryId4 == RightMPVEntryFull.EntryId4
                    && hfull.WayID == RightMPVEntryFull.WayID)
                    {
                        test = false;
                        RightMPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.MPVFull.Add(RightMPVEntryFull);
                    Data.Complete();

                }
            }

            if (!RightPDSV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.PDSVFull.GetAll)
                {
                    if (hfull.EntryId1 == RightPDSVEntryFull.EntryId1
                    && hfull.EntryId2 == RightPDSVEntryFull.EntryId2
                    && hfull.EntryId3 == RightPDSVEntryFull.EntryId3
                    && hfull.WayID == RightPDSVEntryFull.WayID)
                    {
                        test = false;
                        RightPDSVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.PDSVFull.Add(RightPDSVEntryFull);
                    Data.Complete();

                }
            }
            if (!RightPerforate.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.Perforate_hipFull.GetAll)
                {
                    if (hfull.EntryId1 == RightPerforate_hipEntryFull.EntryId1
                    && hfull.EntryId2 == RightPerforate_hipEntryFull.EntryId2
                    && hfull.EntryId3 == RightPerforate_hipEntryFull.EntryId3
                    && hfull.EntryId4 == RightPerforate_hipEntryFull.EntryId4
                    && hfull.EntryId5 == RightPerforate_hipEntryFull.EntryId5)
                    {
                        test = false;
                        RightPerforate_hipEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.Perforate_hipFull.Add(RightPerforate_hipEntryFull);
                    Data.Complete();

                }
            }
            if (!RightPPV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.PPVFull.GetAll)
                {
                    if (hfull.EntryId1 == RightPPVEntryFull.EntryId1
                    && hfull.EntryId2 == RightPPVEntryFull.EntryId2)
                    {
                        test = false;
                        RightPPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.PPVFull.Add(RightPPVEntryFull);
                    Data.Complete();

                }
            }

            if (!RightSFS.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.SFSFull.GetAll)
                {
                    if (hfull.EntryId1 == RightSFSEntryFull.EntryId1
                    && hfull.EntryId2 == RightSFSEntryFull.EntryId2
                    && hfull.EntryId3 == RightSFSEntryFull.EntryId3
                    && hfull.EntryId4 == RightSFSEntryFull.EntryId4
                    && hfull.EntryId5 == RightSFSEntryFull.EntryId5
                    && hfull.EntryId6 == RightSFSEntryFull.EntryId6)
                    {
                        test = false;
                        RightSFSEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.SFSFull.Add(RightSFSEntryFull);
                    Data.Complete();

                }
            }

            if (!RightSPS.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.SPSHipFull.GetAll)
                {
                    if (hfull.EntryId1 == RightSPSEntryFull.EntryId1
                    && hfull.EntryId2 == RightSPSEntryFull.EntryId2
                    && hfull.EntryId3 == RightSPSEntryFull.EntryId3)
                    {
                        test = false;
                        RightSPSEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.SPSHipFull.Add(RightSPSEntryFull);
                    Data.Complete();

                }
            }
            if (!RightTEMPV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.TEMPVFull.GetAll)
                {
                    if (hfull.EntryId1 == RightTEMPVEntryFull.EntryId1
                    && hfull.EntryId2 == RightTEMPVEntryFull.EntryId2
                    && hfull.EntryId3 == RightTEMPVEntryFull.EntryId3
                    && hfull.WayID == RightTEMPVEntryFull.WayID
                    && hfull.FF_Length == RightTEMPVEntryFull.FF_Length)
                    {
                        test = false;
                        RightTEMPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.TEMPVFull.Add(RightTEMPVEntryFull);
                    Data.Complete();

                }
            }

            if (!RightTibiaPerforate.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.Perforate_shinFull.GetAll)
                {
                    if (hfull.EntryId1 == RightPerforate_shinEntryFull.EntryId1
                    && hfull.EntryId2 == RightPerforate_shinEntryFull.EntryId2
                    && hfull.EntryId3 == RightPerforate_shinEntryFull.EntryId3
                    && hfull.EntryId4 == RightPerforate_shinEntryFull.EntryId4
                    && hfull.EntryId5 == RightPerforate_shinEntryFull.EntryId5)
                    {
                        test = false;
                        RightPerforate_shinEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.Perforate_shinFull.Add(RightPerforate_shinEntryFull);
                    Data.Complete();

                }
            }

            if (!RightZDSV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.ZDSVFull.GetAll)
                {
                    if (hfull.EntryId1 == RightZDSVEntryFull.EntryId1
                    && hfull.EntryId2 == RightZDSVEntryFull.EntryId2
                    && hfull.EntryId3 == RightZDSVEntryFull.EntryId3)
                    {
                        test = false;
                        RightZDSVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.ZDSVFull.Add(RightZDSVEntryFull);
                    Data.Complete();
                }
            }
            //if (!LeftBPVHip.IsEmpty)
            //    Data.BPVHipsFull.Add(LeftBPVEntryFull);

            //if (!LeftBPVTibia.IsEmpty)
            //    Data.BPV_TibiaFull.Add(LeftBPV_TibiaEntryFull);


            //if (!LeftGV.IsEmpty)
            //    Data.GVFull.Add(LeftGVEntryFull);

            //if (!LeftMPV.IsEmpty)
            //    Data.MPVFull.Add(LeftMPVEntryFull);

            //if (!LeftPDSV.IsEmpty)
            //    Data.PDSVFull.Add(LeftPDSVEntryFull);

            //if (!LeftPerforate.IsEmpty)
            //    Data.Perforate_hipFull.Add(LeftPerforate_hipEntryFull);

            //if (!LeftPPV.IsEmpty)
            //    Data.PPVFull.Add(LeftPPVEntryFull);

            //if (!LeftSFS.IsEmpty)
            //    Data.SFSFull.Add(LeftSFSEntryFull);

            //if (!LeftSPS.IsEmpty)
            //    Data.SPSHipFull.Add(LeftSPSEntryFull);

            //if (!LeftTEMPV.IsEmpty)
            //    Data.TEMPVFull.Add(LeftTEMPVEntryFull);

            //if (!LeftTibiaPerforate.IsEmpty)
            //    Data.Perforate_shinFull.Add(LeftPerforate_shinEntryFull);

            //if (!LeftZDSV.IsEmpty)
            //    Data.ZDSVFull.Add(LeftZDSVEntryFull);

            if (!LeftBPVHip.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.BPVHipsFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftBPVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftBPVEntryFull.EntryId2
                    && hfull.EntryId3 == LeftBPVEntryFull.EntryId3
                    && hfull.EntryId4 == LeftBPVEntryFull.EntryId4
                    && hfull.EntryId5 == LeftBPVEntryFull.EntryId5
                    && hfull.WayID == LeftBPVEntryFull.WayID)
                    {
                        test = false;
                        LeftBPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.BPVHipsFull.Add(LeftBPVEntryFull);
                    Data.Complete();

                }
            }
            if (!LeftBPVTibia.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.BPV_TibiaFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftBPV_TibiaEntryFull.EntryId1
                    && hfull.EntryId2 == LeftBPV_TibiaEntryFull.EntryId2
                    && hfull.EntryId3 == LeftBPV_TibiaEntryFull.EntryId3
                    && hfull.EntryId4 == LeftBPV_TibiaEntryFull.EntryId4)
                    {
                        test = false;
                        LeftBPV_TibiaEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.BPV_TibiaFull.Add(LeftBPV_TibiaEntryFull);
                    Data.Complete();

                }
            }

            if (!LeftGV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.GVFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftGVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftGVEntryFull.EntryId2)
                    {
                        test = false;
                        LeftGVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.GVFull.Add(LeftGVEntryFull);
                    Data.Complete();

                }
            }

            if (!LeftMPV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.MPVFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftMPVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftMPVEntryFull.EntryId2
                    && hfull.EntryId3 == LeftMPVEntryFull.EntryId3
                    && hfull.EntryId4 == LeftMPVEntryFull.EntryId4
                    && hfull.WayID == LeftMPVEntryFull.WayID)
                    {
                        test = false;
                        LeftMPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.MPVFull.Add(LeftMPVEntryFull);
                    Data.Complete();

                }
            }

            if (!LeftPDSV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.PDSVFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftPDSVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftPDSVEntryFull.EntryId2
                    && hfull.EntryId3 == LeftPDSVEntryFull.EntryId3
                    && hfull.WayID == LeftPDSVEntryFull.WayID)
                    {
                        test = false;
                        LeftPDSVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.PDSVFull.Add(LeftPDSVEntryFull);

                    Data.Complete();
                }
            }
            if (!LeftPerforate.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.Perforate_hipFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftPerforate_hipEntryFull.EntryId1
                    && hfull.EntryId2 == LeftPerforate_hipEntryFull.EntryId2
                    && hfull.EntryId3 == LeftPerforate_hipEntryFull.EntryId3
                    && hfull.EntryId4 == LeftPerforate_hipEntryFull.EntryId4
                    && hfull.EntryId5 == LeftPerforate_hipEntryFull.EntryId5)
                    {
                        test = false;
                        LeftPerforate_hipEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.Perforate_hipFull.Add(LeftPerforate_hipEntryFull);
                    Data.Complete();

                }
            }
            if (!LeftPPV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.PPVFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftPPVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftPPVEntryFull.EntryId2)
                    {
                        test = false;
                        LeftPPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.PPVFull.Add(LeftPPVEntryFull);
                    Data.Complete();

                }
            }

            if (!LeftSFS.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.SFSFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftSFSEntryFull.EntryId1
                    && hfull.EntryId2 == LeftSFSEntryFull.EntryId2
                    && hfull.EntryId3 == LeftSFSEntryFull.EntryId3
                    && hfull.EntryId4 == LeftSFSEntryFull.EntryId4
                    && hfull.EntryId5 == LeftSFSEntryFull.EntryId5
                    && hfull.EntryId6 == LeftSFSEntryFull.EntryId6)
                    {
                        test = false;
                        LeftSFSEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.SFSFull.Add(LeftSFSEntryFull);
                    Data.Complete();

                }
            }

            if (!LeftSPS.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.SPSHipFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftSPSEntryFull.EntryId1
                    && hfull.EntryId2 == LeftSPSEntryFull.EntryId2
                    && hfull.EntryId3 == LeftSPSEntryFull.EntryId3)
                    {
                        test = false;
                        LeftSPSEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.SPSHipFull.Add(LeftSPSEntryFull);
                    Data.Complete();

                }
            }
            if (!LeftTEMPV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.TEMPVFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftTEMPVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftTEMPVEntryFull.EntryId2
                    && hfull.EntryId3 == LeftTEMPVEntryFull.EntryId3
                    && hfull.WayID == LeftTEMPVEntryFull.WayID
                    && hfull.FF_Length == LeftTEMPVEntryFull.FF_Length)
                    {
                        test = false;
                        LeftTEMPVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.TEMPVFull.Add(LeftTEMPVEntryFull);

                    Data.Complete();
                }
            }

            if (!LeftTibiaPerforate.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.Perforate_shinFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftPerforate_shinEntryFull.EntryId1
                    && hfull.EntryId2 == LeftPerforate_shinEntryFull.EntryId2
                    && hfull.EntryId3 == LeftPerforate_shinEntryFull.EntryId3
                    && hfull.EntryId4 == LeftPerforate_shinEntryFull.EntryId4
                    && hfull.EntryId5 == LeftPerforate_shinEntryFull.EntryId5)
                    {
                        test = false;
                        LeftPerforate_shinEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.Perforate_shinFull.Add(LeftPerforate_shinEntryFull);
                    Data.Complete();

                }
            }

            if (!LeftZDSV.IsEmpty)
            {
                test = true;
                foreach (var hfull in Data.ZDSVFull.GetAll)
                {
                    if (hfull.EntryId1 == LeftZDSVEntryFull.EntryId1
                    && hfull.EntryId2 == LeftZDSVEntryFull.EntryId2
                    && hfull.EntryId3 == LeftZDSVEntryFull.EntryId3)
                    {
                        test = false;
                        LeftZDSVEntryFull = hfull;
                        break;
                    }
                }
                if (test)
                {
                    Data.ZDSVFull.Add(LeftZDSVEntryFull);
                    Data.Complete();

                }
            }

            //Data.Complete();

        }

        private void GetLegPartFromEntry(LegPartEntries FullEntry, LegPartViewModel Part, bool isLeft)
        {

            using (var context = new MySqlContext())
            {
                PDSVHipEntryRepository PDSVEntryRep = new PDSVHipEntryRepository(context);
                PDSVHipRepository PDSVStructRep = new PDSVHipRepository(context);
                SFSHipEntryRepository SFSEntryRep = new SFSHipEntryRepository(context);
                SFSHipRepository SFSStructRep = new SFSHipRepository(context);
                BPVHipEntryRepository BPVHipEntryRep = new BPVHipEntryRepository(context);
                BPVHipRepository BPVHipStructRep = new BPVHipRepository(context);
                Perforate_hipEntryRepository Perforate_hipEntryRep = new Perforate_hipEntryRepository(context);
                Perforate_hipRepository Perforate_hipStructRep = new Perforate_hipRepository(context);
                ZDSVEntryRepository ZDSVEntryRep = new ZDSVEntryRepository(context);
                ZDSVRepository ZDSVStructRep = new ZDSVRepository(context);
                BPV_TibiaEntryRepository BPVTibiaEntryRep = new BPV_TibiaEntryRepository(context);
                BPV_TibiaRepository BPVTibiaStructRep = new BPV_TibiaRepository(context);
                SPSHipEntryRepository SPSEntryRep = new SPSHipEntryRepository(context);
                SPSHipRepository SPSStructRep = new SPSHipRepository(context);
                Perforate_shinEntryRepository Perforate_shinEntryRep = new Perforate_shinEntryRepository(context);
                Perforate_shinRepository Perforate_shinStructRep = new Perforate_shinRepository(context);
                MPVEntryRepository MPVEntryRep = new MPVEntryRepository(context);
                MPVRepository MPVStructRep = new MPVRepository(context);
                TEMPVEntryRepository TEMPVEntryRep = new TEMPVEntryRepository(context);
                TEMPVRepository TEMPVStructRep = new TEMPVRepository(context);
                GVEntryRepository GVEntryRep = new GVEntryRepository(context);
                GVRepository GVStructRep = new GVRepository(context);
                PPVEntryRepository PPVEntryRep = new PPVEntryRepository(context);
                PPVRepository PPVStructRep = new PPVRepository(context);

                if (isLeft)
                {

                    if (Part is PDSVViewModel)
                    {
                        if (PDSVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftPDSV.LegSections[0].CurrentEntry = PDSVEntryRep.Get(FullEntry.EntryId1);
                            LeftPDSV.LegSections[0].SelectedValue = PDSVStructRep.Get(LeftPDSV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftPDSV.LegSections[1].CurrentEntry = PDSVEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftPDSV.LegSections[1].SelectedValue = PDSVStructRep.Get(LeftPDSV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftPDSV.LegSections[2].CurrentEntry = PDSVEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftPDSV.LegSections[2].SelectedValue = PDSVStructRep.Get(LeftPDSV.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.WayID != null)
                            LeftPDSV.SelectedWayType = LeftPDSV.PDSVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                        LeftPDSV.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftPDSV);
                        PDSVLeftstr = result.stringList;
                        IsVisiblePDSVleft = result.listVisibility;


                    }
                    else if (Part is SFSViewModel)
                    {



                        if (SFSEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftSFS.LegSections[0].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId1);
                            LeftSFS.LegSections[0].SelectedValue = SFSStructRep.Get(LeftSFS.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftSFS.LegSections[1].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftSFS.LegSections[1].SelectedValue = SFSStructRep.Get(LeftSFS.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftSFS.LegSections[2].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftSFS.LegSections[2].SelectedValue = SFSStructRep.Get(LeftSFS.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            LeftSFS.LegSections[3].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId4.Value);
                            LeftSFS.LegSections[3].SelectedValue = SFSStructRep.Get(LeftSFS.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            LeftSFS.LegSections[4].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId5.Value);
                            LeftSFS.LegSections[4].SelectedValue = SFSStructRep.Get(LeftSFS.LegSections[4].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId6 != null)
                        {
                            LeftSFS.LegSections[5].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId6.Value);
                            LeftSFS.LegSections[5].SelectedValue = SFSStructRep.Get(LeftSFS.LegSections[5].CurrentEntry.StructureID);

                        }

                        LeftSFS.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftSFS);
                        SFSLeftstr = result.stringList;
                        IsVisibleSFSleft = result.listVisibility;

                    }
                    else if (Part is BPVHipViewModel)
                    {



                        if (BPVHipEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftBPVHip.LegSections[0].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId1);
                            LeftBPVHip.LegSections[0].SelectedValue = BPVHipStructRep.Get(LeftBPVHip.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftBPVHip.LegSections[1].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftBPVHip.LegSections[1].SelectedValue = BPVHipStructRep.Get(LeftBPVHip.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftBPVHip.LegSections[2].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftBPVHip.LegSections[2].SelectedValue = BPVHipStructRep.Get(LeftBPVHip.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            LeftBPVHip.LegSections[3].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId4.Value);
                            LeftBPVHip.LegSections[3].SelectedValue = BPVHipStructRep.Get(LeftBPVHip.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            LeftBPVHip.LegSections[4].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId5.Value);
                            LeftBPVHip.LegSections[4].SelectedValue = BPVHipStructRep.Get(LeftBPVHip.LegSections[4].CurrentEntry.StructureID);

                        }

                        if (FullEntry.WayID != null)
                            LeftBPVHip.SelectedWayType = LeftBPVHip.BpvWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                        LeftBPVHip.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftBPVHip);
                        BpvLeftstr = result.stringList;
                        IsVisibleBPVleft = result.listVisibility;

                    }
                    else if (Part is BPVTibiaViewModel)
                    {


                        if (BPVTibiaEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftBPVTibia.LegSections[0].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId1);
                            LeftBPVTibia.LegSections[0].SelectedValue = BPVTibiaStructRep.Get(LeftBPVTibia.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftBPVTibia.LegSections[1].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftBPVTibia.LegSections[1].SelectedValue = BPVTibiaStructRep.Get(LeftBPVTibia.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftBPVTibia.LegSections[2].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftBPVTibia.LegSections[2].SelectedValue = BPVTibiaStructRep.Get(LeftBPVTibia.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            LeftBPVTibia.LegSections[3].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId4.Value);
                            LeftBPVTibia.LegSections[3].SelectedValue = BPVTibiaStructRep.Get(LeftBPVTibia.LegSections[3].CurrentEntry.StructureID);

                        }


                        LeftBPVTibia.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftBPVTibia);
                        BPV_TibiaLeftstr = result.stringList;
                        IsVisibleBPV_Tibialeft = result.listVisibility;

                    }
                    else if (Part is HipPerforateViewModel)
                    {



                        if (Perforate_hipEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftPerforate.LegSections[0].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId1);
                            LeftPerforate.LegSections[0].SelectedValue = Perforate_hipStructRep.Get(LeftPerforate.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftPerforate.LegSections[1].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftPerforate.LegSections[1].SelectedValue = Perforate_hipStructRep.Get(LeftPerforate.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftPerforate.LegSections[2].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftPerforate.LegSections[2].SelectedValue = Perforate_hipStructRep.Get(LeftPerforate.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            LeftPerforate.LegSections[3].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId4.Value);
                            LeftPerforate.LegSections[3].SelectedValue = Perforate_hipStructRep.Get(LeftPerforate.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            LeftPerforate.LegSections[4].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId5.Value);
                            LeftPerforate.LegSections[4].SelectedValue = Perforate_hipStructRep.Get(LeftPerforate.LegSections[4].CurrentEntry.StructureID);

                        }


                        LeftPerforate.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftPerforate);
                        Perforate_hipLeftstr = result.stringList;
                        IsVisiblePerforateHIPleft = result.listVisibility;

                    }
                    else if (Part is ZDSVViewModel)
                    {



                        if (ZDSVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftZDSV.LegSections[0].CurrentEntry = ZDSVEntryRep.Get(FullEntry.EntryId1);
                            LeftZDSV.LegSections[0].SelectedValue = ZDSVStructRep.Get(LeftZDSV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftZDSV.LegSections[1].CurrentEntry = ZDSVEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftZDSV.LegSections[1].SelectedValue = ZDSVStructRep.Get(LeftZDSV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftZDSV.LegSections[2].CurrentEntry = ZDSVEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftZDSV.LegSections[2].SelectedValue = ZDSVStructRep.Get(LeftZDSV.LegSections[2].CurrentEntry.StructureID);

                        }
                        LeftZDSV.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftZDSV);
                        ZDSVLeftstr = result.stringList;
                        IsVisibleZDSVleft = result.listVisibility;

                    }
                    else if (Part is SPSViewModel)
                    {



                        if (SPSEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftSPS.LegSections[0].CurrentEntry = SPSEntryRep.Get(FullEntry.EntryId1);
                            LeftSPS.LegSections[0].SelectedValue = SPSStructRep.Get(LeftSPS.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftSPS.LegSections[1].CurrentEntry = SPSEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftSPS.LegSections[1].SelectedValue = SPSStructRep.Get(LeftSPS.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftSPS.LegSections[2].CurrentEntry = SPSEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftSPS.LegSections[2].SelectedValue = SPSStructRep.Get(LeftSPS.LegSections[2].CurrentEntry.StructureID);

                        }

                        LeftSPS.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftSPS);
                        SPSLeftstr = result.stringList;
                        IsVisibleSPSleft = result.listVisibility;

                    }
                    else if (Part is TibiaPerforateViewModel)
                    {



                        if (Perforate_shinEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftTibiaPerforate.LegSections[0].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId1);
                            LeftTibiaPerforate.LegSections[0].SelectedValue = Perforate_shinStructRep.Get(LeftTibiaPerforate.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftTibiaPerforate.LegSections[1].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftTibiaPerforate.LegSections[1].SelectedValue = Perforate_shinStructRep.Get(LeftTibiaPerforate.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftTibiaPerforate.LegSections[2].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftTibiaPerforate.LegSections[2].SelectedValue = Perforate_shinStructRep.Get(LeftTibiaPerforate.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            LeftTibiaPerforate.LegSections[3].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId4.Value);
                            LeftTibiaPerforate.LegSections[3].SelectedValue = Perforate_shinStructRep.Get(LeftTibiaPerforate.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            LeftTibiaPerforate.LegSections[4].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId5.Value);
                            LeftTibiaPerforate.LegSections[4].SelectedValue = Perforate_shinStructRep.Get(LeftTibiaPerforate.LegSections[4].CurrentEntry.StructureID);

                        }

                        LeftTibiaPerforate.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftTibiaPerforate);
                        Perforate_shinLeftstr = result.stringList;
                        IsVisiblePerforate_shinleft = result.listVisibility;

                    }
                    else if (Part is MPVViewModel)
                    {



                        if (MPVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftMPV.LegSections[0].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId1);
                            LeftMPV.LegSections[0].SelectedValue = MPVStructRep.Get(LeftMPV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftMPV.LegSections[1].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftMPV.LegSections[1].SelectedValue = MPVStructRep.Get(LeftMPV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftMPV.LegSections[2].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftMPV.LegSections[2].SelectedValue = MPVStructRep.Get(LeftMPV.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            LeftMPV.LegSections[3].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId4.Value);
                            LeftMPV.LegSections[3].SelectedValue = MPVStructRep.Get(LeftMPV.LegSections[3].CurrentEntry.StructureID);

                        }


                        if (FullEntry.WayID != null)
                            LeftMPV.SelectedWayType = LeftMPV.MPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];

                        LeftMPV.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftMPV);
                        MPVLeftstr = result.stringList;
                        IsVisibleMPVleft = result.listVisibility;

                    }
                    else if (Part is TEMPVViewModel)
                    {



                        if (TEMPVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftTEMPV.LegSections[0].CurrentEntry = TEMPVEntryRep.Get(FullEntry.EntryId1);
                            LeftTEMPV.LegSections[0].SelectedValue = TEMPVStructRep.Get(LeftTEMPV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftTEMPV.LegSections[1].CurrentEntry = TEMPVEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftTEMPV.LegSections[1].SelectedValue = TEMPVStructRep.Get(LeftTEMPV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            LeftTEMPV.LegSections[2].CurrentEntry = TEMPVEntryRep.Get(FullEntry.EntryId3.Value);
                            LeftTEMPV.LegSections[2].SelectedValue = TEMPVStructRep.Get(LeftTEMPV.LegSections[2].CurrentEntry.StructureID);

                        }

                        if (FullEntry.WayID != null)
                            LeftTEMPV.SelectedWayType = LeftTEMPV.TEMPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];

                        LeftTEMPV.FF_length = ((TEMPVEntryFull)FullEntry).FF_Length;
                        LeftTEMPV.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftTEMPV);
                        TEMPVLeftstr = result.stringList;
                        IsVisibleTEMPVleft = result.listVisibility;

                    }
                    else if (Part is GVViewModel)
                    {



                        if (GVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftGV.LegSections[0].CurrentEntry = GVEntryRep.Get(FullEntry.EntryId1);
                            LeftGV.LegSections[0].SelectedValue = GVStructRep.Get(LeftGV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftGV.LegSections[1].CurrentEntry = GVEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftGV.LegSections[1].SelectedValue = GVStructRep.Get(LeftGV.LegSections[1].CurrentEntry.StructureID);

                        }



                        LeftGV.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftGV);
                        GVLeftstr = result.stringList;
                        IsVisibleGVleft = result.listVisibility;

                    }
                    else if (Part is PPVViewModel)
                    {



                        if (PPVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            LeftPPV.LegSections[0].CurrentEntry = PPVEntryRep.Get(FullEntry.EntryId1);
                            LeftPPV.LegSections[0].SelectedValue = PPVStructRep.Get(LeftPPV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            LeftPPV.LegSections[1].CurrentEntry = PPVEntryRep.Get(FullEntry.EntryId2.Value);
                            LeftPPV.LegSections[1].SelectedValue = PPVStructRep.Get(LeftPPV.LegSections[1].CurrentEntry.StructureID);

                        }


                        LeftPPV.IsEmpty = false;
                        SaveSet result = SaveViewModel(LeftPPV);
                        PPVLeftstr = result.stringList;
                        IsVisiblePPVleft = result.listVisibility;

                    }

                }
                else
                {
                    if (Part is PDSVViewModel)
                    {
                        if (PDSVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightPDSV.LegSections[0].CurrentEntry = PDSVEntryRep.Get(FullEntry.EntryId1);
                            RightPDSV.LegSections[0].SelectedValue = PDSVStructRep.Get(RightPDSV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightPDSV.LegSections[1].CurrentEntry = PDSVEntryRep.Get(FullEntry.EntryId2.Value);
                            RightPDSV.LegSections[1].SelectedValue = PDSVStructRep.Get(RightPDSV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightPDSV.LegSections[2].CurrentEntry = PDSVEntryRep.Get(FullEntry.EntryId3.Value);
                            RightPDSV.LegSections[2].SelectedValue = PDSVStructRep.Get(RightPDSV.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.WayID != null)
                            RightPDSV.SelectedWayType = RightPDSV.PDSVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                        RightPDSV.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightPDSV);
                        PDSVRightstr = result.stringList;
                        IsVisiblePDSVright = result.listVisibility;


                    }
                    else if (Part is SFSViewModel)
                    {



                        if (SFSEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightSFS.LegSections[0].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId1);
                            RightSFS.LegSections[0].SelectedValue = SFSStructRep.Get(RightSFS.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightSFS.LegSections[1].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId2.Value);
                            RightSFS.LegSections[1].SelectedValue = SFSStructRep.Get(RightSFS.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightSFS.LegSections[2].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId3.Value);
                            RightSFS.LegSections[2].SelectedValue = SFSStructRep.Get(RightSFS.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            RightSFS.LegSections[3].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId4.Value);
                            RightSFS.LegSections[3].SelectedValue = SFSStructRep.Get(RightSFS.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            RightSFS.LegSections[4].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId5.Value);
                            RightSFS.LegSections[4].SelectedValue = SFSStructRep.Get(RightSFS.LegSections[4].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId6 != null)
                        {
                            RightSFS.LegSections[5].CurrentEntry = SFSEntryRep.Get(FullEntry.EntryId6.Value);
                            RightSFS.LegSections[5].SelectedValue = SFSStructRep.Get(RightSFS.LegSections[5].CurrentEntry.StructureID);

                        }

                        RightSFS.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightSFS);
                        SFSRightstr = result.stringList;
                        IsVisibleSFSRight = result.listVisibility;

                    }
                    else if (Part is BPVHipViewModel)
                    {



                        if (BPVHipEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightBPVHip.LegSections[0].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId1);
                            RightBPVHip.LegSections[0].SelectedValue = BPVHipStructRep.Get(RightBPVHip.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightBPVHip.LegSections[1].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId2.Value);
                            RightBPVHip.LegSections[1].SelectedValue = BPVHipStructRep.Get(RightBPVHip.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightBPVHip.LegSections[2].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId3.Value);
                            RightBPVHip.LegSections[2].SelectedValue = BPVHipStructRep.Get(RightBPVHip.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            RightBPVHip.LegSections[3].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId4.Value);
                            RightBPVHip.LegSections[3].SelectedValue = BPVHipStructRep.Get(RightBPVHip.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            RightBPVHip.LegSections[4].CurrentEntry = BPVHipEntryRep.Get(FullEntry.EntryId5.Value);
                            RightBPVHip.LegSections[4].SelectedValue = BPVHipStructRep.Get(RightBPVHip.LegSections[4].CurrentEntry.StructureID);

                        }

                        if (FullEntry.WayID != null)
                            RightBPVHip.SelectedWayType = RightBPVHip.BpvWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                        RightBPVHip.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightBPVHip);
                        BpvRightstr = result.stringList;
                        IsVisibleBPVRight = result.listVisibility;

                    }
                    else if (Part is BPVTibiaViewModel)
                    {


                        if (BPVTibiaEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightBPVTibia.LegSections[0].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId1);
                            RightBPVTibia.LegSections[0].SelectedValue = BPVTibiaStructRep.Get(RightBPVTibia.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightBPVTibia.LegSections[1].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId2.Value);
                            RightBPVTibia.LegSections[1].SelectedValue = BPVTibiaStructRep.Get(RightBPVTibia.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightBPVTibia.LegSections[2].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId3.Value);
                            RightBPVTibia.LegSections[2].SelectedValue = BPVTibiaStructRep.Get(RightBPVTibia.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            RightBPVTibia.LegSections[3].CurrentEntry = BPVTibiaEntryRep.Get(FullEntry.EntryId4.Value);
                            RightBPVTibia.LegSections[3].SelectedValue = BPVTibiaStructRep.Get(RightBPVTibia.LegSections[3].CurrentEntry.StructureID);

                        }


                        RightBPVTibia.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightBPVTibia);
                        BPV_TibiaRightstr = result.stringList;
                        IsVisibleBPV_Tibiaright = result.listVisibility;

                    }
                    else if (Part is HipPerforateViewModel)
                    {



                        if (Perforate_hipEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightPerforate.LegSections[0].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId1);
                            RightPerforate.LegSections[0].SelectedValue = Perforate_hipStructRep.Get(RightPerforate.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightPerforate.LegSections[1].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId2.Value);
                            RightPerforate.LegSections[1].SelectedValue = Perforate_hipStructRep.Get(RightPerforate.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightPerforate.LegSections[2].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId3.Value);
                            RightPerforate.LegSections[2].SelectedValue = Perforate_hipStructRep.Get(RightPerforate.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            RightPerforate.LegSections[3].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId4.Value);
                            RightPerforate.LegSections[3].SelectedValue = Perforate_hipStructRep.Get(RightPerforate.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            RightPerforate.LegSections[4].CurrentEntry = Perforate_hipEntryRep.Get(FullEntry.EntryId5.Value);
                            RightPerforate.LegSections[4].SelectedValue = Perforate_hipStructRep.Get(RightPerforate.LegSections[4].CurrentEntry.StructureID);

                        }


                        RightPerforate.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightPerforate);
                        Perforate_hipRightstr = result.stringList;
                        IsVisiblePerforateHIPright = result.listVisibility;

                    }
                    else if (Part is ZDSVViewModel)
                    {



                        if (ZDSVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightZDSV.LegSections[0].CurrentEntry = ZDSVEntryRep.Get(FullEntry.EntryId1);
                            RightZDSV.LegSections[0].SelectedValue = ZDSVStructRep.Get(RightZDSV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightZDSV.LegSections[1].CurrentEntry = ZDSVEntryRep.Get(FullEntry.EntryId2.Value);
                            RightZDSV.LegSections[1].SelectedValue = ZDSVStructRep.Get(RightZDSV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightZDSV.LegSections[2].CurrentEntry = ZDSVEntryRep.Get(FullEntry.EntryId3.Value);
                            RightZDSV.LegSections[2].SelectedValue = ZDSVStructRep.Get(RightZDSV.LegSections[2].CurrentEntry.StructureID);

                        }
                        RightZDSV.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightZDSV);
                        ZDSVRightstr = result.stringList;
                        IsVisibleZDSVright = result.listVisibility;

                    }
                    else if (Part is SPSViewModel)
                    {



                        if (SPSEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightSPS.LegSections[0].CurrentEntry = SPSEntryRep.Get(FullEntry.EntryId1);
                            RightSPS.LegSections[0].SelectedValue = SPSStructRep.Get(RightSPS.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightSPS.LegSections[1].CurrentEntry = SPSEntryRep.Get(FullEntry.EntryId2.Value);
                            RightSPS.LegSections[1].SelectedValue = SPSStructRep.Get(RightSPS.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightSPS.LegSections[2].CurrentEntry = SPSEntryRep.Get(FullEntry.EntryId3.Value);
                            RightSPS.LegSections[2].SelectedValue = SPSStructRep.Get(RightSPS.LegSections[2].CurrentEntry.StructureID);

                        }

                        RightSPS.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightSPS);
                        SPSRightstr = result.stringList;
                        IsVisibleSPSRight = result.listVisibility;

                    }
                    else if (Part is TibiaPerforateViewModel)
                    {



                        if (Perforate_shinEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightTibiaPerforate.LegSections[0].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId1);
                            RightTibiaPerforate.LegSections[0].SelectedValue = Perforate_shinStructRep.Get(RightTibiaPerforate.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightTibiaPerforate.LegSections[1].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId2.Value);
                            RightTibiaPerforate.LegSections[1].SelectedValue = Perforate_shinStructRep.Get(RightTibiaPerforate.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightTibiaPerforate.LegSections[2].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId3.Value);
                            RightTibiaPerforate.LegSections[2].SelectedValue = Perforate_shinStructRep.Get(RightTibiaPerforate.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            RightTibiaPerforate.LegSections[3].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId4.Value);
                            RightTibiaPerforate.LegSections[3].SelectedValue = Perforate_shinStructRep.Get(RightTibiaPerforate.LegSections[3].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId5 != null)
                        {
                            RightTibiaPerforate.LegSections[4].CurrentEntry = Perforate_shinEntryRep.Get(FullEntry.EntryId5.Value);
                            RightTibiaPerforate.LegSections[4].SelectedValue = Perforate_shinStructRep.Get(RightTibiaPerforate.LegSections[4].CurrentEntry.StructureID);

                        }

                        RightTibiaPerforate.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightTibiaPerforate);
                        Perforate_shinRightstr = result.stringList;
                        IsVisiblePerforate_shinRight = result.listVisibility;

                    }
                    else if (Part is MPVViewModel)
                    {



                        if (MPVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightMPV.LegSections[0].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId1);
                            RightMPV.LegSections[0].SelectedValue = MPVStructRep.Get(RightMPV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightMPV.LegSections[1].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId2.Value);
                            RightMPV.LegSections[1].SelectedValue = MPVStructRep.Get(RightMPV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightMPV.LegSections[2].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId3.Value);
                            RightMPV.LegSections[2].SelectedValue = MPVStructRep.Get(RightMPV.LegSections[2].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId4 != null)
                        {
                            RightMPV.LegSections[3].CurrentEntry = MPVEntryRep.Get(FullEntry.EntryId4.Value);
                            RightMPV.LegSections[3].SelectedValue = MPVStructRep.Get(RightMPV.LegSections[3].CurrentEntry.StructureID);

                        }


                        if (FullEntry.WayID != null)
                            RightMPV.SelectedWayType = RightMPV.MPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];

                        RightMPV.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightMPV);
                        MPVRightstr = result.stringList;
                        IsVisibleMPVRight = result.listVisibility;

                    }
                    else if (Part is TEMPVViewModel)
                    {



                        if (TEMPVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightTEMPV.LegSections[0].CurrentEntry = TEMPVEntryRep.Get(FullEntry.EntryId1);
                            RightTEMPV.LegSections[0].SelectedValue = TEMPVStructRep.Get(RightTEMPV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightTEMPV.LegSections[1].CurrentEntry = TEMPVEntryRep.Get(FullEntry.EntryId2.Value);
                            RightTEMPV.LegSections[1].SelectedValue = TEMPVStructRep.Get(RightTEMPV.LegSections[1].CurrentEntry.StructureID);

                        }
                        if (FullEntry.EntryId3 != null)
                        {
                            RightTEMPV.LegSections[2].CurrentEntry = TEMPVEntryRep.Get(FullEntry.EntryId3.Value);
                            RightTEMPV.LegSections[2].SelectedValue = TEMPVStructRep.Get(RightTEMPV.LegSections[2].CurrentEntry.StructureID);

                        }

                        if (FullEntry.WayID != null)
                            RightTEMPV.SelectedWayType = RightTEMPV.TEMPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];

                        RightTEMPV.FF_length = ((TEMPVEntryFull)FullEntry).FF_Length;
                        RightTEMPV.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightTEMPV);
                        TEMPVRightstr = result.stringList;
                        IsVisibleTEMPVRight = result.listVisibility;

                    }
                    else if (Part is GVViewModel)
                    {



                        if (GVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightGV.LegSections[0].CurrentEntry = GVEntryRep.Get(FullEntry.EntryId1);
                            RightGV.LegSections[0].SelectedValue = GVStructRep.Get(RightGV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightGV.LegSections[1].CurrentEntry = GVEntryRep.Get(FullEntry.EntryId2.Value);
                            RightGV.LegSections[1].SelectedValue = GVStructRep.Get(RightGV.LegSections[1].CurrentEntry.StructureID);

                        }



                        RightGV.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightGV);
                        GVRightstr = result.stringList;
                        IsVisibleGVRight = result.listVisibility;

                    }
                    else if (Part is PPVViewModel)
                    {



                        if (PPVEntryRep.Get(FullEntry.EntryId1) != null)
                        {
                            RightPPV.LegSections[0].CurrentEntry = PPVEntryRep.Get(FullEntry.EntryId1);
                            RightPPV.LegSections[0].SelectedValue = PPVStructRep.Get(RightPPV.LegSections[0].CurrentEntry.StructureID);
                        }
                        if (FullEntry.EntryId2 != null)
                        {
                            RightPPV.LegSections[1].CurrentEntry = PPVEntryRep.Get(FullEntry.EntryId2.Value);
                            RightPPV.LegSections[1].SelectedValue = PPVStructRep.Get(RightPPV.LegSections[1].CurrentEntry.StructureID);

                        }


                        RightPPV.IsEmpty = false;
                        SaveSet result = SaveViewModel(RightPPV);
                        PPVRightstr = result.stringList;
                        IsVisiblePPVRight = result.listVisibility;

                    }


                }

            }

        }







        private LegPartEntries SaveFullEntry(LegPartViewModel Part, LegPartEntries FullEntry)
        {
            if (!Part.IsEmpty)
            {
                LegPartEntries LeftSFSEntryFullbuf = FullEntry;
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { continue; }
                    LegPartEntry newSFSentry = (LegPartEntry)section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    if (Part is PDSVViewModel)
                    {
                        var testList = Data.PDSVHipEntries.GetAll.Where(s => s.Comment == ((PDSVHipEntry)newSFSentry).Comment && s.StructureID == ((PDSVHipEntry)newSFSentry).StructureID && s.Size == ((PDSVHipEntry)newSFSentry).Size && s.Size2 == ((PDSVHipEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {

                            Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is SFSViewModel)
                    {

                        var testList = Data.SFSHipEntries.GetAll.Where(s => s.Comment == ((SFSHipEntry)newSFSentry).Comment && s.StructureID == ((SFSHipEntry)newSFSentry).StructureID && s.Size == ((SFSHipEntry)newSFSentry).Size && s.Size2 == ((SFSHipEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is BPVHipViewModel)
                    {
                        var testList = Data.BPVHipEntries.GetAll.Where(s => s.Comment == ((BPVHipEntry)newSFSentry).Comment && s.StructureID == ((BPVHipEntry)newSFSentry).StructureID && s.Size == ((BPVHipEntry)newSFSentry).Size && s.Size2 == ((BPVHipEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is BPVTibiaViewModel)
                    {
                        var testList = Data.BPV_TibiaEntries.GetAll.Where(s => s.Comment == ((BPV_TibiaEntry)newSFSentry).Comment && s.StructureID == ((BPV_TibiaEntry)newSFSentry).StructureID && s.Size == ((BPV_TibiaEntry)newSFSentry).Size && s.Size2 == ((BPV_TibiaEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is HipPerforateViewModel)
                    {

                        var testList = Data.Perforate_hipEntries.GetAll.Where(s => s.Comment == ((Perforate_hipEntry)newSFSentry).Comment && s.StructureID == ((Perforate_hipEntry)newSFSentry).StructureID && s.Size == ((Perforate_hipEntry)newSFSentry).Size && s.Size2 == ((Perforate_hipEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is ZDSVViewModel)
                    {
                        var testList = Data.ZDSVEntries.GetAll.Where(s => s.Comment == ((ZDSVEntry)newSFSentry).Comment && s.StructureID == ((ZDSVEntry)newSFSentry).StructureID && s.Size == ((ZDSVEntry)newSFSentry).Size && s.Size2 == ((ZDSVEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                            Data.Complete();

                        }
                    }

                    else if (Part is SPSViewModel)
                    {
                        var testList = Data.SPSEntries.GetAll.Where(s => s.Comment == ((SPSHipEntry)newSFSentry).Comment && s.StructureID == ((SPSHipEntry)newSFSentry).StructureID && s.Size == ((SPSHipEntry)newSFSentry).Size && s.Size2 == ((SPSHipEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is TibiaPerforateViewModel)
                    {
                        var testList = Data.Perforate_shinEntries.GetAll.Where(s => s.Comment == ((Perforate_shinEntry)newSFSentry).Comment && s.StructureID == ((Perforate_shinEntry)newSFSentry).StructureID && s.Size == ((Perforate_shinEntry)newSFSentry).Size && s.Size2 == ((Perforate_shinEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is MPVViewModel)
                    {
                        var testList = Data.MPVEntries.GetAll.Where(s => s.Comment == ((MPVEntry)newSFSentry).Comment && s.StructureID == ((MPVEntry)newSFSentry).StructureID && s.Size == ((MPVEntry)newSFSentry).Size && s.Size2 == ((MPVEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.MPVEntries.Add((MPVEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is TEMPVViewModel)
                    {
                        ((TEMPVEntryFull)LeftSFSEntryFullbuf).FF_Length = Part.FF_length;
                        var testList = Data.TEMPVEntries.GetAll.Where(s => s.Comment == ((TEMPVEntry)newSFSentry).Comment && s.StructureID == ((TEMPVEntry)newSFSentry).StructureID && s.Size == ((TEMPVEntry)newSFSentry).Size && s.Size2 == ((TEMPVEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is PPVViewModel)
                    {
                        var testList = Data.PPVEntries.GetAll.Where(s => s.Comment == ((PPVEntry)newSFSentry).Comment && s.StructureID == ((PPVEntry)newSFSentry).StructureID && s.Size == ((PPVEntry)newSFSentry).Size && s.Size2 == ((PPVEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.PPVEntries.Add((PPVEntry)newSFSentry);
                            Data.Complete();

                        }
                    }
                    else if (Part is GVViewModel)
                    {
                        var testList = Data.GVEntries.GetAll.Where(s => s.Comment == ((GVEntry)newSFSentry).Comment && s.StructureID == ((GVEntry)newSFSentry).StructureID && s.Size == ((GVEntry)newSFSentry).Size && s.Size2 == ((GVEntry)newSFSentry).Size2).ToList();
                        if (testList.Count > 0)
                        {
                            newSFSentry = testList[0];
                        }
                        else
                        {
                            Data.GVEntries.Add((GVEntry)newSFSentry);
                            Data.Complete();

                        }
                    }

                    //       Data.Complete();
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
            return FullEntry;
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
            //bufBpvLeftStr += sender.Comment;
            SaveSet result = new SaveSet(bufBpvLeftStr, IsVisibleBPVleftbuf);
            return result;

        }

        public string mode;
        private void Clear(object sender, object data)
        {
            mode = "Normal";
            TextTip = "";
            GVLeftstr = new List<string>();
            GVRightstr = new List<string>();


            PPVLeftstr = new List<string>();
            PPVRightstr = new List<string>();

            CEAPLeftstr = new List<string>();
            CEAPRightstr = new List<string>();
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

            IsVisibleGVleft = new ObservableCollection<Visibility>();
            IsVisibleGVRight = new ObservableCollection<Visibility>();


            IsVisiblePPVleft = new ObservableCollection<Visibility>();
            IsVisiblePPVRight = new ObservableCollection<Visibility>();

            IsVisibleCEAPleft = new ObservableCollection<Visibility>();
            IsVisibleCEAPRight = new ObservableCollection<Visibility>();

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

            for (int i = 0; i < 6; ++i)
            {
                IsVisibleGVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleGVRight.Add(Visibility.Collapsed);
            }


            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePPVleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisiblePPVRight.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleCEAPleft.Add(Visibility.Collapsed);
            }
            for (int i = 0; i < 6; ++i)
            {
                IsVisibleCEAPRight.Add(Visibility.Collapsed);
            }
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

            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();
            RecomendationsList = new List<RecomendationsDataSource>();
            ComplainsList = new List<ComplainsDataSource>();
            // if (!LeftCEAR.IsEmpty)
            LeftCEAR = new LettersViewModel(Controller, LegSide.Left);
            //  if (!RightCEAR.IsEmpty)
            RightCEAR = new LettersViewModel(Controller, LegSide.Right);

            LeftTEMPV = new TEMPVViewModel(Controller, LegSide.Left);

            RightTEMPV = new TEMPVViewModel(Controller, LegSide.Right);


            LeftMPV = new MPVViewModel(Controller, LegSide.Left);

            RightMPV = new MPVViewModel(Controller, LegSide.Right);
            LeftZDSV = new ZDSVViewModel(Controller, LegSide.Left);
            RightZDSV = new ZDSVViewModel(Controller, LegSide.Right);
            LeftTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Left);
            RightTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Right);
            LeftSPS = new SPSViewModel(Controller, LegSide.Left);
            RightSPS = new SPSViewModel(Controller, LegSide.Right);
            LeftSFS = new SFSViewModel(Controller, LegSide.Left);
            RightSFS = new SFSViewModel(Controller, LegSide.Right);
            LeftPDSV = new PDSVViewModel(Controller, LegSide.Left);
            RightPDSV = new PDSVViewModel(Controller, LegSide.Right);
            LeftGV = new GVViewModel(Controller, LegSide.Left);
            RightGV = new GVViewModel(Controller, LegSide.Right);
            LeftPPV = new PPVViewModel(Controller, LegSide.Left);
            RightPPV = new PPVViewModel(Controller, LegSide.Right);
            LeftPerforate = new HipPerforateViewModel(Controller, LegSide.Left);
            RightPerforate = new HipPerforateViewModel(Controller, LegSide.Right);
            LeftBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Left);
            RightBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Right);
            LeftBPVHip = new BPVHipViewModel(Controller, LegSide.Left);
            RightBPVHip = new BPVHipViewModel(Controller, LegSide.Right);
            LeftAdditionalText = "";
            RightAdditionalText = "";
        }
        int obsid;
        private void GetObsForOverview(object sender, object data)
        {
            Clear(this, null);//?
            mode = "EDIT";
            MessageBus.Default.Call("SetMode", this, "EDIT");
            obsid = (int)data;

            using (var context = new MySqlContext())
            {
                ExaminationRepository ExamRep = new ExaminationRepository(context);
                ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);
                LettersRepository LettersRep = new LettersRepository(context);



                Examination Exam = ExamRep.Get(obsid);
                ExaminationLeg leftLegExam = LegExamRep.Get(Exam.idLeftLegExamination.Value);
                ExaminationLeg rightLegExam = LegExamRep.Get(Exam.idRightLegExamination.Value);




                Weight = Exam.weight.ToString();
                Growth = Exam.height.ToString();
                TextTip = Exam.NB;


                LeftAdditionalText = leftLegExam.additionalText;

                PDSVHipEntryFullRepository PDSVEntryFullRep = new PDSVHipEntryFullRepository(context);
                if (leftLegExam.PDSVid != null)
                {
                    GetLegPartFromEntry(PDSVEntryFullRep.Get(leftLegExam.PDSVid.Value), LeftPDSV, true);
                }


                BPVHipEntryFullRepository BPVEntryFullRep = new BPVHipEntryFullRepository(context);
                if (leftLegExam.BPVHip != null)
                    GetLegPartFromEntry(BPVEntryFullRep.Get(leftLegExam.BPVHip.Value), LeftBPVHip, true);


                BPV_TibiaEntryFullRepository BPVTibiaEntryFullRep = new BPV_TibiaEntryFullRepository(context);
                if (leftLegExam.BPVTibiaid != null)
                    GetLegPartFromEntry(BPVTibiaEntryFullRep.Get(leftLegExam.BPVTibiaid.Value), LeftBPVTibia, true);



                GVEntryFullRepository GVEntryFullRep = new GVEntryFullRepository(context);
                if (leftLegExam.GVid != null)
                    GetLegPartFromEntry(GVEntryFullRep.Get(leftLegExam.GVid.Value), LeftGV, true);


                MPVEntryFullRepository MPVEntryFullRep = new MPVEntryFullRepository(context);
                if (leftLegExam.MPVid != null)
                    GetLegPartFromEntry(MPVEntryFullRep.Get(leftLegExam.MPVid.Value), LeftMPV, true);


                Perforate_hipEntryFullRepository PerforateEntryFullRep = new Perforate_hipEntryFullRepository(context);
                if (leftLegExam.PerforateHipid != null)
                    GetLegPartFromEntry(PerforateEntryFullRep.Get(leftLegExam.PerforateHipid.Value), LeftPerforate, true);



                PPVEntryFullRepository PPVEntryFullRep = new PPVEntryFullRepository(context);
                if (leftLegExam.PPVid != null)
                    GetLegPartFromEntry(PPVEntryFullRep.Get(leftLegExam.PPVid.Value), LeftPPV, true);



                SFSHipEntryFullRepository SFSEntryFullRep = new SFSHipEntryFullRepository(context);
                if (leftLegExam.SFSid != null)
                    GetLegPartFromEntry(SFSEntryFullRep.Get(leftLegExam.SFSid.Value), LeftSFS, true);


                SPSHipEntryFullRepository SPSEntryFullRep = new SPSHipEntryFullRepository(context);
                if (leftLegExam.SPSid != null)
                    GetLegPartFromEntry(SPSEntryFullRep.Get(leftLegExam.SPSid.Value), LeftSPS, true);




                TEMPVEntryFullRepository TEMPVEntryFullRep = new TEMPVEntryFullRepository(context);
                if (leftLegExam.TEMPVid != null)
                    GetLegPartFromEntry(TEMPVEntryFullRep.Get(leftLegExam.TEMPVid.Value), LeftTEMPV, true);



                Perforate_shinEntryFullRepository TibiaPerforateEntryFullRep = new Perforate_shinEntryFullRepository(context);
                if (leftLegExam.TibiaPerforateid != null)
                    GetLegPartFromEntry(TibiaPerforateEntryFullRep.Get(leftLegExam.TibiaPerforateid.Value), LeftTibiaPerforate, true);





                ZDSVEntryFullRepository ZDSVEntryFullRep = new ZDSVEntryFullRepository(context);

                if (leftLegExam.ZDSVid != null)
                    GetLegPartFromEntry(ZDSVEntryFullRep.Get(leftLegExam.ZDSVid.Value), LeftZDSV, true);


                if (leftLegExam.C != null)
                    LeftCEAR.LegSections[0].SelectedValue = LettersRep.Get(leftLegExam.C.Value);

                if (leftLegExam.E != null)
                    LeftCEAR.LegSections[1].SelectedValue = LettersRep.Get(leftLegExam.E.Value);

                if (leftLegExam.A != null)
                    LeftCEAR.LegSections[2].SelectedValue = LettersRep.Get(leftLegExam.A.Value);

                if (leftLegExam.P != null)
                    LeftCEAR.LegSections[3].SelectedValue = LettersRep.Get(leftLegExam.P.Value);



                LeftCEAR.SaveCommand.Execute();













                RightAdditionalText = rightLegExam.additionalText;



                if (rightLegExam.PDSVid != null)
                    GetLegPartFromEntry(PDSVEntryFullRep.Get(rightLegExam.PDSVid.Value), RightPDSV, false);




                if (rightLegExam.BPVHip != null)
                    GetLegPartFromEntry(BPVEntryFullRep.Get(rightLegExam.BPVHip.Value), RightBPVHip, false);



                if (rightLegExam.BPVTibiaid != null)
                    GetLegPartFromEntry(BPVTibiaEntryFullRep.Get(rightLegExam.BPVTibiaid.Value), RightBPVTibia, false);




                if (rightLegExam.GVid != null)
                    GetLegPartFromEntry(GVEntryFullRep.Get(rightLegExam.GVid.Value), RightGV, false);



                if (rightLegExam.MPVid != null)
                    GetLegPartFromEntry(MPVEntryFullRep.Get(rightLegExam.MPVid.Value), RightMPV, false);



                if (rightLegExam.PerforateHipid != null)
                    GetLegPartFromEntry(PerforateEntryFullRep.Get(rightLegExam.PerforateHipid.Value), RightPerforate, false);




                if (rightLegExam.PPVid != null)
                    GetLegPartFromEntry(PPVEntryFullRep.Get(rightLegExam.PPVid.Value), RightPPV, false);



                if (rightLegExam.SFSid != null)
                    GetLegPartFromEntry(SFSEntryFullRep.Get(rightLegExam.SFSid.Value), RightSFS, false);



                if (rightLegExam.SPSid != null)
                    GetLegPartFromEntry(SPSEntryFullRep.Get(rightLegExam.SPSid.Value), RightSPS, false);





                if (rightLegExam.TEMPVid != null)
                    GetLegPartFromEntry(TEMPVEntryFullRep.Get(rightLegExam.TEMPVid.Value), RightTEMPV, false);

                if (rightLegExam.TibiaPerforateid != null)
                    GetLegPartFromEntry(TibiaPerforateEntryFullRep.Get(rightLegExam.TibiaPerforateid.Value), RightTibiaPerforate, false);

                if (rightLegExam.ZDSVid != null)
                    GetLegPartFromEntry(ZDSVEntryFullRep.Get(rightLegExam.ZDSVid.Value), RightZDSV, false);

                if (rightLegExam.C != null)
                    RightCEAR.LegSections[0].SelectedValue = LettersRep.Get(rightLegExam.C.Value);

                if (rightLegExam.E != null)
                    RightCEAR.LegSections[1].SelectedValue = LettersRep.Get(rightLegExam.E.Value);

                if (rightLegExam.A != null)
                    RightCEAR.LegSections[2].SelectedValue = LettersRep.Get(rightLegExam.A.Value);

                if (rightLegExam.P != null)
                    RightCEAR.LegSections[3].SelectedValue = LettersRep.Get(rightLegExam.P.Value);

                RightCEAR.SaveCommand.Execute();











                DiagnosisObsRepository diagRep = new DiagnosisObsRepository(context);
                ComplanesObsRepository compRep = new ComplanesObsRepository(context);
                RecomendationObsRepository recRep = new RecomendationObsRepository(context);



                LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();


                DiagnosisDataSource diagDSourceBuf;
                foreach (var diag in Data.DiagnosisObs.GetAll.Where(s => s.isLeft == true && s.id_обследование_ноги == Exam.Id).ToList())
                {
                    diagDSourceBuf = new DiagnosisDataSource(Data.DiagnosisTypes.Get(diag.id_диагноз.Value));
                    diagDSourceBuf.IsChecked = true;
                    LeftDiagnosisList.Add(diagDSourceBuf);
                }

                RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();



                foreach (var diag in Data.DiagnosisObs.GetAll.Where(s => s.isLeft == false && s.id_обследование_ноги == Exam.Id).ToList())
                {
                    diagDSourceBuf = new DiagnosisDataSource(Data.DiagnosisTypes.Get(diag.id_диагноз.Value));
                    diagDSourceBuf.IsChecked = true;
                    RightDiagnosisList.Add(diagDSourceBuf);
                }

                MessageBus.Default.Call("SetDiagnosisListBecauseOFEdit", LeftDiagnosisList, RightDiagnosisList);

                ComplainsList = new List<ComplainsDataSource>();
                ComplainsDataSource compDSourceBuf;
                foreach (var diag in Data.ComplanesObs.GetAll.Where(s => s.id_обследования == Exam.Id).ToList())
                {
                    compDSourceBuf = new ComplainsDataSource(Data.ComplainsTypes.Get(diag.id_жалобы));
                    compDSourceBuf.IsChecked = true;
                    ComplainsList.Add(compDSourceBuf);
                }
                RecomendationsList = new List<RecomendationsDataSource>();
                RecomendationsDataSource recDSourceBuf;

                foreach (var diag in Data.RecomendationObs.GetAll.Where(s => s.id_обследования == Exam.Id).ToList())
                {
                    recDSourceBuf = new RecomendationsDataSource(Data.RecomendationsTypes.Get(diag.id_рекомендации));
                    recDSourceBuf.IsChecked = true;
                    RecomendationsList.Add(recDSourceBuf);
                }
                MessageBus.Default.Call("SetDRecomendationListBecauseOFEdit", this, RecomendationsList);

                MessageBus.Default.Call("SetDComplanesListBecauseOFEdit", this, ComplainsList);


                //leftLegExams.additionalText = LeftAdditionalText;
                //if (LeftCEAR.LegSections[0].SelectedValue != null)
                //    leftLegExams.C = LeftCEAR.LegSections[0].SelectedValue.Id;
                //if (LeftCEAR.LegSections[1].SelectedValue != null)
                //    leftLegExams.E = LeftCEAR.LegSections[1].SelectedValue.Id;
                //if (LeftCEAR.LegSections[2].SelectedValue != null)
                //    leftLegExams.A = LeftCEAR.LegSections[2].SelectedValue.Id;
                //if (LeftCEAR.LegSections[3].SelectedValue != null)
                //    leftLegExams.P = LeftCEAR.LegSections[3].SelectedValue.Id;


            }
            MessageBus.Default.Call("SetMode", this, "Normal");
        }
        //  public ObservableCollection<>
        //кто присылает и что присылает
        private void Handler(object sender, object data)
        {
            Type senderType = sender.GetType();
            LegPartViewModel senderVM = (LegPartViewModel)sender;
            //  BPVHipEntryFull bpv = new BPVHipEntryFull();
            if (senderType == typeof(GVViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    GVLeftstr = new List<string>();
                    LeftGVEntryFull = new GVEntryFull();
                    //to do тут должно быть сохранение
                    LeftGV = (GVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftGV);
                    GVLeftstr = result.stringList;
                    IsVisibleGVleft = result.listVisibility;

                }

                else
                {
                    GVRightstr = new List<string>();
                    RightGVEntryFull = new GVEntryFull();
                    //to do тут должно быть сохранение
                    RightGV = (GVViewModel)sender;
                    SaveSet result = SaveViewModel(RightGV);
                    GVRightstr = result.stringList;
                    IsVisibleGVRight = result.listVisibility;

                }




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



            if (senderType == typeof(PPVViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    PPVLeftstr = new List<string>();
                    LeftPPVEntryFull = new PPVEntryFull();
                    //to do тут должно быть сохранение
                    LeftPPV = (PPVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftPPV);
                    PPVLeftstr = result.stringList;
                    IsVisiblePPVleft = result.listVisibility;

                }

                else
                {
                    PPVRightstr = new List<string>();
                    RightPPVEntryFull = new PPVEntryFull();
                    //to do тут должно быть сохранение
                    RightPPV = (PPVViewModel)sender;
                    SaveSet result = SaveViewModel(RightPPV);
                    PPVRightstr = result.stringList;
                    IsVisiblePPVRight = result.listVisibility;

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

            if (senderType == typeof(LettersViewModel))
                if (senderVM.CurrentLegSide == LegSide.Left)
                {

                    IsVisibleCEAPleft = new ObservableCollection<Visibility>();
                    LeftCEAR = (LettersViewModel)sender;
                    CEAPLeftstr = new List<string>();
                    foreach (var leter in LeftCEAR.LegSections)
                    {
                        if (leter.SelectedValue != null)
                        {
                            IsVisibleCEAPleft.Add(Visibility.Visible);
                            CEAPLeftstr.Add(leter.SelectedValue.Leter + leter.SelectedValue.Text1);
                        }
                        else
                        {
                            CEAPLeftstr.Add("");
                            IsVisibleCEAPleft.Add(Visibility.Collapsed);
                        }
                    }



                }
                else
                {
                    IsVisibleCEAPRight = new ObservableCollection<Visibility>();
                    RightCEAR = (LettersViewModel)sender;
                    CEAPRightstr = new List<string>();
                    foreach (var leter in RightCEAR.LegSections)
                    {
                        if (leter.SelectedValue != null)
                        {
                            IsVisibleCEAPRight.Add(Visibility.Visible);
                            CEAPRightstr.Add(leter.SelectedValue.Leter + leter.SelectedValue.Text1);
                        }
                        else
                        { IsVisibleCEAPRight.Add(Visibility.Collapsed); }
                    }


                }
            //
        }
    }
}
