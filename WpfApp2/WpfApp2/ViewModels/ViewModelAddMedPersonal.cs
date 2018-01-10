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

namespace WpfApp2.ViewModels
{

   


    public class ViewModelAddMedPersonal : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand SaveAndGoDoctorListCommand { get; protected set; }
        #endregion
        #region Bindings
        
        public string _nameOfButton;
        public string nameOfButton { get { return _nameOfButton; } set { _nameOfButton = value; OnPropertyChanged(); } }
        //public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private MedPersonal currentMedPersonal;
        //public DelegateCommand Changed { get; protected set; }
        private string _textHeader;
        public string TextHeader { get { return _textHeader; } set { _textHeader = value; OnPropertyChanged(); } }
     
        private string _name;
        private string _surname;
        private string _patronimic;
    

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        public string Surname { get { return _surname; } set { _surname = value; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; OnPropertyChanged(); } }



        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;

        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }

        public Brush TextBoxPatronimicB { get { return _textBox_Patronimic_B; } set { _textBox_Patronimic_B = value; OnPropertyChanged(); } }
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
           
            return result;
        }

        public void SetAllFieldsDefault()
        {
            TextBoxNameB = Brushes.Gray;

            TextBoxSurnameB = Brushes.Gray;

            TextBoxPatronimicB = Brushes.Gray;

        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ViewModelAddMedPersonal(NavigationController controller) : base(controller)
        {
           
            base.HasNavigation = true;

            TextHeader = "Добавление медперсонала";

            nameOfButton = "Добавить";

            SetAllFieldsDefault();
            ToDashboardCommand = new DelegateCommand(
              () =>
              {
                  Name = "";
                  Surname = "";
                  Patronimic = "";
                  
              }
          );

            SaveAndGoDoctorListCommand = new DelegateCommand(
                () =>
                {
                    if (TestRequiredFields())
                    {
                        currentMedPersonal = new MedPersonal();
                        currentMedPersonal.Name = Name;
                        currentMedPersonal.Surname = Surname;
                        currentMedPersonal.Patronimic = Patronimic;
                        currentMedPersonal.isEnabled = true;
                        Data.MedPersonal.Add(currentMedPersonal);
                        Data.Complete();


                        MessageBus.Default.Call("OpenMeds", this, "");
                        Controller.NavigateTo<ViewModelViewMedPatient>();
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
