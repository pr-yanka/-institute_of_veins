using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;
using WpfApp2.Messaging;
using WpfApp2.Db.Models.LegParts;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Controls;

namespace WpfApp2.LegParts
{
    public abstract class LegSectionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private int _listNumber;
        public int ListNumber { get; set; }
        private LegPartEntry _currentEntry;
        public LegPartEntry CurrentEntry
        {
            get { return _currentEntry; }
            set
            {
                _currentEntry = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<LegPartDbStructure> _structureSource;

        public ObservableCollection<LegPartDbStructure> StructureSource
        {
            get { return _structureSource; }
            set
            {
                _structureSource = value;
                OnPropertyChanged();
            }
        }
        //all values

        //selected value

        private bool _isButtonsEnabled;

        public bool IsButtonsEnabled { get { return _isButtonsEnabled; } set { _isButtonsEnabled = value; OnPropertyChanged(); } }

        private LegPartDbStructure _selectedValue;

        private int? _selectedIndex;

        public int? SelectedIndex { get { return _selectedIndex; } set { _selectedIndex = value; OnPropertyChanged(); } }

        public LegPartDbStructure SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (value != null && value.Text2 == "" && value.Text1 == "")
                {
                    _selectedValue = value; OnPropertyChanged();

                    IsButtonsEnabled = false;

                    MessageBus.Default.Call("RebuildLegSectionViewModel", "Empty", this);
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

                        //foreach(var x in StructureSource)
                        //{
                        //    x.IsButtonsVisible = Visibility.Visible;
                        //}
                        //_selectedValue.IsButtonsVisible = Visibility.Collapsed;

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
                        MessageBus.Default.Call("RebuildLegSectionViewModel", this, this);

                        OnPropertyChanged();



                    }
                }
                else { _selectedValue = null; OnPropertyChanged(); }

                OnPropertyChanged();
            }
        }


        private bool _hasSize;
        //has size
        public bool HasSize
        {
            get
            {
                return _hasSize;
            }
            set
            {
                _hasSize = value;
                OnPropertyChanged();
            }
        }

        //has double size
        private bool _hasDoubleSize;
        public bool HasDoubleSize
        {
            get
            {
                return _hasDoubleSize;
            }
            set
            {
                _hasDoubleSize = value;
                OnPropertyChanged();
            }
        }

        //has first part
        private bool _hasFirstPart;
        public bool HasFirstPart
        {
            get
            {
                return _hasFirstPart;
            }
            set
            {
                _hasFirstPart = value;
                OnPropertyChanged();
            }
        }

        //has second part
        private bool _hasSecondPart;
        public bool HasSecondPart
        {
            get
            {
                return _hasSecondPart;
            }
            set
            {
                _hasSecondPart = value;
                OnPropertyChanged();
            }
        }

        private bool _hasComment;
        public bool HasComment
        {
            get
            {
                return _hasComment;
            }
            set
            {
                _hasComment = value;
                OnPropertyChanged();
            }
        }


        private string _text1;
        public string Text1 { get; set; }

        private string _text2;
        public string Text2 { get; set; }

        private float _size;
        public float Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }

        public string Comment { get; set; }

        private float _size2;

        private LegSectionViewModel _previousSection;

        public LegSectionViewModel PreviousSection
        {
            get
            {
                return _previousSection;
            }
            set
            {
                _previousSection = value;
                OnPropertyChanged();
            }
        }

        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get
            {
                if (_previousSection == null) return Visibility.Visible;
                if (_previousSection.SelectedValue != null && !_previousSection.SelectedValue.ToNextPart) return Visibility.Visible;
                //SelectedValue = null;
                return Visibility.Hidden;
            }
            set
            {
                _isVisible = value;
                // int indexOfSelectedValue = SelectedValue.Id;

                OnPropertyChanged();
            }
        }

        public LegSectionViewModel(NavigationController controller, LegSectionViewModel prevSection) : base(controller)
        {
            IsButtonsEnabled = false;
            //         ClickOnBorder = new DelegateCommand<object>(
            //    (sender) =>
            //    {
            //        ComboBox x = sender as ComboBox;
            //        x.MouseDoubleClick.I
            //        x.IsDropDownOpen = true;



            //    }
            //);

            ToRedactStruct = new DelegateCommand(() =>
            {

                // x.SelectedValue 
                // LegSectionViewModel section = x.SelectedValue as LegSectionViewModel;
                MessageBus.Default.Call("OpenStructRedact", SelectedValue, null);


            }
   );


            LostFocus = new DelegateCommand<object>(
       (sender) =>
       {

           if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
               ((TextBox)sender).Text = "0";



       }
   ); ClickOnWeight = new DelegateCommand<object>(
      (sender) =>
      {

          if (((TextBox)sender).Text == "0")
              ((TextBox)sender).Text = "";



      }
  );
            _previousSection = prevSection;
            if (prevSection != null)
                prevSection.PropertyChanged += (e, args) =>
                {
                    if (prevSection.SelectedValue != null) IsVisible = Visibility.Visible;
                    else IsVisible = Visibility.Hidden; ;
                };
            StructureSource = new ObservableCollection<LegPartDbStructure>();
            var t = StructureSource.GetEnumerator().GetType().GetGenericTypeDefinition();
        }

        public void DeleteCustom()
        {
            StructureSource.Remove(_customChoice);
        }

        private LegPartDbStructure _customChoice;
        private string _startCustomText = "Свой вариант ответа";

        protected void AddCustomObject(Type structureType)
        {
            _customChoice = (LegPartDbStructure)Activator.CreateInstance(structureType);
            _customChoice.Text1 = _startCustomText;
            _customChoice.HasSize = false;
            _customChoice.Custom = true;
            _customChoice.ToNextPart = false;
            StructureSource.Add(_customChoice);
        }

        protected void AddEmpty(Type structureType)
        {
            var _Empty = (LegPartDbStructure)Activator.CreateInstance(structureType);
            _Empty.Text1 = "";
            _Empty.Text2 = "";
            _Empty.HasSize = false;
            _Empty.Custom = false;
            _Empty.ToNextPart = false;
            StructureSource.Add(_Empty);
        }

        protected void AddNextPartObject(Type structureType)
        {
            var next = (LegPartDbStructure)Activator.CreateInstance(structureType);
            next.Text1 = "Переход к следующему разделу";
            next.HasSize = false;
            next.Custom = false;
            next.ToNextPart = true;
            StructureSource.Add(next);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float Size2 { get; set; }

        public string SizeToText
        {
            get
            {
                if (!HasSize && !HasDoubleSize)
                {
                    return "";
                }
                else if (HasSize) return Size.ToString();
                else return Size.ToString() + "*" + Size2.ToString();
            }
        }

   
        public DelegateCommand<object> LostFocus { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }
      
        public DelegateCommand ToRedactStruct { get; private set; }
    }
}
