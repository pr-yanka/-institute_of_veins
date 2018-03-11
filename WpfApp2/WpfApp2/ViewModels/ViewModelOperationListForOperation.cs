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
    public class OperationTypesDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsVisibleTotal { get; set; }
        public bool IsFilteredPt { get; set; }
        private bool? _isChecked;
        public bool? IsChecked
        {
            get
            {
                if (_isChecked == null)
                    return false;
                else return _isChecked;
            }
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public OperationType Data { get; set; }

        public OperationTypesDataSource(OperationType Diagnosis)
        {
            IsVisibleTotal = true;
            IsFilteredPt = false;
            this.Data = Diagnosis;
            IsChecked = false;
        }
    }
    public class ViewModelOperationListForOperation : ViewModelBase, INotifyPropertyChanged
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
                    if (DataSourceList[i].IsChecked != null && DataSourceList[i].IsChecked == true)
                    {
                        FullCopy[i].IsChecked = true;
                    }
                }
                if (lastLength >= value.Length)
                {
                    //foreach(ChangeHistoryClass x in FullCopy)
                    //{
                    //    ChangeHistoryClass buf = new ChangeHistoryClass(x.Ch);
                    //    Changes.Add(buf);
                    //}

                    DataSourceList = new ObservableCollection<OperationTypesDataSource>(FullCopy);
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

                Controller.NavigateTo<ViewModelOperationListForOperation>();



            }
        }


        List<OperationTypesDataSource> FullCopy;


        #region everyth connected with panel


        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public ICommand OpenCommand { protected set; get; }

        public OperationTypePanelViewModel CurrentPanelViewModel { get; protected set; }


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
            DataSourceList = new ObservableCollection<OperationTypesDataSource>();
            LeftDiag = new List<OperationTypesDataSource>();
            RightDiag = new List<OperationTypesDataSource>();

            foreach (var DiagnosisType in Data.OperationType.GetAll)
            {
                DataSourceList.Add(new OperationTypesDataSource(DiagnosisType));
                LeftDiag.Add(new OperationTypesDataSource(DiagnosisType));
                RightDiag.Add(new OperationTypesDataSource(DiagnosisType));
            }
        }
       


        private void SetDiagnosisList(object sender, object data)
        {
            FilterText = "";
            ld = (string)data;
            if (ld == "Left")
            {
                DataSourceList = new ObservableCollection<OperationTypesDataSource>(LeftDiag);
                FullCopy = LeftDiag;
            }
            else
            {
                DataSourceList = new ObservableCollection<OperationTypesDataSource>(RightDiag);
                FullCopy = RightDiag;
            }
        }
        //Жалобы/диагноз/заключение
        public List<OperationTypesDataSource> LeftDiag { get; set; }
        public List<OperationTypesDataSource> RightDiag { get; set; }
        public ObservableCollection<OperationTypesDataSource> DataSourceList { get; set; }
        public string TextName { get; set; }

        public ViewModelOperationListForOperation(NavigationController controller) : base(controller)
        {
            TextOFNewType = "Новый тип операции";
            VisOfNothingFaund = Visibility.Collapsed;
            CurrentPanelViewModel = new OperationTypePanelViewModel(this);
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });
            //   SetClear
            MessageBus.Default.Subscribe("SetClearOperationListLeftRightOperation", SetClear);
            //MessageBus.Default.Subscribe("SetDiagnosisListRight", SetDiagnosisListRight);
            //MessageBus.Default.Subscribe("SetDiagnosisListLeft", SetDiagnosisListLeft);
            SaveCommand = new DelegateCommand(() =>
            {

                var newType = CurrentPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.ToString()))
                {
                    CurrentPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.OperationType.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = DataSourceList;
                    var LeftDiagbuf = LeftDiag;
                    var RightDiagbuf = RightDiag;
                    DataSourceList = new ObservableCollection<OperationTypesDataSource>();
                    LeftDiag = new List<OperationTypesDataSource>();
                    RightDiag = new List<OperationTypesDataSource>();
                    FullCopy = new List<OperationTypesDataSource>();
                    foreach (var DiagnosisType in Data.OperationType.GetAll)
                    {
                        FullCopy.Add(new OperationTypesDataSource(DiagnosisType));
                        DataSourceList.Add(new OperationTypesDataSource(DiagnosisType));
                        LeftDiag.Add(new OperationTypesDataSource(DiagnosisType));
                        RightDiag.Add(new OperationTypesDataSource(DiagnosisType));
                    }
                    foreach (var DiagnosisType in DataSourceListbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            DataSourceList.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
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
                    Controller.NavigateTo<ViewModelOperationListForOperation>();
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
            HeaderText = "Типы операции";
            AddButtonText = "Новый тип операции";
            MessageBus.Default.Subscribe("SetleftOrRightOpForOp", SetDiagnosisList);
            DataSourceList = new ObservableCollection<OperationTypesDataSource>();
            LeftDiag = new List<OperationTypesDataSource>();
            RightDiag = new List<OperationTypesDataSource>();


            // DataSourceList = new ObservableCollection<OperationForAmbullatorCardDataSource>();
            FullCopy = new List<OperationTypesDataSource>();

            foreach (var DiagnosisType in Data.OperationType.GetAll)
            {
                FullCopy.Add(new OperationTypesDataSource(DiagnosisType));
                DataSourceList.Add(new OperationTypesDataSource(DiagnosisType));
                LeftDiag.Add(new OperationTypesDataSource(DiagnosisType));
                RightDiag.Add(new OperationTypesDataSource(DiagnosisType));
            }


            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    List<OperationTypesDataSource> DataSourceListBuffer = new List<OperationTypesDataSource>();
                    foreach (var Data in FullCopy)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    if (ld == "Left")
                    {



                        MessageBus.Default.Call("SetLeftOperationListForOperation", this, DataSourceListBuffer);
                        LeftDiag = new List<OperationTypesDataSource>(FullCopy);
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightOperationListForOperation", this, DataSourceListBuffer);
                        RightDiag = new List<OperationTypesDataSource>(FullCopy);
                    }

                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    List<OperationTypesDataSource> DataSourceListBuffer = new List<OperationTypesDataSource>();
                    foreach (var Data in DataSourceList)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    if (ld == "Left")
                    {
                        MessageBus.Default.Call("SetLeftDiagnosisListForOperation", this, DataSourceListBuffer);
                        LeftDiag = new List<OperationTypesDataSource>(DataSourceList);
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForOperation", this, DataSourceListBuffer);
                        RightDiag = new List<OperationTypesDataSource>(DataSourceList);
                    }

                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
        }
    }
}
