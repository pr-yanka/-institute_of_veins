using System;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelNewPatient : ViewModelBase, INotifyPropertyChanged
    {
        public string nameOfButton { get; set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand Changed { get; protected set; }
        private Patient currentPatient;
        private Visibility _visibility;
        public Visibility Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }



        private string _currentPatientFlat;
        public string CurrentPatientFlat { get { return _currentPatientFlat; } set { _currentPatientFlat = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _name;
        private string _surname;
        private string _patronimic;
        private DateTime _date;

        private string _town;
        private string _street;
        private string _house;

        private string _phone;
        private string _email;


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                nameOfButton = "Сохранить изменения"; OnPropertyChanged();
            }
        }

        public string Surname         { get { return _surname; } set { _surname = value;  OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value;  OnPropertyChanged(); } }
      public DateTime Date         { get { return _date; } set { _date = value;  OnPropertyChanged(); } }


        public string Town           { get { return _town; } set { _town = value;  OnPropertyChanged(); } }

        public string Street          { get { return _street; } set { _street = value;  OnPropertyChanged(); } }
        public string House         { get { return _house; } set { _house = value;  OnPropertyChanged(); } }


        public string Phone              { get { return _phone; } set { _phone = value;  OnPropertyChanged(); } }

        public string email                 { get { return _email; } set { _email = value;  OnPropertyChanged(); } }

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

        public Patient CurrentPatient { get { return currentPatient; } set { currentPatient = value; OnPropertyChanged(); } }

        public int GenderTypeNumber { get { return _genderTypeNumber; } set { _genderTypeNumber = value; OnPropertyChanged(); } }

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


        public ViewModelNewPatient(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
          //  Visibility = Visibility.Hidden;
            SetAllFieldsDefault();
            
            nameOfButton = "Добавить пользователя";
            TextHeader = "Добавление пациента";
            CurrentPatient = new Patient();

            CurrentPatient.Birthday = DateTime.Now;

            

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    CurrentPatientFlat = "";
                    Name = "";

                    Surname = "";


                    Patronimic = "";
                    Date = DateTime.Now;



                    Town = "";

                    Street = "";
                    House = "";


                    Phone = "";


                    email = "";
                    //Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {

                    //CurrentPatient.Name = "1";
                    //TextBox_Name_T = new System.Windows.Thickness(1, 1, 1, 1);
                 
                  

                   
                   
                   
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
                     
                        Data.Patients.Add(CurrentPatient);
                        Data.Complete();
                        MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
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
