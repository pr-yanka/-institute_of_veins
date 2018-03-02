using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.MPV;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts.VMs
{
    public class MPVViewModel : LegPartViewModel
    {


        public List<MPVWay> MPVWayType { get; set; }
        public int? SelectedMPVWayTypeId { get; set; }


        private void Rebuild(object sender, object data)
        {
            if (Controller.CurrentViewModel.Controller.LegViewModel == this && mode == "Normal")
            {
                var section = (LegSectionViewModel)data;
                if (section.SelectedValue != null && section.SelectedValue.Text1 == "" && section.SelectedValue.Text2 == "")
                {



                    for (int i = section.ListNumber - 1; i < LegSections.Count; i++)
                    {

                        LegSections[i].SelectedValue = null;
                    }

                    if (section.ListNumber - 1 == 0)
                    { IsEmpty = true; }


                }
                else if (section.SelectedValue != null && section.SelectedValue.Text1 == "Переход к следующему разделу")
                {
                    for (int i = section.ListNumber; i < LegSections.Count; i++)
                    {

                        LegSections[i].SelectedValue = null;
                    }

                    if (section.ListNumber - 1 == 0)
                    { IsEmpty = true; }
                }
                else if (section.SelectedValue != null)
                {


                    if (section.ListNumber != 4 && LegSections[section.ListNumber].SelectedValue == null)
                    {


                        var StructureSourceBuf = new List<int>();
                        bool test = true;
                        int selectCombo = 0;
                        int selectComboNext = 0;

                        var bufSave = new ObservableCollection<LegPartDbStructure>();
                        bufSave = LegSections[section.ListNumber].StructureSource;
                        using (MySqlContext context = new MySqlContext())
                        {
                            MPVRepository MPV = new MPVRepository(context);
                            MPVComboRepository MPVCombo = new MPVComboRepository(context);
                            MetricsRepository Metrics = new MetricsRepository(context);
                            LegSections[section.ListNumber].StructureSource = new ObservableCollection<LegPartDbStructure>(MPV.LevelStructures(LegSections[section.ListNumber].ListNumber).ToList());


                            foreach (var variant in bufSave)
                            {

                                if (variant.Text1 == "Свой вариант ответа" || variant.Text1 == "Переход к следующему разделу")
                                {
                                    LegSections[section.ListNumber].StructureSource.Add(variant);
                                }
                                else if (variant.Text1 == "" && variant.Text2 == "")
                                { LegSections[section.ListNumber].StructureSource.Add(variant); }


                            }
                            foreach (var structure in LegSections[section.ListNumber].StructureSource)
                            {
                                structure.Metrics = Metrics.GetStr(structure.Size);
                            }

                            // StructureSource = new ObservableCollection<LegPartDbStructure>();
                            foreach (var Combo in MPVCombo.GetAll)
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
                                if (section.ListNumber == 3)
                                {
                                    try
                                    {
                                        selectCombo = Combo.IdStr3.Value;
                                        selectComboNext = Combo.IdStr4.Value;
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
                            if (test && variant.Text1 != "Свой вариант ответа" && variant.Text1 != "Переход к следующему разделу")
                            {
                                if (variant.Text1 == "" && variant.Text2 == "")
                                {
                                }
                                else
                                {
                                    LegSections[section.ListNumber].StructureSource.Remove(variant);
                                }
                            }


                        }

                    }
                }
            }
        }

        private void RebuildFirst(object sender, object data)
        {

            using (MySqlContext context = new MySqlContext())
            {
                MPVRepository MPV = new MPVRepository(context);
                MetricsRepository Metrics = new MetricsRepository(context);
                var bufSaveLegSection = new List<int?>();

                foreach (var x in LegSections)
                {
                    if (x.SelectedValue != null)
                        bufSaveLegSection.Add(x.SelectedValue.Id);
                    else
                    {
                        bufSaveLegSection.Add(null);
                    }
                }
                for (int i = 0; i < LegSections.Count; ++i)
                {
                    var bufSave = new ObservableCollection<LegPartDbStructure>();
                    bufSave = LegSections[i].StructureSource;


                    LegSections[i].StructureSource = new ObservableCollection<LegPartDbStructure>(MPV.LevelStructures(i + 1).ToList());


                    int selectedIndex = -1;
                    if (bufSaveLegSection[i] != null)
                    {
                        for (int j = 0; j < LegSections[i].StructureSource.Count; ++j)
                        {
                            if (LegSections[i].StructureSource[j].Id == bufSaveLegSection[i])
                            {
                                selectedIndex = j;
                            }
                        }
                    }


                    if (selectedIndex != -1)
                        LegSections[i].SelectedValue = LegSections[i].StructureSource[selectedIndex];
                    foreach (var variant in bufSave)
                    {

                        if (variant.Text1 == "Свой вариант ответа" || variant.Text1 == "Переход к следующему разделу")
                        {
                            if (variant.Text1 == "Переход к следующему разделу" && i == 0)
                            { }
                            else
                            {
                                LegSections[i].StructureSource.Add(variant);
                            }
                        }
                        else if (variant.Text1 == "" && variant.Text2 == "")
                        { LegSections[i].StructureSource.Add(variant); }


                    }
                    foreach (var structure in LegSections[i].StructureSource)
                    {
                        structure.Metrics = Metrics.GetStr(structure.Size);
                    }

                }
            }
            MessageBus.Default.Call("LegDataSaved", this, this.GetType());


        }

        private ObservableCollection<LegSectionViewModel> _sections;
        public override ObservableCollection<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public void Initialize()
        {
            MessageBus.Default.Subscribe("RebuildFirstMPV", RebuildFirst);
            MessageBus.Default.Subscribe("RebuildLegSectionViewModel", Rebuild);

            SavePanelCommand = new DelegateCommand(() =>
            {
                var panel = CurrentPanelViewModel;
                if (!string.IsNullOrWhiteSpace(panel.Text1) || !string.IsNullOrWhiteSpace(panel.Text2))
                {
                    CurrentLegSide = CurrentLegSide;
                    CurrentPanelViewModel.PanelOpened = false;
                    handled = false;
                    var newStruct = GetPanelStructure();
                    newStruct.Custom = false;
                    Data.MPV.Add((MPVStructure)newStruct);
                    Data.Complete();
                    _lastSender.StructureSource.Add(newStruct);
                    _lastSender.SelectedValue = newStruct;
                    CurrentPanelViewModel.PanelOpened = false;
                    handled = false;
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }

                //_lastSender.DeleteCustom();
            });
            SaveCommand = new DelegateCommand(
              () =>
              {
                  if (LegSections[0].SelectedValue != null)
                  {
                      bool test = true;
                      foreach (var leg in LegSections)
                      {
                          if (leg.HasSize && leg.CurrentEntry.Size == 0)
                          { test = false; }
                          //if(leg.HasDoubleSize && leg.Size2 == 0)
                          //{
                          //    test = false;
                          //}
                      }
                      if (test)
                      {
                          IsEmpty = false;

                          List<int?> ids = new List<int?>();

                          foreach (var leg in LegSections)
                          {
                              //никогда так не делайте
                              if (leg.IsVisible == Visibility.Visible && leg.ListNumber != 1 && leg.SelectedValue != null && leg.SelectedValue.Id != 0)
                                  ids.Add(leg.SelectedValue.Id);
                          }

                          var combo = Data.MPVCombos.FindCombo(LegSections[0].SelectedValue.Id, ids);
                          //если комбо не нашлось - значит оно кастомное, мы его запомним и отправим в базу на радость будущим пользователям
                          if (combo == null)
                          {
                              var newCombo = new MPVCombo();

                              for (int i = 0; i < LegSections.Count; i++)
                              {
                                  var currentStructure = LegSections[i].SelectedValue;
                                  //ничего не было выбрано
                                  if (currentStructure == null) continue;
                                  //добавляем структуры, которые встретились впервые, чтобы потом добавить комбо
                                  if (currentStructure.Id == 0
                                //потому что переход к след.разделу в комбо добавлять не надо, это излишняя информация
                                && !currentStructure.ToNextPart)
                                  {
                                      //currentStructure.Level = i + 1;
                                      //Data.MPV.Add((MPVtructure)currentStructure);
                                      //Data.Complete();
                                      //((MPVEntry)LegSections[i].CurrentEntry).Structure = (MPVtructure)currentStructure;
                                      //(LegSections[i].CurrentEntry).StructureID = currentStructure.Id;
                                      //Data.MPVEntries.Add((MPVEntry)LegSections[i].CurrentEntry);
                                      //Data.Complete();
                                      //if (i == 0) newCombo.IdStr1 = currentStructure.Id;
                                      ////там гда раньше был ноль теперь будет актуальный айдишник
                                      //else ids[i - 2] = currentStructure.Id;
                                  }
                              }

                              newCombo.IdStr1 = LegSections[0].SelectedValue.Id;
                              //заполняем комбо
                              Data.MPVCombos.AddCombo(newCombo, ids);
                              Data.Complete();
                              MessageBus.Default.Call("RebuildFirstMPV", this, LegSections[0]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[0]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[1]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[2]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[3]);
                          }
                          MessageBus.Default.Call("LegDataSaved", this, this.GetType());
                          Controller.NavigateTo<ViewModelAddPhysical>();
                      }
                      else { MessageBox.Show("Не все поля заполнены"); }
                  }
                  else
                  {
                      MessageBus.Default.Call("LegDataSaved", this, this.GetType());
                      Controller.NavigateTo<ViewModelAddPhysical>();
                  }
              }
          );
            MPVWayType = new List<MPVWay>();
            foreach (var way in Data.MPVWay.GetAll)
            {
                MPVWayType.Add(way);
            }


            LevelCount = 4;
            _sections = new ObservableCollection<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new MPVSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSections.Add(new MPVSectionViewModel(Controller, null, i + 1));
            }
            _title = "Малая подкожная вена";
        }

        public MPVViewModel(NavigationController controller) : base(controller) { }

        public MPVViewModel(NavigationController controller, LegSide side) : base(controller, side)
        {
            Initialize();
        }
    }
}
