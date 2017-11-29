﻿using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp2.LegParts.DialogConfirmStructure;
using WpfApp2.LegParts.VMs;
using WpfApp2.Navigation;
using WpfApp2.ViewModels;

namespace WpfApp2.LegParts
{
    public class LegPartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private bool _isEmpty = true;
        public bool IsEmpty {
            get
            {
                return _isEmpty;
            }
            protected set {
                _isEmpty = value;
                OnPropertyChanged("IsEmpty");
            }
        }

        public string ButtonText
        {
            get
            {
                if (!IsEmpty) return "Редактировать";
                else return "Заполнить";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool _panelOpened = false;

        public bool PanelOpened
        {
            get { return _panelOpened; }
            set
            {
                _panelOpened = value;
                OnPropertyChanged("PanelOpened");
            }
        }

        protected string _title;
        public string Title
        {
            get { return _title; }
            set { this._title = value; }
        }

        private int _levelCount = 1;
        public int LevelCount
        {
            get { return _levelCount; }
            set { this._levelCount = value; }
        }

        public List<string> Source { get; } = new List<string>();
        
        public virtual List<LegSectionViewModel> LegSections { get; set; }

        public DelegateCommand RevertCommand { set; get; }
        public DelegateCommand SaveCommand { set; get; }

        private ICommand openDialogCommand = null;
        public ICommand OpenDialogCommand
        {
            get { return this.openDialogCommand; }
            set { this.openDialogCommand = value; }
        }

        public ICommand OpenPanelCommand { set; private get; }
        public ICommand ClosePanelCommand { set; private get; }

        public SizePanelViewModel CurrentPanelViewModel;

        private UserControl _panel;
        public UserControl Panel
        {
            set { _panel = value; }
        }

        public DelegateCommand AnimationCompleted {get; set; }

        public LegPartViewModel(NavigationController controller) : base(controller)
        {
            OpenPanelCommand = new DelegateCommand(() => { PanelOpened = true; });
            ClosePanelCommand = new DelegateCommand(() => { PanelOpened = false; });
            PanelOpened = false;

            //_sections = new List<BPVHipSectionViewModel>();
            _hasNavigation = false;
            Controller = controller;

            RevertCommand = new DelegateCommand(
                () =>
                {
                    IsEmpty = false;
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            SaveCommand = new DelegateCommand(
                () =>
                {
                    IsEmpty = false;
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            CurrentPanelViewModel = new SizePanelViewModel(this.Controller);
        }

        private void FinishAdding(object parameter)
        {
            var vm = new DialogConfirmStructureViewModel();
            var result = DialogService.DialogService.OpenDialog(vm, parameter as Window);
        }
}
}
