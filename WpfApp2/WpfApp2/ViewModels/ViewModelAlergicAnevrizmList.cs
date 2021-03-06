﻿using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.ViewModels
{
    public class AlergicAnevrizmListDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public AlergicAnevrizm Data { get; set; }
        public DelegateCommand DeleteCommand { set; get; }
        public bool IsVisibleTotal { get; set; }
        private bool? _isChecked;
        public bool? IsChecked
        {
            get
            {
                if (_isChecked == null)
                    return false;
                else return _isChecked;
            }
            set
            {
                _isChecked = value;

                OnPropertyChanged();
            }
        }
        public AlergicAnevrizmListDataSource(AlergicAnevrizm Recomendations)
        {
            IsVisibleTotal = true;
            this.Data = Recomendations;
            IsChecked = false;
        }
    }
    public class ViewModelAlergicAnevrizmList : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region everyth connected with panel


        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public ICommand OpenCommand { protected set; get; }

        public AlergicAnevrizmPanelViewModel CurrentPanelViewModel { get; protected set; }


        public static bool Handled = false;
        public UIElement UI;



        private void OpenHandler(object sender, object data)
        {
            if (!Handled)
            {
                Handled = true;
                CurrentPanelViewModel.PanelOpened = true;
            }
        }

        #endregion
        private int lastLength = 0;
        private Visibility _visOfNothingFaund;
        public Visibility VisOfNothingFaund
        {
            get { return _visOfNothingFaund; }
            set
            { _visOfNothingFaund = value; OnPropertyChanged(); }
        }
        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value; OnPropertyChanged();
                for (int i = 0; i < DataSourceList.Count; ++i)
                {
                    foreach (var x in FullCopy)
                        if (DataSourceList[i].IsChecked != null && DataSourceList[i].IsChecked == true && x.Data.Id == DataSourceList[i].Data.Id)
                        {
                            x.IsChecked = true;
                        }
                        else if (x.Data.Id == DataSourceList[i].Data.Id)
                        {
                            x.IsChecked = false;
                        }
                }
                if (lastLength >= value.Length)
                {
                    //foreach(ChangeHistoryClass x in FullCopy)
                    //{
                    //    ChangeHistoryClass buf = new ChangeHistoryClass(x.Ch);
                    //    Changes.Add(buf);
                    //}

                    DataSourceList = new ObservableCollection<AlergicAnevrizmListDataSource>(FullCopy);
                }
                lastLength = value.Length;
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    for (int i = 0; i < DataSourceList.Count; ++i)
                    {



                        if (DataSourceList[i].Data.Str.ToLower().Contains(FilterText.ToLower()))
                        {

                            DataSourceList[i].IsVisibleTotal = true;

                        }
                        else
                        {

                            DataSourceList[i].IsVisibleTotal = false;
                        }




                    }



                    for (int i = 0; i < DataSourceList.Count; ++i)
                    {
                        if (DataSourceList[i].IsVisibleTotal == false)
                        {
                            DataSourceList.Remove(DataSourceList[i]);
                            --i;
                        }
                    }
                    if (DataSourceList.Count == 0)
                    {
                        VisOfNothingFaund = Visibility.Visible;
                    }
                    else
                    {
                        VisOfNothingFaund = Visibility.Collapsed;
                    }

                    // 
                }
                else
                {

                    VisOfNothingFaund = Visibility.Collapsed;
                    foreach (var x in DataSourceList)
                    {
                        x.IsVisibleTotal = true;


                    }

                    // SetChangesInDB(null, null);
                }

                Controller.NavigateTo<ViewModelAlergicAnevrizmList>();



            }
        }


        List<AlergicAnevrizmListDataSource> FullCopy;

        private void SetClear(object sender, object data)
        {
            DataSourceList = new ObservableCollection<AlergicAnevrizmListDataSource>();
            FullCopy = new List<AlergicAnevrizmListDataSource>();
            bool test = true;
            foreach (var HirurgInterupType in Data.AlergicAnevrizm.GetAll)
            {
                foreach (var x in DataSourceList)
                {
                    if (x.Data.Str == HirurgInterupType.Str)
                    {
                        test = false;
                    }
                }
                if (test)
                {
                    DataSourceList.Add(new AlergicAnevrizmListDataSource(HirurgInterupType));
                    FullCopy.Add(new AlergicAnevrizmListDataSource(HirurgInterupType));
                }
            }
        }


        private void SetDRecomendationListBecauseOFEdit(object sender, object data)
        {
            SetClear(null, null);
            foreach (var dat in (List<AlergicAnevrizmListDataSource>)data)
            {

                foreach (var datC in DataSourceList)
                {
                    if (dat.Data != null && dat.Data.Id == datC.Data.Id)
                    {

                        datC.IsChecked = true;
                    }

                }

            }

        }
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string TextOFNewType { get; set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public ObservableCollection<AlergicAnevrizmListDataSource> _dataSourceList;
        public ObservableCollection<AlergicAnevrizmListDataSource> DataSourceList { get { return _dataSourceList; } set { _dataSourceList = value; OnPropertyChanged(); } }

        public ViewModelAlergicAnevrizmList(NavigationController controller) : base(controller)
        {
            VisOfNothingFaund = Visibility.Collapsed;
            MessageBus.Default.Subscribe("SetClearAlergicAnevrizmList", SetClear);
            MessageBus.Default.Subscribe("SetAlergicAnevrizmListBecauseOFEdit", SetDRecomendationListBecauseOFEdit);
            TextOFNewType = "Новый анамнез";
            HeaderText = "Аллергологический анамнез";
            AddButtonText = "Другой аллергологический анамнез";

            DataSourceList = new ObservableCollection<AlergicAnevrizmListDataSource>();
            foreach (var RecomendationsType in Data.AlergicAnevrizm.GetAll)
            {
                DataSourceList.Add(new AlergicAnevrizmListDataSource(RecomendationsType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    FilterText = "";
                    ObservableCollection<AlergicAnevrizmListDataSource> DataSourceListBuffer = new ObservableCollection<AlergicAnevrizmListDataSource>();
                    foreach (var Data in FullCopy)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    MessageBus.Default.Call("SetAlergicAnevrizmListList", this, DataSourceListBuffer);
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );



            CurrentPanelViewModel = new AlergicAnevrizmPanelViewModel(this);
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {
                FilterText = "";
                var newType = CurrentPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.AlergicAnevrizm.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = DataSourceList;
                    DataSourceList = new ObservableCollection<AlergicAnevrizmListDataSource>();
                    FullCopy = new List<AlergicAnevrizmListDataSource>();
                    bool test = true;
                    foreach (var HirurgInterupType in Data.AlergicAnevrizm.GetAll)
                    {
                        foreach (var x in DataSourceList)
                        {
                            if (x.Data.Str == HirurgInterupType.Str)
                            {
                                test = false;
                            }
                        }
                        if (test)
                        {
                            DataSourceList.Add(new AlergicAnevrizmListDataSource(HirurgInterupType));
                            FullCopy.Add(new AlergicAnevrizmListDataSource(HirurgInterupType));
                        }
                    }

                    foreach (var DiagnosisType in DataSourceListbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            DataSourceList.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelAlergicAnevrizmList>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });
        }

    }
}
