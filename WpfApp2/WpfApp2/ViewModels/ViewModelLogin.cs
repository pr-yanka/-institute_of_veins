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
using System.IO;
using System.Collections.Generic;
using System;

namespace WpfApp2.ViewModels
{
    public class ViewModelLogin : ViewModelBase
    {
        //private string Password { get; set; }

        public string Name { get; set; }

        int CurrAccId;

        public DelegateCommand<object> ToDashboardCommand { get; protected set; }

        public BPVHipRepository rep;
        private void SetDefault(object sender, object data)
        {

            Name = "";

        }
        private void SetCurrAccIdBack(object sender, object data)
        {

            MessageBus.Default.Call("SetCurrentACCIDForContext", null, CurrAccId);

        }

        public ViewModelLogin(NavigationController controller) : base(controller)
        {
            HasNavigation = false;
            MessageBus.Default.Subscribe("SetCurrAccIdBack", SetCurrAccIdBack);
            MessageBus.Default.Subscribe("SetAccNameDefault", SetDefault);
            

            ToDashboardCommand = new DelegateCommand<object>(
        (sender) =>
        {
            string CheckSum = CalculateMD5Hash(((PasswordBox)sender).Password);
            sender = null;
            bool isUeserNameCorrect = false;

            foreach (var acc in Data.Accaunt.GetAll)
            {
               
    
                if (Name == acc.Name && acc.isEnabled == true)
                {
                    isUeserNameCorrect = true;
                    if (CheckSum == acc.Password)
                    {

                        CurrAccId = acc.Id;
                        MessageBus.Default.Call("SetCurrentACCIDForContext", null, acc.Id);
                        MessageBus.Default.Call("GetAcaunt", null, acc.Id);
                        MessageBus.Default.Call("SetAccIDForAddExamination", null, acc.Id);
                        MessageBus.Default.Call("SetAccIDForExaminationStatement", null, acc.Id);
                        MessageBus.Default.Call("SetAccIDForHirurgOverview", null, acc.Id);
                        MessageBus.Default.Call("SetAccIDForCurrentPatient", null, acc.Id);
                        MessageBus.Default.Call("SetAccIDForCurrentPatientHistory", null, acc.Id);
                        
                        if ((acc.isDoctor != null && acc.isDoctor.Value) || (acc.isMedPersonal != null && acc.isMedPersonal.Value))
                        {
                            MessageBus.Default.Call("SetVisibilityPanelAdmin", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetVisibilityForDocsOrMed", this, Visibility.Visible);
                            MessageBus.Default.Call("SetCurrentACCOp", this, acc.Id);
                        }
                        else if (acc.isAdmin != null && acc.isAdmin.Value)
                        {
                            // MessageBus.Default.Call("SetVisibilityMyOp", null, null);
                            MessageBus.Default.Call("SetVisibilityPanelAdmin", this, Visibility.Visible);
                            MessageBus.Default.Call("SetAlertVisibility", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetVisibilityForDocsOrMed", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetCurrentACCOp", this, acc.Id);
                        }
                        else if(acc.isSecretar != null && acc.isSecretar.Value)
                        {
                            MessageBus.Default.Call("SetAlertVisibility", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetVisibilityPanelAdmin", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetVisibilityForDocsOrMed", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetCurrentACCOp", this, acc.Id);
                        }
                        else
                        {
                            MessageBus.Default.Call("SetAlertVisibility", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetVisibilityPanelAdmin", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetVisibilityForDocsOrMed", this, Visibility.Collapsed);
                            MessageBus.Default.Call("SetCurrentACCOp", this, acc.Id);
                        }
                        Controller.NavigateTo<ViewModelDashboard>();

                    }
                    else
                    { MessageBox.Show("Неправильный логин или пароль"); }
                    break;
                }

            }
            if (!isUeserNameCorrect)
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
