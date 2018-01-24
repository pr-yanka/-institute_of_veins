using System.Collections.ObjectModel;
using System.Linq;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class MPVSectionViewModel : LegSectionViewModel
    {
        public MPVSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.MPV.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(MPVStructure));
            AddNextPartObject(typeof(MPVStructure));
            AddEmpty(typeof(MPVStructure));
            CurrentEntry = new MPVEntry();
        }
    }
}