using JetBrains.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp2.LegParts;
using WpfApp2.LegParts.VMs;
using WpfApp2.ViewModels;

namespace WpfApp2.Navigation
{
    public class NavigationController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<ViewModelBase> _viewModels;

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel {
            get { return _currentViewModel; }
            set { _currentViewModel = value; OnPropertyChanged(nameof(CurrentViewModel)); }
        }

        private List<ViewModelBase> _legViewModels;

        private ViewModelBase _legViewModel;

        public ViewModelBase LegViewModel
        {
            get { return _legViewModel; }
            set { _legViewModel = value; OnPropertyChanged(nameof(LegViewModel)); }
        }

        public NavigationController()
        {
            _viewModels = new List<ViewModelBase>
            {
                new ViewModelLogin(this),
                new ViewModelPhysicalOverview(this),
                new ViewModelOperationOverview(this),
                new ViewModelRegistration(this),
                new ViewModelDashboard(this),
                new ViewModelCurrentPatient(this),
                new ViewModelNewPatient(this),
                new ViewModelTablePatients(this),
                new ViewModelAddPhysical(this),
                new ViewModelEditPatient(this),
                new ViewModelViewHistory(this),
                new ViewModelLegDescribe(this),
                new ViewModelRecomendationsAdd(this),
                new ViewModelSymptomsAdd(this),
                new ViewModelPhysicalTable(this),
                new ViewModelCalendarOperations(this),
                new ViewModelPathologyList(this),
                new ViewModelAddPathology(this),
                new ViewModelCreateOperation(this),
                new ViewModelAddOperationResult(this),
                new ViewModelEditOperation(this),
                new ViewModelAddAnalize(this),
                new ViewModelAddPhysical(this),
                new ViewModelAnalizeOverview(this),
                new ViewModelAddOperation(this),
                new LegPartViewModel(this),
               new ViewModelDiagnosisListForOperation(this),
                new ViewModelComplainsList(this),
                new ViewModelDiagnosisList(this),
                new ViewModelRecomendationsList(this)
            };

            _currentViewModel = _viewModels.First();

            _legViewModels = new List<ViewModelBase>
            {
                new SFSViewModel(this),
                new BPVHipViewModel(this),
                new HipPerforateViewModel(this),
                new PDSVViewModel(this),
                new ZDSVViewModel(this),
                new TibiaPerforateViewModel(this),
                new BPVTibiaViewModel(this),
                new SPSViewModel(this)
            };

            _legViewModel = _legViewModels.First();
        }

        public void NavigateTo<T>()
        {
            var target = _viewModels.FirstOrDefault(e => e.GetType() == typeof(T));

            if (target != null)
                CurrentViewModel = target;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
