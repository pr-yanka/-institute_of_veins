using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Drawing;  5448217
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
using System.Windows.Controls;

namespace WpfApp2.ViewModels
{
    public class StreetsForQuery
    {


        public int id { set; get; }

        public string название { set; get; }

        public int Город { set; get; }

    }
    public class CitiesForQuery
    {


        public int id { set; get; }

        public string название { set; get; }

        public int Область { set; get; }
    }
    public class DistrictsForQuery
    {


        public int id { set; get; }

        public string название { set; get; }

        public int Город { set; get; }

    }
    public class ViewModelEditPatient : ViewModelBase, INotifyPropertyChanged
    {
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public string _nameOfButton;
        public string nameOfButton { get { return _nameOfButton; } set { _nameOfButton = value; OnPropertyChanged("nameOfButton"); } }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private Patient currentPatient;
        public DelegateCommand Changed { get; protected set; }
        public DelegateCommand<object> ClickOnAutoComplete { get; }

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
        private IEnumerable<String> _districtList;
        private IEnumerable<String> _streetList;
        private IEnumerable<String> _townsList;
        public IEnumerable<String> TownsList { get { return _townsList; } set { _townsList = value; OnPropertyChanged(); } }
        public IEnumerable<String> DistrictList { get { return _districtList; } set { _districtList = value; OnPropertyChanged(); } }
        public IEnumerable<String> RegionList { get; set; }
        public IEnumerable<String> StreetList { get { return _streetList; } set { _streetList = value; OnPropertyChanged(); } }
        public List<int> TownListID;
        int curTwnID = 0;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                nameOfButton = "Сохранить изменения"; OnPropertyChanged();
            }
        }

        public string Surname { get { return _surname; } set { _surname = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        private string _region;
        private string _district;

        public string Town { get { return _town; } set { _town = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); GetStreetAnDistrict(); } }

        public string Street { get { return _street; } set { _street = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }
        public string House { get { return _house; } set { _house = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        private RegexUtilities mailTester;
        public string Phone { get { return _phone; } set { _phone = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

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
                nameOfButton = "Сохранить изменения"; OnPropertyChanged();
            }
        }

        public string District { get { return _district; } set { _district = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }
        public string Region { get { return _region; } set { _region = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); GetTowns(); } }

        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;
        private Brush _textBox_City_B;
        private Brush _textBox_Street_B;
        private Brush _textBox_House_B;
        private Brush _textBox_Flat_B;
        private Brush _textBox_Phone_B;
        private Brush _textBox_Email_B;
        private int _genderTypeNumber; private Brush _date_B;
        private Brush _textBox_District_B;
        private Brush _textBox_Region_B;
        public Brush TextBoxDistrictB { get { return _textBox_District_B; } set { _textBox_District_B = value; OnPropertyChanged(); } }

        public Brush TextBoxRegionB { get { return _textBox_Region_B; } set { _textBox_Region_B = value; OnPropertyChanged(); } }

        public Brush Date_B { get { return _date_B; } set { _date_B = value; OnPropertyChanged(); } }
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

        int curOblID = 0;


        private void GetTowns()
        {
            using (var context = new MySqlContext())
            {

                //DistrictsRepository distRep = new DistrictsRepository(context);
                //StreetsRepository strtRep = new StreetsRepository(context);


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

                    //DistrictList = new List<string>();
                    DistrictList = context.Set<Districts>().Where(entry => (entry.IdCity == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();

                    //DistrictList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_районы where Город = " + curOblID + " ORDER BY название").ToList();

                }
                else
                {
                    DistrictList = new List<string>();
                    TownsList = new List<string>();
                }
                Controller.NavigateTo<ViewModelEditPatient>();
            }
        }
        //  TownListID = context.Database.SqlQuery<int>("SELECT id FROM med_db.справочник_города where Область = " + curOblID).ToList();

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
            //if (String.IsNullOrWhiteSpace(Town))
            //{
            //    TextBoxCityB = Brushes.Red;

            //    result = false;
            //}
            //if (String.IsNullOrWhiteSpace(Street))
            //{
            //    TextBoxStreetB = Brushes.Red;

            //    result = false;
            //}

            //if (String.IsNullOrWhiteSpace(House))
            //{
            //    TextBoxHouseB = Brushes.Red;

            //    result = false;
            //}

            if (String.IsNullOrWhiteSpace(Phone))
            {
                TextBoxPhoneB = Brushes.Red;

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
            //if (String.IsNullOrWhiteSpace(District))
            //{
            //    TextBoxDistrictB = Brushes.Red;

            //    result = false;
            //}

            //if (String.IsNullOrWhiteSpace(Region))
            //{
            //    TextBoxRegionB = Brushes.Red;

            //    result = false;
            //}


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
        private void GetStreetAnDistrict()
        {
            using (var context = new MySqlContext())
            {
                curTwnID = 0;

                curTwnID = context.Set<Cities>().Where(entry => (entry.Str == Town && entry.OblId == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Id).FirstOrDefault();


                //curTwnID = context.Database.SqlQuery<int>("SELECT id FROM med_db.справочник_города where название = '" + Town + "' and Область = " + curOblID + " ORDER BY название").ToList().FirstOrDefault();



                if (curTwnID != 0)
                {
                    StreetList = context.Set<Streets>().Where(entry => (entry.IdCity == curTwnID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();

                    // StreetList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_улицы where Город = " + curTwnID + " ORDER BY название").ToList();

                    // DistrictList = DistrictListbuf;
                }
                else
                {
                    List<string> DistrictListbuf = new List<string>();
                    List<string> StreetListbuf = new List<string>();
                    StreetList = StreetListbuf;
                    DistrictList = DistrictListbuf;
                }
                Controller.NavigateTo<ViewModelEditPatient>();
            }
        }
        private void TestRequiredFieldsMessageBox()
        {


            if (Date.Day >= DateTime.Now.Day && Date.Month >= DateTime.Now.Month && Date.Year >= DateTime.Now.Year)
            {
                Date_B = Brushes.Red;
                MessageBox.Show("Дата рождения заполнена неправильно");

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
            //else if (String.IsNullOrWhiteSpace(Town))
            //{
            //    TextBoxCityB = Brushes.Red;
            //    MessageBox.Show("Город не заполнен");

            //}
            //else if (String.IsNullOrWhiteSpace(Street))
            //{
            //    TextBoxStreetB = Brushes.Red;
            //    MessageBox.Show("Улица не заполнена");

            //}
            //else if (String.IsNullOrWhiteSpace(House))
            //{
            //    TextBoxHouseB = Brushes.Red;
            //    MessageBox.Show("Дом не заполнен");

            //}
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
            //else if (String.IsNullOrWhiteSpace(Region))
            //{
            //    TextBoxRegionB = Brushes.Red;

            //    MessageBox.Show("Область не заполнена");
            //}

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
            Date_B = Brushes.Gray;
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
            using (var context = new MySqlContext())
            {

                CitiesRepository ctRep = new CitiesRepository(context);
                RegionsRepository regRep = new RegionsRepository(context);
                DistrictsRepository distRep = new DistrictsRepository(context);
                StreetsRepository strtRep = new StreetsRepository(context);


                Town = ctRep.Get(CurrentPatient.City).Str;
                if (CurrentPatient.District != null)
                {
                    District = distRep.Get(CurrentPatient.District.Value).Str;
                }
                Region = regRep.Get(CurrentPatient.Region).Str;
                Street = strtRep.Get(CurrentPatient.Street).Str;

                List<string> TownsListbuf = new List<string>();
                List<string> RegionListbuf = new List<string>();
                List<string> DistrictListbuf = new List<string>();
                List<string> StreetListbuf = new List<string>();
                //foreach (var Town in ctRep.GetAll)
                //{
                //    TownsListbuf.Add(Town.Str);
                //}
                //foreach (var Street in strtRep.GetAll)
                //{
                //    StreetListbuf.Add(Street.Str);
                //}

                //foreach (var District in distRep.GetAll)
                //{
                //    DistrictListbuf.Add(District.Str);
                //}

                //DistrictList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_районы where Город = " + curOblID + " ORDER BY название").ToList();


                DistrictList = context.Set<Districts>().Where(entry => (entry.IdCity == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();
                //  DistrictList = distRep.DbContext.Set<Districts>().Where(entry => (entry.IdCity == curOblID)).OrderBy(entry => entry.Str).Select(entry => entry.Str);

                RegionList = context.Set<Regions>().OrderBy(entry => entry.Str).Select(entry => entry.Str).ToList();

                //RegionList = context.Database.SqlQuery<string>("SELECT название FROM med_db.справочник_область ORDER BY название").ToList(); ;

                StreetList = StreetListbuf;
                TownsList = TownsListbuf;


                //Town = ctRep.Get(CurrentPatient.City).Str;
                //if (CurrentPatient.District != null)
                //{
                //    District = distRep.Get(CurrentPatient.District.Value).Str;
                //}

                //Street = strtRep.Get(CurrentPatient.Street).Str;
            }
            GetTowns();
            GetStreetAnDistrict();
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
            nameOfButton = "Вернуться к пациенту";
        }

        private string _currentPatientFlat;
        public string CurrentPatientFlat { get { return _currentPatientFlat; } set { _currentPatientFlat = value; nameOfButton = "Сохранить изменения"; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //nameOfButton = "Сохранить изменения";
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModelEditPatient(NavigationController controller) : base(controller)
        {
            mailTester = new RegexUtilities();
            base.HasNavigation = false;
            Visibility = Visibility.Visible;
            TextHeader = "Редактирование пациента";
            nameOfButton = "Вернуться к пацыенту";
            MessageBus.Default.Subscribe("GetCurrentPatientIdForEdit", SetCurrentPatientID);
            SetAllFieldsDefault();

            ToDashboardCommand = new DelegateCommand(
              () =>
              {


                  using (var context = new MySqlContext())
                  {

                      CitiesRepository ctRep = new CitiesRepository(context);
                      RegionsRepository regRep = new RegionsRepository(context);
                      DistrictsRepository distRep = new DistrictsRepository(context);
                      StreetsRepository strtRep = new StreetsRepository(context);


                      Town = ctRep.Get(CurrentPatient.City).Str;
                      if (CurrentPatient.District != null)
                      {
                          District = distRep.Get(CurrentPatient.District.Value).Str;
                      }
                      Region = regRep.Get(CurrentPatient.Region).Str;
                      Street = strtRep.Get(CurrentPatient.Street).Str;
                  }


                  CurrentPatientFlat = CurrentPatient.Flat.ToString();
                  Name = CurrentPatient.Name;

                  Surname = CurrentPatient.Sirname;


                  Patronimic = CurrentPatient.Patronimic;
                  Date = CurrentPatient.Birthday;



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
            ClickOnAutoComplete = new DelegateCommand<object>(
              (sender) =>
              {
                  var buf = (AutoCompleteBox)sender;
                  buf.IsDropDownOpen = true;

              }
          );
            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    SetAllFieldsDefault();
                    if (TestRequiredFields())
                    {


                        using (var context = new MySqlContext())
                        {

                            CurrentPatient = Data.Patients.Get(CurrentPatient.Id);
                            //CitiesRepository ctRep = new CitiesRepository(context);
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
                            //context.Database.SqlQuery<CitiesForQuery>("SELECT * FROM med_db.справочник_города where Область = " + curOblID + " ORDER BY название").ToList()
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
                            //StreetsForQuery context.Database.SqlQuery<StreetsForQuery>("SELECT * FROM med_db.справочник_улицы where Город = " + curTwnID + " ORDER BY название").ToList()
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


                        //CurrentPatient.City = Town;
                        //CurrentPatient.Street = Street;
                        CurrentPatient.House = House;
                        CurrentPatient.Phone = Phone;
                        CurrentPatient.Email = email;

                        int flatBuffer = 0;
                        if (!int.TryParse(CurrentPatientFlat, out flatBuffer))
                        {

                            CurrentPatient.Flat = null;


                        }
                        else
                        {
                            CurrentPatient.Flat = flatBuffer;
                        }
                        //   CurrentPatient.Flat = int.Parse(CurrentPatientFlat);
                        if (GenderTypeNumber == 0)
                        {
                            CurrentPatient.Gender = "м";
                        }
                        else
                        {
                            CurrentPatient.Gender = "ж";
                        }

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
