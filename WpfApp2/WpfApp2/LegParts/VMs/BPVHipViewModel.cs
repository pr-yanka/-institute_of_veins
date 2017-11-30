using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class BPVHipViewModel : LegPartViewModel
    {
        private List<LegSectionViewModel> _sections;
        public override List<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public BPVHipViewModel(NavigationController controller) : base(controller)
        {
            LevelCount = 5;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                LegSections.Add(new BPVHipSectionViewModel(i + 1));
            }
            _title = "Большая подкожная вена на голени";
        }

        public BPVHipViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            LevelCount = 5;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                LegSections.Add(new BPVHipSectionViewModel(i + 1));
            }
            _title = "Большая подкожная вена на голени";
        }
    }
}
