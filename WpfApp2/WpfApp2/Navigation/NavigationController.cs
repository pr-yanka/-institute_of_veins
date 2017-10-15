using JetBrains.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public NavigationController()
        {
            _viewModels = new List<ViewModelBase>
            {
                new ViewModelLogin(this),
                new ViewModelRegistration(this),
                new ViewModelDashboard(this),
                new ViewModelCurrentPatient(this),
                new ViewModelNewPatient(this),
                new ViewModelTablePatients(this),
                new ViewModelAddPhysicalScreen1(this),
                new ViewModelEditPatient(this),
                new ViewModelViewHistory(this),
                new ViewModelLegDescribe(this),
                new ViewModelRecomendationsAdd(this),
                new ViewModelSymptomsAdd(this),
                new ViewModelPhysicalTable(this),
                new ViewModelOperationOverview(this),
                new ViewModelCalendarOperations(this),
                new ViewModelPathologyList(this),
                new ViewModelAddPathology(this),
                new ViewModelCreateOperation(this),
                new ViewModelOperationOverview(this),
                new ViewModelAddOperationResult(this),
                new ViewModelEditOperation(this)
            };

            _currentViewModel = _viewModels.First();
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
