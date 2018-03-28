using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels.Panels
{
    public class SclerozPanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public DelegateCommand<object> LostFocus1 { get; private set; }
        public DelegateCommand<object> LostFocus2 { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }
        public DelegateCommand<object> ClickOnAutoComplete { get; private set; }
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
        private string _sclezingVeshestvo;
        public string SclezingVeshestvo
        {
            get { return _sclezingVeshestvo; }
            set
            {
                _sclezingVeshestvo = value;
                OnPropertyChanged();
            }
        }
        private float _persent;
        public float Persent
        {
            get { return _persent; }
            set
            {
                _persent = value;
                OnPropertyChanged();
            }
        }
        private float _mL;
        public float ML
        {
            get { return _mL; }
            set
            {
                _mL = value;
                OnPropertyChanged();
            }
        }

        //Persent ML
        private IEnumerable<String> _svetofvodDiabetCommentList;
        public IEnumerable<String> SclezingCommentList { get { return _svetofvodDiabetCommentList; } set { _svetofvodDiabetCommentList = value; OnPropertyChanged(); } }


        public SclerozPanelViewModel(ViewModelBase parentVM) : base(parentVM.Controller)
        {
            LostFocus1 = new DelegateCommand<object>(
           (sender) =>
           {

               if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
               {
                   ((TextBox)sender).Text = "0";
                   ML = 0f;
               }


           }
       ); LostFocus2 = new DelegateCommand<object>(
          (sender) =>
          {

              if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
              {
                  ((TextBox)sender).Text = "0";
                  Persent = 0f;
              }


          }
      ); ClickOnWeight = new DelegateCommand<object>(
          (sender) =>
          {

              if (((TextBox)sender).Text == "0")
                  ((TextBox)sender).Text = "";



          }
      );
            ClickOnAutoComplete = new DelegateCommand<object>(
                 (sender) =>
                 {
                     try
                     {

                         if (sender != null)
                         {
                             var buf = (AutoCompleteBox)sender;
                             if (!buf.IsDropDownOpen)
                                 buf.IsDropDownOpen = true;
                         }
                     }
                     catch
                     {

                     }

                 }
             );
            ParentVM = parentVM;

        }

        private string _shortText;
        public string ShortText
        {
            get { return _shortText; }
            set
            {
                _shortText = value;
                OnPropertyChanged();
            }
        }

        //private string _longText;
        //public string LongText
        //{
        //    get { return _longText; }
        //    set
        //    {
        //        _longText = value;
        //        OnPropertyChanged();
        //    }
        //}

        public Sclezing GetPanelType()
        {
            var newType = new Sclezing();
            //newType.LongName = LongText;
            newType.Ml = ML;
            newType.Prcent = Persent;
            newType.Str = ShortText;
            bool xtestx = false;
            foreach (var x in SclezingCommentList)
            {
                if (x == SclezingVeshestvo)
                {
                    xtestx = true;
                    break;
                }
            }
            if (!xtestx)
            {
                if (!string.IsNullOrWhiteSpace(SclezingVeshestvo))
                {
                    var bff = new Veshestvo();
                    bff.Str = SclezingVeshestvo;
                    Data.Veshestvo.Add(bff);
                    Data.Complete();
                }
            }

            newType.Veshestvo = SclezingVeshestvo;

            return newType;
        }

        internal void ClearPanel()
        {
            //LongText = "";
            ShortText = "";
            ML = 0f;
            Persent = 0f;
            SclezingVeshestvo = "";


            List<String> buff3 = new List<string>();
            foreach (var x in Data.Veshestvo.GetAll)
                buff3.Add(x.Str);
            SclezingCommentList = buff3;

        }
    }
}
