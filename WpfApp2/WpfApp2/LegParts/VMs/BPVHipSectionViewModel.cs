using System.Collections.ObjectModel;
using System.Linq;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts.VMs
{
    public class BPVHipSectionViewModel : LegSectionViewModel
    {
        public BPVHipSectionViewModel(NavigationController controller, LegSectionViewModel prevSection, int number) : base(controller, prevSection)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.BPVHips.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(BPVHipStructure));
            AddNextPartObject(typeof(BPVHipStructure));
            AddEmpty(typeof(BPVHipStructure));
            CurrentEntry = new BPVHipEntry();
        }

    }



    public class BPVHipAdditionalSectionViewModel : LegSectionViewModel
    {
        private string _startCustomText = "Свой вариант ответа";
        private LegPartDbStructure _selectedValue;
        public override LegPartDbStructure SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (value != null && value.Text2 == "" && value.Text1 == "")
                {
                    _selectedValue = value; OnPropertyChanged();

                    IsButtonsEnabled = false;

             
                }
                else if (value != null)
                {

                    if ((_selectedValue == null && value.Custom) || (_selectedValue != null && _selectedValue.Custom != value.Custom))
                    {
                        if (value.Custom && value.Text1 == _startCustomText)
                        {
                            IsButtonsEnabled = false;
                            MessageBus.Default.Call("OpenCustom", this, this.GetType());
                        }
                        else MessageBus.Default.Call("CloseCustom", this, this.GetType());
                    }
                    else
                    {

                        IsButtonsEnabled = true;

                        _selectedValue = value;

                        SelectedIndex = StructureSource.IndexOf(StructureSource.Where(s => s.Id == _selectedValue.Id).ToList()[0]);

                     

                        if (_selectedValue == null)
                        {
                            HasFirstPart = false;
                            HasSecondPart = false;
                            HasComment = false;
                            HasSize = false;
                            HasDoubleSize = false;

                            OnPropertyChanged();
                            return;
                        }

                        if (_selectedValue.Text1 != "") HasFirstPart = true;
                        else { HasFirstPart = false; }
                        if (_selectedValue.Text2 != "") HasSecondPart = true;
                        else { HasSecondPart = false; }
                        if (_selectedValue.HasSize) HasSize = true;
                        else { HasSize = false; }
                        if (_selectedValue.HasDoubleMetric) HasDoubleSize = true;
                        else { HasDoubleSize = false; }
                        if (_selectedValue.ToNextPart)
                        {
                            HasComment = false;
                            IsButtonsEnabled = false;
                        }
                        else
                            HasComment = true;
                        //MessageBus.Default.Call("RebuildLegSectionViewModel", this, this);

                        OnPropertyChanged();



                    }
                }
                else { _selectedValue = null; OnPropertyChanged(); }

                OnPropertyChanged();
            }
        }
        public BPVHipAdditionalSectionViewModel(NavigationController controller, LegSectionViewModel prevSection, int number) : base(controller, prevSection)
        {
            ListNumber = number;
            StructureSource = new ObservableCollection<LegPartDbStructure>(base.Data.BPVHips.LevelStructures(number).ToList());
            foreach (var structure in StructureSource)
            {
                structure.Metrics = Data.Metrics.GetStr(structure.Size);
            }

            AddCustomObject(typeof(BPVHipStructure));
            
            AddEmpty(typeof(BPVHipStructure));
            CurrentEntry = new BPVHipEntry();
        }

    }
    //public class BPVHipAdditionalSectionViewModel
    //{

    //    private BPVHipAdditionalStructure selectedValue;
    //    public BPVHipAdditionalStructure SelectedValue
    //    {
    //        get { return selectedValue; }
    //        set { selectedValue = value; }
    //    }

    //    private int selectedIndex;
    //    public int SelectedIndex
    //    {
    //        get { return selectedIndex; }
    //        set { selectedIndex = value; }
    //    }

    //    private ObservableCollection<BPVHipAdditionalStructure> structureSource;
    //    public ObservableCollection<BPVHipAdditionalStructure> StructureSource
    //    {
    //        get { return structureSource; }
    //        set { structureSource = value; }
    //    }

    //    public BPVHipAdditionalSectionViewModel()
    //    {
    //        using (MySqlContext context = new MySqlContext())
    //        {
    //            MetricsRepository Metrics = new MetricsRepository(context);

    //            BPVHipAdditionalStructureRepository bpvhipaddstruct = new BPVHipAdditionalStructureRepository(context);
    //            //ListNumber = number;
    //            StructureSource = new ObservableCollection<BPVHipAdditionalStructure>(bpvhipaddstruct.GetAll);
    //            foreach (var structure in StructureSource)
    //            {
    //                structure.Metrics = Metrics.GetStr(structure.Size);
    //            }

    //            //AddCustomObject(typeof(BPVHipStructure));
    //            //AddNextPartObject(typeof(BPVHipStructure));
    //            //AddEmpty(typeof(BPVHipStructure));
    //            //CurrentEntry = new BPVHipEntry();
    //        }
    //    }

    //}




}
