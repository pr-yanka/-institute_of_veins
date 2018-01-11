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

namespace WpfApp2.LegParts
{
    public abstract class LegSectionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private int _listNumber;
        public int ListNumber { get; set; }
        private LegPartEntry _currentEntry;
        public LegPartEntry CurrentEntry {
            get { return _currentEntry; }
            set
            {
                _currentEntry = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<LegPartDbStructure> StructureSource { get; protected set; }
        //all values

        //selected value
        private LegPartDbStructure _selectedValue;

        public LegPartDbStructure SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if ((_selectedValue == null && value.Custom) || (_selectedValue != null &&_selectedValue.Custom != value.Custom))
                {
                    if (value.Custom && value.Text1 == _startCustomText) MessageBus.Default.Call("OpenCustom", this, this.GetType());
                    else MessageBus.Default.Call("CloseCustom", this, this.GetType());
                }
                _selectedValue = value;
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
                if (_selectedValue.Text2 != "") HasSecondPart = true;
                if (_selectedValue.HasSize) HasSize = true;
                if (_selectedValue.HasDoubleMetric) HasDoubleSize = true;

                HasComment = true;
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
        public bool HasDoubleSize {
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
        public bool HasSecondPart {
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
        public float Size { get; set; }

        public string Comment { get; set; }

        private float _size2;

        private LegSectionViewModel _previousSection;

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
            set {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public LegSectionViewModel(NavigationController controller, LegSectionViewModel prevSection) : base(controller)
        {
            _previousSection = prevSection;
            if (prevSection != null)
                prevSection.PropertyChanged += (e, args) =>
                {
                    if (prevSection.SelectedValue != null) IsVisible = Visibility.Visible;
                    else IsVisible = Visibility.Hidden;;
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

        public string SizeToText {
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

        
    }
}
