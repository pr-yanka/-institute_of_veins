using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelEditPatient : ViewModelBase, INotifyPropertyChanged
    {
        public string nameOfButton { get; set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private Patient currentPatient;

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

        public Patient CurrentPatient { get { return currentPatient; } set { currentPatient = value; OnPropertyChanged("CurrentPatient"); } }

        public int GenderTypeNumber { get => _genderTypeNumber; set { _genderTypeNumber = value; OnPropertyChanged("GendeTypeNumber"); } }

        public Brush TextBoxNameB { get => _textBox_Name_B; set { _textBox_Name_B = value; OnPropertyChanged("TextBox_Name_B"); } }

        public Brush TextBoxSurnameB { get => _textBox_Surname_B; set { _textBox_Surname_B = value; OnPropertyChanged("TextBox_Surname_B"); } }

        public Brush TextBoxPatronimicB { get => _textBox_Patronimic_B; set { _textBox_Patronimic_B = value; OnPropertyChanged("TextBox_Patronimic_B"); } }

        public Brush TextBoxCityB { get => _textBox_City_B; set { _textBox_City_B = value; OnPropertyChanged("TextBox_City_B"); } }

        public Brush TextBoxStreetB { get => _textBox_Street_B; set { _textBox_Street_B = value; OnPropertyChanged("TextBox_Street_B"); } }

        public Brush TextBoxHouseB { get => _textBox_House_B; set { _textBox_House_B = value; OnPropertyChanged("TextBox_House_B"); } }

        public Brush TextBoxFlatB { get => _textBox_Flat_B; set { _textBox_Flat_B = value; OnPropertyChanged("TextBox_Flat_B"); } }

        public Brush TextBoxPhoneB { get => _textBox_Phone_B; set { _textBox_Phone_B = value; OnPropertyChanged("TextBox_Phone_B"); } }

        public Brush TextBoxEmailB { get => _textBox_Email_B; set { _textBox_Email_B = value; OnPropertyChanged("TextBox_Email_B"); } }


        private bool TestRequiredFields()
        {
            bool result = true;

            if (String.IsNullOrWhiteSpace(CurrentPatient.Name))
            {
                TextBoxNameB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.Sirname))
            {
                TextBoxSurnameB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.Patronimic))
            {
                TextBoxPatronimicB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.City))
            {
                TextBoxCityB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.Street))
            {
                TextBoxStreetB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.House))
            {
                TextBoxHouseB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.Phone))
            {
                TextBoxPhoneB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(CurrentPatient.Email))
            {
                TextBoxEmailB = Brushes.Red;

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
            if (CurrentPatient.Gender == "м")
            {
                GenderTypeNumber = 0;
            }
            else
            {
                GenderTypeNumber = 1;
            }
        }

        public string CurrentPatientFlat { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelEditPatient(NavigationController controller) : base(controller)
        {
            base.HasNavigation = false;

           

            nameOfButton = "Сохранить изменения";
            MessageBus.Default.Subscribe("GetCurrentPatientIdForEdit", SetCurrentPatientID);
            SetAllFieldsDefault();

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                SetAllFieldsDefault();
                    if (TestRequiredFields())
                    {
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
