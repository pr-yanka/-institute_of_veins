﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class PDSVSectionViewModel : LegSectionViewModel
    {
        public PDSVSectionViewModel(NavigationController controller, LegSectionViewModel prev, int number) : base(controller, prev)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.PDSVHips.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(PDSVHipStructure));
            AddNextPartObject(typeof(PDSVHipStructure));
            AddEmpty(typeof(PDSVHipStructure));
            CurrentEntry = new PDSVHipEntry();
        }
    }
}
