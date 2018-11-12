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
using System.Windows.Media.Imaging;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace WpfApp2.ViewModels
{
    public class DocDataSoursForNewUser : INotifyPropertyChanged
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
            set { _isChecked = value; MessageBus.Default.Call("SomethingChangedUserForEditUser", this, this); OnPropertyChanged(); }
        }
        public string Name { get; set; }
        public int id { get; set; }


        public DocDataSoursForNewUser(string Name, int id)
        {
            this.Name = Name;
            this.id = id;
            IsChecked = false;

        }

    }
    public class ViewModelAddUser : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        private int _widthOfBtn;
        public int WidthOfBtn { get { return _widthOfBtn; } set { _widthOfBtn = value; OnPropertyChanged(); } }

        private Visibility _visibilityOfGoBAck;
        public Visibility VisibilityOfGoBAck { get { return _visibilityOfGoBAck; } set { _visibilityOfGoBAck = value; OnPropertyChanged(); } }


        private DelegateCommand _addPerson;
        public DelegateCommand AddPerson { get { return _addPerson; } set { _addPerson = value; OnPropertyChanged(); } }
        public DelegateCommand<object> ShowPassword { get; protected set; }
        public DelegateCommand<object> ToDashboardCommand { get; protected set; }
        public DelegateCommand GoToDoctorListCommand { get; }
        public DelegateCommand<object> SaveAndGoDoctorListCommand { get; protected set; }
        public DelegateCommand HidePassword { get; protected set; }
        #endregion
        #region Bindings
        private string _nameOfPerson;
        public string NameOfPerson { get { return _nameOfPerson; } set { _nameOfPerson = value; OnPropertyChanged(); } }

        public List<string> accType { get; set; }
        public ObservableCollection<DocDataSoursForNewUser> DocsDataSource { get; set; }
        public ObservableCollection<DocDataSoursForNewUser> MedsDataSource { get; set; }
        private string _password;
        private BitmapImage _imageSource;
        public BitmapImage ImageSource { get { return _imageSource; } set { _imageSource = value; OnPropertyChanged(); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        private Visibility _passwordBoxVisiblity;
        private Visibility _passwordTextBoxVisiblity;
        public Visibility PasswordBoxVisiblity { get { return _passwordBoxVisiblity; } set { _passwordBoxVisiblity = value; OnPropertyChanged(); } }

        public Visibility PasswordTextBoxVisiblity { get { return _passwordTextBoxVisiblity; } set { _passwordTextBoxVisiblity = value; OnPropertyChanged(); } }


        private Visibility _Vis;
        public Visibility Vis { get { return _Vis; } set { _Vis = value; OnPropertyChanged(); } }


        private Visibility _docVis;
        public Visibility DocVis { get { return _docVis; } set { _docVis = value; OnPropertyChanged(); } }
        private Visibility _medVis;
        public Visibility MedVis { get { return _medVis; } set { _medVis = value; OnPropertyChanged(); } }


        public string _nameOfButton;
        public string nameOfButton { get { return _nameOfButton; } set { _nameOfButton = value; OnPropertyChanged(); } }
        //public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private Accaunt currentUser;
        //public DelegateCommand Changed { get; protected set; }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }

        private string _name;
        public int _selectedIndexOfAccauntType;
        public int SelectedIndexOfAccauntType
        {
            get { return _selectedIndexOfAccauntType; }
            set
            {
                _selectedIndexOfAccauntType = value;
                if (accType[_selectedIndexOfAccauntType] == "Врач")
                {
                    NameOfPerson = "Добавить врача";
                    AddPerson = new DelegateCommand(
              () =>
              {
                  MessageBus.Default.Call("RefreshDataForNewDoctorsForAddUser", this, "");

                  Controller.NavigateTo<ViewModelAddDoctor>();

              }
          );
                    Vis = Visibility.Visible;
                    DocVis = Visibility.Visible; MedVis = Visibility.Collapsed;
                }
                else if (accType[_selectedIndexOfAccauntType] == "Медперсонал")
                {
                    AddPerson = new DelegateCommand(
              () =>
              {
                  MessageBus.Default.Call("RefreshDataForMedpersonalForAddUser", null, null);
                  Controller.NavigateTo<ViewModelAddMedPersonal>();

              }
          );

                    Vis = Visibility.Visible;
                    NameOfPerson = "Добавить медперсонал";
                    DocVis = Visibility.Collapsed; MedVis = Visibility.Visible;
                }
                else
                {
                    Vis = Visibility.Hidden;
                    DocVis = Visibility.Collapsed;
                    MedVis = Visibility.Collapsed;
                }
                OnPropertyChanged();
            }
        }

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }




        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;


        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }

        #endregion


        private bool TestRequiredFields()
        {
            bool result = true;

            if (String.IsNullOrWhiteSpace(Name))
            {
                TextBoxNameB = Brushes.Red;

                result = false;
            }
            if (String.IsNullOrWhiteSpace(Password))
            {
                TextBoxSurnameB = Brushes.Red;

                result = false;
            }
            foreach (var ac in Data.Accaunt.GetAll)
            {
                if (Name == ac.Name)
                {
                    result = false;
                    MessageBox.Show("Такое имя занято");
                    break;
                }
            }

            return result;
        }

        public void SetAllFieldsDefault()
        {
            TextBoxNameB = Brushes.Gray;

            TextBoxSurnameB = Brushes.Gray;



        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region MessageBus

        private void UpdateAccsEmptyAddMeds(object sender, object data)
        {
            //Name = "";
            int curDocId = (int)sender;
            MedsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
            DocsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
            bool test = true;
            foreach (var doc in Data.Doctor.GetAll)
            {
                test = true;

                foreach (var acc in Data.Accaunt.GetAll)
                {
                    if (acc.isDoctor != null && acc.isDoctor.Value && doc.isEnabled != null && doc.isEnabled.Value == true)
                    {
                        if (doc.Id == acc.idврач)
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {

                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";
                    DocDataSoursForNewUser buf = new DocDataSoursForNewUser(doc.Sirname + initials, doc.Id);

                    DocsDataSource.Add(buf);

                }
            }
            foreach (var doc in Data.MedPersonal.GetAll)
            {
                test = true;

                foreach (var acc in Data.Accaunt.GetAll)
                {
                    if (acc.isMedPersonal != null && acc.isMedPersonal.Value && doc.isEnabled != null && doc.isEnabled.Value == true)
                    {
                        if (doc.Id == acc.idмедперсонал)
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {
                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";
                    DocDataSoursForNewUser buf = new DocDataSoursForNewUser(doc.Surname + initials, doc.Id);
                    if (curDocId == doc.Id)
                    {
                        buf.IsChecked = true;
                    }
                    MedsDataSource.Add(buf);
                    if (MedsDataSource.IndexOf(buf) != 0)
                    {
                        var bff = MedsDataSource[0];
                        int bufint = MedsDataSource.IndexOf(buf);
                        MedsDataSource[0] = MedsDataSource[MedsDataSource.IndexOf(buf)];
                        MedsDataSource[bufint] = bff;
                    }


                }
            }

            //MedsDataSource.Reverse()
        }

        private void UpdateAccsEmptyAddDocs(object sender, object data)
        {
            //Name = "";
            int curDocId = (int)sender;
            MedsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
            DocsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
            bool test = true;
            foreach (var doc in Data.Doctor.GetAll)
            {
                test = true;

                foreach (var acc in Data.Accaunt.GetAll)
                {
                    if (acc.isDoctor != null && acc.isDoctor.Value && doc.isEnabled != null && doc.isEnabled.Value == true)
                    {
                        if (doc.Id == acc.idврач)
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {

                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";

                    DocDataSoursForNewUser buf = new DocDataSoursForNewUser(doc.Sirname + initials, doc.Id);
                    if (curDocId == doc.Id)
                    {
                        buf.IsChecked = true;
                    }
                    DocsDataSource.Add(buf);
                    if (DocsDataSource.IndexOf(buf) != 0)
                    {
                        var bff = DocsDataSource[0];
                        int bufint = DocsDataSource.IndexOf(buf);
                        DocsDataSource[0] = DocsDataSource[DocsDataSource.IndexOf(buf)];
                        DocsDataSource[bufint] = bff;
                    }
                }
            }
            foreach (var doc in Data.MedPersonal.GetAll)
            {
                test = true;

                foreach (var acc in Data.Accaunt.GetAll)
                {
                    if (acc.isMedPersonal != null && acc.isMedPersonal.Value && doc.isEnabled != null && doc.isEnabled.Value == true)
                    {
                        if (doc.Id == acc.idмедперсонал)
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {
                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";

                    MedsDataSource.Add(new DocDataSoursForNewUser(doc.Surname + initials, doc.Id));
                }
            }

            //MedsDataSource.Reverse()
        }
        private void UpdateAccsEmpty(object sender, object data)
        {
            Name = "";
            MedsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
            DocsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
            bool test = true;
            foreach (var doc in Data.Doctor.GetAll)
            {
                test = true;

                foreach (var acc in Data.Accaunt.GetAll)
                {
                    if (acc.isDoctor != null && acc.isDoctor.Value && doc.isEnabled != null && doc.isEnabled.Value == true)
                    {
                        if (doc.Id == acc.idврач)
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {
                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";

                    DocsDataSource.Add(new DocDataSoursForNewUser(doc.Sirname + initials, doc.Id));
                }
            }
            foreach (var doc in Data.MedPersonal.GetAll)
            {
                test = true;

                foreach (var acc in Data.Accaunt.GetAll)
                {
                    if (acc.isMedPersonal != null && acc.isMedPersonal.Value && doc.isEnabled != null && doc.isEnabled.Value == true)
                    {
                        if (doc.Id == acc.idмедперсонал)
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {
                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";

                    MedsDataSource.Add(new DocDataSoursForNewUser(doc.Surname + initials, doc.Id));
                }
            }
        }
        #endregion
        public ViewModelAddUser(NavigationController controller) : base(controller)
        {
            NameOfPerson = "Добавить врача";
            AddPerson = new DelegateCommand(
      () =>
      {
          MessageBus.Default.Call("RefreshDataForNewDoctorsForAddUser", this, "");

          Controller.NavigateTo<ViewModelAddDoctor>();

      }
  ); WidthOfBtn = 200;
            VisibilityOfGoBAck = Visibility.Visible;
            Vis = Visibility.Visible;
            DocVis = Visibility.Visible;
            MedVis = Visibility.Collapsed;
            MessageBus.Default.Subscribe("UpdateAccsEmptyForNewUserForAddNewMedpersonal", UpdateAccsEmptyAddMeds);
            MessageBus.Default.Subscribe("UpdateAccsEmptyForNewUserForAddNewMed", UpdateAccsEmptyAddDocs);
            MessageBus.Default.Subscribe("UpdateAccsEmptyForNewUser", UpdateAccsEmpty);
            ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Hide.PNG"));
            base.HasNavigation = true;
            PasswordBoxVisiblity = Visibility.Visible;
            PasswordTextBoxVisiblity = Visibility.Hidden;
            TextHeader = "Добавление пользователя";
            accType = new List<string>();

            accType.Add("Врач");
            accType.Add("Админ");
            accType.Add("Медперсонал");
            accType.Add("Секретарь");
            nameOfButton = "Добавить";

            SetAllFieldsDefault();

            HidePassword = new DelegateCommand(
              () =>
              {
                  ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Hide.PNG"));

                  Password = "";
                  PasswordBoxVisiblity = Visibility.Visible;
                  PasswordTextBoxVisiblity = Visibility.Hidden;

              }
          );
            ShowPassword = new DelegateCommand<object>(
              (sender) =>
              {
                  ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Show.PNG"));
                  // Password = CalculateMD5Hash(((PasswordBox)sender).Password);
                  Password = ((PasswordBox)sender).Password;
                  sender = null;
                  PasswordBoxVisiblity = Visibility.Hidden;
                  PasswordTextBoxVisiblity = Visibility.Visible;

              }
          );

            ToDashboardCommand = new DelegateCommand<object>(
              (sender)
             =>
              {
                  Name = "";
                  ((PasswordBox)sender).Password = "";

              }
          );
            GoToDoctorListCommand = new DelegateCommand(
             () =>
             {


                 MessageBus.Default.Call("OpenUsers", this, "");
                 Controller.NavigateTo<ViewModelViewUsers>();


             }
         );
            SaveAndGoDoctorListCommand = new DelegateCommand<object>(
              (sender) =>
              {
                  Password = ((PasswordBox)sender).Password;
                  sender = null;
                  if (TestRequiredFields())
                  {

                      currentUser = new Accaunt();
                      currentUser.Name = Name;
                      currentUser.Password = CalculateMD5Hash(Password);

                      currentUser.isEnabled = true;

                      if (accType[SelectedIndexOfAccauntType] == "Врач")
                      {
                          currentUser.isDoctor = true;
                          currentUser.idмедперсонал = null;


                          foreach (var doc in DocsDataSource)
                          {
                              if (doc.IsChecked == true)
                              {
                                  currentUser.idврач = doc.id;
                              }
                          }

                      }
                      else if (accType[SelectedIndexOfAccauntType] == "Админ")
                      {
                          currentUser.idмедперсонал = null;
                          currentUser.idврач = null;
                          currentUser.isAdmin = true;
                      }
                      else if (accType[SelectedIndexOfAccauntType] == "Медперсонал")
                      {
                          currentUser.isMedPersonal = true;
                          currentUser.idврач = null;
                          foreach (var doc in MedsDataSource)
                          {
                              if (doc.IsChecked == true)
                              {
                                  currentUser.idмедперсонал = doc.id;
                              }
                          }
                      }
                      else if (accType[SelectedIndexOfAccauntType] == "Секретарь")
                      {
                          currentUser.idмедперсонал = null;
                          currentUser.idврач = null;
                          currentUser.isSecretar = true;
                      }
                      Data.Accaunt.Add(currentUser);
                      Data.Complete();


                      MessageBus.Default.Call("OpenUsers", this, "");
                      Controller.NavigateTo<ViewModelViewUsers>();
                  }
                  else
                  {

                      MessageBox.Show("Не все поля заполнены");
                  }

              }
            );

        }
        public string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);


            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }
}
