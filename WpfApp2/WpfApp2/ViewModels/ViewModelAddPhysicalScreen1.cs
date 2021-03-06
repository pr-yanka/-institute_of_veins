﻿using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.GV;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.BPV_Tibia;
using WpfApp2.Db.Models.LegParts.BPVHip;
using WpfApp2.Db.Models.LegParts.GV;
using WpfApp2.Db.Models.LegParts.MPV;
using WpfApp2.Db.Models.LegParts.PDSVHip;
using WpfApp2.Db.Models.LegParts.Perforate_hip;
using WpfApp2.Db.Models.LegParts.Perforate_shin;
using WpfApp2.Db.Models.LegParts.PPV;
using WpfApp2.Db.Models.LegParts.SFSHip;
using WpfApp2.Db.Models.LegParts.SPSHip;
using WpfApp2.Db.Models.LegParts.TEMPV;
using WpfApp2.Db.Models.LegParts.ZDSV;
using WpfApp2.Db.Models.PPV;
using WpfApp2.Db.Models.SPS;
using WpfApp2.DialogPreOperation;
using WpfApp2.DialogService;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;
using Xceed.Words.NET;

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

        private Visibility _isVisibleForSecretarySign;


        public Visibility IsVisibleForSecretarySign { get { return _isVisibleForSecretarySign; } set { _isVisibleForSecretarySign = value; OnPropertyChanged(); } }

        private Visibility _isVisibleForSecretary;


        public Visibility IsVisibleForSecretary { get { return _isVisibleForSecretary; } set { _isVisibleForSecretary = value; OnPropertyChanged(); } }


        private Brush _bPDSV;
        private Brush _bZDSV;
        private Brush _bPerforate1;
        private Brush _bPerforateGoleni;
        private Brush _bTEMPV;
        private Brush _bPPV;
        private Brush _bCEAR;
        private Brush _bAdditionalText;
        private Brush _bGV;


        private Brush _bPDSVL;
        private Brush _bZDSVL;
        private Brush _bPerforate1L;
        private Brush _bPerforateGoleniL;
        private Brush _bTEMPVL;
        private Brush _bPPVL;
        private Brush _bCEARL;
        private Brush _bAdditionalTextL;
        private Brush _bGVL;


        public Brush BPDSV { get { return _bPDSV; } set { _bPDSV = value; OnPropertyChanged(); } }
        public Brush BZDSV { get { return _bZDSV; } set { _bZDSV = value; OnPropertyChanged(); } }
        public Brush BPerforate1 { get { return _bPerforate1; } set { _bPerforate1 = value; OnPropertyChanged(); } }
        public Brush BPerforateGoleni { get { return _bPerforateGoleni; } set { _bPerforateGoleni = value; OnPropertyChanged(); } }
        public Brush BTEMPV { get { return _bTEMPV; } set { _bTEMPV = value; OnPropertyChanged(); } }
        public Brush BPPV { get { return _bPPV; } set { _bPPV = value; OnPropertyChanged(); } }
        public Brush BCEAR { get { return _bCEAR; } set { _bCEAR = value; OnPropertyChanged(); } }
        public Brush BAdditionalText { get { return _bAdditionalText; } set { _bAdditionalText = value; OnPropertyChanged(); } }
        public Brush BGV { get { return _bGV; } set { _bGV = value; OnPropertyChanged(); } }


        public Brush BPDSVL { get { return _bPDSVL; } set { _bPDSVL = value; OnPropertyChanged(); } }
        public Brush BZDSVL { get { return _bZDSVL; } set { _bZDSVL = value; OnPropertyChanged(); } }
        public Brush BPerforate1L { get { return _bPerforate1L; } set { _bPerforate1L = value; OnPropertyChanged(); } }
        public Brush BPerforateGoleniL { get { return _bPerforateGoleniL; } set { _bPerforateGoleniL = value; OnPropertyChanged(); } }
        public Brush BTEMPVL { get { return _bTEMPVL; } set { _bTEMPVL = value; OnPropertyChanged(); } }
        public Brush BPPVL { get { return _bPPVL; } set { _bPPVL = value; OnPropertyChanged(); } }
        public Brush BCEARL { get { return _bCEARL; } set { _bCEARL = value; OnPropertyChanged(); } }
        public Brush BAdditionalTextL { get { return _bAdditionalTextL; } set { _bAdditionalTextL = value; OnPropertyChanged(); } }
        public Brush BGVL { get { return _bGVL; } set { _bGVL = value; OnPropertyChanged(); } }



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
        private string _textOfEndBtn;

        public string TextOfEndBtn
        {
            get { return _textOfEndBtn; }
            set
            {
                _textOfEndBtn = value; OnPropertyChanged();
            }
        }
        //Завершить обследование
        private string _leftAdditionalText;
        private string _rightAdditionalText;

        public string LeftAdditionalText
        {
            get { return _leftAdditionalText; }
            set
            {
                _leftAdditionalText = value; OnPropertyChanged();
                //if (string.IsNullOrWhiteSpace(LeftAdditionalText))
                //{

                //    BAdditionalText = Brushes.Red;
                //}
                //else if (!string.IsNullOrWhiteSpace(LeftAdditionalText))
                //{
                //    BAdditionalText = null;
                //}

            }
        }
        public string RightAdditionalText
        {
            get { return _rightAdditionalText; }
            set
            {
                _rightAdditionalText = value; OnPropertyChanged();
                //if (string.IsNullOrWhiteSpace(RightAdditionalText))
                //{

                //    BAdditionalTextL = Brushes.Red;
                //}
                //else if (!string.IsNullOrWhiteSpace(RightAdditionalText))
                //{
                //    BAdditionalTextL = null;
                //}
            }
        }
        private Visibility _isVisibleTextTTT;
        public Visibility IsVisibleTextTTT
        {
            get
            {
                return _isVisibleTextTTT;
            }
            set
            {
                _isVisibleTextTTT = value;
                OnPropertyChanged();
            }
        }
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
                else if (float.TryParse(value, out buf) && buf >= 0) { _weight = buf.ToString(); }

                if (float.TryParse(Weight, out buf) && float.TryParse(Growth, out buf) && buf >= 0)
                {
                    ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100));
                }

                OnPropertyChanged();
            }
        }
        private string _textOfPreOperation;

        public string TextOfPreOperation
        {
            get { return _textOfPreOperation; }
            set
            {
                _textOfPreOperation = value; OnPropertyChanged();
            }
        }
        private string _growth;
        public string Growth
        {
            get { return _growth; }
            set
            {
                float buf = 0f;
                if (value.Contains(",")) { _growth = value; } else if (value == "") { _growth = ""; } else if (float.TryParse(value, out buf) && buf >= 0) { _growth = buf.ToString(); }
                if (float.TryParse(Weight, out buf) && float.TryParse(Growth, out buf) && buf >= 0)
                {
                    ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100));
                }

                OnPropertyChanged();
            }
        }

        private double _itm;
        public double ITM { get { return Math.Round(_itm, 3); } set { if (float.Parse(Growth) != 0) { _itm = value; } OnPropertyChanged(); } }

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

        public ObservableCollection<ComplainsDataSource> ComplainsList { get; set; }
        public ObservableCollection<RecomendationsDataSource> RecomendationsList { get; set; }
        public ObservableCollection<DiagnosisDataSource> DiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> LeftDiagnosisList { get; set; }
        public ObservableCollection<DiagnosisDataSource> RightDiagnosisList { get; set; }

        private void SetComplainsList(object sender, object data)
        {
            ComplainsList = new ObservableCollection<ComplainsDataSource>((ObservableCollection<ComplainsDataSource>)data);

        }
        private void SetRecomendationsList(object sender, object data)
        {
            RecomendationsList = new ObservableCollection<RecomendationsDataSource>((ObservableCollection<RecomendationsDataSource>)data);
        }
        private void SetDiagnosisList(object sender, object data)
        {
            DiagnosisList = new ObservableCollection<DiagnosisDataSource>((List<DiagnosisDataSource>)data);
        }
        private string _ageText;
        public string AgeText { get { return _ageText; } set { _ageText = value; OnPropertyChanged(); } }
        private void SetCurrentPatientID(object sender, object data)
        {
            MessageBus.Default.Call("SetClearDiagnosisListLeftRightObsled", null, null);
            MessageBus.Default.Call("SetClearRecomendationListObsledovanie", null, null);
            MessageBus.Default.Call("SetClearComplanesListObsledovanie", null, null);
            Clear(null, null);
            IsVisibleTextTTT = Visibility.Hidden;
            Weight = "0";
            Growth = "0";
            TextTip = "Текст пометки";
            CurrentPatient = Data.Patients.Get((int)data);
            initials = " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";
            char[] chararr = CurrentPatient.Age.ToString().ToCharArray();
            try
            {
                string agelastNumb = chararr[chararr.Length - 1].ToString();
                float buff = 0f;
                if (float.TryParse(agelastNumb, out buff))
                {
                    if (CurrentPatient.Age >= 10 && CurrentPatient.Age <= 19)
                    {
                        AgeText = " лет";
                    }
                    else if (buff == 1)
                    { AgeText = " год"; }
                    else if (buff >= 2 && buff <= 4)
                    {
                        AgeText = " года";
                    }
                    else if (buff == 0 || (buff >= 5 && buff <= 9))
                    {
                        AgeText = " лет";
                    }
                }
            }
            catch { }
            SetAllBordersDefault();
        }

        private ICommand openDialogCommand = null;

        public DelegateCommand LostFocusOnWeight { get; private set; }

        public ICommand OpenDialogCommand
        {
            get { return openDialogCommand; }
            set { openDialogCommand = value; }
        }


        private BPVHipViewModel _leftBPVHip;
        private SFSViewModel _leftSFS;
        private PDSVViewModel _leftPDSV;
        private ZDSVViewModel _leftZDSV;
        private HipPerforateViewModel _leftPerforate;
        private TibiaPerforateViewModel _leftTibiaPerforate;
        private BPVTibiaViewModel _leftBPVTibia;
        private SPSViewModel _leftSPS;
        private MPVViewModel _leftMPV;
        private MPVViewModel _rightMPV;
        private PPVViewModel _leftPPV;
        private PPVViewModel _rightPPV;
        private TEMPVViewModel _leftTEMPV;
        private TEMPVViewModel _rightTEMPV;
        private BPVHipViewModel _rightBPVHip;
        private SFSViewModel _rightSFS;
        private LettersViewModel _leftCEAR;
        private LettersViewModel _rightCEAR;
        private PDSVViewModel _rightPDSV;
        private ZDSVViewModel _rightZDSV;
        private HipPerforateViewModel _rightPerforate;
        private TibiaPerforateViewModel _rightTibiaPerforate;
        private BPVTibiaViewModel _rightBPVTibia;
        private SPSViewModel _rightSPS;
        private GVViewModel _leftGV;
        private GVViewModel _rightGV;

        public BPVHipViewModel LeftBPVHip { get { return _leftBPVHip; } set { _leftBPVHip = value; OnPropertyChanged(); } }
        public SFSViewModel LeftSFS { get { return _leftSFS; } set { _leftSFS = value; OnPropertyChanged(); } }
        public PDSVViewModel LeftPDSV { get { return _leftPDSV; } set { _leftPDSV = value; OnPropertyChanged(); } }
        public ZDSVViewModel LeftZDSV { get { return _leftZDSV; } set { _leftZDSV = value; OnPropertyChanged(); } }
        public HipPerforateViewModel LeftPerforate { get { return _leftPerforate; } set { _leftPerforate = value; OnPropertyChanged(); } }
        public TibiaPerforateViewModel LeftTibiaPerforate { get { return _leftTibiaPerforate; } set { _leftTibiaPerforate = value; OnPropertyChanged(); } }
        public BPVTibiaViewModel LeftBPVTibia { get { return _leftBPVTibia; } set { _leftBPVTibia = value; OnPropertyChanged(); } }
        public SPSViewModel LeftSPS { get { return _leftSPS; } set { _leftSPS = value; OnPropertyChanged(); } }
        public MPVViewModel LeftMPV { get { return _leftMPV; } set { _leftMPV = value; OnPropertyChanged(); } }
        public MPVViewModel RightMPV { get { return _rightMPV; } set { _rightMPV = value; OnPropertyChanged(); } }
        public PPVViewModel LeftPPV { get { return _leftPPV; } set { _leftPPV = value; OnPropertyChanged(); } }
        public PPVViewModel RightPPV { get { return _rightPPV; } set { _rightPPV = value; OnPropertyChanged(); } }
        public TEMPVViewModel LeftTEMPV { get { return _leftTEMPV; } set { _leftTEMPV = value; OnPropertyChanged(); } }
        public TEMPVViewModel RightTEMPV { get { return _rightTEMPV; } set { _rightTEMPV = value; OnPropertyChanged(); } }
        public BPVHipViewModel RightBPVHip { get { return _rightBPVHip; } set { _rightBPVHip = value; OnPropertyChanged(); } }
        public SFSViewModel RightSFS { get { return _rightSFS; } set { _rightSFS = value; OnPropertyChanged(); } }
        public LettersViewModel LeftCEAR { get { return _leftCEAR; } set { _leftCEAR = value; OnPropertyChanged(); } }
        public LettersViewModel RightCEAR { get { return _rightCEAR; } set { _rightCEAR = value; OnPropertyChanged(); } }
        public PDSVViewModel RightPDSV { get { return _rightPDSV; } set { _rightPDSV = value; OnPropertyChanged(); } }
        public ZDSVViewModel RightZDSV { get { return _rightZDSV; } set { _rightZDSV = value; OnPropertyChanged(); } }
        public HipPerforateViewModel RightPerforate { get { return _rightPerforate; } set { _rightPerforate = value; OnPropertyChanged(); } }
        public TibiaPerforateViewModel RightTibiaPerforate { get { return _rightTibiaPerforate; } set { _rightTibiaPerforate = value; OnPropertyChanged(); } }
        public BPVTibiaViewModel RightBPVTibia { get { return _rightBPVTibia; } set { _rightBPVTibia = value; OnPropertyChanged(); } }
        public SPSViewModel RightSPS { get { return _rightSPS; } set { _rightSPS = value; OnPropertyChanged(); } }
        public GVViewModel LeftGV { get { return _leftGV; } set { _leftGV = value; OnPropertyChanged(); } }
        public GVViewModel RightGV { get { return _rightGV; } set { _rightGV = value; OnPropertyChanged(); } }


        public DelegateCommand ToLeftGVCommand { get; private set; }
        public DelegateCommand ToRightGVCommand { get; private set; }
        public DelegateCommand ToLeftCEARCommand { get; private set; }
        public DelegateCommand ToRightCEARCommand { get; private set; }
        public DelegateCommand ToLeftPPVCommand { get; private set; }
        public DelegateCommand ToRightPPVCommand { get; private set; }
        public string Doctor { get; private set; }

        private bool IsObservCollectionIsFilled<T>(ObservableCollection<T> x)
        {
            if (x != null && x.Count != 0)
            {
                return true;
            }

            return false;
        }

        private bool IsListIsFilled<T>(List<T> x)
        {
            if (x != null && x.Count != 0)
            {
                return true;
            }

            return false;
        }
        private void FinishAdding(object parameter)
        {
            BrushesFill();




            if (LeftGV.IsEmpty == true)
            {
                MessageBox.Show("ГВ слева не заполнено");
            }

            else if (!IsObservCollectionIsFilled(LeftDiagnosisList))
            {
                MessageBox.Show("Диагнозы слева не заполнены");

            }
            else if (!IsObservCollectionIsFilled(RightDiagnosisList))
            {
                MessageBox.Show("Диагнозы справа не заполнены");

            }
            else if (!IsObservCollectionIsFilled(ComplainsList))
            {
                MessageBox.Show("Жалобы не заполнены");

            }
            else if (!IsObservCollectionIsFilled(RecomendationsList))
            {
                MessageBox.Show("Рекомендации не заполнены");

            }
            else if (RightGV.IsEmpty == true)
            {
                MessageBox.Show("ГВ справа не заполнено");
            }

            else if (LeftSFS.IsEmpty == true)
            {
                MessageBox.Show("СФС слева не заполнено");
            }
            else if (RightSFS.IsEmpty == true)
            {
                MessageBox.Show("СФС справа не заполнено");
            }
            else if (RightBPVHip.IsEmpty == true)
            {
                MessageBox.Show("БПВ на бедре справа не заполнено");
            }
            else if (LeftBPVHip.IsEmpty == true)
            {
                MessageBox.Show("БПВ на бедре слева не заполнено");
            }
            else if (RightBPVTibia.IsEmpty == true)
            {
                MessageBox.Show("БПВ на голени справа не заполнено");
            }
            else if (LeftBPVTibia.IsEmpty == true)
            {
                MessageBox.Show("БПВ на голени справа не заполнено");
            }
            else if (RightSPS.IsEmpty == true)
            {
                MessageBox.Show("СПС справа не заполнено");
            }
            else if (LeftSPS.IsEmpty == true)
            {
                MessageBox.Show("СПС слева не заполнено");
            }
            else if (RightMPV.IsEmpty == true)
            {
                MessageBox.Show("МПВ справа не заполнено");
            }
            else if (LeftMPV.IsEmpty == true)
            {
                MessageBox.Show("МПВ слева не заполнено");
            }


            //else if (RightPPV.IsEmpty == true)
            //{
            //    MessageBox.Show("ППВ справа не заполнено");
            //}
            //else if (LeftPPV.IsEmpty == true)
            //{
            //    MessageBox.Show("ППВ слева не заполнено");
            //}
            //else if (string.IsNullOrWhiteSpace(RightAdditionalText))
            //{
            //    MessageBox.Show("Примечание справа не заполнено");
            //}
            //else if (string.IsNullOrWhiteSpace(LeftAdditionalText))
            //{
            //    MessageBox.Show("Примечание слева не заполнено");
            //}



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
                    testThread = false;
                    //RemoveAllSaves();
                    Data.Complete();

                    SaveExaminationToSavedTable();

                    Data.Complete();


                        
                    Examination examnTotal = Data.Examination.Get(obsid);
                    ExaminationLeg leftLegExams = Data.ExaminationLeg.Get(examnTotal.idLeftLegExamination.Value);
                    ExaminationLeg rightLegExams = Data.ExaminationLeg.Get(examnTotal.idRightLegExamination.Value);
                    examnTotal.statementOverviewId = statementOverviewId;
                    examnTotal.hirurgOverviewId = hirurgOverviewId;


                    SavedExamination savedExamnTotal = Data.SavedExamination.GetAll.Where(e => e.acc_id == Acc_id).FirstOrDefault();
                    SavedExaminationLeg savedLegExamL = Data.SavedExaminationLeg.Get(savedExamnTotal.idLeftLegExamination.Value);
                    SavedExaminationLeg savedLegExamR = Data.SavedExaminationLeg.Get(savedExamnTotal.idRightLegExamination.Value);
                    //savedExamnTotal.acc_id = Acc_id;
                    examnTotal.height = savedExamnTotal.height;
                    examnTotal.weight = savedExamnTotal.weight;
                    // examnTotal.Comment = savedExamnTotal.Comment;
                    //examnTotal.Date = (savedExamnTotal.Date != null) ? savedExamnTotal.Date.Value : DateTime.Now;
                    //examnTotal.DoctorID = savedExamnTotal.DoctorID;
                    examnTotal.hirurgOverviewId = savedExamnTotal.hirurgOverviewId;
                    examnTotal.NB = savedExamnTotal.NB;
                    // examnTotal.OperationType = savedExamnTotal.OperationType;
                    examnTotal.PatientId = savedExamnTotal.PatientId;
                    examnTotal.statementOverviewId = savedExamnTotal.statementOverviewId;


                    leftLegExams.A = savedLegExamL.A;
                    leftLegExams.additionalText = savedLegExamL.additionalText;
                    leftLegExams.BPVHip = savedLegExamL.BPVHip;
                    leftLegExams.BPVTibiaid = savedLegExamL.BPVTibiaid;
                    leftLegExams.C = savedLegExamL.C;
                    leftLegExams.E = savedLegExamL.E;
                    leftLegExams.GVid = savedLegExamL.GVid;
                    leftLegExams.MPVid = savedLegExamL.MPVid;
                    leftLegExams.P = savedLegExamL.P;
                    leftLegExams.PDSVid = savedLegExamL.PDSVid;
                    leftLegExams.PerforateHipid = savedLegExamL.PerforateHipid;
                    leftLegExams.PPVid = savedLegExamL.PPVid;
                    leftLegExams.SFSid = savedLegExamL.SFSid;
                    leftLegExams.SPSid = savedLegExamL.SPSid;
                    leftLegExams.TEMPVid = savedLegExamL.TEMPVid;
                    leftLegExams.TibiaPerforateid = savedLegExamL.TibiaPerforateid;
                    leftLegExams.ZDSVid = savedLegExamL.ZDSVid;

                    rightLegExams.A = savedLegExamR.A;
                    rightLegExams.additionalText = savedLegExamR.additionalText;
                    rightLegExams.BPVHip = savedLegExamR.BPVHip;
                    rightLegExams.BPVTibiaid = savedLegExamR.BPVTibiaid;
                    rightLegExams.C = savedLegExamR.C;
                    rightLegExams.E = savedLegExamR.E;
                    rightLegExams.GVid = savedLegExamR.GVid;
                    rightLegExams.MPVid = savedLegExamR.MPVid;
                    rightLegExams.P = savedLegExamR.P;
                    rightLegExams.PDSVid = savedLegExamR.PDSVid;
                    rightLegExams.PerforateHipid = savedLegExamR.PerforateHipid;
                    rightLegExams.PPVid = savedLegExamR.PPVid;
                    rightLegExams.SFSid = savedLegExamR.SFSid;
                    rightLegExams.SPSid = savedLegExamR.SPSid;
                    rightLegExams.TEMPVid = savedLegExamR.TEMPVid;
                    rightLegExams.TibiaPerforateid = savedLegExamR.TibiaPerforateid;
                    rightLegExams.ZDSVid = savedLegExamR.ZDSVid;
                    //if (!LeftBPVHip.IsEmpty && leftLegExams.BPVHip == null)
                    //    leftLegExams.BPVHip = LeftBPVEntryFull.Id;

                    //if (!LeftBPVTibia.IsEmpty && leftLegExams.BPVTibiaid == null)
                    //    leftLegExams.BPVTibiaid = LeftBPV_TibiaEntryFull.Id;


                    //if (!LeftGV.IsEmpty && leftLegExams.GVid == null)
                    //    leftLegExams.GVid = LeftGVEntryFull.Id;

                    //if (!LeftMPV.IsEmpty && leftLegExams.MPVid == null)
                    //    leftLegExams.MPVid = LeftMPVEntryFull.Id;

                    //if (!LeftPDSV.IsEmpty && leftLegExams.PDSVid == null)
                    //    leftLegExams.PDSVid = LeftPDSVEntryFull.Id;

                    //if (!LeftPerforate.IsEmpty && leftLegExams.PerforateHipid == null)
                    //    leftLegExams.PerforateHipid = LeftPerforate_hipEntryFull.Id;

                    //if (!LeftPPV.IsEmpty && leftLegExams.PPVid == null)
                    //    leftLegExams.PPVid = LeftPPVEntryFull.Id;

                    //if (!LeftSFS.IsEmpty && leftLegExams.SFSid == null)
                    //    leftLegExams.SFSid = LeftSFSEntryFull.Id;

                    //if (!LeftSPS.IsEmpty && leftLegExams.SPSid == null)
                    //    leftLegExams.SPSid = LeftSPSEntryFull.Id;

                    //if (!LeftTEMPV.IsEmpty && leftLegExams.TEMPVid == null)
                    //    leftLegExams.TEMPVid = LeftTEMPVEntryFull.Id;

                    //if (!LeftTibiaPerforate.IsEmpty && leftLegExams.TibiaPerforateid == null)
                    //    leftLegExams.TibiaPerforateid = LeftPerforate_shinEntryFull.Id;

                    //if (!LeftZDSV.IsEmpty && leftLegExams.ZDSVid == null)
                    //    leftLegExams.ZDSVid = LeftZDSVEntryFull.Id;

                    //leftLegExams.additionalText = LeftAdditionalText;
                    //if (LeftCEAR.LegSections[0].SelectedValue != null)
                    //    leftLegExams.C = LeftCEAR.LegSections[0].SelectedValue.Id;
                    //if (LeftCEAR.LegSections[1].SelectedValue != null)
                    //    leftLegExams.E = LeftCEAR.LegSections[1].SelectedValue.Id;
                    //if (LeftCEAR.LegSections[2].SelectedValue != null)
                    //    leftLegExams.A = LeftCEAR.LegSections[2].SelectedValue.Id;
                    //if (LeftCEAR.LegSections[3].SelectedValue != null)
                    //    leftLegExams.P = LeftCEAR.LegSections[3].SelectedValue.Id;


                    //if (!RightBPVHip.IsEmpty && rightLegExams.BPVHip == null)
                    //    rightLegExams.BPVHip = RightBPVEntryFull.Id;

                    //if (!RightBPVTibia.IsEmpty && rightLegExams.BPVTibiaid == null)
                    //    rightLegExams.BPVTibiaid = RightBPV_TibiaEntryFull.Id;


                    //if (!RightGV.IsEmpty && rightLegExams.GVid == null)
                    //    rightLegExams.GVid = RightGVEntryFull.Id;

                    //if (!RightMPV.IsEmpty && rightLegExams.MPVid == null)
                    //    rightLegExams.MPVid = RightMPVEntryFull.Id;

                    //if (!RightPDSV.IsEmpty && rightLegExams.PDSVid == null)
                    //    rightLegExams.PDSVid = RightPDSVEntryFull.Id;

                    //if (!RightPerforate.IsEmpty && rightLegExams.PerforateHipid == null)
                    //    rightLegExams.PerforateHipid = RightPerforate_hipEntryFull.Id;

                    //if (!RightPPV.IsEmpty && rightLegExams.PPVid == null)
                    //    rightLegExams.PPVid = RightPPVEntryFull.Id;

                    //if (!RightSFS.IsEmpty && rightLegExams.SFSid == null)
                    //    rightLegExams.SFSid = RightSFSEntryFull.Id;

                    //if (!RightSPS.IsEmpty && rightLegExams.SPSid == null)
                    //    rightLegExams.SPSid = RightSPSEntryFull.Id;

                    //if (!RightTEMPV.IsEmpty && rightLegExams.TEMPVid == null)
                    //    rightLegExams.TEMPVid = RightTEMPVEntryFull.Id;

                    //if (!RightTibiaPerforate.IsEmpty && rightLegExams.TibiaPerforateid == null)
                    //    rightLegExams.TibiaPerforateid = RightPerforate_shinEntryFull.Id;

                    //if (!RightZDSV.IsEmpty && rightLegExams.ZDSVid == null)
                    //    rightLegExams.ZDSVid = RightZDSVEntryFull.Id;

                    //rightLegExams.additionalText = RightAdditionalText;
                    //if (RightCEAR.LegSections[0].SelectedValue != null)
                    //    rightLegExams.C = RightCEAR.LegSections[0].SelectedValue.Id;
                    //if (RightCEAR.LegSections[1].SelectedValue != null)
                    //    rightLegExams.E = RightCEAR.LegSections[1].SelectedValue.Id;
                    //if (RightCEAR.LegSections[2].SelectedValue != null)
                    //    rightLegExams.A = RightCEAR.LegSections[2].SelectedValue.Id;
                    //if (RightCEAR.LegSections[3].SelectedValue != null)
                    //    rightLegExams.P = RightCEAR.LegSections[3].SelectedValue.Id;



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

                            if (dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == true)
                            {
                                test = true;
                                foreach (var diag in LeftDiagnosisList)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_diagnosis == diag.Data.Id)
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
                                test = false;
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

                                    if (dgOp.id_diagnosis == diag.Data.Id && dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == true)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newDiag = new DiagnosisObs();
                                    newDiag.id_diagnosis = diag.Data.Id;
                                    newDiag.id_leg_examination = examnTotal.Id;
                                    newDiag.isLeft = true;
                                    Data.DiagnosisObs.Add(newDiag);
                                    Data.Complete();
                                    //    test = false;
                                }
                            }
                        }

                    }
                    test = false;
                    if (RightDiagnosisList != null)
                    {
                        foreach (var dgOp in Data.DiagnosisObs.GetAll)
                        {

                            if (dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == false)
                            {
                                test = true;
                                foreach (var diag in RightDiagnosisList)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_diagnosis == diag.Data.Id)
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
                                test = false;
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
                                    if (dgOp.id_diagnosis == diag.Data.Id && dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == false)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newDiag = new DiagnosisObs();
                                    newDiag.id_diagnosis = diag.Data.Id;
                                    newDiag.id_leg_examination = examnTotal.Id;
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

                            if (dgOp.id_examination == examnTotal.Id)
                            {
                                test = true;
                                foreach (var diag in RecomendationsList)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_recommendations == diag.Data.Id)
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
                                test = false;
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
                                    if (rcOp.id_recommendations == rec.Data.Id && rcOp.id_examination == examnTotal.Id.Value)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newRec = new RecomendationObs();
                                    newRec.id_recommendations = rec.Data.Id;
                                    newRec.id_examination = examnTotal.Id.Value;
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

                            if (dgOp.id_Examination == examnTotal.Id)
                            {
                                test = true;
                                foreach (var diag in ComplainsList)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_Complains == diag.Data.Id)
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
                                test = false;
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
                                    if (cmOp.id_Complains == cmp.Data.Id && cmOp.id_Examination == examnTotal.Id.Value)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newcmp = new ComplanesObs();
                                    newcmp.id_Complains = cmp.Data.Id;
                                    newcmp.id_Examination = examnTotal.Id.Value;
                                    Data.ComplanesObs.Add(newcmp);
                                    Data.Complete();
                                }
                            }
                        }
                    }
                    //   Data.Complete();
                    testThread = false;
                    RemoveAllSaves();
                    Data.Complete();
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                    mode = "Normal";

                }
                else
                {
                    testThread = false;

                    DialogYesNo.DialogYesNoViewModel vm =
                    new DialogYesNo.DialogYesNoViewModel("Назначить операцию?");
                    DialogResult result =
                        DialogService.DialogService.OpenDialog(vm, parameter as Window);

                    if (result == DialogResult.Yes)
                    {
                        DialogPreOperationViewModel vm1 = new DialogPreOperationViewModel(Data);
                        result = DialogService.DialogService.OpenDialog(vm1, parameter as Window);


                    }
                    SaveExaminationToSavedTable();

                    Data.Complete();

                    Examination examnTotal = new Examination();
                    ExaminationLeg leftLegExams = new ExaminationLeg();
                    ExaminationLeg rightLegExams = new ExaminationLeg();
                    SavedExamination savedExamnTotal = Data.SavedExamination.GetAll.Where(e => e.acc_id == Acc_id).FirstOrDefault();
                    SavedExaminationLeg savedLegExamL = Data.SavedExaminationLeg.Get(savedExamnTotal.idLeftLegExamination.Value);
                    SavedExaminationLeg savedLegExamR = Data.SavedExaminationLeg.Get(savedExamnTotal.idRightLegExamination.Value);

                    examnTotal.height = savedExamnTotal.height;
                    examnTotal.weight = savedExamnTotal.weight;
                    // examnTotal.Comment = savedExamnTotal.Comment;
                    examnTotal.Date = (savedExamnTotal.Date != null) ? savedExamnTotal.Date.Value : DateTime.Now;
                    examnTotal.DoctorID = savedExamnTotal.DoctorID;
                    examnTotal.hirurgOverviewId = savedExamnTotal.hirurgOverviewId;
                    examnTotal.NB = savedExamnTotal.NB;
                    // examnTotal.OperationType = savedExamnTotal.OperationType;
                    examnTotal.PatientId = savedExamnTotal.PatientId;
                    examnTotal.statementOverviewId = savedExamnTotal.statementOverviewId;


                    leftLegExams.A = savedLegExamL.A;
                    leftLegExams.additionalText = savedLegExamL.additionalText;
                    leftLegExams.BPVHip = savedLegExamL.BPVHip;
                    leftLegExams.BPVTibiaid = savedLegExamL.BPVTibiaid;
                    leftLegExams.C = savedLegExamL.C;
                    leftLegExams.E = savedLegExamL.E;
                    leftLegExams.GVid = savedLegExamL.GVid;
                    leftLegExams.MPVid = savedLegExamL.MPVid;
                    leftLegExams.P = savedLegExamL.P;
                    leftLegExams.PDSVid = savedLegExamL.PDSVid;
                    leftLegExams.PerforateHipid = savedLegExamL.PerforateHipid;
                    leftLegExams.PPVid = savedLegExamL.PPVid;
                    leftLegExams.SFSid = savedLegExamL.SFSid;
                    leftLegExams.SPSid = savedLegExamL.SPSid;
                    leftLegExams.TEMPVid = savedLegExamL.TEMPVid;
                    leftLegExams.TibiaPerforateid = savedLegExamL.TibiaPerforateid;
                    leftLegExams.ZDSVid = savedLegExamL.ZDSVid;

                    rightLegExams.A = savedLegExamR.A;
                    rightLegExams.additionalText = savedLegExamR.additionalText;
                    rightLegExams.BPVHip = savedLegExamR.BPVHip;
                    rightLegExams.BPVTibiaid = savedLegExamR.BPVTibiaid;
                    rightLegExams.C = savedLegExamR.C;
                    rightLegExams.E = savedLegExamR.E;
                    rightLegExams.GVid = savedLegExamR.GVid;
                    rightLegExams.MPVid = savedLegExamR.MPVid;
                    rightLegExams.P = savedLegExamR.P;
                    rightLegExams.PDSVid = savedLegExamR.PDSVid;
                    rightLegExams.PerforateHipid = savedLegExamR.PerforateHipid;
                    rightLegExams.PPVid = savedLegExamR.PPVid;
                    rightLegExams.SFSid = savedLegExamR.SFSid;
                    rightLegExams.SPSid = savedLegExamR.SPSid;
                    rightLegExams.TEMPVid = savedLegExamR.TEMPVid;
                    rightLegExams.TibiaPerforateid = savedLegExamR.TibiaPerforateid;
                    rightLegExams.ZDSVid = savedLegExamR.ZDSVid;


                    examnTotal.hirurgOverviewId = hirurgOverviewId;
                    examnTotal.statementOverviewId = statementOverviewId;
                    //SaveAll();
                    if (result == DialogResult.Yes)
                    {
                        examnTotal.isNeedOperation = true;
                        examnTotal.OperationType = OpTypeFromDialog;
                        examnTotal.Comment = OpCommentFromDialog;
                    }
                    else
                    {
                        examnTotal.isNeedOperation = false;
                    }




























                    //if (!LeftBPVHip.IsEmpty)
                    //    leftLegExams.BPVHip = LeftBPVEntryFull.Id;

                    //if (!LeftBPVTibia.IsEmpty)
                    //    leftLegExams.BPVTibiaid = LeftBPV_TibiaEntryFull.Id;


                    //if (!LeftGV.IsEmpty)
                    //    leftLegExams.GVid = LeftGVEntryFull.Id;

                    //if (!LeftMPV.IsEmpty)
                    //    leftLegExams.MPVid = LeftMPVEntryFull.Id;

                    //if (!LeftPDSV.IsEmpty)
                    //    leftLegExams.PDSVid = LeftPDSVEntryFull.Id;

                    //if (!LeftPerforate.IsEmpty)
                    //    leftLegExams.PerforateHipid = LeftPerforate_hipEntryFull.Id;

                    //if (!LeftPPV.IsEmpty)
                    //    leftLegExams.PPVid = LeftPPVEntryFull.Id;

                    //if (!LeftSFS.IsEmpty)
                    //    leftLegExams.SFSid = LeftSFSEntryFull.Id;

                    //if (!LeftSPS.IsEmpty)
                    //    leftLegExams.SPSid = LeftSPSEntryFull.Id;

                    //if (!LeftTEMPV.IsEmpty)
                    //    leftLegExams.TEMPVid = LeftTEMPVEntryFull.Id;

                    //if (!LeftTibiaPerforate.IsEmpty)
                    //    leftLegExams.TibiaPerforateid = LeftPerforate_shinEntryFull.Id;

                    //if (!LeftZDSV.IsEmpty)
                    //    leftLegExams.ZDSVid = LeftZDSVEntryFull.Id;

                    //leftLegExams.additionalText = LeftAdditionalText;
                    //if (LeftCEAR.LegSections[0].SelectedValue != null)
                    //    leftLegExams.C = LeftCEAR.LegSections[0].SelectedValue.Id;
                    //if (LeftCEAR.LegSections[1].SelectedValue != null)
                    //    leftLegExams.E = LeftCEAR.LegSections[1].SelectedValue.Id;
                    //if (LeftCEAR.LegSections[2].SelectedValue != null)
                    //    leftLegExams.A = LeftCEAR.LegSections[2].SelectedValue.Id;
                    //if (LeftCEAR.LegSections[3].SelectedValue != null)
                    //    leftLegExams.P = LeftCEAR.LegSections[3].SelectedValue.Id;


                    //if (!RightBPVHip.IsEmpty)
                    //    rightLegExams.BPVHip = RightBPVEntryFull.Id;

                    //if (!RightBPVTibia.IsEmpty)
                    //    rightLegExams.BPVTibiaid = RightBPV_TibiaEntryFull.Id;


                    //if (!RightGV.IsEmpty)
                    //    rightLegExams.GVid = RightGVEntryFull.Id;

                    //if (!RightMPV.IsEmpty)
                    //    rightLegExams.MPVid = RightMPVEntryFull.Id;

                    //if (!RightPDSV.IsEmpty)
                    //    rightLegExams.PDSVid = RightPDSVEntryFull.Id;

                    //if (!RightPerforate.IsEmpty)
                    //    rightLegExams.PerforateHipid = RightPerforate_hipEntryFull.Id;

                    //if (!RightPPV.IsEmpty)
                    //    rightLegExams.PPVid = RightPPVEntryFull.Id;

                    //if (!RightSFS.IsEmpty)
                    //    rightLegExams.SFSid = RightSFSEntryFull.Id;

                    //if (!RightSPS.IsEmpty)
                    //    rightLegExams.SPSid = RightSPSEntryFull.Id;

                    //if (!RightTEMPV.IsEmpty)
                    //    rightLegExams.TEMPVid = RightTEMPVEntryFull.Id;

                    //if (!RightTibiaPerforate.IsEmpty)
                    //    rightLegExams.TibiaPerforateid = RightPerforate_shinEntryFull.Id;

                    //if (!RightZDSV.IsEmpty)
                    //    rightLegExams.ZDSVid = RightZDSVEntryFull.Id;

                    //rightLegExams.additionalText = RightAdditionalText;
                    //if (RightCEAR.LegSections[0].SelectedValue != null)
                    //    rightLegExams.C = RightCEAR.LegSections[0].SelectedValue.Id;
                    //if (RightCEAR.LegSections[1].SelectedValue != null)
                    //    rightLegExams.E = RightCEAR.LegSections[1].SelectedValue.Id;
                    //if (RightCEAR.LegSections[2].SelectedValue != null)
                    //    rightLegExams.A = RightCEAR.LegSections[2].SelectedValue.Id;
                    //if (RightCEAR.LegSections[3].SelectedValue != null)
                    //    rightLegExams.P = RightCEAR.LegSections[3].SelectedValue.Id;

                    Data.ExaminationLeg.Add(leftLegExams);
                    Data.Complete();
                    Data.ExaminationLeg.Add(rightLegExams);
                    Data.Complete();

                    examnTotal.PatientId = CurrentPatient.Id;
                    examnTotal.Date = DateTime.Now;
                    if (result == DialogResult.Yes)
                    {
                        examnTotal.isNeedOperation = true;
                    }
                    else
                    {
                        examnTotal.isNeedOperation = false;
                    }

                    examnTotal.weight = float.Parse(Weight);
                    examnTotal.NB = TextTip;
                    examnTotal.height = float.Parse(Growth);
                    examnTotal.idLeftLegExamination = leftLegExams.Id;
                    examnTotal.idRightLegExamination = rightLegExams.Id;
                    Data.Examination.Add(examnTotal);
                    Data.Complete();
                    if (LeftDiagnosisList != null)
                    {
                        foreach (var diag in LeftDiagnosisList)
                        {
                            if (diag.IsChecked.Value)
                            {
                                var newDiag = new DiagnosisObs
                                {
                                    id_diagnosis = diag.Data.Id,
                                    id_leg_examination = examnTotal.Id,
                                    isLeft = true
                                };
                                Data.DiagnosisObs.Add(newDiag);
                                Data.Complete();
                            }
                        }
                    }

                    if (RightDiagnosisList != null)
                    {
                        foreach (var diag in RightDiagnosisList)
                        {
                            if (diag.IsChecked.Value)
                            {
                                var newDiag = new DiagnosisObs
                                {
                                    id_diagnosis = diag.Data.Id,
                                    id_leg_examination = examnTotal.Id,
                                    isLeft = false
                                };
                                Data.DiagnosisObs.Add(newDiag);
                                Data.Complete();
                            }
                        }
                    }

                    if (RecomendationsList != null)
                    {
                        foreach (var rec in RecomendationsList)
                        {
                            if (rec.IsChecked.Value)
                            {
                                var newRec = new RecomendationObs
                                {
                                    id_recommendations = rec.Data.Id,
                                    id_examination = examnTotal.Id.Value
                                };
                                Data.RecomendationObs.Add(newRec);
                                Data.Complete();
                            }
                        }
                    }

                    if (ComplainsList != null)
                    {
                        foreach (var cmp in ComplainsList)
                        {
                            if (cmp.IsChecked.Value)
                            {
                                var newcmp = new ComplanesObs();
                                newcmp.id_Complains = cmp.Data.Id;
                                newcmp.id_Examination = examnTotal.Id.Value;
                                Data.ComplanesObs.Add(newcmp);
                                Data.Complete();
                            }
                        }
                    }
                    //  Data.Complete();
                    testThread = false;
                    RemoveAllSaves();
                    Data.Complete();
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();
                }





            }
        }

        public static string FirstCharToLower(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToLower() + input.Substring(1);
            }
        }

        private void BuildStr(ref Paragraph p4, LegPartViewModel LegPart, bool isNormal)
        {
            if (!LegPart.IsEmpty)
            {
                int x = 0;
                if (!isNormal)
                {
                    p4.Append(LegPart.Title).Font("Times new roman").FontSize(11.0).UnderlineStyle(UnderlineStyle.singleLine).Append(": ").Font("Times new roman").FontSize(11.0);
                }
                else
                {
                    p4.Append(LegPart.Title).Font("Times new roman").FontSize(11.0).Append(": ").Font("Times new roman").FontSize(11.0); ;

                }
                if (!LegPart.IsEmpty)
                {

                    if (LegPart is PDSVViewModel)
                    {
                        var section = ((PDSVViewModel)LegPart).AdditionalStructure;
                        if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                        {
                            //++x;


                            if (section.SelectedValue.HasSize || section.HasDoubleSize)
                            {
                                if (section.HasDoubleSize)
                                {
                                    p4.Append(section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);

                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                    }
                                    else
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + "").Font("Times new roman").FontSize(11.0);

                                    }

                                }
                            }
                            else
                            {
                                p4.Append("").Font("Times new roman").FontSize(11.0);
                            }

                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                            {
                                p4.Append(section.SelectedValue.Text2).Font("Times new roman").FontSize(11.0);
                            }
                            //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                            //{
                            //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                            //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                            //    else
                            //    {
                            //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                            //    }
                            //}
                        }
                    }
                    else if (LegPart is ZDSVViewModel)
                    {
                        var section = ((ZDSVViewModel)LegPart).AdditionalStructure;
                        if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                        {
                            //++x;
                            //p4.Append("\nЗДСВ на бедре интерфасциально располагается ").Font("Times new roman").FontSize(11.0);

                            //if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                            //{

                            //    p4.Append(section.SelectedValue.Text1).Font("Times new roman").FontSize(11.0);


                            //}

                            if (section.SelectedValue.HasSize || section.HasDoubleSize)
                            {
                                if (section.HasDoubleSize)
                                {
                                    p4.Append(section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);

                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                    }
                                    else
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + "").Font("Times new roman").FontSize(11.0);

                                    }

                                }
                            }
                            else
                            {
                                p4.Append("").Font("Times new roman").FontSize(11.0);
                            }

                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                            {
                                p4.Append(section.SelectedValue.Text2).Font("Times new roman").FontSize(11.0);
                            }
                            //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                            //{
                            //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                            //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                            //    else
                            //    {
                            //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                            //    }

                            //}


                            //

                            //

                        }

                    }

                    //if (LegPart.SelectedWayType != null && !string.IsNullOrWhiteSpace(LegPart.SelectedWayType.Name) && !string.IsNullOrWhiteSpace(LegPart.SelectedWayType.Name))
                    //{
                    //    x++;

                    //    if (!isNormal)
                    //        p4.Append("вид хода: " + LegPart.SelectedWayType.Name).Font("Times new roman").FontSize(11.0);
                    //    else
                    //    {
                    //        p4.Append("вид хода: " + LegPart.SelectedWayType.Name).Font("Times new roman").FontSize(11.0);
                    //    }
                    //}



                    foreach (var section in LegPart.LegSections)
                    {
                        if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                            {


                                if (x == 0)
                                {
                                    p4.Append(GetStrFixedForDocumemnt(section.SelectedValue.Text1)).Font("Times new roman").FontSize(11.0);
                                }
                                else
                                {
                                    p4.Append(", " + GetStrFixedForDocumemnt(section.SelectedValue.Text1)).Font("Times new roman").FontSize(11.0);

                                }


                                x++;
                            }


                            if (section.SelectedValue.HasSize || section.HasDoubleSize)
                            {
                                if (section.HasDoubleSize)
                                {
                                    if (!isNormal)
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                    }
                                    else
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                    }


                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                    {
                                        if (!isNormal)
                                        {
                                            p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                        }
                                        else
                                        {
                                            p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                        }


                                    }
                                    else
                                    {
                                        if (!isNormal)
                                        {
                                            p4.Append(" " + section.CurrentEntry.Size + "").Font("Times new roman").FontSize(11.0);
                                        }
                                        else
                                        {
                                            p4.Append(" " + section.CurrentEntry.Size + "").Font("Times new roman").FontSize(11.0);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                //if (!isNormal)
                                //    p4.Append("").Font("Times new roman").FontSize(11.0);
                                //else
                                //{
                                //    p4.Append("").Font("Times new roman").FontSize(11.0);
                                //}

                            }

                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                            {
                                if (!isNormal)
                                {
                                    p4.Append(" " + section.SelectedValue.Text2 + "").Font("Times new roman").FontSize(11.0);
                                }
                                else
                                {
                                    p4.Append(" " + section.SelectedValue.Text2 + "").Font("Times new roman").FontSize(11.0);
                                }

                            }
                            if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                            {
                                if (!isNormal)
                                {
                                    p4.Append("\nКомментарий: " + section.CurrentEntry.Comment + "").Font("Times new roman").FontSize(11.0);
                                }
                                else
                                {
                                    p4.Append("\nКомментарий: " + section.CurrentEntry.Comment + "").Font("Times new roman").FontSize(11.0);
                                }

                            }

                        }
                    }
                    if (LegPart is PDSVViewModel)
                    {
                        var section = ((PDSVViewModel)LegPart).AdditionalStructure;

                        p4.Append(".\nПДСВ на бедре интерфасциально располагается ").Font("Times new roman").FontSize(11.0);
                        //  p4 += "ПДСВ на бедре интерфасциально располагается ";
                        if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                        {

                            p4.Append(section.SelectedValue.Text1).Font("Times new roman").FontSize(11.0);


                        }
                    }
                    if (LegPart is BPVHipViewModel)
                    {
                        var section = ((BPVHipViewModel)LegPart).AdditionalStructure;
                        if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                        {
                            ++x;
                            p4.Append("\nБПВ на бедре интерфасциально располагается ").Font("Times new roman").FontSize(11.0);
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                            {

                                p4.Append(section.SelectedValue.Text1).Font("Times new roman").FontSize(11.0);


                            }

                            if (section.SelectedValue.HasSize || section.HasDoubleSize)
                            {
                                if (section.HasDoubleSize)
                                {
                                    p4.Append(section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);

                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                    }
                                    else
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + "").Font("Times new roman").FontSize(11.0);

                                    }

                                }
                            }
                            else
                            {
                                p4.Append("").Font("Times new roman").FontSize(11.0);
                            }

                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                            {
                                p4.Append(section.SelectedValue.Text2).Font("Times new roman").FontSize(11.0);
                            }
                        }
                    }
                    else if (LegPart is SPSViewModel)
                    {
                        var section = ((SPSViewModel)LegPart).AdditionalStructure;
                        if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                        {
                            ++x;
                            p4.Append(", расположено ").Font("Times new roman").FontSize(11.0);
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                            {

                                p4.Append(section.SelectedValue.Text1).Font("Times new roman").FontSize(11.0);


                            }

                            if (section.SelectedValue.HasSize || section.HasDoubleSize)
                            {
                                if (section.HasDoubleSize)
                                {
                                    p4.Append(section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);

                                }
                                else
                                {
                                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + " " + section.SelectedValue.Metrics + ".").Font("Times new roman").FontSize(11.0);
                                    }
                                    else
                                    {
                                        p4.Append(" " + section.CurrentEntry.Size + "").Font("Times new roman").FontSize(11.0);

                                    }

                                }
                            }
                            else
                            {
                                p4.Append("").Font("Times new roman").FontSize(11.0);
                            }

                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                            {
                                p4.Append(section.SelectedValue.Text2).Font("Times new roman").FontSize(11.0);
                            }
                            //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                            //{
                            //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                            //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                            //    else
                            //    {
                            //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                            //    }

                            //}


                            //

                            //

                        }

                    }
                    if(LegPart is ZDSVViewModel)
                    {
                        var section = ((ZDSVViewModel)LegPart).AdditionalStructure;

                        p4.Append(".\nЗДСВ на бедре интерфасциально располагается ").Font("Times new roman").FontSize(11.0);

                        if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                        {

                            p4.Append(section.SelectedValue.Text1).Font("Times new roman").FontSize(11.0);


                        }
                    }
                    if (LegPart is TEMPVViewModel)
                    {
                        if (x == 0)
                        {
                            if (!isNormal)
                            {
                                p4.Append(", протяженностью " + ((TEMPVViewModel)LegPart).FF_length + " см.").Font("Times new roman").FontSize(11.0);
                            }
                            else
                            {
                                p4.Append(", протяженностью " + ((TEMPVViewModel)LegPart).FF_length + " см.").Font("Times new roman").FontSize(11.0);
                            }
                        }
                        else
                        {
                            if (!isNormal)
                            {
                                p4.Append(", протяженностью " + ((TEMPVViewModel)LegPart).FF_length + " см.").Font("Times new roman").FontSize(11.0);
                            }
                            else
                            {
                                p4.Append(", протяженностью " + ((TEMPVViewModel)LegPart).FF_length + " см.").Font("Times new roman").FontSize(11.0);
                            }
                        }
                        x++;
                    }
                    //else


                    string buf = p4.Text[p4.Text.Length - 1].ToString();
                    if (buf != ".")
                    {
                        p4.Append(".").Font("Times new roman").FontSize(11.0);
                    }
                    string name = "";
                    if (!string.IsNullOrWhiteSpace(LegPart.Comment))
                    {
                        if (LegPart is PDSVViewModel)
                        {


                            name = "ПДСВ";


                        }
                        else if (LegPart is SFSViewModel)
                        {


                            name = "СФС";


                        }
                        else if (LegPart is BPVHipViewModel)
                        {

                            name = "БПВНБ";


                        }
                        else if (LegPart is BPVTibiaViewModel)
                        {

                            name = "БПВНГ";


                        }
                        else if (LegPart is HipPerforateViewModel)
                        {


                            name = "ПБИНВ";


                        }
                        else if (LegPart is ZDSVViewModel)
                        {

                            name = "ЗДСВ";

                        }

                        else if (LegPart is SPSViewModel)
                        {
                            name = "СПС";

                        }
                        else if (LegPart is TibiaPerforateViewModel)
                        {

                            name = "ПГ";

                        }
                        else if (LegPart is MPVViewModel)
                        {

                            name = "МПВ";


                        }
                        else if (LegPart is TEMPVViewModel)
                        {
                            name = "ТЕМПВ";

                        }
                        else if (LegPart is PPVViewModel)
                        {

                            name = "ППВ";


                        }
                        else if (LegPart is GVViewModel)
                        {

                            name = "ГВ";

                        }
                        if (!isNormal)
                        {
                            p4.Append("\nКомментарий к " + name + " : " + LegPart.Comment).Font("Times new roman").FontSize(11.0);
                        }
                        else
                        {
                            p4.Append("\nКомментарий к " + name + " : " + LegPart.Comment).Font("Times new roman").FontSize(11.0);
                        }

                    }
                }
                p4.Append(" \n").FontSize(11.0);
            }
        }

        private string GetStrFixedForDocumemnt(string str)
        {
            List<char> chararr = str.ToCharArray().ToList();
            if (chararr[chararr.Count - 1] == '.')
            {
                chararr.RemoveAt(chararr.Count - 1);
            }
            if (char.IsUpper(chararr[0]) && char.IsLower(chararr[1]))
            {
                chararr[0] = char.ToLower(chararr[0]);
            }
            string result = "";
            foreach (var x in chararr)
            {
                result += x;
            }



            return result;
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
        // int docsCreated = 0;
        private void CreateStatement(string docName, string _fileNameOnly, string doctorInits)
        {
            try
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
                    int day12 = CurrentPatient.Birthday.Day;
                    int mnth12 = CurrentPatient.Birthday.Month;
                    string mnthStr1 = "";
                    string dayStr1 = "";
                    if (mnth12 < 10)
                    {
                        mnthStr1 += "0" + mnth12.ToString();
                    }
                    else
                    {
                        mnthStr1 = mnth12.ToString();
                    }

                    if (day12 < 10)
                    {
                        dayStr1 += "0" + day12.ToString();
                    }
                    else
                    {
                        dayStr1 = day12.ToString();
                    }
                    p.Append("Консультативное заключение\n").Font("Times new roman").Bold().FontSize(14.0).Alignment = Alignment.center;
                    p1.Append("" + CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic + ", " + dayStr1 + "." + mnthStr1 + "." + CurrentPatient.Birthday.Year + "                            Дата: " + DateTime.Now.ToShortDateString() + "\n").Font("Times new roman").FontSize(12.0);
                    p2.Append("Допплерография вен нижних конечностей:\n").Font("Times new roman").Bold().FontSize(13.0);
                    p3.Append("Правая нижняя конечность:").Font("Times new roman").Bold().FontSize(11.0);
                    //if(!RightSFS.)
                    BuildStr(ref p4, RightGV, false);
                    BuildStr(ref p4, RightSFS, true);
                    BuildStr(ref p4, RightBPVHip, false);
                    BuildStr(ref p4, RightPDSV, true);
                    BuildStr(ref p4, RightZDSV, true);
                    BuildStr(ref p4, RightPerforate, true);
                    BuildStr(ref p4, RightBPVTibia, false);
                    BuildStr(ref p4, RightTibiaPerforate, true);
                    BuildStr(ref p4, RightSPS, true);
                    BuildStr(ref p4, RightMPV, false);
                    BuildStr(ref p4, RightTEMPV, false);
                    BuildStr(ref p4, RightPPV, false);


                    if (!string.IsNullOrWhiteSpace(RightAdditionalText))
                    {

                        string buf = RightAdditionalText[RightAdditionalText.Length - 1].ToString();
                        if (buf != ".")
                        {
                            p4.Append("Примечание: " + RightAdditionalText + ".\n").Font("Times new roman").FontSize(11.0);
                        }
                        else
                        {
                            p4.Append("Примечание: " + RightAdditionalText + "\n").Font("Times new roman").FontSize(11.0);
                        }
                    }
                    p4.Append("\n\nЛевая нижняя конечность:\n").Font("Times new roman").Bold().FontSize(11.0);
                    BuildStr(ref p4, LeftGV, false);
                    BuildStr(ref p4, LeftSFS, true);
                    BuildStr(ref p4, LeftBPVHip, false);
                    BuildStr(ref p4, LeftPDSV, false);
                    BuildStr(ref p4, LeftZDSV, true);
                    BuildStr(ref p4, LeftPerforate, true);
                    BuildStr(ref p4, LeftBPVTibia, false);
                    BuildStr(ref p4, LeftTibiaPerforate, true);
                    BuildStr(ref p4, LeftSPS, true);
                    BuildStr(ref p4, LeftMPV, false);
                    BuildStr(ref p4, LeftTEMPV, false);
                    BuildStr(ref p4, LeftPPV, false);

                    //true false
                    if (!string.IsNullOrWhiteSpace(LeftAdditionalText))
                    {
                        string buf1 = LeftAdditionalText[LeftAdditionalText.Length - 1].ToString();
                        if (buf1 != ".")
                        {
                            p4.Append("Примечание: " + LeftAdditionalText + ".\n").Font("Times new roman").FontSize(11.0);
                        }
                        else
                        {
                            p4.Append("Примечание: " + LeftAdditionalText + "\n").Font("Times new roman").FontSize(11.0);
                        }
                    }
                    p4.Append("\n\nЗаключение:\n").Font("Times new roman").Bold().FontSize(11.0);

                    p4.Append("").Font("Times new roman").FontSize(11.0);
                    int x = 0;
                    foreach (var letter in RightDiagnosisList)
                    {
                        if (letter.IsChecked != null && letter.IsChecked == true)
                        {
                            if (x == 0)
                            {
                                p4.Append("" + FirstCharToUpper(GetStrFixedForDocumemnt(letter.Data.Str)) + "").Font("Times new roman").FontSize(11.0);
                            }
                            else
                            {
                                p4.Append(", " + letter.Data.Str).Font("Times new roman").FontSize(11.0);
                            }
                            x++;
                        }
                    }
                    char[] chararrbuF = p4.Text.ToCharArray();
                    if (chararrbuF[chararrbuF.Length - 1] == '.')
                    { }
                    else
                    {
                        p4.Append(".").Font("Times new roman").FontSize(11.0);
                    }

                    p4.Append(" ").Font("Times new roman").FontSize(11.0);


                    foreach (var letter in RightCEAR.LegSections)
                    {
                        if (letter.SelectedValue != null)
                        {
                            p4.Append("" + letter.SelectedValue.Leter + letter.SelectedValue.Text1 + "").Font("Times new roman").FontSize(11.0);

                        }
                    }
                    p4.Append(".\n").Font("Times new roman").FontSize(11.0);

                    //p4.Append("\nЗаключение слева: ").Font("Times new roman").FontSize(11.0);
                    x = 0;
                    foreach (var letter in LeftDiagnosisList)
                    {
                        if (letter.IsChecked != null && letter.IsChecked == true)
                        {
                            if (x == 0)
                            {
                                p4.Append("" + FirstCharToUpper(GetStrFixedForDocumemnt(letter.Data.Str)) + "").Font("Times new roman").FontSize(11.0);
                            }
                            else
                            {
                                p4.Append(", " + letter.Data.Str).Font("Times new roman").FontSize(11.0);
                            }
                            x++;
                        }
                    }
                    chararrbuF = p4.Text.ToCharArray();
                    if (chararrbuF[chararrbuF.Length - 1] == '.')
                    { }
                    else
                    {
                        p4.Append(".").Font("Times new roman").FontSize(11.0);
                    }
                    p4.Append(" ").Font("Times new roman").FontSize(11.0);
                    foreach (var letter in LeftCEAR.LegSections)
                    {
                        if (letter.SelectedValue != null)
                        {
                            p4.Append("" + letter.SelectedValue.Leter + letter.SelectedValue.Text1 + "").Font("Times new roman").FontSize(11.0);

                        }
                    }
                    p4.Append(".").Font("Times new roman").FontSize(11.0);
                    int ia = 0;
                    p4.Append("\n\nРекомендовано").Font("Times new roman").FontSize(11.0).Bold().UnderlineStyle(UnderlineStyle.singleLine).Append(": ").Font("Times new roman").FontSize(11.0);
                    if (RecomendationsList != null)
                    {
                        foreach (var rec in RecomendationsList)
                        {
                            if (rec.IsChecked == true)
                            {
                                if (ia == 0)
                                {
                                    p4.Append("" + rec.Data.Str + "").Font("Times new roman").FontSize(11.0);
                                }
                                else
                                { p4.Append(", " + rec.Data.Str + "").Font("Times new roman").FontSize(11.0); }
                                ia++;
                            }
                        }
                        p4.Append(".").Font("Times new roman").FontSize(11.0);
                        //   p4.Append("Сафено-феморальное соустье").Font("Times new roman").FontSize(11.0).UnderlineStyle(UnderlineStyle.singleLine);
                        //foreach (var section in RightSFS.LegSections)
                        //{
                        //    if (section.SelectedValue != null)
                        //        p4.Append(" " + section.SelectedValue.Text1 + "").Font("Times new roman").FontSize(11.0);
                        //}
                        if (!string.IsNullOrWhiteSpace(doctorInits))
                        {
                            p5.Alignment = Alignment.right;
                            p5.Append("\n\nВрач: " + doctorInits).Font("Times new roman").FontSize(11.0);
                        }
                    }
                    // Save this document.
                    document.Save();
                    // Release this document from memory.
                    byte[] bteToBD = File.ReadAllBytes(docName);
                    StatementObs Hv = new StatementObs();
                    if (statementOverviewId != null && statementOverviewId != 0)
                    {
                        Hv = Data.StatementObs.Get(statementOverviewId.Value);

                        Hv.DocTemplate = bteToBD;

                        Data.Complete();
                    }
                    else
                    {

                        Hv.DocTemplate = bteToBD;
                        //Hv.DoctorId = int.Parse(p2.ToString());
                        Data.StatementObs.Add(Hv);

                        Data.Complete();
                        statementOverviewId = Hv.Id;
                    }
                    //bool tester = true;
                    //foreach (var x in HirurgOverviewRep.GetAll)
                    //{

                    //    if (x.PatientId == CurrentPatient.Id)
                    //    {
                    //        tester = false;
                    //        Hv = Data.HirurgOverview.Get(x.Id);
                    //        Hv.DocTemplate = bteToBD;

                    //        Data.Complete();
                    //        break;
                    //    }

                    //    // HirurgOverview Hv = new HirurgOverview();
                    //}
                    //if (tester)
                    //{
                    //    Hv.PatientId = CurrentPatient.Id;
                    //    Hv.DocTemplate = bteToBD;
                    //    Data.HirurgOverview.Add(Hv);
                    //    Data.Complete();
                    //}

                    MessageBus.Default.Call("GetStatementForStatementFILENAME", docName, null);
                    MessageBus.Default.Call("GetStatementForStatement", _fileNameOnly, statementOverviewId);
                }

                Process.Start("WINWORD.EXE", docName);
            }
            catch { }
        }

        private void BrushesFill()
        {








            //else if (RightMPV.IsEmpty == true)
            //{
            //    MessageBox.Show("МПВ справа не заполнено");
            //}
            //else if (LeftMPV.IsEmpty == true)
            //{
            //    MessageBox.Show("МПВ слева не заполнено");
            //}

            if (LeftGV.IsEmpty == true)
            {


                BGV = Brushes.Red;

            }
            else if (LeftGV.IsEmpty != true)
            {
                BGV = null;
            }


            if (RightGV.IsEmpty == true)
            {


                BGVL = Brushes.Red;
            }
            else if (RightGV.IsEmpty != true)
            {
                BGVL = null;
            }


            if (LeftSFS.IsEmpty == true)
            {

                BPDSV = Brushes.Red;
            }
            else if (LeftSFS.IsEmpty != true)
            {
                BPDSV = null;
            }


            if (RightSFS.IsEmpty == true)
            {

                BPDSVL = Brushes.Red;
            }
            else if (RightSFS.IsEmpty != true)
            {
                BPDSVL = null;
            }




            if (RightBPVHip.IsEmpty == true)
            {

                BZDSVL = Brushes.Red;
            }
            else if (RightBPVHip.IsEmpty != true)
            {
                BZDSVL = null;
            }


            if (LeftBPVHip.IsEmpty == true)
            {

                BZDSV = Brushes.Red;
            }
            else if (LeftBPVHip.IsEmpty != true)
            {
                BZDSV = null;
            }

            if (RightBPVTibia.IsEmpty == true)
            {

                BPerforate1L = Brushes.Red;
            }
            else if (RightBPVTibia.IsEmpty != true)
            {
                BPerforate1L = null;
            }

            if (LeftBPVTibia.IsEmpty == true)
            {

                BPerforate1 = Brushes.Red;
            }
            else if (LeftBPVTibia.IsEmpty != true)
            {
                BPerforate1 = null;
            }


            if (RightSPS.IsEmpty == true)
            {

                BPerforateGoleniL = Brushes.Red;
            }

            else if (RightSPS.IsEmpty != true)
            {
                BPerforateGoleniL = null;
            }


            if (LeftSPS.IsEmpty == true)
            {

                BPerforateGoleni = Brushes.Red;
            }
            else if (LeftSPS.IsEmpty != true)
            {
                BPerforateGoleni = null;
            }
            //1313

            if (RightMPV.IsEmpty == true)
            {

                BTEMPVL = Brushes.Red;
            }
            else if (RightMPV.IsEmpty != true)
            {
                BTEMPVL = null;
            }
            if (LeftMPV.IsEmpty == true)
            {

                BTEMPV = Brushes.Red;
            }
            else if (LeftMPV.IsEmpty != true)
            {
                BTEMPV = null;
            }

            //if (RightPPV.IsEmpty == true)
            //{

            //    BPPVL = Brushes.Red;
            //}
            //else if (RightPPV.IsEmpty != true)
            //{
            //    BPPVL = null;
            //}

            //if (LeftPPV.IsEmpty == true)
            //{

            //    BPPV = Brushes.Red;
            //}
            //else if (LeftPPV.IsEmpty != true)
            //{
            //    BPPV = null;
            //}

            //if (string.IsNullOrWhiteSpace(RightAdditionalText))
            //{

            //    BAdditionalTextL = Brushes.Red;
            //}
            //else if (!string.IsNullOrWhiteSpace(RightAdditionalText))
            //{
            //    BAdditionalTextL = null;
            //}


            //if (string.IsNullOrWhiteSpace(LeftAdditionalText))
            //{

            //    BAdditionalText = Brushes.Red;
            //}
            //else if (!string.IsNullOrWhiteSpace(LeftAdditionalText))
            //{
            //    BAdditionalText = null;
            //}

            if (LeftCEAR.LegSections[0].SelectedValue == null)
            {
                BCEAR = Brushes.Red;
            }

            if (LeftCEAR.LegSections[1].SelectedValue == null)
            {
                BCEAR = Brushes.Red;
            }

            if (LeftCEAR.LegSections[2].SelectedValue == null)
            {
                BCEAR = Brushes.Red;
            }

            if (LeftCEAR.LegSections[3].SelectedValue == null)
            {
                BCEAR = Brushes.Red;
            }

            if (LeftCEAR.LegSections[0].SelectedValue != null && LeftCEAR.LegSections[1].SelectedValue != null && LeftCEAR.LegSections[2].SelectedValue != null && LeftCEAR.LegSections[3].SelectedValue != null)
            {
                BCEAR = null;
            }

            if (RightCEAR.LegSections[0].SelectedValue == null)
            {
                BCEARL = Brushes.Red;
            }
            if (RightCEAR.LegSections[1].SelectedValue == null)
            {
                BCEARL = Brushes.Red;
            }
            if (RightCEAR.LegSections[2].SelectedValue == null)
            {
                BCEARL = Brushes.Red;
            }
            if (RightCEAR.LegSections[3].SelectedValue == null)
            {
                BCEARL = Brushes.Red;
            }
            if (RightCEAR.LegSections[0].SelectedValue != null && RightCEAR.LegSections[1].SelectedValue != null && RightCEAR.LegSections[2].SelectedValue != null && RightCEAR.LegSections[3].SelectedValue != null)
            {
                BCEARL = null;
            }

        }

        private bool isEdited = false;
        //private bool TestAllFIelds()
        //{


        //    bool test = true;
        //    if (LeftGV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ГВ слева не заполнено");
        //        test = false;
        //        BGV = Brushes.Red;

        //    }
        //    else if (LeftGV.IsEmpty != true)
        //    {
        //        BGV = null;
        //    }
        //     if (RightGV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ГВ справа не заполнено");
        //        test = false;
        //        BGVL = Brushes.Red;
        //    }
        //    else if (RightGV.IsEmpty != true)
        //    {
        //        BGVL = null;
        //    }

        //     if (LeftPDSV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ПДСВ слева не заполнено"); test = false;
        //        BPDSV = Brushes.Red;
        //    }
        //    else if (LeftPDSV.IsEmpty != true)
        //    {
        //        BPDSV = null;
        //    }

        //     if (RightPDSV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ПДСВ справа не заполнено"); test = false;
        //        BPDSVL = Brushes.Red;
        //    }
        //    else if (RightPDSV.IsEmpty != true)
        //    {
        //        BPDSVL = null;
        //    }



        //     if (RightZDSV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ЗДСВ справа не заполнено"); test = false;
        //        BZDSVL = Brushes.Red;
        //    }
        //    else if (RightZDSV.IsEmpty != true)
        //    {
        //        BZDSVL = null;
        //    }

        //     if (LeftZDSV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ЗДСВ слева не заполнено"); test = false;
        //        BZDSV = Brushes.Red;
        //    }
        //    else if (LeftZDSV.IsEmpty != true)
        //    {
        //        BZDSV = null;
        //    }
        //     if (RightPerforate.IsEmpty == true)
        //    {
        //        MessageBox.Show("Перфоранты бедра и несафенные вены справа не заполнено"); test = false;
        //        BPerforate1L = Brushes.Red;
        //    }
        //    else if (RightPerforate.IsEmpty != true)
        //    {
        //        BPerforate1L = null;
        //    }
        //     if (LeftPerforate.IsEmpty == true)
        //    {
        //        MessageBox.Show("Перфоранты бедра и несафенные вены слева не заполнено"); test = false;
        //        BPerforate1 = Brushes.Red;
        //    }
        //    else if (LeftPerforate.IsEmpty != true)
        //    {
        //        BPerforate1 = null;
        //    }

        //     if (RightTibiaPerforate.IsEmpty == true)
        //    {
        //        test = false;
        //        MessageBox.Show("Перфоранты голени справа не заполнено");
        //        BPerforateGoleniL = Brushes.Red;
        //    }

        //    else if (RightTibiaPerforate.IsEmpty != true)
        //    {
        //        BPerforateGoleniL = null;
        //    }
        //     if (LeftTibiaPerforate.IsEmpty == true)
        //    {
        //        MessageBox.Show("Перфоранты голени слева не заполнено"); test = false;
        //        BPerforateGoleni = Brushes.Red;
        //    }
        //    else if (LeftTibiaPerforate.IsEmpty != true)
        //    {
        //        BPerforateGoleni = null;
        //    }

        //     if (RightTEMPV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ТЕ МПВ справа не заполнено"); test = false;
        //        BTEMPVL = Brushes.Red;
        //    }
        //    else if (RightTEMPV.IsEmpty != true)
        //    {
        //        BTEMPVL = null;
        //    }
        //     if (LeftTEMPV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ТЕ МПВ слева не заполнено"); test = false;
        //        BTEMPV = Brushes.Red;
        //    }
        //    else if (LeftTEMPV.IsEmpty != true)
        //    {
        //        BTEMPV = null;
        //    }

        //     if (RightPPV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ППВ справа не заполнено"); test = false;
        //        BPPVL = Brushes.Red;
        //    }
        //    else if (RightPPV.IsEmpty != true)
        //    {
        //        BPPVL = null;
        //    }

        //     if (LeftPPV.IsEmpty == true)
        //    {
        //        MessageBox.Show("ППВ слева не заполнено"); test = false;
        //        BPPV = Brushes.Red;
        //    }
        //    else if (LeftPPV.IsEmpty != true)
        //    {
        //        BPPV = null;
        //    }

        //     if (string.IsNullOrWhiteSpace(RightAdditionalText))
        //    {
        //        MessageBox.Show("Примечание справа не заполнено"); test = false;
        //        BAdditionalTextL = Brushes.Red;
        //    }
        //    else if (!string.IsNullOrWhiteSpace(RightAdditionalText))
        //    {
        //        BAdditionalTextL = null;
        //    }


        //     if (string.IsNullOrWhiteSpace(LeftAdditionalText))
        //    {
        //        MessageBox.Show("Примечание слева не заполнено"); test = false;
        //        BAdditionalText = Brushes.Red;
        //    }
        //    else if (!string.IsNullOrWhiteSpace(LeftAdditionalText))
        //    {
        //        BAdditionalText = null;
        //    }

        //     if (LeftCEAR.LegSections[0].SelectedValue == null)
        //    {
        //        MessageBox.Show("C слева не заполнено"); test = false; BCEAR = Brushes.Red;
        //    }

        //    else if (LeftCEAR.LegSections[1].SelectedValue == null)
        //    {
        //        MessageBox.Show("E слева не заполнено"); test = false; BCEAR = Brushes.Red;
        //    }

        //    else if (LeftCEAR.LegSections[2].SelectedValue == null)
        //    {
        //        MessageBox.Show("A слева не заполнено"); test = false; BCEAR = Brushes.Red;
        //    }

        //    else if (LeftCEAR.LegSections[3].SelectedValue == null)
        //    {
        //        MessageBox.Show("P слева не заполнено"); test = false; BCEAR = Brushes.Red;
        //    }

        //    else if (LeftCEAR.LegSections[0].SelectedValue != null && LeftCEAR.LegSections[1].SelectedValue != null && LeftCEAR.LegSections[2].SelectedValue != null && LeftCEAR.LegSections[3].SelectedValue != null)
        //    {
        //        BCEAR = null;
        //    }

        //    else if (RightCEAR.LegSections[0].SelectedValue == null)
        //    {
        //        MessageBox.Show("C справа не заполнено"); test = false; BCEARL = Brushes.Red;
        //    }
        //    else if (RightCEAR.LegSections[1].SelectedValue == null)
        //    {
        //        MessageBox.Show("E справа не заполнено"); test = false; BCEARL = Brushes.Red;
        //    }
        //    else if (RightCEAR.LegSections[2].SelectedValue == null)
        //    {
        //        MessageBox.Show("A справа не заполнено"); test = false; BCEARL = Brushes.Red;
        //    }
        //    else if (RightCEAR.LegSections[3].SelectedValue == null)
        //    {
        //        MessageBox.Show("P справа не заполнено"); test = false; BCEARL = Brushes.Red;
        //    }
        //    else if (RightCEAR.LegSections[0].SelectedValue != null && RightCEAR.LegSections[1].SelectedValue != null && RightCEAR.LegSections[2].SelectedValue != null && RightCEAR.LegSections[3].SelectedValue != null)
        //    {
        //        BCEARL = null;
        //    }
        //    BrushesFill();
        //    return test;
        //}
        public string CreateStrForOverview(LegPartViewModel LegPart)
        {
            if (LegPart.IsEmpty) { return ""; }
            string p4 = "";
            if (LegPart.SelectedWayType != null && !string.IsNullOrWhiteSpace(LegPart.SelectedWayType.Name) && !string.IsNullOrWhiteSpace(LegPart.SelectedWayType.Name))
            {
                p4 += "Вид хода: " + LegPart.SelectedWayType.Name + "\n";
            }

            if (LegPart is TEMPVViewModel)
            {
                p4 += "Протяженностью " + ((TEMPVViewModel)LegPart).FF_length + " см\n";
            }

            int x = 0;
            if (LegPart is BPVHipViewModel)
            {
                var section = ((BPVHipViewModel)LegPart).AdditionalStructure;
                if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                {
                    ++x;
                    p4 += "\nБПВ на бедре интерфасциально располагается ";
                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                    {

                        p4 += "" + section.SelectedValue.Text1 + "";


                    }

                    if (section.SelectedValue.HasSize || section.HasDoubleSize)
                    {
                        if (section.HasDoubleSize)
                        {
                            p4 += " " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                            {
                                p4 += " " + section.CurrentEntry.Size + "" + section.SelectedValue.Metrics + ".";
                            }
                            else
                            {
                                p4 += " " + section.CurrentEntry.Size + "";

                            }

                        }
                    }
                    else
                    {
                        p4 += "";
                    }

                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                    {
                        p4 += "" + section.SelectedValue.Text2 + "";
                    }
                    //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                    //{
                    //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                    //    else
                    //    {
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                    //    }

                    //}


                    //

                    //

                }

            }
            else if (LegPart is PDSVViewModel)
            {
                var section = ((PDSVViewModel)LegPart).AdditionalStructure;
                if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                {
                    ++x;
                    p4 += "ПДСВ на бедре интерфасциально располагается ";
                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                    {

                        p4 += "" + section.SelectedValue.Text1 + "";


                    }

                    if (section.SelectedValue.HasSize || section.HasDoubleSize)
                    {
                        if (section.HasDoubleSize)
                        {
                            p4 += " " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                            {
                                p4 += " " + section.CurrentEntry.Size + "" + section.SelectedValue.Metrics + ".";
                            }
                            else
                            {
                                p4 += " " + section.CurrentEntry.Size + "";

                            }

                        }
                    }
                    else
                    {
                        p4 += "";
                    }

                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                    {
                        p4 += "" + section.SelectedValue.Text2 + "";
                    }
                    //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                    //{
                    //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                    //    else
                    //    {
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                    //    }

                    //}


                    //

                    //

                }

            }
            else if (LegPart is ZDSVViewModel)
            {
                var section = ((ZDSVViewModel)LegPart).AdditionalStructure;
                if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                {
                    ++x;
                    p4 += "\nЗДСВ на бедре интерфасциально располагается ";
                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                    {

                        p4 += "" + section.SelectedValue.Text1 + "";


                    }

                    if (section.SelectedValue.HasSize || section.HasDoubleSize)
                    {
                        if (section.HasDoubleSize)
                        {
                            p4 += " " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                            {
                                p4 += " " + section.CurrentEntry.Size + "" + section.SelectedValue.Metrics + ".";
                            }
                            else
                            {
                                p4 += " " + section.CurrentEntry.Size + "";

                            }

                        }
                    }
                    else
                    {
                        p4 += "";
                    }

                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                    {
                        p4 += "" + section.SelectedValue.Text2 + "";
                    }
                    //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                    //{
                    //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                    //    else
                    //    {
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                    //    }

                    //}


                    //

                    //

                }

            }
            else if (LegPart is SPSViewModel)
            {
                var section = ((SPSViewModel)LegPart).AdditionalStructure;
                if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                {
                    ++x;
                    p4 += "расположено";
                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                    {

                        p4 += "" + section.SelectedValue.Text1 + "";


                    }

                    if (section.SelectedValue.HasSize || section.HasDoubleSize)
                    {
                        if (section.HasDoubleSize)
                        {
                            p4 += " " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                            {
                                p4 += " " + section.CurrentEntry.Size + "" + section.SelectedValue.Metrics + ".";
                            }
                            else
                            {
                                p4 += " " + section.CurrentEntry.Size + "";

                            }

                        }
                    }
                    else
                    {
                        p4 += " ";
                    }

                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                    {
                        p4 += "" + section.SelectedValue.Text2 + "";
                    }
                    //if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                    //{
                    //    if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                    //    else
                    //    {
                    //        p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                    //    }

                    //}


                    //

                    //

                }

            }
            foreach (var section in LegPart.LegSections)
            {
                if (section.SelectedValue != null && section.SelectedValue.ToNextPart == false && (section.Text1 != "" && section.Text2 != ""))
                {
                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text1))
                    {
                        if (x == 0)
                        {
                            p4 += "" + section.SelectedValue.Text1 + "";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(p4))
                            {
                                string buf = p4[p4.Length - 1].ToString();
                                string byf2 = (p4.Length >= 2) ? p4[p4.Length - 2].ToString() : "";
                                if (buf != "." && byf2 != ".")
                                {
                                    p4 += ", " + section.SelectedValue.Text1 + "";
                                }

                                else
                                {
                                    p4 += " " + section.SelectedValue.Text1 + "";
                                }
                            }

                        }
                    }

                    if (section.SelectedValue.HasSize || section.HasDoubleSize)
                    {
                        if (section.HasDoubleSize)
                        {
                            p4 += " " + section.CurrentEntry.Size + "*" + section.CurrentEntry.Size2 + " " + section.SelectedValue.Metrics + ".";

                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(section.SelectedValue.Metrics))
                            {
                                p4 += " " + section.CurrentEntry.Size + "" + section.SelectedValue.Metrics + ".";
                            }
                            else
                            {
                                p4 += " " + section.CurrentEntry.Size + "";

                            }

                        }
                    }
                    else
                    {
                        p4 += " ";
                    }

                    if (!string.IsNullOrWhiteSpace(section.SelectedValue.Text2))
                    {
                        p4 += "" + section.SelectedValue.Text2 + "";
                    }

                    if (!string.IsNullOrWhiteSpace(section.CurrentEntry.Comment))
                    {
                        if (LegPart.LegSections[x].SelectedValue != null && !LegPart.LegSections[x].SelectedValue.ToNextPart)
                        {
                            p4 += "\nКомментарий : " + section.CurrentEntry.Comment + "\n";
                        }
                        else
                        {
                            p4 += "\nКомментарий : " + section.CurrentEntry.Comment;
                        }

                    }


                    //

                    //

                }
                else
                {
                    break;
                }
                x++;
            }


            if (!string.IsNullOrWhiteSpace(p4))
            {
                string buff = p4[p4.Length - 1].ToString();
                if (buff == " ")
                {
                    List<char> chararr = p4.ToCharArray().ToList();
                    if (chararr[chararr.Count - 1] == ' ')
                    {
                        chararr.RemoveAt(chararr.Count - 1);

                    }
                    string result = "";
                    foreach (var z in chararr)
                    {
                        result += z;
                    }
                    p4 = result;
                    //buff = (p4.Length >= 2) ? p4[p4.Length - 2].ToString() : "";
                }
                buff = p4[p4.Length - 1].ToString();
                string byf22 = (p4.Length >= 2) ? p4[p4.Length - 2].ToString() : "";

                if (buff != "." && byf22 != ".")
                {
                    p4 += ".";
                }
            }
            string name = "";
            if (!string.IsNullOrWhiteSpace(LegPart.Comment))
            {
                if (LegPart is PDSVViewModel)
                {


                    name = "ПДСВ";


                }
                else if (LegPart is SFSViewModel)
                {


                    name = "СФС";


                }
                else if (LegPart is BPVHipViewModel)
                {

                    name = "БПВНБ";


                }
                else if (LegPart is BPVTibiaViewModel)
                {

                    name = "БПВНГ";


                }
                else if (LegPart is HipPerforateViewModel)
                {


                    name = "ПБИНВ";


                }
                else if (LegPart is ZDSVViewModel)
                {

                    name = "ЗДСВ";

                }

                else if (LegPart is SPSViewModel)
                {
                    name = "СПС";

                }
                else if (LegPart is TibiaPerforateViewModel)
                {

                    name = "ПГ";

                }
                else if (LegPart is MPVViewModel)
                {

                    name = "МПВ";


                }
                else if (LegPart is TEMPVViewModel)
                {
                    name = "ТЕМПВ";

                }
                else if (LegPart is PPVViewModel)
                {

                    name = "ППВ";


                }
                else if (LegPart is GVViewModel)
                {

                    name = "ГВ";

                }
                p4 += "\nКомментарий к " + name + " : " + LegPart.Comment;
            }

            return p4;

        }

        public string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        private void SetAllBordersDefault()
        {
            BPDSV = null;
            BZDSV = null;
            BPerforate1 = null;
            BPerforateGoleni = null;
            BTEMPV = null;
            BPPV = null;
            BCEAR = null;
            BAdditionalText = null;
            BGV = null;

            BPDSVL = null;
            BZDSVL = null;
            BPerforate1L = null;
            BPerforateGoleniL = null;
            BTEMPVL = null;
            BPPVL = null;
            BCEARL = null;
            BAdditionalTextL = null;
            BGVL = null;
        }

        private int togleforCreateStatement = 0;
        public ViewModelAddPhysical(NavigationController controller) : base(controller)
        {
            SetAllBordersDefault();
            CurrentPanelViewModel = new DoctorSelectPanelViewModel(this);
            CurrentPanelViewModel.Doctors = new ObservableCollection<Docs>();

            foreach (var doc in Data.Doctor.GetAll)
            {
                CurrentPanelViewModel.Doctors.Add(new Docs(doc));
            }
            OpenCommand = new DelegateCommand(() =>
            {
                MessageBus.Default.Call("SetCurrentPatientIDRealyThisTime", null, CurrentPatient.Id);
                MessageBus.Default.Call("GetHirurgOverviewForHirurgOverview", null, hirurgOverviewId);
                Controller.NavigateTo<ViewModelHirurgOverview>();
                //CurrentPanelViewModel.ClearPanel();
                //CurrentPanelViewModel.PanelOpened = true;
            });
            SaveCommand = new DelegateCommand(() =>
            {
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

            MessageBus.Default.Subscribe("SetAccIDForAddExamination", SetAccID);
            MessageBus.Default.Subscribe("GetObsFromSavedOverview", GetObsFromSavedOverview);
            MessageBus.Default.Subscribe("GetObsForOverview", GetObsForOverview);
            MessageBus.Default.Subscribe("ClearObsledovanie", Clear);
            MessageBus.Default.Subscribe("LegDataSaved", Handler);
            MessageBus.Default.Subscribe("GetCurrentPatientIdForOperation", SetCurrentPatientID);

            MessageBus.Default.Subscribe("SetRightDiagnosisListForObsled", SetRightDiagnosisList);
            MessageBus.Default.Subscribe("SetLeftDiagnosisListForObsled", SetLeftDiagnosisList);

            MessageBus.Default.Subscribe("SetRecomendationsList", SetRecomendationsList);
            MessageBus.Default.Subscribe("SetDiagnosisList", SetDiagnosisList);
            MessageBus.Default.Subscribe("SetComplainsList", SetComplainsList);


            MessageBus.Default.Subscribe("SetAllDefaultForCreateObsled", SetAllDefault);

            TextTip = "Текст пометки";
            Controller = controller;
            base.HasNavigation = false;

            openDialogCommand = new RelayCommand(FinishAdding);

            LostFocusOnWeight = new DelegateCommand(
              () =>
              {
                  if (string.IsNullOrWhiteSpace(Weight))
                  {
                      Weight = "0";
                  }
              }
          );
            LostFocusOnGrowth = new DelegateCommand(
            () =>
            {
                if (string.IsNullOrWhiteSpace(Growth))
                {
                    Growth = "0";
                }
            }
        );
            ClickOnWeight = new DelegateCommand(
                () =>
                {
                    if (Weight == "0")
                    {
                        Weight = "";
                    }
                }
            );
            ClickOnGrowth = new DelegateCommand(
                () =>
                {
                    if (Growth == "0")
                    {
                        Growth = "";
                    }
                }
            );

            ToPhysicalOverviewCommand = new DelegateCommand(
                () =>
                {
                    BrushesFill();




                    if (LeftGV.IsEmpty == true)
                    {
                        MessageBox.Show("ГВ слева не заполнено");
                    }

                    else if (!IsObservCollectionIsFilled(LeftDiagnosisList))
                    {
                        MessageBox.Show("Диагнозы слева не заполнены");

                    }
                    else if (!IsObservCollectionIsFilled(RightDiagnosisList))
                    {
                        MessageBox.Show("Диагнозы справа не заполнены");

                    }
                    else if (!IsObservCollectionIsFilled(ComplainsList))
                    {
                        MessageBox.Show("Жалобы не заполнены");

                    }
                    else if (!IsObservCollectionIsFilled(RecomendationsList))
                    {
                        MessageBox.Show("Рекомендации не заполнены");

                    }
                    //else if (RightGV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ГВ справа не заполнено");
                    //}

                    //else if (LeftPDSV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ПДСВ слева не заполнено");
                    //}
                    //else if (RightPDSV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ПДСВ справа не заполнено");
                    //}
                    //else if (RightZDSV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ЗДСВ справа не заполнено");
                    //}
                    //else if (LeftZDSV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ЗДСВ слева не заполнено");
                    //}
                    //else if (RightPerforate.IsEmpty == true)
                    //{
                    //    MessageBox.Show("Перфоранты бедра и несафенные вены справа не заполнено");
                    //}
                    //else if (LeftPerforate.IsEmpty == true)
                    //{
                    //    MessageBox.Show("Перфоранты бедра и несафенные вены слева не заполнено");
                    //}
                    //else if (RightTibiaPerforate.IsEmpty == true)
                    //{
                    //    MessageBox.Show("Перфоранты голени справа не заполнено");
                    //}
                    //else if (LeftTibiaPerforate.IsEmpty == true)
                    //{
                    //    MessageBox.Show("Перфоранты голени слева не заполнено");
                    //}
                    //else if (RightTEMPV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ТЕ МПВ справа не заполнено");
                    //}
                    //else if (LeftTEMPV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ТЕ МПВ слева не заполнено");
                    //}
                    //else if (RightPPV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ППВ справа не заполнено");
                    //}
                    //else if (LeftPPV.IsEmpty == true)
                    //{
                    //    MessageBox.Show("ППВ слева не заполнено");
                    //}

                    else if (LeftSFS.IsEmpty == true)
                    {
                        MessageBox.Show("СФС слева не заполнено");
                    }
                    else if (RightSFS.IsEmpty == true)
                    {
                        MessageBox.Show("СФС справа не заполнено");
                    }
                    else if (RightBPVHip.IsEmpty == true)
                    {
                        MessageBox.Show("БПВ на бедре справа не заполнено");
                    }
                    else if (LeftBPVHip.IsEmpty == true)
                    {
                        MessageBox.Show("БПВ на бедре слева не заполнено");
                    }
                    else if (RightBPVTibia.IsEmpty == true)
                    {
                        MessageBox.Show("БПВ на голени справа не заполнено");
                    }
                    else if (LeftBPVTibia.IsEmpty == true)
                    {
                        MessageBox.Show("БПВ на голени справа не заполнено");
                    }
                    else if (RightSPS.IsEmpty == true)
                    {
                        MessageBox.Show("СПС справа не заполнено");
                    }
                    else if (LeftSPS.IsEmpty == true)
                    {
                        MessageBox.Show("СПС слева не заполнено");
                    }
                    else if (RightMPV.IsEmpty == true)
                    {
                        MessageBox.Show("МПВ справа не заполнено");
                    }
                    else if (LeftMPV.IsEmpty == true)
                    {
                        MessageBox.Show("МПВ слева не заполнено");
                    }
                    //else if (string.IsNullOrWhiteSpace(RightAdditionalText))
                    //{
                    //    MessageBox.Show("Примечание справа не заполнено");
                    //}
                    //else if (string.IsNullOrWhiteSpace(LeftAdditionalText))
                    //{
                    //    MessageBox.Show("Примечание слева не заполнено");
                    //}



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
                        MessageBus.Default.Call("SetCurrentPatientIDRealyThisTimeStatement", null, CurrentPatient.Id);
                        MessageBus.Default.Call("GetStatementForStatement", null, statementOverviewId);
                        Controller.NavigateTo<ViewModelStatementForObsled>();


                    }
                }
            );

            ToPhysicalChirurgOverviewCommand = new DelegateCommand(
              () =>
              {
                  BrushesFill();



                  if (LeftGV.IsEmpty == true)
                  {
                      MessageBox.Show("ГВ слева не заполнено");
                  }

                  else if (!IsObservCollectionIsFilled(LeftDiagnosisList))
                  {
                      MessageBox.Show("Диагнозы слева не заполнены");

                  }
                  else if (!IsObservCollectionIsFilled(RightDiagnosisList))
                  {
                      MessageBox.Show("Диагнозы справа не заполнены");

                  }
                  else if (!IsObservCollectionIsFilled(ComplainsList))
                  {
                      MessageBox.Show("Жалобы не заполнены");

                  }
                  else if (!IsObservCollectionIsFilled(RecomendationsList))
                  {
                      MessageBox.Show("Рекомендации не заполнены");

                  }
                  else if (RightGV.IsEmpty == true)
                  {
                      MessageBox.Show("ГВ справа не заполнено");
                  }

                  else if (LeftSFS.IsEmpty == true)
                  {
                      MessageBox.Show("СФС слева не заполнено");
                  }
                  else if (RightSFS.IsEmpty == true)
                  {
                      MessageBox.Show("СФС справа не заполнено");
                  }
                  else if (RightBPVHip.IsEmpty == true)
                  {
                      MessageBox.Show("БПВ на бедре справа не заполнено");
                  }
                  else if (LeftBPVHip.IsEmpty == true)
                  {
                      MessageBox.Show("БПВ на бедре слева не заполнено");
                  }
                  else if (RightBPVTibia.IsEmpty == true)
                  {
                      MessageBox.Show("БПВ на голени справа не заполнено");
                  }
                  else if (LeftBPVTibia.IsEmpty == true)
                  {
                      MessageBox.Show("БПВ на голени справа не заполнено");
                  }
                  else if (RightSPS.IsEmpty == true)
                  {
                      MessageBox.Show("СПС справа не заполнено");
                  }
                  else if (LeftSPS.IsEmpty == true)
                  {
                      MessageBox.Show("СПС слева не заполнено");
                  }
                  else if (RightMPV.IsEmpty == true)
                  {
                      MessageBox.Show("МПВ справа не заполнено");
                  }
                  else if (LeftMPV.IsEmpty == true)
                  {
                      MessageBox.Show("МПВ слева не заполнено");
                  }
                  //else if (RightPPV.IsEmpty == true)
                  //{
                  //    MessageBox.Show("ППВ справа не заполнено");
                  //}
                  //else if (LeftPPV.IsEmpty == true)
                  //{
                  //    MessageBox.Show("ППВ слева не заполнено");
                  //}
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

                  }

                  //MessageBus.Default.Call("GetOperationResultForCreateStatement", this, operationId);
                  // Controller.NavigateTo<ViewModelCreateStatement>();





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

            //SetIdOfOverview    SetIdOfStatement
            MessageBus.Default.Subscribe("SetIdOfStatement", SetIdOfStatement);
            MessageBus.Default.Subscribe("SetIdOfOverview", SetIdOfOverview);
            MessageBus.Default.Subscribe("CreateStatement", CreateStatement);
            MessageBus.Default.Subscribe("CreateHirurgOverview", CreateHirurgOverview);
            MessageBus.Default.Subscribe("SaveScrollSize", SaveScrollSize);
            MessageBus.Default.Subscribe("GetScrollSize", GetScrollSize);
            MessageBus.Default.Subscribe("GetScrollSizeRight", GetScrollSizeRight);
            MessageBus.Default.Subscribe("SaveScrollSizeRight", SaveScrollSizeRight);
            //GetScrollSize
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
            //Controller.AddLegPartVM(LeftBPVHip);
            //Controller.AddLegPartVM(RightBPVHip);

            ToLeftBPVHipCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftBPVHip; MessageBus.Default.Call("RebuildFirstBPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightBPVHipCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightBPVHip; MessageBus.Default.Call("RebuildFirstBPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //БПВ голень
            //BPVTibia

            LeftBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Left);
            RightBPVTibia = new BPVTibiaViewModel(Controller, LegSide.Right);
            //Controller.AddLegPartVM(LeftBPVTibia);
            //Controller.AddLegPartVM(RightBPVTibia);

            ToLeftBPVTibiaCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftBPVTibia; MessageBus.Default.Call("RebuildFirstBPV_Tibia", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightBPVTibiaCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightBPVTibia; MessageBus.Default.Call("RebuildFirstBPV_Tibia", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //Бедро перфорант

            LeftPerforate = new HipPerforateViewModel(Controller, LegSide.Left);
            // LeftPerforate.isFromSomewearElse = false;
            RightPerforate = new HipPerforateViewModel(Controller, LegSide.Right);
            //  RightPerforate.isFromSomewearElse = false;
            //Controller.AddLegPartVM(LeftPerforate);
            //Controller.AddLegPartVM(RightPerforate);
            ToLeftPerforateCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftPerforate;
                    MessageBus.Default.Call("RebuildFirstPerforateHip", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightPerforateCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightPerforate; MessageBus.Default.Call("RebuildFirstPerforateHip", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );


            //PPV

            LeftPPV = new PPVViewModel(Controller, LegSide.Left);
            RightPPV = new PPVViewModel(Controller, LegSide.Right);
            //Controller.AddLegPartVM(LeftPPV);
            //Controller.AddLegPartVM(RightPPV);
            ToLeftPPVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftPPV; MessageBus.Default.Call("RebuildFirstPPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightPPVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightPPV; MessageBus.Default.Call("RebuildFirstPPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );
            //GV

            LeftGV = new GVViewModel(Controller, LegSide.Left);
            RightGV = new GVViewModel(Controller, LegSide.Right);
            //Controller.AddLegPartVM(LeftGV);
            //Controller.AddLegPartVM(RightGV);
            ToLeftGVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftGV; MessageBus.Default.Call("RebuildFirstGV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightGVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightGV; MessageBus.Default.Call("RebuildFirstGV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );
            //ПДСВ
            LeftPDSV = new PDSVViewModel(Controller, LegSide.Left);
            RightPDSV = new PDSVViewModel(Controller, LegSide.Right);
            //Controller.AddLegPartVM(LeftPDSV);
            //Controller.AddLegPartVM(RightPDSV);

            ToLeftPDSVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftPDSV; MessageBus.Default.Call("RebuildFirstPDSV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightPDSVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightPDSV; MessageBus.Default.Call("RebuildFirstPDSV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //СФС

            LeftSFS = new SFSViewModel(Controller, LegSide.Left);
            RightSFS = new SFSViewModel(Controller, LegSide.Right);

            //Controller.AddLegPartVM(LeftSFS);
            //Controller.AddLegPartVM(RightSFS);

            ToLeftSFSCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftSFS; MessageBus.Default.Call("RebuildFirstSFS", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightSFSCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightSFS; MessageBus.Default.Call("RebuildFirstSFS", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //СПС

            LeftSPS = new SPSViewModel(Controller, LegSide.Left);
            RightSPS = new SPSViewModel(Controller, LegSide.Right);

            //Controller.AddLegPartVM(LeftSPS);
            //Controller.AddLegPartVM(RightSPS);
            IMTCOUNT = new DelegateCommand(
            () =>
            {
                ITM = float.Parse(Weight) / ((float.Parse(Growth) / 100) * (float.Parse(Growth) / 100));
            }
          );
            ToLeftSPSCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftSPS; MessageBus.Default.Call("RebuildFirstSPS", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightSPSCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightSPS; MessageBus.Default.Call("RebuildFirstSPS", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //Перфорант голени

            LeftTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Left);
            RightTibiaPerforate = new TibiaPerforateViewModel(Controller, LegSide.Right);
            //Controller.AddLegPartVM(LeftTibiaPerforate);
            //Controller.AddLegPartVM(RightTibiaPerforate);
            ToLeftTibiaPerforateCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftTibiaPerforate; MessageBus.Default.Call("RebuildFirstPerforateTibia", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightTibiaPerforateCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightTibiaPerforate; MessageBus.Default.Call("RebuildFirstPerforateTibia", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //ЗДСВ

            LeftZDSV = new ZDSVViewModel(Controller, LegSide.Left);
            RightZDSV = new ZDSVViewModel(Controller, LegSide.Right);

            //Controller.AddLegPartVM(LeftZDSV);
            //Controller.AddLegPartVM(RightZDSV);

            ToLeftZDSVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftZDSV; MessageBus.Default.Call("RebuildFirstZDSV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightZDSVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightZDSV; MessageBus.Default.Call("RebuildFirstZDSV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //
            //МПВ

            LeftMPV = new MPVViewModel(Controller, LegSide.Left);
            RightMPV = new MPVViewModel(Controller, LegSide.Right);

            //Controller.AddLegPartVM(LeftMPV);
            //Controller.AddLegPartVM(RightMPV);

            ToLeftMPVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftMPV; MessageBus.Default.Call("RebuildFirstMPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightMPVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightMPV; MessageBus.Default.Call("RebuildFirstMPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            //ТЕМПВ


            LeftTEMPV = new TEMPVViewModel(Controller, LegSide.Left);
            RightTEMPV = new TEMPVViewModel(Controller, LegSide.Right);

            //Controller.AddLegPartVM(LeftTEMPV);
            //Controller.AddLegPartVM(RightTEMPV);

            ToLeftTEMPVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = LeftTEMPV;
                    MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightTEMPVCommand = new DelegateCommand(
                () =>
                {

                    Controller.LegViewModel = RightTEMPV;
                    MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            // //CEAP

            LeftCEAR = new LettersViewModel(Controller, LegSide.Left);
            RightCEAR = new LettersViewModel(Controller, LegSide.Right);

            //Controller.AddLegPartVM(LeftCEAR);
            //Controller.AddLegPartVM(RightCEAR);

            ToLeftCEARCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.LegViewModel = LeftCEAR;
                    MessageBus.Default.Call("RebuildFirstCEAP", this, null);
                    Controller.NavigateTo<LegPartViewModel>();
                }
            );

            ToRightCEARCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("RebuildFirstTEMPV", this, this);
                    Controller.LegViewModel = RightCEAR;
                    MessageBus.Default.Call("RebuildFirstCEAP", this, null);
                    Controller.NavigateTo<LegPartViewModel>();
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
                    {
                        TextTip = "";
                    }
                    //Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
            LostOnTextTip = new DelegateCommand(
                () =>
                {
                    if (string.IsNullOrWhiteSpace(TextTip))
                    {
                        TextTip = "Текст пометки";
                    }
                    //Controller.NavigateTo<ViewModelCurrentPatient>();
                }
            );
            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {

                    var acc = Data.Accaunt.Get(Acc_id);
                    if ((acc.isSecretar == null || !acc.isSecretar.Value) && isEdited == true)
                    {
                        MessageBoxResult dialogResult = MessageBox.Show("Вернуться на страницу пациента? Текущий прогресс будет потерян.", "", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            testThread = false;
                            RemoveAllSaves();
                            MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                            Controller.NavigateTo<ViewModelCurrentPatient>();
                        }
                    }
                    else
                    {
                        testThread = false;
                        RemoveAllSaves();
                        MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                        Controller.NavigateTo<ViewModelCurrentPatient>();
                    }
                }
            );

            // Set prev/next section
            SetPrevNextCommands();

        }

        private void SetPrevNextCommands()
        {
            LeftBPVHip.OpenNextLegViewModelCommand = ToLeftPDSVCommand;
            LeftBPVHip.OpenPrevLegViewModelCommand = ToLeftSFSCommand;
            RightBPVHip.OpenNextLegViewModelCommand = ToRightPDSVCommand;
            RightBPVHip.OpenPrevLegViewModelCommand = ToRightSFSCommand;

            LeftBPVTibia.OpenNextLegViewModelCommand = ToLeftTibiaPerforateCommand;
            LeftBPVTibia.OpenPrevLegViewModelCommand = ToLeftPerforateCommand;
            RightBPVTibia.OpenNextLegViewModelCommand = ToRightTibiaPerforateCommand;
            RightBPVTibia.OpenPrevLegViewModelCommand = ToRightPerforateCommand;

            LeftPerforate.OpenNextLegViewModelCommand = ToLeftBPVTibiaCommand;
            LeftPerforate.OpenPrevLegViewModelCommand = ToLeftZDSVCommand;
            RightPerforate.OpenNextLegViewModelCommand = ToRightBPVTibiaCommand;
            RightPerforate.OpenPrevLegViewModelCommand = ToRightZDSVCommand;

            LeftPPV.OpenNextLegViewModelCommand = ToLeftGVCommand;
            LeftPPV.OpenPrevLegViewModelCommand = ToLeftTEMPVCommand;
            RightPPV.OpenNextLegViewModelCommand = ToRightGVCommand;
            RightPPV.OpenPrevLegViewModelCommand = ToRightTEMPVCommand;

            LeftPDSV.OpenNextLegViewModelCommand = ToLeftZDSVCommand;
            LeftPDSV.OpenPrevLegViewModelCommand = ToLeftBPVHipCommand;
            RightPDSV.OpenNextLegViewModelCommand = ToRightZDSVCommand;
            RightPDSV.OpenPrevLegViewModelCommand = ToRightBPVHipCommand;

            LeftSFS.OpenNextLegViewModelCommand = ToLeftBPVHipCommand;
            RightSFS.OpenNextLegViewModelCommand = ToRightBPVHipCommand;

            LeftSPS.OpenNextLegViewModelCommand = ToLeftMPVCommand;
            LeftSPS.OpenPrevLegViewModelCommand = ToLeftTibiaPerforateCommand;
            RightSPS.OpenNextLegViewModelCommand = ToRightMPVCommand;
            RightSPS.OpenPrevLegViewModelCommand = ToRightTibiaPerforateCommand;

            LeftTibiaPerforate.OpenNextLegViewModelCommand = ToLeftSPSCommand;
            LeftTibiaPerforate.OpenPrevLegViewModelCommand = ToLeftBPVTibiaCommand;
            RightTibiaPerforate.OpenNextLegViewModelCommand = ToRightSPSCommand;
            RightTibiaPerforate.OpenPrevLegViewModelCommand = ToRightBPVTibiaCommand;

            LeftZDSV.OpenNextLegViewModelCommand = ToLeftPerforateCommand;
            LeftZDSV.OpenPrevLegViewModelCommand = ToLeftPDSVCommand;
            RightZDSV.OpenNextLegViewModelCommand = ToRightPerforateCommand;
            RightZDSV.OpenPrevLegViewModelCommand = ToRightPDSVCommand;

            LeftMPV.OpenNextLegViewModelCommand = ToLeftTEMPVCommand;
            LeftMPV.OpenPrevLegViewModelCommand = ToLeftSPSCommand;
            RightMPV.OpenNextLegViewModelCommand = ToRightTEMPVCommand;
            RightMPV.OpenPrevLegViewModelCommand = ToRightSPSCommand;

            LeftTEMPV.OpenNextLegViewModelCommand = ToLeftPPVCommand;
            LeftTEMPV.OpenPrevLegViewModelCommand = ToLeftMPVCommand;
            RightTEMPV.OpenNextLegViewModelCommand = ToRightPPVCommand;
            RightTEMPV.OpenPrevLegViewModelCommand = ToRightMPVCommand;

            LeftGV.OpenPrevLegViewModelCommand = ToLeftPPVCommand;
            RightGV.OpenPrevLegViewModelCommand = ToRightPPVCommand;
        }

        private void SetAccID(object sender, object data)
        {
            Acc_id = (int)data;
            var acc = Data.Accaunt.Get(Acc_id);
            if (acc.isSecretar != null && acc.isSecretar.Value)
            {
                IsVisibleForSecretary = Visibility.Hidden;
                IsVisibleForSecretarySign = Visibility.Visible;
            }
            else
            {
                IsVisibleForSecretary = Visibility.Visible;
                IsVisibleForSecretarySign = Visibility.Hidden;
            }
        }
        private void GetObsFromSavedOverview(object sender, object data)
        {
            Clear(this, null);//?


            //TextOfEndBtn = "Вернуться";
            MessageBus.Default.Call("SetMode", this, "EDIT");
            obsid = (int)data;

            SavedExamination Exam = Data.SavedExamination.Get(obsid);
            statementOverviewId = Exam.statementOverviewId;
            hirurgOverviewId = Exam.hirurgOverviewId;
            SavedExaminationLeg leftLegExam = Data.SavedExaminationLeg.Get(Exam.idLeftLegExamination.Value);
            SavedExaminationLeg rightLegExam = Data.SavedExaminationLeg.Get(Exam.idRightLegExamination.Value);
            //IsVisibleTextTTT = Visibility.Visible;
            //if (Exam.isNeedOperation.Value)
            //{
            //    TextOfPreOperation = "Предварительно назначена" + Data.OperationType.Get(Exam.OperationType.Value);

            //}
            //else
            //{
            //    TextOfPreOperation = "Предварительная операция не была назначена";
            //}


            Weight = Exam.weight.ToString();
            Growth = Exam.height.ToString();
            TextTip = Exam.NB;


            LeftAdditionalText = leftLegExam.additionalText;

            if (leftLegExam.PDSVid != null)
            {
                GetLegPartFromEntry(Data.PDSVFull.Get(leftLegExam.PDSVid.Value), LeftPDSV, true);
            }


            if (leftLegExam.BPVHip != null)
            {
                GetLegPartFromEntry(Data.BPVHipsFull.Get(leftLegExam.BPVHip.Value), LeftBPVHip, true);
            }

            if (leftLegExam.BPVTibiaid != null)
            {
                GetLegPartFromEntry(Data.BPV_TibiaFull.Get(leftLegExam.BPVTibiaid.Value), LeftBPVTibia, true);
            }

            if (leftLegExam.GVid != null)
            {
                GetLegPartFromEntry(Data.GVFull.Get(leftLegExam.GVid.Value), LeftGV, true);
            }

            if (leftLegExam.MPVid != null)
            {
                GetLegPartFromEntry(Data.MPVFull.Get(leftLegExam.MPVid.Value), LeftMPV, true);
            }

            if (leftLegExam.PerforateHipid != null)
            {
                GetLegPartFromEntry(Data.Perforate_hipFull.Get(leftLegExam.PerforateHipid.Value), LeftPerforate, true);
            }

            if (leftLegExam.PPVid != null)
            {
                GetLegPartFromEntry(Data.PPVFull.Get(leftLegExam.PPVid.Value), LeftPPV, true);
            }

            if (leftLegExam.SFSid != null)
            {
                GetLegPartFromEntry(Data.SFSFull.Get(leftLegExam.SFSid.Value), LeftSFS, true);
            }

            if (leftLegExam.SPSid != null)
            {
                GetLegPartFromEntry(Data.SPSHipFull.Get(leftLegExam.SPSid.Value), LeftSPS, true);
            }

            if (leftLegExam.TEMPVid != null)
            {
                GetLegPartFromEntry(Data.TEMPVFull.Get(leftLegExam.TEMPVid.Value), LeftTEMPV, true);
            }

            if (leftLegExam.TibiaPerforateid != null)
            {
                GetLegPartFromEntry(Data.Perforate_shinFull.Get(leftLegExam.TibiaPerforateid.Value), LeftTibiaPerforate, true);
            }

            if (leftLegExam.ZDSVid != null)
            {
                GetLegPartFromEntry(Data.ZDSVFull.Get(leftLegExam.ZDSVid.Value), LeftZDSV, true);
            }

            if (leftLegExam.C != null)
            {
                LeftCEAR.LegSections[0].SelectedValue = Data.Letters.Get(leftLegExam.C.Value);
            }

            if (leftLegExam.E != null)
            {
                LeftCEAR.LegSections[1].SelectedValue = Data.Letters.Get(leftLegExam.E.Value);
            }

            if (leftLegExam.A != null)
            {
                LeftCEAR.LegSections[2].SelectedValue = Data.Letters.Get(leftLegExam.A.Value);
            }

            if (leftLegExam.P != null)
            {
                LeftCEAR.LegSections[3].SelectedValue = Data.Letters.Get(leftLegExam.P.Value);
            }

            LeftCEAR.SaveCommand.Execute();













            RightAdditionalText = rightLegExam.additionalText;



            if (rightLegExam.PDSVid != null)
            {
                GetLegPartFromEntry(Data.PDSVFull.Get(rightLegExam.PDSVid.Value), RightPDSV, false);
            }

            if (rightLegExam.BPVHip != null)
            {
                GetLegPartFromEntry(Data.BPVHipsFull.Get(rightLegExam.BPVHip.Value), RightBPVHip, false);
            }

            if (rightLegExam.BPVTibiaid != null)
            {
                GetLegPartFromEntry(Data.BPV_TibiaFull.Get(rightLegExam.BPVTibiaid.Value), RightBPVTibia, false);
            }

            if (rightLegExam.GVid != null)
            {
                GetLegPartFromEntry(Data.GVFull.Get(rightLegExam.GVid.Value), RightGV, false);
            }

            if (rightLegExam.MPVid != null)
            {
                GetLegPartFromEntry(Data.MPVFull.Get(rightLegExam.MPVid.Value), RightMPV, false);
            }

            if (rightLegExam.PerforateHipid != null)
            {
                GetLegPartFromEntry(Data.Perforate_hipFull.Get(rightLegExam.PerforateHipid.Value), RightPerforate, false);
            }

            if (rightLegExam.PPVid != null)
            {
                GetLegPartFromEntry(Data.PPVFull.Get(rightLegExam.PPVid.Value), RightPPV, false);
            }

            if (rightLegExam.SFSid != null)
            {
                GetLegPartFromEntry(Data.SFSFull.Get(rightLegExam.SFSid.Value), RightSFS, false);
            }

            if (rightLegExam.SPSid != null)
            {
                GetLegPartFromEntry(Data.SPSHipFull.Get(rightLegExam.SPSid.Value), RightSPS, false);
            }

            if (rightLegExam.TEMPVid != null)
            {
                GetLegPartFromEntry(Data.TEMPVFull.Get(rightLegExam.TEMPVid.Value), RightTEMPV, false);
            }

            if (rightLegExam.TibiaPerforateid != null)
            {
                GetLegPartFromEntry(Data.Perforate_shinFull.Get(rightLegExam.TibiaPerforateid.Value), RightTibiaPerforate, false);
            }

            if (rightLegExam.ZDSVid != null)
            {
                GetLegPartFromEntry(Data.ZDSVFull.Get(rightLegExam.ZDSVid.Value), RightZDSV, false);
            }

            if (rightLegExam.C != null)
            {
                RightCEAR.LegSections[0].SelectedValue = Data.Letters.Get(rightLegExam.C.Value);
            }

            if (rightLegExam.E != null)
            {
                RightCEAR.LegSections[1].SelectedValue = Data.Letters.Get(rightLegExam.E.Value);
            }

            if (rightLegExam.A != null)
            {
                RightCEAR.LegSections[2].SelectedValue = Data.Letters.Get(rightLegExam.A.Value);
            }

            if (rightLegExam.P != null)
            {
                RightCEAR.LegSections[3].SelectedValue = Data.Letters.Get(rightLegExam.P.Value);
            }

            RightCEAR.SaveCommand.Execute();











            
            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();


            DiagnosisDataSource diagDSourceBuf;
            foreach (var diag in Data.SavedDiagnosisObs.GetAll.Where(s => s.isLeft == true && s.id_leg_examination == Exam.Id).ToList())
            {
                diagDSourceBuf = new DiagnosisDataSource(Data.DiagnosisTypes.Get(diag.id_diagnosis.Value));
                diagDSourceBuf.IsChecked = true;
                LeftDiagnosisList.Add(diagDSourceBuf);
            }

            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();



            foreach (var diag in Data.SavedDiagnosisObs.GetAll.Where(s => s.isLeft == false && s.id_leg_examination == Exam.Id).ToList())
            {
                diagDSourceBuf = new DiagnosisDataSource(Data.DiagnosisTypes.Get(diag.id_diagnosis.Value));
                diagDSourceBuf.IsChecked = true;
                RightDiagnosisList.Add(diagDSourceBuf);
            }

            MessageBus.Default.Call("SetDiagnosisListBecauseOFEdit", LeftDiagnosisList, RightDiagnosisList);

            ComplainsList = new ObservableCollection<ComplainsDataSource>();
            ComplainsDataSource compDSourceBuf;
            foreach (var diag in Data.SavedComplanesObs.GetAll.Where(s => s.id_Examination == Exam.Id).ToList())
            {
                compDSourceBuf = new ComplainsDataSource(Data.ComplainsTypes.Get(diag.id_Complains));
                compDSourceBuf.IsChecked = true;
                ComplainsList.Add(compDSourceBuf);
            }
            RecomendationsList = new ObservableCollection<RecomendationsDataSource>();
            RecomendationsDataSource recDSourceBuf;

            foreach (var diag in Data.SavedRecomendationObs.GetAll.Where(s => s.id_examination == Exam.Id).ToList())
            {
                recDSourceBuf = new RecomendationsDataSource(Data.RecomendationsTypes.Get(diag.id_recommendations));
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

            MessageBus.Default.Call("SetMode", this, "Normal");
            if (Exam.id_current_examination == null)
            {
                mode = "Normal";
            }
            else
            {
                mode = "EDIT";
                TextOfEndBtn = "Вернуться";
                obsid = Exam.id_current_examination.Value;
            }

            Controller.NavigateTo<ViewModelAddPhysical>();
            isEdited = false;
        }

        private void CreateStatement(object p1, object p2)
        {
            try
            {
                /*
                   string _fileNameOnly = "";
                  string fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга.docx"; _fileNameOnly = "Осмотр_хирурга.docx";
                  byte[] bte = Data.doc_template.Get(3).DocTemplate;

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
                          fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга" + togle + ".docx"; _fileNameOnly = "Осмотр_хирурга" + togle + ".docx";
                      }
                  }


                       */
                string docName = "";
                //string docName = "Консультативное_заключение";
                string _fileNameOnly = "";
                //  string fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга.docx";
                _fileNameOnly = "Консультативное_заключение.docx";

                if (togleforCreateStatement == 0)
                {
                    docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + ".docx";
                }
                else
                {
                    docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togleforCreateStatement + ".docx";
                    _fileNameOnly = "Консультативное_заключение" + togleforCreateStatement + ".docx";
                }
                for (; ; )
                {
                    try
                    {

                        CreateStatement(docName, _fileNameOnly, p1.ToString());


                        togleforCreateStatement += 1;
                        docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togleforCreateStatement + ".docx";
                        _fileNameOnly = "Консультативное_заключение" + togleforCreateStatement + ".docx";

                        break;
                    }
                    catch (Exception ex)
                    {
                        togleforCreateStatement += 1;
                        docName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togleforCreateStatement + ".docx";
                        _fileNameOnly = "Консультативное_заключение" + togleforCreateStatement + ".docx";
                    }
                }





            }
            catch { }
        }

        private void CreateHirurgOverview(object p1, object p2)
        {
            Doctor = p1 as string;

            //CurrentPanelViewModel.PanelOpened = false;

            //Handled = false;

            int togle = 0;
            string _fileNameOnly = "";
            string fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга.docx"; _fileNameOnly = "Осмотр_хирурга.docx";
            byte[] bte = Data.doc_template.Get(3).DocTemplate;

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
                    fileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга" + togle + ".docx"; _fileNameOnly = "Осмотр_хирурга" + togle + ".docx";
                }
            }

            try
            {
                using (DocX document = DocX.Load(fileName))
                {


                    document.ReplaceText("«ФИО»", CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic);
                    char[] chararr = CurrentPatient.Age.ToString().ToCharArray();
                    try
                    {
                        string agelastNumb = chararr[chararr.Length - 1].ToString();
                        float buff = 0f;
                        if (float.TryParse(agelastNumb, out buff))
                        {
                            if (CurrentPatient.Age >= 10 && CurrentPatient.Age <= 19)
                            {
                                document.ReplaceText("«Возраст»", CurrentPatient.Age.ToString() + " лет");
                            }
                            else if (buff == 1)
                            { document.ReplaceText("«Возраст»", CurrentPatient.Age.ToString() + " год"); }
                            else if (buff >= 2 && buff <= 4)
                            {
                                document.ReplaceText("«Возраст»", CurrentPatient.Age.ToString() + " года");
                            }
                            else if (buff == 0 || (buff >= 5 && buff <= 9))
                            {
                                document.ReplaceText("«Возраст»", CurrentPatient.Age.ToString() + " лет");
                            }
                        }
                    }
                    catch { }

                    document.ReplaceText("«ИМТ»", ITM.ToString());
                    if (!string.IsNullOrWhiteSpace(TextTip))
                    {
                        document.ReplaceText("«NB_»", TextTip);
                    }
                    else
                    {
                        document.ReplaceText("«NB_»", "");
                    }

                    int day12 = DateTime.Now.Day;
                    int mnth12 = DateTime.Now.Month;
                    string mnthStr1 = "";
                    string dayStr1 = "";
                    if (mnth12 < 10)
                    {
                        mnthStr1 += "0" + mnth12.ToString();
                    }
                    else
                    {
                        mnthStr1 = mnth12.ToString();
                    }

                    if (day12 < 10)
                    {
                        dayStr1 += "0" + day12.ToString();
                    }
                    else
                    {
                        dayStr1 = day12.ToString();
                    }
                    document.ReplaceText("«Дата»", dayStr1 + "." + mnthStr1 + "." + DateTime.Now.Year.ToString());






                    string complanes = "";
                    if (ComplainsList != null)
                    {
                        int xxx = 0;
                        foreach (var rec in ComplainsList)
                        {
                            if (rec.IsChecked == true)
                            {
                                if (xxx == 0)
                                {
                                    complanes += rec.Data.Str;
                                }
                                else
                                {
                                    complanes += ", " + rec.Data.Str;
                                }
                                xxx++;


                            }
                        }
                        char[] chararrbuF1 = complanes.ToCharArray();
                        if (chararrbuF1.Length > 0 && chararrbuF1[chararrbuF1.Length - 1] == '.')
                        { }
                        else
                        {
                            complanes += ".";
                        }
                    }
                    document.ReplaceText("«Жалобы»", complanes);

                    string lettersLeft = "";
                    string lettersRight = "";

                    var ExamsOfCurrPatient = Data.Examination.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();
                    int xx = 0;
                    foreach (var x in LeftDiagnosisList)
                    {
                        if (xx == 0)
                        {
                            lettersLeft += FirstCharToLower(GetStrFixedForDocumemnt(x.Data.Str));
                        }
                        else
                        {
                            lettersLeft += ", " + FirstCharToLower(GetStrFixedForDocumemnt(x.Data.Str));
                        }
                        xx++;
                    }
                    char[] chararrbuF = lettersLeft.ToCharArray();
                    if (chararrbuF[chararrbuF.Length - 1] == '.')
                    { }
                    else
                    {
                        lettersLeft += ".";
                    }


                    xx = 0;
                    foreach (var x in RightDiagnosisList)
                    {
                        if (xx == 0)
                        {
                            lettersRight += FirstCharToLower(GetStrFixedForDocumemnt(x.Data.Str));
                        }
                        else
                        {
                            lettersRight += ", " + FirstCharToLower(GetStrFixedForDocumemnt(x.Data.Str));
                        }
                        xx++;
                    }
                    chararrbuF = lettersRight.ToCharArray();
                    if (chararrbuF[chararrbuF.Length - 1] == '.')
                    { }
                    else
                    {
                        lettersRight += ".";
                    }

                    lettersRight += " ";
                    lettersLeft += " ";
                    if (ExamsOfCurrPatient.Count > 0)
                    {
                        DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                        var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                        ExaminationLeg leftLegExam = Data.ExaminationLeg.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                        ExaminationLeg rightLegExam = Data.ExaminationLeg.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);
                        Letters bufLetter = new Letters();
                        if (LeftCEAR.LegSections[0].SelectedValue != null)
                        {
                            bufLetter = LeftCEAR.LegSections[0].SelectedValue;
                            lettersLeft += bufLetter.Leter + bufLetter.Text1 + "";
                        }
                        if (LeftCEAR.LegSections[1].SelectedValue != null)
                        {
                            bufLetter = LeftCEAR.LegSections[1].SelectedValue;
                            lettersLeft += bufLetter.Leter + bufLetter.Text1 + "";
                        }
                        if (LeftCEAR.LegSections[2].SelectedValue != null)
                        {
                            bufLetter = LeftCEAR.LegSections[2].SelectedValue;
                            lettersLeft += bufLetter.Leter + bufLetter.Text1 + "";
                        }
                        if (LeftCEAR.LegSections[3].SelectedValue != null)
                        {
                            bufLetter = LeftCEAR.LegSections[3].SelectedValue;
                            lettersLeft += bufLetter.Leter + bufLetter.Text1 + "";
                        }

                        if (RightCEAR.LegSections[0].SelectedValue != null)
                        {
                            bufLetter = RightCEAR.LegSections[0].SelectedValue;
                            lettersRight += bufLetter.Leter + bufLetter.Text1 + "";
                        }
                        if (RightCEAR.LegSections[1].SelectedValue != null)
                        {
                            bufLetter = RightCEAR.LegSections[1].SelectedValue;
                            lettersRight += bufLetter.Leter + bufLetter.Text1 + "";
                        }
                        if (RightCEAR.LegSections[2].SelectedValue != null)
                        {
                            bufLetter = RightCEAR.LegSections[2].SelectedValue;
                            lettersRight += bufLetter.Leter + bufLetter.Text1 + "";
                        }
                        if (RightCEAR.LegSections[3].SelectedValue != null)
                        {
                            bufLetter = RightCEAR.LegSections[3].SelectedValue;
                            lettersRight += bufLetter.Leter + bufLetter.Text1 + "";
                        }

                    }

                    List<string> bff = new List<string>();

                    bff.Add("СФСр");
                    bff.Add("БПВр на бедре");
                    bff.Add("ПДСВр");
                    bff.Add("ЗДСВр");
                    bff.Add("Перфоранты бедра и несафенные веныр");
                    bff.Add("БПВ на голенир");
                    bff.Add("Перфоранты голенир");
                    bff.Add("СПСр");
                    bff.Add("МПВр");
                    bff.Add("ТЕ_МПВр");
                    bff.Add("ППВр");
                    bff.Add("Глубокие веныр");


                    document.ReplaceText("«Заключение_справа»", lettersRight);
                    document.ReplaceText("«Заключение_cлева»", lettersLeft);



                    //буквы_1


                    //буквы_2
                    string RightLL = "";
                    string LeftLL = "";
                    Formatting d = new Formatting();
                    Formatting dx = new Formatting();
                    dx.Bold = true;
                    dx.FontFamily = new Font("Times new roman");
                    d.FontFamily = new Font("Times new roman");
                    d.Bold = true;
                    d.UnderlineStyle = UnderlineStyle.singleLine;

                    document.ReplaceText("«Врач»", Doctor);





                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightPDSV)))
                    //{
                    //    document.ReplaceText("СФСр", "ПДСВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightPDSV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}

                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightZDSV)))
                    //{
                    //    document.ReplaceText("СФСр", "ЗДСВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightZDSV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}



                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightPerforate)))
                    //{
                    //    document.ReplaceText("СФСр", "Перфоранты бедра и несафенные веныСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightPerforate) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    //}

                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightTibiaPerforate)))
                    //{

                    //    document.ReplaceText("СФСр", "Перфоранты голениСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightTibiaPerforate) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);




                    //}
                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightTEMPV)))
                    //{
                    //    document.ReplaceText("СФСр", "ТЕМПВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightTEMPV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}




                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightPPV)))
                    //{
                    //    document.ReplaceText("СФСр", "ППВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightPPV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    //}



                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightGV)))
                    //{
                    //    document.ReplaceText("СФСр", "Глубокие веныСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightGV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}

                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightSFS)))
                    {
                        document.ReplaceText("СФСр", "СФССФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightSFS) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }
                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightBPVHip)))
                    {
                        document.ReplaceText("СФСр", "БПВ на бедреСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightBPVHip) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }
                    //


                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightBPVTibia)))
                    {
                        document.ReplaceText("СФСр", "БПВ на голениСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightBPVTibia) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    }
                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightSPS)))
                    {

                        document.ReplaceText("СФСр", "СПССФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightSPS) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);




                    }
                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightMPV)))
                    {
                        document.ReplaceText("СФСр", "МПВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightMPV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }

                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightGV)))
                    {
                        document.ReplaceText("СФСр", "Глубокие веныСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightGV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }
                    //
                    RightLL = "";
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightPPV)))
                    {
                        RightLL += "ППВ : " + CreateStrForOverview(RightPPV) + "\n";
                        //document.ReplaceText("СФСр", "ППВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        //document.ReplaceText("СФСр", ": " + CreateStrForOverview(RightPPV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    }






                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightPDSV)))
                    {
                        RightLL += "ПДСВ : " + CreateStrForOverview(RightPDSV) + "\n";
                    }

                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightZDSV)))
                    {
                        RightLL += "ЗДСВ : " + CreateStrForOverview(RightZDSV) + "\n";
                    }

                    //


                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightPerforate)))
                    {
                        RightLL += "Перфоранты бедра и несафенные вены " + CreateStrForOverview(RightPerforate) + "\n";
                    }


                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightTibiaPerforate)))
                    {
                        RightLL += "Перфоранты голени : " + CreateStrForOverview(RightTibiaPerforate) + "\n";
                    }

                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(RightTEMPV)))
                    {
                        RightLL += "ТЕМПВ : " + CreateStrForOverview(RightTEMPV) + "\n";
                    }

                    document.ReplaceText("«Примечание_справа»", "Примечание: " + RightAdditionalText);
                    d.Bold = false;
                    d.UnderlineStyle = UnderlineStyle.none;
                    document.ReplaceText("СФСр", RightLL, false, System.Text.RegularExpressions.RegexOptions.None, d);

                    d.Bold = true;
                    d.UnderlineStyle = UnderlineStyle.singleLine;





                    //область
                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftPDSV)))
                    //{
                    //    document.ReplaceText("СФСл", "ПДСВСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftPDSV) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}

                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftZDSV)))
                    //{
                    //    document.ReplaceText("СФСл", "ЗДСВСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftZDSV) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}
                    ////LeftLL += "ЗДСВ : " + CreateStrForOverview(LeftZDSV) + "\n";



                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftPerforate)))
                    //{
                    //    document.ReplaceText("СФСл", "Перфоранты бедра и несафенные веныСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftPerforate) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    //}
                    ////  LeftLL += "Перфоранты бедра и несафенные вены : " + CreateStrForOverview(LeftPerforate) + "\n";
                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftTibiaPerforate)))
                    //{

                    //    document.ReplaceText("СФСл", "Перфоранты голениСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftTibiaPerforate) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);


                    //    //  LeftLL += "Перфоранты голени : " + CreateStrForOverview(LeftTibiaPerforate) + "\n";

                    //}
                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftTEMPV)))
                    //{
                    //    document.ReplaceText("СФСл", "ТЕМПВСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftTEMPV) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}
                    //// LeftLL += "ТЕМПВ : " + CreateStrForOverview(LeftTEMPV) + "\n";




                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftPPV)))
                    //{
                    //    document.ReplaceText("СФСл", "ППВСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftPPV) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}
                    ////LeftLL += "ППВ : " + CreateStrForOverview(LeftPPV) + "\n";



                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftGV)))
                    //{
                    //    document.ReplaceText("СФСл", "Глубокие веныСФСл", false, System.Text.RegularExpressions.RegexOptions.None, d);
                    //    document.ReplaceText("СФСл", ": " + CreateStrForOverview(LeftGV) + "\nСФСл", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    //}
                    //// LeftLL += "Глубокие вены : " + CreateStrForOverview(LeftGV) + "\nСФСл";


                    //// document.ReplaceText("СФСл", LeftLL, false, System.Text.RegularExpressions.RegexOptions.None, d);


                    //LeftLL = "";
                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftSFS)))
                    //    LeftLL += "СФС : " + CreateStrForOverview(LeftSFS) + "\n";


                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftBPVHip)))
                    //    LeftLL += "БПВ на бедре : " + CreateStrForOverview(LeftBPVHip) + "\n";




                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftBPVTibia)))

                    //    LeftLL += "БПВ на голени " + CreateStrForOverview(LeftBPVTibia) + "\n";



                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftSPS)))

                    //    LeftLL += "СПС : " + CreateStrForOverview(LeftSPS) + "\n";


                    //if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftMPV)))

                    //    LeftLL += "МПВ : " + CreateStrForOverview(LeftMPV) + "\n";
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftSFS)))
                    {
                        document.ReplaceText("СФСр", "СФССФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftSFS) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }
                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftBPVHip)))
                    {
                        document.ReplaceText("СФСр", "БПВ на бедреСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftBPVHip) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }
                    //


                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftBPVTibia)))
                    {
                        document.ReplaceText("СФСр", "БПВ на голениСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftBPVTibia) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    }
                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftSPS)))
                    {

                        document.ReplaceText("СФСр", "СПССФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftSPS) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);




                    }
                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftMPV)))
                    {
                        document.ReplaceText("СФСр", "МПВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftMPV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }

                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftGV)))
                    {
                        document.ReplaceText("СФСр", "Глубокие веныСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftGV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);

                    }
                    //
                    LeftLL = "";
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftPPV)))
                    {
                        LeftLL += "ППВ : " + CreateStrForOverview(LeftPPV) + "\n";
                        //document.ReplaceText("СФСр", "ППВСФСр", false, System.Text.RegularExpressions.RegexOptions.None, d);
                        //document.ReplaceText("СФСр", ": " + CreateStrForOverview(LeftPPV) + "\nСФСр", false, System.Text.RegularExpressions.RegexOptions.None, dx);
                    }






                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftPDSV)))
                    {
                        LeftLL += "ПДСВ : " + CreateStrForOverview(LeftPDSV) + "\n";
                    }

                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftZDSV)))
                    {
                        LeftLL += "ЗДСВ : " + CreateStrForOverview(LeftZDSV) + "\n";
                    }

                    //


                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftPerforate)))
                    {
                        LeftLL += "Перфоранты бедра и несафенные вены " + CreateStrForOverview(LeftPerforate) + "\n";
                    }


                    //
                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftTibiaPerforate)))
                    {
                        LeftLL += "Перфоранты голени : " + CreateStrForOverview(LeftTibiaPerforate) + "\n";
                    }

                    if (!string.IsNullOrWhiteSpace(CreateStrForOverview(LeftTEMPV)))
                    {
                        LeftLL += "ТЕМПВ : " + CreateStrForOverview(LeftTEMPV) + "\n";
                    }

                    document.ReplaceText("«Примечание_слева»", "Примечание: " + LeftAdditionalText);
                    d.Bold = false;
                    d.UnderlineStyle = UnderlineStyle.none;
                    document.ReplaceText("СФСл", LeftLL, false, System.Text.RegularExpressions.RegexOptions.None, d);



                    document.ReplaceText("«Примечание_слева»", LeftAdditionalText);

                    int xx2 = 0;                   //
                    string recomendations = "";
                    if (RecomendationsList != null)
                    {
                        foreach (var rec in RecomendationsList)
                        {
                            if (rec.IsChecked == true)
                            {
                                if (xx2 == 0)
                                {
                                    recomendations += rec.Data.Str;
                                }
                                else
                                {
                                    recomendations += ", " + rec.Data.Str;
                                }
                                xx2++;


                            }
                        }
                    }
                    char[] chararrbuF2 = recomendations.ToCharArray();
                    if (chararrbuF2[chararrbuF2.Length - 1] == '.')
                    { }
                    else
                    {
                        recomendations += ".";
                    }
                    document.ReplaceText("«Рекомендации»", recomendations);

                    document.Save();

                    byte[] bteToBD = File.ReadAllBytes(fileName);
                    HirurgOverview Hv = new HirurgOverview();
                    if (hirurgOverviewId != null && hirurgOverviewId != 0)
                    {
                        Hv = Data.HirurgOverview.Get(hirurgOverviewId.Value);

                        Hv.DocTemplate = bteToBD;
                        Hv.DoctorId = int.Parse(p2.ToString());
                        Data.Complete();
                    }
                    else
                    {

                        Hv.DocTemplate = bteToBD;
                        Hv.DoctorId = int.Parse(p2.ToString());
                        Data.HirurgOverview.Add(Hv);

                        Data.Complete();
                        hirurgOverviewId = Hv.Id;
                    }
                    //bool tester = true;
                    //foreach (var x in HirurgOverviewRep.GetAll)
                    //{

                    //    if (x.PatientId == CurrentPatient.Id)
                    //    {
                    //        tester = false;
                    //        Hv = Data.HirurgOverview.Get(x.Id);
                    //        Hv.DocTemplate = bteToBD;

                    //        Data.Complete();
                    //        break;
                    //    }

                    //    // HirurgOverview Hv = new HirurgOverview();
                    //}
                    //if (tester)
                    //{
                    //    Hv.PatientId = CurrentPatient.Id;
                    //    Hv.DocTemplate = bteToBD;
                    //    Data.HirurgOverview.Add(Hv);
                    //    Data.Complete();
                    //}

                    MessageBus.Default.Call("GetHirurgOverviewtForHirurgOverviewFILENAME", fileName, null);

                    MessageBus.Default.Call("GetHirurgOverviewForHirurgOverview", _fileNameOnly, hirurgOverviewId);
                    //Release this document from memory.

                    Process.Start("WINWORD.EXE", fileName);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private struct SaveSet
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

            RightBPV_TibiaEntryFull = (BPV_TibiaEntryFull)SaveFullEntry(RightBPVTibia, RightBPV_TibiaEntryFull, false, mode);
            LeftBPV_TibiaEntryFull = (BPV_TibiaEntryFull)SaveFullEntry(LeftBPVTibia, LeftBPV_TibiaEntryFull, true, mode);
            RightPerforate_hipEntryFull = (Perforate_hipEntryFull)SaveFullEntry(RightPerforate, RightPerforate_hipEntryFull, false, mode);
            LeftPerforate_hipEntryFull = (Perforate_hipEntryFull)SaveFullEntry(LeftPerforate, LeftPerforate_hipEntryFull, true, mode);
            RightZDSVEntryFull = (ZDSVEntryFull)SaveFullEntry(RightZDSV, RightZDSVEntryFull, false, mode);
            LeftZDSVEntryFull = (ZDSVEntryFull)SaveFullEntry(LeftZDSV, LeftZDSVEntryFull, true, mode);
            RightPDSVEntryFull = (PDSVHipEntryFull)SaveFullEntry(RightPDSV, RightPDSVEntryFull, false, mode);
            LeftPDSVEntryFull = (PDSVHipEntryFull)SaveFullEntry(LeftPDSV, LeftPDSVEntryFull, true, mode);
            RightBPVEntryFull = (BPVHipEntryFull)SaveFullEntry(RightBPVHip, RightBPVEntryFull, false, mode);
            LeftBPVEntryFull = (BPVHipEntryFull)SaveFullEntry(LeftBPVHip, LeftBPVEntryFull, true, mode);
            RightSFSEntryFull = (SFSHipEntryFull)SaveFullEntry(RightSFS, RightSFSEntryFull, false, mode);
            LeftSFSEntryFull = (SFSHipEntryFull)SaveFullEntry(LeftSFS, LeftSFSEntryFull, true, mode);

            RightSPSEntryFull = (SPSHipEntryFull)SaveFullEntry(RightSPS, RightSPSEntryFull, false, mode);
            LeftSPSEntryFull = (SPSHipEntryFull)SaveFullEntry(LeftSPS, LeftSPSEntryFull, true, mode);

            RightPerforate_shinEntryFull = (Perforate_shinEntryFull)SaveFullEntry(RightTibiaPerforate, RightPerforate_shinEntryFull, false, mode);
            LeftPerforate_shinEntryFull = (Perforate_shinEntryFull)SaveFullEntry(LeftTibiaPerforate, LeftPerforate_shinEntryFull, true, mode);

            RightTEMPVEntryFull = (TEMPVEntryFull)SaveFullEntry(RightTEMPV, RightTEMPVEntryFull, false, mode);
            LeftTEMPVEntryFull = (TEMPVEntryFull)SaveFullEntry(LeftTEMPV, LeftTEMPVEntryFull, true, mode);

            RightMPVEntryFull = (MPVEntryFull)SaveFullEntry(RightMPV, RightMPVEntryFull, false, mode);
            LeftMPVEntryFull = (MPVEntryFull)SaveFullEntry(LeftMPV, LeftMPVEntryFull, true, mode);


            RightPPVEntryFull = (PPVEntryFull)SaveFullEntry(RightPPV, RightPPVEntryFull, false, mode);
            LeftPPVEntryFull = (PPVEntryFull)SaveFullEntry(LeftPPV, LeftPPVEntryFull, true, mode);

            RightGVEntryFull = (GVEntryFull)SaveFullEntry(RightGV, RightGVEntryFull, false, mode);
            LeftGVEntryFull = (GVEntryFull)SaveFullEntry(LeftGV, LeftGVEntryFull, true, mode);


            if (mode != "EDIT")
            {
                //bool test = true;
                if (!RightBPVHip.IsEmpty)
                {


                    Data.BPVHipsFull.Add(RightBPVEntryFull);
                    // Data.Complete();

                }


                if (!RightBPVTibia.IsEmpty)
                {

                    Data.BPV_TibiaFull.Add(RightBPV_TibiaEntryFull);
                    //    Data.Complete();


                }

                if (!RightGV.IsEmpty)
                {

                    Data.GVFull.Add(RightGVEntryFull);
                    //  Data.Complete();

                }

                if (!RightMPV.IsEmpty)
                {

                    Data.MPVFull.Add(RightMPVEntryFull);
                    // Data.Complete();


                }

                if (!RightPDSV.IsEmpty)
                {

                    Data.PDSVFull.Add(RightPDSVEntryFull);
                    // Data.Complete();


                }
                if (!RightPerforate.IsEmpty)
                {

                    Data.Perforate_hipFull.Add(RightPerforate_hipEntryFull);
                    //  Data.Complete();


                }
                if (!RightPPV.IsEmpty)
                {

                    Data.PPVFull.Add(RightPPVEntryFull);
                    //  Data.Complete();


                }

                if (!RightSFS.IsEmpty)
                {

                    Data.SFSFull.Add(RightSFSEntryFull);
                    //Data.Complete();


                }

                if (!RightSPS.IsEmpty)
                {

                    Data.SPSHipFull.Add(RightSPSEntryFull);
                    //  Data.Complete();


                }
                if (!RightTEMPV.IsEmpty)
                {

                    Data.TEMPVFull.Add(RightTEMPVEntryFull);
                    // Data.Complete();


                }

                if (!RightTibiaPerforate.IsEmpty)
                {

                    Data.Perforate_shinFull.Add(RightPerforate_shinEntryFull);
                    //  Data.Complete();


                }

                if (!RightZDSV.IsEmpty)
                {

                    Data.ZDSVFull.Add(RightZDSVEntryFull);

                }


                if (!LeftBPVHip.IsEmpty)
                {

                    Data.BPVHipsFull.Add(LeftBPVEntryFull);
                    //Data.Complete();


                }
                if (!LeftBPVTibia.IsEmpty)
                {

                    Data.BPV_TibiaFull.Add(LeftBPV_TibiaEntryFull);
                    //   Data.Complete();
                    //

                }

                if (!LeftGV.IsEmpty)
                {

                    Data.GVFull.Add(LeftGVEntryFull);
                    // Data.Complete();


                }

                if (!LeftMPV.IsEmpty)
                {

                    Data.MPVFull.Add(LeftMPVEntryFull);
                    //  Data.Complete();

                }


                if (!LeftPDSV.IsEmpty)
                {

                    Data.PDSVFull.Add(LeftPDSVEntryFull);

                    //    Data.Complete();

                }
                if (!LeftPerforate.IsEmpty)
                {

                    Data.Perforate_hipFull.Add(LeftPerforate_hipEntryFull);
                    //  Data.Complete();


                }
                if (!LeftPPV.IsEmpty)
                {

                    Data.PPVFull.Add(LeftPPVEntryFull);
                    //   Data.Complete();


                }

                if (!LeftSFS.IsEmpty)
                {

                    Data.SFSFull.Add(LeftSFSEntryFull);
                    //     Data.Complete();


                }

                if (!LeftSPS.IsEmpty)
                {
                    Data.SPSHipFull.Add(LeftSPSEntryFull);
                    // Data.Complete();


                }
                if (!LeftTEMPV.IsEmpty)
                {

                    Data.TEMPVFull.Add(LeftTEMPVEntryFull);

                    //  Data.Complete();

                }

                if (!LeftTibiaPerforate.IsEmpty)
                {

                    Data.Perforate_shinFull.Add(LeftPerforate_shinEntryFull);
                    //   Data.Complete();


                }

                if (!LeftZDSV.IsEmpty)
                {

                    Data.ZDSVFull.Add(LeftZDSVEntryFull);
                    // Data.Complete();


                }
            }
            else
            {
                Examination Exam = Data.Examination.Get(obsid);
                ExaminationLeg LegExamL = new ExaminationLeg();
                ExaminationLeg LegExamR = new ExaminationLeg();
                LegExamL = Data.ExaminationLeg.Get(Exam.idLeftLegExamination.Value);
                LegExamR = Data.ExaminationLeg.Get(Exam.idRightLegExamination.Value);
                if (!RightBPVHip.IsEmpty && LegExamR.BPVHip == null)
                {


                    Data.BPVHipsFull.Add(RightBPVEntryFull);
                    // Data.Complete();

                }


                if (!RightBPVTibia.IsEmpty && LegExamR.BPVTibiaid == null)
                {

                    Data.BPV_TibiaFull.Add(RightBPV_TibiaEntryFull);
                    //    Data.Complete();


                }

                if (!RightGV.IsEmpty && LegExamR.GVid == null)
                {

                    Data.GVFull.Add(RightGVEntryFull);
                    //  Data.Complete();

                }

                if (!RightMPV.IsEmpty && LegExamR.MPVid == null)
                {

                    Data.MPVFull.Add(RightMPVEntryFull);
                    // Data.Complete();


                }

                if (!RightPDSV.IsEmpty && LegExamR.PDSVid == null)
                {

                    Data.PDSVFull.Add(RightPDSVEntryFull);
                    // Data.Complete();


                }
                if (!RightPerforate.IsEmpty && LegExamR.PerforateHipid == null)
                {

                    Data.Perforate_hipFull.Add(RightPerforate_hipEntryFull);
                    //  Data.Complete();


                }
                if (!RightPPV.IsEmpty && LegExamR.PPVid == null)
                {

                    Data.PPVFull.Add(RightPPVEntryFull);
                    //  Data.Complete();


                }

                if (!RightSFS.IsEmpty && LegExamR.SFSid == null)
                {

                    Data.SFSFull.Add(RightSFSEntryFull);
                    //Data.Complete();


                }

                if (!RightSPS.IsEmpty && LegExamR.SPSid == null)
                {

                    Data.SPSHipFull.Add(RightSPSEntryFull);
                    //  Data.Complete();


                }
                if (!RightTEMPV.IsEmpty && LegExamR.TEMPVid == null)
                {

                    Data.TEMPVFull.Add(RightTEMPVEntryFull);
                    // Data.Complete();


                }

                if (!RightTibiaPerforate.IsEmpty && LegExamR.TibiaPerforateid == null)
                {

                    Data.Perforate_shinFull.Add(RightPerforate_shinEntryFull);
                    //  Data.Complete();


                }

                if (!RightZDSV.IsEmpty && LegExamR.ZDSVid == null)
                {

                    Data.ZDSVFull.Add(RightZDSVEntryFull);

                }



                if (!LeftBPVHip.IsEmpty && LegExamL.BPVHip == null)
                {


                    Data.BPVHipsFull.Add(LeftBPVEntryFull);
                    // Data.Complete();

                }


                if (!LeftBPVTibia.IsEmpty && LegExamL.BPVTibiaid == null)
                {

                    Data.BPV_TibiaFull.Add(LeftBPV_TibiaEntryFull);
                    //    Data.Complete();


                }

                if (!LeftGV.IsEmpty && LegExamL.GVid == null)
                {

                    Data.GVFull.Add(LeftGVEntryFull);
                    //  Data.Complete();

                }

                if (!LeftMPV.IsEmpty && LegExamL.MPVid == null)
                {

                    Data.MPVFull.Add(LeftMPVEntryFull);
                    // Data.Complete();


                }

                if (!LeftPDSV.IsEmpty && LegExamL.PDSVid == null)
                {

                    Data.PDSVFull.Add(LeftPDSVEntryFull);
                    // Data.Complete();


                }
                if (!LeftPerforate.IsEmpty && LegExamL.PerforateHipid == null)
                {

                    Data.Perforate_hipFull.Add(LeftPerforate_hipEntryFull);
                    //  Data.Complete();


                }
                if (!LeftPPV.IsEmpty && LegExamL.PPVid == null)
                {

                    Data.PPVFull.Add(LeftPPVEntryFull);
                    //  Data.Complete();


                }

                if (!LeftSFS.IsEmpty && LegExamL.SFSid == null)
                {

                    Data.SFSFull.Add(LeftSFSEntryFull);
                    //Data.Complete();


                }

                if (!LeftSPS.IsEmpty && LegExamL.SPSid == null)
                {

                    Data.SPSHipFull.Add(LeftSPSEntryFull);
                    //  Data.Complete();


                }
                if (!LeftTEMPV.IsEmpty && LegExamL.TEMPVid == null)
                {

                    Data.TEMPVFull.Add(LeftTEMPVEntryFull);
                    // Data.Complete();


                }

                if (!LeftTibiaPerforate.IsEmpty && LegExamL.TibiaPerforateid == null)
                {

                    Data.Perforate_shinFull.Add(LeftPerforate_shinEntryFull);
                    //  Data.Complete();


                }

                if (!LeftZDSV.IsEmpty && LegExamL.ZDSVid == null)
                {

                    Data.ZDSVFull.Add(LeftZDSVEntryFull);

                }
            }
            Data.Complete();

        }
        //private void SaveAll()
        //{


        //}
        //private void saveAllForSavedExam()
        //{
        //    LegExamL = Data.ExaminationLeg.Get(Exam.idLeftLegExamination.Value);
        //    LegExamR = Data.ExaminationLeg.Get(Exam.idRightLegExamination.Value);
        //    if (!RightBPVHip.IsEmpty && LegExamR.BPVHip == null)
        //    {


        //        Data.BPVHipsFull.Add(RightBPVEntryFull);
        //        // Data.Complete();

        //    }


        //    if (!RightBPVTibia.IsEmpty && LegExamR.BPVTibiaid == null)
        //    {

        //        Data.BPV_TibiaFull.Add(RightBPV_TibiaEntryFull);
        //        //    Data.Complete();


        //    }

        //    if (!RightGV.IsEmpty && LegExamR.GVid == null)
        //    {

        //        Data.GVFull.Add(RightGVEntryFull);
        //        //  Data.Complete();

        //    }

        //    if (!RightMPV.IsEmpty && LegExamR.MPVid == null)
        //    {

        //        Data.MPVFull.Add(RightMPVEntryFull);
        //        // Data.Complete();


        //    }

        //    if (!RightPDSV.IsEmpty && LegExamR.PDSVid == null)
        //    {

        //        Data.PDSVFull.Add(RightPDSVEntryFull);
        //        // Data.Complete();


        //    }
        //    if (!RightPerforate.IsEmpty && LegExamR.PerforateHipid == null)
        //    {

        //        Data.Perforate_hipFull.Add(RightPerforate_hipEntryFull);
        //        //  Data.Complete();


        //    }
        //    if (!RightPPV.IsEmpty && LegExamR.PPVid == null)
        //    {

        //        Data.PPVFull.Add(RightPPVEntryFull);
        //        //  Data.Complete();


        //    }

        //    if (!RightSFS.IsEmpty && LegExamR.SFSid == null)
        //    {

        //        Data.SFSFull.Add(RightSFSEntryFull);
        //        //Data.Complete();


        //    }

        //    if (!RightSPS.IsEmpty && LegExamR.SPSid == null)
        //    {

        //        Data.SPSHipFull.Add(RightSPSEntryFull);
        //        //  Data.Complete();


        //    }
        //    if (!RightTEMPV.IsEmpty && LegExamR.TEMPVid == null)
        //    {

        //        Data.TEMPVFull.Add(RightTEMPVEntryFull);
        //        // Data.Complete();


        //    }

        //    if (!RightTibiaPerforate.IsEmpty && LegExamR.TibiaPerforateid == null)
        //    {

        //        Data.Perforate_shinFull.Add(RightPerforate_shinEntryFull);
        //        //  Data.Complete();


        //    }

        //    if (!RightZDSV.IsEmpty && LegExamR.ZDSVid == null)
        //    {

        //        Data.ZDSVFull.Add(RightZDSVEntryFull);

        //    }



        //    if (!LeftBPVHip.IsEmpty && LegExamL.BPVHip == null)
        //    {


        //        Data.BPVHipsFull.Add(LeftBPVEntryFull);
        //        // Data.Complete();

        //    }


        //    if (!LeftBPVTibia.IsEmpty && LegExamL.BPVTibiaid == null)
        //    {

        //        Data.BPV_TibiaFull.Add(LeftBPV_TibiaEntryFull);
        //        //    Data.Complete();


        //    }

        //    if (!LeftGV.IsEmpty && LegExamL.GVid == null)
        //    {

        //        Data.GVFull.Add(LeftGVEntryFull);
        //        //  Data.Complete();

        //    }

        //    if (!LeftMPV.IsEmpty && LegExamL.MPVid == null)
        //    {

        //        Data.MPVFull.Add(LeftMPVEntryFull);
        //        // Data.Complete();


        //    }

        //    if (!LeftPDSV.IsEmpty && LegExamL.PDSVid == null)
        //    {

        //        Data.PDSVFull.Add(LeftPDSVEntryFull);
        //        // Data.Complete();


        //    }
        //    if (!LeftPerforate.IsEmpty && LegExamL.PerforateHipid == null)
        //    {

        //        Data.Perforate_hipFull.Add(LeftPerforate_hipEntryFull);
        //        //  Data.Complete();


        //    }
        //    if (!LeftPPV.IsEmpty && LegExamL.PPVid == null)
        //    {

        //        Data.PPVFull.Add(LeftPPVEntryFull);
        //        //  Data.Complete();


        //    }

        //    if (!LeftSFS.IsEmpty && LegExamL.SFSid == null)
        //    {

        //        Data.SFSFull.Add(LeftSFSEntryFull);
        //        //Data.Complete();


        //    }

        //    if (!LeftSPS.IsEmpty && LegExamL.SPSid == null)
        //    {

        //        Data.SPSHipFull.Add(LeftSPSEntryFull);
        //        //  Data.Complete();


        //    }
        //    if (!LeftTEMPV.IsEmpty && LegExamL.TEMPVid == null)
        //    {

        //        Data.TEMPVFull.Add(LeftTEMPVEntryFull);
        //        // Data.Complete();


        //    }

        //    if (!LeftTibiaPerforate.IsEmpty && LegExamL.TibiaPerforateid == null)
        //    {

        //        Data.Perforate_shinFull.Add(LeftPerforate_shinEntryFull);
        //        //  Data.Complete();


        //    }

        //    if (!LeftZDSV.IsEmpty && LegExamL.ZDSVid == null)
        //    {

        //        Data.ZDSVFull.Add(LeftZDSVEntryFull);

        //    }
        //}
        private void GetLegPartFromEntry(LegPartEntries FullEntry, LegPartViewModel Part, bool isLeft)
        {
            if (FullEntry == null)
            {
                throw new Exception("FullEntry is null");
            }
            if (isLeft)
            {

                if (Part is PDSVViewModel)
                {
                    if (FullEntry.EntryId0 != null)
                    {
                        LeftPDSV.AdditionalStructure.CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId0.Value);
                        LeftPDSV.AdditionalStructure.SelectedValue = Data.PDSVHips.Get(LeftPDSV.AdditionalStructure.CurrentEntry.StructureID);

                    }
                    if (Data.PDSVHipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftPDSV.LegSections[0].CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId1);
                        LeftPDSV.LegSections[0].SelectedValue = Data.PDSVHips.Get(LeftPDSV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftPDSV.LegSections[1].CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId2.Value);
                        LeftPDSV.LegSections[1].SelectedValue = Data.PDSVHips.Get(LeftPDSV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftPDSV.LegSections[2].CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId3.Value);
                        LeftPDSV.LegSections[2].SelectedValue = Data.PDSVHips.Get(LeftPDSV.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.WayID != null)
                    {
                        LeftPDSV.SelectedWayType = LeftPDSV.PDSVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    LeftPDSV.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftPDSV);
                    PDSVLeftstr = result.stringList;
                    IsVisiblePDSVleft = result.listVisibility;


                }
                else if (Part is SFSViewModel)
                {



                    if (Data.SFSHipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftSFS.LegSections[0].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId1);
                        LeftSFS.LegSections[0].SelectedValue = Data.SFSHips.Get(LeftSFS.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftSFS.LegSections[1].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId2.Value);
                        LeftSFS.LegSections[1].SelectedValue = Data.SFSHips.Get(LeftSFS.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftSFS.LegSections[2].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId3.Value);
                        LeftSFS.LegSections[2].SelectedValue = Data.SFSHips.Get(LeftSFS.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        LeftSFS.LegSections[3].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId4.Value);
                        LeftSFS.LegSections[3].SelectedValue = Data.SFSHips.Get(LeftSFS.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        LeftSFS.LegSections[4].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId5.Value);
                        LeftSFS.LegSections[4].SelectedValue = Data.SFSHips.Get(LeftSFS.LegSections[4].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId6 != null)
                    {
                        LeftSFS.LegSections[5].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId6.Value);
                        LeftSFS.LegSections[5].SelectedValue = Data.SFSHips.Get(LeftSFS.LegSections[5].CurrentEntry.StructureID);

                    }

                    LeftSFS.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftSFS);
                    SFSLeftstr = result.stringList;
                    IsVisibleSFSleft = result.listVisibility;

                }
                else if (Part is BPVHipViewModel)
                {

                    if (FullEntry.EntryId0 != null)
                    {
                        LeftBPVHip.AdditionalStructure.CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId0.Value);
                        LeftBPVHip.AdditionalStructure.SelectedValue = Data.BPVHips.Get(LeftBPVHip.AdditionalStructure.CurrentEntry.StructureID);

                    }

                    if (Data.BPVHipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftBPVHip.LegSections[0].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId1);
                        LeftBPVHip.LegSections[0].SelectedValue = Data.BPVHips.Get(LeftBPVHip.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftBPVHip.LegSections[1].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId2.Value);
                        LeftBPVHip.LegSections[1].SelectedValue = Data.BPVHips.Get(LeftBPVHip.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftBPVHip.LegSections[2].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId3.Value);
                        LeftBPVHip.LegSections[2].SelectedValue = Data.BPVHips.Get(LeftBPVHip.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        LeftBPVHip.LegSections[3].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId4.Value);
                        LeftBPVHip.LegSections[3].SelectedValue = Data.BPVHips.Get(LeftBPVHip.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        LeftBPVHip.LegSections[4].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId5.Value);
                        LeftBPVHip.LegSections[4].SelectedValue = Data.BPVHips.Get(LeftBPVHip.LegSections[4].CurrentEntry.StructureID);

                    }

                    if (FullEntry.WayID != null)
                    {
                        LeftBPVHip.SelectedWayType = LeftBPVHip.BpvWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    LeftBPVHip.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftBPVHip);
                    BpvLeftstr = result.stringList;
                    IsVisibleBPVleft = result.listVisibility;

                }
                else if (Part is BPVTibiaViewModel)
                {


                    if (Data.BPV_TibiaEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftBPVTibia.LegSections[0].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId1);
                        LeftBPVTibia.LegSections[0].SelectedValue = Data.BPV_Tibia.Get(LeftBPVTibia.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftBPVTibia.LegSections[1].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId2.Value);
                        LeftBPVTibia.LegSections[1].SelectedValue = Data.BPV_Tibia.Get(LeftBPVTibia.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftBPVTibia.LegSections[2].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId3.Value);
                        LeftBPVTibia.LegSections[2].SelectedValue = Data.BPV_Tibia.Get(LeftBPVTibia.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        LeftBPVTibia.LegSections[3].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId4.Value);
                        LeftBPVTibia.LegSections[3].SelectedValue = Data.BPV_Tibia.Get(LeftBPVTibia.LegSections[3].CurrentEntry.StructureID);

                    }


                    LeftBPVTibia.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftBPVTibia);
                    BPV_TibiaLeftstr = result.stringList;
                    IsVisibleBPV_Tibialeft = result.listVisibility;

                }
                else if (Part is HipPerforateViewModel)
                {



                    if (Data.Perforate_hipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftPerforate.LegSections[0].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId1);
                        LeftPerforate.LegSections[0].SelectedValue = Data.Perforate_hip.Get(LeftPerforate.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftPerforate.LegSections[1].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId2.Value);
                        LeftPerforate.LegSections[1].SelectedValue = Data.Perforate_hip.Get(LeftPerforate.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftPerforate.LegSections[2].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId3.Value);
                        LeftPerforate.LegSections[2].SelectedValue = Data.Perforate_hip.Get(LeftPerforate.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        LeftPerforate.LegSections[3].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId4.Value);
                        LeftPerforate.LegSections[3].SelectedValue = Data.Perforate_hip.Get(LeftPerforate.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        LeftPerforate.LegSections[4].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId5.Value);
                        LeftPerforate.LegSections[4].SelectedValue = Data.Perforate_hip.Get(LeftPerforate.LegSections[4].CurrentEntry.StructureID);

                    }


                    LeftPerforate.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftPerforate);
                    Perforate_hipLeftstr = result.stringList;
                    IsVisiblePerforateHIPleft = result.listVisibility;

                }
                else if (Part is ZDSVViewModel)
                {

                    if (FullEntry.EntryId0 != null)
                    {
                        LeftZDSV.AdditionalStructure.CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId0.Value);
                        LeftZDSV.AdditionalStructure.SelectedValue = Data.ZDSV.Get(LeftZDSV.AdditionalStructure.CurrentEntry.StructureID);

                    }

                    if (Data.ZDSVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftZDSV.LegSections[0].CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId1);
                        LeftZDSV.LegSections[0].SelectedValue = Data.ZDSV.Get(LeftZDSV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftZDSV.LegSections[1].CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId2.Value);
                        LeftZDSV.LegSections[1].SelectedValue = Data.ZDSV.Get(LeftZDSV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftZDSV.LegSections[2].CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId3.Value);
                        LeftZDSV.LegSections[2].SelectedValue = Data.ZDSV.Get(LeftZDSV.LegSections[2].CurrentEntry.StructureID);

                    }
                    LeftZDSV.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftZDSV);
                    ZDSVLeftstr = result.stringList;
                    IsVisibleZDSVleft = result.listVisibility;

                }
                else if (Part is SPSViewModel)
                {

                    if (FullEntry.EntryId0 != null)
                    {
                        LeftSPS.AdditionalStructure.CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId0.Value);
                        LeftSPS.AdditionalStructure.SelectedValue = Data.SPS.Get(LeftSPS.AdditionalStructure.CurrentEntry.StructureID);

                    }

                    if (Data.SPSEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftSPS.LegSections[0].CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId1);
                        LeftSPS.LegSections[0].SelectedValue = Data.SPS.Get(LeftSPS.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftSPS.LegSections[1].CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId2.Value);
                        LeftSPS.LegSections[1].SelectedValue = Data.SPS.Get(LeftSPS.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftSPS.LegSections[2].CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId3.Value);
                        LeftSPS.LegSections[2].SelectedValue = Data.SPS.Get(LeftSPS.LegSections[2].CurrentEntry.StructureID);

                    }

                    LeftSPS.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftSPS);
                    SPSLeftstr = result.stringList;
                    IsVisibleSPSleft = result.listVisibility;

                }
                else if (Part is TibiaPerforateViewModel)
                {



                    if (Data.Perforate_shinEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftTibiaPerforate.LegSections[0].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId1);
                        LeftTibiaPerforate.LegSections[0].SelectedValue = Data.Perforate_shin.Get(LeftTibiaPerforate.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftTibiaPerforate.LegSections[1].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId2.Value);
                        LeftTibiaPerforate.LegSections[1].SelectedValue = Data.Perforate_shin.Get(LeftTibiaPerforate.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftTibiaPerforate.LegSections[2].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId3.Value);
                        LeftTibiaPerforate.LegSections[2].SelectedValue = Data.Perforate_shin.Get(LeftTibiaPerforate.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        LeftTibiaPerforate.LegSections[3].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId4.Value);
                        LeftTibiaPerforate.LegSections[3].SelectedValue = Data.Perforate_shin.Get(LeftTibiaPerforate.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        LeftTibiaPerforate.LegSections[4].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId5.Value);
                        LeftTibiaPerforate.LegSections[4].SelectedValue = Data.Perforate_shin.Get(LeftTibiaPerforate.LegSections[4].CurrentEntry.StructureID);

                    }

                    LeftTibiaPerforate.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftTibiaPerforate);
                    Perforate_shinLeftstr = result.stringList;
                    IsVisiblePerforate_shinleft = result.listVisibility;

                }
                else if (Part is MPVViewModel)
                {



                    if (Data.MPVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftMPV.LegSections[0].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId1);
                        LeftMPV.LegSections[0].SelectedValue = Data.MPV.Get(LeftMPV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftMPV.LegSections[1].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId2.Value);
                        LeftMPV.LegSections[1].SelectedValue = Data.MPV.Get(LeftMPV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftMPV.LegSections[2].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId3.Value);
                        LeftMPV.LegSections[2].SelectedValue = Data.MPV.Get(LeftMPV.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        LeftMPV.LegSections[3].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId4.Value);
                        LeftMPV.LegSections[3].SelectedValue = Data.MPV.Get(LeftMPV.LegSections[3].CurrentEntry.StructureID);

                    }


                    if (FullEntry.WayID != null)
                    {
                        LeftMPV.SelectedWayType = LeftMPV.MPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    LeftMPV.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftMPV);
                    MPVLeftstr = result.stringList;
                    IsVisibleMPVleft = result.listVisibility;

                }
                else if (Part is TEMPVViewModel)
                {



                    if (Data.TEMPVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftTEMPV.LegSections[0].CurrentEntry = Data.TEMPVEntries.Get(FullEntry.EntryId1);
                        LeftTEMPV.LegSections[0].SelectedValue = Data.TEMPV.Get(LeftTEMPV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftTEMPV.LegSections[1].CurrentEntry = Data.TEMPVEntries.Get(FullEntry.EntryId2.Value);
                        LeftTEMPV.LegSections[1].SelectedValue = Data.TEMPV.Get(LeftTEMPV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        LeftTEMPV.LegSections[2].CurrentEntry = Data.TEMPVEntries.Get(FullEntry.EntryId3.Value);
                        LeftTEMPV.LegSections[2].SelectedValue = Data.TEMPV.Get(LeftTEMPV.LegSections[2].CurrentEntry.StructureID);

                    }

                    if (FullEntry.WayID != null)
                    {
                        LeftTEMPV.SelectedWayType = LeftTEMPV.TEMPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    LeftTEMPV.FF_length = ((TEMPVEntryFull)FullEntry).FF_Length;
                    LeftTEMPV.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftTEMPV);
                    TEMPVLeftstr = result.stringList;
                    IsVisibleTEMPVleft = result.listVisibility;

                }
                else if (Part is GVViewModel)
                {



                    if (Data.GVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftGV.LegSections[0].CurrentEntry = Data.GVEntries.Get(FullEntry.EntryId1);
                        LeftGV.LegSections[0].SelectedValue = Data.GV.Get(LeftGV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftGV.LegSections[1].CurrentEntry = Data.GVEntries.Get(FullEntry.EntryId2.Value);
                        LeftGV.LegSections[1].SelectedValue = Data.GV.Get(LeftGV.LegSections[1].CurrentEntry.StructureID);

                    }



                    LeftGV.IsEmpty = false;
                    SaveSet result = SaveViewModel(LeftGV);
                    GVLeftstr = result.stringList;
                    IsVisibleGVleft = result.listVisibility;

                }
                else if (Part is PPVViewModel)
                {



                    if (Data.PPVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        LeftPPV.LegSections[0].CurrentEntry = Data.PPVEntries.Get(FullEntry.EntryId1);
                        LeftPPV.LegSections[0].SelectedValue = Data.PPV.Get(LeftPPV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        LeftPPV.LegSections[1].CurrentEntry = Data.PPVEntries.Get(FullEntry.EntryId2.Value);
                        LeftPPV.LegSections[1].SelectedValue = Data.PPV.Get(LeftPPV.LegSections[1].CurrentEntry.StructureID);

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
                    if (FullEntry.EntryId0 != null)
                    {
                        RightPDSV.AdditionalStructure.CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId0.Value);
                        RightPDSV.AdditionalStructure.SelectedValue = Data.PDSVHips.Get(RightPDSV.AdditionalStructure.CurrentEntry.StructureID);
                    }
                    if (Data.PDSVHipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightPDSV.LegSections[0].CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId1);
                        RightPDSV.LegSections[0].SelectedValue = Data.PDSVHips.Get(RightPDSV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightPDSV.LegSections[1].CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId2.Value);
                        RightPDSV.LegSections[1].SelectedValue = Data.PDSVHips.Get(RightPDSV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightPDSV.LegSections[2].CurrentEntry = Data.PDSVHipEntries.Get(FullEntry.EntryId3.Value);
                        RightPDSV.LegSections[2].SelectedValue = Data.PDSVHips.Get(RightPDSV.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.WayID != null)
                    {
                        RightPDSV.SelectedWayType = RightPDSV.PDSVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    RightPDSV.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightPDSV);
                    PDSVRightstr = result.stringList;
                    IsVisiblePDSVright = result.listVisibility;


                }
                else if (Part is SFSViewModel)
                {



                    if (Data.SFSHipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightSFS.LegSections[0].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId1);
                        RightSFS.LegSections[0].SelectedValue = Data.SFSHips.Get(RightSFS.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightSFS.LegSections[1].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId2.Value);
                        RightSFS.LegSections[1].SelectedValue = Data.SFSHips.Get(RightSFS.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightSFS.LegSections[2].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId3.Value);
                        RightSFS.LegSections[2].SelectedValue = Data.SFSHips.Get(RightSFS.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        RightSFS.LegSections[3].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId4.Value);
                        RightSFS.LegSections[3].SelectedValue = Data.SFSHips.Get(RightSFS.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        RightSFS.LegSections[4].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId5.Value);
                        RightSFS.LegSections[4].SelectedValue = Data.SFSHips.Get(RightSFS.LegSections[4].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId6 != null)
                    {
                        RightSFS.LegSections[5].CurrentEntry = Data.SFSHipEntries.Get(FullEntry.EntryId6.Value);
                        RightSFS.LegSections[5].SelectedValue = Data.SFSHips.Get(RightSFS.LegSections[5].CurrentEntry.StructureID);

                    }

                    RightSFS.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightSFS);
                    SFSRightstr = result.stringList;
                    IsVisibleSFSRight = result.listVisibility;

                }
                else if (Part is BPVHipViewModel)
                {
                    if (FullEntry.EntryId0 != null)
                    {
                        RightBPVHip.AdditionalStructure.CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId0.Value);
                        //var xs = Data.BPVHips.Get(RightBPVHip.AdditionalStructure.CurrentEntry.StructureID);
                        RightBPVHip.AdditionalStructure.SelectedValue = Data.BPVHips.Get(RightBPVHip.AdditionalStructure.CurrentEntry.StructureID);

                    }


                    if (Data.BPVHipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightBPVHip.LegSections[0].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId1);
                        RightBPVHip.LegSections[0].SelectedValue = Data.BPVHips.Get(RightBPVHip.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightBPVHip.LegSections[1].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId2.Value);
                        RightBPVHip.LegSections[1].SelectedValue = Data.BPVHips.Get(RightBPVHip.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightBPVHip.LegSections[2].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId3.Value);
                        RightBPVHip.LegSections[2].SelectedValue = Data.BPVHips.Get(RightBPVHip.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        RightBPVHip.LegSections[3].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId4.Value);
                        RightBPVHip.LegSections[3].SelectedValue = Data.BPVHips.Get(RightBPVHip.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        RightBPVHip.LegSections[4].CurrentEntry = Data.BPVHipEntries.Get(FullEntry.EntryId5.Value);
                        RightBPVHip.LegSections[4].SelectedValue = Data.BPVHips.Get(RightBPVHip.LegSections[4].CurrentEntry.StructureID);

                    }

                    if (FullEntry.WayID != null)
                    {
                        RightBPVHip.SelectedWayType = RightBPVHip.BpvWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    RightBPVHip.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightBPVHip);
                    BpvRightstr = result.stringList;
                    IsVisibleBPVRight = result.listVisibility;

                }
                else if (Part is BPVTibiaViewModel)
                {


                    if (Data.BPV_TibiaEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightBPVTibia.LegSections[0].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId1);
                        RightBPVTibia.LegSections[0].SelectedValue = Data.BPV_Tibia.Get(RightBPVTibia.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightBPVTibia.LegSections[1].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId2.Value);
                        RightBPVTibia.LegSections[1].SelectedValue = Data.BPV_Tibia.Get(RightBPVTibia.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightBPVTibia.LegSections[2].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId3.Value);
                        RightBPVTibia.LegSections[2].SelectedValue = Data.BPV_Tibia.Get(RightBPVTibia.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        RightBPVTibia.LegSections[3].CurrentEntry = Data.BPV_TibiaEntries.Get(FullEntry.EntryId4.Value);
                        RightBPVTibia.LegSections[3].SelectedValue = Data.BPV_Tibia.Get(RightBPVTibia.LegSections[3].CurrentEntry.StructureID);

                    }


                    RightBPVTibia.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightBPVTibia);
                    BPV_TibiaRightstr = result.stringList;
                    IsVisibleBPV_Tibiaright = result.listVisibility;

                }
                else if (Part is HipPerforateViewModel)
                {



                    if (Data.Perforate_hipEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightPerforate.LegSections[0].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId1);
                        RightPerforate.LegSections[0].SelectedValue = Data.Perforate_hip.Get(RightPerforate.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightPerforate.LegSections[1].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId2.Value);
                        RightPerforate.LegSections[1].SelectedValue = Data.Perforate_hip.Get(RightPerforate.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightPerforate.LegSections[2].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId3.Value);
                        RightPerforate.LegSections[2].SelectedValue = Data.Perforate_hip.Get(RightPerforate.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        RightPerforate.LegSections[3].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId4.Value);
                        RightPerforate.LegSections[3].SelectedValue = Data.Perforate_hip.Get(RightPerforate.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        RightPerforate.LegSections[4].CurrentEntry = Data.Perforate_hipEntries.Get(FullEntry.EntryId5.Value);
                        RightPerforate.LegSections[4].SelectedValue = Data.Perforate_hip.Get(RightPerforate.LegSections[4].CurrentEntry.StructureID);

                    }


                    RightPerforate.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightPerforate);
                    Perforate_hipRightstr = result.stringList;
                    IsVisiblePerforateHIPright = result.listVisibility;

                }
                else if (Part is ZDSVViewModel)
                {


                    if (FullEntry.EntryId0 != null)
                    {
                        RightZDSV.AdditionalStructure.CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId0.Value);
                        RightZDSV.AdditionalStructure.SelectedValue = Data.ZDSV.Get(RightZDSV.AdditionalStructure.CurrentEntry.StructureID);

                    }

                    if (Data.ZDSVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightZDSV.LegSections[0].CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId1);
                        RightZDSV.LegSections[0].SelectedValue = Data.ZDSV.Get(RightZDSV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightZDSV.LegSections[1].CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId2.Value);
                        RightZDSV.LegSections[1].SelectedValue = Data.ZDSV.Get(RightZDSV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightZDSV.LegSections[2].CurrentEntry = Data.ZDSVEntries.Get(FullEntry.EntryId3.Value);
                        RightZDSV.LegSections[2].SelectedValue = Data.ZDSV.Get(RightZDSV.LegSections[2].CurrentEntry.StructureID);

                    }
                    RightZDSV.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightZDSV);
                    ZDSVRightstr = result.stringList;
                    IsVisibleZDSVright = result.listVisibility;

                }
                else if (Part is SPSViewModel)
                {
                    if (FullEntry.EntryId0 != null)
                    {
                        RightSPS.AdditionalStructure.CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId0.Value);
                        RightSPS.AdditionalStructure.SelectedValue = Data.SPS.Get(RightSPS.AdditionalStructure.CurrentEntry.StructureID);

                    }


                    if (Data.SPSEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightSPS.LegSections[0].CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId1);
                        RightSPS.LegSections[0].SelectedValue = Data.SPS.Get(RightSPS.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightSPS.LegSections[1].CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId2.Value);
                        RightSPS.LegSections[1].SelectedValue = Data.SPS.Get(RightSPS.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightSPS.LegSections[2].CurrentEntry = Data.SPSEntries.Get(FullEntry.EntryId3.Value);
                        RightSPS.LegSections[2].SelectedValue = Data.SPS.Get(RightSPS.LegSections[2].CurrentEntry.StructureID);

                    }

                    RightSPS.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightSPS);
                    SPSRightstr = result.stringList;
                    IsVisibleSPSRight = result.listVisibility;

                }
                else if (Part is TibiaPerforateViewModel)
                {



                    if (Data.Perforate_shinEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightTibiaPerforate.LegSections[0].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId1);
                        RightTibiaPerforate.LegSections[0].SelectedValue = Data.Perforate_shin.Get(RightTibiaPerforate.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightTibiaPerforate.LegSections[1].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId2.Value);
                        RightTibiaPerforate.LegSections[1].SelectedValue = Data.Perforate_shin.Get(RightTibiaPerforate.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightTibiaPerforate.LegSections[2].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId3.Value);
                        RightTibiaPerforate.LegSections[2].SelectedValue = Data.Perforate_shin.Get(RightTibiaPerforate.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        RightTibiaPerforate.LegSections[3].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId4.Value);
                        RightTibiaPerforate.LegSections[3].SelectedValue = Data.Perforate_shin.Get(RightTibiaPerforate.LegSections[3].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId5 != null)
                    {
                        RightTibiaPerforate.LegSections[4].CurrentEntry = Data.Perforate_shinEntries.Get(FullEntry.EntryId5.Value);
                        RightTibiaPerforate.LegSections[4].SelectedValue = Data.Perforate_shin.Get(RightTibiaPerforate.LegSections[4].CurrentEntry.StructureID);

                    }

                    RightTibiaPerforate.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightTibiaPerforate);
                    Perforate_shinRightstr = result.stringList;
                    IsVisiblePerforate_shinRight = result.listVisibility;

                }
                else if (Part is MPVViewModel)
                {



                    if (Data.MPVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightMPV.LegSections[0].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId1);
                        RightMPV.LegSections[0].SelectedValue = Data.MPV.Get(RightMPV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightMPV.LegSections[1].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId2.Value);
                        RightMPV.LegSections[1].SelectedValue = Data.MPV.Get(RightMPV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightMPV.LegSections[2].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId3.Value);
                        RightMPV.LegSections[2].SelectedValue = Data.MPV.Get(RightMPV.LegSections[2].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId4 != null)
                    {
                        RightMPV.LegSections[3].CurrentEntry = Data.MPVEntries.Get(FullEntry.EntryId4.Value);
                        RightMPV.LegSections[3].SelectedValue = Data.MPV.Get(RightMPV.LegSections[3].CurrentEntry.StructureID);

                    }


                    if (FullEntry.WayID != null)
                    {
                        RightMPV.SelectedWayType = RightMPV.MPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    RightMPV.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightMPV);
                    MPVRightstr = result.stringList;
                    IsVisibleMPVRight = result.listVisibility;

                }
                else if (Part is TEMPVViewModel)
                {



                    if (Data.TEMPVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightTEMPV.LegSections[0].CurrentEntry = Data.TEMPVEntries.Get(FullEntry.EntryId1);
                        RightTEMPV.LegSections[0].SelectedValue = Data.TEMPV.Get(RightTEMPV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightTEMPV.LegSections[1].CurrentEntry = Data.TEMPVEntries.Get(FullEntry.EntryId2.Value);
                        RightTEMPV.LegSections[1].SelectedValue = Data.TEMPV.Get(RightTEMPV.LegSections[1].CurrentEntry.StructureID);

                    }
                    if (FullEntry.EntryId3 != null)
                    {
                        RightTEMPV.LegSections[2].CurrentEntry = Data.TEMPVEntries.Get(FullEntry.EntryId3.Value);
                        RightTEMPV.LegSections[2].SelectedValue = Data.TEMPV.Get(RightTEMPV.LegSections[2].CurrentEntry.StructureID);

                    }

                    if (FullEntry.WayID != null)
                    {
                        RightTEMPV.SelectedWayType = RightTEMPV.TEMPVWayType.Where(s => s.Id == FullEntry.WayID).ToList()[0];
                    }

                    RightTEMPV.FF_length = ((TEMPVEntryFull)FullEntry).FF_Length;
                    RightTEMPV.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightTEMPV);
                    TEMPVRightstr = result.stringList;
                    IsVisibleTEMPVRight = result.listVisibility;

                }
                else if (Part is GVViewModel)
                {



                    if (Data.GVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightGV.LegSections[0].CurrentEntry = Data.GVEntries.Get(FullEntry.EntryId1);
                        RightGV.LegSections[0].SelectedValue = Data.GV.Get(RightGV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightGV.LegSections[1].CurrentEntry = Data.GVEntries.Get(FullEntry.EntryId2.Value);
                        RightGV.LegSections[1].SelectedValue = Data.GV.Get(RightGV.LegSections[1].CurrentEntry.StructureID);

                    }



                    RightGV.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightGV);
                    GVRightstr = result.stringList;
                    IsVisibleGVRight = result.listVisibility;

                }
                else if (Part is PPVViewModel)
                {



                    if (Data.PPVEntries.Get(FullEntry.EntryId1) != null)
                    {
                        RightPPV.LegSections[0].CurrentEntry = Data.PPVEntries.Get(FullEntry.EntryId1);
                        RightPPV.LegSections[0].SelectedValue = Data.PPV.Get(RightPPV.LegSections[0].CurrentEntry.StructureID);
                    }
                    if (FullEntry.EntryId2 != null)
                    {
                        RightPPV.LegSections[1].CurrentEntry = Data.PPVEntries.Get(FullEntry.EntryId2.Value);
                        RightPPV.LegSections[1].SelectedValue = Data.PPV.Get(RightPPV.LegSections[1].CurrentEntry.StructureID);

                    }


                    RightPPV.IsEmpty = false;
                    SaveSet result = SaveViewModel(RightPPV);
                    PPVRightstr = result.stringList;
                    IsVisiblePPVRight = result.listVisibility;

                }


            }

        }

        private int? statementOverviewId;
        private int? hirurgOverviewId;

        private LegPartEntries SaveFullEntry(LegPartViewModel Part, LegPartEntries FullEntry, bool isLeft, string mode)
        {



            if (mode != "EDIT" && !Part.IsEmpty)
            {
                LegPartEntries LeftSFSEntryFullbuf = FullEntry;
                LegPartEntry newSFSentry;
                if (Part is ZDSVViewModel)
                {
                    newSFSentry = ((ZDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                    Data.Complete();
                }
                if (Part is BPVHipViewModel)
                {
                    newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                    Data.Complete();
                }
                if (Part is PDSVViewModel)
                {
                    newSFSentry = ((PDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((PDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                    Data.Complete();
                }
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    //Data.Complete();
                    if (Part is PDSVViewModel)
                    {


                        Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is SFSViewModel)
                    {


                        //  ((SFSHipEntry)newSFSentry).Structure = (SFSHipStructure)section.SelectedValue;
                        Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is BPVHipViewModel)
                    {

                        Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is BPVTibiaViewModel)
                    {

                        Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is HipPerforateViewModel)
                    {


                        Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is ZDSVViewModel)
                    {

                        Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                        Data.Complete();


                    }

                    else if (Part is SPSViewModel)
                    {

                        Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is TibiaPerforateViewModel)
                    {

                        Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is MPVViewModel)
                    {

                        Data.MPVEntries.Add((MPVEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is TEMPVViewModel)
                    {
                        ((TEMPVEntryFull)LeftSFSEntryFullbuf).FF_Length = Part.FF_length;

                        Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is PPVViewModel)
                    {

                        Data.PPVEntries.Add((PPVEntry)newSFSentry);
                        Data.Complete();


                    }
                    else if (Part is GVViewModel)
                    {

                        Data.GVEntries.Add((GVEntry)newSFSentry);
                        Data.Complete();


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
                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }



                return LeftSFSEntryFullbuf;

            }
            else if (mode == "EDIT")
            {

                Examination Exam = Data.Examination.Get(obsid);
                ExaminationLeg LegExam = new ExaminationLeg();
                if (Exam == null || LegExam == null)
                {
                    return FullEntry;
                }

                if (isLeft)
                {
                    LegExam = Data.ExaminationLeg.Get(Exam.idLeftLegExamination.Value);
                }
                else
                {
                    LegExam = Data.ExaminationLeg.Get(Exam.idRightLegExamination.Value);
                }

                LegPartEntries LeftSFSEntryFullbuf = FullEntry;

                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

                if (Part is PDSVViewModel && LegExam.PDSVid != null)
                {

                    PDSVHipEntry EntToChange = new PDSVHipEntry();
                    PDSVHipEntryFull EntFullToChange = Data.PDSVFull.Get(LegExam.PDSVid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.PDSVFull.Remove(EntFullToChange);
                                LegExam.PDSVid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((PDSVHipEntry)newSFSentry).Comment;
                            EntToChange.Size = ((PDSVHipEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((PDSVHipEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((PDSVHipEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is PDSVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }










                if (Part is ZDSVViewModel && LegExam.ZDSVid != null)
                {

                    ZDSVEntry EntToChange = new ZDSVEntry();
                    ZDSVEntryFull EntFullToChange = Data.ZDSVFull.Get(LegExam.ZDSVid.Value);
                    LegPartEntry newSFSentry;
                    bool test = true;

                    if (((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue == null)
                    {
                        test = false;
                        EntFullToChange.EntryId0 = null;

                    }
                    else
                    {
                        newSFSentry = ((ZDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                        if (EntFullToChange.EntryId0 == null)
                        {
                            test = false;
                            Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                            Data.Complete();
                            EntFullToChange.EntryId0 = newSFSentry.Id;
                            Data.Complete();
                        }
                        else
                        {
                            EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId0.Value);
                        }

                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                    }
                    if (test)
                    {
                        newSFSentry = ((ZDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                        EntToChange.Comment = ((ZDSVEntry)newSFSentry).Comment;
                        EntToChange.Size = ((ZDSVEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((ZDSVEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((ZDSVEntry)newSFSentry).StructureID;
                    }
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.ZDSVFull.Remove(EntFullToChange);
                                LegExam.ZDSVid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((ZDSVEntry)newSFSentry).Comment;
                            EntToChange.Size = ((ZDSVEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((ZDSVEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((ZDSVEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is ZDSVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }




                if (Part is HipPerforateViewModel && LegExam.PerforateHipid != null)
                {

                    Perforate_hipEntry EntToChange = new Perforate_hipEntry();
                    Perforate_hipEntryFull EntFullToChange = Data.Perforate_hipFull.Get(LegExam.PerforateHipid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.Perforate_hipFull.Remove(EntFullToChange);
                                LegExam.PerforateHipid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((Perforate_hipEntry)newSFSentry).Comment;
                            EntToChange.Size = ((Perforate_hipEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((Perforate_hipEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((Perforate_hipEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is HipPerforateViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }


                if (Part is TibiaPerforateViewModel && LegExam.TibiaPerforateid != null)
                {

                    Perforate_shinEntry EntToChange = new Perforate_shinEntry();
                    Perforate_shinEntryFull EntFullToChange = Data.Perforate_shinFull.Get(LegExam.TibiaPerforateid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.Perforate_shinFull.Remove(EntFullToChange);
                                LegExam.TibiaPerforateid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((Perforate_shinEntry)newSFSentry).Comment;
                            EntToChange.Size = ((Perforate_shinEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((Perforate_shinEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((Perforate_shinEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is TibiaPerforateViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }


















                if (Part is BPVHipViewModel && LegExam.BPVHip != null)
                {

                    BPVHipEntry EntToChange = new BPVHipEntry();
                    BPVHipEntryFull EntFullToChange = Data.BPVHipsFull.Get(LegExam.BPVHip.Value);
                    LegPartEntry newSFSentry;
                    bool test = true;

                    if (((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue == null)
                    {
                        test = false;
                        EntFullToChange.EntryId0 = null;

                    }
                    else
                    {
                        newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                        if (EntFullToChange.EntryId0 == null)
                        {
                            test = false;
                            Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                            Data.Complete();
                            EntFullToChange.EntryId0 = newSFSentry.Id;
                            Data.Complete();
                        }
                        else
                        {
                            EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId0.Value);
                        }

                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                    }
                    if (test)
                    {
                        newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                        EntToChange.Comment = ((BPVHipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((BPVHipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((BPVHipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((BPVHipEntry)newSFSentry).StructureID;
                    }


                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.BPVHipsFull.Remove(EntFullToChange);
                                LegExam.BPVHip = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((BPVHipEntry)newSFSentry).Comment;
                            EntToChange.Size = ((BPVHipEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((BPVHipEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((BPVHipEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is BPVHipViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }









                if (Part is SFSViewModel && LegExam.SFSid != null)
                {

                    SFSHipEntry EntToChange = new SFSHipEntry();
                    SFSHipEntryFull EntFullToChange = Data.SFSFull.Get(LegExam.SFSid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.SFSFull.Remove(EntFullToChange);
                                LegExam.SFSid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((SFSHipEntry)newSFSentry).Comment;
                            EntToChange.Size = ((SFSHipEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((SFSHipEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((SFSHipEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is SFSViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }
















                if (Part is BPVTibiaViewModel && LegExam.BPVTibiaid != null)
                {

                    BPV_TibiaEntry EntToChange = new BPV_TibiaEntry();
                    BPV_TibiaEntryFull EntFullToChange = Data.BPV_TibiaFull.Get(LegExam.BPVTibiaid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.BPV_TibiaFull.Remove(EntFullToChange);
                                LegExam.BPVTibiaid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((BPV_TibiaEntry)newSFSentry).Comment;
                            EntToChange.Size = ((BPV_TibiaEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((BPV_TibiaEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((BPV_TibiaEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is BPVTibiaViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }










                if (Part is SPSViewModel && LegExam.SPSid != null)
                {

                    SPSHipEntry EntToChange = new SPSHipEntry();
                    SPSHipEntryFull EntFullToChange = Data.SPSHipFull.Get(LegExam.SPSid.Value);
                    LegPartEntry newSFSentry;
                    bool test = true;

                    if (((SPSViewModel)(Part)).AdditionalStructure.SelectedValue == null)
                    {
                        test = false;
                        EntFullToChange.EntryId0 = null;

                    }
                    else
                    {
                        newSFSentry = ((SPSViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((SPSViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                        if (EntFullToChange.EntryId0 == null)
                        {
                            test = false;
                            Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                            Data.Complete();
                            EntFullToChange.EntryId0 = newSFSentry.Id;
                            Data.Complete();
                        }
                        else
                        {
                            EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId0.Value);
                        }

                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                    }
                    if (test)
                    {
                        newSFSentry = ((SPSViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((SPSViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                        EntToChange.Comment = ((SPSHipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((SPSHipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((SPSHipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((SPSHipEntry)newSFSentry).StructureID;
                    }
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.SPSHipFull.Remove(EntFullToChange);
                                LegExam.SPSid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((SPSHipEntry)newSFSentry).Comment;
                            EntToChange.Size = ((SPSHipEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((SPSHipEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((SPSHipEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is SPSViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }










                if (Part is MPVViewModel && LegExam.MPVid != null)
                {

                    MPVEntry EntToChange = new MPVEntry();
                    MPVEntryFull EntFullToChange = Data.MPVFull.Get(LegExam.MPVid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.MPVFull.Remove(EntFullToChange);
                                LegExam.MPVid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((MPVEntry)newSFSentry).Comment;
                            EntToChange.Size = ((MPVEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((MPVEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((MPVEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is MPVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.MPVEntries.Add((MPVEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }


                if (Part is TEMPVViewModel && LegExam.TEMPVid != null)
                {

                    TEMPVEntry EntToChange = new TEMPVEntry();
                    TEMPVEntryFull EntFullToChange = Data.TEMPVFull.Get(LegExam.TEMPVid.Value);
                    EntFullToChange.FF_Length = Part.FF_length;
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.TEMPVFull.Remove(EntFullToChange);
                                LegExam.TEMPVid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((TEMPVEntry)newSFSentry).Comment;
                            EntToChange.Size = ((TEMPVEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((TEMPVEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((TEMPVEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is TEMPVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }




                if (Part is PPVViewModel && LegExam.PPVid != null)
                {

                    PPVEntry EntToChange = new PPVEntry();
                    PPVEntryFull EntFullToChange = Data.PPVFull.Get(LegExam.PPVid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.PPVFull.Remove(EntFullToChange);
                                LegExam.PPVid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((PPVEntry)newSFSentry).Comment;
                            EntToChange.Size = ((PPVEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((PPVEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((PPVEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is PPVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.PPVEntries.Add((PPVEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }



                if (Part is GVViewModel && LegExam.GVid != null)
                {

                    GVEntry EntToChange = new GVEntry();
                    GVEntryFull EntFullToChange = Data.GVFull.Get(LegExam.GVid.Value);
                    for (int i = 0; i < Part.LegSections.Count; ++i)
                    {
                        if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                        { break; }

                        LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                        if (Part.LegSections[i].SelectedValue != null)
                        {
                            newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                        }
                        bool test = true;
                        if (i == 0)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                Data.GVFull.Remove(EntFullToChange);
                                LegExam.GVid = null;
                                Data.Complete();
                                break;
                            }
                            else
                            {

                                EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId1);
                                LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                            }

                        }
                        else if (i == 1)
                        {

                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId2 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId2 == null)
                                {
                                    test = false;
                                    Data.GVEntries.Add((GVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId2 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId2.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                            }
                        }
                        else if (i == 2)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId3 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId3 == null)
                                {
                                    test = false;
                                    Data.GVEntries.Add((GVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId3 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId3.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                            }
                        }
                        else if (i == 3)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId4 = null;

                            }
                            else
                            {
                                if (EntFullToChange.EntryId4 == null)
                                {
                                    test = false;
                                    Data.GVEntries.Add((GVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId4 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId4.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                            }
                        }
                        else if (i == 4)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId5 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId5 == null)
                                {
                                    test = false;
                                    Data.GVEntries.Add((GVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId5 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId5.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                            }
                        }
                        else if (i == 5)
                        {
                            if (Part.LegSections[i].SelectedValue == null)
                            {
                                test = false;
                                EntFullToChange.EntryId6 = null;
                            }
                            else
                            {
                                if (EntFullToChange.EntryId6 == null)
                                {
                                    test = false;
                                    Data.GVEntries.Add((GVEntry)newSFSentry);
                                    Data.Complete();
                                    EntFullToChange.EntryId6 = newSFSentry.Id;
                                    Data.Complete();
                                }
                                else
                                {
                                    EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId6.Value);
                                }

                                LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                            }
                        }

                        if (test)
                        {
                            EntToChange.Comment = ((GVEntry)newSFSentry).Comment;
                            EntToChange.Size = ((GVEntry)newSFSentry).Size;
                            EntToChange.Size2 = ((GVEntry)newSFSentry).Size2;
                            EntToChange.StructureID = ((GVEntry)newSFSentry).StructureID;
                        }


                        Data.Complete();



                    }
                }
                else if (Part is GVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
                {
                    foreach (var section in Part.LegSections)
                    {
                        if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                        { break; }
                        LegPartEntry newSFSentry = section.CurrentEntry;
                        newSFSentry.StructureID = section.SelectedValue.Id;

                        Data.GVEntries.Add((GVEntry)newSFSentry);
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


                    if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                    {
                        LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                    }

                }

            }

            return FullEntry;
        }


        private SaveSet SaveViewModel(LegPartViewModel sender)
        {
            List<string> bufBpvLeftStr = new List<string>();



            //to do тут должно быть сохранение


            var IsVisibleBPVleftbuf = new ObservableCollection<Visibility>();
            if (sender is SPSViewModel)
            {
                var aditionalStructureValue = ((SPSViewModel)(sender)).AdditionalStructure;

                if (aditionalStructureValue.SelectedValue == null || (aditionalStructureValue.SelectedValue.Text2 == "" && aditionalStructureValue.SelectedValue.Text1 == ""))
                {


                }
                else
                {
                    if (aditionalStructureValue.SelectedValue.HasSize || aditionalStructureValue.HasDoubleSize)
                    {
                        if (aditionalStructureValue.HasDoubleSize)
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");


                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                        }
                        else
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + "");

                        }

                    }

                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }
                //    name = "БПВНБ";

                //  continue;
            }
            if (sender is ZDSVViewModel)
            {
                var aditionalStructureValue = ((ZDSVViewModel)(sender)).AdditionalStructure;

                if (aditionalStructureValue.SelectedValue == null || (aditionalStructureValue.SelectedValue.Text2 == "" && aditionalStructureValue.SelectedValue.Text1 == ""))
                {


                }
                else
                {
                    if (aditionalStructureValue.SelectedValue.HasSize || aditionalStructureValue.HasDoubleSize)
                    {
                        if (aditionalStructureValue.HasDoubleSize)
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");


                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                        }
                        else
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + "");

                        }

                    }

                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }
                //    name = "БПВНБ";

                //  continue;
            }
            // IsVisibleBPVleftbuf.Add(Visibility.Visible);
            if (sender is BPVHipViewModel)
            {
                var aditionalStructureValue = ((BPVHipViewModel)(sender)).AdditionalStructure;

                if (aditionalStructureValue.SelectedValue == null || (aditionalStructureValue.SelectedValue.Text2 == "" && aditionalStructureValue.SelectedValue.Text1 == ""))
                {


                }
                else
                {
                    if (aditionalStructureValue.SelectedValue.HasSize || aditionalStructureValue.HasDoubleSize)
                    {
                        if (aditionalStructureValue.HasDoubleSize)
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");


                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                        }
                        else
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + "");

                        }

                    }

                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }
                //    name = "БПВНБ";

                //  continue;
            }
            else if (sender is PDSVViewModel)
            {
                var aditionalStructureValue = ((PDSVViewModel)(sender)).AdditionalStructure;

                if (aditionalStructureValue.SelectedValue == null || (aditionalStructureValue.SelectedValue.Text2 == "" && aditionalStructureValue.SelectedValue.Text1 == ""))
                {


                }
                else
                {
                    if (aditionalStructureValue.SelectedValue.HasSize || aditionalStructureValue.HasDoubleSize)
                    {
                        if (aditionalStructureValue.HasDoubleSize)
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + "*" + aditionalStructureValue.CurrentEntry.Size2 + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.CurrentEntry.Size + aditionalStructureValue.SelectedValue.Metrics + ". " + aditionalStructureValue.SelectedValue.Text2 + "");


                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(aditionalStructureValue.CurrentEntry.Comment))
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + " \nКомментарий : \"" + aditionalStructureValue.CurrentEntry.Comment + "\"");
                        }
                        else
                        {
                            bufBpvLeftStr.Add(aditionalStructureValue.SelectedValue.Text1 + " " + aditionalStructureValue.SelectedValue.Text2 + "");

                        }

                    }

                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }
                //    name = "БПВНБ";

                //  continue;
            }
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
                            if (!string.IsNullOrWhiteSpace(sender.LegSections[i].CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + "*" + sender.LegSections[i].CurrentEntry.Size2 + sender.LegSections[i].SelectedValue.Metrics + ". " + sender.LegSections[i].SelectedValue.Text2 + " \nКомментарий : \"" + sender.LegSections[i].CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + "*" + sender.LegSections[i].CurrentEntry.Size2 + sender.LegSections[i].SelectedValue.Metrics + ". " + sender.LegSections[i].SelectedValue.Text2 + "");

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(sender.LegSections[i].CurrentEntry.Comment))
                            {
                                bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + sender.LegSections[i].SelectedValue.Metrics + ". " + sender.LegSections[i].SelectedValue.Text2 + " \nКомментарий : \"" + sender.LegSections[i].CurrentEntry.Comment + "\"");
                            }
                            else
                            {
                                bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].CurrentEntry.Size + sender.LegSections[i].SelectedValue.Metrics + ". " + sender.LegSections[i].SelectedValue.Text2 + "");


                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(sender.LegSections[i].CurrentEntry.Comment))
                        {
                            bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].SelectedValue.Text2 + " \nКомментарий : \"" + sender.LegSections[i].CurrentEntry.Comment + "\"");
                        }
                        else
                        {
                            bufBpvLeftStr.Add(sender.LegSections[i].SelectedValue.Text1 + " " + sender.LegSections[i].SelectedValue.Text2 + "");

                        }

                    }

                    IsVisibleBPVleftbuf.Add(Visibility.Visible);
                }

            }
            string name = "";
            if (!string.IsNullOrWhiteSpace(sender.Comment) && bufBpvLeftStr.Count != 0)
            {
                if (sender is PDSVViewModel)
                {


                    name = "ПДСВ";


                }
                else if (sender is SFSViewModel)
                {


                    name = "СФС";


                }
                else if (sender is BPVHipViewModel)
                {

                    name = "БПВНБ";


                }
                else if (sender is BPVTibiaViewModel)
                {

                    name = "БПВНГ";


                }
                else if (sender is HipPerforateViewModel)
                {


                    name = "ПБИНВ";


                }
                else if (sender is ZDSVViewModel)
                {

                    name = "ЗДСВ";

                }

                else if (sender is SPSViewModel)
                {
                    name = "СПС";

                }
                else if (sender is TibiaPerforateViewModel)
                {

                    name = "ПГ";

                }
                else if (sender is MPVViewModel)
                {

                    name = "МПВ";


                }
                else if (sender is TEMPVViewModel)
                {
                    name = "ТЕМПВ";

                }
                else if (sender is PPVViewModel)
                {

                    name = "ППВ";


                }
                else if (sender is GVViewModel)
                {

                    name = "ГВ";

                }

                bufBpvLeftStr[bufBpvLeftStr.Count - 1] += "\nКомментарий к " + name + " : " + sender.Comment + "";
            }


            //bufBpvLeftStr += sender.Comment;
            SaveSet result = new SaveSet(bufBpvLeftStr, IsVisibleBPVleftbuf);
            return result;

        }

        public string mode;
        private bool isDelayStarted = false;
        private void Clear(object sender, object data)
        {
            TextOfEndBtn = "Завершить обследование";
            //   Controller.ClearLegPartVM();
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
            RecomendationsList = new ObservableCollection<RecomendationsDataSource>();
            ComplainsList = new ObservableCollection<ComplainsDataSource>();

            RightCEAR.LegSections = new List<LettersSectionViewModel>();
            LeftCEAR.LegSections = new List<LettersSectionViewModel>();
            LeftCEAR.Comment = "";
            RightCEAR.Comment = "";
            LeftCEAR.IsEmpty = true;
            RightCEAR.IsEmpty = true;
            for (int i = 0; i < RightCEAR.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightCEAR.LegSections.Add(new LettersSectionViewModel(Controller, RightCEAR.LegSections[i - 1]));

                }
                else
                {
                    RightCEAR.LegSections.Add(new LettersSectionViewModel(Controller, null));
                }
                RightCEAR.LegSections[i].IsVisible = Visibility.Visible;

                if (i == 0)
                {
                    RightCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "C").ToList());
                    RightCEAR.LegSections[i].ListNumber = "C";
                }
                else if (i == 1)
                {
                    RightCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "E").ToList());
                    RightCEAR.LegSections[i].ListNumber = "E";
                }
                else if (i == 2)
                {
                    RightCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "A").ToList());
                    RightCEAR.LegSections[i].ListNumber = "A";
                }
                else if (i == 3)
                {
                    RightCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "P").ToList());
                    RightCEAR.LegSections[i].ListNumber = "P";
                }
                Letters emptyLetter = new Letters();
                emptyLetter.Id = 0;
                emptyLetter.Text1 = "";
                emptyLetter.Leter = "";
                RightCEAR.LegSections[i].StructureSource.Add(emptyLetter);
            }



            for (int i = 0; i < LeftCEAR.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftCEAR.LegSections.Add(new LettersSectionViewModel(Controller, LeftCEAR.LegSections[i - 1]));

                }
                else
                {
                    LeftCEAR.LegSections.Add(new LettersSectionViewModel(Controller, null));
                }
                LeftCEAR.LegSections[i].IsVisible = Visibility.Visible;

                if (i == 0)
                {
                    LeftCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "C").ToList());
                    LeftCEAR.LegSections[i].ListNumber = "C";
                }
                else if (i == 1)
                {
                    LeftCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "E").ToList());
                    LeftCEAR.LegSections[i].ListNumber = "E";
                }
                else if (i == 2)
                {
                    LeftCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "A").ToList());
                    LeftCEAR.LegSections[i].ListNumber = "A";
                }
                else if (i == 3)
                {
                    LeftCEAR.LegSections[i].StructureSource = new ObservableCollection<Letters>(Data.Letters.GetAll.ToList().Where(x => x.Leter == "P").ToList());
                    LeftCEAR.LegSections[i].ListNumber = "P";
                }
                Letters emptyLetter = new Letters();
                emptyLetter.Id = 0;
                emptyLetter.Text1 = "";
                emptyLetter.Leter = "";
                LeftCEAR.LegSections[i].StructureSource.Add(emptyLetter);
            }


            LeftTEMPV.Comment = "";


            LeftTEMPV.FF_length = 0;
            LeftTEMPV.IsEmpty = true;
            LeftTEMPV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftTEMPV.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftTEMPV.LegSections.Add(new TEMPVSectionViewModel(Controller, LeftTEMPV.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftTEMPV.LegSections.Add(new TEMPVSectionViewModel(Controller, null, i + 1));
                }
            }
            RightTEMPV.FF_length = 0;
            RightTEMPV.IsEmpty = true;
            RightTEMPV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftTEMPV.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightTEMPV.LegSections.Add(new TEMPVSectionViewModel(Controller, RightTEMPV.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightTEMPV.LegSections.Add(new TEMPVSectionViewModel(Controller, null, i + 1));
                }
            }


            RightTEMPV.Comment = "";

            LeftMPV.Comment = "";
            LeftMPV.IsEmpty = true;
            LeftMPV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftMPV.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftMPV.LegSections.Add(new MPVSectionViewModel(Controller, LeftMPV.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftMPV.LegSections.Add(new MPVSectionViewModel(Controller, null, i + 1));
                }
            }
            RightMPV.Comment = "";
            RightMPV.IsEmpty = true;
            RightMPV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftMPV.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightMPV.LegSections.Add(new MPVSectionViewModel(Controller, RightMPV.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightMPV.LegSections.Add(new MPVSectionViewModel(Controller, null, i + 1));
                }
            }
            LeftZDSV.AdditionalStructure = new ZDSVAdditionalSectionViewModel(Controller, null, 0);
            LeftZDSV.Comment = "";
            LeftZDSV.IsEmpty = true;
            LeftZDSV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftZDSV.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftZDSV.LegSections.Add(new ZDSVSectionViewModel(Controller, LeftZDSV.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftZDSV.LegSections.Add(new ZDSVSectionViewModel(Controller, null, i + 1));
                }
            }
            RightZDSV.AdditionalStructure = new ZDSVAdditionalSectionViewModel(Controller, null, 0);
            RightZDSV.Comment = "";
            RightZDSV.IsEmpty = true;
            RightZDSV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftZDSV.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightZDSV.LegSections.Add(new ZDSVSectionViewModel(Controller, RightZDSV.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightZDSV.LegSections.Add(new ZDSVSectionViewModel(Controller, null, i + 1));
                }
            }


            LeftTibiaPerforate.Comment = "";
            LeftTibiaPerforate.IsEmpty = true;
            LeftTibiaPerforate.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftTibiaPerforate.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftTibiaPerforate.LegSections.Add(new TibiaPerforateSectionViewModel(Controller, LeftTibiaPerforate.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftTibiaPerforate.LegSections.Add(new TibiaPerforateSectionViewModel(Controller, null, i + 1));
                }
            }
            RightTibiaPerforate.Comment = "";
            RightTibiaPerforate.IsEmpty = true;
            RightTibiaPerforate.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftTibiaPerforate.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightTibiaPerforate.LegSections.Add(new TibiaPerforateSectionViewModel(Controller, RightTibiaPerforate.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightTibiaPerforate.LegSections.Add(new TibiaPerforateSectionViewModel(Controller, null, i + 1));
                }
            }



            LeftSPS.Comment = "";
            LeftSPS.IsEmpty = true;
            LeftSPS.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftSPS.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftSPS.LegSections.Add(new SPSSectionViewModel(Controller, LeftSPS.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftSPS.LegSections.Add(new SPSSectionViewModel(Controller, null, i + 1));
                }
            }
            RightSPS.Comment = "";
            RightSPS.IsEmpty = true;
            RightSPS.AdditionalStructure = new SPSAdditionalSectionViewModel(Controller, null, 0);
            RightSPS.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftSPS.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightSPS.LegSections.Add(new SPSSectionViewModel(Controller, RightSPS.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightSPS.LegSections.Add(new SPSSectionViewModel(Controller, null, i + 1));
                }
            }


            LeftSFS.Comment = "";
            LeftSFS.IsEmpty = true;
            LeftSPS.AdditionalStructure = new SPSAdditionalSectionViewModel(Controller, null, 0);
            LeftSFS.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftSFS.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftSFS.LegSections.Add(new SFSSectionViewModel(Controller, LeftSFS.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftSFS.LegSections.Add(new SFSSectionViewModel(Controller, null, i + 1));
                }
            }
            RightSFS.Comment = "";
            RightSFS.IsEmpty = true;
            RightSFS.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftSFS.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightSFS.LegSections.Add(new SFSSectionViewModel(Controller, RightSFS.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightSFS.LegSections.Add(new SFSSectionViewModel(Controller, null, i + 1));
                }
            }

            LeftPDSV.Comment = "";

            LeftPDSV.IsEmpty = true;
            LeftPDSV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftPDSV.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftPDSV.LegSections.Add(new PDSVSectionViewModel(Controller, LeftPDSV.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftPDSV.LegSections.Add(new PDSVSectionViewModel(Controller, null, i + 1));
                }
            }
            LeftPDSV.AdditionalStructure = new PDSVAdditionalSectionViewModel(Controller, null, 0);
            RightPDSV.Comment = "";
            RightPDSV.IsEmpty = true;
            RightPDSV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftPDSV.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightPDSV.LegSections.Add(new PDSVSectionViewModel(Controller, RightPDSV.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightPDSV.LegSections.Add(new PDSVSectionViewModel(Controller, null, i + 1));
                }
            }
            RightPDSV.AdditionalStructure = new PDSVAdditionalSectionViewModel(Controller, null, 0);

            LeftGV.Comment = "";
            LeftGV.IsEmpty = true;
            LeftGV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftGV.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftGV.LegSections.Add(new GVSectionViewModel(Controller, LeftGV.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftGV.LegSections.Add(new GVSectionViewModel(Controller, null, i + 1));
                }
            }
            RightGV.Comment = "";
            RightGV.IsEmpty = true;
            RightGV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftGV.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightGV.LegSections.Add(new GVSectionViewModel(Controller, RightGV.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightGV.LegSections.Add(new GVSectionViewModel(Controller, null, i + 1));
                }
            }


            LeftPPV.Comment = "";


            LeftPPV.IsEmpty = true;
            LeftPPV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftPPV.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftPPV.LegSections.Add(new PPVSectionViewModel(Controller, LeftPPV.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftPPV.LegSections.Add(new PPVSectionViewModel(Controller, null, i + 1));
                }
            }
            RightPPV.Comment = "";
            RightPPV.IsEmpty = true;
            RightPPV.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftPPV.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightPPV.LegSections.Add(new PPVSectionViewModel(Controller, RightPPV.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightPPV.LegSections.Add(new PPVSectionViewModel(Controller, null, i + 1));
                }
            }



            LeftPerforate.Comment = "";
            LeftPerforate.IsEmpty = true;
            LeftPerforate.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftPerforate.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftPerforate.LegSections.Add(new HipPerforateSectionViewModel(Controller, LeftPerforate.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftPerforate.LegSections.Add(new HipPerforateSectionViewModel(Controller, null, i + 1));
                }
            }
            RightPerforate.Comment = "";
            RightPerforate.IsEmpty = true;
            RightPerforate.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftPerforate.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightPerforate.LegSections.Add(new HipPerforateSectionViewModel(Controller, RightPerforate.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightPerforate.LegSections.Add(new HipPerforateSectionViewModel(Controller, null, i + 1));
                }
            }


            LeftBPVTibia.Comment = "";

            LeftBPVTibia.IsEmpty = true;
            LeftBPVTibia.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftBPVTibia.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftBPVTibia.LegSections.Add(new BPVTibiaSectionViewModel(Controller, LeftBPVTibia.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftBPVTibia.LegSections.Add(new BPVTibiaSectionViewModel(Controller, null, i + 1));
                }
            }
            RightBPVTibia.Comment = "";
            RightBPVTibia.IsEmpty = true;
            RightBPVTibia.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftBPVTibia.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightBPVTibia.LegSections.Add(new BPVTibiaSectionViewModel(Controller, RightBPVTibia.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightBPVTibia.LegSections.Add(new BPVTibiaSectionViewModel(Controller, null, i + 1));
                }
            }





            LeftBPVHip.Comment = "";
            LeftBPVHip.IsEmpty = true;
            LeftBPVHip.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftBPVHip.LevelCount; i++)
            {
                if (i != 0)
                {
                    LeftBPVHip.LegSections.Add(new BPVHipSectionViewModel(Controller, LeftBPVHip.LegSections[i - 1], i + 1));
                }
                else
                {
                    LeftBPVHip.LegSections.Add(new BPVHipSectionViewModel(Controller, null, i + 1));
                }
            }
            LeftBPVHip.AdditionalStructure = new BPVHipAdditionalSectionViewModel(Controller, null, 0);
            RightBPVHip.Comment = "";
            RightBPVHip.IsEmpty = true;
            RightBPVHip.LegSections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LeftBPVHip.LevelCount; i++)
            {
                if (i != 0)
                {
                    RightBPVHip.LegSections.Add(new BPVHipSectionViewModel(Controller, RightBPVHip.LegSections[i - 1], i + 1));
                }
                else
                {
                    RightBPVHip.LegSections.Add(new BPVHipSectionViewModel(Controller, null, i + 1));
                }
            }
            RightBPVHip.AdditionalStructure = new BPVHipAdditionalSectionViewModel(Controller, null, 0);
            LeftAdditionalText = "";
            RightAdditionalText = "";
            statementOverviewId = 0;
            hirurgOverviewId = 0;
            SetAllBordersDefault();

            testThread = true;
            var acc = Data.Accaunt.Get(Acc_id);
            if (!isDelayStarted && (acc.isSecretar == null || !acc.isSecretar.Value))
            {
                DelayTest();
            }

            isEdited = false;
        }

        private bool testThread = false;
        private void RemoveAllSaves()
        {

            foreach (var x in Data.SavedExamination.GetAll.Where(e => e.acc_id == Acc_id))
            {

                foreach (var y in Data.SavedExaminationLeg.GetAll.Where(e => e.Id == x.idLeftLegExamination || e.Id == x.idRightLegExamination))
                {
                    y.A = null;
                    y.additionalText = "";

                    y.BPVHip = null;
                    y.BPVTibiaid = null;
                    y.C = null;
                    y.E = null;
                    y.GVid = null;
                    y.MPVid = null;
                    y.P = null;
                    y.PDSVid = null;
                    y.PerforateHipid = null;
                    y.PPVid = null;
                    y.SFSid = null;
                    y.SPSid = null;
                    y.TEMPVid = null;
                    y.TibiaPerforateid = null;
                    y.ZDSVid = null;
                }
                foreach (var y in Data.SavedComplanesObs.GetAll.Where(e => e.id_Examination == x.Id))
                {
                    Data.SavedComplanesObs.Remove(y);
                }
                foreach (var y in Data.SavedDiagnosisObs.GetAll.Where(e => e.id_leg_examination == x.Id))
                {
                    Data.SavedDiagnosisObs.Remove(y);
                }
                foreach (var y in Data.SavedRecomendationObs.GetAll.Where(e => e.id_examination == x.Id))
                {
                    Data.SavedRecomendationObs.Remove(y);
                }
                x.height = 0;
                x.weight = 0;
                x.Comment = "";
                x.Date = null;
                x.DoctorID = null;
                x.hirurgOverviewId = null;
                x.isNeedOperation = null;
                x.NB = "";
                x.OperationType = null;
                x.PatientId = null;
                x.statementOverviewId = null;
                x.id_current_examination = null;


            }

        }
        private LegPartEntries SaveForSavedProc(ref SavedExaminationLeg LegExam, ref SavedExamination Exam, LegPartViewModel Part, LegPartEntries FullEntry, bool isLeft, int obsid)
        {



            //SavedExamination Exam = Data.SavedExamination.Get(obsid);
            //SavedExaminationLeg LegExam = new SavedExaminationLeg();
            //if (Exam == null || LegExam == null)
            //    return FullEntry;
            //if (isLeft)
            //{
            //    LegExam = Data.SavedExaminationLeg.Get(Exam.idLeftLegExamination.Value);
            //}
            //else
            //{
            //    LegExam = Data.SavedExaminationLeg.Get(Exam.idRightLegExamination.Value);
            //}

            LegPartEntries LeftSFSEntryFullbuf = FullEntry;

            if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
            {
                LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
            }

            if (Part is PDSVViewModel && LegExam.PDSVid != null)
            {

                PDSVHipEntry EntToChange = new PDSVHipEntry();
                PDSVHipEntryFull EntFullToChange = Data.PDSVFull.Get(LegExam.PDSVid.Value);
                LegPartEntry newSFSentry;
                bool test = true;
                var aditionalStructureValue = ((PDSVViewModel)(Part)).AdditionalStructure.SelectedValue;
                if (aditionalStructureValue == null || (aditionalStructureValue.Text2 == "" && aditionalStructureValue.Text1 == ""))
                {
                    test = false;
                    EntFullToChange.EntryId0 = null;

                }
                else
                {
                    newSFSentry = ((PDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((PDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                    if (EntFullToChange.EntryId0 == null)
                    {
                        test = false;
                        Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                        Data.Complete();
                        EntFullToChange.EntryId0 = newSFSentry.Id;
                        Data.Complete();
                    }
                    else
                    {
                        EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId0.Value);
                    }

                    LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                }
                if (test)
                {
                    newSFSentry = ((PDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((PDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    EntToChange.Comment = ((PDSVHipEntry)newSFSentry).Comment;
                    EntToChange.Size = ((PDSVHipEntry)newSFSentry).Size;
                    EntToChange.Size2 = ((PDSVHipEntry)newSFSentry).Size2;
                    EntToChange.StructureID = ((PDSVHipEntry)newSFSentry).StructureID;
                }
                //if (Part is PDSVViewModel)
                //{
                //    newSFSentry = ((PDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                //    newSFSentry.StructureID = ((PDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                //    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                //    Data.Complete();
                //}
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.PDSVFull.Remove(EntFullToChange);
                            LegExam.PDSVid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PDSVHipEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((PDSVHipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((PDSVHipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((PDSVHipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((PDSVHipEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is PDSVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                LegPartEntry newSFSentry;
                var aditionalStruct = ((PDSVViewModel)(Part)).AdditionalStructure;
                if (aditionalStruct.SelectedValue != null)
                {
                    if (aditionalStruct.SelectedValue.Text1 == "" && aditionalStruct.SelectedValue.Text2 == "")
                    { }
                    else
                    {
                        newSFSentry = ((PDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((PDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;



                        Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);

                        Data.Complete();
                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;
                        //Data.Complete();
                    }
                }


                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.PDSVHipEntries.Add((PDSVHipEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }










            if (Part is ZDSVViewModel && LegExam.ZDSVid != null)
            {

                ZDSVEntry EntToChange = new ZDSVEntry();
                ZDSVEntryFull EntFullToChange = Data.ZDSVFull.Get(LegExam.ZDSVid.Value);
                LegPartEntry newSFSentry;
                bool test = true;


                var aditionalStructureValue = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue;
                if (aditionalStructureValue == null || (aditionalStructureValue.Text2 == "" && aditionalStructureValue.Text1 == ""))
                {
                    test = false;
                    EntFullToChange.EntryId0 = null;

                }
                else
                {
                    newSFSentry = ((ZDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                    if (EntFullToChange.EntryId0 == null)
                    {
                        test = false;
                        Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                        Data.Complete();
                        EntFullToChange.EntryId0 = newSFSentry.Id;
                        Data.Complete();
                    }
                    else
                    {
                        EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId0.Value);
                    }

                    LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                }
                if (test)
                {
                    newSFSentry = ((ZDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    EntToChange.Comment = ((ZDSVEntry)newSFSentry).Comment;
                    EntToChange.Size = ((ZDSVEntry)newSFSentry).Size;
                    EntToChange.Size2 = ((ZDSVEntry)newSFSentry).Size2;
                    EntToChange.StructureID = ((ZDSVEntry)newSFSentry).StructureID;
                }
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.ZDSVFull.Remove(EntFullToChange);
                            LegExam.ZDSVid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.ZDSVEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((ZDSVEntry)newSFSentry).Comment;
                        EntToChange.Size = ((ZDSVEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((ZDSVEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((ZDSVEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is ZDSVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                LegPartEntry newSFSentry;




                var aditionalStruct = ((ZDSVViewModel)(Part)).AdditionalStructure;
                if (aditionalStruct.SelectedValue != null)
                {
                    if (aditionalStruct.SelectedValue.Text1 == "" && aditionalStruct.SelectedValue.Text2 == "")
                    {
                    }
                    else
                    {
                        //EntFullToChange.EntryId0 = null;

                        //}
                        //else
                        //{
                        newSFSentry = ((ZDSVViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((ZDSVViewModel)(Part)).AdditionalStructure.SelectedValue.Id;



                        Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);

                        Data.Complete();
                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;
                        //Data.Complete();
                    }
                }
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.ZDSVEntries.Add((ZDSVEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }




            if (Part is HipPerforateViewModel && LegExam.PerforateHipid != null)
            {

                Perforate_hipEntry EntToChange = new Perforate_hipEntry();
                Perforate_hipEntryFull EntFullToChange = Data.Perforate_hipFull.Get(LegExam.PerforateHipid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.Perforate_hipFull.Remove(EntFullToChange);
                            LegExam.PerforateHipid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_hipEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((Perforate_hipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((Perforate_hipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((Perforate_hipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((Perforate_hipEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is HipPerforateViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.Perforate_hipEntries.Add((Perforate_hipEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }


            if (Part is TibiaPerforateViewModel && LegExam.TibiaPerforateid != null)
            {

                Perforate_shinEntry EntToChange = new Perforate_shinEntry();
                Perforate_shinEntryFull EntFullToChange = Data.Perforate_shinFull.Get(LegExam.TibiaPerforateid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.Perforate_shinFull.Remove(EntFullToChange);
                            LegExam.TibiaPerforateid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.Perforate_shinEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((Perforate_shinEntry)newSFSentry).Comment;
                        EntToChange.Size = ((Perforate_shinEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((Perforate_shinEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((Perforate_shinEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is TibiaPerforateViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.Perforate_shinEntries.Add((Perforate_shinEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }


















            if (Part is BPVHipViewModel && LegExam.BPVHip != null)
            {

                BPVHipEntry EntToChange = new BPVHipEntry();
                BPVHipEntryFull EntFullToChange = Data.BPVHipsFull.Get(LegExam.BPVHip.Value);
                LegPartEntry newSFSentry;
                bool test = true;


                var aditionalStructureValue = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue;
                if (aditionalStructureValue == null || (aditionalStructureValue.Text2 == "" && aditionalStructureValue.Text1 == ""))
                {
                    test = false;
                    EntFullToChange.EntryId0 = null;

                }
                else
                {
                    newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                    if (EntFullToChange.EntryId0 == null)
                    {
                        test = false;
                        Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                        Data.Complete();
                        EntFullToChange.EntryId0 = newSFSentry.Id;
                        Data.Complete();
                    }
                    else
                    {
                        EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId0.Value);
                    }

                    LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                }
                if (test)
                {
                    newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    EntToChange.Comment = ((BPVHipEntry)newSFSentry).Comment;
                    EntToChange.Size = ((BPVHipEntry)newSFSentry).Size;
                    EntToChange.Size2 = ((BPVHipEntry)newSFSentry).Size2;
                    EntToChange.StructureID = ((BPVHipEntry)newSFSentry).StructureID;
                }


                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.BPVHipsFull.Remove(EntFullToChange);
                            LegExam.BPVHip = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }

                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPVHipEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((BPVHipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((BPVHipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((BPVHipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((BPVHipEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is BPVHipViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {

                LegPartEntry newSFSentry;




                var aditionalStruct = ((BPVHipViewModel)(Part)).AdditionalStructure;
                if (aditionalStruct.SelectedValue != null)
                {
                    if (aditionalStruct.SelectedValue.Text1 == "" && aditionalStruct.SelectedValue.Text2 == "")
                    {
                    }
                    else
                    {
                        //EntFullToChange.EntryId0 = null;

                        //}
                        //else
                        //{
                        newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;



                        Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);

                        Data.Complete();
                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;
                        //Data.Complete();
                    }
                }
                //if (test)
                //{
                //    newSFSentry = ((BPVHipViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                //    newSFSentry.StructureID = ((BPVHipViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                //    EntToChange.Comment = ((BPVHipEntry)newSFSentry).Comment;
                //    EntToChange.Size = ((BPVHipEntry)newSFSentry).Size;
                //    EntToChange.Size2 = ((BPVHipEntry)newSFSentry).Size2;
                //    EntToChange.StructureID = ((BPVHipEntry)newSFSentry).StructureID;
                //}


                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.BPVHipEntries.Add((BPVHipEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }









            if (Part is SFSViewModel && LegExam.SFSid != null)
            {

                SFSHipEntry EntToChange = new SFSHipEntry();
                SFSHipEntryFull EntFullToChange = Data.SFSFull.Get(LegExam.SFSid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.SFSFull.Remove(EntFullToChange);
                            LegExam.SFSid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SFSHipEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((SFSHipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((SFSHipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((SFSHipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((SFSHipEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is SFSViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.SFSHipEntries.Add((SFSHipEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }
















            if (Part is BPVTibiaViewModel && LegExam.BPVTibiaid != null)
            {

                BPV_TibiaEntry EntToChange = new BPV_TibiaEntry();
                BPV_TibiaEntryFull EntFullToChange = Data.BPV_TibiaFull.Get(LegExam.BPVTibiaid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.BPV_TibiaFull.Remove(EntFullToChange);
                            LegExam.BPVTibiaid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.BPV_TibiaEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((BPV_TibiaEntry)newSFSentry).Comment;
                        EntToChange.Size = ((BPV_TibiaEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((BPV_TibiaEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((BPV_TibiaEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is BPVTibiaViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.BPV_TibiaEntries.Add((BPV_TibiaEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }










            if (Part is SPSViewModel && LegExam.SPSid != null)
            {

                SPSHipEntry EntToChange = new SPSHipEntry();
                SPSHipEntryFull EntFullToChange = Data.SPSHipFull.Get(LegExam.SPSid.Value);
                LegPartEntry newSFSentry;
                bool test = true;


                var aditionalStructureValue = ((SPSViewModel)(Part)).AdditionalStructure.SelectedValue;
                if (aditionalStructureValue == null || (aditionalStructureValue.Text2 == "" && aditionalStructureValue.Text1 == ""))
                {
                    test = false;
                    EntFullToChange.EntryId0 = null;

                }
                else
                {
                    newSFSentry = ((SPSViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((SPSViewModel)(Part)).AdditionalStructure.SelectedValue.Id;

                    if (EntFullToChange.EntryId0 == null)
                    {
                        test = false;
                        Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                        Data.Complete();
                        EntFullToChange.EntryId0 = newSFSentry.Id;
                        Data.Complete();
                    }
                    else
                    {
                        EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId0.Value);
                    }

                    LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;

                }
                if (test)
                {
                    newSFSentry = ((SPSViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                    newSFSentry.StructureID = ((SPSViewModel)(Part)).AdditionalStructure.SelectedValue.Id;
                    EntToChange.Comment = ((SPSHipEntry)newSFSentry).Comment;
                    EntToChange.Size = ((SPSHipEntry)newSFSentry).Size;
                    EntToChange.Size2 = ((SPSHipEntry)newSFSentry).Size2;
                    EntToChange.StructureID = ((SPSHipEntry)newSFSentry).StructureID;
                }
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.SPSHipFull.Remove(EntFullToChange);
                            LegExam.SPSid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.SPSEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((SPSHipEntry)newSFSentry).Comment;
                        EntToChange.Size = ((SPSHipEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((SPSHipEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((SPSHipEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is SPSViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {


                LegPartEntry newSFSentry;




                var aditionalStruct = ((SPSViewModel)(Part)).AdditionalStructure;
                if (aditionalStruct.SelectedValue != null)
                {
                    if (aditionalStruct.SelectedValue.Text1 == "" && aditionalStruct.SelectedValue.Text2 == "")
                    {
                    }
                    else
                    {

                        //EntFullToChange.EntryId0 = null;

                        //}
                        //else
                        //{
                        newSFSentry = ((SPSViewModel)(Part)).AdditionalStructure.CurrentEntry as LegPartEntry;
                        newSFSentry.StructureID = ((SPSViewModel)(Part)).AdditionalStructure.SelectedValue.Id;



                        Data.SPSEntries.Add((SPSHipEntry)newSFSentry);

                        Data.Complete();
                        LeftSFSEntryFullbuf.EntryId0 = newSFSentry.Id;
                        //Data.Complete();

                    }
                }
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.SPSEntries.Add((SPSHipEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }










            if (Part is MPVViewModel && LegExam.MPVid != null)
            {

                MPVEntry EntToChange = new MPVEntry();
                MPVEntryFull EntFullToChange = Data.MPVFull.Get(LegExam.MPVid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.MPVFull.Remove(EntFullToChange);
                            LegExam.MPVid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.MPVEntries.Add((MPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.MPVEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((MPVEntry)newSFSentry).Comment;
                        EntToChange.Size = ((MPVEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((MPVEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((MPVEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is MPVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.MPVEntries.Add((MPVEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }


            if (Part is TEMPVViewModel && LegExam.TEMPVid != null)
            {

                TEMPVEntry EntToChange = new TEMPVEntry();
                TEMPVEntryFull EntFullToChange = Data.TEMPVFull.Get(LegExam.TEMPVid.Value);
                EntFullToChange.FF_Length = Part.FF_length;
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.TEMPVFull.Remove(EntFullToChange);
                            LegExam.TEMPVid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.TEMPVEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((TEMPVEntry)newSFSentry).Comment;
                        EntToChange.Size = ((TEMPVEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((TEMPVEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((TEMPVEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is TEMPVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.TEMPVEntries.Add((TEMPVEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }




            if (Part is PPVViewModel && LegExam.PPVid != null)
            {

                PPVEntry EntToChange = new PPVEntry();
                PPVEntryFull EntFullToChange = Data.PPVFull.Get(LegExam.PPVid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.PPVFull.Remove(EntFullToChange);
                            LegExam.PPVid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.PPVEntries.Add((PPVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.PPVEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((PPVEntry)newSFSentry).Comment;
                        EntToChange.Size = ((PPVEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((PPVEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((PPVEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is PPVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.PPVEntries.Add((PPVEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }



            if (Part is GVViewModel && LegExam.GVid != null)
            {

                GVEntry EntToChange = new GVEntry();
                GVEntryFull EntFullToChange = Data.GVFull.Get(LegExam.GVid.Value);
                for (int i = 0; i < Part.LegSections.Count; ++i)
                {
                    if (Part.LegSections[i].SelectedValue != null && Part.LegSections[i].SelectedValue.ToNextPart)
                    { break; }

                    LegPartEntry newSFSentry = Part.LegSections[i].CurrentEntry;

                    if (Part.LegSections[i].SelectedValue != null)
                    {
                        newSFSentry.StructureID = Part.LegSections[i].SelectedValue.Id;
                    }
                    bool test = true;
                    if (i == 0)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            Data.GVFull.Remove(EntFullToChange);
                            LegExam.GVid = null;
                            Data.Complete();
                            break;
                        }
                        else
                        {

                            EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId1);
                            LeftSFSEntryFullbuf.EntryId1 = newSFSentry.Id;

                        }

                    }
                    else if (i == 1)
                    {

                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId2 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId2 == null)
                            {
                                test = false;
                                Data.GVEntries.Add((GVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId2 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId2.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId2 = newSFSentry.Id;

                        }
                    }
                    else if (i == 2)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId3 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId3 == null)
                            {
                                test = false;
                                Data.GVEntries.Add((GVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId3 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId3.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId3 = newSFSentry.Id;
                        }
                    }
                    else if (i == 3)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId4 = null;

                        }
                        else
                        {
                            if (EntFullToChange.EntryId4 == null)
                            {
                                test = false;
                                Data.GVEntries.Add((GVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId4 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId4.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId4 = newSFSentry.Id;
                        }
                    }
                    else if (i == 4)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId5 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId5 == null)
                            {
                                test = false;
                                Data.GVEntries.Add((GVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId5 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId5.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId5 = newSFSentry.Id;
                        }
                    }
                    else if (i == 5)
                    {
                        if (Part.LegSections[i].SelectedValue == null)
                        {
                            test = false;
                            EntFullToChange.EntryId6 = null;
                        }
                        else
                        {
                            if (EntFullToChange.EntryId6 == null)
                            {
                                test = false;
                                Data.GVEntries.Add((GVEntry)newSFSentry);
                                Data.Complete();
                                EntFullToChange.EntryId6 = newSFSentry.Id;
                                Data.Complete();
                            }
                            else
                            {
                                EntToChange = Data.GVEntries.Get(EntFullToChange.EntryId6.Value);
                            }

                            LeftSFSEntryFullbuf.EntryId6 = newSFSentry.Id;
                        }
                    }

                    if (test)
                    {
                        EntToChange.Comment = ((GVEntry)newSFSentry).Comment;
                        EntToChange.Size = ((GVEntry)newSFSentry).Size;
                        EntToChange.Size2 = ((GVEntry)newSFSentry).Size2;
                        EntToChange.StructureID = ((GVEntry)newSFSentry).StructureID;
                    }


                    Data.Complete();



                }
            }
            else if (Part is GVViewModel && Part != null && Part.LegSections != null && Part.LegSections[0].SelectedValue != null)
            {
                foreach (var section in Part.LegSections)
                {
                    if (section.SelectedValue == null || section.SelectedValue.ToNextPart)
                    { break; }
                    LegPartEntry newSFSentry = section.CurrentEntry;
                    newSFSentry.StructureID = section.SelectedValue.Id;

                    Data.GVEntries.Add((GVEntry)newSFSentry);
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


                if (Part.SelectedWayType != null && !string.IsNullOrWhiteSpace(Part.SelectedWayType.Name))
                {
                    LeftSFSEntryFullbuf.WayID = Part.SelectedWayType.Id;
                }

            }
            return FullEntry;

        }
        private async void DelayTest()
        {
            isDelayStarted = true;
            //textBox1.Text += "\r\nThread Sleeps!";
            for (; ; )
            {
                if (testThread)
                {
                    await Task.Delay(16000);
                    if (!testThread)
                    {
                        isDelayStarted = false; return;
                    }
                    //RemoveAllSaves();
                    SaveExaminationToSavedTable();
                    //SavedExamination examnTotal = new SavedExamination();
                    //SavedExaminationLeg leftLegExams = new SavedExaminationLeg();
                    //SavedExaminationLeg rightLegExams = new SavedExaminationLeg();
                    //examnTotal.hirurgOverviewId = hirurgOverviewId;
                    //examnTotal.statementOverviewId = statementOverviewId;




                    //ExaminationRepository ExamRep = new ExaminationRepository(context);
                    //ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);


                }
                else
                {
                    isDelayStarted = false; return;
                }
            }
        }

        private int Acc_id = 0;
        private void SaveExaminationToSavedTable()
        {

            /*  */
            var savedExam = Data.SavedExamination.GetAll.Where(e => e.acc_id == Acc_id).ToList();
            SavedExamination examnTotal;
            SavedExaminationLeg LegExamL;
            SavedExaminationLeg LegExamR;
            if (savedExam.Count != 0)
            {
                examnTotal = savedExam[0];
                LegExamL = Data.SavedExaminationLeg.Get(examnTotal.idLeftLegExamination.Value);
                LegExamR = Data.SavedExaminationLeg.Get(examnTotal.idRightLegExamination.Value);
            }
            else
            {
                LegExamL = new SavedExaminationLeg();
                LegExamR = new SavedExaminationLeg();
                Data.SavedExaminationLeg.Add(LegExamL);
                Data.SavedExaminationLeg.Add(LegExamR);
                Data.Complete();
                examnTotal = new SavedExamination();
                examnTotal.idLeftLegExamination = LegExamL.Id;
                examnTotal.idRightLegExamination = LegExamR.Id;
                examnTotal.height = 0;
                examnTotal.weight = 0;
                examnTotal.Comment = "";
                examnTotal.Date = null;
                examnTotal.DoctorID = null;
                examnTotal.hirurgOverviewId = null;
                examnTotal.isNeedOperation = null;
                examnTotal.NB = "";
                examnTotal.OperationType = null;
                examnTotal.PatientId = null;
                examnTotal.statementOverviewId = null;
                examnTotal.id_current_examination = null;
                examnTotal.statementOverviewId = statementOverviewId;
                examnTotal.hirurgOverviewId = hirurgOverviewId;
                examnTotal.acc_id = Acc_id;
                Data.SavedExamination.Add(examnTotal);
                Data.Complete();
            }
            //examnTotal = Data.SavedExamination.GetAll.FirstOrDefault();
            //LegExamL = Data.SavedExaminationLeg.Get(examnTotal.idLeftLegExamination.Value);
            //LegExamR = Data.SavedExaminationLeg.Get(examnTotal.idRightLegExamination.Value);
            examnTotal.statementOverviewId = statementOverviewId;
            examnTotal.hirurgOverviewId = hirurgOverviewId;
            examnTotal.acc_id = Acc_id;
            if (mode == "EDIT")
            {
                examnTotal.id_current_examination = obsid;

                Examination savedExamnTotal = Data.Examination.Get(obsid);
                ExaminationLeg savedLegExamL = Data.ExaminationLeg.Get(savedExamnTotal.idLeftLegExamination.Value);
                ExaminationLeg savedLegExamR = Data.ExaminationLeg.Get(savedExamnTotal.idRightLegExamination.Value);


                examnTotal.height = savedExamnTotal.height;
                examnTotal.weight = savedExamnTotal.weight;
                // examnTotal.Comment = savedExamnTotal.Comment;
                examnTotal.Date = savedExamnTotal.Date;
                examnTotal.DoctorID = savedExamnTotal.DoctorID;
                examnTotal.hirurgOverviewId = savedExamnTotal.hirurgOverviewId;
                examnTotal.NB = savedExamnTotal.NB;
                // examnTotal.OperationType = savedExamnTotal.OperationType;
                examnTotal.PatientId = savedExamnTotal.PatientId;
                examnTotal.statementOverviewId = savedExamnTotal.statementOverviewId;

                if (LegExamL.A == null)
                {
                    LegExamL.A = savedLegExamL.A;
                }

                if (LegExamL.additionalText == null)
                {
                    LegExamL.additionalText = savedLegExamL.additionalText;
                }

                if (LegExamL.BPVHip == null)
                {
                    LegExamL.BPVHip = savedLegExamL.BPVHip;
                }

                if (LegExamL.BPVTibiaid == null)
                {
                    LegExamL.BPVTibiaid = savedLegExamL.BPVTibiaid;
                }

                if (LegExamL.C == null)
                {
                    LegExamL.C = savedLegExamL.C;
                }

                if (LegExamL.E == null)
                {
                    LegExamL.E = savedLegExamL.E;
                }

                if (LegExamL.GVid == null)
                {
                    LegExamL.GVid = savedLegExamL.GVid;
                }

                if (LegExamL.MPVid == null)
                {
                    LegExamL.MPVid = savedLegExamL.MPVid;
                }

                if (LegExamL.P == null)
                {
                    LegExamL.P = savedLegExamL.P;
                }

                if (LegExamL.PDSVid == null)
                {
                    LegExamL.PDSVid = savedLegExamL.PDSVid;
                }

                if (LegExamL.PerforateHipid == null)
                {
                    LegExamL.PerforateHipid = savedLegExamL.PerforateHipid;
                }

                if (LegExamL.PPVid == null)
                {
                    LegExamL.PPVid = savedLegExamL.PPVid;
                }

                if (LegExamL.SFSid == null)
                {
                    LegExamL.SFSid = savedLegExamL.SFSid;
                }

                if (LegExamL.SPSid == null)
                {
                    LegExamL.SPSid = savedLegExamL.SPSid;
                }

                if (LegExamL.TEMPVid == null)
                {
                    LegExamL.TEMPVid = savedLegExamL.TEMPVid;
                }

                if (LegExamL.TibiaPerforateid == null)
                {
                    LegExamL.TibiaPerforateid = savedLegExamL.TibiaPerforateid;
                }

                if (LegExamL.ZDSVid == null)
                {
                    LegExamL.ZDSVid = savedLegExamL.ZDSVid;
                }

                if (LegExamR.A == null)
                {
                    LegExamR.A = savedLegExamR.A;
                }

                if (LegExamR.additionalText == null)
                {
                    LegExamR.additionalText = savedLegExamR.additionalText;
                }

                if (LegExamR.BPVHip == null)
                {
                    LegExamR.BPVHip = savedLegExamR.BPVHip;
                }

                if (LegExamR.BPVTibiaid == null)
                {
                    LegExamR.BPVTibiaid = savedLegExamR.BPVTibiaid;
                }

                if (LegExamR.C == null)
                {
                    LegExamR.C = savedLegExamR.C;
                }

                if (LegExamR.E == null)
                {
                    LegExamR.E = savedLegExamR.E;
                }

                if (LegExamR.GVid == null)
                {
                    LegExamR.GVid = savedLegExamR.GVid;
                }

                if (LegExamR.MPVid == null)
                {
                    LegExamR.MPVid = savedLegExamR.MPVid;
                }

                if (LegExamR.P == null)
                {
                    LegExamR.P = savedLegExamR.P;
                }

                if (LegExamR.PDSVid == null)
                {
                    LegExamR.PDSVid = savedLegExamR.PDSVid;
                }

                if (LegExamR.PerforateHipid == null)
                {
                    LegExamR.PerforateHipid = savedLegExamR.PerforateHipid;
                }

                if (LegExamR.PPVid == null)
                {
                    LegExamR.PPVid = savedLegExamR.PPVid;
                }

                if (LegExamR.SFSid == null)
                {
                    LegExamR.SFSid = savedLegExamR.SFSid;
                }

                if (LegExamR.SPSid == null)
                {
                    LegExamR.SPSid = savedLegExamR.SPSid;
                }

                if (LegExamR.TEMPVid == null)
                {
                    LegExamR.TEMPVid = savedLegExamR.TEMPVid;
                }

                if (LegExamR.TibiaPerforateid == null)
                {
                    LegExamR.TibiaPerforateid = savedLegExamR.TibiaPerforateid;
                }

                if (LegExamR.ZDSVid == null)
                {
                    LegExamR.ZDSVid = savedLegExamR.ZDSVid;
                }

                Data.Complete();
                ////LegExamR.A = savedLegExamR.A;
                ////LegExamR.additionalText = savedLegExamR.additionalText;
                ////LegExamR.BPVHip = savedLegExamR.BPVHip;
                ////LegExamR.BPVTibiaid = savedLegExamR.BPVTibiaid;
                ////LegExamR.C = savedLegExamR.C;
                ////LegExamR.E = savedLegExamR.E;
                ////LegExamR.GVid = savedLegExamR.GVid;
                ////LegExamR.MPVid = savedLegExamR.MPVid;
                ////LegExamR.P = savedLegExamR.P;
                ////LegExamR.PDSVid = savedLegExamR.PDSVid;
                ////LegExamR.PerforateHipid = savedLegExamR.PerforateHipid;
                ////LegExamR.PPVid = savedLegExamR.PPVid;
                ////LegExamR.SFSid = savedLegExamR.SFSid;
                ////LegExamR.SPSid = savedLegExamR.SPSid;
                ////LegExamR.TEMPVid = savedLegExamR.TEMPVid;
                ////LegExamR.TibiaPerforateid = savedLegExamR.TibiaPerforateid;
                ////LegExamR.ZDSVid = savedLegExamR.ZDSVid;


                //examnTotal.hirurgOverviewId = hirurgOverviewId;
                //examnTotal.statementOverviewId = statementOverviewId;
                ////SaveAll();


            }


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

            RightBPV_TibiaEntryFull = (BPV_TibiaEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightBPVTibia, RightBPV_TibiaEntryFull, false, examnTotal.Id.Value);
            LeftBPV_TibiaEntryFull = (BPV_TibiaEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftBPVTibia, LeftBPV_TibiaEntryFull, true, examnTotal.Id.Value);
            RightPerforate_hipEntryFull = (Perforate_hipEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightPerforate, RightPerforate_hipEntryFull, false, examnTotal.Id.Value);
            LeftPerforate_hipEntryFull = (Perforate_hipEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftPerforate, LeftPerforate_hipEntryFull, true, examnTotal.Id.Value);
            RightZDSVEntryFull = (ZDSVEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightZDSV, RightZDSVEntryFull, false, examnTotal.Id.Value);
            LeftZDSVEntryFull = (ZDSVEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftZDSV, LeftZDSVEntryFull, true, examnTotal.Id.Value);
            RightPDSVEntryFull = (PDSVHipEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightPDSV, RightPDSVEntryFull, false, examnTotal.Id.Value);
            LeftPDSVEntryFull = (PDSVHipEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftPDSV, LeftPDSVEntryFull, true, examnTotal.Id.Value);
            RightBPVEntryFull = (BPVHipEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightBPVHip, RightBPVEntryFull, false, examnTotal.Id.Value);
            LeftBPVEntryFull = (BPVHipEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftBPVHip, LeftBPVEntryFull, true, examnTotal.Id.Value);
            RightSFSEntryFull = (SFSHipEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightSFS, RightSFSEntryFull, false, examnTotal.Id.Value);
            LeftSFSEntryFull = (SFSHipEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftSFS, LeftSFSEntryFull, true, examnTotal.Id.Value);

            RightSPSEntryFull = (SPSHipEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightSPS, RightSPSEntryFull, false, examnTotal.Id.Value);
            LeftSPSEntryFull = (SPSHipEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftSPS, LeftSPSEntryFull, true, examnTotal.Id.Value);

            RightPerforate_shinEntryFull = (Perforate_shinEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightTibiaPerforate, RightPerforate_shinEntryFull, false, examnTotal.Id.Value);
            LeftPerforate_shinEntryFull = (Perforate_shinEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftTibiaPerforate, LeftPerforate_shinEntryFull, true, examnTotal.Id.Value);

            RightTEMPVEntryFull = (TEMPVEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightTEMPV, RightTEMPVEntryFull, false, examnTotal.Id.Value);
            LeftTEMPVEntryFull = (TEMPVEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftTEMPV, LeftTEMPVEntryFull, true, examnTotal.Id.Value);

            RightMPVEntryFull = (MPVEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightMPV, RightMPVEntryFull, false, examnTotal.Id.Value);
            LeftMPVEntryFull = (MPVEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftMPV, LeftMPVEntryFull, true, examnTotal.Id.Value);


            RightPPVEntryFull = (PPVEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightPPV, RightPPVEntryFull, false, examnTotal.Id.Value);
            LeftPPVEntryFull = (PPVEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftPPV, LeftPPVEntryFull, true, examnTotal.Id.Value);

            RightGVEntryFull = (GVEntryFull)SaveForSavedProc(ref LegExamR, ref examnTotal, RightGV, RightGVEntryFull, false, examnTotal.Id.Value);
            LeftGVEntryFull = (GVEntryFull)SaveForSavedProc(ref LegExamL, ref examnTotal, LeftGV, LeftGVEntryFull, true, examnTotal.Id.Value);


            //Examination Exam = Data.Examination.Get(obsid);
            //ExaminationLeg LegExamL = new ExaminationLeg();
            //ExaminationLeg LegExamR = new ExaminationLeg();
            //LegExamL = Data.ExaminationLeg.Get(Exam.idLeftLegExamination.Value);
            //LegExamR = Data.ExaminationLeg.Get(Exam.idRightLegExamination.Value);
            Data.Complete();
            //using (var context = new MySqlContext())
            //{
            //    SavedExaminationRepository SavedExamRep = new SavedExaminationRepository(context);
            //    SavedExaminationLegRepository SavedLegExamRep = new SavedExaminationLegRepository(context);
            //    examnTotal = SavedExamRep.GetAll.FirstOrDefault();
            //    LegExamL = SavedLegExamRep.Get(examnTotal.idLeftLegExamination.Value);
            //    LegExamR = SavedLegExamRep.Get(examnTotal.idRightLegExamination.Value);

            //}
            if (!RightBPVHip.IsEmpty && LegExamR.BPVHip == null)
            {


                Data.BPVHipsFull.Add(RightBPVEntryFull);
                // Data.Complete();

            }


            if (!RightBPVTibia.IsEmpty && LegExamR.BPVTibiaid == null)
            {

                Data.BPV_TibiaFull.Add(RightBPV_TibiaEntryFull);
                //    Data.Complete();


            }

            if (!RightGV.IsEmpty && LegExamR.GVid == null)
            {

                Data.GVFull.Add(RightGVEntryFull);
                //  Data.Complete();

            }

            if (!RightMPV.IsEmpty && LegExamR.MPVid == null)
            {

                Data.MPVFull.Add(RightMPVEntryFull);
                // Data.Complete();


            }

            if (!RightPDSV.IsEmpty && LegExamR.PDSVid == null)
            {

                Data.PDSVFull.Add(RightPDSVEntryFull);
                // Data.Complete();


            }
            if (!RightPerforate.IsEmpty && LegExamR.PerforateHipid == null)
            {

                Data.Perforate_hipFull.Add(RightPerforate_hipEntryFull);
                //  Data.Complete();


            }
            if (!RightPPV.IsEmpty && LegExamR.PPVid == null)
            {

                Data.PPVFull.Add(RightPPVEntryFull);
                //  Data.Complete();


            }

            if (!RightSFS.IsEmpty && LegExamR.SFSid == null)
            {

                Data.SFSFull.Add(RightSFSEntryFull);
                //Data.Complete();


            }

            if (!RightSPS.IsEmpty && LegExamR.SPSid == null)
            {

                Data.SPSHipFull.Add(RightSPSEntryFull);
                //  Data.Complete();


            }
            if (!RightTEMPV.IsEmpty && LegExamR.TEMPVid == null)
            {

                Data.TEMPVFull.Add(RightTEMPVEntryFull);
                // Data.Complete();


            }

            if (!RightTibiaPerforate.IsEmpty && LegExamR.TibiaPerforateid == null)
            {

                Data.Perforate_shinFull.Add(RightPerforate_shinEntryFull);
                //  Data.Complete();


            }

            if (!RightZDSV.IsEmpty && LegExamR.ZDSVid == null)
            {

                Data.ZDSVFull.Add(RightZDSVEntryFull);

            }



            if (!LeftBPVHip.IsEmpty && LegExamL.BPVHip == null)
            {


                Data.BPVHipsFull.Add(LeftBPVEntryFull);
                // Data.Complete();

            }


            if (!LeftBPVTibia.IsEmpty && LegExamL.BPVTibiaid == null)
            {

                Data.BPV_TibiaFull.Add(LeftBPV_TibiaEntryFull);
                //    Data.Complete();


            }

            if (!LeftGV.IsEmpty && LegExamL.GVid == null)
            {

                Data.GVFull.Add(LeftGVEntryFull);
                //  Data.Complete();

            }

            if (!LeftMPV.IsEmpty && LegExamL.MPVid == null)
            {

                Data.MPVFull.Add(LeftMPVEntryFull);
                // Data.Complete();


            }

            if (!LeftPDSV.IsEmpty && LegExamL.PDSVid == null)
            {

                Data.PDSVFull.Add(LeftPDSVEntryFull);
                // Data.Complete();


            }
            if (!LeftPerforate.IsEmpty && LegExamL.PerforateHipid == null)
            {

                Data.Perforate_hipFull.Add(LeftPerforate_hipEntryFull);
                //  Data.Complete();


            }
            if (!LeftPPV.IsEmpty && LegExamL.PPVid == null)
            {

                Data.PPVFull.Add(LeftPPVEntryFull);
                //  Data.Complete();


            }

            if (!LeftSFS.IsEmpty && LegExamL.SFSid == null)
            {

                Data.SFSFull.Add(LeftSFSEntryFull);
                //Data.Complete();


            }

            if (!LeftSPS.IsEmpty && LegExamL.SPSid == null)
            {

                Data.SPSHipFull.Add(LeftSPSEntryFull);
                //  Data.Complete();


            }
            if (!LeftTEMPV.IsEmpty && LegExamL.TEMPVid == null)
            {

                Data.TEMPVFull.Add(LeftTEMPVEntryFull);
                // Data.Complete();


            }

            if (!LeftTibiaPerforate.IsEmpty && LegExamL.TibiaPerforateid == null)
            {

                Data.Perforate_shinFull.Add(LeftPerforate_shinEntryFull);
                //  Data.Complete();


            }

            if (!LeftZDSV.IsEmpty && LegExamL.ZDSVid == null)
            {

                Data.ZDSVFull.Add(LeftZDSVEntryFull);

            }

            Data.Complete();



            if (!LeftBPVHip.IsEmpty && LegExamL.BPVHip == null)
            {
                LegExamL.BPVHip = LeftBPVEntryFull.Id;
            }

            if (!LeftBPVTibia.IsEmpty && LegExamL.BPVTibiaid == null)
            {
                LegExamL.BPVTibiaid = LeftBPV_TibiaEntryFull.Id;
            }

            if (!LeftGV.IsEmpty && LegExamL.GVid == null)
            {
                LegExamL.GVid = LeftGVEntryFull.Id;
            }

            if (!LeftMPV.IsEmpty && LegExamL.MPVid == null)
            {
                LegExamL.MPVid = LeftMPVEntryFull.Id;
            }

            if (!LeftPDSV.IsEmpty && LegExamL.PDSVid == null)
            {
                LegExamL.PDSVid = LeftPDSVEntryFull.Id;
            }

            if (!LeftPerforate.IsEmpty && LegExamL.PerforateHipid == null)
            {
                LegExamL.PerforateHipid = LeftPerforate_hipEntryFull.Id;
            }

            if (!LeftPPV.IsEmpty && LegExamL.PPVid == null)
            {
                LegExamL.PPVid = LeftPPVEntryFull.Id;
            }

            if (!LeftSFS.IsEmpty && LegExamL.SFSid == null)
            {
                LegExamL.SFSid = LeftSFSEntryFull.Id;
            }

            if (!LeftSPS.IsEmpty && LegExamL.SPSid == null)
            {
                LegExamL.SPSid = LeftSPSEntryFull.Id;
            }

            if (!LeftTEMPV.IsEmpty && LegExamL.TEMPVid == null)
            {
                LegExamL.TEMPVid = LeftTEMPVEntryFull.Id;
            }

            if (!LeftTibiaPerforate.IsEmpty && LegExamL.TibiaPerforateid == null)
            {
                LegExamL.TibiaPerforateid = LeftPerforate_shinEntryFull.Id;
            }

            if (!LeftZDSV.IsEmpty && LegExamL.ZDSVid == null)
            {
                LegExamL.ZDSVid = LeftZDSVEntryFull.Id;
            }

            LegExamL.additionalText = LeftAdditionalText;
            if (LeftCEAR.LegSections[0].SelectedValue != null)
            {
                LegExamL.C = LeftCEAR.LegSections[0].SelectedValue.Id;
            }

            if (LeftCEAR.LegSections[1].SelectedValue != null)
            {
                LegExamL.E = LeftCEAR.LegSections[1].SelectedValue.Id;
            }

            if (LeftCEAR.LegSections[2].SelectedValue != null)
            {
                LegExamL.A = LeftCEAR.LegSections[2].SelectedValue.Id;
            }

            if (LeftCEAR.LegSections[3].SelectedValue != null)
            {
                LegExamL.P = LeftCEAR.LegSections[3].SelectedValue.Id;
            }

            if (!RightBPVHip.IsEmpty && LegExamR.BPVHip == null)
            {
                LegExamR.BPVHip = RightBPVEntryFull.Id;
            }

            if (!RightBPVTibia.IsEmpty && LegExamR.BPVTibiaid == null)
            {
                LegExamR.BPVTibiaid = RightBPV_TibiaEntryFull.Id;
            }

            if (!RightGV.IsEmpty && LegExamR.GVid == null)
            {
                LegExamR.GVid = RightGVEntryFull.Id;
            }

            if (!RightMPV.IsEmpty && LegExamR.MPVid == null)
            {
                LegExamR.MPVid = RightMPVEntryFull.Id;
            }

            if (!RightPDSV.IsEmpty && LegExamR.PDSVid == null)
            {
                LegExamR.PDSVid = RightPDSVEntryFull.Id;
            }

            if (!RightPerforate.IsEmpty && LegExamR.PerforateHipid == null)
            {
                LegExamR.PerforateHipid = RightPerforate_hipEntryFull.Id;
            }

            if (!RightPPV.IsEmpty && LegExamR.PPVid == null)
            {
                LegExamR.PPVid = RightPPVEntryFull.Id;
            }

            if (!RightSFS.IsEmpty && LegExamR.SFSid == null)
            {
                LegExamR.SFSid = RightSFSEntryFull.Id;
            }

            if (!RightSPS.IsEmpty && LegExamR.SPSid == null)
            {
                LegExamR.SPSid = RightSPSEntryFull.Id;
            }

            if (!RightTEMPV.IsEmpty && LegExamR.TEMPVid == null)
            {
                LegExamR.TEMPVid = RightTEMPVEntryFull.Id;
            }

            if (!RightTibiaPerforate.IsEmpty && LegExamR.TibiaPerforateid == null)
            {
                LegExamR.TibiaPerforateid = RightPerforate_shinEntryFull.Id;
            }

            if (!RightZDSV.IsEmpty && LegExamR.ZDSVid == null)
            {
                LegExamR.ZDSVid = RightZDSVEntryFull.Id;
            }

            LegExamR.additionalText = RightAdditionalText;
            if (RightCEAR.LegSections[0].SelectedValue != null)
            {
                LegExamR.C = RightCEAR.LegSections[0].SelectedValue.Id;
            }

            if (RightCEAR.LegSections[1].SelectedValue != null)
            {
                LegExamR.E = RightCEAR.LegSections[1].SelectedValue.Id;
            }

            if (RightCEAR.LegSections[2].SelectedValue != null)
            {
                LegExamR.A = RightCEAR.LegSections[2].SelectedValue.Id;
            }

            if (RightCEAR.LegSections[3].SelectedValue != null)
            {
                LegExamR.P = RightCEAR.LegSections[3].SelectedValue.Id;
            }

            examnTotal.PatientId = CurrentPatient.Id;
            //examnTotal.Date = DateTime.Now;

            examnTotal.weight = float.Parse(Weight);
            examnTotal.NB = TextTip;
            examnTotal.height = float.Parse(Growth);

            //examnTotal.idLeftLegExamination = leftLegExams.Id;
            //examnTotal.idRightLegExamination = rightLegExams.Id;



            bool test = false;
            if (LeftDiagnosisList != null)
            {

                foreach (var dgOp in Data.SavedDiagnosisObs.GetAll)
                {

                    if (dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == true)
                    {
                        test = true;
                        foreach (var diag in LeftDiagnosisList)
                        {
                            if (diag.IsChecked.Value && dgOp.id_diagnosis == diag.Data.Id)
                            {
                                test = false;
                                break;
                            }
                        }
                    }
                    if (test)
                    {
                        Data.SavedDiagnosisObs.Remove(dgOp);
                        Data.Complete();
                        test = false;
                    }
                }
                test = false;
                // Data.Complete();

                foreach (var diag in LeftDiagnosisList)
                {
                    if (diag.IsChecked.Value)
                    {

                        test = true;
                        foreach (var dgOp in Data.SavedDiagnosisObs.GetAll)
                        {

                            if (dgOp.id_diagnosis == diag.Data.Id && dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == true)
                            {
                                test = false;
                                break;
                            }
                        }
                        if (test)
                        {
                            var newDiag = new SavedDiagnosisObs();
                            newDiag.id_diagnosis = diag.Data.Id;
                            newDiag.id_leg_examination = examnTotal.Id;
                            newDiag.isLeft = true;
                            Data.SavedDiagnosisObs.Add(newDiag);
                            Data.Complete();
                            //    test = false;
                        }
                    }
                }

            }
            test = false;
            if (RightDiagnosisList != null)
            {
                foreach (var dgOp in Data.SavedDiagnosisObs.GetAll)
                {

                    if (dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == false)
                    {
                        test = true;
                        foreach (var diag in RightDiagnosisList)
                        {
                            if (diag.IsChecked.Value && dgOp.id_diagnosis == diag.Data.Id)
                            {
                                test = false;
                                break;
                            }
                        }
                    }
                    if (test)
                    {
                        Data.SavedDiagnosisObs.Remove(dgOp);
                        Data.Complete();
                        test = false;
                    }
                }
                test = false;
                //Data.Complete();
                foreach (var diag in RightDiagnosisList)
                {
                    if (diag.IsChecked.Value)
                    {
                        test = true;
                        foreach (var dgOp in Data.SavedDiagnosisObs.GetAll)
                        {
                            if (dgOp.id_diagnosis == diag.Data.Id && dgOp.id_leg_examination == examnTotal.Id && dgOp.isLeft == false)
                            {
                                test = false;
                                break;
                            }
                        }
                        if (test)
                        {
                            var newDiag = new SavedDiagnosisObs();
                            newDiag.id_diagnosis = diag.Data.Id;
                            newDiag.id_leg_examination = examnTotal.Id;
                            newDiag.isLeft = false;
                            Data.SavedDiagnosisObs.Add(newDiag);
                            Data.Complete();
                        }
                    }
                }
            }
            test = false;
            if (RecomendationsList != null)
            {

                foreach (var dgOp in Data.SavedRecomendationObs.GetAll)
                {

                    if (dgOp.id_examination == examnTotal.Id)
                    {
                        test = true;
                        foreach (var diag in RecomendationsList)
                        {
                            if (diag.IsChecked.Value && dgOp.id_recommendations == diag.Data.Id)
                            {
                                test = false;
                                break;
                            }
                        }
                    }
                    if (test)
                    {
                        Data.SavedRecomendationObs.Remove(dgOp);
                        Data.Complete();
                        test = false;
                    }
                }

                //   Data.Complete();
                test = false;

                foreach (var rec in RecomendationsList)
                {
                    if (rec.IsChecked.Value)
                    {
                        test = true;
                        foreach (var rcOp in Data.SavedRecomendationObs.GetAll)
                        {
                            if (rcOp.id_recommendations == rec.Data.Id && rcOp.id_examination == examnTotal.Id.Value)
                            {
                                test = false;
                                break;
                            }
                        }
                        if (test)
                        {
                            var newRec = new SavedRecomendationObs();
                            newRec.id_recommendations = rec.Data.Id;
                            newRec.id_examination = examnTotal.Id.Value;
                            Data.SavedRecomendationObs.Add(newRec);
                            Data.Complete();
                        }
                    }
                }
            }
            test = false;
            if (ComplainsList != null)
            {
                foreach (var dgOp in Data.SavedComplanesObs.GetAll)
                {

                    if (dgOp.id_Examination == examnTotal.Id)
                    {
                        test = true;
                        foreach (var diag in ComplainsList)
                        {
                            if (diag.IsChecked.Value && dgOp.id_Complains == diag.Data.Id)
                            {
                                test = false;
                                break;
                            }
                        }
                    }
                    if (test)
                    {
                        Data.SavedComplanesObs.Remove(dgOp);
                        Data.Complete();
                        test = false;
                    }
                }

                //  Data.Complete();

                test = false;


                foreach (var cmp in ComplainsList)
                {
                    if (cmp.IsChecked.Value)
                    {
                        test = true;
                        foreach (var cmOp in Data.SavedComplanesObs.GetAll)
                        {
                            if (cmOp.id_Complains == cmp.Data.Id && cmOp.id_Examination == examnTotal.Id.Value)
                            {
                                test = false;
                                break;
                            }
                        }
                        if (test)
                        {
                            var newcmp = new SavedComplanesObs();
                            newcmp.id_Complains = cmp.Data.Id;
                            newcmp.id_Examination = examnTotal.Id.Value;
                            Data.SavedComplanesObs.Add(newcmp);
                            Data.Complete();
                        }
                    }
                }
            }
            //   Data.Complete();





            Data.Complete();
            //MessageBox.Show("\r\nThread awakens!");

        }
        private void SetAllDefault(object sender, object data)
        {
            testThread = true;

            SetAllBordersDefault();
        }

        private int obsid;
        private void SetIdOfStatement(object sender, object data)
        {
            statementOverviewId = int.Parse(data.ToString());
        }
        private void SetIdOfOverview(object sender, object data)
        {
            hirurgOverviewId = int.Parse(data.ToString());
        }
        private void GetObsForOverview(object sender, object data)
        {
            Clear(this, null);//?

            mode = "EDIT";
            TextOfEndBtn = "Вернуться";
            MessageBus.Default.Call("SetMode", this, "EDIT");
            obsid = (int)data;

            Examination Exam = Data.Examination.Get(obsid);
            statementOverviewId = Exam.statementOverviewId;
            hirurgOverviewId = Exam.hirurgOverviewId;
            ExaminationLeg leftLegExam = Data.ExaminationLeg.Get(Exam.idLeftLegExamination.Value);
            ExaminationLeg rightLegExam = Data.ExaminationLeg.Get(Exam.idRightLegExamination.Value);
            IsVisibleTextTTT = Visibility.Visible;
            if (Exam.isNeedOperation)
            {
                TextOfPreOperation = "Предварительно назначена" + Data.OperationType.Get(Exam.OperationType.Value);

            }
            else
            {
                TextOfPreOperation = "Предварительная операция не была назначена";
            }


            Weight = Exam.weight.ToString();
            Growth = Exam.height.ToString();
            TextTip = Exam.NB;


            LeftAdditionalText = leftLegExam.additionalText;

            if (leftLegExam.PDSVid != null)
            {
                GetLegPartFromEntry(Data.PDSVFull.Get(leftLegExam.PDSVid.Value), LeftPDSV, true);
            }


            if (leftLegExam.BPVHip != null)
            {
                GetLegPartFromEntry(Data.BPVHipsFull.Get(leftLegExam.BPVHip.Value), LeftBPVHip, true);
            }

            if (leftLegExam.BPVTibiaid != null)
            {
                GetLegPartFromEntry(Data.BPV_TibiaFull.Get(leftLegExam.BPVTibiaid.Value), LeftBPVTibia, true);
            }

            if (leftLegExam.GVid != null)
            {
                GetLegPartFromEntry(Data.GVFull.Get(leftLegExam.GVid.Value), LeftGV, true);
            }

            if (leftLegExam.MPVid != null)
            {
                GetLegPartFromEntry(Data.MPVFull.Get(leftLegExam.MPVid.Value), LeftMPV, true);
            }

            if (leftLegExam.PerforateHipid != null)
            {
                GetLegPartFromEntry(Data.Perforate_hipFull.Get(leftLegExam.PerforateHipid.Value), LeftPerforate, true);
            }

            if (leftLegExam.PPVid != null)
            {
                GetLegPartFromEntry(Data.PPVFull.Get(leftLegExam.PPVid.Value), LeftPPV, true);
            }

            if (leftLegExam.SFSid != null)
            {
                GetLegPartFromEntry(Data.SFSFull.Get(leftLegExam.SFSid.Value), LeftSFS, true);
            }

            if (leftLegExam.SPSid != null)
            {
                GetLegPartFromEntry(Data.SPSHipFull.Get(leftLegExam.SPSid.Value), LeftSPS, true);
            }

            if (leftLegExam.TEMPVid != null)
            {
                GetLegPartFromEntry(Data.TEMPVFull.Get(leftLegExam.TEMPVid.Value), LeftTEMPV, true);
            }

            if (leftLegExam.TibiaPerforateid != null)
            {
                GetLegPartFromEntry(Data.Perforate_shinFull.Get(leftLegExam.TibiaPerforateid.Value), LeftTibiaPerforate, true);
            }

            if (leftLegExam.ZDSVid != null)
            {
                GetLegPartFromEntry(Data.ZDSVFull.Get(leftLegExam.ZDSVid.Value), LeftZDSV, true);
            }

            if (leftLegExam.C != null)
            {
                LeftCEAR.LegSections[0].SelectedValue = Data.Letters.Get(leftLegExam.C.Value);
            }

            if (leftLegExam.E != null)
            {
                LeftCEAR.LegSections[1].SelectedValue = Data.Letters.Get(leftLegExam.E.Value);
            }

            if (leftLegExam.A != null)
            {
                LeftCEAR.LegSections[2].SelectedValue = Data.Letters.Get(leftLegExam.A.Value);
            }

            if (leftLegExam.P != null)
            {
                LeftCEAR.LegSections[3].SelectedValue = Data.Letters.Get(leftLegExam.P.Value);
            }

            LeftCEAR.SaveCommand.Execute();













            RightAdditionalText = rightLegExam.additionalText;



            if (rightLegExam.PDSVid != null)
            {
                GetLegPartFromEntry(Data.PDSVFull.Get(rightLegExam.PDSVid.Value), RightPDSV, false);
            }

            if (rightLegExam.BPVHip != null)
            {
                GetLegPartFromEntry(Data.BPVHipsFull.Get(rightLegExam.BPVHip.Value), RightBPVHip, false);
            }

            if (rightLegExam.BPVTibiaid != null)
            {
                GetLegPartFromEntry(Data.BPV_TibiaFull.Get(rightLegExam.BPVTibiaid.Value), RightBPVTibia, false);
            }

            if (rightLegExam.GVid != null)
            {
                GetLegPartFromEntry(Data.GVFull.Get(rightLegExam.GVid.Value), RightGV, false);
            }

            if (rightLegExam.MPVid != null)
            {
                GetLegPartFromEntry(Data.MPVFull.Get(rightLegExam.MPVid.Value), RightMPV, false);
            }

            if (rightLegExam.PerforateHipid != null)
            {
                GetLegPartFromEntry(Data.Perforate_hipFull.Get(rightLegExam.PerforateHipid.Value), RightPerforate, false);
            }

            if (rightLegExam.PPVid != null)
            {
                GetLegPartFromEntry(Data.PPVFull.Get(rightLegExam.PPVid.Value), RightPPV, false);
            }

            if (rightLegExam.SFSid != null)
            {
                GetLegPartFromEntry(Data.SFSFull.Get(rightLegExam.SFSid.Value), RightSFS, false);
            }

            if (rightLegExam.SPSid != null)
            {
                GetLegPartFromEntry(Data.SPSHipFull.Get(rightLegExam.SPSid.Value), RightSPS, false);
            }

            if (rightLegExam.TEMPVid != null)
            {
                GetLegPartFromEntry(Data.TEMPVFull.Get(rightLegExam.TEMPVid.Value), RightTEMPV, false);
            }

            if (rightLegExam.TibiaPerforateid != null)
            {
                GetLegPartFromEntry(Data.BPV_TibiaFull.Get(rightLegExam.TibiaPerforateid.Value), RightTibiaPerforate, false);
            }

            if (rightLegExam.ZDSVid != null)
            {
                GetLegPartFromEntry(Data.ZDSVFull.Get(rightLegExam.ZDSVid.Value), RightZDSV, false);
            }

            if (rightLegExam.C != null)
            {
                RightCEAR.LegSections[0].SelectedValue = Data.Letters.Get(rightLegExam.C.Value);
            }

            if (rightLegExam.E != null)
            {
                RightCEAR.LegSections[1].SelectedValue = Data.Letters.Get(rightLegExam.E.Value);
            }

            if (rightLegExam.A != null)
            {
                RightCEAR.LegSections[2].SelectedValue = Data.Letters.Get(rightLegExam.A.Value);
            }

            if (rightLegExam.P != null)
            {
                RightCEAR.LegSections[3].SelectedValue = Data.Letters.Get(rightLegExam.P.Value);
            }

            RightCEAR.SaveCommand.Execute();

                
                


            LeftDiagnosisList = new ObservableCollection<DiagnosisDataSource>();


            DiagnosisDataSource diagDSourceBuf;
            foreach (var diag in Data.DiagnosisObs.GetAll.Where(s => s.isLeft == true && s.id_leg_examination == Exam.Id).ToList())
            {
                diagDSourceBuf = new DiagnosisDataSource(Data.DiagnosisTypes.Get(diag.id_diagnosis.Value));
                diagDSourceBuf.IsChecked = true;
                LeftDiagnosisList.Add(diagDSourceBuf);
            }

            RightDiagnosisList = new ObservableCollection<DiagnosisDataSource>();



            foreach (var diag in Data.DiagnosisObs.GetAll.Where(s => s.isLeft == false && s.id_leg_examination == Exam.Id).ToList())
            {
                diagDSourceBuf = new DiagnosisDataSource(Data.DiagnosisTypes.Get(diag.id_diagnosis.Value));
                diagDSourceBuf.IsChecked = true;
                RightDiagnosisList.Add(diagDSourceBuf);
            }

            MessageBus.Default.Call("SetDiagnosisListBecauseOFEdit", LeftDiagnosisList, RightDiagnosisList);

            ComplainsList = new ObservableCollection<ComplainsDataSource>();
            ComplainsDataSource compDSourceBuf;
            foreach (var diag in Data.ComplanesObs.GetAll.Where(s => s.id_Examination == Exam.Id).ToList())
            {
                compDSourceBuf = new ComplainsDataSource(Data.ComplainsTypes.Get(diag.id_Complains));
                compDSourceBuf.IsChecked = true;
                ComplainsList.Add(compDSourceBuf);
            }
            RecomendationsList = new ObservableCollection<RecomendationsDataSource>();
            RecomendationsDataSource recDSourceBuf;

            foreach (var diag in Data.RecomendationObs.GetAll.Where(s => s.id_examination == Exam.Id).ToList())
            {
                recDSourceBuf = new RecomendationsDataSource(Data.RecomendationsTypes.Get(diag.id_recommendations));
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


            MessageBus.Default.Call("SetMode", this, "Normal");
            isEdited = false;
        }

        //  public ObservableCollection<>
        //кто присылает и что присылает
        private double ScrollSize;
        private double ScrollSizeRight;
        private bool isOneTime;
        private bool isOneTimeRight;
        private void SaveScrollSize(object sender, object data)
        {
            ScrollSize = (double)data;
        }
        private void GetScrollSize(object sender, object data)
        {
            MessageBus.Default.Call("SetScrollOnlyForAddObsled", ScrollSize, isOneTime);
            isOneTime = false;
        }

        private void SaveScrollSizeRight(object sender, object data)
        {
            ScrollSizeRight = (double)data;
        }
        private void GetScrollSizeRight(object sender, object data)
        {
            MessageBus.Default.Call("SetScrollOnlyForAddObsledRight", ScrollSizeRight, isOneTimeRight);
            isOneTimeRight = false;
        }
        private void Handler(object sender, object data)
        {

            isOneTime = true;
            isOneTimeRight = true;
            isEdited = true;
            MessageBus.Default.Call("SetScrollForAddObsled", ScrollSize, null);
            MessageBus.Default.Call("SetScrollForAddObsledRight", ScrollSize, null);
            Type senderType = sender.GetType();
            LegPartViewModel senderVM = (LegPartViewModel)sender;
            //  BPVHipEntryFull bpv = new BPVHipEntryFull();
            if (senderType == typeof(GVViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    GVLeftstr = new List<string>();
                    LeftGVEntryFull = new GVEntryFull();
                    //to do тут должно быть сохранение
                    LeftGV = (GVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftGV);
                    GVLeftstr = result.stringList;
                    IsVisibleGVleft = result.listVisibility;
                    if (LeftGV.IsEmpty == true)
                    {


                        BGV = Brushes.Red;

                    }
                    else if (LeftGV.IsEmpty != true)
                    {
                        BGV = null;
                    }
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
                    if (RightGV.IsEmpty == true)
                    {


                        BGVL = Brushes.Red;
                    }
                    else if (RightGV.IsEmpty != true)
                    {
                        BGVL = null;
                    }
                }
            }

            if (senderType == typeof(MPVViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    MPVLeftstr = new List<string>();
                    LeftMPVEntryFull = new MPVEntryFull();
                    //to do тут должно быть сохранение
                    LeftMPV = (MPVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftMPV);
                    MPVLeftstr = result.stringList;
                    IsVisibleMPVleft = result.listVisibility;
                    if (LeftMPV.IsEmpty == true)
                    {

                        BTEMPV = Brushes.Red;
                    }
                    else if (LeftMPV.IsEmpty != true)
                    {
                        BTEMPV = null;
                    }
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

                    if (RightMPV.IsEmpty == true)
                    {

                        BTEMPVL = Brushes.Red;
                    }
                    else if (RightMPV.IsEmpty != true)
                    {
                        BTEMPVL = null;
                    }
                }
            }

            if (senderType == typeof(PPVViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    PPVLeftstr = new List<string>();
                    LeftPPVEntryFull = new PPVEntryFull();
                    //to do тут должно быть сохранение
                    LeftPPV = (PPVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftPPV);
                    PPVLeftstr = result.stringList;
                    IsVisiblePPVleft = result.listVisibility;


                    if (LeftPPV.IsEmpty == true)
                    {

                        BPPV = Brushes.Red;
                    }
                    else if (LeftPPV.IsEmpty != true)
                    {
                        BPPV = null;
                    }
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
                    if (RightPPV.IsEmpty == true)
                    {

                        BPPVL = Brushes.Red;
                    }
                    else if (RightPPV.IsEmpty != true)
                    {
                        BPPVL = null;
                    }
                }
            }

            if (senderType == typeof(TEMPVViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    TEMPVLeftstr = new List<string>();
                    LeftTEMPVEntryFull = new TEMPVEntryFull();
                    //to do тут должно быть сохранение
                    LeftTEMPV = (TEMPVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftTEMPV);
                    TEMPVLeftstr = result.stringList;
                    IsVisibleTEMPVleft = result.listVisibility;
                    //if (LeftTEMPV.IsEmpty == true)
                    //{

                    //    BTEMPV = Brushes.Red;
                    //}
                    //else if (LeftTEMPV.IsEmpty != true)
                    //{
                    //    BTEMPV = null;
                    //}
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



                    //if (RightTEMPV.IsEmpty == true)
                    //{

                    //    BTEMPVL = Brushes.Red;
                    //}
                    //else if (RightTEMPV.IsEmpty != true)
                    //{
                    //    BTEMPVL = null;
                    //}


                }
            }
            //sender проверять какого типа
            if (senderType == typeof(SFSViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    SFSLeftstr = new List<string>();
                    LeftSFSEntryFull = new SFSHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftSFS = (SFSViewModel)sender;
                    SaveSet result = SaveViewModel(LeftSFS);
                    SFSLeftstr = result.stringList;
                    IsVisibleSFSleft = result.listVisibility;
                    if (LeftSFS.IsEmpty == true)
                    {

                        BPDSV = Brushes.Red;
                    }
                    else if (LeftSFS.IsEmpty != true)
                    {
                        BPDSV = null;
                    }
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
                    if (RightSFS.IsEmpty == true)
                    {

                        BPDSVL = Brushes.Red;
                    }
                    else if (RightSFS.IsEmpty != true)
                    {
                        BPDSVL = null;
                    }
                }
            }

            //


            if (senderType == typeof(SPSViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    SPSLeftstr = new List<string>();
                    LeftSPSEntryFull = new SPSHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftSPS = (SPSViewModel)sender;
                    SaveSet result = SaveViewModel(LeftSPS);
                    SPSLeftstr = result.stringList;
                    IsVisibleSPSleft = result.listVisibility;
                    if (LeftSPS.IsEmpty == true)
                    {

                        BPerforateGoleni = Brushes.Red;
                    }
                    else if (LeftSPS.IsEmpty != true)
                    {
                        BPerforateGoleni = null;
                    }
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
                    if (RightSPS.IsEmpty == true)
                    {

                        BPerforateGoleniL = Brushes.Red;
                    }

                    else if (RightSPS.IsEmpty != true)
                    {
                        BPerforateGoleniL = null;
                    }
                }
            }

            if (senderType == typeof(TibiaPerforateViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    Perforate_shinLeftstr = new List<string>();
                    LeftPerforate_shinEntryFull = new Perforate_shinEntryFull();
                    //to do тут должно быть сохранение
                    LeftTibiaPerforate = (TibiaPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(LeftTibiaPerforate);
                    Perforate_shinLeftstr = result.stringList;
                    IsVisiblePerforate_shinleft = result.listVisibility;




                    //if (LeftTibiaPerforate.IsEmpty == true)
                    //{

                    //    BPerforateGoleni = Brushes.Red;
                    //}
                    //else if (LeftTibiaPerforate.IsEmpty != true)
                    //{
                    //    BPerforateGoleni = null;
                    //}
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
                    //if (RightTibiaPerforate.IsEmpty == true)
                    //{

                    //    BPerforateGoleniL = Brushes.Red;
                    //}

                    //else if (RightTibiaPerforate.IsEmpty != true)
                    //{
                    //    BPerforateGoleniL = null;
                    //}
                }
            }



            //




            if (senderType == typeof(BPVHipViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftBPVEntryFull = new BPVHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftBPVHip = (BPVHipViewModel)sender;
                    SaveSet result = SaveViewModel(LeftBPVHip);
                    BpvLeftstr = result.stringList;
                    IsVisibleBPVleft = result.listVisibility;
                    if (LeftBPVHip.IsEmpty == true)
                    {

                        BZDSV = Brushes.Red;
                    }
                    else if (LeftBPVHip.IsEmpty != true)
                    {
                        BZDSV = null;
                    }
                }
                else
                {
                    RightBPVEntryFull = new BPVHipEntryFull();
                    BpvRightstr = new List<string>();
                    RightBPVHip = (BPVHipViewModel)sender;
                    SaveSet result = SaveViewModel(RightBPVHip);
                    BpvRightstr = result.stringList;
                    IsVisibleBPVRight = result.listVisibility;
                    if (RightBPVHip.IsEmpty == true)
                    {

                        BZDSVL = Brushes.Red;
                    }
                    else if (RightBPVHip.IsEmpty != true)
                    {
                        BZDSVL = null;
                    }
                }
            }

            if (senderType == typeof(PDSVViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftPDSVEntryFull = new PDSVHipEntryFull();
                    //to do тут должно быть сохранение
                    LeftPDSV = (PDSVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftPDSV);
                    PDSVLeftstr = result.stringList;
                    IsVisiblePDSVleft = result.listVisibility;
                    //SaveAll();
                    //if (LeftPDSV.IsEmpty == true)
                    //{

                    //    BPDSV = Brushes.Red;
                    //}
                    //else if (LeftPDSV.IsEmpty != true)
                    //{
                    //    BPDSV = null;
                    //}

                }
                else
                {
                    RightPDSVEntryFull = new PDSVHipEntryFull();
                    //to do тут должно быть сохранение
                    RightPDSV = (PDSVViewModel)sender;
                    SaveSet result = SaveViewModel(RightPDSV);
                    PDSVRightstr = result.stringList;
                    IsVisiblePDSVright = result.listVisibility;




                    //if (RightPDSV.IsEmpty == true)
                    //{

                    //    BPDSVL = Brushes.Red;
                    //}
                    //else if (RightPDSV.IsEmpty != true)
                    //{
                    //    BPDSVL = null;
                    //}

                }
            }

            //
            if (senderType == typeof(ZDSVViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftZDSVEntryFull = new ZDSVEntryFull();
                    //to do тут должно быть сохранение
                    LeftZDSV = (ZDSVViewModel)sender;
                    SaveSet result = SaveViewModel(LeftZDSV);
                    ZDSVLeftstr = result.stringList;
                    IsVisibleZDSVleft = result.listVisibility;

                    //if (LeftZDSV.IsEmpty == true)
                    //{

                    //    BZDSV = Brushes.Red;
                    //}
                    //else if (LeftZDSV.IsEmpty != true)
                    //{
                    //    BZDSV = null;
                    //}
                }
                else
                {
                    RightZDSVEntryFull = new ZDSVEntryFull();
                    //to do тут должно быть сохранение
                    RightZDSV = (ZDSVViewModel)sender;
                    SaveSet result = SaveViewModel(RightZDSV);
                    ZDSVRightstr = result.stringList;
                    IsVisibleZDSVright = result.listVisibility;


                    //if (RightZDSV.IsEmpty == true)
                    //{

                    //    BZDSVL = Brushes.Red;
                    //}
                    //else if (RightZDSV.IsEmpty != true)
                    //{
                    //    BZDSVL = null;
                    //}



                }
            }

            if (senderType == typeof(HipPerforateViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftPerforate_hipEntryFull = new Perforate_hipEntryFull();
                    //to do тут должно быть сохранение
                    LeftPerforate = (HipPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(LeftPerforate);
                    Perforate_hipLeftstr = result.stringList;
                    IsVisiblePerforateHIPleft = result.listVisibility;


                    //if (LeftPerforate.IsEmpty == true)
                    //{

                    //    BPerforate1 = Brushes.Red;
                    //}
                    //else if (LeftPerforate.IsEmpty != true)
                    //{
                    //    BPerforate1 = null;
                    //}
                }
                else
                {
                    RightPerforate_hipEntryFull = new Perforate_hipEntryFull();
                    //to do тут должно быть сохранение
                    RightPerforate = (HipPerforateViewModel)sender;
                    SaveSet result = SaveViewModel(RightPerforate);
                    Perforate_hipRightstr = result.stringList;
                    IsVisiblePerforateHIPright = result.listVisibility;
                    //if (RightPerforate.IsEmpty == true)
                    //{

                    //    BPerforate1L = Brushes.Red;
                    //}
                    //else if (RightPerforate.IsEmpty != true)
                    //{
                    //    BPerforate1L = null;
                    //}
                }
            }

            if (senderType == typeof(BPVTibiaViewModel))
            {
                if (senderVM.CurrentLegSide == LegSide.Left)
                {
                    LeftBPV_TibiaEntryFull = new BPV_TibiaEntryFull();
                    //to do тут должно быть сохранение
                    LeftBPVTibia = (BPVTibiaViewModel)sender;
                    SaveSet result = SaveViewModel(LeftBPVTibia);
                    BPV_TibiaLeftstr = result.stringList;
                    IsVisibleBPV_Tibialeft = result.listVisibility;
                    if (LeftBPVTibia.IsEmpty == true)
                    {

                        BPerforate1 = Brushes.Red;
                    }
                    else if (LeftBPVTibia.IsEmpty != true)
                    {
                        BPerforate1 = null;
                    }
                }
                else
                {
                    RightBPV_TibiaEntryFull = new BPV_TibiaEntryFull();
                    //to do тут должно быть сохранение
                    RightBPVTibia = (BPVTibiaViewModel)sender;
                    SaveSet result = SaveViewModel(RightBPVTibia);
                    BPV_TibiaRightstr = result.stringList;
                    IsVisibleBPV_Tibiaright = result.listVisibility;
                    if (RightBPVTibia.IsEmpty == true)
                    {

                        BPerforate1L = Brushes.Red;
                    }
                    else if (RightBPVTibia.IsEmpty != true)
                    {
                        BPerforate1L = null;
                    }
                }
            }

            if (senderType == typeof(LettersViewModel))
            {
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

                    if (LeftCEAR.LegSections[0].SelectedValue == null)
                    {
                        BCEAR = Brushes.Red;
                    }

                    if (LeftCEAR.LegSections[1].SelectedValue == null)
                    {
                        BCEAR = Brushes.Red;
                    }

                    if (LeftCEAR.LegSections[2].SelectedValue == null)
                    {
                        BCEAR = Brushes.Red;
                    }

                    if (LeftCEAR.LegSections[3].SelectedValue == null)
                    {
                        BCEAR = Brushes.Red;
                    }

                    if (LeftCEAR.LegSections[0].SelectedValue != null && LeftCEAR.LegSections[1].SelectedValue != null && LeftCEAR.LegSections[2].SelectedValue != null && LeftCEAR.LegSections[3].SelectedValue != null)
                    {
                        BCEAR = null;
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

                    if (RightCEAR.LegSections[0].SelectedValue == null)
                    {
                        BCEARL = Brushes.Red;
                    }
                    if (RightCEAR.LegSections[1].SelectedValue == null)
                    {
                        BCEARL = Brushes.Red;
                    }
                    if (RightCEAR.LegSections[2].SelectedValue == null)
                    {
                        BCEARL = Brushes.Red;
                    }
                    if (RightCEAR.LegSections[3].SelectedValue == null)
                    {
                        BCEARL = Brushes.Red;
                    }
                    if (RightCEAR.LegSections[0].SelectedValue != null && RightCEAR.LegSections[1].SelectedValue != null && RightCEAR.LegSections[2].SelectedValue != null && RightCEAR.LegSections[3].SelectedValue != null)
                    {
                        BCEARL = null;
                    }
                }
            }
        }

    }



}