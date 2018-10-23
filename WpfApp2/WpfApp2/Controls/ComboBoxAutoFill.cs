using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2.Controls
{
    public class ComboBoxAutoFill: ComboBox
    {        
        public ComboBoxAutoFill()
        {
            IsEditable = true;
            IsTextSearchEnabled = false;
            PreviewTextInput += PreviewTextInput_EnhanceComboSearch;
            PreviewKeyUp += PreviewKeyUp_EnhanceComboSearch;
        }

        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void PreviewTextInput_EnhanceComboSearch(object sender, TextCompositionEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            cmb.IsDropDownOpen = true;
            
            if (!string.IsNullOrEmpty(cmb.Text))
            {
                string fullText = cmb.Text.Insert(GetChildOfType<TextBox>(cmb).CaretIndex, e.Text);
                cmb.Items.Filter = (filterItem) =>
                {
                    return FindText(filterItem.ToString(), fullText);
                };
            }
            else if (!string.IsNullOrEmpty(e.Text))
            {
                cmb.Items.Filter = (filterItem) =>
                {
                    return FindText(filterItem.ToString(), cmb.Text);
                };
            }
            else
            {
                cmb.Items.Filter = (filterItem) => { return true; };
            }
        }

        private bool FindText(string initialItem, string foundText)
        {
            return initialItem.ToLowerInvariant().Contains(foundText) || initialItem.Trim() == "Свой вариант ответа" || initialItem.Trim() == "Переход к следующему разделу";
        }

        private void PreviewKeyUp_EnhanceComboSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                ComboBox cmb = (ComboBox)sender;

                cmb.IsDropDownOpen = true;
               
                if (!string.IsNullOrEmpty(cmb.Text))
                {
                    cmb.Items.Filter = (filterItem) =>
                    {
                        return FindText(filterItem.ToString(), cmb.Text);
                    };
                }
                else
                {
                    cmb.Items.Filter = (filterItem) => { return true; };
                }
           }
        }     

    }
}
