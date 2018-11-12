using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;
using System.Collections.Generic;

namespace WpfApp2.ViewModels
{
    public class ViewModelAddPathology : ViewModelBase, INotifyPropertyChanged
    {

        #region Inotify realisation
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

        public PatologyTypePanelViewModel CurrentPanelViewModel { get; protected set; }

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

        public string ReturnBtnName { get; private set; }

        #endregion
        #region Bindings
        public string TextAddOrSave { get; set; }
        private ObservableCollection<string> _patologyTypes;
        public ObservableCollection<string> PatologyTypes { get { return _patologyTypes; } set { _patologyTypes = value; OnPropertyChanged(); } }
        private ObservableCollection<int> _patologyTypesId;
        public ObservableCollection<int> PatologyTypesId { get { return _patologyTypesId; } set { _patologyTypesId = value; OnPropertyChanged(); } }
        private Visibility _isNewTypeAvalible;
        public Visibility isNewTypeAvalible { get { return _isNewTypeAvalible; } set { _isNewTypeAvalible = value; OnPropertyChanged(); } }

        private int _index = 1;

        private bool _isReadOnly;
        public bool isReadOnly { get { return _isReadOnly; } set { _isReadOnly = value; OnPropertyChanged(); } }


        public string _yearAppear;
        public string _monthAppear;
        public string _monthDisappear;
        public string _yearDisappear;
        private Brush _yearAppearB;
        private Brush _monthAppearB;
        private Brush _yearDisappearB;
        private Brush _monthDisappearB;

        public Brush YearAppearB { get { return _yearAppearB; } set { _yearAppearB = value; OnPropertyChanged(); } }
        public Brush MonthAppearB { get { return _monthAppearB; } set { _monthAppearB = value; OnPropertyChanged(); } }
        public Brush YearDisappearB { get { return _yearDisappearB; } set { _yearDisappearB = value; OnPropertyChanged(); } }
        public Brush MonthDisappearB { get { return _monthDisappearB; } set { _monthDisappearB = value; OnPropertyChanged(); } }

        public int Index { get { return _index; } set { _index = value; OnPropertyChanged(); } }
        public string YearAppear { get { return _yearAppear; } set { _yearAppear = value; } }
        public string MonthAppear { get { return _monthAppear; } set { _monthAppear = value; } }
        public string MonthDisappear { get { return _monthDisappear; } set { _monthDisappear = value; } }
        public string YearDisappear { get { return _yearDisappear; } set { _yearDisappear = value; } }
        private string _initials;
        public string Initials
        {
            get { return _initials; }
            set
            {
                _initials = value;

                OnPropertyChanged();
            }
        }
        public DateTime DateAppear { get; set; }

        public DateTime DateDisappear { get; set; }

        public Patient CurrentPatient { get; set; }
        #endregion
        #region MessageBus

        private void SetCurrentPatientID(object sender, object data)
        {
            YearSelectedId = Year.Count - 1;
            //Initials = "Пациент: " + CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ". ";

            setCurrMonth(DateTime.Now.Month);
            YearDissapearSelectedId = Yeard.Count - 1;
            MonthDissapearSelectedId = Monthd.Count - 1;
            YearAppear = "";
            MonthAppear = "";
            MonthDisappear = "";
            YearDisappear = "";
            isNewTypeAvalible = Visibility.Visible;
            isReadOnly = true;
            CurrentPatient = Data.Patients.Get((int)data);
            PatologyTypesId = new ObservableCollection<int>();
            PatologyTypes = new ObservableCollection<string>();
            ObservableCollection<Patology> PatologyTypesbuf = new ObservableCollection<Patology>();

            foreach (Patology Patology in Data.Patology.GetAll)
            {
                //Patology sadasew
                if (Patology.id_пациента == CurrentPatient.Id)
                {
                    foreach (var PatoType in Data.PatologyType.GetAll)
                    {
                        if (PatoType.Id == Patology.id_патологии)
                        {
                            PatologyTypesbuf.Add(Patology);
                        }
                    }

                }
            }
            bool result = true;
            foreach (PatologyType PatoType in Data.PatologyType.GetAll)
            {
                result = true;

                foreach (var PatoTypeBuff in PatologyTypesbuf)
                {
                    if (PatoType.Id == PatoTypeBuff.id_патологии && PatoTypeBuff.isArchivatied != true)
                        result = false;
                }
                if (result == true)
                {
                    PatologyTypes.Add(PatoType.Str);
                    PatologyTypesId.Add(PatoType.Id);
                }
            }

            Index = 0;
            // Controller.NavigateTo<ViewModelAddPathology>();
        }
        #endregion

        #region DelegateCommands

        public DelegateCommand ToPathologyListCommand { get; protected set; }

        public DelegateCommand ToPathologyListNoSaveCommands { get; protected set; }

        #endregion

        private void rebuildMonthDissapearList()
        {
            Monthd = new ObservableCollection<string>();
            if (Month.Count != 0)
            {
                if (Yeard.Count != 0 && Year.Count != 0 && Year[YearSelectedId] != DateTime.Now.Year.ToString() && Yeard[YearDissapearSelectedId] == DateTime.Now.Year.ToString() && MonthSelectedId != -1)
                {
                    for (int i = MonthSelectedId; i < DateTime.Now.Month; ++i)
                    {

                        string buf = Month[i];
                        Monthd.Add(buf);


                    }
                    Monthd.Add("-");
                    MonthDissapearSelectedId = Monthd.Count - 1;
                }
                else if(Yeard.Count != 0 && Year.Count != 0 && MonthSelectedId != -1)
                {
                    for (int i = MonthSelectedId; i < Month.Count; ++i)
                    {

                        string buf = Month[i];
                        Monthd.Add(buf);


                    }
                    Monthd.Add("-");
                    MonthDissapearSelectedId = Monthd.Count - 1;
                }
            }

        }

        private void rebuildYearDissapearList()
        {
            Yeard = new ObservableCollection<string>();
            for (int i = YearSelectedId; i < Year.Count; ++i)
            {

                string buf = Year[i];
                Yeard.Add(buf);


            }
            Yeard.Add("-");
            YearDissapearSelectedId = Yeard.Count - 1;


        }


        private int _yearSelectedId;

        public int YearSelectedId { get { return _yearSelectedId; } set { _yearSelectedId = value; RebuildMonthList(); rebuildYearDissapearList(); OnPropertyChanged(); } }

        private void RebuildMonthList()
        {
            Month = new ObservableCollection<string>();
            if (Year[YearSelectedId] == DateTime.Now.Year.ToString())
            {

                for (int i = 1; i <= DateTime.Now.Month; i++)
                {
                    Month.Add(getmonthName(i));
                }

            }
            else
            {
                Month.Add("Январь");
                Month.Add("Февраль");
                Month.Add("Март");
                Month.Add("Апрель");
                Month.Add("Май");
                Month.Add("Июнь");
                Month.Add("Июль");
                Month.Add("Август");
                Month.Add("Сентябрь");
                Month.Add("Октябрь");
                Month.Add("Ноябрь");
                Month.Add("Декабрь");
            }
        }


        private int _monthSelectedId;

        public int MonthSelectedId { get { return _monthSelectedId; } set { _monthSelectedId = value; rebuildMonthDissapearList(); OnPropertyChanged(); } }

        private int _yearDissapearSelectedId;

        public int YearDissapearSelectedId { get { return _yearDissapearSelectedId; } set { _yearDissapearSelectedId = value; rebuildMonthDissapearList(); OnPropertyChanged(); } }

        private int _monthDissapearSelectedId;

        public int MonthDissapearSelectedId { get { return _monthDissapearSelectedId; } set { _monthDissapearSelectedId = value; OnPropertyChanged(); } }


        private int getmonthName(string number)
        {
            switch (number)
            {
                case "Январь":
                    return 1;
                case "Февраль":
                    return 2;
                case "Март":
                    return 3;
                case "Апрель":
                    return 4;
                case "Май":
                    return 5;
                case "Июнь":
                    return 6;
                case "Июль":
                    return 7;
                case "Август":
                    return 8;
                case "Сентябрь":
                    return 9;
                case "Октябрь":
                    return 10;
                case "Ноябрь":
                    return 11;
                case "Декабрь":
                    return 12;
            }
            return 0;

        }

        private void setCurrMonth(int i)
        {

            switch (DateTime.Now.Month)
            {
                case 1:
                    MonthSelectedId = Month.IndexOf("Январь");
                    break;
                case 2:
                    MonthSelectedId = Month.IndexOf("Февраль");
                    break;
                case 3:
                    MonthSelectedId = Month.IndexOf("Март");
                    break;
                case 4:
                    MonthSelectedId = Month.IndexOf("Апрель");
                    break;
                case 5:
                    MonthSelectedId = Month.IndexOf("Май");
                    break;
                case 6:
                    MonthSelectedId = Month.IndexOf("Июнь");
                    break;
                case 7:
                    MonthSelectedId = Month.IndexOf("Июль");
                    break;
                case 8:
                    MonthSelectedId = Month.IndexOf("Август");
                    break;
                case 9:
                    MonthSelectedId = Month.IndexOf("Сентябрь");
                    break;
                case 10:
                    MonthSelectedId = Month.IndexOf("Октябрь");
                    break;
                case 11:
                    MonthSelectedId = Month.IndexOf("Ноябрь");
                    break;
                case 12:
                    MonthSelectedId = Month.IndexOf("Декабрь");
                    break;
            }


        }
        private ObservableCollection<string> _month;

        public ObservableCollection<string> Month { get { return _month; } set { _month = value; OnPropertyChanged(); } }

        private List<string> _year;

        public List<string> Year { get { return _year; } set { _year = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _monthd;

        public ObservableCollection<string> Monthd { get { return _monthd; } set { _monthd = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _yeard;

        public ObservableCollection<string> Yeard { get { return _yeard; } set { _yeard = value; OnPropertyChanged(); } }
        private string getmonthName(int number)
        {
            switch (number)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
            }
            return "";

        }

        public ViewModelAddPathology(NavigationController controller) : base(controller)
        {
            Monthd = new ObservableCollection<string>();
            Yeard = new ObservableCollection<string>();

            Year = new List<string>();

            // MonthAndYear = new List<string>();
            Month = new ObservableCollection<string>();
            Month.Add("Январь");
            Month.Add("Февраль");
            Month.Add("Март");
            Month.Add("Апрель");
            Month.Add("Май");
            Month.Add("Июнь");
            Month.Add("Июль");
            Month.Add("Август");
            Month.Add("Сентябрь");
            Month.Add("Октябрь");
            Month.Add("Ноябрь");
            Month.Add("Декабрь");
            Monthd = new ObservableCollection<string>(Month);
            for (int i = 1950; i <= DateTime.Now.Year; ++i)
            {


                Year.Add(i.ToString());
                if (DateTime.Now.Month == 1 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 2 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 3 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 4 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 5 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 6 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 7 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 8 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 9 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 10 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 11 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

                if (DateTime.Now.Month == 12 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

            }

            Yeard = new ObservableCollection<string>(Year);
            Yeard.Add("-");
            Monthd.Add("-");
            ReturnBtnName = "Вернуться";

            TextAddOrSave = "Добавить";
            YearAppearB = Brushes.Gray;
            MonthAppearB = Brushes.Gray;
            YearDisappearB = Brushes.Gray;
            MonthDisappearB = Brushes.Gray;
            DateAppear = DateTime.Now;
            DateDisappear = DateTime.Now;
            MessageBus.Default.Subscribe("GetPatientForAddPatology", SetCurrentPatientID);
            HasNavigation = true;
            CurrentPanelViewModel = new PatologyTypePanelViewModel(this);
            OpenPanelCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });



            ToPathologyListCommand = new DelegateCommand(
                () =>
                {
                    if (PatologyTypes.Count != 0)
                    {

                        try
                        {
                            Patology buff = new Patology();

                            // string[] curDate = MonthAndYear[MonthAndYearSelectedId].Split(' ');

                            DateAppear = new DateTime(int.Parse(Year[YearSelectedId]), getmonthName(Month[MonthSelectedId]), 1);
                            buff.MonthAppear = DateAppear;
                            buff.YearAppear = DateAppear;


                            if (Monthd[MonthDissapearSelectedId] != "-" && Yeard[YearDissapearSelectedId] != "-")
                            {

                                buff.isArchivatied = true;
                                DateDisappear = new DateTime(int.Parse(Yeard[YearDissapearSelectedId]), getmonthName(Monthd[MonthDissapearSelectedId]), 1);
                                buff.MonthDisappear = DateDisappear;
                                buff.YearDisappear = DateDisappear;


                            }
                            else
                            {
                                buff.MonthDisappear = null;
                                buff.YearDisappear = null;
                            }
                            buff.id_пациента = CurrentPatient.Id;

                            buff.id_патологии = PatologyTypesId[Index];

                            Data.Patology.Add(buff);
                            Data.Complete();
                            MessageBus.Default.Call("GetPatientForPatology", this, CurrentPatient.Id);
                            Controller.NavigateTo<ViewModelPathologyList>();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Добавьте патологию");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Добавьте патологию");
                    }
                }
            );
            ToPathologyListNoSaveCommands = new DelegateCommand(
              () =>
              {
                  MessageBus.Default.Call("GetPatientForPatology", this, CurrentPatient.Id);
                  Controller.NavigateTo<ViewModelPathologyList>();
              }
          );

            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });

            SaveCommand = new DelegateCommand(() =>
            {


                var newType = CurrentPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentPanelViewModel.PanelOpened = false;
                    Handled = false;
                    Data.PatologyType.Add((newType));
                    Data.Complete();
                    MessageBus.Default.Call("GetPatientForAddPatology", this, CurrentPatient.Id);
                    Index = PatologyTypes.Count - 1;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            });

        }
    }
}
