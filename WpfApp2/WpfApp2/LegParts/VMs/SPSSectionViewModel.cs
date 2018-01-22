using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.SPS;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class SPSSectionViewModel : LegSectionViewModel
    {
        public SPSSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.SPS.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(SPSHipStructure));
            AddNextPartObject(typeof(SPSHipStructure));
            AddEmpty(typeof(SPSHipStructure));
            CurrentEntry = new SPSHipEntry();

        }
    }
}
