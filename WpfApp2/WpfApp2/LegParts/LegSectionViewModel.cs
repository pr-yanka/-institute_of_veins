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

namespace WpfApp2.LegParts
{
    public abstract class LegSectionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private int _listNumber;
        public int ListNumber { get; set; }

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
                    if (value.Custom) MessageBus.Default.Call("OpenCustom", this, this.GetType());
                    else MessageBus.Default.Call("CloseCustom", this, this.GetType());
                }
                _selectedValue = value;
                OnPropertyChanged();
            }
        }


        private bool _hasSize;
        //has size
        public bool HasSize { get; set; }

        //has double size
        private bool _hasDoubleSize;
        public bool HasDoubleSize { get; set; }

        //has first part
        private bool _hasFirstPart;
        public bool HasFirstPart { get; set; }

        //has second part
        private bool _hasSecondPart;
        public bool HasSecondPart { get; set; }

        private string _text1;
        public string Text1 { get; set; }

        private string _text2;
        public string Text2 { get; set; }

        private float _size;
        public float Size { get; set; }

        private float _size2;

        private LegSectionViewModel _previousSection;

        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get
            {
                if (_previousSection == null) return Visibility.Visible;
                if (_previousSection.SelectedValue != null && !_previousSection.SelectedValue.ToNextPart) return Visibility.Visible;
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

        protected void AddCustomObject(Type structureType)
        {           
            var custom = (LegPartDbStructure)Activator.CreateInstance(structureType);
            custom.Text1 = "Свой вариант ответа.";
            custom.HasSize = false;
            custom.Custom = true;
            custom.ToNextPart = false;
            StructureSource.Add(custom);
        }

        protected void AddNextPartObject(Type structureType)
        {
            var next = (LegPartDbStructure)Activator.CreateInstance(structureType);
            next.Text1 = "Переход к следующему разделу.";
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
