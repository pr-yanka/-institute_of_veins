using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class SFSViewModel : LegPartViewModel
    {
        private List<LegSectionViewModel> _sections;
        public override List<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }


        public void Initialize()
        {
            LevelCount = 6;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new SFSSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSections.Add(new SFSSectionViewModel(Controller, null, i + 1));
            }
            _title = "Сафенно-феморальное соустье";
        }

        public SFSViewModel(NavigationController controller) : base(controller) { }

        public SFSViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }
    }
}