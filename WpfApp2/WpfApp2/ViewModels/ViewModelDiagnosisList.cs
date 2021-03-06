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
    public class DiagnosisDataSource : INotifyPropertyChanged
    {
        public bool IsVisibleTotal { get; set; }
        public bool IsFilteredPt { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool? _isChecked;
        public bool? IsChecked
        {
            get
            {
                if (_isChecked == null)
                    return false;
                else return _isChecked;
            }
            set { _isChecked = value;
                if (value == true)
                {
                    MessageBus.Default.Call("OneWayDiagnosisListObsledovanie", this, "true");
                }
                else
                {
                    MessageBus.Default.Call("OneWayDiagnosisListObsledovanie", this, "false");
                }
                OnPropertyChanged(); }
        }
        public DiagnosisType Data { get; set; }

        public DiagnosisDataSource(DiagnosisType Diagnosis)
        {
            IsVisibleTotal = true;
            IsFilteredPt = false;
            this.Data = Diagnosis;
            IsChecked = false;
        }
    }

    public class ViewModelDiagnosisList : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        List<int> Sequence;
        private void IsItChecked(object dataElement, object isSelected)
        {
            string isS = isSelected.ToString();
            DiagnosisDataSource data = dataElement as DiagnosisDataSource;
            bool test = true;
            if (isS == "true")
            {
                foreach (var item in Sequence)
                {
                    if (item == data.Data.Id)
                    {
                        test = false;
                    }
                }
                if (test)
                    Sequence.Add(data.Data.Id);
            }
            else
            {
                Sequence.Remove(data.Data.Id);
            }
        }
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

                    DataSourceList = new ObservableCollection<DiagnosisDataSource>(FullCopy);
                }
                lastLength = value.Length;
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    for (int i = 0; i < DataSourceList.Count; ++i)
                    {



                        if (DataSourceList[i].Data.Str.ToLower().Contains(FilterText.ToLower()))
                        {
                            DataSourceList[i].IsFilteredPt = true;
                            DataSourceList[i].IsVisibleTotal = true;
                            //Controller.NavigateTo<ViewModelOperationForAmbullatorCardList>();
                        }
                        else
                        {
                            DataSourceList[i].IsFilteredPt = false;
                            DataSourceList[i].IsVisibleTotal = false;
                            //Controller.NavigateTo<ViewModelOperationForAmbullatorCardList>();
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
                        x.IsFilteredPt = false;

                    }

                    // SetChangesInDB(null, null);
                }

                Controller.NavigateTo<ViewModelDiagnosisList>();



            }
        }


        List<DiagnosisDataSource> FullCopy;


        #region everyth connected with panel


        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public ICommand OpenCommand { protected set; get; }

        public DiagTypePanelViewModel CurrentPanelViewModel { get; protected set; }


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

        public string TextOFNewType { get; private set; }

        #endregion
        public string TextName { get; set; }
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public ObservableCollection<DiagnosisDataSource> _dataSourceList;
        public ObservableCollection<DiagnosisDataSource> DataSourceList { get { return _dataSourceList; } set { _dataSourceList = value; OnPropertyChanged(); } }

        private string ld;
        private void SetDiagnosisListBecauseOFEdit(object sender, object data)
        {

            FilterText = "";
            foreach (var dg in (ObservableCollection<DiagnosisDataSource>)sender)
            {
                foreach (var datC in LeftDiag)
                {
                    if (dg.Data != null && dg.Data.Id == datC.Data.Id)
                    {
                        datC.IsChecked = true;
                    }
                }

            }
            foreach (var dg in (ObservableCollection<DiagnosisDataSource>)data)
            {
                foreach (var datC in RightDiag)
                {
                    if (dg.Data != null && dg.Data.Id == datC.Data.Id)
                    {
                        datC.IsChecked = true;
                    }
                }

            }
            FilterText = "";
        }
        private void SetDiagnosisList(object sender, object data)
        {
            ld = (string)data;
            if (ld == "Left")
            {
                DataSourceList = new ObservableCollection<DiagnosisDataSource>(LeftDiag);
                FullCopy = LeftDiag;
            }
            else
            {
                DataSourceList = new ObservableCollection<DiagnosisDataSource>(RightDiag);
                FullCopy = RightDiag;
            }
        }
        //Жалобы/диагноз/заключение
        public List<DiagnosisDataSource> _leftDiag;
        public List<DiagnosisDataSource> _rightDiag;
        public List<DiagnosisDataSource> LeftDiag { get { return _leftDiag; } set { _leftDiag = value; OnPropertyChanged(); } }
        public List<DiagnosisDataSource> RightDiag { get { return _rightDiag; } set { _rightDiag = value; OnPropertyChanged(); } }

        private void SetClear(object sender, object data)
        {
            DataSourceList = new ObservableCollection<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();
            FullCopy = new List<DiagnosisDataSource>();
            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                FullCopy.Add(new DiagnosisDataSource(DiagnosisType));
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
            }
        }
        public ViewModelDiagnosisList(NavigationController controller) : base(controller)
        {
            Sequence = new List<int>();
            VisOfNothingFaund = Visibility.Collapsed;
            TextOFNewType = "Новый тип диагноза";
            TextName = "Вернуться к обследованию";
            HeaderText = "Диагнозы";
            AddButtonText = "Другой диагноз";
            DataSourceList = new ObservableCollection<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();
            MessageBus.Default.Subscribe("OneWayDiagnosisListObsledovanie", IsItChecked);
            MessageBus.Default.Subscribe("SetClearDiagnosisListLeftRightObsled", SetClear);
            MessageBus.Default.Subscribe("SetDiagnosisListBecauseOFEdit", SetDiagnosisListBecauseOFEdit);
            MessageBus.Default.Subscribe("SetleftOrRightForObsled", SetDiagnosisList);
            FullCopy = new List<DiagnosisDataSource>();
            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                FullCopy.Add(new DiagnosisDataSource(DiagnosisType));
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    List<DiagnosisDataSource> DataSourceListBuffer = new List<DiagnosisDataSource>();
                    FilterText = "";
                    foreach (var ids in Sequence)
                    {
                        foreach (var Data in FullCopy)
                        {
                            if (Data.IsChecked == true && Data.Data.Id == ids)
                            {
                                DataSourceListBuffer.Add(Data);
                            }
                        }
                    }
                    if (ld == "Left")
                    {
                        MessageBus.Default.Call("SetLeftDiagnosisListForObsled", this, DataSourceListBuffer);
                        LeftDiag = new List<DiagnosisDataSource>(DataSourceList);
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForObsled", this, DataSourceListBuffer);
                        RightDiag = new List<DiagnosisDataSource>(DataSourceList);
                    }
                    // MessageBus.Default.Call("SetDiagnosisList", this, DataSourceListBuffer);
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );


            CurrentPanelViewModel = new DiagTypePanelViewModel(this);
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

                    Data.DiagnosisTypes.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = DataSourceList;
                    var LeftDiagbuf = LeftDiag;
                    var RightDiagbuf = RightDiag;
                    DataSourceList = new ObservableCollection<DiagnosisDataSource>();
                    LeftDiag = new List<DiagnosisDataSource>();
                    RightDiag = new List<DiagnosisDataSource>();
                    FullCopy = new List<DiagnosisDataSource>();
                    foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
                    {
                        FullCopy.Add(new DiagnosisDataSource(DiagnosisType));
                        DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                        LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                        RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
                    }
                    foreach (var DiagnosisType in DataSourceListbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            DataSourceList.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                            FullCopy.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }
                    foreach (var DiagnosisType in LeftDiagbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            LeftDiag.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }
                    foreach (var DiagnosisType in RightDiagbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            RightDiag.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }
                    Controller.NavigateTo<ViewModelDiagnosisList>();
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
