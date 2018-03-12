using Microsoft.Practices.Prism.Commands;
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
    public class ComplainsDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsVisibleTotal { get; set; }
        public bool IsFilteredPt { get; set; }
        public ComplainsType Data { get; set; }
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
        public ComplainsDataSource(ComplainsType Complains)
        {
            IsVisibleTotal = true;
            IsFilteredPt = false;

            this.Data = Complains;
            IsChecked = false;
        }
    }
    public class ViewModelComplainsList : ViewModelBase, INotifyPropertyChanged
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

                    DataSourceList = new ObservableCollection<ComplainsDataSource>(FullCopy);
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

                Controller.NavigateTo<ViewModelComplainsList>();



            }
        }


        List<ComplainsDataSource> FullCopy;
        #region everyth connected with panel


        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public ICommand OpenCommand { protected set; get; }

        public ComplaneTypePanelViewModel CurrentPanelViewModel { get; protected set; }


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

        private void SetDComplanesListBecauseOFEdit(object sender, object data)
        {

            FilterText = "";
            foreach (var dat in (List<ComplainsDataSource>)data)
            {
                foreach (var datC in DataSourceList)
                {
                    if (dat.Data != null && dat.Data.Id == datC.Data.Id)
                    {
                        datC.IsChecked = true;
                    }
                }
            }
            FilterText = "";

        }


        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string TextOFNewType { get; private set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public ObservableCollection<ComplainsDataSource> _dataSourceList;
        public ObservableCollection<ComplainsDataSource> DataSourceList { get { return _dataSourceList; } set { _dataSourceList = value; OnPropertyChanged(); } }
        private void SetClear(object sender, object data)
        {
            FilterText = "";
            DataSourceList = new ObservableCollection<ComplainsDataSource>();
            FullCopy = new List<ComplainsDataSource>();
            foreach (var ComplainsType in Data.ComplainsTypes.GetAll)
            {
                FullCopy.Add(new ComplainsDataSource(ComplainsType));
                DataSourceList.Add(new ComplainsDataSource(ComplainsType));
            }
        }
        public ViewModelComplainsList(NavigationController controller) : base(controller)
        {
            VisOfNothingFaund = Visibility.Collapsed;
            MessageBus.Default.Subscribe("SetDComplanesListBecauseOFEdit", SetDComplanesListBecauseOFEdit);
            MessageBus.Default.Subscribe("SetClearComplanesListObsledovanie", SetClear);
            TextOFNewType = "Новый тип жалобы";
            HeaderText = "Жалобы";
            AddButtonText = "Другая жалоба";
            DataSourceList = new ObservableCollection<ComplainsDataSource>();
            FullCopy = new List<ComplainsDataSource>();
            foreach (var ComplainsType in Data.ComplainsTypes.GetAll)
            {
                FullCopy.Add(new ComplainsDataSource(ComplainsType));
                DataSourceList.Add(new ComplainsDataSource(ComplainsType));
            }
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    FilterText = "";
                    List<ComplainsDataSource> DataSourceListBuffer = new List<ComplainsDataSource>();
                    foreach (var Data in DataSourceList)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    MessageBus.Default.Call("SetComplainsList", this, DataSourceListBuffer);
                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {

                    Controller.NavigateTo<ViewModelAddPhysical>();
                }
            );

            CurrentPanelViewModel = new ComplaneTypePanelViewModel(this);
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

                    Data.ComplainsTypes.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = DataSourceList;
                    DataSourceList = new ObservableCollection<ComplainsDataSource>();
                    FullCopy = new List<ComplainsDataSource>();
                    foreach (var ComplainsType in Data.ComplainsTypes.GetAll)
                    {
                        DataSourceList.Add(new ComplainsDataSource(ComplainsType));
                        FullCopy.Add(new ComplainsDataSource(ComplainsType));
                    }


                    foreach (var DiagnosisType in DataSourceListbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            DataSourceList.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                            FullCopy.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }
                    OnPropertyChanged("DataSourceList");
                    Controller.NavigateTo<ViewModelComplainsList>();
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
