using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.ViewModels;

namespace WpfApp2.Templates
{
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateLogin { get; set; }
        public DataTemplate TemplateRegistration { get; set; }
        public DataTemplate TemplateDashboard { get; set; }
        public DataTemplate TemplateCurrentPatient { get; set; }
        public DataTemplate TemplateNewPatient { get; set; }
        public DataTemplate TemplateTablePatients { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            if (item.GetType() == typeof(ViewModelDashboard))
                return TemplateDashboard;

            if (item.GetType() == typeof(ViewModelLogin))
                return TemplateLogin;

            if (item.GetType() == typeof(ViewModelRegistration))
                return TemplateRegistration;

            if (item.GetType() == typeof(ViewModelCurrentPatient))
                return TemplateCurrentPatient;

            if (item.GetType() == typeof(ViewModelNewPatient))
                return TemplateNewPatient;

            if (item.GetType() == typeof(ViewModelTablePatients))
                return TemplateTablePatients;

            return null;
        }
    }
}
