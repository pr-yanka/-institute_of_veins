using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class BPVTibiaViewModel : LegPartViewModel
    {
        private List<LegSectionViewModel> _sections;
        public override List<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public BPVTibiaViewModel(NavigationController controller) : base(controller)
        {
            LevelCount = 4;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                LegSections.Add(new BPVTibiaSectionViewModel(i + 1));
            }
            _title = "Большая подкожная вена на голени";
        }

        public BPVTibiaViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            LevelCount = 4;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                LegSections.Add(new BPVTibiaSectionViewModel(i + 1));
            }
            _title = "Большая подкожная вена на голени";
        }
    }
}
