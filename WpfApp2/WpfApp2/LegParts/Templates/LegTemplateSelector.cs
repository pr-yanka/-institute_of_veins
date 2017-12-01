using System.Windows;
using System.Windows.Controls;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts.Templates
{
    public class LegTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StandartTemplate { get; set; }
        public DataTemplate BPVHipTemplate { get; set; }
        public DataTemplate EmptyTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            //тут ещё айди футляра
            if (item.GetType() == typeof(BPVHipViewModel))
                return BPVHipTemplate;

            if (item.GetType() == typeof(SFSViewModel))
                return EmptyTemplate;

            if (item.GetType() == typeof(HipPerforateViewModel))
                return EmptyTemplate;

            if (item.GetType() == typeof(PDSVViewModel))
                return EmptyTemplate;

            if (item.GetType() == typeof(ZDSVViewModel))
                return EmptyTemplate;

            return null;
        }
    }
}
