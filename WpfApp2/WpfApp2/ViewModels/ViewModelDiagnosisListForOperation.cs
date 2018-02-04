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
    public class ViewModelDiagnosisListForOperation : ViewModelBase
    {
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
