using Microsoft.Practices.Prism.Commands;
using System;
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
    public class PreparateHateDataSource : INotifyPropertyChanged
    {
        private IEnumerable<String> _townsList;
        public IEnumerable<String> PreparateHateCommentList { get { return _townsList; } set { _townsList = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public PreparateHate Data { get; set; }
        public string Commentary { set { _str = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); } get { return _str; } }

        private string _str;
        public bool IsVisibleTotal { get; set; }
        private bool? _isChecked;
        public DelegateCommand DeleteCommand { set; get; }
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
        public PreparateHateDataSource(PreparateHate Recomendations)
        {
            using (var context = new MySqlContext())
            {
                PreparateHateCommentRepository prpH = new PreparateHateCommentRepository(context);
                List<string> buff2 = new List<string>();
                foreach (var x in prpH.GetAll)
                    buff2.Add(x.Str);


                PreparateHateCommentList = buff2;
            }

            IsVisibleTotal = true;
            this.Data = Recomendations;
            IsChecked = false;
        }
    }
    public class ViewModelPreparateHate : ViewModelBase, INotifyPropertyChanged
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

        public PreparateHatePanelViewModel CurrentPanelViewModel { get; protected set; }


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

                    DataSourceList = new ObservableCollection<PreparateHateDataSource>(FullCopy);
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

                Controller.NavigateTo<ViewModelPreparateHate>();



            }
        }


        List<PreparateHateDataSource> FullCopy;
        private void SetClear(object sender, object data)
        {
            DataSourceList = new ObservableCollection<PreparateHateDataSource>();
            FullCopy = new List<PreparateHateDataSource>();
            using (var context = new MySqlContext())
            {
                PreparateHateRepository sRep = new PreparateHateRepository(context);


                foreach (var HirurgInterupType in sRep.GetAll)
                {
                    DataSourceList.Add(new PreparateHateDataSource(HirurgInterupType));
                    FullCopy.Add(new PreparateHateDataSource(HirurgInterupType));
                }
            }
        }
        private void SetDRecomendationListBecauseOFEdit(object sender, object data)
        {

            SetClear(null, null);
            foreach (var dat in (List<PreparateHateDataSource>)data)
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
        public ObservableCollection<PreparateHateDataSource> _dataSourceList;
        public ObservableCollection<PreparateHateDataSource> DataSourceList { get { return _dataSourceList; } set { _dataSourceList = value; OnPropertyChanged(); } }

        public ViewModelPreparateHate(NavigationController controller) : base(controller)
        {
            VisOfNothingFaund = Visibility.Collapsed;
            MessageBus.Default.Subscribe("SetClearPreparateHateList", SetClear);
            MessageBus.Default.Subscribe("SetPreparateHateListBecauseOFEdit", SetDRecomendationListBecauseOFEdit);
            TextOFNewType = "Новый препарат";
            HeaderText = "Непереносимость припаратов";
            AddButtonText = "Другой препарат";

            DataSourceList = new ObservableCollection<PreparateHateDataSource>();
            foreach (var RecomendationsType in Data.PreparateHate.GetAll)
            {
                DataSourceList.Add(new PreparateHateDataSource(RecomendationsType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    FilterText = "";
                    ObservableCollection<PreparateHateDataSource> DataSourceListBuffer = new ObservableCollection<PreparateHateDataSource>();
                    foreach (var Data in FullCopy)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    MessageBus.Default.Call("SetPreparateHateList", this, DataSourceListBuffer);
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                }
            );



            CurrentPanelViewModel = new PreparateHatePanelViewModel(this);
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

                    Data.PreparateHate.Add((newType));

                    Data.Complete();
                    var DataSourceListbuf = DataSourceList;
                    DataSourceList = new ObservableCollection<PreparateHateDataSource>();
                    FullCopy = new List<PreparateHateDataSource>();
                    using (var context = new MySqlContext())
                    {
                        PreparateHateRepository sRep = new PreparateHateRepository(context);


                        foreach (var HirurgInterupType in sRep.GetAll)
                        {
                            DataSourceList.Add(new PreparateHateDataSource(HirurgInterupType));
                            FullCopy.Add(new PreparateHateDataSource(HirurgInterupType));
                        }
                    }

                    foreach (var DiagnosisType in DataSourceListbuf)
                    {
                        if (DiagnosisType.IsChecked.Value)
                        {
                            DataSourceList.Where(s => s.Data.Id == DiagnosisType.Data.Id).ToList()[0].IsChecked = true;
                        }
                    }

                    Controller.NavigateTo<ViewModelPreparateHate>();
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
