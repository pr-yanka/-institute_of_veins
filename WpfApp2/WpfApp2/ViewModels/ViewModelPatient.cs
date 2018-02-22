using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelPatient : ViewModelBase
    {
        public DelegateCommand ToPatientCommand { get; protected set; }
        public DelegateCommand ToPatientHistory { get; protected set; }
        private Patient _patient;

        public bool IsFilteredName { get; set; }
        public bool IsFilteredAge { get; set; }



        public bool IsVisibleTotal { get; set; }

        public ViewModelPatient(NavigationController controller, Patient patient) : base(controller)
        {
            IsVisibleTotal = true;
            IsFilteredName = false;
            IsFilteredAge = false;
            _patient = patient;
            ToPatientCommand = new DelegateCommand(
              () =>
              {
                  MessageBus.Default.Call("OpenCurrentPatient", this, patient.Id);
                  Controller.NavigateTo<ViewModelCurrentPatient>();
              }
            );
            ToPatientHistory = new DelegateCommand(
            () =>
            {
                MessageBus.Default.Call("OpenHistoryOfPatient", this, patient.Id);
                Controller.NavigateTo<ViewModelViewHistory>();
            }
         );
        }



        public Patient CurrentPatient
        {
            get { return _patient; }
            set { _patient = value; }
        }


        private void ToPatient(object sender, RoutedEventArgs e)
        {

        }
    }
}
