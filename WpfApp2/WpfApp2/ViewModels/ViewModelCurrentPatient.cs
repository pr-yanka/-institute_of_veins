﻿using System;
using System.Collections.Generic;
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
    public class ViewModelCurrentPatient : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private Visibility _isVisibleForSecretary;
        public Visibility IsVisibleForSecretary { get { return _isVisibleForSecretary; } set { _isVisibleForSecretary = value; OnPropertyChanged(); } }

        int Acc_id = 0;

        private void SetAccID(object sender, object data)
        {
            Acc_id = (int)data;
            var acc = Data.Accaunt.Get(Acc_id);
            if (acc.isSecretar != null && acc.isSecretar.Value)
            {
                IsVisibleForSecretary = Visibility.Hidden;
            }
            else
            {
                IsVisibleForSecretary = Visibility.Visible;
            }
        }
        public DelegateCommand ToEditPatientCommand { get; protected set; }
        public DelegateCommand ToTablePatientsCommand { get; protected set; }
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToNewOperationCommand { get; protected set; }
        public DelegateCommand ToNewPhysicalCommand { get; protected set; }
        public DelegateCommand ToAddAnalysesCommand { get; protected set; }
        public DelegateCommand ToViewHistoryCommand { get; protected set; }
        public DelegateCommand ToPathologyListCommand { get; protected set; }
        public DelegateCommand ToAddAnalizeCommand { get; protected set; }
        public DelegateCommand ToAdditionalInfoCommand { get; protected set; }
        //protected int CurrentPatientID;  

        public string PatientBirthday { get; set; }

        private Patient currentPatient;

        public Patient CurrentPatient
        {
            get { return currentPatient; }
            set { currentPatient = value; }
        }
        private Visibility _isDistrict;
        public Visibility IsDistrict { get { return _isDistrict; } set { _isDistrict = value; OnPropertyChanged(); } }

        public string Town { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }

        private string _ageText;
        public string AgeText { get { return _ageText; } set { _ageText = value; OnPropertyChanged(); } }

        private void SetCurrentPatientID(object sender, object data)
        {

            CurrentPatient = Data.Patients.Get((int)data);
            PatientBirthday = CurrentPatient.Birthday.Day.ToString() + "." + CurrentPatient.Birthday.Month.ToString() + "." + CurrentPatient.Birthday.Year.ToString();

            Town = "Город: " + Data.Cities.Get(CurrentPatient.City).Str;
            if (CurrentPatient.District != null)
            {
                District = "Регион: " + Data.Districts.Get(CurrentPatient.District.Value).Str;
                IsDistrict = Visibility.Visible;
            }
            else
            {
                IsDistrict = Visibility.Hidden;
            }
            Region = "Область: " + Data.Regions.Get(CurrentPatient.Region).Str;
            Street = "Улица: " + Data.Streets.Get(CurrentPatient.Street).Str + " " + CurrentPatient.House + " кв. " + CurrentPatient.Flat;
            char[] chararr = CurrentPatient.Age.ToString().ToCharArray();
            try
            {
                string agelastNumb = chararr[chararr.Length - 1].ToString();
                float buff = 0f;
                if (float.TryParse(agelastNumb, out buff))
                {
                    if (CurrentPatient.Age >= 10 && CurrentPatient.Age <= 19)
                    {
                        AgeText = " лет ";
                    }
                    else if (buff == 1)
                    { AgeText = " год "; }
                    else if (buff >= 2 && buff <= 4)
                    {
                        AgeText = " года ";
                    }
                    else if (buff == 0 || (buff >= 5 && buff <= 9))
                    {
                        AgeText = " лет ";
                    }
                }
            }
            catch { }
        }

        public ViewModelCurrentPatient(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("GetCurrentPatientId", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetAccIDForCurrentPatient", SetAccID);
            base.HasNavigation = true;



            ToNewOperationCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("SetCurrentPatientForOperation", this, currentPatient.Id);
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );

            ToAdditionalInfoCommand = new DelegateCommand(() =>
               {
                   MessageBus.Default.Call("SetCurrentPatientIDForAmbCard", this, currentPatient.Id);

                   Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
               }
            );
            ToPathologyListCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForPatology", this, currentPatient.Id);

                    Controller.NavigateTo<ViewModelPathologyList>();
                }
            );

            ToTablePatientsCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("UpdateTableOfPatients", this, controller);
                    Controller.NavigateTo<ViewModelTablePatients>();
                }
            );

            ToDashboardCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelDashboard>();
                }
            );

            ToEditPatientCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientIdForEdit", this, currentPatient.Id);
                    Controller.NavigateTo<ViewModelEditPatient>();
                }
            );

            ToNewPhysicalCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetCurrentPatientIdForOperation", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
                );

            ToViewHistoryCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("OpenHistoryOfPatient", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelViewHistory>();
                });

            ToAddAnalizeCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetPatientForAnalize", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelAddAnalize>();
                });
        }
    }
}

