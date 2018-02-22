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
using System.Windows.Controls;
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


        public string TextAddOrSave { get; set; }

        public DateTime DateAppear { get; set; }

        public DateTime DateDisappear { get; set; }

        public Patient CurrentPatient { get; set; }

        public Patology CurrentPatology { get; set; }
        #endregion
        #region MessageBus


        private void rebuildMonthDissapearList()
        {
            MonthAndYeard = new ObservableCollection<string>();
            for (int i = MonthAndYearSelectedId; i < MonthAndYear.Count; ++i)
            {

                string buf = MonthAndYear[i];
                MonthAndYeard.Add(buf);


            }
            MonthAndYeard.Add("-");
            MonthAndYearDissapearSelectedId = MonthAndYeard.Count - 1;


        }
        private int _monthAndYearSelectedId;

        public int MonthAndYearSelectedId { get { return _monthAndYearSelectedId; } set { _monthAndYearSelectedId = value; OnPropertyChanged(); rebuildMonthDissapearList(); } }

        private int _monthAndYearDissapearSelectedId;

        public int MonthAndYearDissapearSelectedId { get { return _monthAndYearDissapearSelectedId; } set { _monthAndYearDissapearSelectedId = value; OnPropertyChanged(); } }


        private ObservableCollection<string> _monthAndYeard;

        public ObservableCollection<string> MonthAndYeard { get { return _monthAndYeard; } set { _monthAndYeard = value; OnPropertyChanged(); } }

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
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Январь " + i);
                    break;
                case 2:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Февраль " + i);
                    break;
                case 3:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Март " + i);
                    break;
                case 4:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Апрель " + i);
                    break;
                case 5:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Май " + i);
                    break;
                case 6:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Июнь " + i);
                    break;
                case 7:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Июль " + i);
                    break;
                case 8:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Август " + i);
                    break;
                case 9:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Сентябрь " + i);
                    break;
                case 10:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Октябрь " + i);
                    break;
                case 11:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Ноябрь " + i);
                    break;
                case 12:
                    _monthAndYearSelectedId = MonthAndYear.IndexOf("Декабрь " + i);
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
        private List<string> _monthAndYear;

        public List<string> MonthAndYear { get { return _monthAndYear; } set { _monthAndYear = value; OnPropertyChanged(); } }

        private void SetCurrentPatology(object sender, object data)
        {
            isNewTypeAvalible = Visibility.Hidden;
            isReadOnly = false;
            using (var context = new MySqlContext())
            {
                PatologyTypes = new ObservableCollection<string>();

                PatologyTypesId = new ObservableCollection<int>();


                PatologyTypeRepository PatType = new PatologyTypeRepository(context);
                PatologyRepository PatRep = new PatologyRepository(context);
                PatientsRepository PatsRep = new PatientsRepository(context);



                foreach (var Patology in PatType.GetAll)
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
                CurrentPatient = PatsRep.Get(CurrentPatology.id_пациента);

                MonthAndYearSelectedId = MonthAndYear.IndexOf(getmonthNameClassic(CurrentPatology.MonthAppear.Value.Month) + " " + CurrentPatology.YearAppear.Value.Year);

                //YearAppear = CurrentPatology.YearAppear.Value.Year.ToString();

                //MonthAppear = CurrentPatology.MonthAppear.Value.Month.ToString();

                try
                {
                    MonthAndYearDissapearSelectedId = MonthAndYeard.IndexOf(getmonthNameClassic(CurrentPatology.MonthDisappear.Value.Month) + " " + CurrentPatology.YearDisappear.Value.Year);

                    //YearDisappear = CurrentPatology.YearDisappear.Value.Year.ToString();
                    //MonthDisappear = CurrentPatology.MonthDisappear.Value.Month.ToString();
                }
                catch
                {
                    //YearDisappear = "";
                    //MonthDisappear = "";
                    MonthAndYearDissapearSelectedId = MonthAndYeard.Count - 1;
                }


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

        public ViewModelArchivePathology(NavigationController controller) : base(controller)
        {
            MonthAndYeard = new ObservableCollection<string>();
            MonthAndYear = new List<string>();

            for (int i = 1950; i <= DateTime.Now.Year; ++i)
            {


                MonthAndYear.Add("Январь " + i);
                if (DateTime.Now.Month == 1 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Февраль " + i);
                if (DateTime.Now.Month == 2 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Март " + i);
                if (DateTime.Now.Month == 3 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Апрель " + i);
                if (DateTime.Now.Month == 4 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Май " + i);
                if (DateTime.Now.Month == 5 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Июнь " + i);
                if (DateTime.Now.Month == 6 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Июль " + i);
                if (DateTime.Now.Month == 7 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Август " + i);
                if (DateTime.Now.Month == 8 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Сентябрь " + i);
                if (DateTime.Now.Month == 9 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Октябрь " + i);
                if (DateTime.Now.Month == 10 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Ноябрь " + i);
                if (DateTime.Now.Month == 11 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }
                MonthAndYear.Add("Декабрь " + i);
                if (DateTime.Now.Month == 12 && i == DateTime.Now.Year)
                {
                    setCurrMonth(i);
                    break;
                }

            }
            rebuildMonthDissapearList();

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




                    if (MonthAndYeard[MonthAndYearDissapearSelectedId] != "-")
                    {


                        foreach (var Patology in Data.Patology.GetAll)
                        {
                            if (Patology.id_пациента == CurrentPatology.id_пациента && Patology.id_патологии == CurrentPatology.id_патологии)
                            {
                                string[] curDate = MonthAndYear[MonthAndYearSelectedId].Split(' ');

                                DateAppear = new DateTime(int.Parse(curDate[1]), getmonthName(curDate[0]), 1);

                                Patology.MonthAppear = DateAppear;

                                Patology.YearAppear = DateAppear;

                                string[] curDatedsp = MonthAndYeard[MonthAndYearDissapearSelectedId].Split(' ');

                                DateDisappear = new DateTime(int.Parse(curDatedsp[1]), getmonthName(curDatedsp[0]), 1);

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
