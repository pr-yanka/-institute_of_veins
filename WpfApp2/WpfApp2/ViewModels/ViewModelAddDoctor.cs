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
            set { _isChecked = value;  OnPropertyChanged(); }
        }
        public string Name { get; set; }
        public int id { get; set; }


        public SpecDataSours(string Name,int id)
        {
            this.Name = Name;
            this.id = id;
            IsChecked = false;
        }

    }


    public class ViewModelAddDoctor : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand SaveAndGoDoctorListCommand { get; protected set; }
        #endregion
        #region Bindings
        private ObservableCollection<SpecDataSours> _specializations;
        private ObservableCollection<SpecDataSours> _scintifics;

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

        public string Patronimic { get { return _patronimic; } set { _patronimic = value;  OnPropertyChanged(); } }
       


        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;
     
        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }

        public Brush TextBoxPatronimicB { get { return _textBox_Patronimic_B; } set { _textBox_Patronimic_B = value; OnPropertyChanged(); } }
        #endregion

        #region MessageBus

        private void RefreshDataForDoctors(object sender, object data)
        {

            using (var context = new MySqlContext())
            {

                Specializations = new ObservableCollection<SpecDataSours>();
                Scintifics = new ObservableCollection<SpecDataSours>();
                SpecializationTypeRepository spRep = new SpecializationTypeRepository(context);
                ScientificTitleTypeRepository scRep = new ScientificTitleTypeRepository(context);

                foreach(var spec in spRep.GetAll)
                {
                    Specializations.Add(new SpecDataSours(spec.Str,spec.id_специлизации));
                }

                foreach (var title in scRep.GetAll)
                {
                    Scintifics.Add(new SpecDataSours(title.Str, title.Id));
                }

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
            //var CauntSpecializations = 0;
            //var CauntScintifics = 0;
            //foreach (var spec in Specializations)
            //{
            //    if (spec.IsChecked == true)
            //    {
            //        CauntSpecializations++;

            //    }

            //}
          
            //foreach (var Tytle in Scintifics)
            //{
            //    if (Tytle.IsChecked == true)
            //    {
            //        CauntScintifics++;

            //    }

            //}
            //if (CauntSpecializations == 0 || CauntScintifics == 0)
            //{

            //    result = false;
            //}
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
        public ViewModelAddDoctor(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("RefreshDataForNewDoctors", RefreshDataForDoctors);
            //Date = DateTime.Now;
            base.HasNavigation = true;
         
            TextHeader = "Добавление врача";
         
            nameOfButton = "Добавить";
         
            SetAllFieldsDefault();
            ToDashboardCommand = new DelegateCommand(
              () =>
              {
                  MessageBus.Default.Call("RefreshDataForNewDoctors", this,"");
              }
          );
           
            SaveAndGoDoctorListCommand = new DelegateCommand(
                () =>
                {
                   if(TestRequiredFields())
                    {
                        currentDoctor = new Doctor();
                        currentDoctor.Name = Name;
                        currentDoctor.Sirname = Surname;
                        currentDoctor.Patronimic = Patronimic;
                        currentDoctor.Aditional = Aditional;
                        currentDoctor.isEnabled = true;
                        Data.Doctor.Add(currentDoctor);
                        Data.Complete();
                        foreach(var spec in Specializations)
                        {
                            if(spec.IsChecked == true)
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
