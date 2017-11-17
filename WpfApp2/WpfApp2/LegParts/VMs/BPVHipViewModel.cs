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
        public BPVHipViewModel(NavigationController controller) : base(controller)
        {
            LevelCount = 5;
            //LegSections = new List<BPVHipSectionViewModel>();
            /*for (int i = 0; i < LegSections.Count; i++)
            {
                LegSections.Add(new BPVHipSectionViewModel());
            }*/
        }    
    }
}
