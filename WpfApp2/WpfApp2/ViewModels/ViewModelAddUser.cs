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

namespace WpfApp2.ViewModels
{

    public class ViewModelAddUser : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand<object> ShowPassword { get; protected set; }
        public DelegateCommand<object> ToDashboardCommand { get; protected set; }
        public DelegateCommand<object> SaveAndGoDoctorListCommand { get; protected set; }
        public DelegateCommand HidePassword { get; protected set; }
        #endregion
        #region Bindings

        public List<string> accType { get; set; }
        
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
      
        public int SelectedIndexOfAccauntType { get; set; }

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


        public ViewModelAddUser(NavigationController controller) : base(controller)
        {
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
                      }
                      else if (accType[SelectedIndexOfAccauntType] == "Админ")
                      {
                          currentUser.isAdmin = true;
                      }
                      else if (accType[SelectedIndexOfAccauntType] == "Медперсонал")
                      {
                          currentUser.isMedPersonal = true;
                      }
                      else if (accType[SelectedIndexOfAccauntType] == "Секретарь")
                      {
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
