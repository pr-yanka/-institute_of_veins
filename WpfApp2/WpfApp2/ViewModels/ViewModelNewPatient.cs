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
using System.Windows.Controls;
using System.Linq;

namespace WpfApp2.ViewModels
{
    public class ViewModelNewPatient : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand Changed { get; protected set; }

        public AutoCompleteFilterPredicate<object> CustomeFilter
        {
            get
            {
                return new AutoCompleteFilterPredicate<object>(CustomFiltration);
            }
        }





        private bool CustomFiltration(string search, object item)
        {
            string info = item as string;
            if (info != null)
            {
                string filterText = search.ToLower();
                return info.ToLower().StartsWith(filterText) || info.ToLower().Contains(filterText);
            }
            return false;
        }
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


        private IEnumerable<String> _districtList;
        private IEnumerable<String> _streetList;
        private IEnumerable<String> _townsList;
        public IEnumerable<String> TownsList { get { return _townsList; } set { _townsList = value; OnPropertyChanged(); } }
        public IEnumerable<String> DistrictList { get { return _districtList; } set { _districtList = value; OnPropertyChanged(); } }
        public IEnumerable<String> RegionList { get; set; }
        public IEnumerable<String> StreetList { get { return _streetList; } set { _streetList = value; OnPropertyChanged(); } }

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

                OnPropertyChanged();
            }
        }

        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }
        private string _region;
        private string _district;

        private RegexUtilities mailTester;

        public string Town { get { return _town; } set { _town = value; OnPropertyChanged(); GetStreetAnDistrict(); } }
        public string District { get { return _district; } set { _district = value; OnPropertyChanged(); } }
        public string Region { get { return _region; } set { _region = value; OnPropertyChanged(); GetTowns(); } }
        public string Street { get { return _street; } set { _street = value; OnPropertyChanged(); } }
        public string House { get { return _house; } set { _house = value; OnPropertyChanged(); } }

        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }

        public string email
        {
            get { return _email; }
            set
            {
                _email = value; if (!String.IsNullOrWhiteSpace(value))
                {



                    if (mailTester.IsValidEmail(value))
                    {
                        TextBoxEmailB = Brushes.Gray;

                    }
                    else
                    {

                        TextBoxEmailB = Brushes.Red;
                    }
                }
                else
                {
                    TextBoxEmailB = Brushes.Gray;
                }


                OnPropertyChanged();
            }
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
        private Brush _date_B;
        private Brush _textBox_District_B;
        private Brush _textBox_Region_B;
        public Brush TextBoxDistrictB { get { return _textBox_District_B; } set { _textBox_District_B = value; OnPropertyChanged(); } }

        public Brush TextBoxRegionB { get { return _textBox_Region_B; } set { _textBox_Region_B = value; OnPropertyChanged(); } }

        public Brush Date_B { get { return _date_B; } set { _date_B = value; OnPropertyChanged(); } }

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
        private void TestRequiredFieldsMessageBox()
        {


            if (Date.Day >= DateTime.Now.Day && Date.Month >= DateTime.Now.Month && Date.Year >= DateTime.Now.Year)
            {
                Date_B = Brushes.Red;
                MessageBox.Show("Дата заполнена неправильно");

            }

            else if (String.IsNullOrWhiteSpace(Name))
            {
                TextBoxNameB = Brushes.Red;
                MessageBox.Show("Имя не заполнено");

            }
            else if (String.IsNullOrWhiteSpace(Surname))
            {
                TextBoxSurnameB = Brushes.Red;
                MessageBox.Show("Фамилия не заполнена");

            }
            else if (String.IsNullOrWhiteSpace(Patronimic))
            {
                TextBoxPatronimicB = Brushes.Red;

                MessageBox.Show("Отчество не заполнено");
            }
            else if (String.IsNullOrWhiteSpace(Town))
            {
                TextBoxCityB = Brushes.Red;
                MessageBox.Show("Город не заполнен");

            }
            else if (String.IsNullOrWhiteSpace(Street))
            {
                TextBoxStreetB = Brushes.Red;
                MessageBox.Show("Улица не заполнена");

            }
            else if (String.IsNullOrWhiteSpace(House))
            {
                TextBoxHouseB = Brushes.Red;
                MessageBox.Show("Дом не заполнен");

            }
            else if (String.IsNullOrWhiteSpace(Phone))
            {
                TextBoxPhoneB = Brushes.Red;

                MessageBox.Show("Телефон не заполнена");
            }
            //if (String.IsNullOrWhiteSpace(District))
            //{
            //    TextBoxDistrictB = Brushes.Red;

            //    result = false;
            //}
            else if (String.IsNullOrWhiteSpace(Region))
            {
                TextBoxRegionB = Brushes.Red;

                MessageBox.Show("Область не заполнена");
            }

            else if (!String.IsNullOrWhiteSpace(email))
            {
                if (!mailTester.IsValidEmail(email))
                {

                    TextBoxEmailB = Brushes.Red;
                    MessageBox.Show("Еmail заполнен неправильно");
                }

            }

            //int flatBuffer = 0;
            //if (!int.TryParse(CurrentPatientFlat, out flatBuffer))
            //{
            //    TextBoxFlatB = Brushes.Red;

            //    result = false;
            //}
            //else
            //{
            //    CurrentPatient.Flat = flatBuffer;
            //}

        }
        private bool TestRequiredFields()
        {
            bool result = true;

            if (Date.Day >= DateTime.Now.Day && Date.Month >= DateTime.Now.Month && Date.Year >= DateTime.Now.Year)
            {
                Date_B = Brushes.Red;

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
            //if (String.IsNullOrWhiteSpace(District))
            //{
            //    TextBoxDistrictB = Brushes.Red;

            //    result = false;
            //}
            if (String.IsNullOrWhiteSpace(Region))
            {
                TextBoxRegionB = Brushes.Red;

                result = false;
            }

            if (!String.IsNullOrWhiteSpace(email))
            {
                if (!mailTester.IsValidEmail(email))
                {
                    result = false;
                    TextBoxEmailB = Brushes.Red;

                }

            }

            //int flatBuffer = 0;
            //if (!int.TryParse(CurrentPatientFlat, out flatBuffer))
            //{
            //    TextBoxFlatB = Brushes.Red;

            //    result = false;
            //}
            //else
            //{
            //    CurrentPatient.Flat = flatBuffer;
            //}
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
            Date_B = Brushes.Gray;
            TextBoxEmailB = Brushes.Gray;
        }
        int curOblID = 0;
        int curTwnID = 0;
        public DelegateCommand<object> ClickOnAutoComplete { get; set; }
        #region MessageBus
        private void GetTowns()
        {
            using (var context = new MySqlContext())
            {
                RegionsRepository regRep = new RegionsRepository(context);

                curOblID = 0;
                foreach (var Ton in regRep.GetAll)
                {
                    if (Ton.Str == Region)
                    {
                        curOblID = Ton.Id;
                    }
                }

                if (curOblID != 0)
                {
                    TownsList = context.Set<Cities>().Where(entry => (entry.OblId == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();
                    //TownsList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_города where Область = " + curOblID + " ORDER BY название").ToList();
                    //  TownListID = context.Database.SqlQuery<int>("SELECT id FROM med_db.справочник_города where Область = " + curOblID).ToList();
                    DistrictList = context.Set<Districts>().Where(entry => (entry.IdCity == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();
                    // DistrictList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_районы where Город = " + curOblID + " ORDER BY название").ToList();

                }
                else
                {
                    DistrictList = new List<string>();
                    TownsList = new List<string>();
                }
                Controller.NavigateTo<ViewModelNewPatient>();
            }
        }

        private void GetStreetAnDistrict()
        {
            using (var context = new MySqlContext())
            {
                curTwnID = 0;


                curTwnID = context.Set<Cities>().Where(entry => (entry.Str == Town && entry.OblId == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Id).FirstOrDefault();

                // curTwnID = context.Database.SqlQuery<int>("SELECT id FROM med_db.справочник_города where название = '" + Town + "' and Область = " + curOblID + " ORDER BY название").ToList().FirstOrDefault();

                // context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_города where Область = ").ToList();


                if (curTwnID != 0)
                {
                    StreetList = context.Set<Streets>().Where(entry => (entry.IdCity == curTwnID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();

                    //    StreetList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_улицы where Город = " + curTwnID + " ORDER BY название").ToList();

                    // DistrictList = DistrictListbuf;
                }
                else
                {
                    List<string> DistrictListbuf = new List<string>();
                    List<string> StreetListbuf = new List<string>();
                    StreetList = StreetListbuf;
                    DistrictList = DistrictListbuf;
                }
                Controller.NavigateTo<ViewModelNewPatient>();
            }
        }
        private void GetDictionary(object sender, object data)
        {

            using (var context = new MySqlContext())
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
                Town = "";
                District = "";
                Region = "";
                Street = "";

                nameOfButton = "Добавить";
                Date = DateTime.Now;


                List<string> TownsListbuf = new List<string>();
                List<string> RegionListbuf = new List<string>();





                RegionList = context.Set<Regions>().OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();
                // RegionList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_область ORDER BY название").ToList(); ;




                TownsList = TownsListbuf;
                DistrictList = TownsListbuf;
                StreetList = TownsListbuf;


            }



        }
        #endregion


        public ViewModelNewPatient(NavigationController controller) : base(controller)
        {
            mailTester = new RegexUtilities();
            ClickOnAutoComplete = new DelegateCommand<object>(
               (sender) =>
               {
                   try
                   {

                       if (sender != null)
                       {
                           var buf = (AutoCompleteBox)sender;
                           if (!buf.IsDropDownOpen)
                               buf.IsDropDownOpen = true;
                       }
                   }
                   catch
                   {

                   }
               }
           );
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
                        CurrentPatient = new Patient();
                        //CurrentPatient.Name = Name;
                        //CurrentPatient.Sirname = Surname;
                        //CurrentPatient.Patronimic = Patronimic;
                        //CurrentPatient.Birthday = Date;

                        using (var context = new MySqlContext())
                        {

                            //CurrentPatient = Data.Patients.Get(CurrentPatient.Id);
                            ////CitiesRepository ctRep = new CitiesRepository(context);
                            RegionsRepository regRep = new RegionsRepository(context);
                            //DistrictsRepository distRep = new DistrictsRepository(context);
                            //               StreetsRepository strtRep = new StreetsRepository(context);
                            CurrentPatient.Name = Name;
                            CurrentPatient.Sirname = Surname;
                            CurrentPatient.Patronimic = Patronimic;
                            CurrentPatient.Birthday = Date;
                            bool isExist = false;
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
                                curOblID = bufRegions.Id;
                                CurrentPatient.Region = bufRegions.Id;
                            }

                            isExist = false;

                            var townsbuflist = context.Set<Cities>().Where(entry => (entry.OblId == curOblID)).OrderBy(entry => entry.Str).ToList();
                            foreach (var Town1 in townsbuflist)
                            {
                                if (Town1.Str == Town && Town1.OblId == curOblID)
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
                                bufCity.OblId = curOblID;
                                Data.Cities.Add(bufCity);
                                Data.Complete();
                                curTwnID = bufCity.Id;
                                CurrentPatient.City = bufCity.Id;
                            }
                            isExist = false;
                            //StreetsForQuery
                            var streetbuflist = context.Set<Streets>().Where(entry => (entry.IdCity == curTwnID)).OrderBy(entry => entry.Str).ToList();

                            foreach (var Street1 in streetbuflist)
                            {
                                if (Street1.Str == Street && Street1.IdCity == curTwnID)
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
                                bufStreet.IdCity = curTwnID;
                                Data.Streets.Add(bufStreet);
                                Data.Complete();
                                CurrentPatient.Street = bufStreet.Id;
                            }
                            //DistrictsForQuery
                            isExist = false;
                            var districtbuflist = context.Set<Districts>().Where(entry => (entry.IdCity == curOblID)).OrderBy(entry => entry.Str).ToList();

                            foreach (var District1 in districtbuflist)
                            {
                                if (District1.Str == District && District1.IdCity == curOblID)
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
                                bufDistricts.IdCity = curOblID;
                                Data.Districts.Add(bufDistricts);
                                Data.Complete();
                                CurrentPatient.District = bufDistricts.Id;
                            }

                        }
                        CurrentPatient.House = House;
                        CurrentPatient.Phone = Phone;

                        int flatBuffer = 0;
                        if (!int.TryParse(CurrentPatientFlat, out flatBuffer))
                        {

                            CurrentPatient.Flat = null;

                        }
                        else
                        {
                            CurrentPatient.Flat = flatBuffer;
                        }
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
                        TestRequiredFieldsMessageBox();
                    }

                }
            );
        }
    }
}