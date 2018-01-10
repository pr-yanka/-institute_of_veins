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
        #endregion

        #region Bindings
        private ObservableCollection<SpecDataSoursForEdit> _specializationsOld;
        private ObservableCollection<SpecDataSoursForEdit> _scintificsOld;
        private ObservableCollection<SpecDataSoursForEdit> _specializations;
        private ObservableCollection<SpecDataSoursForEdit> _scintifics;

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
        public string Aditional { get { return _aditional; } set { _aditional = value; nameOfButton = "Сохранить"; OnPropertyChanged();  } }


        public string Name { get { return _name; } set { _name = value; nameOfButton = "Сохранить"; OnPropertyChanged();  } }

        public string Surname { get { return _surname; } set { _surname = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }



        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;

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

                Specializations = new ObservableCollection<SpecDataSoursForEdit>();
                Scintifics = new ObservableCollection<SpecDataSoursForEdit>();
                SpecializationsOld = new ObservableCollection<SpecDataSoursForEdit>();
                ScintificsOld = new ObservableCollection<SpecDataSoursForEdit>();
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
            var CauntSpecializations = 0;
            var CauntScintifics = 0;
            foreach (var spec in Specializations)
            {
                if (spec.IsChecked == true)
                {
                    CauntSpecializations++;

                }

            }

            foreach (var Tytle in Scintifics)
            {
                if (Tytle.IsChecked == true)
                {
                    CauntScintifics++;

                }

            }
            if (CauntSpecializations == 0 || CauntScintifics == 0)
            {

                result = false;
            }
            return result;
        }

        public void SetAllFieldsDefault()
        {
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
                                        if(doctorSpec.id_врача == currentDoctor.Id && doctorSpec.id_специлизации == specOld.id)
                                        {
                                            Data.DoctorsSpecializations.Remove(doctorSpec);
                                            specOld.IsChecked = false;
                                            break;
                                        }
                                    }
                                
                                }
                            }
                        }
                        Data.Complete();
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
                                }
                            }
                        }

                        Data.Complete();






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
                                }
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
