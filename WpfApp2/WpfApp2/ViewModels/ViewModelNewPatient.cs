﻿using System;
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
        private Patient currentPatient;
        private Visibility _visibility;
        public Visibility Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }


       

        public string CurrentPatientFlat { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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


        public ViewModelNewPatient(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;
            Visibility = Visibility.Hidden;
            SetAllFieldsDefault();
            nameOfButton = "Добавить пользователя";
            TextHeader = "Добавление пациента";
            CurrentPatient = new Patient();

            CurrentPatient.Birthday = DateTime.Now;

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
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
