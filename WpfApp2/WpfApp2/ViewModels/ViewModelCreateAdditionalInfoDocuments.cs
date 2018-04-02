using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;
using Xceed.Words.NET;

namespace WpfApp2.ViewModels
{
    class ViewModelCreateAdditionalInfoDocuments : ViewModelBase, INotifyPropertyChanged
    {

        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private Visibility _isDocAdded;

        public Visibility IsDocAdded
        {
            get { return _isDocAdded; }
            set
            {
                _isDocAdded = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Docs> _doctors;
        public ObservableCollection<Docs> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }
        private int _doctorSelectedId;

        public int DoctorSelectedId
        {
            get { return _doctorSelectedId; }
            set
            {
                _doctorSelectedId = value;
                OnPropertyChanged();
            }
        }



        public string _fileNameOnly;
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
        private string _textForDoWhat;

        public string TextForDoWhat
        {
            get { return _textForDoWhat; }
            set
            {
                _textForDoWhat = value;
                OnPropertyChanged();
            }
        }
        private AdditionalInfoDocument _currentDocument;

        public AdditionalInfoDocument CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                _currentDocument = value;
                OnPropertyChanged();
            }
        }
        public Patient CurrentPatient { get; set; }
        public DelegateCommand ToCurrentObsledCommand { get; }
        public DelegateCommand OpenWordDocument { get; }
        public DelegateCommand SetNewOverview { get; }
        public DelegateCommand SaveWordDocument { get; }
        public DelegateCommand OpenFile { get; }
        public DelegateCommand ToCurrentPatientCommand { get; }

        private void SetCurrentPatientIDRealyThisTime(object sender, object data)
        {
            using (var context = new MySqlContext())
            {
                PatientsRepository PtRep = new PatientsRepository(context);

                CurrentPatient = PtRep.Get((int)data);
            }
        }
        private void SetCurrentPatientID(object sender, object data)
        {

            if (sender != null)
            {
                _fileNameOnly = sender as string;
            }
            CurrentDocument = new AdditionalInfoDocument();
            try
            {
                using (var context = new MySqlContext())
                {
                    AdditionalInfoDocumentRepository HVRep = new AdditionalInfoDocumentRepository(context);
                    DoctorRepository DoctorRep = new DoctorRepository(context);
                    PatientsRepository PtRep = new PatientsRepository(context);

                    // CurrentPatient = PtRep.Get((int)data);CurrentDocument
                    Doctors = new ObservableCollection<Docs>();
                    //bool tester = true;
                    foreach (var doc in DoctorRep.GetAll)
                    {
                        if (doc.isEnabled.Value)
                        {
                            Doctors.Add(new Docs(doc));
                        }
                    }


                    if (data != null && int.Parse(data.ToString()) != 0)
                    {
                        CurrentDocument = HVRep.Get(int.Parse(data.ToString()));
                        if (CurrentDocument.DoctorId != 0)
                        {
                            var doc = DoctorRep.Get(CurrentDocument.DoctorId);
                            foreach (var docs in Doctors)
                            {
                                if (docs.doc.Id == doc.Id)
                                {
                                    DoctorSelectedId = Doctors.IndexOf(docs);
                                }
                            }
                        }
                        // DoctorSelectedId = CurrentDocument.DoctorId;
                        IsDocAdded = Visibility.Visible;
                        TextForDoWhat = "";
                    }
                    else
                    {
                        DoctorSelectedId = 0;
                        IsDocAdded = Visibility.Hidden;
                        TextForDoWhat = "Сформируйте или загрузите документ";

                    }

                }
            }
            catch
            {

            }
            //       IsAnalizeLoadedVisibility = Visibility.Hidden;


            //TODO: LOAD FROM FILE

        }
        private void GetStatementForStatementFILENAME(object sender, object data)
        {
            FileName = (string)sender;
        }
        public SclerozPanelViewModel CurrentSavePanelViewModel { get; protected set; }
        public ICommand OpenAddSaveCommand { protected set; get; }
        public DelegateCommand RevertSaveCommand { set; get; }
        public ViewModelCreateAdditionalInfoDocuments(NavigationController controller) : base(controller)
        {
            MessageBus.Default.Subscribe("GetAdditionalInfoDocForHirurgOverview", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetCurrentPatientIDRealyThisTimeForAdditionalInfo", SetCurrentPatientIDRealyThisTime);
            // MessageBus.Default.Subscribe("GetAnalizeForAnalizeOverview", SetCurrentAnalizeID);
            HasNavigation = false;
            Controller = controller;
            ToCurrentObsledCommand = new DelegateCommand(
            () =>
            {
                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Сохранили ли вы все изменения", "", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        //        MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                        //GetObsForOverview
                        Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                        FileName = "";
                    }
                }
                else
                {
                    //       MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    //GetObsForOverview
                    Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
                    FileName = "";
                }
                // Controller.NavigateTo<ViewModelAdditionalInfoPatient>();
            }
        );

            OpenWordDocument = new DelegateCommand(
            () =>
            {
                int togle = 0;

                FileName = System.IO.Path.GetTempPath() + "Амбулаторная_карта.docx";
                _fileNameOnly = "Амбулаторная_карта.docx";
                byte[] bte = CurrentDocument.DocTemplate;

                for (; ; )
                {
                    try
                    {

                        File.WriteAllBytes(FileName, bte);

                        break;
                    }
                    catch
                    {
                        togle += 1;
                        FileName = System.IO.Path.GetTempPath() + "Амбулаторная_карта" + togle + ".docx";
                        _fileNameOnly = "Амбулаторная_карта" + togle + ".docx";
                    }
                }
                TextForDoWhat = "Был открыт доккумент " + _fileNameOnly + ". Для сохранения изменений в документе сохраните данные в Word, закройте документ и нажмите кнопку \"Сохранить изменения\".";

                Process.Start("WINWORD.EXE", FileName);
            }
        );
            MessageBus.Default.Subscribe("GeAdditionalInfoDocFILENAME", GetStatementForStatementFILENAME);
            CurrentSavePanelViewModel = new SclerozPanelViewModel(this);

            OpenAddSaveCommand = new DelegateCommand(() =>
            {

                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    CurrentSavePanelViewModel.ClearPanel();
                    CurrentSavePanelViewModel.PanelOpened = true;
                }
                else
                {
                    MessageBox.Show("Сначала откройте документ");
                }
            });

            RevertSaveCommand = new DelegateCommand(() =>
            {
                CurrentSavePanelViewModel.PanelOpened = false;

            });
            SetNewOverview = new DelegateCommand(
            () =>
            {
                if (Doctors != null && Doctors.Count != 0)
                {
                    if (DoctorSelectedId == -1)
                    {
                        MessageBus.Default.Call("CreateDocumentAdditionalInfo", "", null);

                    }
                    else
                    {
                        MessageBus.Default.Call("CreateDocumentAdditionalInfo", Doctors[DoctorSelectedId].ToString(), Doctors[DoctorSelectedId].doc.Id);
                    }
                    TextForDoWhat = "Вы создали новый документ " + _fileNameOnly;

                }

            }
        );
            SaveWordDocument = new DelegateCommand(
            () =>
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(FileName))
                    {
                        byte[] bteToBD = File.ReadAllBytes(FileName);
                        using (var context = new MySqlContext())
                        {
                            AdditionalInfoDocumentRepository HirurgOverviewRep = new AdditionalInfoDocumentRepository(context);
                            AdditionalInfoDocument Hv = new AdditionalInfoDocument();

                            //bool tester = true;

                            if (CurrentDocument.Id != 0)
                            {
                                Hv = Data.AdditionalInfoDocument.Get(CurrentDocument.Id);
                                CurrentDocument.DocTemplate = bteToBD;
                                Hv.DocTemplate = bteToBD;
                                Hv.DoctorId = Doctors[DoctorSelectedId].doc.Id;
                                Data.Complete();
                            }
                            else
                            {

                                Hv.DocTemplate = bteToBD;
                                Hv.DoctorId = Doctors[DoctorSelectedId].doc.Id;
                                CurrentDocument.DocTemplate = bteToBD;
                                Data.AdditionalInfoDocument.Add(Hv);

                                Data.Complete();
                                CurrentDocument.Id = Hv.Id;
                                MessageBus.Default.Call("SetIdOfAdditionalInfoDoc", null, CurrentDocument.Id);
                            }

                        }
                        CurrentSavePanelViewModel.PanelOpened = false;
                        TextForDoWhat = "Изменения в " + _fileNameOnly + " были сохранены";
                    }

                }
                catch
                {

                    MessageBox.Show("Закройте документ");
                }
            }
        );
            OpenFile = new DelegateCommand(
            () =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Word Documents (.docx)|*.docx|Word Template (.dotx)|*.dotx|All Files (*.*)|*.*";
                openFileDialog.ValidateNames = true;
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == true)
                {
                    _fileNameOnly = openFileDialog.SafeFileName;
                    FileName = openFileDialog.FileName;
                    byte[] bteToBD = File.ReadAllBytes(FileName);
                    using (var context = new MySqlContext())
                    {
                        AdditionalInfoDocumentRepository HirurgOverviewRep = new AdditionalInfoDocumentRepository(context);
                        AdditionalInfoDocument Hv = new AdditionalInfoDocument();

                        if (CurrentDocument.Id != 0)
                        {
                            Hv = Data.AdditionalInfoDocument.Get(CurrentDocument.Id);

                            Hv.DocTemplate = bteToBD;
                            Hv.DoctorId = Doctors[DoctorSelectedId].doc.Id;
                            Data.Complete();
                        }
                        else
                        {

                            Hv.DocTemplate = bteToBD;
                            Hv.DoctorId = Doctors[DoctorSelectedId].doc.Id;
                            Data.AdditionalInfoDocument.Add(Hv);

                            Data.Complete();
                            CurrentDocument.Id = Hv.Id;
                            MessageBus.Default.Call("SetIdOfAdditionalInfoDoc", null, CurrentDocument.Id);
                        }

                    }

                    MessageBus.Default.Call("GetAdditionalInfoDocForHirurgOverview", null, CurrentDocument.Id);
                    TextForDoWhat = "Был загружен документ " + _fileNameOnly;
                }


            }
        );

            ToCurrentPatientCommand = new DelegateCommand(
                 () =>
                 {

                     MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
                     Controller.NavigateTo<ViewModelCurrentPatient>();
                 }
             );
        }

        //private void CreateWordDocument()
        //{
        //    MessageBus.Default.Call("CreateDocumentAdditionalInfo",null,SelectedDocto)

        //}
    }
}
