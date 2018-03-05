using System;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp2.ViewModels.Panels;
using System.Linq;

namespace WpfApp2.ViewModels
{
    public class BloodExchangeListDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DelegateCommand DeleteCommand { set; get; }

        public BloodExchange Data { get; set; }
        public string Commentary { get; set; }
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
        public BloodExchangeListDataSource(BloodExchange Recomendations, DelegateCommand DeleteThis)
        {
            DeleteCommand = DeleteThis;
            this.Data = Recomendations;
            IsChecked = false;
        }
    }
    public class ViewModelAdditionalInfoPatient : ViewModelBase, INotifyPropertyChanged
    {
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand Changed { get; protected set; }
        #endregion


        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Bindings
        public DelegateCommand RevertCommand { set; get; }



        public DelegateCommand SaveCommand { set; get; }


        public ICommand OpenCommand { protected set; get; }

        public BloodExchangePanelViewModel CurrentPanelViewModel { get; protected set; }


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

        private IEnumerable<String> _districtList;
        private IEnumerable<String> _streetList;
        private IEnumerable<String> _townsList;
        public IEnumerable<String> TownsList { get { return _townsList; } set { _townsList = value; OnPropertyChanged(); } }
        public IEnumerable<String> DistrictList { get { return _districtList; } set { _districtList = value; OnPropertyChanged(); } }
        public IEnumerable<String> RegionList { get; set; }
        public IEnumerable<String> StreetList { get { return _streetList; } set { _streetList = value; OnPropertyChanged(); } }

        private Patient currentPatient;
        private Visibility _visibility;
        public Visibility Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }



        private ObservableCollection<BloodExchangeListDataSource> _bloodExchange;
        private ObservableCollection<PreparateHateDataSource> _preparateHateTypes;
        private ObservableCollection<HirurgInterruptDataSource> _hirurgIntruptTypes;
        private ObservableCollection<AlergicAnevrizmListDataSource> _alergicAnevrizmTypes;
        private ObservableCollection<OperationForAmbullatorCardDataSource> _operationForAmbulatornCardBuf;


        private CollectionViewSource _bloodExchangeList;
        private CollectionViewSource _preparateHateList;
        private CollectionViewSource _alergicAnevrizmList;
        private CollectionViewSource _hirurgInteruptList;
        private CollectionViewSource _operationForAmbCard;


        public CollectionViewSource BloodExchangeList   { get { return _bloodExchangeList; } set { _bloodExchangeList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public CollectionViewSource PreparateHateList   { get { return _preparateHateList; } set { _preparateHateList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public CollectionViewSource AlergicAnevrizmList { get { return _alergicAnevrizmList; } set { _alergicAnevrizmList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public CollectionViewSource HirurgInteruptList   { get { return _hirurgInteruptList; } set { _hirurgInteruptList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public DelegateCommand ToSetOprerationForAmbCardListCommand { get; set; }
        public CollectionViewSource OperationForAmbCard { get { return _operationForAmbCard; } set { _operationForAmbCard = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }

        public DelegateCommand ToSetHirurgInterruptCommand { get; private set; }
        public DelegateCommand ToSetPreparateHateCommand { get; }
        public DelegateCommand ToSetAlergicAnevrizmCommand { get; private set; }

        //public ObservableCollection<string> OprTypes { get { return _oprTypes; } set { _oprTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<BloodExchangeListDataSource> BloodExchange { get { return _bloodExchange; } set { _bloodExchange = value; OnPropertyChanged(); } }
        ObservableCollection<OperationForAmbullatorCardDataSource> OperationForAmbulatornCardBuf { get { return _operationForAmbulatornCardBuf; } set { _operationForAmbulatornCardBuf = value; OnPropertyChanged(); } }

        ObservableCollection<AlergicAnevrizmListDataSource> AlergicAnevrizmBuf { get { return _alergicAnevrizmTypes; } set { _alergicAnevrizmTypes = value; OnPropertyChanged(); } }

        ObservableCollection<HirurgInterruptDataSource> HirurgInteruptBuf { get { return _hirurgIntruptTypes; } set { _hirurgIntruptTypes = value; OnPropertyChanged(); } }

        ObservableCollection<PreparateHateDataSource> PreparateHateBuf { get { return _preparateHateTypes; } set { _preparateHateTypes = value; OnPropertyChanged(); } }


        private string _bloodGroup;

        private string _sugar;

        private string _isPositiveGroupType;
        private string _nameOfButton;


        private int _isPositiveGroupTypeID;
        private int _bloodGroupID;

        public int BloodGroupID
        {
            get { return _bloodGroupID; }
            set
            {
                _bloodGroupID = value;

                OnPropertyChanged();
            }
        }

        public int IsPositiveGroupTypeID
        {
            get { return _isPositiveGroupTypeID; }
            set
            {
                _isPositiveGroupTypeID = value;

                OnPropertyChanged();
            }
        }



        public string NameOfButton
        {
            get { return _nameOfButton; }
            set
            {
                _nameOfButton = value;

                OnPropertyChanged();
            }
        }
        private string _operation;

        public Patient CurrentPatient { get; set; }

        public string BloodGroup
        {
            get { return _bloodGroup; }
            set
            {
                _bloodGroup = value;
                NameOfButton = "Сохранить";
                OnPropertyChanged();
            }
        }

        public string Sugar
        {
            get { return _sugar; }
            set
            {
                _sugar = value;
                NameOfButton = "Сохранить";
                OnPropertyChanged();
            }
        }

        public string IsPositiveGroupType
        {
            get { return _isPositiveGroupType; }
            set
            {
                _isPositiveGroupType = value;
                NameOfButton = "Сохранить";
                OnPropertyChanged();
            }
        }


        public string Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;

                OnPropertyChanged();
            }
        }
        #endregion

        //private void SetBloodExhangeList(object sender, object data)
        //{
        //    BloodExchangeList.Source = (List<BloodExhangeDataSource>)data;d
        //    BloodExchangeList.View.Refresh();
        //}





        private void SetPreparateHateList(object sender, object data)
        {
            PreparateHateBuf = (ObservableCollection<PreparateHateDataSource>)data;
            foreach (var x in PreparateHateBuf)
            {
                DelegateCommand DelThis = new DelegateCommand(() =>
                {
                    for (int i = 0; i < ((ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source).Count; i++)
                    {
                        if (((ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source)[i].Data.Id == x.Data.Id)
                        {
                            ((ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source).RemoveAt(i);
                        }
                    }

                });

                x.DeleteCommand = DelThis;
            }

            PreparateHateList.Source = PreparateHateBuf;
            PreparateHateList.View.Refresh();
        }
        private void SetAlergicAnevrizmListList(object sender, object data)
        {
            AlergicAnevrizmBuf = (ObservableCollection<AlergicAnevrizmListDataSource>)data;
            foreach (var x in AlergicAnevrizmBuf)
            {
                DelegateCommand DelThis = new DelegateCommand(() =>
                {
                    for (int i = 0; i < ((ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source).Count; i++)
                    {
                        if (((ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source)[i].Data.Id == x.Data.Id)
                        {
                            ((ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source).RemoveAt(i);
                        }
                    }

                });

                x.DeleteCommand = DelThis;
            }
            AlergicAnevrizmList.Source = AlergicAnevrizmBuf;
            AlergicAnevrizmList.View.Refresh();
        }
        private void SetHirurgInteruptListList(object sender, object data)
        {
            HirurgInteruptBuf =   (ObservableCollection<HirurgInterruptDataSource>)data;
            foreach (var x in HirurgInteruptBuf)
            {
                DelegateCommand DelThis = new DelegateCommand(() =>
                {
                    for (int i = 0; i < ((ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source).Count; i++)
                    {
                        if (((ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)[i].Data.Id == x.Data.Id)
                        {
                            ((ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source).RemoveAt(i);
                        }
                    }

                });

                x.DeleteCommand = DelThis;
            }
            HirurgInteruptList.Source = HirurgInteruptBuf;
            HirurgInteruptList.View.Refresh();
        }
        private void SetOprerationForAmbCardList(object sender, object data)
        {
            OperationForAmbulatornCardBuf =  (ObservableCollection<OperationForAmbullatorCardDataSource>)data;
            foreach (var x in OperationForAmbulatornCardBuf)
            {
                DelegateCommand DelThis = new DelegateCommand(() =>
                {
                    for (int i = 0; i < ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).Count; i++)
                    {
                        if (((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)[i].Data.Id == x.Data.Id)
                        {
                            ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).RemoveAt(i);
                        }
                    }

                });

                x.DeleteCommand = DelThis;
            }
            OperationForAmbCard.Source = OperationForAmbulatornCardBuf;
            OperationForAmbCard.View.Refresh();
        }

        public DelegateCommand<object> ClickOnAutoComplete { get; set; }
       
        List<BloodExchangeListDataSource> BloodExchangeBuf;
        private void SetCurrentPatientID(object sender, object data)
        {

            MessageBus.Default.Call("SetClearOprerationForAmbCardList", null, null);
            MessageBus.Default.Call("SetClearPreparateHateList", null, null);
            MessageBus.Default.Call("SetClearHirurgInterruptList", null, null);
            MessageBus.Default.Call("SetClearAlergicAnevrizmList", null, null);
            Sugar = "";

            IsPositiveGroupTypeID = 0;
            BloodGroupID = 0;

            BloodExchange = new ObservableCollection<BloodExchangeListDataSource>();
            OperationForAmbulatornCardBuf = new ObservableCollection<OperationForAmbullatorCardDataSource>();
            AlergicAnevrizmBuf = new ObservableCollection<AlergicAnevrizmListDataSource>();
            HirurgInteruptBuf = new ObservableCollection<HirurgInterruptDataSource>();
            PreparateHateBuf = new ObservableCollection<PreparateHateDataSource>();
            BloodExchangeBuf = new List<BloodExchangeListDataSource>();
            BloodExchangeList = new CollectionViewSource();
            PreparateHateList = new CollectionViewSource();
            AlergicAnevrizmList = new CollectionViewSource();
            HirurgInteruptList = new CollectionViewSource();
            OperationForAmbCard = new CollectionViewSource();

            using (var context = new MySqlContext())
            {
                PatientsRepository PatientsRep = new PatientsRepository(context);

                OperationForAmbulatornCardPatientsRepository OperationForAmbulatornCardPatients = new OperationForAmbulatornCardPatientsRepository(context);
                OperationForAmbulatornCardRepository OperationForAmbulatornCard = new OperationForAmbulatornCardRepository(context);
                AlergicAnevrizmRepository AlergicAnevrizm = new AlergicAnevrizmRepository(context);
                AlergicAnevrizmPatientsRepository AlergicAnevrizmPatients = new AlergicAnevrizmPatientsRepository(context);
                BloodExchangeRepository BloodExchangeRep = new BloodExchangeRepository(context);
                BloodExchangePatientsRepository BloodExchangePatients = new BloodExchangePatientsRepository(context);



                HirurgInteruptRepository HirurgInterup = new HirurgInteruptRepository(context);
                HirurgInteruptPatientsRepository HirurgInterupPatients = new HirurgInteruptPatientsRepository(context);


                PreparateHateRepository PreparateHate = new PreparateHateRepository(context);
                PreparateHatePatientsRepository PreparateHatePatients = new PreparateHatePatientsRepository(context);
                //BloodExchange { get; }

                try
                {
                    CurrentPatient = PatientsRep.Get((int)data);

                    if (CurrentPatient.IsPositiveGroupType != null && CurrentPatient.IsPositiveGroupType.Value == false)
                    {
                        IsPositiveGroupTypeID = 1;
                    }
                    else
                    {
                        IsPositiveGroupTypeID = 0;
                    }

                    if (!string.IsNullOrWhiteSpace(CurrentPatient.BloodGroup) && CurrentPatient.BloodGroup == "1")
                    {
                        BloodGroupID = 0;
                    }
                    else if (!string.IsNullOrWhiteSpace(CurrentPatient.BloodGroup) && CurrentPatient.BloodGroup == "2")
                    {
                        BloodGroupID = 1;
                    }
                    else if (!string.IsNullOrWhiteSpace(CurrentPatient.BloodGroup) && CurrentPatient.BloodGroup == "3")
                    {
                        BloodGroupID = 2;
                    }
                    else if (!string.IsNullOrWhiteSpace(CurrentPatient.BloodGroup) && CurrentPatient.BloodGroup == "4")
                    {
                        BloodGroupID = 3;
                    }




                    if (CurrentPatient.Sugar != null)
                        Sugar = CurrentPatient.Sugar;
                    var opList = OperationForAmbulatornCardPatients.GetAll.Where(s => s.id_пациента == CurrentPatient.Id).ToList();
                    foreach (var x in opList)
                    {
                        var z = new OperationForAmbullatorCardDataSource(OperationForAmbulatornCard.Get(x.id_операции));
                        DelegateCommand DelThis = new DelegateCommand(() =>
                        {
                            for (int i = 0; i < ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).Count; i++)
                            {
                                if (((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)[i].Data.Id == z.Data.Id)
                                {
                                    ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).RemoveAt(i);
                                }
                            }

                        });



                        z.DeleteCommand = DelThis;
                        z.IsChecked = true;
                        OperationForAmbulatornCardBuf.Add(z);
                    }
                    OperationForAmbCard.Source = OperationForAmbulatornCardBuf;
                    OperationForAmbCard.View.Refresh();
                    MessageBus.Default.Call("SetOprerationForAmbCardListBecauseOFEdit", null, OperationForAmbulatornCardBuf);











                    var alList = AlergicAnevrizmPatients.GetAll.Where(s => s.id_пациента == CurrentPatient.Id).ToList();
                    foreach (var x in alList)
                    {
                        var z = new AlergicAnevrizmListDataSource(AlergicAnevrizm.Get(x.id_анамнеза));
                        DelegateCommand DelThis = new DelegateCommand(() =>
                        {
                            for (int i = 0; i < ((ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source).Count; i++)
                            {
                                if (((ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source)[i].Data.Id == z.Data.Id)
                                {
                                    ((ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source).RemoveAt(i);
                                }
                            }

                        });

                        z.DeleteCommand = DelThis;
                        z.IsChecked = true;
                        AlergicAnevrizmBuf.Add(z);
                    }
                    AlergicAnevrizmList.Source = AlergicAnevrizmBuf;
                    AlergicAnevrizmList.View.Refresh();
                    MessageBus.Default.Call("SetAlergicAnevrizmListBecauseOFEdit", null, AlergicAnevrizmBuf.ToList());
















                    var blList = BloodExchangePatients.GetAll.Where(s => s.id_пациента == CurrentPatient.Id).ToList();
                    foreach (var x in blList)
                    {
                        DelegateCommand DelThis = new DelegateCommand(() =>
                        {
                            for (int i = 0; i < ((ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source).Count; i++)
                            {
                                if (((ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)[i].Data.Id == x.id_переливания)
                                {
                                    ((ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source).RemoveAt(i);
                                }
                            }




                        });
                        var z = new BloodExchangeListDataSource(BloodExchangeRep.Get(x.id_переливания), DelThis);
                        z.Commentary = x.Комментарий;
                        z.IsChecked = true;
                        BloodExchange.Add(z);
                        BloodExchangeBuf.Add(z);
                    }
                    BloodExchangeList.Source = BloodExchange;
                    BloodExchangeList.View.Refresh();


















                    var hpList = HirurgInterupPatients.GetAll.Where(s => s.id_пациента == CurrentPatient.Id).ToList();
                    foreach (var x in hpList)
                    {
                        var z = new HirurgInterruptDataSource(HirurgInterup.Get(x.id_вмешательства));
                        DelegateCommand DelThis = new DelegateCommand(() =>
                        {
                            for (int i = 0; i < ((ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source).Count; i++)
                            {
                                if (((ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)[i].Data.Id == z.Data.Id)
                                {
                                    ((ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source).RemoveAt(i);
                                }
                            }

                        });

                        z.DeleteCommand = DelThis;
                        z.IsChecked = true;
                        HirurgInteruptBuf.Add(z);
                    }
                    HirurgInteruptList.Source = HirurgInteruptBuf;
                    HirurgInteruptList.View.Refresh();
                    MessageBus.Default.Call("SetHirurgInterruptListBecauseOFEdit", null, HirurgInteruptBuf.ToList());





                    var phList = PreparateHatePatients.GetAll.Where(s => s.id_пациент == CurrentPatient.Id).ToList();
                    foreach (var x in phList)
                    {
                        var z = new PreparateHateDataSource(PreparateHate.Get(x.id_припарат));
                        DelegateCommand DelThis = new DelegateCommand(() =>
                        {
                            for (int i = 0; i < ((ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source).Count; i++)
                            {
                                if (((ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source)[i].Data.Id == z.Data.Id)
                                {
                                    ((ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source).RemoveAt(i);
                                }
                            }

                        });

                        z.DeleteCommand = DelThis;
                        z.IsChecked = true;
                        z.Commentary = x.Комментарий;
                        PreparateHateBuf.Add(z);
                    }
                    PreparateHateList.Source = PreparateHateBuf;
                    PreparateHateList.View.Refresh();
                    MessageBus.Default.Call("SetPreparateHateListBecauseOFEdit", null, PreparateHateBuf.ToList());














                    NameOfButton = "Вернуться";
                }
                catch (Exception ex)
                {

                }
            }
            NameOfButton = "Вернуться";
            Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
        }

        public ViewModelAdditionalInfoPatient(NavigationController controller) : base(controller)
        {

            BloodExchange = new ObservableCollection<BloodExchangeListDataSource>();
            MessageBus.Default.Subscribe("SetCurrentPatientIDForAmbCard", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetOprerationForAmbCardList", SetOprerationForAmbCardList);
            MessageBus.Default.Subscribe("SetHirurgInterruptList", SetHirurgInteruptListList);
            MessageBus.Default.Subscribe("SetPreparateHateList", SetPreparateHateList);
            MessageBus.Default.Subscribe("SetAlergicAnevrizmListList", SetAlergicAnevrizmListList);
            BloodExchangeList = new CollectionViewSource();
            PreparateHateList = new CollectionViewSource();
            AlergicAnevrizmList = new CollectionViewSource();
            HirurgInteruptList = new CollectionViewSource();
            OperationForAmbCard = new CollectionViewSource();
            //BloodExchange
            ToSetOprerationForAmbCardListCommand = new DelegateCommand(
         () =>
         {

             Controller.NavigateTo<ViewModelOperationForAmbullatorCardList>();
         }
     );
            ToSetHirurgInterruptCommand = new DelegateCommand(
           () =>
           {

               Controller.NavigateTo<ViewModelHirurgInterruptList>();
           }
       );
            ToSetPreparateHateCommand = new DelegateCommand(
         () =>
         {

             Controller.NavigateTo<ViewModelPreparateHate>();
         }
     ); ToSetAlergicAnevrizmCommand = new DelegateCommand(
        () =>
        {

            Controller.NavigateTo<ViewModelAlergicAnevrizmList>();
        }
    );
            //ViewModelAlergicAnevrizmList
            ClickOnAutoComplete = new DelegateCommand<object>(
               (sender) =>
               {
                   try
                   {

                       if (sender != null)
                       {
                           var buf = (AutoCompleteBox)sender;
                           if (!buf.IsDropDownOpen)
                               buf.IsDropDownOpen = true;
                       }
                   }
                   catch
                   {

                   }

               }
           );
            base.HasNavigation = true;
            PreparateHateList.Source = PreparateHateBuf;
            AlergicAnevrizmList.Source = AlergicAnevrizmBuf;
            HirurgInteruptList.Source = HirurgInteruptBuf;
            OperationForAmbCard.Source = OperationForAmbulatornCardBuf;
            //    MessageBus.Default.Subscribe("UpdateDictionariesOfLocationForNewPatient", GetDictionary);
            BloodExchangeList.Source = BloodExchange;
           
       

            CurrentPanelViewModel = new BloodExchangePanelViewModel(this);
            OpenCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.ClearPanel();
                CurrentPanelViewModel.PanelOpened = true;
            });

            SaveCommand = new DelegateCommand(() =>
            {
                var newType = CurrentPanelViewModel.GetPanelType();
                if (newType.Data.Volume != 0f)
                {
                    newType.IsChecked = true;
                    DelegateCommand DelThis = new DelegateCommand(() =>
                    {
                        for (int i = 0; i < ((ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source).Count; i++)
                        {
                            if (((ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)[i].Data.Id == newType.Data.Id)
                            {
                                ((ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source).RemoveAt(i);
                            }
                        }




                    });
                    newType.DeleteCommand = DelThis;
                    BloodExchange.Add(newType);
                    BloodExchangeList.View.Refresh();

                    CurrentPanelViewModel.PanelOpened = false;

                    Handled = false;

                    //Data.BloodExchange.Add((newType));

                    //Data.Complete();



                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });


            CurrentPatient = new Patient();

            CurrentPatient.Birthday = DateTime.Now;



            ToDashboardCommand = new DelegateCommand(
                () =>
                {

                    SetCurrentPatientID(null, CurrentPatient.Id);
                }
            );

            ToCurrentPatientCommand = new DelegateCommand(
                () =>
                {

                    bool test = false;
                    CurrentPatient = Data.Patients.Get(CurrentPatient.Id);
                    CurrentPatient.Sugar = Sugar;
                    if (IsPositiveGroupTypeID == 0)
                    {
                        CurrentPatient.IsPositiveGroupType = true;
                    }
                    else
                    {
                        CurrentPatient.IsPositiveGroupType = false;
                    }
                    CurrentPatient.BloodGroup = (BloodGroupID + 1).ToString();

                    if (BloodExchangeList.Source != null)
                    {
                        test = false;
                        foreach (var dgOp in Data.BloodExchangePatients.GetAll)
                        {

                            if (dgOp.id_пациента == CurrentPatient.Id)
                            {
                                test = true;
                                foreach (var diag in (ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_переливания == diag.Data.Id)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                            }
                            if (test)
                            {
                                Data.BloodExchangePatients.Remove(dgOp);
                                Data.Complete();
                            }
                        }

                        //   Data.Complete();
                        test = false;

                        foreach (var rec in (ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)
                        {


                            if (rec.IsChecked.Value)
                            {
                                test = true;
                                foreach (var rcOp in Data.BloodExchangePatients.GetAll)
                                {
                                    if (rcOp.id_переливания == rec.Data.Id && rcOp.id_пациента == CurrentPatient.Id)
                                    {
                                        var ToChange = Data.BloodExchange.Get(rcOp.id_переливания);

                                        if (ToChange.Date != rec.Data.Date || ToChange.Volume != rec.Data.Volume)
                                        {
                                            var buff = new BloodExchange();
                                            buff.Volume = rec.Data.Volume;
                                            buff.Date = rec.Data.Date;

                                            Data.BloodExchange.Add(buff);
                                            Data.Complete();
                                            Data.BloodExchangePatients.Remove(rcOp);
                                            Data.Complete();
                                            var newRec = new BloodExchangePatients();
                                            newRec.id_пациента = CurrentPatient.Id;
                                            newRec.id_переливания = buff.Id;
                                            newRec.Комментарий = rec.Commentary;
                                            Data.BloodExchangePatients.Add(newRec);
                                            Data.Complete();
                                        }
                                        else
                                        {

                                            rcOp.Комментарий = rec.Commentary;
                                        }
                                        Data.Complete();
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newRec = new BloodExchangePatients();
                                    newRec.id_пациента = CurrentPatient.Id;
                                    newRec.id_переливания = rec.Data.Id;
                                    newRec.Комментарий = rec.Commentary;
                                    Data.BloodExchangePatients.Add(newRec);
                                    Data.Complete();
                                }
                            }
                        }
                        //foreach (var x in (ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)
                        //{
                        //    BloodExchangePatients buf = new BloodExchangePatients();
                        //    buf.id_пациента = CurrentPatient.Id;
                        //    buf.id_переливания = x.Data.Id;
                        //    buf.Комментарий = x.Commentary;
                        //    Data.BloodExchangePatients.Add(buf);

                        //}
                    }
                    if (AlergicAnevrizmList.Source != null)
                    {
                        test = false;
                        foreach (var dgOp in Data.AlergicAnevrizmPatients.GetAll)
                        {

                            if (dgOp.id_пациента == CurrentPatient.Id)
                            {
                                test = true;
                                foreach (var diag in (ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_анамнеза == diag.Data.Id)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                            }
                            if (test)
                            {
                                Data.AlergicAnevrizmPatients.Remove(dgOp);
                                Data.Complete();
                            }
                        }

                        //   Data.Complete();
                        test = false;

                        foreach (var rec in (ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source)
                        {
                            if (rec.IsChecked.Value)
                            {
                                test = true;
                                foreach (var rcOp in Data.AlergicAnevrizmPatients.GetAll)
                                {
                                    if (rcOp.id_анамнеза == rec.Data.Id && rcOp.id_пациента == CurrentPatient.Id)
                                    {
                                        var ToChange = Data.AlergicAnevrizm.Get(rcOp.id_анамнеза);

                                        if (ToChange.Str != rec.Data.Str)
                                        {
                                            var buff = new AlergicAnevrizm();
                                            buff.Str = rec.Data.Str;


                                            Data.AlergicAnevrizm.Add(buff);
                                            Data.Complete();
                                            Data.AlergicAnevrizmPatients.Remove(rcOp);
                                            Data.Complete();
                                            var newRec = new AlergicAnevrizmPatients();
                                            newRec.id_пациента = CurrentPatient.Id;
                                            newRec.id_анамнеза = buff.Id;

                                            Data.AlergicAnevrizmPatients.Add(newRec);
                                            Data.Complete();
                                        }

                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {


                                    var newRec = new AlergicAnevrizmPatients();
                                    newRec.id_пациента = CurrentPatient.Id;
                                    var ToChange = Data.AlergicAnevrizm.Get(rec.Data.Id);
                                    if (ToChange.Str != rec.Data.Str)
                                    {
                                        var buff = new AlergicAnevrizm();
                                        buff.Str = rec.Data.Str;


                                        Data.AlergicAnevrizm.Add(buff);
                                        Data.Complete();
                                        newRec.id_анамнеза = buff.Id;
                                        Data.AlergicAnevrizmPatients.Add(newRec);
                                        Data.Complete();

                                    }
                                    else
                                    {


                                        newRec.id_анамнеза = rec.Data.Id;

                                        Data.AlergicAnevrizmPatients.Add(newRec);
                                        Data.Complete();
                                    }
                                 
                                    
                                }
                            }
                        }

                        //foreach (var x in (ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source)
                        //{
                        //    AlergicAnevrizmPatients buf = new AlergicAnevrizmPatients();
                        //    buf.id_пациента = CurrentPatient.Id;
                        //    buf.id_анамнеза = x.Data.Id;
                        //    Data.AlergicAnevrizmPatients.Add(buf);

                        //}
                    }
                    if (PreparateHateList.Source != null)
                    {

                        test = false;
                        foreach (var dgOp in Data.PreparateHatePatients.GetAll)
                        {

                            if (dgOp.id_пациент == CurrentPatient.Id)
                            {
                                test = true;
                                foreach (var diag in (ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_припарат == diag.Data.Id)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                            }
                            if (test)
                            {
                                Data.PreparateHatePatients.Remove(dgOp);
                                Data.Complete();
                            }
                        }

                        //   Data.Complete();
                        test = false;

                        foreach (var rec in (ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source)
                        {
                            if (rec.IsChecked.Value)
                            {
                                test = true;
                                foreach (var rcOp in Data.PreparateHatePatients.GetAll)
                                {
                                    if (rcOp.id_припарат == rec.Data.Id && rcOp.id_пациент == CurrentPatient.Id)
                                    {
                                        var ToChange = Data.PreparateHate.Get(rcOp.id_припарат);

                                        if (ToChange.Str != rec.Data.Str)
                                        {
                                            var buff = new PreparateHate();
                                            buff.Str = rec.Data.Str;


                                            Data.PreparateHate.Add(buff);
                                            Data.Complete();
                                            Data.PreparateHatePatients.Remove(rcOp);
                                            Data.Complete();
                                            var newRec = new PreparateHatePatients();
                                            newRec.id_пациент = CurrentPatient.Id;
                                            newRec.id_припарат = buff.Id;
                                            newRec.Комментарий = rec.Commentary;
                                            Data.PreparateHatePatients.Add(newRec);
                                            Data.Complete();
                                        }
                                        else
                                        {

                                            rcOp.Комментарий = rec.Commentary;
                                        }

                                        Data.Complete();
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newRec = new PreparateHatePatients();
                                    newRec.id_пациент = CurrentPatient.Id;
                                    newRec.Комментарий = rec.Commentary;
                                    var ToChange = Data.PreparateHate.Get(rec.Data.Id);
                                    if (ToChange.Str != rec.Data.Str)
                                    {
                                        var buff = new PreparateHate();
                                        buff.Str = rec.Data.Str;


                                        Data.PreparateHate.Add(buff);
                                        Data.Complete();
                                        newRec.id_припарат = buff.Id;
                                        Data.PreparateHatePatients.Add(newRec);
                                        Data.Complete();

                                    }
                                    else
                                    {



                                        newRec.id_припарат = rec.Data.Id;

                                        Data.PreparateHatePatients.Add(newRec);
                                        Data.Complete();
                                    }

                                 


                                
                                }
                            }
                        }


                        //foreach (var x in (ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source)
                        //{
                        //    PreparateHatePatients buf = new PreparateHatePatients();
                        //    buf.id_пациента = CurrentPatient.Id;
                        //    buf.id_припарат = x.Data.Id;
                        //    buf.Комментарий = x.Commentary;
                        //    Data.PreparateHatePatients.Add(buf);


                    }
                    if (HirurgInteruptList.Source != null)
                    {
                        test = false;
                        foreach (var dgOp in Data.HirurgInterupPatients.GetAll)
                        {

                            if (dgOp.id_пациента == CurrentPatient.Id)
                            {
                                test = true;
                                foreach (var diag in (ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_вмешательства == diag.Data.Id)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                            }
                            if (test)
                            {
                                Data.HirurgInterupPatients.Remove(dgOp);
                                Data.Complete();
                            }
                        }

                        //   Data.Complete();
                        test = false;

                        foreach (var rec in (ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)
                        {
                            if (rec.IsChecked.Value)
                            {
                                test = true;
                                foreach (var rcOp in Data.HirurgInterupPatients.GetAll)
                                {
                                    if (rcOp.id_вмешательства == rec.Data.Id && rcOp.id_пациента == CurrentPatient.Id)
                                    {
                                        var ToChange = Data.HirurgInterup.Get(rcOp.id_вмешательства);

                                        if (ToChange.Str != rec.Data.Str)
                                        {
                                            var buff = new HirurgInterupt();
                                            buff.Str = rec.Data.Str;


                                            Data.HirurgInterup.Add(buff);
                                            Data.Complete();
                                            Data.HirurgInterupPatients.Remove(rcOp);
                                            Data.Complete();
                                            var newRec = new HirurgInteruptPatients();
                                            newRec.id_пациента = CurrentPatient.Id;
                                            newRec.id_вмешательства = buff.Id;

                                            Data.HirurgInterupPatients.Add(newRec);
                                            Data.Complete();
                                        }
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {

                                    var newRec = new HirurgInteruptPatients();
                                    newRec.id_пациента = CurrentPatient.Id;
                                    var ToChange = Data.HirurgInterup.Get(rec.Data.Id);
                                    if (ToChange.Str != rec.Data.Str)
                                    {
                                        var buff = new HirurgInterupt();
                                        buff.Str = rec.Data.Str;


                                        Data.HirurgInterup.Add(buff);
                                        Data.Complete();
                                        newRec.id_вмешательства = buff.Id;
                                        Data.HirurgInterupPatients.Add(newRec);
                                        Data.Complete();

                                    }
                                    else
                                    {



                                        newRec.id_вмешательства = rec.Data.Id;
                                        Data.HirurgInterupPatients.Add(newRec);
                                        Data.Complete();
                                    }
                                  
                                 
                                 
                                }
                            }
                        }
                        //foreach (var x in (ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)
                        //{
                        //    HirurgInteruptPatients buf = new HirurgInteruptPatients();
                        //    buf.id_пациента = CurrentPatient.Id;
                        //    buf.id_вмешательства = x.Data.Id;

                        //    Data.HirurgInterupPatients.Add(buf);

                        //}
                    }
                    if (OperationForAmbCard.Source != null)
                    {
                        test = false;
                        foreach (var dgOp in Data.OperationForAmbulatornCardPatients.GetAll)
                        {

                            if (dgOp.id_пациента == CurrentPatient.Id)
                            {
                                test = true;
                                foreach (var diag in (ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)
                                {
                                    if (diag.IsChecked.Value && dgOp.id_операции == diag.Data.Id)
                                    {
                                        test = false;
                                        break;
                                    }
                                }
                            }
                            if (test)
                            {
                                Data.OperationForAmbulatornCardPatients.Remove(dgOp);
                                Data.Complete();
                            }
                        }

                        //   Data.Complete();
                        test = false;

                        foreach (var rec in (ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)
                        {
                            if (rec.IsChecked.Value)
                            {
                                test = true;
                                foreach (var rcOp in Data.OperationForAmbulatornCardPatients.GetAll)
                                {
                                    if (rcOp.id_операции == rec.Data.Id && rcOp.id_пациента == CurrentPatient.Id)
                                    {
                                        var ToChange = Data.OperationForAmbulatornCard.Get(rcOp.id_операции);

                                        if (ToChange.Str != rec.Data.Str)
                                        {
                                            var buff = new OperationForAmbulatornCard();
                                            buff.Str = rec.Data.Str;


                                            Data.OperationForAmbulatornCard.Add(buff);
                                            Data.Complete();
                                            Data.OperationForAmbulatornCardPatients.Remove(rcOp);
                                            Data.Complete();
                                            var newRec = new OperationForAmbulatornCardPatients();
                                            newRec.id_пациента = CurrentPatient.Id;
                                            newRec.id_операции = buff.Id;

                                            Data.OperationForAmbulatornCardPatients.Add(newRec);
                                            Data.Complete();
                                        }
                                        test = false;
                                        break;
                                    }
                                }
                                if (test)
                                {
                                    var newRec = new OperationForAmbulatornCardPatients();
                                    newRec.id_пациента = CurrentPatient.Id;
                                    var ToChange = Data.OperationForAmbulatornCard.Get(rec.Data.Id);
                                    if(ToChange.Str != rec.Data.Str)
                                    {
                                        var buff = new OperationForAmbulatornCard();
                                        buff.Str = rec.Data.Str;


                                        Data.OperationForAmbulatornCard.Add(buff);
                                        Data.Complete();
                                        newRec.id_операции = buff.Id;
                                        Data.OperationForAmbulatornCardPatients.Add(newRec);
                                        Data.Complete();

                                    }
                                    else { 

                                 
                                  
                                    newRec.id_операции = rec.Data.Id;
                                    Data.OperationForAmbulatornCardPatients.Add(newRec);
                                    Data.Complete();
                                    }
                                }
                            }
                        }



                        //foreach (var x in (ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)
                        //{
                        //    OperationForAmbulatornCardPatients buf = new OperationForAmbulatornCardPatients();
                        //    buf.id_пациента = CurrentPatient.Id;
                        //    buf.id_операции = x.Data.Id;

                        //    Data.OperationForAmbulatornCardPatients.Add(buf);

                        //}
                    }

                    //

                    //test = false;
                    //if (RecomendationsList != null)
                    //{

                    //    foreach (var dgOp in Data.RecomendationObs.GetAll)
                    //    {

                    //        if (dgOp.id_обследования == examnTotal.Id)
                    //        {
                    //            test = true;
                    //            foreach (var diag in RecomendationsList)
                    //            {
                    //                if (diag.IsChecked.Value && dgOp.id_рекомендации == diag.Data.Id)
                    //                {
                    //                    test = false;
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //        if (test)
                    //        {
                    //            Data.RecomendationObs.Remove(dgOp);
                    //            Data.Complete();
                    //        }
                    //    }

                    //    //   Data.Complete();
                    //    test = false;

                    //    foreach (var rec in RecomendationsList)
                    //    {
                    //        if (rec.IsChecked.Value)
                    //        {
                    //            test = true;
                    //            foreach (var rcOp in Data.RecomendationObs.GetAll)
                    //            {
                    //                if (rcOp.id_рекомендации == rec.Data.Id && rcOp.id_обследования == examnTotal.Id.Value)
                    //                {
                    //                    test = false;
                    //                    break;
                    //                }
                    //            }
                    //            if (test)
                    //            {
                    //                var newRec = new RecomendationObs();
                    //                newRec.id_рекомендации = rec.Data.Id;
                    //                newRec.id_обследования = examnTotal.Id.Value;
                    //                Data.RecomendationObs.Add(newRec);
                    //                Data.Complete();
                    //            }
                    //        }
                    //    }
                    //}

                    //

                    Data.Complete();
                    MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                    Controller.NavigateTo<ViewModelCurrentPatient>();




                }
            );
            NameOfButton = "Вернуться";
        }
    }
}