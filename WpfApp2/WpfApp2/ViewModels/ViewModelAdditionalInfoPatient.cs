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
using System.IO;
using Xceed.Words.NET;
using System.Diagnostics;

namespace WpfApp2.ViewModels
{
    public class BloodExchangeListDataSource : INotifyPropertyChanged
    {
        private IEnumerable<String> _districtList;
        public IEnumerable<String> BloodExchangeCommentList { get { return _districtList; } set { _districtList = value; OnPropertyChanged(); } }

        //SugarDiabetComment
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DelegateCommand DeleteCommand { set; get; }

        public BloodExchange Data { get; set; }
        public string Commentary { set { _str = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); OnPropertyChanged(); } get { return _str; } }

        private string _str;

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


        private bool _isAlergiActive;
        public bool IsAlergiActive
        {
            get
            {
                return _isAlergiActive;
            }
            set
            {
                _isAlergiActive = value;
                if (_isAlergiActive)
                {
                    IsAlergiVisible = Visibility.Hidden;
                    NameOfButton = "Сохранить";
                }
                else
                {
                    IsAlergiVisible = Visibility.Visible;
                }

                OnPropertyChanged();
            }
        }


        private Visibility _isAlergiVisible;
        public Visibility IsAlergiVisible
        {
            get
            {
                return _isAlergiVisible;
            }
            set { _isAlergiVisible = value; OnPropertyChanged(); }
        }

        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Bindings
        #region DelegateCommands
        public DelegateCommand ToDashboardCommand { get; protected set; }
        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        public DelegateCommand Changed { get; protected set; }
        #endregion
        public DelegateCommand RevertCommand { set; get; }
        public DelegateCommand<object> LostFocus { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }

        public DelegateCommand SaveCommand { set; get; }
        public DelegateCommand ToPathologyListCommand { get; private set; }

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
        public IEnumerable<String> BloodExchangeCommentList { get { return _districtList; } set { _districtList = value; OnPropertyChanged(); } }
        private IEnumerable<String> _districtList1;
        public IEnumerable<String> SugarDiabetCommentList { get { return _districtList1; } set { _districtList1 = value; OnPropertyChanged(); } }

        private IEnumerable<String> _townsList;
        public IEnumerable<String> PreparateHateCommentList { get { return _townsList; } set { _townsList = value; OnPropertyChanged(); } }

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


        public CollectionViewSource BloodExchangeList { get { return _bloodExchangeList; } set { _bloodExchangeList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public CollectionViewSource PreparateHateList { get { return _preparateHateList; } set { _preparateHateList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public CollectionViewSource AlergicAnevrizmList { get { return _alergicAnevrizmList; } set { _alergicAnevrizmList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        public CollectionViewSource HirurgInteruptList { get { return _hirurgInteruptList; } set { _hirurgInteruptList = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }
        //public DelegateCommand ToSetOprerationForAmbCardListCommand { get; set; }
        public CollectionViewSource OperationForAmbCard { get { return _operationForAmbCard; } set { _operationForAmbCard = value; OnPropertyChanged(); NameOfButton = "Сохранить"; } }

        public DelegateCommand CreateWordDocumentCommand { get; private set; }
        public DelegateCommand ToSetHirurgInterruptCommand { get; private set; }
        public DelegateCommand ToSetPreparateHateCommand { get; }
        public DelegateCommand ToSetAlergicAnevrizmCommand { get; private set; }

        //public ObservableCollection<string> OprTypes { get { return _oprTypes; } set { _oprTypes = value; OnPropertyChanged(); } }
        public ObservableCollection<BloodExchangeListDataSource> BloodExchange { get { return _bloodExchange; } set { _bloodExchange = value; NameOfButton = "Сохранить"; OnPropertyChanged(); } }
        ObservableCollection<OperationForAmbullatorCardDataSource> OperationForAmbulatornCardBuf { get { return _operationForAmbulatornCardBuf; } set { _operationForAmbulatornCardBuf = value; NameOfButton = "Сохранить"; OnPropertyChanged(); } }

        ObservableCollection<AlergicAnevrizmListDataSource> AlergicAnevrizmBuf { get { return _alergicAnevrizmTypes; } set { _alergicAnevrizmTypes = value; NameOfButton = "Сохранить"; OnPropertyChanged(); } }

        ObservableCollection<HirurgInterruptDataSource> HirurgInteruptBuf { get { return _hirurgIntruptTypes; } set { _hirurgIntruptTypes = value; NameOfButton = "Сохранить"; OnPropertyChanged(); } }

        ObservableCollection<PreparateHateDataSource> PreparateHateBuf { get { return _preparateHateTypes; } set { _preparateHateTypes = value; NameOfButton = "Сохранить"; OnPropertyChanged(); } }

        private void SetDNameToSave(object sender, object data)
        {
            NameOfButton = "Сохранить";
        }

        private string _bloodGroup;

        private string _sugar;
        private string _initials;
        public string Initials
        {
            get { return _initials; }
            set
            {
                _initials = value;

                OnPropertyChanged();
            }
        }
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
                NameOfButton = "Сохранить";
                OnPropertyChanged();
            }
        }

        public int IsPositiveGroupTypeID
        {
            get { return _isPositiveGroupTypeID; }
            set
            {
                _isPositiveGroupTypeID = value;
                NameOfButton = "Сохранить";
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
                    MessageBus.Default.Call("SetPreparateHateListBecauseOFEdit", null, PreparateHateBuf.ToList());
                    MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
                });

                x.DeleteCommand = DelThis;
            }
            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
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
                    MessageBus.Default.Call("SetAlergicAnevrizmListBecauseOFEdit", null, AlergicAnevrizmBuf.ToList());
                    MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
                });

                x.DeleteCommand = DelThis;
            }
            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
            AlergicAnevrizmList.Source = AlergicAnevrizmBuf;
            AlergicAnevrizmList.View.Refresh();
        }
        private void SetHirurgInteruptListList(object sender, object data)
        {
            HirurgInteruptBuf = (ObservableCollection<HirurgInterruptDataSource>)data;
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
                    MessageBus.Default.Call("SetHirurgInterruptListBecauseOFEdit", null, HirurgInteruptBuf.ToList());
                    MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
                });

                x.DeleteCommand = DelThis;
            }
            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
            HirurgInteruptList.Source = HirurgInteruptBuf;
            HirurgInteruptList.View.Refresh();
        }
        //private void SetOprerationForAmbCardList(object sender, object data)
        //{
        //    OperationForAmbulatornCardBuf = (ObservableCollection<OperationForAmbullatorCardDataSource>)data;
        //    foreach (var x in OperationForAmbulatornCardBuf)
        //    {
        //        DelegateCommand DelThis = new DelegateCommand(() =>
        //        {
        //            for (int i = 0; i < ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).Count; i++)
        //            {
        //                if (((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)[i].Data.Id == x.Data.Id)
        //                {
        //                    ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).RemoveAt(i);
        //                }
        //            }
        //            MessageBus.Default.Call("SetOprerationForAmbCardListBecauseOFEdit", null, OperationForAmbulatornCardBuf);

        //            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
        //        });

        //        x.DeleteCommand = DelThis;
        //    }
        //    MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
        //    OperationForAmbCard.Source = OperationForAmbulatornCardBuf;
        //    OperationForAmbCard.View.Refresh();
        //}




        public DelegateCommand<object> ClickOnAutoComplete { get; set; }

        List<BloodExchangeListDataSource> BloodExchangeBuf;
        private void SetCurrentPatientID(object sender, object data)
        {

            List<String> buff1 = new List<string>();
            foreach (var x in Data.BloodExchangeComment.GetAll)
                buff1.Add(x.Str);

            List<String> buff2 = new List<string>();
            foreach (var x in Data.PreparateHateComment.GetAll)
                buff2.Add(x.Str);



            List<String> buff3 = new List<string>();
            foreach (var x in Data.SugarDiabetComment.GetAll)
                buff3.Add(x.Str);

            IsAlergiActive = false;

            SugarDiabetCommentList = buff3;

            PreparateHateCommentList = buff2;
            // BloodExchangeComment
            BloodExchangeCommentList = buff1; //PreparateHateComment
            MessageBus.Default.Call("SetClearOprerationForAmbCardList", null, null);
            MessageBus.Default.Call("SetClearPreparateHateList", null, null);
            MessageBus.Default.Call("SetClearHirurgInterruptList", null, null);
            MessageBus.Default.Call("SetClearAlergicAnevrizmList", null, null);
            Sugar = "";

            IsPositiveGroupTypeID = 0;
            BloodGroupID = 0;

            BloodExchange = new ObservableCollection<BloodExchangeListDataSource>();
            //OperationForAmbulatornCardBuf = new ObservableCollection<OperationForAmbullatorCardDataSource>();
            AlergicAnevrizmBuf = new ObservableCollection<AlergicAnevrizmListDataSource>();
            HirurgInteruptBuf = new ObservableCollection<HirurgInterruptDataSource>();
            PreparateHateBuf = new ObservableCollection<PreparateHateDataSource>();
            BloodExchangeBuf = new List<BloodExchangeListDataSource>();
            BloodExchangeList = new CollectionViewSource();
            PreparateHateList = new CollectionViewSource();
            AlergicAnevrizmList = new CollectionViewSource();
            HirurgInteruptList = new CollectionViewSource();
            //OperationForAmbCard = new CollectionViewSource();

            using (var context = new MySqlContext())
            {
                PatientsRepository PatientsRep = new PatientsRepository(context);

                //OperationForAmbulatornCardPatientsRepository OperationForAmbulatornCardPatients = new OperationForAmbulatornCardPatientsRepository(context);
                //OperationForAmbulatornCardRepository OperationForAmbulatornCard = new OperationForAmbulatornCardRepository(context);
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
                    hirurgOverviewId = CurrentPatient.Амбулаторная_карта_документ_id;
                    Initials = "Пациент: " + CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ". ";

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
                    //var opList = OperationForAmbulatornCardPatients.GetAll.Where(s => s.id_пациента == CurrentPatient.Id).ToList();
                    //foreach (var x in opList)
                    //{
                    //    var z = new OperationForAmbullatorCardDataSource(OperationForAmbulatornCard.Get(x.id_операции));
                    //    DelegateCommand DelThis = new DelegateCommand(() =>
                    //    {
                    //        for (int i = 0; i < ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).Count; i++)
                    //        {
                    //            if (((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)[i].Data.Id == z.Data.Id)
                    //            {
                    //                ((ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source).RemoveAt(i);
                    //            }
                    //        }
                    //        MessageBus.Default.Call("SetOprerationForAmbCardListBecauseOFEdit", null, OperationForAmbulatornCardBuf);
                    //        MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
                    //    });



                    //    z.DeleteCommand = DelThis;
                    //    z.IsChecked = true;
                    //    OperationForAmbulatornCardBuf.Add(z);
                    //}
                    //OperationForAmbCard.Source = OperationForAmbulatornCardBuf;
                    //OperationForAmbCard.View.Refresh();
                    //MessageBus.Default.Call("SetOprerationForAmbCardListBecauseOFEdit", null, OperationForAmbulatornCardBuf);











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
                            MessageBus.Default.Call("SetAlergicAnevrizmListBecauseOFEdit", null, AlergicAnevrizmBuf.ToList());
                            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
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

                            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);


                        });
                        var z = new BloodExchangeListDataSource(BloodExchangeRep.Get(x.id_переливания), DelThis);
                        z.BloodExchangeCommentList = BloodExchangeCommentList;
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
                            MessageBus.Default.Call("SetHirurgInterruptListBecauseOFEdit", null, HirurgInteruptBuf.ToList());
                            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
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
                            MessageBus.Default.Call("SetPreparateHateListBecauseOFEdit", null, PreparateHateBuf.ToList());
                            MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null);
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
            //     Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
            NameOfButton = "Вернуться";
        }

        public ViewModelAdditionalInfoPatient(NavigationController controller) : base(controller)
        {

            BloodExchange = new ObservableCollection<BloodExchangeListDataSource>();
            MessageBus.Default.Subscribe("SetIdOfAdditionalInfoDoc", SetIdOfOverview);
            MessageBus.Default.Subscribe("SetnameOfButtonForAmbCard", SetDNameToSave);
            MessageBus.Default.Subscribe("SetCurrentPatientIDForAmbCard", SetCurrentPatientID);
            //MessageBus.Default.Subscribe("SetOprerationForAmbCardList", SetOprerationForAmbCardList);
            MessageBus.Default.Subscribe("SetHirurgInterruptList", SetHirurgInteruptListList);
            MessageBus.Default.Subscribe("SetPreparateHateList", SetPreparateHateList);
            MessageBus.Default.Subscribe("SetAlergicAnevrizmListList", SetAlergicAnevrizmListList);
            MessageBus.Default.Subscribe("CreateDocumentAdditionalInfo", CreateWordDocument);
            BloodExchangeList = new CollectionViewSource();
            PreparateHateList = new CollectionViewSource();
            AlergicAnevrizmList = new CollectionViewSource();
            HirurgInteruptList = new CollectionViewSource();
            OperationForAmbCard = new CollectionViewSource();
            CreateWordDocumentCommand = new DelegateCommand(
           () =>
           {
               if (TestHirurgInteruptDates())

               {

                   MessageBus.Default.Call("SetCurrentPatientIDRealyThisTimeForAdditionalInfo", null, CurrentPatient.Id);
                   MessageBus.Default.Call("GetAdditionalInfoDocForHirurgOverview", _fileNameOnly, hirurgOverviewId);
                   Controller.NavigateTo<ViewModelCreateAdditionalInfoDocuments>();
               }
               else { MessageBox.Show("Не все поля заполнены"); }
               //CreateWordDocument(null,null);
           }
       );
            //BloodExchange
            //       ToSetOprerationForAmbCardListCommand = new DelegateCommand(
            //    () =>
            //    {

            //        Controller.NavigateTo<ViewModelOperationForAmbullatorCardList>();
            //    }
            //);
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
                    if (newType.Data.Date == null)
                    {
                        newType.Data.Date = DateTime.Now;
                    }
                    newType.DeleteCommand = DelThis;
                    BloodExchange.Add(newType);
                    BloodExchangeList.View.Refresh();
                    NameOfButton = "Сохранить";
                    CurrentPanelViewModel.PanelOpened = false;

                    Handled = false;

                    //Data.BloodExchange.Add((newType));

                    //Data.Complete();



                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            ToPathologyListCommand = new DelegateCommand(
               () =>
               {
                   MessageBus.Default.Call("GetPatientForPatology", this, CurrentPatient.Id);

                   Controller.NavigateTo<ViewModelPathologyList>();
               }
           );
            RevertCommand = new DelegateCommand(() =>
            {
                CurrentPanelViewModel.PanelOpened = false;
                Handled = false;
            });

            LostFocus = new DelegateCommand<object>(
       (sender) =>
       {

           if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
           {
               ((TextBox)sender).Text = "0";
               CurrentPanelViewModel.ShortText = 0;
           }


       }
   ); ClickOnWeight = new DelegateCommand<object>(
      (sender) =>
      {

          if (((TextBox)sender).Text == "0")
              ((TextBox)sender).Text = "";



      }
  );
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

                    if (TestHirurgInteruptDates())
                    {

                        SaveAdditionalInfo();
                        Controller.NavigateTo<ViewModelCurrentPatient>();



                    }
                    else
                    {
                        MessageBox.Show("Дата введена неправильно");
                    }
                }
            );
            NameOfButton = "Вернуться";
        }
        void SaveAdditionalInfo()
        {




            bool test = false;


            CurrentPatient = Data.Patients.Get(CurrentPatient.Id);

            // CurrentPatient = PatientsRep.Get((int)data);
            CurrentPatient.Амбулаторная_карта_документ_id = hirurgOverviewId;// = CurrentPatient.Амбулаторная_карта_документ_id;
            CurrentPatient.Sugar = Sugar;
            bool xtestx = false;
            foreach (var x in SugarDiabetCommentList)
            {
                if (x == Sugar)
                {
                    xtestx = true;
                    break;
                }
            }
            if (!xtestx)
            {
                if (!string.IsNullOrWhiteSpace(Sugar))
                {
                    var bff = new SugarDiabetComment();
                    bff.Str = Sugar;
                    Data.SugarDiabetComment.Add(bff);
                    Data.Complete();
                }
            }


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

                                    bool xtest = false;
                                    foreach (var x in BloodExchangeCommentList)
                                    {
                                        if (x == rec.Commentary)
                                        {
                                            xtest = true;
                                            break;
                                        }
                                    }
                                    if (!xtest)
                                    {
                                        if (!string.IsNullOrWhiteSpace(rec.Commentary))
                                        {
                                            var bff = new BloodExchangeComment();
                                            bff.Str = rec.Commentary;
                                            Data.BloodExchangeComment.Add(bff);
                                            Data.Complete();
                                        }
                                    }

                                    Data.BloodExchangePatients.Add(newRec);
                                    Data.Complete();
                                }
                                else
                                {
                                    bool xtest = false;
                                    foreach (var x in BloodExchangeCommentList)
                                    {
                                        if (x == rec.Commentary)
                                        {
                                            xtest = true;
                                            break;
                                        }
                                    }
                                    if (!xtest)
                                    {
                                        if (!string.IsNullOrWhiteSpace(rec.Commentary))
                                        {
                                            var bff = new BloodExchangeComment();
                                            bff.Str = rec.Commentary;
                                            Data.BloodExchangeComment.Add(bff);
                                            Data.Complete();
                                        }
                                    }
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
            if (IsAlergiActive)
            {
                AlergicAnevrizmList.Source = new ObservableCollection<AlergicAnevrizmListDataSource>();
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

                                    bool xtest = false;
                                    foreach (var x in PreparateHateCommentList)
                                    {
                                        if (x == rec.Commentary)
                                        {
                                            xtest = true;
                                            break;
                                        }
                                    }
                                    if (!xtest)
                                    {
                                        if (!string.IsNullOrWhiteSpace(rec.Commentary))
                                        {
                                            var bff = new PreparateHateComment();
                                            bff.Str = rec.Commentary;
                                            Data.PreparateHateComment.Add(bff);
                                            Data.Complete();
                                        }
                                    }
                                }
                                else
                                {

                                    rcOp.Комментарий = rec.Commentary;
                                    bool xtest = false;
                                    foreach (var x in PreparateHateCommentList)
                                    {
                                        if (x == rec.Commentary)
                                        {
                                            xtest = true;
                                            break;
                                        }
                                    }
                                    if (!xtest)
                                    {
                                        if (!string.IsNullOrWhiteSpace(rec.Commentary))
                                        {
                                            var bff = new PreparateHateComment();
                                            bff.Str = rec.Commentary;
                                            Data.PreparateHateComment.Add(bff);
                                            Data.Complete();
                                        }
                                    }
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

                                if (ToChange.Str != rec.Data.Str || ToChange.Date != rec.Data.Date)
                                {
                                    var buff = new HirurgInterupt();
                                    buff.Str = rec.Data.Str;
                                    buff.Date = rec.Data.Date;

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
                                buff.Date = rec.Data.Date;

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
            //if (OperationForAmbCard.Source != null)
            //{
            //    test = false;
            //    foreach (var dgOp in Data.OperationForAmbulatornCardPatients.GetAll)
            //    {

            //        if (dgOp.id_пациента == CurrentPatient.Id)
            //        {
            //            test = true;
            //            foreach (var diag in (ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)
            //            {
            //                if (diag.IsChecked.Value && dgOp.id_операции == diag.Data.Id)
            //                {
            //                    test = false;
            //                    break;
            //                }
            //            }
            //        }
            //        if (test)
            //        {
            //            Data.OperationForAmbulatornCardPatients.Remove(dgOp);
            //            Data.Complete();
            //        }
            //    }

            //    //   Data.Complete();
            //    test = false;

            //    foreach (var rec in (ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)
            //    {
            //        if (rec.IsChecked.Value)
            //        {
            //            test = true;
            //            foreach (var rcOp in Data.OperationForAmbulatornCardPatients.GetAll)
            //            {
            //                if (rcOp.id_операции == rec.Data.Id && rcOp.id_пациента == CurrentPatient.Id)
            //                {
            //                    var ToChange = Data.OperationForAmbulatornCard.Get(rcOp.id_операции);

            //                    if (ToChange.Str != rec.Data.Str)
            //                    {
            //                        var buff = new OperationForAmbulatornCard();
            //                        buff.Str = rec.Data.Str;


            //                        Data.OperationForAmbulatornCard.Add(buff);
            //                        Data.Complete();
            //                        Data.OperationForAmbulatornCardPatients.Remove(rcOp);
            //                        Data.Complete();
            //                        var newRec = new OperationForAmbulatornCardPatients();
            //                        newRec.id_пациента = CurrentPatient.Id;
            //                        newRec.id_операции = buff.Id;

            //                        Data.OperationForAmbulatornCardPatients.Add(newRec);
            //                        Data.Complete();
            //                    }
            //                    test = false;
            //                    break;
            //                }
            //            }
            //            if (test)
            //            {
            //                var newRec = new OperationForAmbulatornCardPatients();
            //                newRec.id_пациента = CurrentPatient.Id;
            //                var ToChange = Data.OperationForAmbulatornCard.Get(rec.Data.Id);
            //                if (ToChange.Str != rec.Data.Str)
            //                {
            //                    var buff = new OperationForAmbulatornCard();
            //                    buff.Str = rec.Data.Str;


            //                    Data.OperationForAmbulatornCard.Add(buff);
            //                    Data.Complete();
            //                    newRec.id_операции = buff.Id;
            //                    Data.OperationForAmbulatornCardPatients.Add(newRec);
            //                    Data.Complete();

            //                }
            //                else
            //                {



            //                    newRec.id_операции = rec.Data.Id;
            //                    Data.OperationForAmbulatornCardPatients.Add(newRec);
            //                    Data.Complete();
            //                }
            //            }
            //        }
            //    }



            //foreach (var x in (ObservableCollection<OperationForAmbullatorCardDataSource>)OperationForAmbCard.Source)
            //{
            //    OperationForAmbulatornCardPatients buf = new OperationForAmbulatornCardPatients();
            //    buf.id_пациента = CurrentPatient.Id;
            //    buf.id_операции = x.Data.Id;

            //    Data.OperationForAmbulatornCardPatients.Add(buf);

            //}
            //}

            //
            Data.Complete();
            MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);

        }
        private bool TestHirurgInteruptDates()
        {
            bool test = true;
            if (HirurgInteruptList.Source != null)
            {
                foreach (var x in (ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)
                {
                    if (x.Data.Date == null || x.Data.Date > DateTime.Now)
                    {
                        test = false;
                    }
                }
                return test;
            }
            if (BloodExchangeList.Source != null)
            {
                foreach (var x in (ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)
                {
                    if (x.Data.Date != null && x.Data.Date > DateTime.Now)
                    {
                        test = false;
                    }
                }
                return test;
            }
            return true;
        }
        int? hirurgOverviewId;

        #region AllForCreateDocFile

        private string _fileNameOnly;

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }
        private void CreateWordDocument(object sender, object data)
        {
            if (TestHirurgInteruptDates())
            {


                SaveAdditionalInfo();

                //                Controller.NavigateTo<ViewModelCurrentPatient>();

                int togle = 0;

                _fileNameOnly = "";

                // string fileName = System.IO.Path.GetTeWmpPath() + Guid.NewGuid().ToString() + ".docx";

                _fileNameOnly = "Амбулаторная_карта.docx";

                string fileName = System.IO.Path.GetTempPath() + "Амбулаторная_карта.docx";

                byte[] bte = Data.doc_template.Get(5).DocTemplate;

                //File.WriteAllBytes(fileName, bte);

                for (; ; )
                {
                    try
                    {
                        if (togle == 0)
                        {
                            File.WriteAllBytes(System.IO.Path.GetTempPath() + "Амбулаторная_карта.docx", bte);
                            _fileNameOnly = "Амбулаторная_карта.docx";
                        }
                        else
                        {
                            File.WriteAllBytes(System.IO.Path.GetTempPath() + "Амбулаторная_карта" + togle + ".docx", bte);
                            _fileNameOnly = "Амбулаторная_карта" + togle + ".docx";
                        }
                        break;
                    }
                    catch
                    {
                        togle += 1;
                        fileName = System.IO.Path.GetTempPath() + "Амбулаторная_карта" + togle + ".docx";
                        _fileNameOnly = "Амбулаторная_карта" + togle + ".docx";
                    }
                }

                using (DocX document = DocX.Load(fileName))
                {
                    string Н = "";
                    if (BloodExchangeList.Source != null)
                    {
                        foreach (var exchange in (ObservableCollection<BloodExchangeListDataSource>)BloodExchangeList.Source)
                        {
                            string tesr = (!string.IsNullOrWhiteSpace(exchange.Commentary)) ? " комментарий : " + exchange.Commentary + "; " : "; ";
                            Н += exchange.Data.Date.ToShortDateString() + ", " + exchange.Data.Volume + " мл. " + tesr;

                        }
                    }
                    //
                    //
                    document.ReplaceText("“Я”", CurrentPatient.BloodGroup);
                    document.ReplaceText("“Н”", Н);
                    document.ReplaceText("“А”", CurrentPatient.Sugar);
                    //))))))
                    document.ReplaceText("“ФИО”", CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic);
                    //
                    string day1 = "0";
                    string day2 = "0";
                    string mnth1 = "0";
                    string mnth2 = "0";
                    string year1 = CurrentPatient.Birthday.Year.ToString();
                    string year2 = CurrentPatient.Birthday.Year.ToString();
                    string day11 = "0";
                    string day22 = "0";
                    string mnth11 = "0";
                    string mnth22 = "0";
                    string year11 = DateTime.Now.Year.ToString();
                    string year22 = DateTime.Now.Year.ToString();
                    //
                    if (DateTime.Now.Day.ToString().ToCharArray().Length == 1)
                    {
                        day11 = "0";
                        day22 = DateTime.Now.Day.ToString().ToCharArray()[0].ToString();
                    }
                    else
                    {
                        day11 = DateTime.Now.Day.ToString().ToCharArray()[0].ToString();
                        day22 = DateTime.Now.Day.ToString().ToCharArray()[1].ToString();
                    }
                    if (DateTime.Now.Month.ToString().ToCharArray().Length == 1)
                    {
                        mnth11 = "0";
                        mnth22 = DateTime.Now.Month.ToString().ToCharArray()[0].ToString();
                    }
                    else
                    {
                        mnth11 = DateTime.Now.Month.ToString().ToCharArray()[0].ToString();
                        mnth22 = DateTime.Now.Month.ToString().ToCharArray()[1].ToString();
                    }
                    try
                    {
                        year11 = DateTime.Now.Year.ToString().ToCharArray()[2].ToString();
                        year22 = DateTime.Now.Year.ToString().ToCharArray()[3].ToString();
                        document.ReplaceText("г1", year11);
                        document.ReplaceText("г2", year22);
                    }
                    catch
                    {
                        document.ReplaceText("г1", DateTime.Now.Year.ToString());
                        document.ReplaceText("г2", "");
                    }
                    //
                    if (CurrentPatient.Birthday.Day.ToString().ToCharArray().Length == 1)
                    {
                        day1 = "0";
                        day2 = CurrentPatient.Birthday.Day.ToString().ToCharArray()[0].ToString();
                    }
                    else
                    {
                        day1 = CurrentPatient.Birthday.Day.ToString().ToCharArray()[0].ToString();
                        day2 = CurrentPatient.Birthday.Day.ToString().ToCharArray()[1].ToString();
                    }//
                    if (CurrentPatient.Birthday.Month.ToString().ToCharArray().Length == 1)
                    {
                        mnth1 = "0";
                        mnth2 = CurrentPatient.Birthday.Month.ToString().ToCharArray()[0].ToString();
                    }
                    else
                    {
                        mnth1 = CurrentPatient.Birthday.Month.ToString().ToCharArray()[0].ToString();
                        mnth2 = CurrentPatient.Birthday.Month.ToString().ToCharArray()[1].ToString();
                    }
                    try
                    {
                        year1 = CurrentPatient.Birthday.Year.ToString().ToCharArray()[2].ToString();
                        year2 = CurrentPatient.Birthday.Year.ToString().ToCharArray()[3].ToString();
                        document.ReplaceText("Г1", year1);
                        document.ReplaceText("Г2", year2);
                    }
                    catch
                    {
                        document.ReplaceText("Г1", CurrentPatient.Birthday.Year.ToString());
                        document.ReplaceText("Г2", "");
                    }

                    document.ReplaceText("ч1", day11);
                    document.ReplaceText("ч2", day22);
                    document.ReplaceText("м1", mnth11);
                    document.ReplaceText("м2", mnth22);
                    document.ReplaceText("Ч1", day1);
                    document.ReplaceText("Ч2", day2);
                    document.ReplaceText("М1", mnth1);
                    document.ReplaceText("М2", mnth2);

                    document.ReplaceText("область", "область " + Data.Regions.Get(CurrentPatient.Region).Str);
                    if (CurrentPatient.District != null)
                        document.ReplaceText("район", "район " + Data.Districts.Get(CurrentPatient.District.Value).Str);
                    else
                    {
                        document.ReplaceText("район,", "");
                    }
                    document.ReplaceText("місто(село)", "місто(село) " + Data.Cities.Get(CurrentPatient.City).Str);
                    document.ReplaceText("вулиця", "вулиця " + Data.Streets.Get(CurrentPatient.Street).Str);
                    document.ReplaceText("будинок", "будинок " + CurrentPatient.House);
                    document.ReplaceText("кв.", "кв. " + CurrentPatient.Flat.ToString());
                    if (CurrentPatient.Work != null)
                        document.ReplaceText("МестоРаботы", CurrentPatient.Work);
                    else
                        document.ReplaceText("МестоРаботы", "-");

                    document.ReplaceText("“П”", (CurrentPatient.Gender == "м") ? "1" : "2");

                    document.ReplaceText("“ТЕЛЕФОН”", CurrentPatient.Phone);

                    document.ReplaceText("“Rezus”", (CurrentPatient.IsPositiveGroupType != null && CurrentPatient.IsPositiveGroupType.Value) ? "Rh+" : "Rh-");

                    int xx = 0;
                    string hintrpt = "";
                    if (HirurgInteruptList.Source != null)
                    {
                        foreach (var x in (ObservableCollection<HirurgInterruptDataSource>)HirurgInteruptList.Source)
                        {
                            if (xx == 0)
                            {
                                if (x.Data != null)
                                    hintrpt += x.Data.Str + " " + x.Data.Date.Value.ToShortDateString();
                            }
                            else
                            {
                                if (x.Data != null)
                                    hintrpt += ", " + x.Data.Str + " " + x.Data.Date.Value.ToShortDateString();
                            }
                            xx++;
                        }
                        char[] chararrbuF = hintrpt.ToCharArray();
                        if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                        {
                            hintrpt = hintrpt.Remove(0, 1);

                        }
                        if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                        { }
                        else if (chararrbuF.Length != 0)
                        {
                            hintrpt += ".";
                        }


                    }
                    document.ReplaceText("“HirurgVmesh”", hintrpt);
                    xx = 0;
                    string alergi = "";
                    if (AlergicAnevrizmList.Source != null)
                    {
                        foreach (var x in (ObservableCollection<AlergicAnevrizmListDataSource>)AlergicAnevrizmList.Source)
                        {
                            if (xx == 0)
                            {
                                alergi += x.Data.Str;
                            }
                            else
                            {
                                alergi += ", " + x.Data.Str;
                            }
                            xx++;
                        }
                        char[] chararrbuF = hintrpt.ToCharArray();
                        if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                        {
                            alergi = hintrpt.Remove(0, 1);

                        }
                        if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                        { }
                        else if (chararrbuF.Length != 0)
                        {
                            alergi += ".";
                        }


                    }
                    document.ReplaceText("“Alergia”", alergi);
                    xx = 0;
                    alergi = "";
                    if (PreparateHateList.Source != null)
                    {
                        foreach (var x in (ObservableCollection<PreparateHateDataSource>)PreparateHateList.Source)
                        {
                            if (xx == 0)
                            {

                                alergi += x.Data.Str + (!string.IsNullOrWhiteSpace(x.Commentary) ? " комментарий : " + x.Commentary : "");
                            }
                            else
                            {
                                alergi += ", " + x.Data.Str + (!string.IsNullOrWhiteSpace(x.Commentary) ? " комментарий : " + x.Commentary : "");

                            }
                            xx++;
                        }
                        char[] chararrbuF = hintrpt.ToCharArray();
                        if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                        {
                            alergi = hintrpt.Remove(0, 1);

                        }
                        if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                        { }
                        else if (chararrbuF.Length != 0)
                        {
                            alergi += ".";
                        }


                    }
                    document.ReplaceText("“Neperenosimost”", alergi);


                    if (sender != null)
                    {
                        document.ReplaceText("«Врач»", sender.ToString());
                    }
                    else
                    {
                        document.ReplaceText("«Врач»", "");
                    }

                    using (var context = new MySqlContext())
                    {
                        PatologyTypeRepository ptTRep = new PatologyTypeRepository(context);
                        PatologyRepository ptRep = new PatologyRepository(context);
                        // PatientsRepository ptentRep = new PatientsRepository(context);
                        //CurrentPatient = ptentRep.Get((int)data);
                        //Initials = "Пациент: " + CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ". ";
                        string ptlogy = ""; xx = 0;
                        foreach (var Patology in ptRep.GetAll)
                        {
                            //Patology sadasew

                            if (Patology.id_пациента == CurrentPatient.Id)
                            {
                                foreach (var PatoType in ptTRep.GetAll)
                                {
                                    if (PatoType.Id == Patology.id_патологии)
                                    {
                                        //  float OpacityBuf = 0.0f;
                                        if (Patology.isArchivatied != true)
                                        {
                                            // OpacityBuf = 0.38f;


                                            string DateAppear = getmonthName(Patology.MonthAppear.Value.Month) + " " + Patology.YearAppear.Value.Year.ToString() + " года";
                                            //string DateDisappear = "";
                                            //try
                                            //{
                                            //    DateDisappear = getmonthName(Patology.MonthDisappear.Value.Month) + " " + Patology.YearDisappear.Value.Year.ToString() + " года";
                                            //}
                                            //catch { }

                                            if (xx == 0) { ptlogy += PatoType.Str + " " + DateAppear; } else { ptlogy += ", " + PatoType.Str + " " + DateAppear; }
                                            xx++;
                                        }
                                    }
                                }

                            }
                        }

                        char[] chararrbuF = ptlogy.ToCharArray();
                        if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                        {
                            ptlogy = ptlogy.Remove(0, 1);

                        }
                        if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                        { }
                        else if (chararrbuF.Length != 0)
                        {
                            ptlogy += ".";
                        }


                        document.ReplaceText("“PTS”", " : " + ptlogy);
                        document.Save();
                        Process.Start("WINWORD.EXE", fileName);
                        byte[] bteToBD = File.ReadAllBytes(fileName);

                        AdditionalInfoDocumentRepository HirurgOverviewRep = new AdditionalInfoDocumentRepository(context);
                        AdditionalInfoDocument Hv = new AdditionalInfoDocument();
                        if (hirurgOverviewId != null && hirurgOverviewId != 0)
                        {
                            Hv = Data.AdditionalInfoDocument.Get(hirurgOverviewId.Value);

                            Hv.DocTemplate = bteToBD;
                            try
                            {
                                Hv.DoctorId = int.Parse(data.ToString());

                            }
                            catch
                            {
                            }

                            Data.Complete();
                            hirurgOverviewId = Hv.Id;
                        }
                        else
                        {

                            Hv.DocTemplate = bteToBD;
                            try
                            {
                                Hv.DoctorId = int.Parse(data.ToString());

                            }
                            catch
                            {
                            }
                            Data.AdditionalInfoDocument.Add(Hv);

                            Data.Complete();
                            hirurgOverviewId = Hv.Id;
                        }
                    }
                    MessageBus.Default.Call("GeAdditionalInfoDocFILENAME", fileName, null);

                    //
                    MessageBus.Default.Call("GetAdditionalInfoDocForHirurgOverview", _fileNameOnly, hirurgOverviewId);
                }
            }
            else
            {
                MessageBox.Show("Дата введена неправильно");
            }
        }
        private void SetIdOfOverview(object sender, object data)
        {
            hirurgOverviewId = int.Parse(data.ToString());
        }
        private string getmonthName(int number)
        {
            switch (number)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
            }
            return "";

        }
        #endregion
    }
}