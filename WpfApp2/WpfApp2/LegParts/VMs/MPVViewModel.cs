﻿using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.MPV;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.LegParts.VMs
{
    public class MPVViewModel : LegPartViewModel
    {

        private ObservableCollection<MPVWay> _mPVWayType;
        public ObservableCollection<MPVWay> MPVWayType
        {
            get { return _mPVWayType; }
            set { _mPVWayType = value; OnPropertyChanged(); }
        }
        private int? _selectedMPVWayTypeId;
        public int? SelectedMPVWayTypeId
        {
            get { return _selectedMPVWayTypeId; }
            set { _selectedMPVWayTypeId = value; OnPropertyChanged(); }
        }
        private MPVVayTypePanelViewModel _currentPanelViewModelWaySelect;
        public override ViewModelBase CurrentPanelViewModelWaySelect
        {
            get { return _currentPanelViewModelWaySelect; }
            set { _currentPanelViewModelWaySelect = value as MPVVayTypePanelViewModel; OnPropertyChanged(); }
        }
        public string TextOFNewType { get; set; }

        public DelegateCommand RevertWayCommand { set; get; }

        public DelegateCommand SavetWayCommand { set; get; }

        public ICommand OpenAddtWayCommand { protected set; get; }
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


                    if (section.ListNumber < 4 && LegSections[section.ListNumber].SelectedValue == null)
                    {


                        var StructureSourceBuf = new List<int>();
                        bool test = true;
                        int selectCombo = 0;
                        int selectComboNext = 0;

                        var bufSave = new ObservableCollection<LegPartDbStructure>();
                        bufSave = LegSections[section.ListNumber].StructureSource;
                        if (((LegPartViewModel)Controller.CurrentViewModel.Controller.LegViewModel).CurrentLegSide != this.CurrentLegSide) return; 
                        LegSections[section.ListNumber].StructureSource = new ObservableCollection<LegPartDbStructure>(Data.MPV.LevelStructures(LegSections[section.ListNumber].ListNumber).ToList());


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
                            structure.Metrics = Data.Metrics.GetStr(structure.Size);
                        }

                        // StructureSource = new ObservableCollection<LegPartDbStructure>();
                        foreach (var Combo in Data.MPVCombos.GetAll)
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

            if (((LegPartViewModel)Controller.CurrentViewModel.Controller.LegViewModel).CurrentLegSide != this.CurrentLegSide) return; 
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


                LegSections[i].StructureSource = new ObservableCollection<LegPartDbStructure>(Data.MPV.LevelStructures(i + 1).ToList());


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
                    structure.Metrics = Data.Metrics.GetStr(structure.Size);
                }

            }

            MessageBus.Default.Call("LegDataSaved", this, this.GetType());

            FF_lengthSave = FF_length;
            SelectedWayTypeSave = SelectedWayType;
            LegSectionsSaved = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSectionsSaved.Add(new MPVSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSectionsSaved.Add(new MPVSectionViewModel(Controller, null, i + 1));
            }

            commentSave = Comment; for (int i = 0; i < LegSections.Count; i++)
            {

                LegSectionsSaved[i].Comment = LegSections[i].Comment;
                LegSectionsSaved[i].Size = LegSections[i].Size;
                LegSectionsSaved[i].Size2 = LegSections[i].Size2;
                LegSectionsSaved[i].Text1 = LegSections[i].Text1;
                LegSectionsSaved[i].Text2 = LegSections[i].Text2;
                LegSectionsSaved[i].SelectedValue = LegSections[i].SelectedValue;
                LegSectionsSaved[i].CurrentEntry = LegSections[i].CurrentEntry;
            }
            MPVWayType = new ObservableCollection<MPVWay>();

            foreach (var Scintific in Data.MPVWay.GetAll)
            {
                MPVWayType.Add(Scintific);
            }
            MPVWay emptyWay = new MPVWay();
            emptyWay.Name = "";
            MPVWayType.Add(emptyWay);
            SelectedWayType = SelectedWayTypeSave;
        }

        private ObservableCollection<LegSectionViewModel> _sections;
        public override ObservableCollection<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public void Initialize()
        {
            TextOFNewType = "Новый МПВ ход";
            MessageBus.Default.Subscribe("RebuildFirstMPV", RebuildFirst);
            MessageBus.Default.Subscribe("RebuildLegSectionViewModel", Rebuild);
            CurrentPanelViewModelWaySelect = new MPVVayTypePanelViewModel(this);
            OpenAddtWayCommand = new DelegateCommand(() =>
            {
                ((MPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).ClearPanel();
                ((MPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = true;
            });

            SavetWayCommand = new DelegateCommand(() =>
            {
                var newType = ((MPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Name))
                {
                    ((MPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = false;

                    //Handled = false;

                    Data.MPVWay.Add((newType));

                    Data.Complete();
                    PanelOpened = true;
                    var DataSourceListbuf = MPVWayType;
                    MPVWayType = new ObservableCollection<MPVWay>();

                    foreach (var Scintific in Data.MPVWay.GetAll)
                    {
                        MPVWayType.Add(Scintific);
                    }
                    MPVWay emptyWay = new MPVWay();
                    emptyWay.Name = "";
                    MPVWayType.Add(emptyWay);
                    SelectedMPVWayTypeId = MPVWayType.Count - 1;
                    // Controller.NavigateTo<BPVHipViewModel>();

                    PanelOpened = false;
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertWayCommand = new DelegateCommand(() =>
            {
                ((MPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = false;
                PanelOpened = false;
            });
            SavePanelCommand = new DelegateCommand(() =>
            {
                var panel = CurrentPanelViewModel;
                if (!string.IsNullOrWhiteSpace(panel.Text1) || !string.IsNullOrWhiteSpace(panel.Text2))
                {
                    CurrentLegSide = CurrentLegSide;

                    if (IsStructEdited(CurrentPanelViewModel.LegPrt) && testOnUnique(CurrentPanelViewModel.LegPrt))
                    {
                        var newStruct = GetPanelStructure();
                        newStruct.Custom = false;

                        Data.MPV.Add((MPVStructure)newStruct);
                        Data.Complete();
                        _lastSender.StructureSource.Add(newStruct);
                        _lastSender.SelectedValue = newStruct;
                        CurrentPanelViewModel.PanelOpened = false;
                        handled = false;
                    }
                    if (!IsStructEdited(CurrentPanelViewModel.LegPrt))
                    {
                        CurrentPanelViewModel.PanelOpened = false;
                        handled = false;
                    }
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
                      bool isValid = Validate();
                      if (isValid)
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

                              commentSave = Comment; for (int i = 0; i < LegSections.Count; i++)
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
                  }
                  else
                  {
                      MessageBus.Default.Call("LegDataSaved", this, this.GetType());
                      Controller.NavigateTo<ViewModelAddPhysical>();
                  }
              }
          );
            MPVWayType = new ObservableCollection<MPVWay>();
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

        protected override bool Validate()
        {
            bool isValid = true;
            if (LegSections[0].SelectedValue != null)
            {
                foreach (var leg in LegSections)
                {
                    if (leg.HasSize && leg.CurrentEntry.Size == 0)
                    {
                        isValid = false;
                    }
                    //if (leg.HasDoubleSize && leg.CurrentEntry.Size2 == 0)
                    //{
                    //    isValid = false;
                    //}
                }
            }
            if (!isValid)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            return isValid;
        }
    }
}
