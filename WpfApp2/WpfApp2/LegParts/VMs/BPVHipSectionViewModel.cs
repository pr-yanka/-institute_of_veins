using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class BPVHipSectionViewModel : LegSectionViewModel
    {
        public BPVHipSectionViewModel(NavigationController controller, LegSectionViewModel prevSection, int number) : base(controller, prevSection)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.BPVHips.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }
            AddCustomObject(typeof(BPVHipStructure));
        }

    }
}
