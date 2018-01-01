using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class DoctorDataSource : INotifyPropertyChanged
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
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public Doctor Data { get; set; }

        public string initials { get; set; }

        public DoctorDataSource(Doctor Doctor)
        {
            this.Data = Doctor;
            initials = " " + Doctor.Name.ToCharArray()[0].ToString() + ". " + Doctor.Patronimic.ToCharArray()[0].ToString() + ".";
            IsChecked = false;
        }
    }
    public class ViewModelAddOperation : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void UpdateSelectedDoctors(object sender, object data)
        {
            DoctorsSelected = new List<DoctorDataSource>();
            foreach (var doctor in Doctors)
            {
                if (doctor.IsChecked == true)
                { DoctorsSelected.Add(doctor); }
            }
        }

        public List<OperationType> OprTypes { get; set; }
        public List<Anestethic> AnestethicTypes { get; set; }
        public List<DoctorDataSource> Doctors { get; set; }
        private List<DoctorDataSource> _doctorsSelected;
        public List<DoctorDataSource> DoctorsSelected
        {
            get
            {
                return _doctorsSelected;
            }
            set
            {
                _doctorsSelected = value; OnPropertyChanged();
            }
        }

        public Operation Operation { get; set; }

        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }


        public ViewModelAddOperation(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("UpdateSelectedDoctors", UpdateSelectedDoctors);
            OprTypes = new List<OperationType>();
            AnestethicTypes = new List<Anestethic>();
            Doctors = new List<DoctorDataSource>();
            Controller = controller;
            HasNavigation = false;
            foreach (var Doctor in Data.Doctor.GetAll)
            {
                Doctors.Add(new DoctorDataSource(Doctor));
            }

            ToCurrentPatientCommand = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelCurrentPatient>(); }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () => { Controller.NavigateTo<ViewModelOperationOverview>(); }
            );
        }
    }
}
