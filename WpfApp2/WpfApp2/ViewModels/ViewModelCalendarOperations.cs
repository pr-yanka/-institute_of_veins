using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public struct OperationStruct
    {

        public string Date { get; set; }
        public string Time { get; set; }
        public string Patient { get; set; }
        public string OpType { get; set; }
        public string Anestetic { get; set; }
        public DelegateCommand ToOperation { get; set; }

        public OperationStruct(DelegateCommand ToOperation, Operation Op)
        {
            this.ToOperation = ToOperation;
            DateTime buf1 = DateTime.Parse(Op.Time);
            Date = Op.Date.Day.ToString() + "." + Op.Date.Month.ToString() + "." + Op.Date.Year.ToString();
            Time = buf1.Hour.ToString() + ":" + buf1.Minute.ToString();

            using (var context = new MySqlContext())
            {
                PatientsRepository PtRep = new PatientsRepository(context);
                AnestethicRepository AnestethicRep = new AnestethicRepository(context);
                OperationTypeRepository OperationTypeRep = new OperationTypeRepository(context);
                var CurrentPatient = PtRep.Get(Op.PatientId);
                Patient = CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";

                if (!string.IsNullOrWhiteSpace(OperationTypeRep.Get(Op.OperationTypeId).ShortName))
                    OpType = OperationTypeRep.Get(Op.OperationTypeId).ShortName;
                else
                {
                    OpType = OperationTypeRep.Get(Op.OperationTypeId).LongName;
                }

                Anestetic = AnestethicRep.Get(Op.AnestheticId).Str;
            }

        }

    }

    public class ViewModelCalendarOperations : ViewModelBase, INotifyPropertyChanged
    {
        private bool _IsCompletedOp;
        private bool _isSortByData;
        //   string CurrentAcaunt;  
        public bool IsSortByData { get { return _isSortByData; } set { _isSortByData = value; if (_isSortByData == true)
                {
                    ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));

                    // Let the UI control refresh in order for changes to take place.
                    ViewSource.View.Refresh();

                }
                else
                {
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                } OnPropertyChanged(); } }
        public CollectionViewSource ViewSource { get; set; }

        private void SetCurrentACCOp(object sender, object data)
        {
            using (var context = new MySqlContext())
            {

                MedPersonalRepository MedPersonalRep = new MedPersonalRepository(context);


                OperationRepository OperationRp = new OperationRepository(context);



                BrigadeRepository BrigadeRep = new BrigadeRepository(context);
                BrigadeMedPersonalRepository BrigadeMedRep = new BrigadeMedPersonalRepository(context);

                var CurrentAc = Data.Accaunt.Get((int)data);
                Operations = new ObservableCollection<OperationStruct>();

                bool test = true;


                foreach (var Operation in OperationRp.GetAll)
                {

                    test = true;
                    if (CurrentAc.isDoctor != null && CurrentAc.isDoctor.Value)
                        foreach (var Brigade in BrigadeRep.GetAll)
                        {

                            if (Brigade.id_операции == Operation.Id && CurrentAc.idврач == Brigade.id_врача)
                            {
                                test = false;
                            }
                        }
                    else if (CurrentAc.isMedPersonal != null && CurrentAc.isMedPersonal.Value)
                        foreach (var Brigade in BrigadeMedRep.GetAll)
                        {
                            if (Brigade.id_операции == Operation.Id && CurrentAc.idмедперсонал == Brigade.id_медперсонал)
                            {
                                test = false;
                            }
                        }


                    if (!test)
                    {
                        DelegateCommand bufer = new DelegateCommand(
                        () =>
                        {
                            MessageBus.Default.Call("GetOperationForOverwiev", this, Operation.Id);
                            Controller.NavigateTo<ViewModelOperationOverview>();
                        }
                    );


                        if (Operation.отмена_операции != null) { }
                        else
                            Operations.Add(new OperationStruct(bufer, Operation));
                    }
                }
                ViewSource = new CollectionViewSource();
                ViewSource.Source = Operations;
                IsSortByData = true;
            
            }
        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public ObservableCollection<OperationStruct> _operations;
        public ObservableCollection<OperationStruct> Operations { get { return _operations; } set { _operations = value; OnPropertyChanged(); } }



        public ViewModelCalendarOperations(NavigationController controller) : base(controller)
        {

            MessageBus.Default.Subscribe("SetCurrentACCOp", SetCurrentACCOp);
            base.HasNavigation = true;



            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );

            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
    }
}
