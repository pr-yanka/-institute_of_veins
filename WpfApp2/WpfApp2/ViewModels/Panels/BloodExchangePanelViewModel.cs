using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class BloodExchangePanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ViewModelBase ParentVM { get; protected set; }

        private bool _panelOpened = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged();
            }
        }



        public BloodExchangePanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            ParentVM = parentVM;

        }

        private float _shortText;
        public float ShortText
        {
            get { return _shortText; }
            set
            {
                _shortText = value;
                OnPropertyChanged();
            }
        }


        private DateTime _shortTime;
        public DateTime ShortTime
        {
            get { return _shortTime; }
            set
            {
                _shortTime = value;
                OnPropertyChanged();
            }
        }

        private string _longText;
        public string LongText
        {
            get { return _longText; }
            set
            {
                _longText = value;
                OnPropertyChanged();
            }
        }

        public BloodExchangeListDataSource GetPanelType()
        {
            var newObj = new BloodExchange();
            newObj.Volume = ShortText;
            newObj.Date = ShortTime;
            Data.BloodExchange.Add(newObj);
            Data.Complete();

            var newType = new BloodExchangeListDataSource(newObj, new DelegateCommand(() => { }));
            //newType.LongName = LongText;
            newType.Commentary = LongText;

            return newType;
        }

        internal void ClearPanel()
        {
            ShortTime = DateTime.Now;
            //LongText = "";
            ShortText = 0;
        }
    }
}
