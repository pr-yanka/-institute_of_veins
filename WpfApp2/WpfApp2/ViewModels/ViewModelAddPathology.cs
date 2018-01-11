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
            Index = 1;

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
            }
            else if (String.IsNullOrEmpty(MonthDisappear) && !String.IsNullOrEmpty(YearDisappear))
            {
                MonthDisappearB = Brushes.Red;
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
            }
            return result;
        }

        public ViewModelAddPathology(NavigationController controller) : base(controller)
        {

            TextAddOrSave = "Добавить";
            YearAppearB = Brushes.Gray;
            MonthAppearB = Brushes.Gray;
            DateAppear = DateTime.Now;
            DateDisappear = DateTime.Now;
            MessageBus.Default.Subscribe("GetPatientForAddPatology", SetCurrentPatientID);
            HasNavigation = false;
            CurrentPanelViewModel = new PatologyTypePanelViewModel(this);
            OpenPanelCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });



            ToPathologyListCommand = new DelegateCommand(
                () =>
                {




                    if (testTime())
                    {
                        Patology buff = new Patology();
                        DateAppear = new DateTime(int.Parse(YearAppear), int.Parse(MonthAppear), 1);
                        buff.MonthAppear = DateAppear;
                        buff.YearAppear = DateAppear;
                        if (!String.IsNullOrEmpty(MonthDisappear) && !String.IsNullOrEmpty(YearDisappear))
                        {
                            DateDisappear = new DateTime(int.Parse(YearDisappear), int.Parse(MonthDisappear), 1);
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
