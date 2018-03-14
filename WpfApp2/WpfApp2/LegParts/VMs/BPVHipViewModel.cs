using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.LegParts.VMs
{
    public class BPVHipViewModel : LegPartViewModel
    {





        private ObservableCollection<BPVHipWay> _bpvWayType;
        public ObservableCollection<BPVHipWay> BpvWayType
        {
            get { return _bpvWayType; }
            set { _bpvWayType = value; OnPropertyChanged(); }
        }
        private int _selectedBpvWayTypeId;
        public int SelectedBpvWayTypeId
        {
            get { return _selectedBpvWayTypeId; }
            set { _selectedBpvWayTypeId = value; OnPropertyChanged(); }
        }
        private BPVVayTypePanelViewModel _currentPanelViewModelWaySelect;
        public override ViewModelBase CurrentPanelViewModelWaySelect
        {
            get { return _currentPanelViewModelWaySelect; }
            set { _currentPanelViewModelWaySelect = value as BPVVayTypePanelViewModel; OnPropertyChanged(); }
        }

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


                    if (section.ListNumber < 5 && LegSections[section.ListNumber].SelectedValue == null)
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
            if (((LegPartViewModel)Controller.CurrentViewModel.Controller.LegViewModel).CurrentLegSide != this.CurrentLegSide) return; using (MySqlContext context = new MySqlContext())
            {
              
              
                BPVHipRepository BPVHip = new BPVHipRepository(context);
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

                    LegSections[i].StructureSource = new ObservableCollection<LegPartDbStructure>(BPVHip.LevelStructures(i + 1).ToList());



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
            FF_lengthSave = FF_length;
            SelectedWayTypeSave = SelectedWayType;
            LegSectionsSaved = new List<LegSectionViewModel>();
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSectionsSaved.Add(new BPVHipSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSectionsSaved.Add(new BPVHipSectionViewModel(Controller, null, i + 1));
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

            BpvWayType = new ObservableCollection<BPVHipWay>();

            foreach (var Scintific in Data.BPVHipWay.GetAll)
            {
                BpvWayType.Add(Scintific);
                if (Scintific.Id == SelectedWayTypeSave.Id)
                {
                    SelectedBpvWayTypeId = BpvWayType.IndexOf(SelectedWayTypeSave as BPVHipWay);
                }
            }

            SelectedWayType = SelectedWayTypeSave;
        }

        private ObservableCollection<LegSectionViewModel> _sections;

        public override ObservableCollection<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }
        public string TextOFNewType { get; set; }

        public DelegateCommand RevertWayCommand { set; get; }

        public DelegateCommand SavetWayCommand { set; get; }

        public ICommand OpenAddtWayCommand { protected set; get; }

        public void Initialize()
        {
            TextOFNewType = "Новый БПВ ход";
            MessageBus.Default.Subscribe("RebuildFirstBPV", RebuildFirst);
            MessageBus.Default.Subscribe("RebuildLegSectionViewModel", Rebuild);
            BpvWayType = new ObservableCollection<BPVHipWay>();

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
                        Data.BPVHips.Add((BPVHipStructure)newStruct);
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

            CurrentPanelViewModelWaySelect = new BPVVayTypePanelViewModel(this);
            OpenAddtWayCommand = new DelegateCommand(() =>
            {
                ((BPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).ClearPanel();
                ((BPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = true;
            });

            SavetWayCommand = new DelegateCommand(() =>
            {
                var newType = ((BPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Name))
                {
                    ((BPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = false;

                    //Handled = false;

                    Data.BPVHipWay.Add((newType));

                    Data.Complete();
                    PanelOpened = true;
                    var DataSourceListbuf = BpvWayType;
                    BpvWayType = new ObservableCollection<BPVHipWay>();

                    foreach (var Scintific in Data.BPVHipWay.GetAll)
                    {
                        BpvWayType.Add(Scintific);
                    }
                    SelectedBpvWayTypeId = BpvWayType.Count - 1;
                    // Controller.NavigateTo<BPVHipViewModel>();

                    PanelOpened = false;
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertWayCommand = new DelegateCommand(() =>
            {
                ((BPVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = false;
                PanelOpened = false;
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

                           var combo = Data.BPVCombos.FindCombo(LegSections[0].SelectedValue.Id, ids);
                           //если комбо не нашлось - значит оно кастомное, мы его запомним и отправим в базу на радость будущим пользователям
                           if (combo == null)
                           {
                               var newCombo = new BPVHipCombo();

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
                                       //Data.BPVHips.Add((BPVHipStructure)currentStructure);
                                       //Data.Complete();
                                       //((BPVHipEntry)LegSections[i].CurrentEntry).Structure = (BPVHipStructure)currentStructure;
                                       //(LegSections[i].CurrentEntry).StructureID = currentStructure.Id;
                                       //Data.BPVHipEntries.Add((BPVHipEntry)LegSections[i].CurrentEntry);
                                       //Data.Complete();
                                       //if (i == 0) newCombo.IdStr1 = currentStructure.Id;
                                       ////там гда раньше был ноль теперь будет актуальный айдишник
                                       //else ids[i - 2] = currentStructure.Id;
                                   }
                               }

                               newCombo.IdStr1 = LegSections[0].SelectedValue.Id;
                               //заполняем комбо
                               Data.BPVCombos.AddCombo(newCombo, ids);
                               Data.Complete();
                               MessageBus.Default.Call("RebuildFirstBPV", this, LegSections[0]);
                               MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[0]);
                               MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[1]);
                               MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[2]);
                               MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[3]);
                               MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[4]);
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


            foreach (var way in Data.BPVHipWay.GetAll)
            {
                BpvWayType.Add(way);
            }
            SelectedBpvWayTypeId = 0;
            LevelCount = 5;
            _sections = new ObservableCollection<LegSectionViewModel>();
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
