using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
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

        public void Initialize()
        {
            LevelCount = 5;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new BPVHipSectionViewModel(Controller, _sections[i-1], i + 1));
                else
                    LegSections.Add(new BPVHipSectionViewModel(Controller, null, i + 1));
            }
            _title = "Большая подкожная вена на бедре";
            CurrentEntry = new BPVHipEntry();
        }

        public BPVHipViewModel(NavigationController controller) : base(controller) { }

        public BPVHipViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }

        
    }
}
