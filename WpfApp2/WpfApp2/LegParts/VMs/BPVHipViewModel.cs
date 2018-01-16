using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class BPVHipViewModel : LegPartViewModel
    {

        public List<BPVHipWay> BpvWayType { get; set; }
        public int SelectedBpvWayTypeId { get; set; }
        public BPVHipWay SelectedBpvWayType { get; set; }


        private void Rebuild(object sender, object data)
        {
            var section = (LegSectionViewModel)data;
            if (section.SelectedValue != null && section.SelectedValue.Text1 == "" && section.SelectedValue.Text2 == "")
            {



                for (int i = section.ListNumber-1; i < LegSections.Count; i++)
                {

                      LegSections[i].SelectedValue = null;
                }

                if (section.ListNumber - 1 == 0)
                { IsEmpty = true; }


            }
            else if(section.SelectedValue != null)
            {


                if (section.ListNumber != 5 && LegSections[section.ListNumber].SelectedValue == null)
                {


                    var StructureSourceBuf = new List<int>();
                    bool test = true;
                    int selectCombo = 0;
                    int selectComboNext = 0;

                    var bufSave = new ObservableCollection<LegPartDbStructure>();
                    bufSave = LegSections[section.ListNumber].StructureSource;

                    LegSections[section.ListNumber].StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.BPVHips.LevelStructures(LegSections[section.ListNumber].ListNumber).ToList());
                 
                    foreach (var variant in bufSave)
                    {

                        if (variant.Text1 == "Свой вариант ответа" || variant.Text1 == "Переход к следующему разделу"  )
                        {
                            LegSections[section.ListNumber].StructureSource.Add(variant);
                        }
                        else if(variant.Text1 == "" && variant.Text2 == "")
                        { LegSections[section.ListNumber].StructureSource.Add(variant); }


                    }
                    foreach (var structure in LegSections[section.ListNumber].StructureSource)
                    {
                        structure.Metrics = Data.Metrics.GetStr(structure.Size);
                    }
                    // StructureSource = new ObservableCollection<LegPartDbStructure>();
                    foreach (var Combo in Data.BPVCombos.GetAll)
                    {
                        if (section.ListNumber == 1)
                        {
                            try
                            {
                                selectCombo = Combo.IdStr1;
                                selectComboNext = Combo.IdStr2.Value;
                            }
                            catch { continue; }
                        }
                        if (section.ListNumber == 2)
                        {
                            try
                            {
                                selectCombo = Combo.IdStr2.Value;
                                selectComboNext = Combo.IdStr3.Value;
                            }
                            catch { continue; }
                        }
                        else if (section.ListNumber == 3)
                        {
                            try
                            {
                                selectCombo = Combo.IdStr3.Value;
                                selectComboNext = Combo.IdStr4.Value;
                            }
                            catch { continue; }
                        }
                        else if (section.ListNumber == 4)
                        {
                            try
                            {
                                selectCombo = Combo.IdStr4.Value;
                                selectComboNext = Combo.IdStr5.Value;
                            }
                            catch { continue; }
                        }



                        if (section.SelectedValue.Id == selectCombo)
                        {
                            test = true;

                            foreach (var bufId in StructureSourceBuf)
                            {

                                if (bufId == selectComboNext)
                                {
                                    test = false;
                                    break;
                                }

                            }
                            if (test)
                            {
                                StructureSourceBuf.Add(selectComboNext);
                            }


                        }


                    }

                    List<LegPartDbStructure> buf = LegSections[section.ListNumber].StructureSource.ToList();
                    foreach (var variant in buf)
                    {
                        test = true;
                        foreach (var bufId in StructureSourceBuf)
                        {

                            if (bufId == variant.Id)
                            {
                                test = false;
                                break;
                            }

                        }
                        if (variant.Text1 != "" && variant.Text2 != "")
                        {
                            if (test && variant.Text1 != "Свой вариант ответа" && variant.Text1 != "Переход к следующему разделу")
                            {
                                LegSections[section.ListNumber].StructureSource.Remove(variant);
                            }
                        }


                    }

                }
            }

        }

        private List<LegSectionViewModel> _sections;
        public override List<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public void Initialize()
        {
            MessageBus.Default.Subscribe("RebuildLegSectionViewModel", Rebuild);
            BpvWayType = new List<BPVHipWay>();

            foreach (var way in Data.BPVHipWay.GetAll)
            {
                BpvWayType.Add(way);
            }
            SelectedBpvWayTypeId = 0;
            LevelCount = 5;
            _sections = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new BPVHipSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSections.Add(new BPVHipSectionViewModel(Controller, null, i + 1));

            }
            _title = "Большая подкожная вена на бедре";

        }

        public BPVHipViewModel(NavigationController controller) : base(controller) { }

        public BPVHipViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }


    }
}
