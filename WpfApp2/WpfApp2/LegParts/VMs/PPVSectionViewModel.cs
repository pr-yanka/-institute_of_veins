using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.PPV;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class PPVSectionViewModel : LegSectionViewModel
    {
        public PPVSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.PPV.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(PPVStructure));
            AddNextPartObject(typeof(PPVStructure));
            AddEmpty(typeof(PPVStructure));
            CurrentEntry = new PPVEntry();
        }
    }
}
