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
    public class TibiaPerforateSectionViewModel : LegSectionViewModel
    {
        public TibiaPerforateSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.Perforate_shin.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(Perforate_shinStructure));
            AddNextPartObject(typeof(Perforate_shinStructure));
            AddEmpty(typeof(Perforate_shinStructure));
            CurrentEntry = new Perforate_shinEntry();
        }
    }
}
