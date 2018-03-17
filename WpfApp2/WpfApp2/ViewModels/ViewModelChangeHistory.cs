using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;

namespace WpfApp2.ViewModels
{
    public class ChangeHistoryClass
    {

        public DateTime Date { get; set; }

        public ChangeHistory Ch;

        public string AccName { get; set; }
        public string AccPost { get; set; }
        public string ChangeType { get; set; }
        public string TableChanged { get; set; }
        public string PropertyChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }


        public bool IsFilteredDate { get; set; }
        public bool IsFilteredAccName { get; set; }
        public bool IsFilteredAccPost { get; set; }
        public bool IsFilteredChangeType { get; set; }
        public bool IsFilteredTableChanged { get; set; }
        public bool IsFilteredPropertyChanged { get; set; }
        public bool IsFilteredOldValue { get; set; }
        public bool IsFilteredNewValue { get; set; }


        public bool IsVisibleTotal { get; set; }



        public ChangeHistoryClass(ChangeHistory Ch, MySqlContext context)
        {
            this.Ch = Ch;
            AccName = "";
            AccPost = "";
            ChangeType = "";
            TableChanged = "";
            PropertyChanged = "";
            OldValue = "";
            NewValue = "";
            IsVisibleTotal = true;
            IsFilteredDate = false;
            IsFilteredAccName = false;
            IsFilteredAccPost = false;
            IsFilteredChangeType = false;
            IsFilteredTableChanged = false;
            IsFilteredPropertyChanged = false;
            IsFilteredOldValue = false;
            IsFilteredNewValue = false;


            // TEST
            if (Ch.SomeBlobFileNew != null)
            {
                NewValue = "Новое фото анализа";
            }
            if (Ch.SomeBlobFileOld != null)
            {
                OldValue = "Старое фото анализа";
            }
            else
            {
                OldValue = Ch.старое_значение;
                NewValue = Ch.новое_значение;
            }
            TableChanged = Ch.название_таблицы;
            PropertyChanged = Ch.название_столбца;




            // Date = Op.Date.Day.ToString() + "." + Op.Date.Month.ToString() + "." + Op.Date.Year.ToString();
            // Time = buf1.Hour.ToString() + ":" + buf1.Minute.ToString();
            Date = Ch.дата_изменения;
          
                AccauntRepository acRep = new AccauntRepository(context);
                ChangesInDBTypeRepository chindbRep = new ChangesInDBTypeRepository(context);
                Accaunt CurAcc = acRep.Get(Ch.id_аккаунта);

                AccName = CurAcc.Name;


                if (CurAcc.isAdmin != null && CurAcc.isAdmin.Value)
                {
                    AccPost = "Администратор";
                }
                else if (CurAcc.isDoctor != null && CurAcc.isDoctor.Value)
                {
                    AccPost = "Врач";
                }
                else if (CurAcc.isMedPersonal != null && CurAcc.isMedPersonal.Value)
                {
                    AccPost = "Медперсонал";
                }

                ChangeType = chindbRep.Get(Ch.тип_изменения).Str;
                //var CurrentPatient = PtRep.Get(Ex.PatientId.Value);
                //Patient = CurrentPatient.Sirname + " " + CurrentPatient.Name.ToCharArray()[0].ToString() + ". " + CurrentPatient.Patronimic.ToCharArray()[0].ToString() + ".";


            

        }

    }
    public class ViewModelChangesHistoy : ViewModelBase, INotifyPropertyChanged
    {
        private int _sortId;
        public int SortId
        {
            get { return _sortId; }
            set
            { _sortId = value;
                SetChangesInDB(null, null);
                OnPropertyChanged(); }
        }
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private bool _isSortByData;
        public CollectionViewSource ViewSource { get; set; }
        public bool IsSortByData
        {
            get { return _isSortByData; }
            set
            {
                _isSortByData = value; if (_isSortByData == true)
                {

                    ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                    // Let the UI control refresh in order for changes to take place.
                    ViewSource.View.Refresh();

                }
                else
                {
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
                OnPropertyChanged();
            }
        }
        private int lastLength = 0;
        private Visibility _visOfNothingFaund;
        public Visibility VisOfNothingFaund
        {
            get { return _visOfNothingFaund; }
            set
            { _visOfNothingFaund = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ChangeHistoryClass> _exams;
        public ObservableCollection<ChangeHistoryClass> Changes { get { return _exams; } set { _exams = value; OnPropertyChanged(); } }
        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value; OnPropertyChanged();

                if (lastLength >= value.Length)
                {
                    //foreach(ChangeHistoryClass x in FullCopy)
                    //{
                    //    ChangeHistoryClass buf = new ChangeHistoryClass(x.Ch);
                    //    Changes.Add(buf);
                    //}
                    Changes = new ObservableCollection<ChangeHistoryClass>(FullCopy);
                }
                lastLength = value.Length;
                if (!string.IsNullOrWhiteSpace(FilterText))
                {
                    for (int i = 0; i < Changes.Count; ++i)
                    {



                        if (Changes[i].AccName.ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredAccName = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredAccName = false;
                        }
                        if (Changes[i].AccPost.ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredAccPost = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredAccPost = false;
                        }
                        if (Changes[i].Date.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredDate = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredDate = false;
                        }
                        if (Changes[i].ChangeType.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredChangeType = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredChangeType = false;
                        }



                        if (Changes[i].TableChanged.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredTableChanged = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredTableChanged = false;
                        }

                        if (Changes[i].PropertyChanged.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredPropertyChanged = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredPropertyChanged = false;
                        }



                        if (Changes[i].OldValue.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredOldValue = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredOldValue = false;
                        }


                        if (Changes[i].NewValue.ToString().ToLower().Contains(FilterText.ToLower()))
                        {
                            Changes[i].IsFilteredNewValue = true;
                            Changes[i].IsVisibleTotal = true;
                        }
                        else
                        {
                            Changes[i].IsFilteredNewValue = false;
                        }

                        if (!Changes[i].IsFilteredDate && !Changes[i].IsFilteredNewValue && !Changes[i].IsFilteredOldValue &&
                        !Changes[i].IsFilteredPropertyChanged && !Changes[i].IsFilteredTableChanged &&
                        !Changes[i].IsFilteredChangeType && !Changes[i].IsFilteredAccName && !Changes[i].IsFilteredAccPost)
                        {
                            Changes[i].IsVisibleTotal = false;
                        }
                        //IsFilteredAccName = false;
                        //IsFilteredAccPost = false;
                        //IsFilteredChangeType = false;
                        //IsFilteredTableChanged = false;
                        //IsFilteredPropertyChanged = false;
                        //IsFilteredOldValue = false;
                        //IsFilteredNewValue = false;


                    }
                    //if (_isSortByData == true)
                    //{

                    //    ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                    //    // Let the UI control refresh in order for changes to take place.
                    //    ViewSource.View.Refresh();

                    //}
                    //


                    for (int i = 0; i < Changes.Count; ++i)
                    {
                        if (Changes[i].IsVisibleTotal == false)
                        {
                            Changes.Remove(Changes[i]);
                            --i;
                        }
                    }
                    if (Changes.Count == 0)
                    {
                        VisOfNothingFaund = Visibility.Visible;
                    }
                    else
                    {
                        VisOfNothingFaund = Visibility.Collapsed;
                    }
                    ViewSource.Source = Changes;


                    ViewSource.View.Refresh();
                    //  Controller.NavigateTo<ViewModelChangesHistoy>();
                }
                else
                {
                    ViewSource.Source = Changes;
                    VisOfNothingFaund = Visibility.Collapsed;
                    foreach (ChangeHistoryClass x in Changes)
                    {
                        x.IsVisibleTotal = true;
                        x.IsFilteredDate = false;
                        x.IsFilteredAccName = false;
                        x.IsFilteredAccPost = false;
                        x.IsFilteredChangeType = false;
                        x.IsFilteredTableChanged = false;
                        x.IsFilteredPropertyChanged = false;
                        x.IsFilteredOldValue = false;
                        x.IsFilteredNewValue = false;
                    }
                    ViewSource.View.Refresh();
                    // SetChangesInDB(null, null);
                }





            }
        }

        //private void FilterActivater()
        //{

        bool test;
        //}
        List<ChangeHistoryClass> FullCopy;
        private void SetChangesInDB(object sender, object data)
        {
            using (MySqlContext context = new MySqlContext())
            {
                try
                {


                    ChangeHistoryRepository ChangeRp = new ChangeHistoryRepository(context);

                    if(Changes.Count != FullCopy.Count)
                        Changes = new ObservableCollection<ChangeHistoryClass>(FullCopy);
                    //FullCopy = new List<ChangeHistoryClass>();
                    //  Changes = new ObservableCollection<ChangeHistoryClass>();
                    //  ViewSource = new CollectionViewSource();
                    test = true;
                    string query = "SELECT * FROM med_db.история_изменений ORDER BY id DESC";
                    int limit = 0;
                    if(SortId == 0)
                    {
                        limit = 5;
                        query += " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 1)
                    {
                        limit = 10;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 2)
                    {
                        limit = 20;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 3)
                    {
                        limit = 30;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 4)
                    {
                        limit = 40;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 5)
                    {
                        limit = 50;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 6)
                    {
                        limit = 100;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 7)
                    {
                        limit = 200;
                        query +=  " LIMIT " + limit.ToString();
                    }
                    else if (SortId == 8)
                    {
                       
                    }
                  
                    Changes = new ObservableCollection<ChangeHistoryClass>();
                    FullCopy = new List<ChangeHistoryClass>();
                    foreach (ChangeHistory Ch in context.Database.SqlQuery<ChangeHistory>(query).ToList())
                    {


                        //test = true;
                        //for (int i = 0; i < Changes.Count; ++i)
                        //{
                          
                        //    if (Changes[i].Ch.id == Ch.id)
                        //    { test = false;break; }
                          
                        //}
                        //if (test)
                        //{
                            ChangeHistoryClass buf = new ChangeHistoryClass(Ch, context);
                            FullCopy.Add(buf);
                            Changes.Add(buf);
                        //}


                    }



                    if (Changes.Count == 0)
                    {
                        VisOfNothingFaund = Visibility.Visible;
                    }
                    else
                    {
                        VisOfNothingFaund = Visibility.Collapsed;
                    }

                    ViewSource.Source = Changes;


                    if (_isSortByData == true)
                    {

                        ViewSource.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

                        // Let the UI control refresh in order for changes to take place.
                        ViewSource.View.Refresh();

                    }
                    else
                    {
                        ViewSource.SortDescriptions.Clear();
                        ViewSource.View.Refresh();
                    }
                    //    Controller.NavigateTo<ViewModelChangesHistoy>();
                }
                catch (Exception exc)
                {
                    ViewSource = new CollectionViewSource();
                    Changes = new ObservableCollection<ChangeHistoryClass>();
                    ViewSource.Source = Changes;
                    ViewSource.SortDescriptions.Clear();
                    ViewSource.View.Refresh();
                }
            }
            _filterText = "";
            OnPropertyChanged("FilterText");
        }

        public DelegateCommand ToPhysicalCommand { get; protected set; }
        public DelegateCommand FilterTextCommand { get; protected set; }
        public ViewModelChangesHistoy(NavigationController controller) : base(controller)
        {
            SortId = 0;
            ViewSource = new CollectionViewSource();
            MessageBus.Default.Subscribe("SetChangesForChangesTable", SetChangesInDB);
            base.HasNavigation = true;

            _isSortByData = true;
            FullCopy = new List<ChangeHistoryClass>();
            Changes = new ObservableCollection<ChangeHistoryClass>();
            FilterTextCommand = new DelegateCommand(
              () =>
              {



              }
          );
            ToPhysicalCommand = new DelegateCommand(
                () =>
                {
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
    }
}
