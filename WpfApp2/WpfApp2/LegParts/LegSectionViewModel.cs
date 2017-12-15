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
                if (_previousSection.SelectedValue != null) return Visibility.Visible;
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
