using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class SFSSectionViewModel : LegSectionViewModel
    {
        public SFSSectionViewModel(NavigationController controller, int number) : base(controller)
        {
            ListNumber = number;
        }
    }
}
