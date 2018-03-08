using JetBrains.Annotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; OnPropertyChanged(nameof(CurrentViewModel)); }
        }


        private ObservableCollection<LegPartViewModel> _legViewModels;
        public ObservableCollection<LegPartViewModel> LegViewModels
        {
            get { return _legViewModels; }
            set { _legViewModels = value; OnPropertyChanged(); }
        }

        private ViewModelBase _legViewModel;

        public ViewModelBase LegViewModel
        {
            get { return _legViewModel; }
            set { _legViewModel = value; OnPropertyChanged(nameof(LegViewModel)); }
        }

        public void ClearLegPartVM()
        {

            //LegViewModels = new ObservableCollection<LegPartViewModel>();
        }

        //public void AddLegPartVM(LegPartViewModel vm)
        //{
        //    if (LegViewModels == null)
        //    {
        //        LegViewModels = new ObservableCollection<LegPartViewModel>();
        //        //_viewModels = new List<ViewModelBase>();
        //    }
        //    LegViewModels.Add(vm);
        //    vm.idInController = LegViewModels.IndexOf(vm);
        //    //_viewModels.Add(vm);
        //}

        public NavigationController()
        {
            _viewModels = new List<ViewModelBase>
            {
                new ViewModelLogin(this),

                new ViewModelOperationResultOverview(this),
                new ViewModelPhysicalOverview(this),
                new ViewModelOperationOverview(this),
                new ViewModelRegistration(this),
                new ViewModelDashboard(this),
                new ViewModelRedactPathology(this),
                new ViewModelCurrentPatient(this),
                new ViewModelNewPatient(this),
                new ViewModelTablePatients(this),

                new ViewModelEditPatient(this),
                new ViewModelViewHistory(this),
                new ViewModelLegDescribe(this),
                new ViewModelRecomendationsAdd(this),
                new ViewModelSymptomsAdd(this),
                new ViewModelPhysicalTable(this),
                new ViewModelCalendarOperations(this),
                new ViewModelPathologyList(this),
                new ViewModelAddPathology(this),
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
                new ViewModelCancelOperations(this),
                new ViewModelRecomendationsList(this),
                new ViewModelArchivePathology(this),
                new ViewModelAdminPanel(this),
                new ViewModelViewDoctors(this),
                new ViewModelViewUsers(this),
                new ViewModelViewMedPatient(this),

                new ViewModelAddMedPersonal(this),
                new ViewModelAddDoctor(this),
                new ViewModelEditDoctor(this),
                new ViewModelAddUser(this),
                new ViewModelEditUser(this),
                new ViewModelCreateStatement(this),
                new ViewModelEditMedPersonal(this),
                new ViewModelChangesHistoy(this),
                new ViewModelAddEpicriz(this),
                new ViewModelAdditionalInfoPatient(this),
                new ViewModelHirurgInterruptList(this),
                 new ViewModelPreparateHate(this),
                new  ViewModelAlergicAnevrizmList(this),
                   new  ViewModelOperationForAmbullatorCardList(this), new   ViewModelOperationListForOperation(this),
                new LegPartViewModel(this)


            };

            _currentViewModel = _viewModels.First();

            //   AddLegPartVM(new SFSViewModel(this, LegSide.Left));
            /*
            _legViewModels = new List<LegPartViewModel>
            {
                new SFSViewModel(this, LegSide.Left),
                new SFSViewModel(this, LegSide.Right),
                new BPVHipViewModel(this, LegSide.Left),
                new BPVHipViewModel(this, LegSide.Right),
                new HipPerforateViewModel(this, LegSide.Right),
                new PDSVViewModel(this),
                new ZDSVViewModel(this),
                new TibiaPerforateViewModel(this),
                new BPVTibiaViewModel(this),
                new SPSViewModel(this)
            };*/

            // _legViewModel = _legViewModels.First();
        }

        public void NavigateTo<T>()
        {
            var target = _viewModels.FirstOrDefault(e => e.GetType() == typeof(T));

            if (target != null)
                CurrentViewModel = target;
        }

        public LegPartViewModel GetLegPart<T>(LegSide side)
        {
            var target1 = _legViewModels.Where(e => e.GetType() == typeof(T));
            var target2 = target1.Where(e => (e).CurrentLegSide == side);
            var target3 = target2.FirstOrDefault();
            return target3;
        }

        public void NavigateTo<T>(LegSide side)
        {
            var target = GetLegPart<T>(side);
            if (target != null)
            {
                LegViewModel = target;
                NavigateTo<LegPartViewModel>();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
