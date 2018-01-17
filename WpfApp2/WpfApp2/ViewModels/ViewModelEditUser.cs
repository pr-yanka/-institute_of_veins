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

    public class ViewModelEditUser : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand PasswordChabged { get; protected set; }
        public DelegateCommand<object> ShowPassword { get; protected set; }
        public DelegateCommand<object> ToDashboardCommand { get; protected set; }
        public DelegateCommand<object> SaveAndGoDoctorListCommand { get; protected set; }
        public DelegateCommand HidePassword { get; protected set; }
        #endregion
        #region Bindings

        public List<string> accType { get; set; }
                                                                           
       private ObservableCollection<DocDataSoursForNewUser> _docsDataSource;
        private ObservableCollection<DocDataSoursForNewUser> _medsDataSource;

        public ObservableCollection<DocDataSoursForNewUser> DocsDataSource { get { return _docsDataSource; } set { _docsDataSource = value; OnPropertyChanged(); } }
        public ObservableCollection<DocDataSoursForNewUser> MedsDataSource { get { return _medsDataSource; } set { _medsDataSource = value; OnPropertyChanged(); } }
        private Visibility _docVis;
        public Visibility DocVis { get { return _docVis; } set { _docVis = value; OnPropertyChanged(); } }
        private Visibility _medVis;
        public Visibility MedVis { get { return _medVis; } set { _medVis = value; OnPropertyChanged(); } }

        private string _password;
        private BitmapImage _imageSource;
        public BitmapImage ImageSource { get { return _imageSource; } set { _imageSource = value; OnPropertyChanged(); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        private Visibility _passwordBoxVisiblity;
        private Visibility _passwordTextBoxVisiblity;
        public Visibility PasswordBoxVisiblity { get { return _passwordBoxVisiblity; } set { _passwordBoxVisiblity = value; OnPropertyChanged(); } }

        public Visibility PasswordTextBoxVisiblity { get { return _passwordTextBoxVisiblity; } set { _passwordTextBoxVisiblity = value; OnPropertyChanged(); } }


        public string _nameOfButton;
        public string nameOfButton { get { return _nameOfButton; } set { _nameOfButton = value; OnPropertyChanged(); } }
        //public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private Accaunt currentUser;
        //public DelegateCommand Changed { get; protected set; }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }

        private string _name;
        private int _selectedIndexOfAccauntType;
        public int SelectedIndexOfAccauntType { get { return _selectedIndexOfAccauntType; } set { _selectedIndexOfAccauntType = value; if (accType[_selectedIndexOfAccauntType] == "Врач") { DocVis = Visibility.Visible; MedVis = Visibility.Collapsed; } else if (accType[_selectedIndexOfAccauntType] == "Медперсонал") { DocVis = Visibility.Collapsed; MedVis = Visibility.Visible; } else { DocVis = Visibility.Collapsed; MedVis = Visibility.Collapsed; } OnPropertyChanged(); } }

        public string Name { get { return _name; } set { _name = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }




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
            //if (String.IsNullOrWhiteSpace(Password))
            //{
            //    TextBoxSurnameB = Brushes.Red;

            //    result = false;
            //}


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
        private void Changed(object sender, object data)
        {
            nameOfButton = "Сохранить";
        }

        private void GetUserForEditUser(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                MedsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
                DocsDataSource = new ObservableCollection<DocDataSoursForNewUser>();
                MedPersonalRepository medRip = new MedPersonalRepository(context);
                AccauntRepository acRep = new AccauntRepository(context);
                DoctorRepository dcRep = new DoctorRepository(context);



                currentUser = Data.Accaunt.Get((int)data);
                Name = currentUser.Name;
                if (currentUser.isAdmin == true)
                {
                    SelectedIndexOfAccauntType = accType.IndexOf("Админ");
                }
                else if (currentUser.isDoctor == true)
                {
                    SelectedIndexOfAccauntType = accType.IndexOf("Врач");
                    var doc = dcRep.Get(currentUser.idврач.Value);
                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";
                    MedVis = Visibility.Collapsed;
                    DocVis = Visibility.Visible;
                    DocsDataSource.Add(new DocDataSoursForNewUser(doc.Sirname + initials, doc.Id));
                    DocsDataSource[0].IsChecked = true;


                }
                else if (currentUser.isSecretar == true)
                {
                    SelectedIndexOfAccauntType = accType.IndexOf("Секретарь");
                }
                else if (currentUser.isMedPersonal == true)
                {
                    SelectedIndexOfAccauntType = accType.IndexOf("Медперсонал");
                    var doc = medRip.Get(currentUser.idмедперсонал.Value);
                    string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ". ";
                    MedVis = Visibility.Visible;
                    DocVis = Visibility.Collapsed;
                    MedsDataSource.Add(new DocDataSoursForNewUser(doc.Surname + initials, doc.Id));
                    MedsDataSource[0].IsChecked = true;
                }
                bool test = true;
                foreach (var doc in dcRep.GetAll)
                {
                    test = true;

                    foreach (var acc in acRep.GetAll)
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
                foreach (var doc in medRip.GetAll)
                {
                    test = true;

                    foreach (var acc in acRep.GetAll)
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
            nameOfButton = "К списку пользователей";
        }
        #endregion
        public ViewModelEditUser(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("SomethingChangedUserForEditUser", Changed);

            MessageBus.Default.Subscribe("GetUserForEditUser", GetUserForEditUser);
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
            nameOfButton = "К списку пользователей";

            SetAllFieldsDefault();
            PasswordChabged = new DelegateCommand(
              () =>
              {
                  nameOfButton = "Сохранить";

              }
          );
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
                  Name = currentUser.Name;

                  ((PasswordBox)sender).Password = "";

                  MessageBus.Default.Call("GetUserForEditUser", this,currentUser.Id);

                  nameOfButton = "К списку пользователей";
              }
          );

            SaveAndGoDoctorListCommand = new DelegateCommand<object>(
              (sender) =>
              {
                  Password = ((PasswordBox)sender).Password;
                  sender = null;
                  if (TestRequiredFields())
                  {

                      currentUser = Data.Accaunt.Get(currentUser.Id);
                      currentUser.Name = Name;

                      if (!String.IsNullOrEmpty(Password))
                          currentUser.Password = CalculateMD5Hash(Password);

                      currentUser.isDoctor = false;
                      currentUser.isAdmin = false;
                      currentUser.isMedPersonal = false;
                      currentUser.isSecretar = false;
                      //currentUser.isEnabled = true;

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
