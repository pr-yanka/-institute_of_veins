using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ViewModelPatient : ViewModelBase
    {
        private Patient _patient;

        public ViewModelPatient(NavigationController controller, Patient patient) : base(controller)
        {
            _patient = patient;
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
