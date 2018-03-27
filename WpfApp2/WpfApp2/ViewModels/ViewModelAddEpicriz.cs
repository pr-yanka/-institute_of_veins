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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.Db.Models;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.BPVHip;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using WpfApp2.ViewModels.Panels;
using Xceed.Words.NET;

namespace WpfApp2.ViewModels
{
    //public struct docs
    //{
    //    public Doctor doc;
    //    public docs(Doctor doc)
    //    {
    //        this.doc = doc;
    //    }
    //    public override string ToString()
    //    {
    //        string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ".";
    //        return doc.Sirname + initials;
    //    }
    //}
    public class ViewModelAddEpicriz : ViewModelBase, INotifyPropertyChanged
    {
        public DelegateCommand RevertSclerozCommand { set; get; }
        public DelegateCommand RevertAnticogulantsCommand { set; get; }
        public DelegateCommand SaveSclerozCommand { set; get; }
        public DelegateCommand SaveAnticogulantsCommand { set; get; }
        public ICommand OpenAddSclerozCommand { protected set; get; }
        public ICommand OpenAddAnticogulantsCommand { protected set; get; }
        public SclerozPanelViewModel CurrentSclerozPanelViewModel { get; protected set; }
        public AnticogulantPanelViewModel CurrentAnticogulantsPanelViewModel { get; protected set; }
        public static bool Handled = false;
        public UIElement UI;

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
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private float _e1;
        private float _e2;
        private int _days;
        public float E1
        {
            get { return _e1; }
            set
            {
                _e1 = value;

                OnPropertyChanged();
            }
        }
        public float E2
        {
            get { return _e2; }
            set
            {
                _e2 = value;

                OnPropertyChanged();
            }
        }
        public int Days
        {
            get { return _days; }
            set
            {
                _days = value;

                OnPropertyChanged();
            }
        }
        public string Антикоагулянты { get; set; }

        public string FullScrelizovanie { get; set; }
        public string Svetoootvod { get; set; }


        public ObservableCollection<Docs> _doctors;
        public ObservableCollection<Docs> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }


        private int _doctorSelectedId;

        public int SelectedDoctor
        {
            get { return _doctorSelectedId; }
            set
            {
                _doctorSelectedId = value;
                OnPropertyChanged();
            }
        }



        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        public string operationType { get; set; }
        public Patient CurrentPatient;
        private int operationId;


        private int _sclezingIdSelected;

        private int _anticogulantIdSelected;
        public int SclezingIdSelected
        {
            get { return _sclezingIdSelected; }
            set
            {
                _sclezingIdSelected = value;

                OnPropertyChanged();
            }
        }
        public int AnticogulantIdSelected
        {
            get { return _anticogulantIdSelected; }
            set
            {
                _anticogulantIdSelected = value;

                OnPropertyChanged();
            }
        }


        private ObservableCollection<Anticogulants> _anticogulantSelected;
        private ObservableCollection<Sclezing> _sclerozSelected;

        public List<DoctorDataSource> DoctorsSelected;
        public ObservableCollection<Anticogulants> AnticogulantSelected
        {
            get { return _anticogulantSelected; }
            set
            {
                _anticogulantSelected = value;

                OnPropertyChanged();
            }
        }
        public ObservableCollection<Sclezing> SclerozSelected
        {
            get { return _sclerozSelected; }
            set
            {
                _sclerozSelected = value;

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
        private EpicrizOperation _currentDocument;

        public EpicrizOperation CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                _currentDocument = value;
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
        private string _fileNameOnly;
        private void GetOperationid(object sender, object data)
        {
            //MessageBus.Default.Call("SetClearSclazingList", null, null);
            //MessageBus.Default.Call("SetClearAnticogulanyList", null, null);
            Days = 0;
            Svetoootvod = "";
            Антикоагулянты = "";
            FullScrelizovanie = "";
            E1 = 0.0f;
            E2 = 0.0f;
            DoctorsSelected = (List<DoctorDataSource>)sender;
            if (DoctorsSelected == null)
            { DoctorsSelected = new List<DoctorDataSource>(); }
            Doctors = new ObservableCollection<Docs>();
            //
            using (var context = new MySqlContext())
            {
                OperationRepository Oprep = new OperationRepository(context);
                Operation = Oprep.Get((int)data);
                operationId = (int)data;
                DateTime bufTime = DateTime.Parse(Operation.Time);

                Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
                Date = Operation.Date;
                AnticogulantSelected = new ObservableCollection<Anticogulants>();
                SclerozSelected = new ObservableCollection<Sclezing>();
                PatientsRepository PatientsRep = new PatientsRepository(context);
                CurrentPatient = PatientsRep.Get(Operation.PatientId);
                SclezingRepository SclezingRep = new SclezingRepository(context);
                AnticogulantsRepository AntcgRep = new AnticogulantsRepository(context);
                DoctorRepository DoctorRep = new DoctorRepository(context);
                foreach (var doc in DoctorRep.GetAll)
                {
                    Doctors.Add(new Docs(doc));
                }
                foreach (var doc in AntcgRep.GetAll)
                {
                    AnticogulantSelected.Add(doc);

                }
                foreach (var doc in SclezingRep.GetAll)
                {
                    SclerozSelected.Add(doc);

                }
                if (Operation.EpicrizId != null && Operation.EpicrizId != 0)
                {
                    IsDocAdded = Visibility.Visible;
                    TextForDoWhat = "";
                    EpicrizOperationRepository StatementRep = new EpicrizOperationRepository(context);

                    CurrentDocument = StatementRep.Get(Operation.EpicrizId.Value);
                    Days = CurrentDocument.CountDays;
                    Svetoootvod = CurrentDocument.Light;
                    E1 = CurrentDocument.VT;
                    E2 = CurrentDocument.DJSM;
                    // SelectedLeg = CurrentDocument.FirstIsRightIfNull;

                    if (CurrentDocument.SclezingId != null && CurrentDocument.SclezingId != 0)
                    {
                        var doc = SclezingRep.Get(CurrentDocument.SclezingId.Value);
                        foreach (var docs in SclerozSelected)
                        {
                            if (docs.Id == doc.Id)
                            {
                                SclezingIdSelected = SclerozSelected.IndexOf(docs);
                            }
                        }
                    }

                    if (CurrentDocument.AnticogulantId != null && CurrentDocument.AnticogulantId != 0)
                    {
                        var doc = AntcgRep.Get(CurrentDocument.AnticogulantId.Value);
                        foreach (var docs in AnticogulantSelected)
                        {
                            if (docs.Id == doc.Id)
                            {
                                AnticogulantIdSelected = AnticogulantSelected.IndexOf(docs);
                            }
                        }
                    }

                    if (CurrentDocument.DoctorId != 0)
                    {
                        var doc = DoctorRep.Get(CurrentDocument.DoctorId);
                        foreach (var docs in Doctors)
                        {
                            if (docs.doc.Id == doc.Id)
                            {
                                SelectedDoctor = Doctors.IndexOf(docs);
                            }
                        }
                    }
                }
                else
                {
                    SelectedDoctor = 0;
                    IsDocAdded = Visibility.Hidden;
                    TextForDoWhat = "Сформируйте или загрузите документ";
                }




            }
            ////
            //Operation = Data.Operation.Get((int)data);
            //operationId = (int)data;
            //DateTime bufTime = DateTime.Parse(Operation.Time);

            //Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            //Date = Operation.Date;
            //operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            //TextResultCancle = "Итоги операции"; 
            //using (var context = new MySqlContext())
            //{
            //    PatientsRepository PatientsRep = new PatientsRepository(context);
            //    CurrentPatient = PatientsRep.Get(Operation.PatientId);
            //}
            //using (var context = new MySqlContext())
            //{
            //    DoctorRepository DoctorRep = new DoctorRepository(context);


            //    foreach (var doc in DoctorRep.GetAll)
            //    {
            //        if (doc.isEnabled.Value)
            //        {
            //            Doctors.Add(new Docs(doc));
            //        }
            //    }
            //}
        }

        public ViewModelAddEpicriz(NavigationController controller) : base(controller)
        {//SetAnticogulantList
         //MessageBus.Default.Subscribe("SetAnticogulantList", SetAnticogulantList);
         //MessageBus.Default.Subscribe("SetSclazingListForEpicriz", SetSclezingList);
            LostFocusE1 = new DelegateCommand<object>(
      (sender) =>
      {

          if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
          {
              ((TextBox)sender).Text = "0";
              E1 = 0;
          }


      });
            LostFocusE2 = new DelegateCommand<object>(
   (sender) =>
   {

       if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
       {
           ((TextBox)sender).Text = "0";
           E2 = 0;
       }


   });

            LostFocus = new DelegateCommand<object>(
         (sender) =>
         {

             if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
             {
                 ((TextBox)sender).Text = "0";
                 Days = 0;
             }


         }
     ); ClickOnWeight = new DelegateCommand<object>(
        (sender) =>
        {

            if (((TextBox)sender).Text == "0")
                ((TextBox)sender).Text = "";



        }
    );
            MessageBus.Default.Subscribe("GetOperationIDForAddEpicriz", GetOperationid);
            HasNavigation = false;
            SclerozSelected = new ObservableCollection<Sclezing>(Data.Sclezing.GetAll);
            AnticogulantSelected = new ObservableCollection<Anticogulants>(Data.Anticogulants.GetAll);
            ToCreateStatementCommand = new DelegateCommand(
                () =>
                {
                    //doc_templates docTemp = new doc_templates();
                    //byte[] bte = File.ReadAllBytes(@"Предоперационный_эпикриз_ЛЕВАЯ.docx");
                    //docTemp.DocTemplate = bte;
                    //Data.doc_template.Add(docTemp);
                    //Data.Complete();








                    int togle = 0;
                    _fileNameOnly = "";
                    // string fileName = System.IO.Path.GetTeWmpPath() + Guid.NewGuid().ToString() + ".docx";
                    _fileNameOnly = "Предоперационный_эпикриз.docx";
                    string fileName = System.IO.Path.GetTempPath() + "Предоперационный_эпикриз.docx";
                    byte[] bte = new byte[1];
                    if (Operation.OnWhatLegOp == "0")
                    {
                        bte = Data.doc_template.Get(2).DocTemplate;
                    }
                    else if (Operation.OnWhatLegOp == "1")
                    {
                        bte = Data.doc_template.Get(2).DocTemplate;
                    }
                    else if (Operation.OnWhatLegOp == "2")
                    {
                        bte = Data.doc_template.Get(4).DocTemplate;
                    }


                    for (; ; )
                    {
                        try
                        {
                            if (togle == 0)
                            {
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Предоперационный_эпикриз.docx", bte);
                                _fileNameOnly = "Предоперационный_эпикриз.docx";
                            }
                            else
                            {
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Предоперационный_эпикриз" + togle + ".docx", bte);
                                _fileNameOnly = "Предоперационный_эпикриз" + togle + ".docx";
                            }
                            break;
                        }
                        catch
                        {
                            togle += 1;
                            fileName = System.IO.Path.GetTempPath() + "Предоперационный_эпикриз" + togle + ".docx";
                            _fileNameOnly = "Предоперационный_эпикриз" + togle + ".docx";
                        }
                    }


                    using (DocX document = DocX.Load(fileName))
                    {


                        document.ReplaceText("«ФИО»", CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic);
                        document.ReplaceText("«Возраст»", CurrentPatient.Age.ToString());


                        //document.ReplaceText("область", "область " + Data.Regions.Get(CurrentPatient.Region).Str);
                        //if (CurrentPatient.District != null)
                        //    document.ReplaceText("район", "район " + Data.Districts.Get(CurrentPatient.District.Value).Str);
                        //else
                        //{
                        //    document.ReplaceText("район,", "");
                        //}
                        //document.ReplaceText("місто(село)", "місто(село) " + Data.Cities.Get(CurrentPatient.City).Str);
                        //document.ReplaceText("вулиця", "вулиця " + Data.Streets.Get(CurrentPatient.Street).Str);
                        //document.ReplaceText("будинок", "будинок " + CurrentPatient.House);
                        //document.ReplaceText("кв.", "кв. " + CurrentPatient.Flat.ToString());
                        //if (CurrentPatient.Work != null)
                        //    document.ReplaceText("МестоРаботы", CurrentPatient.Work);
                        //else
                        //    document.ReplaceText("МестоРаботы", "-");



                        string lettersLeft = "";
                        string lettersRight = "";
                        string BPVRight = "";
                        string BPVLeft = "";
                        using (var context = new MySqlContext())
                        {
                            ExaminationRepository ExamRep = new ExaminationRepository(context);
                            ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);
                            //BPV

                            LettersRepository LettersRep = new LettersRepository(context);
                            var ExamsOfCurrPatient = ExamRep.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                            if (ExamsOfCurrPatient.Count > 0)
                            {
                                DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                                var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                                ExaminationLeg leftLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                                ExaminationLeg rightLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);
                                BPVHipEntryFullRepository BPVRep = new BPVHipEntryFullRepository(context);
                                BPVHipWayRepository BPVWayRep = new BPVHipWayRepository(context);
                                Letters bufLetter = new Letters();

                                if (leftLegExam.BPVHip != null)
                                {
                                    var bpvLeft = BPVRep.Get(leftLegExam.BPVHip.Value);
                                    if (bpvLeft.WayID != null)
                                    {
                                        document.ReplaceText("«Гибрид2»", BPVWayRep.Get(bpvLeft.WayID.Value).Name);
                                    }
                                }
                                else
                                {
                                    document.ReplaceText("«Гибрид2»", "");

                                }
                                if (rightLegExam.BPVHip != null)
                                {
                                    var bpvRight = BPVRep.Get(rightLegExam.BPVHip.Value);
                                    if (bpvRight.WayID != null)
                                    {
                                        document.ReplaceText("«Гибрид»", BPVWayRep.Get(bpvRight.WayID.Value).Name);
                                    }
                                }
                                else
                                {
                                    document.ReplaceText("«Гибрид»", "");
                                }

                                if (leftLegExam.C != null)
                                {
                                    bufLetter = LettersRep.Get(leftLegExam.C.Value);
                                    lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                                }
                                if (leftLegExam.A != null)
                                {
                                    bufLetter = LettersRep.Get(leftLegExam.A.Value);
                                    lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                                }
                                if (leftLegExam.E != null)
                                {
                                    bufLetter = LettersRep.Get(leftLegExam.E.Value);
                                    lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                                }
                                if (leftLegExam.P != null)
                                {
                                    bufLetter = LettersRep.Get(leftLegExam.P.Value);
                                    lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                                }

                                if (rightLegExam.C != null)
                                {
                                    bufLetter = LettersRep.Get(rightLegExam.C.Value);
                                    lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                                }
                                if (rightLegExam.A != null)
                                {
                                    bufLetter = LettersRep.Get(rightLegExam.A.Value);
                                    lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                                }
                                if (rightLegExam.E != null)
                                {
                                    bufLetter = LettersRep.Get(rightLegExam.E.Value);
                                    lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                                }
                                if (rightLegExam.P != null)
                                {
                                    bufLetter = LettersRep.Get(rightLegExam.P.Value);
                                    lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                                }

                            }

                        }

                        document.ReplaceText("«Заключение_слева»", lettersLeft);

                        document.ReplaceText("«Заключение_справа»", lettersRight);

                        document.ReplaceText("«Дата_операции»", Operation.Date.ToString());

                        if (CurrentPatient.Gender.ToLower() == "м")
                        {
                            document.ReplaceText("«ась»", "ся");
                            document.ReplaceText("«ки» ", "a ");
                        }
                        else
                        {
                            document.ReplaceText("«ась»", "ась");

                            document.ReplaceText("«ки» ", "ки ");

                        }
                        char[] chararr = CurrentPatient.Age.ToString().ToCharArray();
                        try
                        {
                            string agelastNumb = chararr[chararr.Length - 1].ToString();
                            float buff = 0f;
                            if (float.TryParse(agelastNumb, out buff))
                            {
                                if (CurrentPatient.Age >= 10 && CurrentPatient.Age <= 19)
                                {
                                    document.ReplaceText("«лет»", "лет");
                                }
                                else if (buff == 1)
                                { document.ReplaceText("«лет»", "год"); }
                                else if (buff >= 2 && buff <= 4)
                                {
                                    document.ReplaceText("«лет»", "года");
                                }
                                else if (buff == 0 || (buff >= 5 && buff <= 9))
                                {
                                    document.ReplaceText("«лет»", "лет");
                                }
                            }
                        }
                        catch { }



                        //if (!string.IsNullOrWhiteSpace(Data.OperationType.Get(Operation.OperationTypeId).ShortName))
                        //    document.ReplaceText("«Операция2»", Data.OperationType.Get(Operation.OperationTypeId).ShortName);
                        //else
                        //    document.ReplaceText("«Операция2»", Data.OperationType.Get(Operation.OperationTypeId).LongName);

                        document.ReplaceText("«Анестетик»", Data.Anestethic.Get(Operation.AnestheticId).Str);
                        if (AnticogulantIdSelected != 0)
                            document.ReplaceText("«Антикоагулянты»", AnticogulantSelected[AnticogulantIdSelected].Str);
                        else
                            document.ReplaceText("«Антикоагулянты»", "");
                        document.ReplaceText("«E1»", E1.ToString());
                        document.ReplaceText("«E2»", E2.ToString());
                        document.ReplaceText("«E12»", E1.ToString());
                        document.ReplaceText("«E22»", E2.ToString());
                        document.ReplaceText("«световод»", Svetoootvod);
                        document.ReplaceText("«световод2»", Svetoootvod);
                        string brigade = "";
                        int ix = 0;
                        foreach (var brg in DoctorsSelected)
                        {
                            if (ix != 0)
                                brigade += ", " + brg.Surname + " " + brg.initials;
                            else
                            {
                                brigade += brg.Surname + " " + brg.initials;
                            }
                            ++ix;
                        }
                        document.ReplaceText("«Бригада»", brigade);


                        document.ReplaceText("«сутки»", Days.ToString());
                        document.ReplaceText("«Врач»", Doctors[SelectedDoctor].ToString());

                        if (SclezingIdSelected != 0)
                        {
                            document.ReplaceText("«PNS»", SclerozSelected[SclezingIdSelected].Str);

                            document.ReplaceText("«PNS2»", SclerozSelected[SclezingIdSelected].Str);
                        }
                        else
                        {
                            document.ReplaceText("«PNS»", "");
                            document.ReplaceText("«PNS2»", "");
                        }
                        int i1 = 0;
                        int i2 = 0;
                        string leftP = "";
                        string rightP = "";
                        foreach (var Diagnosis in Data.OperationTypeOperations.GetAll)
                        {
                            if (Diagnosis.id_операции == Operation.Id)
                            {
                                if (Diagnosis.isLeft == true)
                                {
                                    if (i1 != 0)
                                        leftP += ", " + Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                                    else
                                    {
                                        leftP += Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                                    }
                                    i1++;
                                }
                                else
                                {
                                    if (i2 != 0)
                                        rightP += ", " + Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                                    else
                                    {
                                        rightP += Data.OperationType.Get(Diagnosis.id_типОперации.Value).Str;
                                    }
                                    i2++;
                                }
                            }
                        }
                        if (Operation.OnWhatLegOp == "0")
                        {
                            operationType = "На левую ногу :" + leftP;
                            document.ReplaceText("«IsLeft»", "ЛЕВАЯ");

                        }
                        if (Operation.OnWhatLegOp == "1")
                        {
                            operationType = "На правую ногу :" + rightP;
                            document.ReplaceText("«IsLeft»", "ПРАВАЯ");
                        }
                        if (Operation.OnWhatLegOp == "2")
                        {
                            operationType = "На левую ногу :" + leftP + " " + "На правую ногу :" + rightP;
                        }

                        document.ReplaceText("«Операция2»", operationType);


                        document.ReplaceText("«Минифлебэктомия»", leftP);




                        document.ReplaceText("«Минифлебэктомия2»", rightP);

                        //область

                        document.Save();
                        byte[] bteToBD = File.ReadAllBytes(fileName);
                        //Release this document from memory.
                        using (var context = new MySqlContext())
                        {
                            EpicrizOperationRepository HirurgOverviewRep = new EpicrizOperationRepository(context);
                            EpicrizOperation Hv = new EpicrizOperation();
                            if (Operation.EpicrizId != null && Operation.EpicrizId != 0)
                            {
                                Hv = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                                Hv.CountDays = Days;
                                Hv.VT = E1;
                                Hv.DJSM = E2;
                                Hv.Light = Svetoootvod;
                                Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                                Hv.DocTemplate = bteToBD;
                                Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                Data.Complete();
                            }
                            else
                            {

                                Hv.DocTemplate = bteToBD;
                                Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                Hv.CountDays = Days;
                                Hv.VT = E1;
                                Hv.DJSM = E2;
                                Hv.Light = Svetoootvod;
                                Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                                Data.EpicrizOperation.Add(Hv);

                                Data.Complete();
                                Operation = Data.Operation.Get(Operation.Id);
                                Operation.EpicrizId = Hv.Id;
                                Data.Complete();
                            }
                        }
                        //Release this document from memory.
                        IsDocAdded = Visibility.Visible;

                        Process.Start("WINWORD.EXE", fileName);
                        GetOperationid(DoctorsSelected, Operation.Id);
                        TextForDoWhat = "Вы создали новый документ " + _fileNameOnly;
                    }

                    //MessageBus.Default.Call("GetOperationResultForCreateStatement", this, operationId);
                    // Controller.NavigateTo<ViewModelCreateStatement>();
                }
            );
            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    //GetObsForOverview
                    Controller.NavigateTo<ViewModelOperationOverview>();
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
                                EpicrizOperationRepository HirurgOverviewRep = new EpicrizOperationRepository(context);
                                EpicrizOperation Hv = new EpicrizOperation();

                                if (CurrentDocument.Id != 0)
                                {
                                    Hv = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                                    Hv.CountDays = Days;
                                    Hv.VT = E1;
                                    Hv.DJSM = E2;
                                    Hv.Light = Svetoootvod;
                                    Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                    Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                                    Hv.DocTemplate = bteToBD;
                                    Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                    Data.Complete();
                                    CurrentDocument.DocTemplate = Hv.DocTemplate;
                                    CurrentDocument.Id = Hv.Id;
                                }
                                else
                                {

                                    Hv.DocTemplate = bteToBD;
                                    Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                    Hv.CountDays = Days;
                                    Hv.VT = E1;
                                    Hv.DJSM = E2;
                                    Hv.Light = Svetoootvod;
                                    Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                    Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                                    Data.EpicrizOperation.Add(Hv);

                                    Data.Complete();
                                    CurrentDocument.Id = Hv.Id;
                                    CurrentDocument.DocTemplate = Hv.DocTemplate;
                                    Operation = Data.Operation.Get(Operation.Id);
                                    Operation.EpicrizId = Hv.Id;
                                    Data.Complete();
                                }

                            }

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
                 EpicrizOperationRepository HirurgOverviewRep = new EpicrizOperationRepository(context);
                 EpicrizOperation Hv = new EpicrizOperation();

                 if (CurrentDocument.Id != 0)
                 {
                     Hv = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                     Hv.CountDays = Days;
                     Hv.VT = E1;
                     Hv.DJSM = E2;
                     Hv.Light = Svetoootvod;
                     Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                     Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                     Hv.DocTemplate = bteToBD;
                     Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                     Data.Complete();
                     CurrentDocument.Id = Hv.Id;
                 }
                 else
                 {

                     Hv.DocTemplate = bteToBD;
                     Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                     Hv.CountDays = Days;
                     Hv.VT = E1;
                     Hv.DJSM = E2;
                     Hv.Light = Svetoootvod;
                     Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                     Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                     Data.EpicrizOperation.Add(Hv);

                     Data.Complete();
                     CurrentDocument.Id = Hv.Id;
                     Operation = Data.Operation.Get(Operation.Id);
                     Operation.EpicrizId = Hv.Id;
                     Data.Complete();
                 }
                 //    Hv = Data.EpicrizOperation.Get(CurrentDocument.Id);

                 //    Hv.DocTemplate = bteToBD;
                 //    Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                 //    Hv.FirstIsRightIfNull = SelectedLeg;
                 //    Hv.CountDays = Days;
                 //    Data.Complete();
                 //    CurrentDocument.Id = Hv.Id;
                 //}
                 //else
                 //{
                 //    Hv.DocTemplate = bteToBD;
                 //    Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                 //    Hv.FirstIsRightIfNull = SelectedLeg;
                 //    Hv.CountDays = Days;
                 //    Data.StatementOperation.Add(Hv);

                 //    Data.Complete();
                 //    CurrentDocument.Id = Hv.Id;
                 //    Operation = Data.Operation.Get(Operation.Id);
                 //    Operation.StatementId = Hv.Id;
                 //    Data.Complete();
                 //}
                 GetOperationid(DoctorsSelected, Operation.Id);
             }

             TextForDoWhat = "Был загружен документ " + _fileNameOnly;
         }


     }
 );
            OpenWordDocument = new DelegateCommand(
        () =>
        {
            int togle = 0;

            FileName = System.IO.Path.GetTempPath() + "Предоперационный_эпикриз.docx";

            _fileNameOnly = "Предоперационный_эпикриз.docx";

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
                    FileName = System.IO.Path.GetTempPath() + "Предоперационный_эпикриз" + togle + ".docx";
                    _fileNameOnly = "Предоперационный_эпикриз" + togle + ".docx";
                }
            }
            Process.Start("WINWORD.EXE", FileName);
        }
    );



















            CurrentSclerozPanelViewModel = new SclerozPanelViewModel(this);
            OpenAddSclerozCommand = new DelegateCommand(() =>
            {
                CurrentSclerozPanelViewModel.ClearPanel();
                CurrentSclerozPanelViewModel.PanelOpened = true;
            });

            SaveSclerozCommand = new DelegateCommand(() =>
            {
                var newType = CurrentSclerozPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentSclerozPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.Sclezing.Add((newType));

                    Data.Complete();

                    //var DataSourceListbuf = Sclerozializations;
                    SclerozSelected = new ObservableCollection<Sclezing>();

                    foreach (var Scleroz in Data.Sclezing.GetAll)
                    {
                        SclerozSelected.Add(Scleroz);
                    }
                    SclezingIdSelected = SclerozSelected.Count;
                    //foreach (var Scleroz in DataSourceListbuf)
                    //{
                    //    if (Scleroz.IsChecked.Value)
                    //    {
                    //        Sclerozializations.Where(s => s.id == Scleroz.id).ToList()[0].IsChecked = true;
                    //    }
                    //}

                    Controller.NavigateTo<ViewModelAddEpicriz>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertSclerozCommand = new DelegateCommand(() =>
            {
                CurrentSclerozPanelViewModel.PanelOpened = false;
                Handled = false;
            });


            CurrentAnticogulantsPanelViewModel = new AnticogulantPanelViewModel(this);
            OpenAddAnticogulantsCommand = new DelegateCommand(() =>
            {
                CurrentAnticogulantsPanelViewModel.ClearPanel();
                CurrentAnticogulantsPanelViewModel.PanelOpened = true;
            });

            SaveAnticogulantsCommand = new DelegateCommand(() =>
            {
                var newType = CurrentAnticogulantsPanelViewModel.GetPanelType();
                if (!string.IsNullOrWhiteSpace(newType.Str))
                {
                    CurrentAnticogulantsPanelViewModel.PanelOpened = false;

                    Handled = false;

                    Data.Anticogulants.Add((newType));

                    Data.Complete();

                    //var DataSourceListbuf = AnticogulantSelected;
                    AnticogulantSelected = new ObservableCollection<Anticogulants>();

                    foreach (var Scintific in Data.Anticogulants.GetAll)
                    {
                        AnticogulantSelected.Add(Scintific);
                    }
                    AnticogulantIdSelected = AnticogulantSelected.Count;
                    //foreach (var Scintific in DataSourceListbuf)
                    //{
                    //    if (Scintific.IsChecked.Value)
                    //    {
                    //        AnticogulantSelected.Where(s => s.Data.Id == Scintific.Data.Id).ToList()[0].IsChecked = true;
                    //    }
                    //}

                    Controller.NavigateTo<ViewModelAddEpicriz>();
                }
                else
                { MessageBox.Show("Не все поля заполнены"); }
            });
            RevertAnticogulantsCommand = new DelegateCommand(() =>
            {
                CurrentAnticogulantsPanelViewModel.PanelOpened = false;
                Handled = false;
            });


        }
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToCreateStatementCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand SaveWordDocument { get; private set; }
        public DelegateCommand OpenFile { get; private set; }
        public DelegateCommand OpenWordDocument { get; private set; }
        public DelegateCommand ToSetSclezindCommand { get; private set; }
        public DelegateCommand ToSetAugmentedRealytyCommand { get; }
        public DelegateCommand<object> LostFocus { get; private set; }
        public DelegateCommand<object> LostFocusE1 { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }
        public DelegateCommand<object> LostFocusE2 { get; private set; }
    }
}
