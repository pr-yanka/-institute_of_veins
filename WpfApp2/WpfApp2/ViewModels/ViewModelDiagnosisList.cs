using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class DiagnosisDataSource
    {

        public DiagnosisType Data {get;set;}
        public bool IsSelected { get; set; }
        public DiagnosisDataSource(DiagnosisType Diagnosis)
        {
            this.Data = Diagnosis;
            IsSelected = false;
        }
    }

    public class ViewModelDiagnosisList : ViewModelBase
    {
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand SaveChangesCommand { get; protected set; }

        public List<DiagnosisDataSource> DataSourceList { get; set; }

        public ViewModelDiagnosisList(NavigationController controller) : base(controller)
        {
            DataSourceList = new List<DiagnosisDataSource>();
            foreach (var DiagnosisType in Data.DiagnosisTypes.GetAll)
            {
                DataSourceList.Add(new DiagnosisDataSource(DiagnosisType));
            }

            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
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
