﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class ZDSVSectionViewModel : LegSectionViewModel
    {
        public ZDSVSectionViewModel(NavigationController controller, LegSectionViewModel prevSection, int number) : base(controller, prevSection)
        {
            ListNumber = number;
        }
    }
}
