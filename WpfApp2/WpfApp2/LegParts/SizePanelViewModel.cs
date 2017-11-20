using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts
{
    public class SizePanelViewModel : ViewModelBase
    {
        public bool DoubleSizeAvailable;

        public SizePanelViewModel(NavigationController controller) : base(controller)
        {
        }
    }
}
