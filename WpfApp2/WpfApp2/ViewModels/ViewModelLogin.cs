using Microsoft.Practices.Prism.Commands;
using WpfApp2.Navigation;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models;
using System.Security.Cryptography;
using System.Text;
using System.Security;
using System.Windows.Controls;
using System.Windows;
using WpfApp2.Messaging;

namespace WpfApp2.ViewModels
{
    public class ViewModelLogin : ViewModelBase
    {
        //private string Password { get; set; }

        public string Name { get; set; }
     

        public DelegateCommand ToRegistrationCommand { get; protected set; }
        public DelegateCommand<object> ToDashboardCommand { get; protected set; }

        public BPVHipRepository rep;

        public ViewModelLogin(NavigationController controller) : base(controller)
        {
            HasNavigation = false;
            ToRegistrationCommand = new DelegateCommand(
                () =>
                {

                    Controller.NavigateTo<ViewModelDashboard>();
                    //Controller.NavigateTo<ViewModelRegistration>();
                }
            );

      

            ToDashboardCommand = new DelegateCommand<object>(
                (sender) =>
                {
                    string  CheckSum = CalculateMD5Hash(((PasswordBox)sender).Password);
                    sender = null;
                    bool isUeserNameCorrect = false;
                   
                    foreach (var acc in Data.Accaunt.GetAll)
                    {
                    if (Name == acc.Name && acc.isEnabled == true)
                        {
                            isUeserNameCorrect = true;
                            if (CheckSum == acc.Password)
                            {
                                MessageBus.Default.Call("GetAcaunt",this, acc.Id);
                                Controller.NavigateTo<ViewModelDashboard>();
                               
                               
                            }
                            else
                            { MessageBox.Show("Неправильный логин или пароль"); }
                            break;
                        }
                        
                    }
                    if(!isUeserNameCorrect)
                    {
                        MessageBox.Show("Неправильный логин или пароль");
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
