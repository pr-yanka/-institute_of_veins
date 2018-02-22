using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class SpecDataSoursForEdit : INotifyPropertyChanged
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
            set { _isChecked = value; MessageBus.Default.Call("UpdateNameOfButtonForEditDoctor", this, ""); OnPropertyChanged(); }
        }
        public string Name { get; set; }
        public int id { get; set; }


        public SpecDataSoursForEdit(string Name, int id)
        {
            this.Name = Name;
            this.id = id;
            IsChecked = false;

        }

    }

    public class ViewModelEditDoctor : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand SaveAndGoDoctorListCommand { get; protected set; }
        public DelegateCommand GoToDoctorListCommand { get; }
        #endregion
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
        #region Bindings
        private ObservableCollection<SpecDataSoursForEdit> _specializationsOld;
        private ObservableCollection<SpecDataSoursForEdit> _scintificsOld;
        private ObservableCollection<SpecDataSoursForEdit> _specializations;
        private ObservableCollection<SpecDataSoursForEdit> _scintifics;
        private ObservableCollection<СategoryType> _category;
        private int _categorySelectedId;

        public int CategorySelectedId { get { return _categorySelectedId; } set { _categorySelectedId = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public ObservableCollection<СategoryType> Category { get { return _category; } set { _category = value; OnPropertyChanged(); } }

        private СategoryType _categoryTypeSelected;
        public СategoryType СategoryTypeSelected { get { return _categoryTypeSelected; } set { _categoryTypeSelected = value; OnPropertyChanged(); } }
        public DelegateCommand<object> ClickOnAutoComplete { get; set; }
        private string _categoryTypeSelectedText;
        public string СategoryTypeSelectedText { get { return _categoryTypeSelectedText; } set { _categoryTypeSelectedText = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public ObservableCollection<SpecDataSoursForEdit> SpecializationsOld { get { return _specializationsOld; } set { _specializationsOld = value; OnPropertyChanged(); } }
        public ObservableCollection<SpecDataSoursForEdit> ScintificsOld { get { return _scintificsOld; } set { _scintificsOld = value; OnPropertyChanged(); } }
        public ObservableCollection<SpecDataSoursForEdit> Specializations { get { return _specializations; } set { _specializations = value; OnPropertyChanged(); } }
        public ObservableCollection<SpecDataSoursForEdit> Scintifics { get { return _scintifics; } set { _scintifics = value; OnPropertyChanged(); } }

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
        public string Aditional { get { return _aditional; } set { _aditional = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }


        public string Name { get { return _name; } set { _name = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public string Surname { get { return _surname; } set { _surname = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }



        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;
        private Brush _textBox_Category_B;

        public Brush TextBoxCategoryB { get { return _textBox_Category_B; } set { _textBox_Category_B = value; OnPropertyChanged(); } }

        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }

        public Brush TextBoxPatronimicB { get { return _textBox_Patronimic_B; } set { _textBox_Patronimic_B = value; OnPropertyChanged(); } }
        #endregion

        #region MessageBus
        private void UpdateNameOfButton(object sender, object data)
        {
            nameOfButton = "Сохранить";
        }

        private void GetCurrentDoctor(object sender, object data)
        {

            using (var context = new MySqlContext())
            {
                Category = new ObservableCollection<СategoryType>();
                Specializations = new ObservableCollection<SpecDataSoursForEdit>();
                Scintifics = new ObservableCollection<SpecDataSoursForEdit>();
                SpecializationsOld = new ObservableCollection<SpecDataSoursForEdit>();
                ScintificsOld = new ObservableCollection<SpecDataSoursForEdit>();
                СategoryTypeRepository ctRep = new СategoryTypeRepository(context);
                DoctorRepository dcRep = new DoctorRepository(context);
                SpecializationTypeRepository spRep = new SpecializationTypeRepository(context);
                ScientificTitleTypeRepository scRep = new ScientificTitleTypeRepository(context);

                DoctorsSpecializationsRepository dcspRep = new DoctorsSpecializationsRepository(context);
                ScientificTitlesRepository dcscRep = new ScientificTitlesRepository(context);


                currentDoctor = dcRep.Get((int)data);
                Name = currentDoctor.Name;
                Surname = currentDoctor.Sirname;
                Patronimic = currentDoctor.Patronimic;
                Aditional = currentDoctor.Aditional;
                foreach (var category in ctRep.GetAll)
                {
                    Category.Add(category);
                    if (category.Id == currentDoctor.категория)
                    {
                        CategorySelectedId = Category.IndexOf(category);
                        СategoryTypeSelectedText = Category[Category.IndexOf(category)].Str;
                        СategoryTypeSelected = Category[Category.IndexOf(category)];
                    }
                }



                foreach (var spec in spRep.GetAll)
                {
                    Specializations.Add(new SpecDataSoursForEdit(spec.Str, spec.id_специлизации));
                    SpecializationsOld.Add(new SpecDataSoursForEdit(spec.Str, spec.id_специлизации));
                }

                foreach (var title in scRep.GetAll)
                {
                    Scintifics.Add(new SpecDataSoursForEdit(title.Str, title.Id));
                    ScintificsOld.Add(new SpecDataSoursForEdit(title.Str, title.Id));
                }

                foreach (var dcsp in dcspRep.GetAll)
                {
                    if (dcsp.id_врача == currentDoctor.Id)
                    {
                        foreach (var spec in SpecializationsOld)
                        {
                            if (spec.id == dcsp.id_специлизации)
                            {
                                spec.IsChecked = true;
                            }
                        }
                    }
                }

                foreach (var dcsc in dcscRep.GetAll)
                {
                    if (dcsc.id_врача == currentDoctor.Id)
                    {
                        foreach (var title in ScintificsOld)
                        {
                            if (title.id == dcsc.id_звания)
                            {
                                title.IsChecked = true;
                            }
                        }
                    }
                }

                foreach (var dcsp in dcspRep.GetAll)
                {
                    if (dcsp.id_врача == currentDoctor.Id)
                    {
                        foreach (var spec in Specializations)
                        {
                            if (spec.id == dcsp.id_специлизации)
                            {
                                spec.IsChecked = true;
                            }
                        }
                    }
                }

                foreach (var dcsc in dcscRep.GetAll)
                {
                    if (dcsc.id_врача == currentDoctor.Id)
                    {
                        foreach (var title in Scintifics)
                        {
                            if (title.id == dcsc.id_звания)
                            {
                                title.IsChecked = true;
                            }
                        }
                    }
                }
                nameOfButton = "К списку врачей";
            }
        }


        #endregion

        private bool TestRequiredFields()
        {
            bool result = true;



            if (string.IsNullOrWhiteSpace(СategoryTypeSelectedText))
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
            TextBoxCategoryB = Brushes.Gray;

            TextBoxNameB = Brushes.Gray;

            TextBoxSurnameB = Brushes.Gray;

            TextBoxPatronimicB = Brushes.Gray;

        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ViewModelEditDoctor(NavigationController controller) : base(controller)
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
                    Specializations = new ObservableCollection<SpecDataSoursForEdit>();

                    foreach (var spec in Data.SpecializationType.GetAll)
                    {
                        Specializations.Add(new SpecDataSoursForEdit(spec.Str, spec.id_специлизации));
                    }

                    foreach (var spec in DataSourceListbuf)
                    {
                        if (spec.IsChecked.Value)
                        {
                            Specializations.Where(s => s.id == spec.id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelEditDoctor>();
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
                    Scintifics = new ObservableCollection<SpecDataSoursForEdit>();

                    foreach (var Scintific in Data.ScientificTitleType.GetAll)
                    {
                        Scintifics.Add(new SpecDataSoursForEdit(Scintific.Str, Scintific.Id));
                    }

                    foreach (var Scintific in DataSourceListbuf)
                    {
                        if (Scintific.IsChecked.Value)
                        {
                            Scintifics.Where(s => s.id == Scintific.id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelEditDoctor>();
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

              buf.FilterMode = AutoCompleteFilterMode.None;

          }
          );
            MessageBus.Default.Subscribe("UpdateNameOfButtonForEditDoctor", UpdateNameOfButton);
            MessageBus.Default.Subscribe("GetDoctorForEditDoctor", GetCurrentDoctor);
            //Date = DateTime.Now;
            base.HasNavigation = true;

            TextHeader = "Редактирование врача";

            nameOfButton = "К списку врачей";

            SetAllFieldsDefault();
            ToDashboardCommand = new DelegateCommand(
              () =>
              {
                  MessageBus.Default.Call("GetDoctorForEditDoctor", this, currentDoctor.Id);
              }
          );

            SaveAndGoDoctorListCommand = new DelegateCommand(
                () =>
                {
                    if (TestRequiredFields())
                    {

                        Doctor bufDoc = Data.Doctor.Get(currentDoctor.Id);
                        bufDoc.Name = Name;
                        bufDoc.Sirname = Surname;
                        bufDoc.Patronimic = Patronimic;
                        bufDoc.Aditional = Aditional;

                        bool test = true;
                        foreach (var Category in Data.СategoryType.GetAll)
                        {
                            if (Category.Str == СategoryTypeSelectedText)
                            {
                                test = false;
                                bufDoc.категория = Category.Id;
                                break;
                            }
                        }
                        if (test)
                        {
                            СategoryType newСategory = new СategoryType();
                            newСategory.Str = СategoryTypeSelectedText;
                            Data.СategoryType.Add(newСategory);
                            Data.Complete();
                            bufDoc.категория = newСategory.Id;
                            Data.Complete();

                        }
                        // bufDoc.категория = CategorySelectedId;
                        Data.Complete();

                        bool specTestbuf = false;
                        foreach (var specOld in SpecializationsOld)
                        {
                            if (specOld.IsChecked == true)
                            {
                                specTestbuf = false;
                                foreach (var spec in Specializations)
                                {
                                    if (specOld.Name == spec.Name && spec.IsChecked == true)
                                    {
                                        specTestbuf = true;
                                        break;
                                    }
                                }
                                if (specTestbuf == false)
                                {

                                    foreach (var doctorSpec in Data.DoctorsSpecializations.GetAll)
                                    {
                                        if (doctorSpec.id_врача == currentDoctor.Id && doctorSpec.id_специлизации == specOld.id)
                                        {
                                            Data.DoctorsSpecializations.Remove(doctorSpec);
                                            Data.Complete();

                                            specOld.IsChecked = false;
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        //     Data.Complete();
                        foreach (var spec in Specializations)
                        {
                            if (spec.IsChecked == true)
                            {
                                specTestbuf = false;
                                foreach (var specOld in SpecializationsOld)
                                {
                                    if (specOld.Name == spec.Name && specOld.IsChecked == true)
                                    {
                                        specTestbuf = true;
                                        break;
                                    }
                                }
                                if (specTestbuf == false)
                                {
                                    DoctorsSpecializations bufDS = new DoctorsSpecializations();
                                    bufDS.id_врача = currentDoctor.Id;
                                    bufDS.id_специлизации = spec.id;
                                    Data.DoctorsSpecializations.Add(bufDS);
                                    Data.Complete();

                                }
                            }
                        }







                        //
                        foreach (var specOld in ScintificsOld)
                        {
                            if (specOld.IsChecked == true)
                            {
                                specTestbuf = false;
                                foreach (var spec in Scintifics)
                                {
                                    if (specOld.Name == spec.Name && spec.IsChecked == true)
                                    {
                                        specTestbuf = true;
                                        break;
                                    }
                                }
                                if (specTestbuf == false)
                                {

                                    foreach (var doctorSpec in Data.ScientificTitles.GetAll)
                                    {
                                        if (doctorSpec.id_врача == currentDoctor.Id && doctorSpec.id_звания == specOld.id)
                                        {
                                            Data.ScientificTitles.Remove(doctorSpec);
                                            Data.Complete();

                                            specOld.IsChecked = false;
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        Data.Complete();
                        foreach (var spec in Scintifics)
                        {
                            if (spec.IsChecked == true)
                            {
                                specTestbuf = false;
                                foreach (var specOld in ScintificsOld)
                                {
                                    if (specOld.Name == spec.Name && specOld.IsChecked == true)
                                    {
                                        specTestbuf = true;
                                        break;
                                    }
                                }
                                if (specTestbuf == false)
                                {
                                    ScientificTitles bufDS = new ScientificTitles();
                                    bufDS.id_врача = currentDoctor.Id;
                                    bufDS.id_звания = spec.id;
                                    Data.ScientificTitles.Add(bufDS);
                                    Data.Complete();

                                }
                            }
                        }

                        //    Data.Complete();

                        MessageBus.Default.Call("OpenDoctors", this, "");
                        Controller.NavigateTo<ViewModelViewDoctors>();
                    }
                    else
                    {

                        MessageBox.Show("Не все поля заполнены");
                    }

                }
            );
            GoToDoctorListCommand = new DelegateCommand(
() =>
{

    MessageBus.Default.Call("OpenDoctors", this, "");
    Controller.NavigateTo<ViewModelViewDoctors>();


}
);
        }
    }
}
