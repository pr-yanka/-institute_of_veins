using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.GV;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class GVSectionViewModel : LegSectionViewModel
    {
        public GVSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(Data.GV.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }
            AddCustomObject(typeof(GVStructure));
            AddNextPartObject(typeof(GVStructure));
            AddEmpty(typeof(GVStructure));
            CurrentEntry = new GVEntry();
        }
    }
}
