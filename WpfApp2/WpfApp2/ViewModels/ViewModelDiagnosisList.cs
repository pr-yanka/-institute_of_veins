using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
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
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
        //Жалобы/диагноз/заключение
        public List<DiagnosisDataSource> DataSourceList { get; set; }

        public ViewModelDiagnosisList(NavigationController controller) : base(controller)
        {
            HeaderText = "Диагнозы";
            AddButtonText = "Добавить диагноз";
            DataSourceList = new List<DiagnosisDataSource>();
            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
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
                    MessageBus.Default.Call("SetDiagnosisList", this, DataSourceListBuffer);
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
