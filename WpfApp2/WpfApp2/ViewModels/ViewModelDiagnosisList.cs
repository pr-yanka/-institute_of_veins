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
    public class DiagnosisDataSource : INotifyPropertyChanged
    {
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
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public DiagnosisType Data { get; set; }

        public DiagnosisDataSource(DiagnosisType Diagnosis)
        {
            this.Data = Diagnosis;
            IsChecked = false;
        }
    }

    public class ViewModelDiagnosisList : ViewModelBase
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
        public List<DiagnosisDataSource> _dataSourceList;
        public List<DiagnosisDataSource> DataSourceList { get { return _dataSourceList; } set { _dataSourceList = value; OnPropertyChanged(); } }

        private string ld;
        private void SetDiagnosisListBecauseOFEdit(object sender, object data)
        {

           
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
            
        }
        private void SetDiagnosisList(object sender, object data)
        {
            ld = (string)data;
            if (ld == "Left")
            {
                DataSourceList = LeftDiag;
            }
            else
            { DataSourceList = RightDiag; }
        }
        //Жалобы/диагноз/заключение
        public List<DiagnosisDataSource> _leftDiag;
        public List<DiagnosisDataSource> _rightDiag;
        public List<DiagnosisDataSource> LeftDiag { get { return _leftDiag; } set { _leftDiag = value; OnPropertyChanged(); } }
        public List<DiagnosisDataSource> RightDiag { get { return _rightDiag; } set { _rightDiag = value; OnPropertyChanged(); } }

        private void SetClear(object sender, object data)
        {
            DataSourceList = new List<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();

            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
            }
        }
        public ViewModelDiagnosisList(NavigationController controller) : base(controller)
        {

            TextOFNewType = "Новый тип диагноза";
            TextName = "Вернуться к обследованию";
            HeaderText = "Диагнозы";
            AddButtonText = "Добавить диагноз";
            DataSourceList = new List<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();
            MessageBus.Default.Subscribe("SetClearDiagnosisListLeftRightObsled", SetClear);
            MessageBus.Default.Subscribe("SetDiagnosisListBecauseOFEdit", SetDiagnosisListBecauseOFEdit);
            MessageBus.Default.Subscribe("SetleftOrRightForObsled", SetDiagnosisList);
            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    List<DiagnosisDataSource> DataSourceListBuffer = new List<DiagnosisDataSource>();

                    foreach (var Data in DataSourceList)
                    {
                        if (Data.IsChecked == true)
                        {
                            DataSourceListBuffer.Add(Data);
                        }
                    }
                    if (ld == "Left")
                    {
                        MessageBus.Default.Call("SetLeftDiagnosisListForObsled", this, DataSourceListBuffer);
                        LeftDiag = DataSourceList;
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForObsled", this, DataSourceListBuffer);
                        RightDiag = DataSourceList;
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
                    DataSourceList = new List<DiagnosisDataSource>();
                    LeftDiag = new List<DiagnosisDataSource>();
                    RightDiag = new List<DiagnosisDataSource>();
                    foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
                    {
                        DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
                        LeftDiag.Add(new DiagnosisDataSource(DiagnosisType));
                        RightDiag.Add(new DiagnosisDataSource(DiagnosisType));
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
