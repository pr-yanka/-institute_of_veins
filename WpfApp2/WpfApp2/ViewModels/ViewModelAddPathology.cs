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

        public DateTime DateAppear { get; set; }

        public DateTime DateDisappear { get; set; }

        public Patient CurrentPatient { get; set; }
        #endregion
        #region MessageBus

        private void SetCurrentPatientID(object sender, object data)
        {

            setCurrMonth(DateTime.Now.Year);
            MonthAndYearDissapearSelectedId = MonthAndYeard.Count - 1;
            YearAppear = "";
            MonthAppear = "";
            MonthDisappear = "";
            YearDisappear = "";
            isNewTypeAvalible = Visibility.Visible;
            isReadOnly = true;
            CurrentPatient = Data.Patients.Get((int)data);
            using (var context = new MySqlContext())
            {
                PatologyTypesId = new ObservableCollection<int>();
                PatologyTypes = new ObservableCollection<string>();
                ObservableCollection<PatologyType> PatologyTypesbuf = new ObservableCollection<PatologyType>();


                PatologyRepository ptRep = new PatologyRepository(context);
                PatientsRepository ptentRep = new PatientsRepository(context);
                PatologyTypeRepository PatType = new PatologyTypeRepository(context);

                foreach (var Patology in ptRep.GetAll)
                {
                    //Patology sadasew
                    if (Patology.id_пациента == CurrentPatient.Id)
                    {
                        foreach (var PatoType in PatType.GetAll)
                        {
                            if (PatoType.Id == Patology.id_патологии)
                            {
                                PatologyTypesbuf.Add(PatoType);
                            }
                        }

                    }
                }
                bool result = true;
                foreach (var PatoType in PatType.GetAll)
                {
                    result = true;

                    foreach (var PatoTypeBuff in PatologyTypesbuf)
                    {
                        if (PatoType.Id == PatoTypeBuff.Id)
                            result = false;
                    }
                    if (result == true)
                    {
                        PatologyTypes.Add(PatoType.Str);
                        PatologyTypesId.Add(PatoType.Id);
                    }
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

        private List<string> _monthAndYear;

        public List<string> MonthAndYear { get { return _monthAndYear; } set { _monthAndYear = value; OnPropertyChanged(); } }

        public ViewModelAddPathology(NavigationController controller) : base(controller)
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

                            string[] curDate = MonthAndYear[MonthAndYearSelectedId].Split(' ');

                            DateAppear = new DateTime(int.Parse(curDate[1]), getmonthName(curDate[0]), 1);
                            buff.MonthAppear = DateAppear;
                            buff.YearAppear = DateAppear;


                            if (MonthAndYeard[MonthAndYearDissapearSelectedId] != "-")
                            {
                                string[] curDatedsp = MonthAndYeard[MonthAndYearDissapearSelectedId].Split(' ');

                                DateDisappear = new DateTime(int.Parse(curDatedsp[1]), getmonthName(curDatedsp[0]), 1);
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
                        catch
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
