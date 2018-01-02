using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ViewModelDiagnosisListForOperation : ViewModelBase
    {
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }
        public string HeaderText { get; set; }
        public string AddButtonText { get; set; }
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
        public List<DiagnosisDataSource> DataSourceList { get; set; }
        public string TextName { get; set; }
       
        public ViewModelDiagnosisListForOperation(NavigationController controller) : base(controller)
        {
            
            TextName = "Вернуться к обследованию";
            HeaderText = "Диагнозы";
            AddButtonText = "Добавить диагноз";
            MessageBus.Default.Subscribe("SetleftOrRight", SetDiagnosisList);
            DataSourceList = new List<DiagnosisDataSource>();
            LeftDiag = new List<DiagnosisDataSource>();
            RightDiag = new List<DiagnosisDataSource>();
           
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
                        MessageBus.Default.Call("SetLeftDiagnosisListForOperation", this, DataSourceListBuffer);
                        LeftDiag = DataSourceList;
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForOperation", this, DataSourceListBuffer);
                        RightDiag = DataSourceList;
                    }
                   
                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
            SaveChangesCommand = new DelegateCommand(
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
                        MessageBus.Default.Call("SetLeftDiagnosisListForOperation", this, DataSourceListBuffer);
                        LeftDiag = DataSourceList;
                    }
                    else
                    {
                        MessageBus.Default.Call("SetRightDiagnosisListForOperation", this, DataSourceListBuffer);
                        RightDiag = DataSourceList;
                    }

                    Controller.NavigateTo<ViewModelAddOperation>();
                }
            );
        }
    }
}
