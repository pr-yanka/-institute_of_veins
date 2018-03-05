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
    public class OperationForAmbullatorCardDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public OperationForAmbulatornCard Data { get; set; }
        public DelegateCommand DeleteCommand { set; get; }

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
        public OperationForAmbullatorCardDataSource(OperationForAmbulatornCard Recomendations)
        {
            IsVisibleTotal = true;
            IsFilteredPt = false;
            this.Data = Recomendations;
            IsChecked = false;
        }
    }
    public class ViewModelOperationForAmbullatorCardList : ViewModelBase
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

        public OperationForAmbullatorCardPanelViewModel CurrentPanelViewModel { get; protected set; }


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
                 
                    DataSourceList = new ObservableCollection<OperationForAmbullatorCardDataSource>(FullCopy);
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

                Controller.NavigateTo<ViewModelOperationForAmbullatorCardList>();



            }
        }

       
        List<OperationForAmbullatorCardDataSource> FullCopy;
        private void SetClear(object sender, object data)
        {
            DataSourceList = new ObservableCollection<OperationForAmbullatorCardDataSource>();
            using (var context = new MySqlContext())
            {
                OperationForAmbulatornCardRepository sRep = new OperationForAmbulatornCardRepository(context);
                foreach (var HirurgInterupType in sRep.GetAll)
                {
                    DataSourceList.Add(new OperationForAmbullatorCardDataSource(HirurgInterupType));
                }
            }
        }
        private void SetDRecomendationListBecauseOFEdit(object sender, object data)
        {

            foreach (var dat in (ObservableCollection<OperationForAmbullatorCardDataSource>)data)
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
        public string TextOFNewType { get; private set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public ObservableCollection<OperationForAmbullatorCardDataSource> _dataSourceList;
        public ObservableCollection<OperationForAmbullatorCardDataSource> DataSourceList { get { return _dataSourceList; } set { _dataSourceList = value; OnPropertyChanged(); } }

        public ViewModelOperationForAmbullatorCardList(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("SetClearOprerationForAmbCardList", SetClear);
            MessageBus.Default.Subscribe("SetOprerationForAmbCardListBecauseOFEdit", SetDRecomendationListBecauseOFEdit);
            TextOFNewType = "Новая операция";
            HeaderText = "Операции";
            AddButtonText = "Добавить";

            DataSourceList = new ObservableCollection<OperationForAmbullatorCardDataSource>();
            FullCopy = new List<OperationForAmbullatorCardDataSource>();
            foreach (var RecomendationsType in Data.OperationForAmbulatornCard.GetAll)
            {
                FullCopy.Add(new OperationForAmbullatorCardDataSource(RecomendationsType));
                DataSourceList.Add(new OperationForAmbullatorCardDataSource(RecomendationsType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    ObservableCollection<OperationForAmbullatorCardDataSource> DataSourceListBuffer = new ObservableCollection<OperationForAmbullatorCardDataSource>();
                    foreach (var Data in DataSourceList)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);

                        }
                    }
                    MessageBus.Default.Call("SetOprerationForAmbCardList", this, DataSourceListBuffer);
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );



            CurrentPanelViewModel = new OperationForAmbullatorCardPanelViewModel(this);
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {
                var newType = CurrentPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.OperationForAmbulatornCard.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = DataSourceList;
                    DataSourceList = new ObservableCollection<OperationForAmbullatorCardDataSource>();
                    FullCopy = new List<OperationForAmbullatorCardDataSource>();
                    using (var context = new MySqlContext())
                    {
                        OperationForAmbulatornCardRepository sRep = new OperationForAmbulatornCardRepository(context);
                        foreach (var HirurgInterupType in sRep.GetAll)
                        {
                            FullCopy.Add(new OperationForAmbullatorCardDataSource(HirurgInterupType));
                            DataSourceList.Add(new OperationForAmbullatorCardDataSource(HirurgInterupType));
                        }
                    }
                    //foreach (var RecomendationsType in Data.OperationForAmbulatornCard.GetAll)
                    //{
                    //    DataSourceList.Add(new OperationForAmbullatorCardDataSource(RecomendationsType));
                    //}

                    foreach (var DiagnosisType in DataSourceListbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            DataSourceList.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelOperationForAmbullatorCardList>();
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
