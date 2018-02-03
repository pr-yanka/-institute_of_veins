using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.ViewModels
{

    public class SpecDataSours : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool? _isChecked;
        public bool? IsChecked
        {
            get
            {
                if (_isChecked == null)
                    return false;
                else return _isChecked;
            }
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public string Name { get; set; }
        public int id { get; set; }


        public SpecDataSours(string Name, int id)
        {
            this.Name = Name;
            this.id = id;
            IsChecked = false;
        }

    }


    public class ViewModelAddDoctor : ViewModelBase, INotifyPropertyChanged
    {
        #region everyth connected with panel
        public DelegateCommand RevertSpecCommand { set; get; }
        public DelegateCommand RevertScintificsCommand { set; get; }
        public DelegateCommand SaveSpecCommand { set; get; }
        public DelegateCommand SaveScintificsCommand { set; get; }
        public ICommand OpenAddSpecCommand { protected set; get; }
        public ICommand OpenAddScintificsCommand { protected set; get; }
        public SpecPanelViewModel CurrentSpecPanelViewModel { get; protected set; }
        public ScintificsPanelViewModel CurrentScintificsPanelViewModel { get; protected set; }
        public static bool Handled = false;
        public UIElement UI;
        //private void OpenHandler(object sender, object data)
        //{
        //    if (!Handled)
        //    {
        //        Handled = true;
        //        CurrentSpecPanelViewModel.PanelOpened = true;
        //    }
        //}

        #endregion

        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand SaveAndGoDoctorListCommand { get; protected set; }
        #endregion
        #region Bindings
        private ObservableCollection<SpecDataSours> _specializations;
        private ObservableCollection<SpecDataSours> _scintifics;
        private ObservableCollection<СategoryType> _category;
        private int _categorySelectedId;
        public int CategorySelectedId { get { return _categorySelectedId; } set { _categorySelectedId = value; OnPropertyChanged(); } }
        private СategoryType _categoryTypeSelected;
        private string _categoryTypeSelectedText;
        public string СategoryTypeSelectedText { get { return _categoryTypeSelectedText; } set { _categoryTypeSelectedText = value; OnPropertyChanged(); } }

        public СategoryType СategoryTypeSelected { get { return _categoryTypeSelected; } set { _categoryTypeSelected = value; OnPropertyChanged(); } }
        public ObservableCollection<СategoryType> Category { get { return _category; } set { _category = value; OnPropertyChanged(); } }
        public DelegateCommand<object> ClickOnAutoComplete { get; set; }
        public ObservableCollection<SpecDataSours> Specializations { get { return _specializations; } set { _specializations = value; OnPropertyChanged(); } }
        public ObservableCollection<SpecDataSours> Scintifics { get { return _scintifics; } set { _scintifics = value; OnPropertyChanged(); } }
        public string _nameOfButton;
        public string nameOfButton { get { return _nameOfButton; } set { _nameOfButton = value; OnPropertyChanged(); } }
        //public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private Doctor currentDoctor;
        //public DelegateCommand Changed { get; protected set; }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }
        private string _aditional;

        private string _name;
        private string _surname;
        private string _patronimic;
        public string Aditional { get { return _aditional; } set { _aditional = value; OnPropertyChanged(); } }


        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; OnPropertyChanged(); } }



        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;
        private Brush _textBox_Category_B;
        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxCategoryB { get { return _textBox_Category_B; } set { _textBox_Category_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }

        public Brush TextBoxPatronimicB { get { return _textBox_Patronimic_B; } set { _textBox_Patronimic_B = value; OnPropertyChanged(); } }
        #endregion
        #region MessageBus

        private void RefreshDataForDoctors(object sender, object data)
        {

            using (var context = new MySqlContext())
            {
                Category = new ObservableCollection<СategoryType>();
                Specializations = new ObservableCollection<SpecDataSours>();
                Scintifics = new ObservableCollection<SpecDataSours>();
                СategoryTypeRepository ctRep = new СategoryTypeRepository(context);
                SpecializationTypeRepository spRep = new SpecializationTypeRepository(context);
                ScientificTitleTypeRepository scRep = new ScientificTitleTypeRepository(context);

                foreach (var category in ctRep.GetAll)
                {
                    Category.Add(category);
                }

                foreach (var spec in spRep.GetAll)
                {
                    Specializations.Add(new SpecDataSours(spec.Str, spec.id_специлизации));
                }

                foreach (var title in scRep.GetAll)
                {
                    Scintifics.Add(new SpecDataSours(title.Str, title.Id));
                }
                CategorySelectedId = 0;
                СategoryTypeSelected = Category[CategorySelectedId];
                //СategoryTypeSelectedText = СategoryTypeSelected.Str;
            }
        }
        #endregion
        private bool TestRequiredFields()
        {
            bool result = true;

            if(string.IsNullOrWhiteSpace(СategoryTypeSelectedText))
            {
                MessageBox.Show("Категория не выбрана");
                TextBoxCategoryB = Brushes.Red;
                result = false;
            }

            if (String.IsNullOrWhiteSpace(Name))
            {
                TextBoxNameB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(Surname))
            {
                TextBoxSurnameB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(Patronimic))
            {
                TextBoxPatronimicB = Brushes.Red;

                result = false;
            }
           
            return result;
        }
        public void SetAllFieldsDefault()
        {
            TextBoxNameB = Brushes.Gray;

            TextBoxSurnameB = Brushes.Gray;

            TextBoxPatronimicB = Brushes.Gray;
            TextBoxCategoryB = Brushes.Gray;

        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ViewModelAddDoctor(NavigationController controller) : base(controller)
        {


            CurrentSpecPanelViewModel = new SpecPanelViewModel(this);
            OpenAddSpecCommand = new DelegateCommand(() =>
            {
                CurrentSpecPanelViewModel.ClearPanel();
                CurrentSpecPanelViewModel.PanelOpened = true;
            });

            SaveSpecCommand = new DelegateCommand(() =>
            {
                var newType = CurrentSpecPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentSpecPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.SpecializationType.Add((newType));

                    Data.Complete();

                    var DataSourceListbuf = Specializations;
                    Specializations = new ObservableCollection<SpecDataSours>();
                  
                    foreach (var spec in Data.SpecializationType.GetAll)
                    {
                        Specializations.Add(new SpecDataSours(spec.Str, spec.id_специлизации));
                    }

                    foreach (var spec in DataSourceListbuf)
                    {
                        if (spec.IsChecked.Value)
                        {
                            Specializations.Where(s => s.id == spec.id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelAddDoctor>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertSpecCommand = new DelegateCommand(() =>
            {
                CurrentSpecPanelViewModel.PanelOpened = false;
                Handled = false;
            });


            CurrentScintificsPanelViewModel = new ScintificsPanelViewModel(this);
            OpenAddScintificsCommand = new DelegateCommand(() =>
            {
                CurrentScintificsPanelViewModel.ClearPanel();
                CurrentScintificsPanelViewModel.PanelOpened = true;
            });

            SaveScintificsCommand = new DelegateCommand(() =>
            {
                var newType = CurrentScintificsPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentScintificsPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.ScientificTitleType.Add((newType));

                    Data.Complete();

                    var DataSourceListbuf = Scintifics;
                    Scintifics = new ObservableCollection<SpecDataSours>();

                    foreach (var Scintific in Data.ScientificTitleType.GetAll)
                    {
                        Scintifics.Add(new SpecDataSours(Scintific.Str, Scintific.Id));
                    }

                    foreach (var Scintific in DataSourceListbuf)
                    {
                        if (Scintific.IsChecked.Value)
                        {
                            Scintifics.Where(s => s.id == Scintific.id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelAddDoctor>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertScintificsCommand = new DelegateCommand(() =>
            {
                CurrentScintificsPanelViewModel.PanelOpened = false;
                Handled = false;
            });











            ClickOnAutoComplete = new DelegateCommand<object>(
            (sender) =>
            {
             var buf = (AutoCompleteBox)sender;
             buf.IsDropDownOpen = true;

            }
            );
            MessageBus.Default.Subscribe("RefreshDataForNewDoctors", RefreshDataForDoctors);
            //Date = DateTime.Now;
            base.HasNavigation = true;

            TextHeader = "Добавление врача";

            nameOfButton = "Добавить";

            SetAllFieldsDefault();
            ToDashboardCommand = new DelegateCommand(
              () =>
              {
                  Name = "";
                  Surname = "";
                  Patronimic = "";
                  Aditional = "";
                  MessageBus.Default.Call("RefreshDataForNewDoctors", this, "");
              }
          );

            SaveAndGoDoctorListCommand = new DelegateCommand(
                () =>
                {
                    if (TestRequiredFields())
                    {
                        currentDoctor = new Doctor();
                        bool test = true;
                        foreach (var Category in Data.СategoryType.GetAll)
                        {
                            if (Category.Str == СategoryTypeSelectedText)
                            {
                                test = false;
                                currentDoctor.категория = Category.Id;
                                break;
                            }
                        }
                        if (test)
                        {
                            СategoryType newСategory = new СategoryType();
                            newСategory.Str = СategoryTypeSelectedText;
                            Data.СategoryType.Add(newСategory);
                            Data.Complete();
                            currentDoctor.категория = newСategory.Id;
                        }
                     
                        currentDoctor.Name = Name;
                        currentDoctor.Sirname = Surname;
                        currentDoctor.Patronimic = Patronimic;
                        currentDoctor.Aditional = Aditional;
                        currentDoctor.isEnabled = true;
                  
                        Data.Doctor.Add(currentDoctor);
                        Data.Complete();
                        foreach (var spec in Specializations)
                        {
                            if (spec.IsChecked == true)
                            {
                                DoctorsSpecializations DoctorSpec = new DoctorsSpecializations();
                                DoctorSpec.id_врача = currentDoctor.Id;
                                DoctorSpec.id_специлизации = spec.id;
                                Data.DoctorsSpecializations.Add(DoctorSpec);
                                Data.Complete();

                            }

                        }
                        Data.Complete();
                        foreach (var Tytle in Scintifics)
                        {
                            if (Tytle.IsChecked == true)
                            {
                                ScientificTitles DoctorTitle = new ScientificTitles();
                                DoctorTitle.id_врача = currentDoctor.Id;
                                DoctorTitle.id_звания = Tytle.id;
                                Data.ScientificTitles.Add(DoctorTitle);

                            }

                        }
                        Data.Complete();
                        MessageBus.Default.Call("OpenDoctors", this, "");
                        Controller.NavigateTo<ViewModelViewDoctors>();
                    }
                    else
                    {

                        MessageBox.Show("Не все поля заполнены");
                    }

                }
            );

        }
    }
}
