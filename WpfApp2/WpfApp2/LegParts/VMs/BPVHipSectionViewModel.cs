using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class BPVHipSectionViewModel : LegSectionViewModel
    {
        public BPVHipSectionViewModel(NavigationController controller, int number) : base(controller)
        {
            ListNumber = number;
            StructureSource = new List<LegPartStructure>(base.Data.BPVHips.FirstLevelStructures.ToList());
        }

    }
}
