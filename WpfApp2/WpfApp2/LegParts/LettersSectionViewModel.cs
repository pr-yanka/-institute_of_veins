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
using WpfApp2.LegParts.VMs;

namespace WpfApp2.LegParts
{
    public class LettersSectionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public bool HasDoubleSize { get; set; }
        public bool HasComment { get; set; }
        public string ListNumber { get; set; }
        private int? _selectedIndex;

        public int? SelectedIndex { get { return _selectedIndex; } set { _selectedIndex = value; OnPropertyChanged(); } }
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

        private bool _isButtonsEnabled;

        public bool IsButtonsEnabled { get { return _isButtonsEnabled; } set { _isButtonsEnabled = value; OnPropertyChanged(); } }

        private ObservableCollection<Letters> _structureSource;

        public ObservableCollection<Letters> StructureSource
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
        private Letters _selectedValue;



        public Letters SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                if (value == null)
                {
                    _selectedValue = null;
                }
                else if (value.Id == 0 && value.Leter == "" && value.Text1 == "")
                    _selectedValue = null;
                else
                {
                    _selectedValue = value;
                    SelectedIndex = StructureSource.IndexOf(StructureSource.Where(s => s.Id == _selectedValue.Id).ToList()[0]);

                }
                OnPropertyChanged();
            }


        }









        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                // int indexOfSelectedValue = SelectedValue.Id;

                OnPropertyChanged();
            }
        }

        public LettersSectionViewModel(NavigationController controller, LettersSectionViewModel prevSection) : base(controller)
        {
            IsButtonsEnabled = false;
            HasComment = false;
            HasDoubleSize = false;
            StructureSource = new ObservableCollection<Letters>();
            var t = StructureSource.GetEnumerator().GetType().GetGenericTypeDefinition();
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }






    }
}
