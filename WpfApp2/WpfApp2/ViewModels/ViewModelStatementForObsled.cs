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

namespace WpfApp2.ViewModels
{
    public class ViewModelStatementForObsled : ViewModelBase, INotifyPropertyChanged
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

        //public ObservableCollection<Docs> _doctors;
        //public ObservableCollection<Docs> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }
        //private int _doctorSelectedId;
        private int obsledId;
        //public int DoctorSelectedId
        //{
        //    get { return _doctorSelectedId; }
        //    set
        //    {
        //        _doctorSelectedId = value;
        //        OnPropertyChanged();
        //    }
        //}
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

        private string _fileName;
        public string _fileNameOnly;
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
        private StatementObs _currentDocument;

        public StatementObs CurrentDocument
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
            CurrentDocument = new StatementObs();
            try
            {
                using (var context = new MySqlContext())
                {
                    StatementObsRepository HVRep = new StatementObsRepository(context);
                  
                  //  DoctorRepository DoctorRep = new DoctorRepository(context);
                    PatientsRepository PtRep = new PatientsRepository(context);

                    // CurrentPatient = PtRep.Get((int)data);CurrentDocument
                    //Doctors = new ObservableCollection<Docs>();
                    ////bool tester = true;
                    //foreach (var doc in DoctorRep.GetAll)
                    //{
                    //    if (doc.isEnabled.Value)
                    //    {
                    //        Doctors.Add(new Docs(doc));
                    //    }
                    //}


                    if (data != null && int.Parse(data.ToString()) != 0)
                    {
                        CurrentDocument = HVRep.Get(int.Parse(data.ToString()));
                        //if (CurrentDocument.DoctorId != 0)
                        //{
                        //    var doc = DoctorRep.Get(CurrentDocument.DoctorId);
                        //    foreach (var docs in Doctors)
                        //    {
                        //        if (docs.doc.Id == doc.Id)
                        //        {
                        //            DoctorSelectedId = Doctors.IndexOf(docs);
                        //        }
                        //    }
                        //}
                        // DoctorSelectedId = CurrentDocument.DoctorId;
                        IsDocAdded = Visibility.Visible;
                        TextForDoWhat = "";
                    }
                    else
                    {
                        //DoctorSelectedId = 0;
                        IsDocAdded = Visibility.Hidden;
                        TextForDoWhat = "Сформируйте или загрузите документ";

                    }
                    //foreach (var x in HVRep.GetAll)
                    //{

                    //    if (x.PatientId == CurrentPatient.Id)
                    //    {
                    //        tester = false;
                    //        CurrentDocument = x;

                    //        break;
                    //    }

                    //    // StatementObs Hv = new StatementObs();
                    //}


                    //if (tester)
                    //{
                    //    IsDocAdded = Visibility.Hidden;
                    //    TextForDoWhat = "Сформируйте или загрузите документ";
                    //}
                    //else
                    //{
                    //    IsDocAdded = Visibility.Visible;

                    //}
                }
            }
            catch
            {

            }
            IsAnalizeLoadedVisibility = Visibility.Hidden;


            //TODO: LOAD FROM FILE

        }
        //private void SetCurrentAnalizeID(object sender, object data)
        //{
        //    IsAnalizeLoadedVisibility = Visibility.Hidden;
        //    Analize = Data.Analize.Get((int)data);

        //    AnalizeType = Data.AnalizeType.Get(Analize.analyzeType);
        //}

        public ViewModelStatementForObsled(NavigationController controller) : base(controller)
        {
            IsAnalizeLoadedVisibility = Visibility.Hidden;
            ButtonName = "К Пациенту";//SetCurrentPatientIDRealyThisTime
            MessageBus.Default.Subscribe("GetStatementForStatement", SetCurrentPatientID);
            MessageBus.Default.Subscribe("SetCurrentPatientIDRealyThisTimeStatement", SetCurrentPatientIDRealyThisTime);
            // MessageBus.Default.Subscribe("GetAnalizeForAnalizeOverview", SetCurrentAnalizeID);
            HasNavigation = false;
            Controller = controller;
            ToCurrentObsledCommand = new DelegateCommand(
            () =>
            {
                Controller.NavigateTo<ViewModelAddPhysical>();
            }
        );

            OpenWordDocument = new DelegateCommand(
            () =>
            {
                int togle = 0;

                FileName = System.IO.Path.GetTempPath() + "Консультативное_заключение.docx";
                _fileNameOnly = "Консультативное_заключение.docx";
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
                        FileName = System.IO.Path.GetTempPath() + "Консультативное_заключение" + togle + ".docx";
                        _fileNameOnly = "Консультативное_заключение" + togle + ".docx";
                    }
                }
                Process.Start("WINWORD.EXE", FileName);
            }
        );
            SetNewOverview = new DelegateCommand(
            () =>
            {
                //if (Doctors != null && Doctors.Count != 0)
                //{
                //    if (DoctorSelectedId == -1)
                //    {
                        MessageBus.Default.Call("CreateStatement", "", null);

                    //}
                    //else
                    //{
                    //    MessageBus.Default.Call("CreateStatement", Doctors[DoctorSelectedId].ToString(), Doctors[DoctorSelectedId].doc.Id);
                    ////}
                    TextForDoWhat = "Вы создали новый документ " + _fileNameOnly;

                //}

                //OpenFileDialog op = new OpenFileDialog();
                //op.Title = "Выберите фотографию анализа";
                //op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                //  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                //  "Portable Network Graphic (*.png)|*.png";
                //if (op.ShowDialog() == true)
                //{
                //    Analize.ImageByte = ImageToByte(new BitmapImage(new Uri(op.FileName)));
                //    IsAnalizeLoadedVisibility = Visibility.Visible;
                //    Data.Complete();
                //}
            }
        );
            SaveWordDocument = new DelegateCommand(
            () =>
            {
                try
                {
                    if (FileName != null)
                    {
                        byte[] bteToBD = File.ReadAllBytes(FileName);
                        using (var context = new MySqlContext())
                        {
                            StatementObsRepository HirurgOverviewRep = new StatementObsRepository(context);
                            StatementObs Hv = new StatementObs();
                            //HirurgOverviewRepository HirurgOverviewRep = new HirurgOverviewRepository(context);
                            //StatementObs Hv = new StatementObs();
                            //bool tester = true;

                            if (CurrentDocument.Id != 0)
                            {
                                Hv = Data.StatementObs.Get(CurrentDocument.Id);
                                CurrentDocument.DocTemplate = bteToBD;
                                Hv.DocTemplate = bteToBD;
                                //Hv.DoctorId = DoctorSelectedId;
                                Data.Complete();
                            }
                            else
                            {

                                Hv.DocTemplate = bteToBD;
                              //  Hv.DoctorId = DoctorSelectedId;
                                CurrentDocument.DocTemplate = bteToBD;
                                Data.StatementObs.Add(Hv);

                                Data.Complete();
                                CurrentDocument.Id = Hv.Id;
                                MessageBus.Default.Call("SetIdOfStatement", null, CurrentDocument.Id);
                            }
                            //foreach (var x in HirurgOverviewRep.GetAll)
                            //{

                            //    if (x.PatientId == CurrentPatient.Id)
                            //    {
                            //        tester = false;
                            //        Hv = x;
                            //        Hv.DocTemplate = bteToBD;
                            //        Data.Complete();
                            //        break;
                            //    }

                            //    // StatementObs Hv = new StatementObs();
                            //}
                            //if (tester)
                            //{
                            //    Hv.PatientId = CurrentPatient.Id;
                            //    Hv.DocTemplate = bteToBD;
                            //    Data.StatementObs.Add(Hv);
                            //    Data.Complete();
                            //}

                        }
                        //int bff = 0;
                        //if (CurrentDocument.DoctorId > 0)
                        //    bff = CurrentDocument.DoctorId;

                        //MessageBus.Default.Call("GetHirurgOverviewForHirurgOverview", null, null);
                        //if (DoctorSelectedId <= 0)
                        //    DoctorSelectedId = bff;
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
                        //StatementObsRepository HirurgOverviewRep = new StatementObsRepository(context);
                        StatementObs Hv = new StatementObs();

                        if (CurrentDocument.Id != 0)
                        {
                            Hv = Data.StatementObs.Get(CurrentDocument.Id);

                            Hv.DocTemplate = bteToBD;
                            //Hv.DoctorId = DoctorSelectedId;
                            Data.Complete();
                        }
                        else
                        {

                            Hv.DocTemplate = bteToBD;
                            //Hv.DoctorId = DoctorSelectedId;
                            Data.StatementObs.Add(Hv);

                            Data.Complete();
                            CurrentDocument.Id = Hv.Id;
                            MessageBus.Default.Call("SetIdOfOverview", null, CurrentDocument.Id);
                        }
                        //bool tester = true;
                        //foreach (var x in HirurgOverviewRep.GetAll)
                        //{

                        //    if (x.PatientId == CurrentPatient.Id)
                        //    {
                        //        tester = false;
                        //        Hv = Data.StatementObs.Get(x.Id);
                        //        Hv.DocTemplate = bteToBD;
                        //        Data.Complete();
                        //        break;
                        //    }

                        //    // StatementObs Hv = new StatementObs();
                        //}
                        //if (tester)
                        //{
                        //    Hv.PatientId = CurrentPatient.Id;
                        //    Hv.DocTemplate = bteToBD;
                        //    Data.StatementObs.Add(Hv);
                        //    Data.Complete();
                        //}

                    }

                    MessageBus.Default.Call("GetStatementForStatement", null, CurrentDocument.Id);
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

            //ToCurrentPatientCommand = new DelegateCommand(
            //     () =>
            //     {

            //         MessageBus.Default.Call("GetCurrentPatientId", this, CurrentPatient.Id);
            //         Controller.NavigateTo<ViewModelCurrentPatient>();
            //     }
            // );
        }

    }
}
