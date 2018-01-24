using System.Collections.ObjectModel;
using System.Linq;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class TEMPVSectionViewModel : LegSectionViewModel
    {
        public TEMPVSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.TEMPV.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(TEMPVStructure));
            AddNextPartObject(typeof(TEMPVStructure));
            AddEmpty(typeof(TEMPVStructure));
            CurrentEntry = new TEMPVEntry();
        }
    }
}