using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;

namespace WpfApp2.ViewModels
{
    public class ViewModelDiagnosisListForOperation : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

                Controller.NavigateTo<ViewModelDiagnosisListForOperation>();



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
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        private string ld;

        private void SetClear(object sender, object data)
        {
            DataSourceList = new ObservableCollection<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();

            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
            }
        }
        private void SetDiagnosisListLeft(object sender, object data)
        {
            // using
            var DiagList = (List<DiagnosisObs>)data;
            List<DiagnosisDataSource> DataSourceListBuffer = new List<DiagnosisDataSource>();
            for (int i = 0; i < DiagList.Count; ++i)
            {

                DataSourceListBuffer.Add(new DiagnosisDataSource(DiagList[i].DiagnosisType));
                DataSourceListBuffer[i].IsChecked = true;
            }
            //LeftDiag = new List<DiagnosisDataSource>();
            //for (int i = 0; i < DiagList.Count; ++i)
            //{
            //    LeftDiag.Add(new DiagnosisDataSource(DiagList[i].DiagnosisType));
            //    LeftDiag[i].IsChecked = true;
            //}
            MessageBus.Default.Call("SetLeftDiagnosisListForOperation", this, DataSourceListBuffer);
            Controller.NavigateTo<ViewModelAddOperation>();
        }
        private void SetDiagnosisListRight(object sender, object data)
        {
            var DiagList = (List<DiagnosisObs>)data;
            List<DiagnosisDataSource> DataSourceListBuffer = new List<DiagnosisDataSource>();
            for (int i = 0; i < DiagList.Count; ++i)
            {

                DataSourceListBuffer.Add(new DiagnosisDataSource(DiagList[i].DiagnosisType));
                DataSourceListBuffer[i].IsChecked = true;
            }
            //RightDiag = new List<DiagnosisDataSource>();
            //for (int i = 0; i < DiagList.Count; ++i)
            //{
            //    RightDiag.Add(new DiagnosisDataSource(DiagList[i].DiagnosisType));
            //    RightDiag[i].IsChecked = true;
            //}
            MessageBus.Default.Call("SetRightDiagnosisListForOperation", this, DataSourceListBuffer);
            Controller.NavigateTo<ViewModelAddOperation>();
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
        public List<DiagnosisDataSource> LeftDiag { get; set; }
        public List<DiagnosisDataSource> RightDiag { get; set; }
        public ObservableCollection<DiagnosisDataSource> DataSourceList { get; set; }
        public string TextName { get; set; }

        public ViewModelDiagnosisListForOperation(NavigationController controller) : base(controller)
        {
            VisOfNothingFaund = Visibility.Collapsed;
            CurrentPanelViewModel = new DiagTypePanelViewModel(this);
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });
            //   SetClear
            MessageBus.Default.Subscribe("SetClearDiagnosisListLeftRightOperation", SetClear);
            MessageBus.Default.Subscribe("SetDiagnosisListRight", SetDiagnosisListRight);
            MessageBus.Default.Subscribe("SetDiagnosisListLeft", SetDiagnosisListLeft);
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
                    Controller.NavigateTo<ViewModelDiagnosisListForOperation>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });
            TextName = "Вернуться к обследованию";
            HeaderText = "Диагнозы";
            AddButtonText = "Другой диагноз";
            MessageBus.Default.Subscribe("SetleftOrRight", SetDiagnosisList);
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


            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    FilterText = "";
                    List<DiagnosisDataSource> DataSourceListBuffer = new List<DiagnosisDataSource>();
                    foreach (var Data in FullCopy)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    if (ld == "Left")
                    {
                        MessageBus.Default.Call("SetLeftDiagnosisListForOperation", this, DataSourceListBuffer);
                        LeftDiag = new List<DiagnosisDataSource>(DataSourceList);
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForOperation", this, DataSourceListBuffer);
                        RightDiag = new List<DiagnosisDataSource>(DataSourceList);
                    }

                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    FilterText = "";
                    List<DiagnosisDataSource> DataSourceListBuffer = new List<DiagnosisDataSource>();
                    foreach (var Data in FullCopy)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    if (ld == "Left")
                    {
                        MessageBus.Default.Call("SetLeftDiagnosisListForOperation", this, DataSourceListBuffer);
                        LeftDiag = LeftDiag = new List<DiagnosisDataSource>(DataSourceList);
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForOperation", this, DataSourceListBuffer);
                        RightDiag = LeftDiag = new List<DiagnosisDataSource>(DataSourceList);
                    }

                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
        }
    }
}
