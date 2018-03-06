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




    public class ViewModelEditMedPersonal : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand SaveAndGoDoctorListCommand { get; protected set; }
        public DelegateCommand GoToDoctorListCommand { get; }
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


        public string Name { get { return _name; } set { _name = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public string Surname { get { return _surname; } set { _surname = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }

        public string Patronimic { get { return _patronimic; } set { _patronimic = value; nameOfButton = "Сохранить"; OnPropertyChanged(); } }



        private Brush _textBox_Name_B;
        private Brush _textBox_Surname_B;
        private Brush _textBox_Patronimic_B;

        public Brush TextBoxNameB { get { return _textBox_Name_B; } set { _textBox_Name_B = value; OnPropertyChanged(); } }

        public Brush TextBoxSurnameB { get { return _textBox_Surname_B; } set { _textBox_Surname_B = value; OnPropertyChanged(); } }
        private int _widthOfBtn;
        public int WidthOfBtn { get { return _widthOfBtn; } set { _widthOfBtn = value; OnPropertyChanged(); } }

        private Visibility _visibilityOfGoBAck;
        public Visibility VisibilityOfGoBAck { get { return _visibilityOfGoBAck; } set { _visibilityOfGoBAck = value; OnPropertyChanged(); } }

        public Brush TextBoxPatronimicB { get { return _textBox_Patronimic_B; } set { _textBox_Patronimic_B = value; OnPropertyChanged(); } }
        #endregion

        #region MessageBus
        private void GetMedForMedEdit(object sender, object data)
        {
            currentMedPersonal = Data.MedPersonal.Get((int)data);
            Name = currentMedPersonal.Name;
            Surname = currentMedPersonal.Surname;
            Patronimic = currentMedPersonal.Patronimic;
            nameOfButton = "К списку медперсонала";
        }
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
        public ViewModelEditMedPersonal(NavigationController controller) : base(controller)
        {
            WidthOfBtn = 300;

            VisibilityOfGoBAck = Visibility.Collapsed;
            base.HasNavigation = true;
            MessageBus.Default.Subscribe("GetMedForMedEdit", GetMedForMedEdit);

            TextHeader = "Добавление медперсонала";

            nameOfButton = "К списку медперсонала";

            SetAllFieldsDefault();
            ToDashboardCommand = new DelegateCommand(
              () =>
              {
                  Name = currentMedPersonal.Name;
                  Surname = currentMedPersonal.Surname;
                  Patronimic = currentMedPersonal.Patronimic;
                  nameOfButton = "К списку медперсонала";
              }
          );

            SaveAndGoDoctorListCommand = new DelegateCommand(
                () =>
                {
                    if (TestRequiredFields())
                    {
                        MedPersonal currentMedPersonalBuf = Data.MedPersonal.Get(currentMedPersonal.Id);
                        currentMedPersonalBuf.Name = Name;
                        currentMedPersonalBuf.Surname = Surname;
                        currentMedPersonalBuf.Patronimic = Patronimic;
                        //currentMedPersonal.isEnabled = true;

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
            GoToDoctorListCommand = new DelegateCommand(
         () =>
         {

             MessageBus.Default.Call("OpenMeds", this, "");
             Controller.NavigateTo<ViewModelViewMedPatient>();


         }
     );
        }
    }
}
