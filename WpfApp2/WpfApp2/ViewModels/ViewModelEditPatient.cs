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

namespace WpfApp2.ViewModels
{
    public class ViewModelEditPatient : ViewModelBase, INotifyPropertyChanged
    {
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public string _nameOfButton;
        public string nameOfButton { get { return _nameOfButton; } set { _nameOfButton = value; OnPropertyChanged("nameOfButton"); } }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private Patient currentPatient;
        public DelegateCommand Changed { get; protected set; }
        private Visibility _visibility;
        public Visibility Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }


        private string _name;
        private string _surname;
        private string _patronimic;
        private DateTime _date;

        private string _town;
        private string _street;
        private string _house; 

        private string _phone;
        private string _email;


        public string Name { get { return _name; } set { _name = value;

                nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public string Surname { get { return _surname; } set { _surname = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }


        public string Town { get { return _town; } set { _town = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public string Street { get { return _street; } set { _street = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }
        public string House { get { return _house; } set { _house = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }


        public string Phone { get { return _phone; } set { _phone = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public string email { get { return _email; } set { _email = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }




        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;
        private Brush _textBox_City_B;
        private Brush _textBox_Street_B;
        private Brush _textBox_House_B;
        private Brush _textBox_Flat_B;
        private Brush _textBox_Phone_B;
        private Brush _textBox_Email_B;
        private int _genderTypeNumber;
       // public Patient CopyPatient { get; set; }

        public Patient CurrentPatient { get { return currentPatient; } set { currentPatient = value; OnPropertyChanged(); } }

        public int GenderTypeNumber { get { return _genderTypeNumber; } set { _genderTypeNumber = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }

        public Brush TextBoxPatronimicB { get { return _textBox_Patronimic_B; } set { _textBox_Patronimic_B = value; OnPropertyChanged(); } }

        public Brush TextBoxCityB { get { return _textBox_City_B; } set { _textBox_City_B = value; OnPropertyChanged(); } }

        public Brush TextBoxStreetB { get { return _textBox_Street_B; } set { _textBox_Street_B = value; OnPropertyChanged(); } }

        public Brush TextBoxHouseB { get { return _textBox_House_B; } set { _textBox_House_B = value; OnPropertyChanged(); } }

        public Brush TextBoxFlatB { get { return _textBox_Flat_B; } set { _textBox_Flat_B = value; OnPropertyChanged(); } }

        public Brush TextBoxPhoneB { get { return _textBox_Phone_B; } set { _textBox_Phone_B = value; OnPropertyChanged(); } }

        public Brush TextBoxEmailB { get { return _textBox_Email_B; } set { _textBox_Email_B = value; OnPropertyChanged(); } }

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
            if (String.IsNullOrWhiteSpace(Town))
            {
                TextBoxCityB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(Street))
            {
                TextBoxStreetB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(House))
            {
                TextBoxHouseB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(Phone))
            {
                TextBoxPhoneB = Brushes.Red;

                result = false;
            }
            
            int flatBuffer = 0;
            if (!int.TryParse(CurrentPatientFlat, out flatBuffer))
            {
                TextBoxFlatB = Brushes.Red;

                result = false;
            }
            else
            {
                CurrentPatient.Flat = flatBuffer;
            }
            return result;
        }

        public void SetAllFieldsDefault()
        {
            TextBoxNameB = Brushes.Gray;

            TextBoxSurnameB = Brushes.Gray;

            TextBoxPatronimicB = Brushes.Gray;

            TextBoxCityB = Brushes.Gray;

            TextBoxStreetB = Brushes.Gray;

            TextBoxHouseB = Brushes.Gray;

            TextBoxFlatB = Brushes.Gray;

            TextBoxPhoneB = Brushes.Gray;

            TextBoxEmailB = Brushes.Gray;
        }
        private int CurrentPatientID;
        private void SetCurrentPatientID(object sender, object data)
        {
            CurrentPatientID = (int)data;
            CurrentPatient = Data.Patients.Get((int)data);
            CurrentPatientFlat = CurrentPatient.Flat.ToString();
            Name = CurrentPatient.Name;

            Surname = CurrentPatient.Sirname;


            Patronimic = CurrentPatient.Patronimic;
            Date = CurrentPatient.Birthday;



            Town = CurrentPatient.City;

            Street = CurrentPatient.Street;
            House = CurrentPatient.House;


            Phone = CurrentPatient.Phone;


            email = CurrentPatient.Email;
            if (CurrentPatient.Gender == "м")
            {
                GenderTypeNumber = 0;
            }
            else
            {
                GenderTypeNumber = 1;
            }
            //CopyPatient = CurrentPatient;
            nameOfButton = "Вернуться к пациенту";
        }

        private string _currentPatientFlat;
        public string CurrentPatientFlat { get { return _currentPatientFlat; } set { _currentPatientFlat = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //nameOfButton = "Сохранить изменения";
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelEditPatient(NavigationController controller) : base(controller)
        {

            //Date = DateTime.Now;
            base.HasNavigation = false;
            Visibility = Visibility.Visible;
            TextHeader = "Редактирование пациента";

            nameOfButton = "Вернуться к пацыенту";
            MessageBus.Default.Subscribe("GetCurrentPatientIdForEdit", SetCurrentPatientID);
            SetAllFieldsDefault();
            ToDashboardCommand = new DelegateCommand(
              () =>
              {
                  CurrentPatientFlat = CurrentPatient.Flat.ToString();
                  Name = CurrentPatient.Name;

                  Surname = CurrentPatient.Sirname;


                  Patronimic = CurrentPatient.Patronimic;
                  Date = CurrentPatient.Birthday;



                  Town = CurrentPatient.City;

                  Street = CurrentPatient.Street;
                  House = CurrentPatient.House;


                  Phone = CurrentPatient.Phone;


                  email = CurrentPatient.Email;
                  if (CurrentPatient.Gender == "м")
                  {
                      GenderTypeNumber = 0;
                  }
                  else
                  {
                      GenderTypeNumber = 1;
                  }
                 // CopyPatient = CurrentPatient;
                  nameOfButton = "Вернуться к пациенту";

                 // Controller.NavigateTo<ViewModelDashboard>();
              }
          );
            Changed = new DelegateCommand(
               () =>
               {
                   nameOfButton = "Сохранить изменения";
               //    Controller.NavigateTo<ViewModelDashboard>();
               }
           );
            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    SetAllFieldsDefault();
                    if (TestRequiredFields())
                    {
                        CurrentPatient.Name = Name;
                        CurrentPatient.Sirname = Surname;
                        CurrentPatient.Patronimic = Patronimic;
                        CurrentPatient.Birthday = Date;
                        CurrentPatient.City = Town;
                        CurrentPatient.Street = Street;
                        CurrentPatient.House = House;
                        CurrentPatient.Phone = Phone;
                        CurrentPatient.Email = email;
                        if (GenderTypeNumber == 0)
                        {
                            CurrentPatient.Gender = "м";
                        }
                        else
                        {
                            CurrentPatient.Gender = "ж";
                        }

                        Data.Complete();
                        Controller.NavigateTo<ViewModelCurrentPatient>();
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
