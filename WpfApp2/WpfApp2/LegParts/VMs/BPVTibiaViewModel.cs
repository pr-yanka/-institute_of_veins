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

        public void Initialize()
        {
            LevelCount = 4;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new BPVTibiaSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSections.Add(new BPVTibiaSectionViewModel(Controller, null, i + 1));
            }
            _title = "Большая подкожная вена на голени";
        }

        public BPVTibiaViewModel(NavigationController controller) : base(controller) { }

        public BPVTibiaViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }
    }
}
