using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class PatologyDataSource
    {
        public string Name { get; set; }
        public string DateAppear { get; set; }
        public string DateDisapear { get; set; }
        public DelegateCommand ArchiveCommand { get; set; }
        public DelegateCommand RedactCommand { get; set; }

        public Visibility ArchiveButtonVis { get; set; }

        public float Opacity { get; set; }
        private Patology Patology;



        public PatologyDataSource(string Name, string DateAppear, string DateDisapear, DelegateCommand ArchiveCommand, DelegateCommand RedactCommand, Patology Patology, float Opacity)
        {
            this.Name = Name;
            this.DateAppear = DateAppear;
            this.DateDisapear = DateDisapear;
            this.ArchiveCommand = ArchiveCommand;
            this.RedactCommand = RedactCommand;
            this.Patology = Patology;
            this.Opacity = Opacity;
            if (Opacity == 0.38f)
            { ArchiveButtonVis = Visibility.Hidden; }
            else
            {
                ArchiveButtonVis = Visibility.Visible;
            }


        }
    }
    public class ViewModelPathologyList : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion




        public DelegateCommand ToCurrentPatientCommand { get; protected set; }

        public DelegateCommand ToAddPathologyCommand { get; protected set; }

        private ObservableCollection<PatologyDataSource> _patologyList;
        public ObservableCollection<PatologyDataSource> PatologyList { get { return _patologyList; } set { _patologyList = value; OnPropertyChanged(); } }
        private string _initials;
        public string Initials
        {
            get { return _initials; }
            set
            {
                _initials = value;

                OnPropertyChanged();
            }
        }
        public Patient CurrentPatient { get; set; }
        private string getmonthName(int number)
        {
            switch (number)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
            }
            return "";

        }
        private void GetPatientForPatology(object sender, object data)
        {

            PatologyList = new ObservableCollection<PatologyDataSource>();
            CurrentPatient = Data.Patients.Get((int)data);
            Initials = "Пациент: " + CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ". ";

            foreach (var Patology in Data.Patology.GetAll)
            {
                //Patology sadasew
                if (Patology.id_пациента == CurrentPatient.Id)
                {
                    foreach (var PatoType in Data.PatologyType.GetAll)
                    {
                        if (PatoType.Id == Patology.id_патологии)
                        {
                            float OpacityBuf = 0.0f;
                            if (Patology.isArchivatied == true)
                                OpacityBuf = 0.38f;


                            string DateAppear = getmonthName(Patology.MonthAppear.Value.Month) + " " + Patology.YearAppear.Value.Year.ToString() + " года";
                            string DateDisappear = "";
                            try
                            {
                                DateDisappear = getmonthName(Patology.MonthDisappear.Value.Month) + " " + Patology.YearDisappear.Value.Year.ToString() + " года";
                            }
                            catch { }
                            DelegateCommand ToRedactP = new DelegateCommand(
                                () =>
                                {
                                    MessageBus.Default.Call("GetPatologyForRedactPatology", this, Patology);
                                    Controller.NavigateTo<ViewModelRedactPathology>();

                                }
                                );
                            DelegateCommand ToArchiveP = new DelegateCommand(
                                () =>
                                {

                                    MessageBus.Default.Call("GetPatologyForArchivePatology", this, Patology);
                                    Controller.NavigateTo<ViewModelArchivePathology>();
                                }
                                );
                            PatologyList.Add(new PatologyDataSource(PatoType.Str, DateAppear, DateDisappear, ToArchiveP, ToRedactP, Patology, OpacityBuf));
                        }
                    }

                }
            }

        }



        public ViewModelPathologyList(NavigationController controller) : base(controller)
        {
            HasNavigation = true;

            MessageBus.Default.Subscribe("GetPatientForPatology", GetPatientForPatology);

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {
                    //MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    //Controller.NavigateTo<ViewModelCurrentPatient>();
                    //MessageBus.Default.Call("SetCurrentPatientIDForAmbCard", this, CurrentPatient.Id);
                    MessageBus.Default.Call("SetPatologyListforAdditionalInfo", null, null);
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );

            ToAddPathologyCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForAddPatology", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddPathology>();
                }
            );
        }
    }
}
