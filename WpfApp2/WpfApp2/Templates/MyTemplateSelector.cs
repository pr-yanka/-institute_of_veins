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
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }
        public DataTemplate Template3 { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            var model = (ViewModelUI)item;
            var type1 = ((ViewModelUI)item).type;
            var type2 = item.GetType();

            if (model.type == UIWindowType.Logins)
                return Template2;

            return Template1;
        }
    }
}
