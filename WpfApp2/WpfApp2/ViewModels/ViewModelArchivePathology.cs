using System;
using System.Collections.Generic;
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

namespace WpfApp2.ViewModels
{
    public class ViewModelArchivePathology : ViewModelBase, INotifyPropertyChanged
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
        public string ReturnBtnName { get; private set; }
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

        #endregion
        #region Bindings

        private ObservableCollection<string> _patologyTypes;
        public ObservableCollection<string> PatologyTypes { get { return _patologyTypes; } set { _patologyTypes = value; OnPropertyChanged(); } }

        private ObservableCollection<int> _patologyTypesId;
        public ObservableCollection<int> PatologyTypesId { get { return _patologyTypesId; } set { _patologyTypesId = value; OnPropertyChanged(); } }
        private bool _isReadOnly;
        public bool isReadOnly { get { return _isReadOnly; } set { _isReadOnly = value; OnPropertyChanged(); } }

        private PatologyType _patologyType;


        public PatologyType PatologyType
        {
            get { return _patologyType; }
            set
            {
                _patologyType = value; OnPropertyChanged();
            }
        }

        public string _yearAppear;
        public string _monthAppear;
        public string _monthDisappear;
        public string _yearDisappear;

        private Visibility _isNewTypeAvalible;
        public Visibility isNewTypeAvalible { get { return _isNewTypeAvalible; } set { _isNewTypeAvalible = value; OnPropertyChanged(); } }



        private Brush _yearAppearB;
        private Brush _monthAppearB;
        private Brush _yearDisappearB;
        private Brush _monthDisappearB;

        public Brush YearAppearB { get { return _yearAppearB; } set { _yearAppearB = value; OnPropertyChanged(); } }
        public Brush MonthAppearB { get { return _monthAppearB; } set { _monthAppearB = value; OnPropertyChanged(); } }
        public Brush YearDisappearB { get { return _yearDisappearB; } set { _yearDisappearB = value; OnPropertyChanged(); } }
        public Brush MonthDisappearB { get { return _monthDisappearB; } set { _monthDisappearB = value; OnPropertyChanged(); } }
        private int _index = 1;

        public int Index { get { return _index; } set { _index = value; OnPropertyChanged(); } }
        public string YearAppear { get { return _yearAppear; } set { _yearAppear = value; } }
        public string MonthAppear { get { return _monthAppear; } set { _monthAppear = value; } }
        public string MonthDisappear { get { return _monthDisappear; } set { _monthDisappear = value; } }
        public string YearDisappear { get { return _yearDisappear; } set { _yearDisappear = value; } }
  

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

        public string TextAddOrSave { get; set; }

        public DateTime DateAppear { get; set; }

        public DateTime DateDisappear { get; set; }

        public Patient CurrentPatient { get; set; }

        public Patology CurrentPatology { get; set; }
        #endregion
        #region MessageBus

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
                else if (Yeard.Count != 0 && Year.Count != 0 && MonthSelectedId != -1)
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
        private int _yearSelectedId;

        public int YearSelectedId { get { return _yearSelectedId; } set { _yearSelectedId = value; RebuildMonthList(); rebuildYearDissapearList(); OnPropertyChanged(); } }

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
        private string getmonthNameClassic(int number)
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

        private void SetCurrentPatology(object sender, object data)
        {
            isNewTypeAvalible = Visibility.Hidden;
            isReadOnly = false;
            PatologyTypes = new ObservableCollection<string>();

            PatologyTypesId = new ObservableCollection<int>();

            foreach (var Patology in Data.PatologyType.GetAll)
            {
                PatologyTypes.Add(Patology.Str);
                PatologyTypesId.Add(Patology.Id);
            }

            CurrentPatology = (Patology)data;
            foreach (var Patology in PatologyTypesId)
            {
                if (CurrentPatology.id_патологии == Patology)
                {
                    Index = PatologyTypesId.IndexOf(Patology);
                    break;
                }
            }
            CurrentPatient = Data.Patients.Get(CurrentPatology.id_пациента);

            MonthSelectedId = Month.IndexOf(getmonthNameClassic(CurrentPatology.MonthAppear.Value.Month));

            YearSelectedId = Year.IndexOf(CurrentPatology.YearAppear.Value.Year.ToString());

            try
            {
                MonthDissapearSelectedId = Monthd.IndexOf(getmonthNameClassic(CurrentPatology.MonthDisappear.Value.Month));
                YearDissapearSelectedId = Yeard.IndexOf(CurrentPatology.YearDisappear.Value.Year.ToString());

            }
            catch
            {
                MonthDissapearSelectedId = Monthd.Count - 1;
                YearDissapearSelectedId = Yeard.Count - 1;
            }
        }
        #endregion
        #region DelegateCommands
        public DelegateCommand ToPathologyListCommand { get; protected set; }
        public DelegateCommand ToPathologyListNoSaveCommands { get; protected set; }
        #endregion



        private bool testTime()
        {
            bool result = true;
            try
            {
                DateAppear = new DateTime(int.Parse(YearAppear), 1, 1);
                YearAppearB = Brushes.Gray;
            }
            catch
            {
                YearAppearB = Brushes.Red;
                result = false;
            }
            try
            {
                DateAppear = new DateTime(1, int.Parse(MonthAppear), 1);
                MonthAppearB = Brushes.Gray;
            }
            catch
            {
                MonthAppearB = Brushes.Red;
                result = false;
            }
            if (!String.IsNullOrEmpty(MonthDisappear) && String.IsNullOrEmpty(YearDisappear))
            {
                YearDisappearB = Brushes.Red;
                result = false;
            }
            else if (String.IsNullOrEmpty(MonthDisappear) && !String.IsNullOrEmpty(YearDisappear))
            {
                MonthDisappearB = Brushes.Red;
                result = false;
            }
            else if (!String.IsNullOrEmpty(MonthDisappear) && !String.IsNullOrEmpty(YearDisappear))
            {
                try
                {
                    DateDisappear = new DateTime(1, int.Parse(MonthDisappear), 1);
                    MonthDisappearB = Brushes.Gray;
                }
                catch
                {
                    MonthDisappearB = Brushes.Red;
                    result = false;
                }
                try
                {
                    DateDisappear = new DateTime(int.Parse(YearDisappear), 1, 1);
                    YearDisappearB = Brushes.Gray;
                }
                catch
                {
                    YearDisappearB = Brushes.Red;
                    result = false;
                }
                try
                {
                    DateDisappear = new DateTime(int.Parse(YearDisappear), int.Parse(MonthDisappear), 1);
                    YearDisappearB = Brushes.Gray;
                    MonthDisappearB = Brushes.Gray;
                }
                catch
                {
                    YearDisappearB = Brushes.Red;
                    MonthDisappearB = Brushes.Red;
                    result = false;
                }
            }
            else
            {
                YearDisappearB = Brushes.Red;
                MonthDisappearB = Brushes.Red;
                result = false;
            }
            return result;
        }
        private ObservableCollection<string> _month;

        public ObservableCollection<string> Month { get { return _month; } set { _month = value; OnPropertyChanged(); } }

        private List<string> _year;

        public List<string> Year { get { return _year; } set { _year = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _monthd;

        public ObservableCollection<string> Monthd { get { return _monthd; } set { _monthd = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _yeard;

        public ObservableCollection<string> Yeard { get { return _yeard; } set { _yeard = value; OnPropertyChanged(); } }


        public ViewModelArchivePathology(NavigationController controller) : base(controller)
        {
            Monthd = new ObservableCollection<string>();
            Yeard = new ObservableCollection<string>();
            Month = new ObservableCollection<string>();
            Year = new List<string>();

            // MonthAndYear = new List<string>();

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

            TextAddOrSave = "В архив";
            YearAppearB = Brushes.Gray;
            MonthAppearB = Brushes.Gray;
            PatologyType = new PatologyType();
            DateAppear = DateTime.Now;
            DateDisappear = DateTime.Now;
            MessageBus.Default.Subscribe("GetPatologyForArchivePatology", SetCurrentPatology);
            HasNavigation = false;
            CurrentPanelViewModel = new PatologyTypePanelViewModel(this);
            OpenPanelCommand = new DelegateCommand(() =>
            {

                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });


            ReturnBtnName = "Вернуться";

            ToPathologyListCommand = new DelegateCommand(
                () =>
                {




                    if (Monthd[MonthDissapearSelectedId] != "-" && Yeard[YearDissapearSelectedId] != "-")
                    {


                        foreach (var Patology in Data.Patology.GetAll)
                        {
                            if (Patology.id == CurrentPatology.id)
                            {
                                DateAppear = new DateTime(int.Parse(Year[YearSelectedId]), getmonthName(Month[MonthSelectedId]), 1);

                                Patology.MonthAppear = DateAppear;

                                Patology.YearAppear = DateAppear;

                                DateDisappear = new DateTime(int.Parse(Yeard[YearDissapearSelectedId]), getmonthName(Monthd[MonthDissapearSelectedId]), 1);

                                Patology.MonthDisappear = DateDisappear;

                                Patology.YearDisappear = DateDisappear;

                                Patology.isArchivatied = true;

                                break;
                            }
                        }

                        Data.Complete();
                        MessageBus.Default.Call("GetPatientForPatology", this, CurrentPatient.Id);
                        Controller.NavigateTo<ViewModelPathologyList>();
                    }
                    else
                    {
                        MessageBox.Show("Укажите дату исчезновения");
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
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
                var newType = CurrentPanelViewModel.GetPanelType();
                Data.PatologyType.Add((newType));
                Data.Complete();
                MessageBus.Default.Call("GetPatologyForRedactPatology", this, CurrentPatology);
            });

        }
    }
}
