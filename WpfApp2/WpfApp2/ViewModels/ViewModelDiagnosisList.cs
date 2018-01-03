using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

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

        public string TextName { get; set; }
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public List<DiagnosisDataSource> DataSourceList { get; set; }
        private string ld;
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
        public List<DiagnosisDataSource> LeftDiag { get; set; }
        public List<DiagnosisDataSource> RightDiag { get; set; }

        public ViewModelDiagnosisList(NavigationController controller) : base(controller)
        {
            TextName = "Вернуться к обследованию";
            HeaderText = "Диагнозы";
            AddButtonText = "Добавить диагноз";
            DataSourceList = new List<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();
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
        }
    }
}
