﻿using System.Windows;
using System.Windows.Controls;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts.Templates
{
    public class LegTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StandartTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return null;

            if (item.GetType() == typeof(BPVHipSectionViewModel))
                return StandartTemplate;

            if (item.GetType() == typeof(SFSSectionViewModel))
                return StandartTemplate;

            return null;
        }
    }
}