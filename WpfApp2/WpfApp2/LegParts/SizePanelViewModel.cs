using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.Db.Models;
using WpfApp2.LegParts.VMs;
using WpfApp2.Navigation;

namespace WpfApp2.LegParts
{
    public class SizePanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public DelegateCommand<object> ClickOnAutoComplete { get; set; }
        public bool DoubleSizeAvailable;
        private LegPartDbStructure _legPrt;
        public LegPartDbStructure LegPrt
        {
            get { return _legPrt; }
            set
            {

                _legPrt = value;

                OnPropertyChanged();
            }
        }
        private ViewModelBase _parentVM;

        private string _textSaveBTN;
        private string _textCancleOrResetBTN;
        public string TextSaveBTN
        {
            get { return _textSaveBTN; }
            set { _textSaveBTN = value; OnPropertyChanged(); }
        }
        public string TextCancleOrResetBTN
        {
            get { return _textCancleOrResetBTN; }
            set { _textCancleOrResetBTN = value; OnPropertyChanged(); }
        }

        public string mode;

        private bool _panelOpened = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch
            {
            }
        }

        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                Dimentions = new ObservableCollection<Metrics>(Data.Metrics.GetAll);
                _panelOpened = value;
                if (value) ClearPanel();
                OnPropertyChanged();
            }
        }

        public void ClearPanel()
        {
            Text1 = "";
            Text2 = "";
            HasSize = false;
        }
        private bool TrueTestDoubleSize;
        public SizePanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
          //  SelectedMetricText = "";

            ClickOnAutoComplete = new DelegateCommand<object>(
             (sender) =>
             {
                 try
                 {
                     if (sender != null)
                     {
                         //Dimentions = new ObservableCollection<Metrics>(Data.Metrics.GetAll);
                         AutoCompleteBox buf = (AutoCompleteBox)sender;
                         if (!buf.IsDropDownOpen)
                             buf.IsDropDownOpen = true;
                     }
                 }
                 catch(Exception ex)
                 {
                   
                 }
             }
         );
            _parentVM = parentVM;
            Dimentions = new ObservableCollection<Metrics>(Data.Metrics.GetAll);
            //потому что я программист от бога
            if (parentVM.GetType() == typeof(SFSViewModel) || parentVM.GetType() == typeof(SPSViewModel))
            {
                DoubleSizeIsAvailable = true;
                TrueTestDoubleSize = true;
                DoubleSizeAvailable = false;
            }
            else
            {
                DoubleSizeIsAvailable = false;
                TrueTestDoubleSize = false;
            }
        }

        private string _text1;
        public string Text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                if (mode == "Edit")
                    TextSaveBTN = "Сохранить";
                OnPropertyChanged();
            }
        }

        private string _text2;
        public string Text2
        {
            get { return _text2; }
            set
            {
                _text2 = value;
                if (mode == "Edit")
                    TextSaveBTN = "Сохранить";
                OnPropertyChanged();
            }
        }

        private bool _hasSize;
        public bool HasSize
        {
            get
            {
                return _hasSize;
            }
            set
            {
                _hasSize = value;
                if (mode == "Edit")
                    TextSaveBTN = "Сохранить";
                if (value && TrueTestDoubleSize == true)
                    DoubleSizeIsAvailable = true;
                else
                { DoubleSizeIsAvailable = false; HasDoubleSize = false; }
                OnPropertyChanged();
            }
        }

        private bool _hasDoubleSize;
        public bool HasDoubleSize
        {
            get { return _hasDoubleSize; }
            set
            {
                _hasDoubleSize = value;
                if (mode == "Edit")
                    TextSaveBTN = "Сохранить";
                OnPropertyChanged();
            }
        }

        private bool _doubleSizeAvailable;
        public bool DoubleSizeIsAvailable
        {
            get { return _doubleSizeAvailable; }
            set
            {
                _doubleSizeAvailable = value;
                OnPropertyChanged();
            }
        }

        private Metrics _selectedMetric;
        public Metrics SelectedMetric
        {
            get
            {
                return _selectedMetric;
            }
            set
            {
                _selectedMetric = value;

                if (mode == "Edit")
                    TextSaveBTN = "Сохранить";
                OnPropertyChanged();
            }
        }


        private string _selectedMetricText;
        public string SelectedMetricText
        {
            get
            {
                return _selectedMetricText;
            }
            set
            {
                _selectedMetricText = value;
                if (mode == "Edit")
                    TextSaveBTN = "Сохранить";
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Metrics> _dimentions;

        public ObservableCollection<Metrics> Dimentions
        {
            get
            {
                return _dimentions;
            }
            set
            {
                _dimentions = value;
                OnPropertyChanged();
            }
        }


    }
}
