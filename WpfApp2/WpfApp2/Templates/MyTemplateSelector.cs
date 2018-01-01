using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.LegParts;
using WpfApp2.ViewModels;

namespace WpfApp2.Templates
{
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateAddAnalize { get; set; }
        public DataTemplate TemplateLogin { get; set; }
        public DataTemplate TemplateRegistration { get; set; }
        public DataTemplate TemplateDashboard { get; set; }
        public DataTemplate TemplateCurrentPatient { get; set; }
        public DataTemplate TemplateNewPatient { get; set; }
        public DataTemplate TemplateTablePatients { get; set; }
        public DataTemplate TemplateAddPhysicalPage1 { get; set; }
        public DataTemplate TemplateEditPatient { get; set; }
        public DataTemplate TemplateViewHistory { get; set; }
        public DataTemplate TemplateLegDescribe { get; set; }
        public DataTemplate TemplateSymptomsAdd { get; set; }
        public DataTemplate TemplateRecomendationsAdd { get; set; }
        public DataTemplate TemplatePhysicalTable { get; set; }
        public DataTemplate TemplateOperationOverview { get; set; }
        public DataTemplate TemplateCalendarOperations { get; set; }
        public DataTemplate TemplatePathologyList { get; set; }
        public DataTemplate TemplateAddPathology { get; set; }
        public DataTemplate TemplateCreateOperation { get; set; }
        public DataTemplate TemplateOperationResultOverview { get; set; }
        public DataTemplate TemplateAddOperationResult { get; set; }
        public DataTemplate TemplateEditOperation { get; set; }
        public DataTemplate TemplateAnalize { get; set; }
        public DataTemplate LegPartMainTemplate { get; set; }
        public DataTemplate TemplateCheckboxes { get; set; }

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

            if (item.GetType() == typeof(ViewModelAddPhysical))
                return TemplateAddPhysicalPage1;

            if (item.GetType() == typeof(ViewModelEditPatient))
                return TemplateEditPatient;

            if (item.GetType() == typeof(ViewModelViewHistory))
                return TemplateViewHistory;

            if (item.GetType() == typeof(ViewModelLegDescribe))
                return TemplateLegDescribe;

            if (item.GetType() == typeof(ViewModelSymptomsAdd))
                return TemplateSymptomsAdd;

            if (item.GetType() == typeof(ViewModelRecomendationsAdd))
                return TemplateRecomendationsAdd;

            if (item.GetType() == typeof(ViewModelPhysicalTable))
                return TemplatePhysicalTable;

            if (item.GetType() == typeof(ViewModelOperationOverview))
                return TemplateOperationOverview;

            if (item.GetType() == typeof(ViewModelCalendarOperations))
                return TemplateCalendarOperations;

            if (item.GetType() == typeof(ViewModelPathologyList))
                return TemplatePathologyList;

            if (item.GetType() == typeof(ViewModelAddPathology))
                return TemplateAddPathology;

            if (item.GetType() == typeof(ViewModelCreateOperation))
                return TemplateCreateOperation;

            if (item.GetType() == typeof(ViewModelOperationResultOverview))
                return TemplateOperationResultOverview;

            if (item.GetType() == typeof(ViewModelAddOperationResult))
                return TemplateAddOperationResult;

            if (item.GetType() == typeof(ViewModelEditOperation))
                return TemplateEditOperation;

            if (item.GetType() == typeof(ViewModelPhysicalOverview))
                return TemplateAddPhysicalPage1;

            if (item.GetType() == typeof(ViewModelAnalizeOverview))
                return TemplateAnalize;

            if (item.GetType() == typeof(ViewModelAddOperation))
                return TemplateEditOperation;

            if (item.GetType() == typeof(ViewModelAddAnalize))
                return TemplateAddAnalize;

            if (item.GetType() == typeof(LegPartViewModel))
                return LegPartMainTemplate;

            if (item.GetType() == typeof(ViewModelComplainsList))
                return TemplateCheckboxes;

            if (item.GetType() == typeof(ViewModelDiagnosisList))
                return TemplateCheckboxes;

            if (item.GetType() == typeof(ViewModelRecomendationsList))
                return TemplateCheckboxes;

            return null;
        }
    }
}
