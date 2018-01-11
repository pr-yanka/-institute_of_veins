using System;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using System.Collections.Generic;


namespace WpfApp2.ViewModels
{
    public class ViewModelNewPatient : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand Changed { get; protected set; }
        #endregion


        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Bindings

        public IEnumerable<String> TownsList { get; set; }
        public IEnumerable<String> DistrictList { get; set; }
        public IEnumerable<String> RegionList { get; set; }
        public IEnumerable<String> StreetList { get; set; }

        private string _currentPatientFlat;
        public string CurrentPatientFlat { get { return _currentPatientFlat; } set { _currentPatientFlat = value; OnPropertyChanged(); } }

        private Patient currentPatient;
        private Visibility _visibility;
        public Visibility Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }
        public string nameOfButton { get; set; }
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

        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }
        private string _region;
        private string _district;


        public string Town { get { return _town; } set { _town = value; OnPropertyChanged(); } }
        public string District { get { return _district; } set { _district = value; OnPropertyChanged(); } }
        public string Region { get { return _region; } set { _region = value; OnPropertyChanged(); } }
        public string Street { get { return _street; } set { _street = value; OnPropertyChanged(); } }
        public string House { get { return _house; } set { _house = value; OnPropertyChanged(); } }

        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }

        public string email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;
        private Brush _textBox_City_B;
        private Brush _textBox_Street_B;
        private Brush _textBox_House_B;
        private Brush _textBox_Flat_B;
        private Brush _textBox_Phone_B;
        private Brush _textBox_Email_B;

        private Brush _textBox_District_B;
        private Brush _textBox_Region_B;
        public Brush TextBoxDistrictB { get { return _textBox_District_B; } set { _textBox_District_B = value; OnPropertyChanged(); } }

        public Brush TextBoxRegionB { get { return _textBox_Region_B; } set { _textBox_Region_B = value; OnPropertyChanged(); } }


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

            if (String.IsNullOrWhiteSpace(District))
            {
                TextBoxDistrictB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(Region))
            {
                TextBoxRegionB = Brushes.Red;

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
            TextBoxRegionB = Brushes.Gray;

            TextBoxDistrictB = Brushes.Gray;

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


        #region MessageBus

        private void GetDictionary(object sender, object data)
        {

            using (var context = new MySqlContext())
            {
                nameOfButton = "Добавить пользователя";
                Date = DateTime.Now;
                CitiesRepository ctRep = new CitiesRepository(context);
                RegionsRepository regRep = new RegionsRepository(context);
                DistrictsRepository distRep = new DistrictsRepository(context);
                StreetsRepository strtRep = new StreetsRepository(context);
                List<string> TownsListbuf = new List<string>();
                List<string> RegionListbuf = new List<string>();
                List<string> DistrictListbuf = new List<string>();
                List<string> StreetListbuf = new List<string>();
                foreach (var Town in ctRep.GetAll)
                {
                    TownsListbuf.Add(Town.Str);
                }
                foreach (var Street in strtRep.GetAll)
                {
                    StreetListbuf.Add(Street.Str);
                }
                foreach (var Region in regRep.GetAll)
                {
                    RegionListbuf.Add(Region.Str);
                }
                foreach (var District in distRep.GetAll)
                {
                    DistrictListbuf.Add(District.Str);
                }
                DistrictList = DistrictListbuf;
                RegionList = RegionListbuf;
                StreetList = StreetListbuf;
                TownsList = TownsListbuf;
            }



        }
        #endregion


        public ViewModelNewPatient(NavigationController controller) : base(controller)
        {
            base.HasNavigation = true;

            MessageBus.Default.Subscribe("UpdateDictionariesOfLocationForNewPatient", GetDictionary);

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

                    District = "";

                    Region = "";

                    Patronimic = "";

                    Date = DateTime.Now;

                    Town = "";

                    Street = "";

                    House = "";

                    Phone = "";

                    email = "";

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

                        using (var context = new MySqlContext())
                        {

                            CitiesRepository ctRep = new CitiesRepository(context);
                            RegionsRepository regRep = new RegionsRepository(context);
                            DistrictsRepository distRep = new DistrictsRepository(context);
                            StreetsRepository strtRep = new StreetsRepository(context);
                            bool isExist = false;
                            foreach (var Town1 in ctRep.GetAll)
                            {
                                if (Town1.Str == Town)
                                {
                                    isExist = true;
                                    CurrentPatient.City = Town1.Id;
                                    break;
                                }
                            }
                            if (isExist == false)
                            {
                                Cities bufCity = new Cities();
                                bufCity.Str = Town;
                                Data.Cities.Add(bufCity);
                                Data.Complete();
                                CurrentPatient.City = bufCity.Id;
                            }
                            isExist = false;
                            foreach (var Street1 in strtRep.GetAll)
                            {
                                if (Street1.Str == Street)
                                {
                                    isExist = true;
                                    CurrentPatient.Street = Street1.Id;
                                    break;
                                }
                            }
                            if (isExist == false)
                            {
                                Streets bufStreet = new Streets();
                                bufStreet.Str = Street;
                                Data.Streets.Add(bufStreet);
                                Data.Complete();
                                CurrentPatient.Street = bufStreet.Id;
                            }
                            isExist = false;
                            foreach (var Region1 in regRep.GetAll)
                            {
                                if (Region1.Str == Region)
                                {
                                    isExist = true;
                                    CurrentPatient.Region = Region1.Id;
                                    break;
                                }
                            }
                            if (isExist == false)
                            {
                                Regions bufRegions = new Regions();
                                bufRegions.Str = Region;
                                Data.Regions.Add(bufRegions);
                                Data.Complete();
                                CurrentPatient.Region = bufRegions.Id;
                            }
                            isExist = false;
                            foreach (var District1 in distRep.GetAll)
                            {
                                if (District1.Str == District)
                                {
                                    isExist = true;
                                    CurrentPatient.District = District1.Id;
                                    break;
                                }
                            }
                            if (isExist == false)
                            {
                                Districts bufDistricts = new Districts();
                                bufDistricts.Str = District;
                                Data.Districts.Add(bufDistricts);
                                Data.Complete();
                                CurrentPatient.District = bufDistricts.Id;
                            }

                        }
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