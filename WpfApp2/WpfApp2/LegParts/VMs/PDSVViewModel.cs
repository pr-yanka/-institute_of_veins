using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public class PDSVViewModel : LegPartViewModel
    {
        private PDSVAdditionalSectionViewModel additionalStructure;
        public PDSVAdditionalSectionViewModel AdditionalStructure
        {
            get { return additionalStructure; }
            set { additionalStructure = value; }
        }
        private ObservableCollection<PDSVHipWay> _bpvWayType;
        public ObservableCollection<PDSVHipWay> PDSVWayType
        {
            get { return _bpvWayType; }
            set { _bpvWayType = value; OnPropertyChanged(); }
        }
        private int? _selectedBpvWayTypeId;
        public int? SelectedPDSVWayTypeId
        {
            get { return _selectedBpvWayTypeId; }
            set { _selectedBpvWayTypeId = value; OnPropertyChanged(); }
        }
        private PDSVVayTypePanelViewModel _currentPanelViewModelWaySelect;
        public override ViewModelBase CurrentPanelViewModelWaySelect
        {
            get { return _currentPanelViewModelWaySelect; }
            set { _currentPanelViewModelWaySelect = value as PDSVVayTypePanelViewModel; OnPropertyChanged(); }
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


                    if (section.ListNumber < 3 && LegSections[section.ListNumber].SelectedValue == null)
                    {


                        var StructureSourceBuf = new List<int>();
                        bool test = true;
                        int selectCombo = 0;
                        int selectComboNext = 0;

                        var bufSave = new ObservableCollection<LegPartDbStructure>();
                        bufSave = LegSections[section.ListNumber].StructureSource;

                        LegSections[section.ListNumber].StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.PDSVHips.LevelStructures(LegSections[section.ListNumber].ListNumber).ToList());

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
                        foreach (var Combo in Data.PDSVCombos.GetAll)
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
            float savedValue = -1;
            int bufSaveLegAdditionalSection = -1;
            if (AdditionalStructure.SelectedValue != null)
            {
                bufSaveLegAdditionalSection = AdditionalStructure.SelectedValue.Id;
                if (AdditionalStructure.CurrentEntry != null)
                {
                    savedValue = AdditionalStructure.CurrentEntry.Size;
                }
            }
            AdditionalStructure = new PDSVAdditionalSectionViewModel(Controller, null, 0);
            if (bufSaveLegAdditionalSection != -1)
            {
                for (int j = 0; j < AdditionalStructure.StructureSource.Count; ++j)
                {
                    if (AdditionalStructure.StructureSource[j].Id == bufSaveLegAdditionalSection && AdditionalStructure.StructureSource[j].Text1 != "Свой вариант ответа")
                    {
                        bufSaveLegAdditionalSection = j;
                        break;
                    }
                }

                //   if (bufSaveLegAdditionalSection != -1)
                AdditionalStructure.SelectedValue = AdditionalStructure.StructureSource[bufSaveLegAdditionalSection];
                if (savedValue != -1)
                {
                    AdditionalStructure.CurrentEntry.Size = savedValue;
                }
            }
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

                LegSections[i].StructureSource = new ObservableCollection<LegPartDbStructure>(Data.PDSVHips.LevelStructures(i + 1).ToList());

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
                    LegSectionsSaved.Add(new PDSVSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSectionsSaved.Add(new PDSVSectionViewModel(Controller, null, i + 1));
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
            PDSVWayType = new ObservableCollection<PDSVHipWay>();

            foreach (var Scintific in Data.PDSVHipWay.GetAll)
            {
                PDSVWayType.Add(Scintific);
            }

            PDSVHipWay emptyWay = new PDSVHipWay();
            emptyWay.Name = "";
            PDSVWayType.Add(emptyWay);
            SelectedWayType = SelectedWayTypeSave;
        }

        private ObservableCollection<LegSectionViewModel> _sections;
        public override ObservableCollection<LegSectionViewModel> LegSections
        {
            get { return _sections; }
            set { _sections = value; }
        }
        private bool testAdditionalStructOnUnique(LegPartDbStructure structure)
        {
            if (Controller.CurrentViewModel.Controller.LegViewModel == this)
            {

                foreach (var x in AdditionalStructure.StructureSource)
                {
                    if (mode == "Edit")
                    {
                        if (x.HasDoubleMetric == CurrentPanelViewModel.HasDoubleSize
                            && x.HasSize == CurrentPanelViewModel.HasSize
                             && (x.Text1 == CurrentPanelViewModel.Text1 || (string.IsNullOrWhiteSpace(x.Text1) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text1)))
                               && (x.Text2 == CurrentPanelViewModel.Text2 || (string.IsNullOrWhiteSpace(x.Text2) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text2)))
                            && x.Id != structure.Id)
                        {
                            if (x.HasSize == true)
                            {
                                if ((x.Metrics == CurrentPanelViewModel.SelectedMetricText || string.IsNullOrWhiteSpace(x.Metrics) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.SelectedMetricText)))
                                {
                                    MessageBox.Show("Такое описание уже существует!");

                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }


                            MessageBox.Show("Такое описание уже существует!");

                            return false;

                        }
                    }
                    else
                    {
                        if (x.HasDoubleMetric == CurrentPanelViewModel.HasDoubleSize
                               && x.HasSize == CurrentPanelViewModel.HasSize
                               && (x.Text1 == CurrentPanelViewModel.Text1 || (string.IsNullOrWhiteSpace(x.Text1) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text1)))
                               && (x.Text2 == CurrentPanelViewModel.Text2 || (string.IsNullOrWhiteSpace(x.Text2) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.Text2))))

                        {

                            if (x.HasSize == true)
                            {
                                if ((x.Metrics == CurrentPanelViewModel.SelectedMetricText || string.IsNullOrWhiteSpace(x.Metrics) && string.IsNullOrWhiteSpace(CurrentPanelViewModel.SelectedMetricText)))
                                {
                                    MessageBox.Show("Такое описание уже существует!");

                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }


                            MessageBox.Show("Такое описание уже существует!");

                            return false;
                        }

                    }
                }

            }
            return true;
        }
        public void Initialize()
        {
            TextOFNewType = "Новый ПДСВ ход";
            MessageBus.Default.Subscribe("RebuildFirstPDSV", RebuildFirst);
            MessageBus.Default.Subscribe("RebuildLegSectionViewModel", Rebuild);
            CurrentPanelViewModelWaySelect = new PDSVVayTypePanelViewModel(this);
            OpenAddtWayCommand = new DelegateCommand(() =>
            {
                ((PDSVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).ClearPanel();
                ((PDSVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = true;
            });

            SavetWayCommand = new DelegateCommand(() =>
            {
                var newType = ((PDSVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Name))
                {
                    ((PDSVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = false;

                    //Handled = false;

                    Data.PDSVHipWay.Add((newType));

                    Data.Complete();
                    PanelOpened = true;
                    var DataSourceListbuf = PDSVWayType;
                    PDSVWayType = new ObservableCollection<PDSVHipWay>();

                    foreach (var Scintific in Data.PDSVHipWay.GetAll)
                    {
                        PDSVWayType.Add(Scintific);
                    }

                    PDSVHipWay emptyWay1 = new PDSVHipWay();
                    emptyWay1.Name = "";
                    PDSVWayType.Add(emptyWay1);
                    SelectedPDSVWayTypeId = PDSVWayType.IndexOf(newType);
                    // Controller.NavigateTo<BPVHipViewModel>();

                    PanelOpened = false;
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertWayCommand = new DelegateCommand(() =>
            {
                ((PDSVVayTypePanelViewModel)CurrentPanelViewModelWaySelect).PanelOpened = false;
                PanelOpened = false;
            });
            SavePanelCommand = new DelegateCommand(() =>
            {
                var panel = CurrentPanelViewModel;
                if (!string.IsNullOrWhiteSpace(panel.Text1) || !string.IsNullOrWhiteSpace(panel.Text2))
                {
                    CurrentLegSide = CurrentLegSide;
                    if (IsStructEdited(CurrentPanelViewModel.LegPrt))
                    {
                        if ((LevelSelected != 0 && testOnUnique(CurrentPanelViewModel.LegPrt)) || (LevelSelected == 0 && testAdditionalStructOnUnique(CurrentPanelViewModel.LegPrt)))
                        {
                            var newStruct = GetPanelStructure();
                            newStruct.Custom = false;
                            Data.PDSVHips.Add((PDSVHipStructure)newStruct);
                            Data.Complete();
                            _lastSender.StructureSource.Add(newStruct);
                            _lastSender.SelectedValue = newStruct;
                            CurrentPanelViewModel.PanelOpened = false;
                            handled = false;
                        }
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

                          var combo = Data.PDSVCombos.FindCombo(LegSections[0].SelectedValue.Id, ids);
                          //если комбо не нашлось - значит оно кастомное, мы его запомним и отправим в базу на радость будущим пользователям
                          if (combo == null)
                          {
                              var newCombo = new PDSVHipCombo();

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
                                      //Data.PDSVHips.Add((PDSVHipStructure)currentStructure);
                                      //Data.Complete();
                                      //((PDSVHipEntry)LegSections[i].CurrentEntry).Structure = (PDSVHipStructure)currentStructure;
                                      //(LegSections[i].CurrentEntry).StructureID = currentStructure.Id;
                                      //Data.PDSVHipEntries.Add((PDSVHipEntry)LegSections[i].CurrentEntry);
                                      //Data.Complete();
                                      //if (i == 0) newCombo.IdStr1 = currentStructure.Id;
                                      ////там гда раньше был ноль теперь будет актуальный айдишник
                                      //else ids[i - 2] = currentStructure.Id;
                                  }
                              }

                              newCombo.IdStr1 = LegSections[0].SelectedValue.Id;
                              //заполняем комбо
                              Data.PDSVCombos.AddCombo(newCombo, ids);
                              Data.Complete();
                              MessageBus.Default.Call("RebuildFirstPDSV", this, LegSections[0]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[0]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[1]);
                              MessageBus.Default.Call("RebuildLegSectionViewModel", this, LegSections[2]);

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
            PDSVWayType = new ObservableCollection<PDSVHipWay>();
            foreach (var way in Data.PDSVHipWay.GetAll)
            {
                PDSVWayType.Add(way);
            }
            PDSVHipWay emptyWay = new PDSVHipWay();
            emptyWay.Name = "";
            PDSVWayType.Add(emptyWay);

            LevelCount = 3;
            _sections = new ObservableCollection<LegSectionViewModel>();
            AdditionalStructure = new PDSVAdditionalSectionViewModel(Controller, null, 0);
            for (int i = 0; i < LevelCount; i++)
            {
                if (i != 0)
                    LegSections.Add(new PDSVSectionViewModel(Controller, _sections[i - 1], i + 1));
                else
                    LegSections.Add(new PDSVSectionViewModel(Controller, null, i + 1));
            }
            _title = "Передняя добавочная сафенная вена";
        }

        public PDSVViewModel(NavigationController controller) : base(controller) { }

        public PDSVViewModel(NavigationController controller, LegSide side) : base(controller, side)
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
