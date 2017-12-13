using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class HipPerforateViewModel : LegPartViewModel
    {
        private List<LegSectionViewModel> _sections;
        public override List<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public void Initialize()
        {
            LevelCount = 5;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new HipPerforateSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSections.Add(new HipPerforateSectionViewModel(Controller, null, i + 1));
            }
            _title = "Перфорант бедра и несафенные вены";
        }

        public HipPerforateViewModel(NavigationController controller) : base(controller) { }

        public HipPerforateViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }
    }
}
