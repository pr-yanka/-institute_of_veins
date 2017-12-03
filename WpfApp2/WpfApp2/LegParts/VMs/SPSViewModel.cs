using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class SPSViewModel : LegPartViewModel
    {
        private List<LegSectionViewModel> _sections;
        public override List<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public SPSViewModel(NavigationController controller) : base(controller)
        {
            LevelCount = 3;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                LegSections.Add(new SFSSectionViewModel(i + 1));
            }
            _title = "Сафено поплитеальное соустье";
        }

        public SPSViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            LevelCount = 3;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                LegSections.Add(new SFSSectionViewModel(i + 1));
            }
            _title = "Сафено поплитеальное соустье";
        }
    }
}
