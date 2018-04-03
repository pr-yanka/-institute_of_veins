using Microsoft.Practices.Prism.Commands;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using Microsoft.Win32;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WpfApp2.DialogService;
using WpfApp2.ViewModels.Panels;
using System.Windows.Input;

namespace WpfApp2.ViewModels
{
    public class ViewModelHirurgOverview : ViewModelBase, INotifyPropertyChanged
    {

        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public string ButtonName { get; set; }


        //      public AnalizeType AnalizeType { get; set; }


        private Visibility _isAnalizeLoadedVisibility;
        public Visibility IsAnalizeLoadedVisibility
        {
            get
            {
                return _isAnalizeLoadedVisibility;
            }
            set { _isAnalizeLoadedVisibility = value; OnPropertyChanged(); }
        }

        //        public Analize Analize { get; set; }

        public Patient CurrentPatient { get; set; }
        public DelegateCommand ToCurrentObsledCommand { get; private set; }
        public DelegateCommand OpenWordDocument { get; private set; }
        public DelegateCommand SetNewOverview { get; protected set; }
        public DelegateCommand SaveWordDocument { get; private set; }
        public DelegateCommand OpenFile { get; private set; }
        public DelegateCommand OpenAnalizePicture { get; protected set; }

        public DelegateCommand ToCurrentPatientCommand { get; protected set; }
        private int obsledId;
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
        private HirurgOverview _currentDocument;

        public HirurgOverview CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                _currentDocument = value;
                OnPropertyChanged();
            }
        }
        //Сформируйте или загрузите документ TextForDoWhat
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
            CurrentDocument = new HirurgOverview();
            try
            {
                using (var context = new MySqlContext())
                {
                    HirurgOverviewRepository HVRep = new HirurgOverviewRepository(context);
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
            IsAnalizeLoadedVisibility = Visibility.Hidden;


            //TODO: LOAD FROM FILE

        }
        private void GetStatementForStatementFILENAME(object sender, object data)
        {
            FileName = (string)sender;
        }

        public SclerozPanelViewModel CurrentSavePanelViewModel { get; protected set; }
        public ICommand OpenAddSaveCommand { protected set; get; }
        public DelegateCommand RevertSaveCommand { set; get; }
        public ViewModelHirurgOverview(NavigationController controller) : base(controller)
        {
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            ButtonName = "К Пациенту";//SetCurrentPatientIDRealyThisTime
            MessageBus.Default.Subscribe("GetHirurgOverviewForHirurgOverview", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetCurrentPatientIDRealyThisTime", SetCurrentPatientIDRealyThisTime);
            // MessageBus.Default.Subscribe("GetAnalizeForAnalizeOverview", SetCurrentAnalizeID);
            HasNavigation = false;
            Controller = controller;
            ToCurrentObsledCommand = new DelegateCommand(
            () =>
            {
                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Вы сохранили изменения в документе?", "", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        Controller.NavigateTo<ViewModelAddPhysical>();
                        FileName = "";
                    }
                }
                else
                {
                    Controller.NavigateTo<ViewModelAddPhysical>();
                    FileName = "";
                }
            }
        );
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


            OpenWordDocument = new DelegateCommand(
            () =>
            {
                int togle = 0;

                FileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга.docx";
                _fileNameOnly = "Осмотр_хирурга.docx";
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
                        FileName = System.IO.Path.GetTempPath() + "Осмотр_хирурга" + togle + ".docx";
                        _fileNameOnly = "Осмотр_хирурга" + togle + ".docx";
                    }
                }
                TextForDoWhat = "Был открыт доккумент " + _fileNameOnly + ". Для сохранения изменений в документе сохраните данные в Word, закройте документ и нажмите кнопку \"Сохранить изменения\".";

                Process.Start("WINWORD.EXE", FileName);
            }
        );
            MessageBus.Default.Subscribe("GetHirurgOverviewtForHirurgOverviewFILENAME", GetStatementForStatementFILENAME);
            SetNewOverview = new DelegateCommand(
            () =>
            {
                if (Doctors != null && Doctors.Count != 0)
                {
                    if (DoctorSelectedId == -1)
                    {
                        MessageBus.Default.Call("CreateHirurgOverview", "", null);

                    }
                    else
                    {
                        MessageBus.Default.Call("CreateHirurgOverview", Doctors[DoctorSelectedId].ToString(), Doctors[DoctorSelectedId].doc.Id);
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
                            HirurgOverviewRepository HirurgOverviewRep = new HirurgOverviewRepository(context);
                            HirurgOverview Hv = new HirurgOverview();
                            //bool tester = true;

                            if (CurrentDocument.Id != 0)
                            {
                                Hv = Data.HirurgOverview.Get(CurrentDocument.Id);
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
                                Data.HirurgOverview.Add(Hv);

                                Data.Complete();
                                CurrentDocument.Id = Hv.Id;
                                MessageBus.Default.Call("SetIdOfOverview", null, CurrentDocument.Id);
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
                openFileDialog.Filter = "Word Documents (.docx)|*.docx|All Files (*.*)|*.*";
                openFileDialog.ValidateNames = true;
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == true)
                {
                    _fileNameOnly = openFileDialog.SafeFileName;
                    FileName = openFileDialog.FileName;
                    byte[] bteToBD = File.ReadAllBytes(FileName);
                    using (var context = new MySqlContext())
                    {
                        HirurgOverviewRepository HirurgOverviewRep = new HirurgOverviewRepository(context);
                        HirurgOverview Hv = new HirurgOverview();

                        if (CurrentDocument.Id != 0)
                        {
                            Hv = Data.HirurgOverview.Get(CurrentDocument.Id);

                            Hv.DocTemplate = bteToBD;
                            Hv.DoctorId = Doctors[DoctorSelectedId].doc.Id;
                            Data.Complete();
                        }
                        else
                        {

                            Hv.DocTemplate = bteToBD;
                            Hv.DoctorId = Doctors[DoctorSelectedId].doc.Id;
                            Data.HirurgOverview.Add(Hv);

                            Data.Complete();
                            CurrentDocument.Id = Hv.Id;
                            MessageBus.Default.Call("SetIdOfOverview", null, CurrentDocument.Id);
                        }

                    }

                    MessageBus.Default.Call("GetHirurgOverviewForHirurgOverview", null, CurrentDocument.Id);
                    TextForDoWhat = "Был загружен документ " + _fileNameOnly;
                }

                //var img = ByteToImage(Analize.ImageByte);
                //int width = Convert.ToInt32(img.Width);
                //int height = Convert.ToInt32(img.Height);
                //Bitmap TestBitmap = new Bitmap(width, height);
                //TestBitmap.Save("TempImage.Bmp");
                //TestBitmap.Dispose();
                //File.WriteAllBytes("TempImage.Bmp", Analize.ImageByte);
                //Process.Start("TempImage.Bmp");
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

    }
}
