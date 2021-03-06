﻿using Microsoft.Practices.Prism.Commands;
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

        public SclerozPanelViewModel CurrentSavePanelViewModel { get; protected set; }
        public ICommand OpenAddSaveCommand { protected set; get; }
        public DelegateCommand RevertSaveCommand { set; get; }
        //    public DelegateCommand SaveChangesInDockCommand { set; get; }

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

        private string _svetoootvod;

        public string Svetoootvod
        {
            get { return _svetoootvod; }
            set
            {
                _svetoootvod = value;

                OnPropertyChanged();
            }
        }

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
        public Patient CurrentPatient { get; set; }
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

        private IEnumerable<String> _svetofvodDiabetCommentList;
        public IEnumerable<String> SvetofvodCommentList { get { return _svetofvodDiabetCommentList; } set { _svetofvodDiabetCommentList = value; OnPropertyChanged(); } }


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
        //CommentaryForDock   
        private string _commentaryForDock;

        public string CommentaryForDock
        {
            get { return _commentaryForDock; }
            set
            {
                _commentaryForDock = value;
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
            List<String> buff3 = new List<string>();
            foreach (var x in Data.Svetovod.GetAll)
                buff3.Add(x.Str);
            SvetofvodCommentList = buff3;

            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            //DateTime bufTime = DateTime.Parse(Operation.Time);

            //Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Data.OperationDateTime.Get(Operation.Datetime_id.Value).Datetime;
            AnticogulantSelected = new ObservableCollection<Anticogulants>();
            SclerozSelected = new ObservableCollection<Sclezing>();
            CurrentPatient = Data.Patients.Get(Operation.PatientId);
            foreach (var doc in Data.Doctor.GetAll)
            {
                Doctors.Add(new Docs(doc));
            }
            foreach (var doc in Data.Anticogulants.GetAll)
            {
                AnticogulantSelected.Add(doc);

            }
            Anticogulants emptyA = new Anticogulants();
            emptyA.Str = "";
            AnticogulantSelected.Add(emptyA);
            foreach (var doc in Data.Sclezing.GetAll)
            {
                SclerozSelected.Add(doc);


            }
            Sclezing empty = new Sclezing();
            empty.Str = "";
            SclerozSelected.Add(empty);
            if (Operation.EpicrizId != null && Operation.EpicrizId != 0)
            {
                IsDocAdded = Visibility.Visible;
                TextForDoWhat = "";
                CurrentDocument = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                if (CurrentDocument.Commentary != null)
                {
                    CommentaryForDock = CurrentDocument.Commentary;
                }
                else
                {
                    CommentaryForDock = "";
                }
                Days = CurrentDocument.CountDays;
                Svetoootvod = CurrentDocument.Light;
                E1 = CurrentDocument.VT;
                E2 = CurrentDocument.DJSM;
                // SelectedLeg = CurrentDocument.FirstIsRightIfNull;

                if (CurrentDocument.SclezingId != null && CurrentDocument.SclezingId != 0)
                {
                    var doc = Data.Sclezing.Get(CurrentDocument.SclezingId.Value);
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
                    var doc = Data.Anticogulants.Get(CurrentDocument.AnticogulantId.Value);
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
                    var doc = Data.Doctor.Get(CurrentDocument.DoctorId);
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
        public SclerozPanelViewModel CurrentSelectDoctorPanelViewModel { get; protected set; }
        public ICommand OpenSelectDoctorCommand { protected set; get; }
        public DelegateCommand RevertSelectDoctorCommand { set; get; }

        public ViewModelAddEpicriz(NavigationController controller) : base(controller)
        {//SetAnticogulantList


            CurrentSelectDoctorPanelViewModel = new SclerozPanelViewModel(this);

            RevertSelectDoctorCommand = new DelegateCommand(() =>
            {
                CurrentSelectDoctorPanelViewModel.PanelOpened = false;
            });
            OpenSelectDoctorCommand = new DelegateCommand(() =>
            {
                CurrentSelectDoctorPanelViewModel.ClearPanel();
                CurrentSelectDoctorPanelViewModel.PanelOpened = true;
            });
            //MessageBus.Default.Subscribe("SetAnticogulantList", SetAnticogulantList);
            //MessageBus.Default.Subscribe("SetSclazingListForEpicriz", SetSclezingList);
            LostFocusE1 = new DelegateCommand<object>(
      (sender) =>
      {

          if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
          {
              ((TextBox)sender).Text = "0.0";
              E1 = 0f;
          }


      });
            LostFocusE2 = new DelegateCommand<object>(
   (sender) =>
   {

       if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
       {
           ((TextBox)sender).Text = "0.0";
           E2 = 0f;
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

                        FileName = fileName;

                        document.ReplaceText("суток", "суток.\n");
                        document.ReplaceText("произведена", "произведена операция:");
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
                        //string BPVRight = "";
                        //string BPVLeft = "";
                        //BPV

                        var ExamsOfCurrPatient = Data.Examination.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                        if (ExamsOfCurrPatient.Count > 0)
                        {
                            DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                            var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                            ExaminationLeg leftLegExam = Data.ExaminationLeg.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                            ExaminationLeg rightLegExam = Data.ExaminationLeg.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);
                            Letters bufLetter = new Letters();

                            if (leftLegExam.BPVHip != null)
                            {
                                var bpvLeft = Data.BPVHipsFull.Get(leftLegExam.BPVHip.Value);
                                if (bpvLeft.WayID != null)
                                {
                                    document.ReplaceText("«Гибрид2»", Data.BPVHipWay.Get(bpvLeft.WayID.Value).Name);
                                }
                            }
                            else
                            {
                                document.ReplaceText("«Гибрид2»", "");

                            }
                            if (rightLegExam.BPVHip != null)
                            {
                                var bpvRight = Data.BPVHipsFull.Get(rightLegExam.BPVHip.Value);
                                if (bpvRight.WayID != null)
                                {
                                    document.ReplaceText("«Гибрид»", Data.BPVHipWay.Get(bpvRight.WayID.Value).Name);
                                }
                            }
                            else
                            {
                                document.ReplaceText("«Гибрид»", "");
                            }
                            List<DiagnosisType> LeftDiagnosisList = new List<DiagnosisType>();

                            foreach (var diag in Data.Diagnosis.GetAll.Where(s => s.isLeft == true && s.id_operation == Operation.Id).ToList())
                            {

                                LeftDiagnosisList.Add(Data.DiagnosisTypes.Get(diag.id_diagnosis.Value));
                            }

                            List<DiagnosisType> RightDiagnosisList = new List<DiagnosisType>();



                            foreach (var diag in Data.Diagnosis.GetAll.Where(s => s.isLeft == false && s.id_operation == Operation.Id).ToList())
                            {

                                RightDiagnosisList.Add(Data.DiagnosisTypes.Get(diag.id_diagnosis.Value));
                            }

                            int xx = 0;
                            foreach (var x in LeftDiagnosisList)
                            {
                                if (xx == 0)
                                {
                                    lettersLeft += FirstCharToUpper(GetStrFixedForDocumemnt(x.Str));
                                }
                                else
                                {
                                    lettersLeft += ", " + GetStrFixedForDocumemnt(x.Str);
                                }
                                xx++;
                            }
                            char[] chararrbuF = lettersLeft.ToCharArray();
                            if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                            {
                                lettersLeft = lettersLeft.Remove(0, 1);

                            }
                            if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                            { }
                            else
                            {
                                //  lettersLeft += ".";
                            }

                            lettersLeft += " ";
                            xx = 0;
                            foreach (var x in RightDiagnosisList)
                            {
                                if (xx == 0)
                                {
                                    lettersRight += GetStrFixedForDocumemnt(x.Str);
                                }
                                else
                                {
                                    lettersRight += ", " + GetStrFixedForDocumemnt(x.Str);
                                }
                                xx++;
                            }
                            chararrbuF = lettersRight.ToCharArray();
                            if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                            {
                                lettersRight = lettersRight.Remove(0, 1);

                            }
                            if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                            { }
                            else
                            {
                                //  lettersRight += ".";
                            }

                            lettersRight += " ";

                            if (leftLegExam.C != null)
                            {
                                bufLetter = Data.Letters.Get(leftLegExam.C.Value);
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (leftLegExam.A != null)
                            {
                                bufLetter = Data.Letters.Get(leftLegExam.A.Value);
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (leftLegExam.E != null)
                            {
                                bufLetter = Data.Letters.Get(leftLegExam.E.Value);
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (leftLegExam.P != null)
                            {
                                bufLetter = Data.Letters.Get(leftLegExam.P.Value);
                                lettersLeft += bufLetter.Leter + bufLetter.Text1 + " ";
                            }

                            if (rightLegExam.C != null)
                            {
                                bufLetter = Data.Letters.Get(rightLegExam.C.Value);
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (rightLegExam.A != null)
                            {
                                bufLetter = Data.Letters.Get(rightLegExam.A.Value);
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (rightLegExam.E != null)
                            {
                                bufLetter = Data.Letters.Get(rightLegExam.E.Value);
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }
                            if (rightLegExam.P != null)
                            {
                                bufLetter = Data.Letters.Get(rightLegExam.P.Value);
                                lettersRight += bufLetter.Leter + bufLetter.Text1 + " ";
                            }

                        }
                        else
                        {
                            document.ReplaceText("«Гибрид»", "");
                            document.ReplaceText("«Гибрид2»", "");

                        }

                        document.ReplaceText("«Заключение_слева»", lettersLeft + "\n");

                        document.ReplaceText("«Заключение_справа»", lettersRight + "\n");

                        document.ReplaceText("«Дата_операции»", Data.OperationDateTime.Get(Operation.Datetime_id.Value).Datetime.ToString());

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

                        try
                        {
                            document.ReplaceText("«Антикоагулянты»", AnticogulantSelected[AnticogulantIdSelected].Str);
                        }
                        catch
                        {
                            document.ReplaceText("«Антикоагулянты».", "");
                        }
                        int numerator = 1;

                        if (E1 != 0f || E2 != 0f || !string.IsNullOrWhiteSpace(Svetoootvod))
                        {
                            string res = "";
                            res += numerator + ") ЭВЛА ";
                            if (E1 != 0f)
                            {

                                res += E1.ToString() + " Вт ";
                            }
                            if (E2 != 0f)
                            {
                                res += E2.ToString() + " Дж/см";
                            }
                            if (!string.IsNullOrWhiteSpace(Svetoootvod))
                            {
                                res += ",\n" + Svetoootvod + " световод";
                            }
                            document.ReplaceText("«POS1»", res + "\n\n«POS1»");
                            document.ReplaceText("«POS2»", res + "\n\n«POS2»");
                            //document.ReplaceText("«E2»", E2.ToString());
                            //document.ReplaceText("«E12»", E1.ToString());
                            //document.ReplaceText("«E22»", E2.ToString());
                            //document.ReplaceText("«световод»", Svetoootvod);
                            //document.ReplaceText("«световод2»", Svetoootvod);
                            numerator++;
                        }


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

                        if (Days != 0)
                            document.ReplaceText("«сутки»", Days.ToString());
                        else
                            document.ReplaceText("Рекомендовано дебандажирование на «сутки» суток.", "");
                        document.ReplaceText("«Врач»", Doctors[SelectedDoctor].ToString());
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(SclerozSelected[SclezingIdSelected].ToString()))
                            {
                                string tesr = (!string.IsNullOrWhiteSpace(CommentaryForDock)) ? " Комментарий : " + CommentaryForDock : "";
                                document.ReplaceText("«POS1»", numerator + ") Пенное склерозирование: " + SclerozSelected[SclezingIdSelected].ToString() + tesr + "\n\n«POS1»");

                                document.ReplaceText("«POS2»", numerator + ") Пенное склерозирование: " + SclerozSelected[SclezingIdSelected].ToString() + tesr + "\n\n«POS2»");
                                numerator++;
                            }
                            
                        }
                        catch
                        {
                            //document.ReplaceText("«POS1»", "");
                            //document.ReplaceText("«POS2»", "");
                        }
                        int i1 = 0;
                        int i2 = 0;
                        string leftP = "";
                        string rightP = "";
                        foreach (var Diagnosis in Data.OperationTypeOperations.GetAll)
                        {
                            if (Diagnosis.id_operation == Operation.Id)
                            {
                                if (Diagnosis.isLeft == true)
                                {
                                    i1++;
                                    //if (i1 != 0)
                                    //    leftP += ", " + GetStrFixedForDocumemnt(Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str);
                                    //else
                                    //{
                                    leftP += i1.ToString() + ". " + GetStrFixedForDocumemnt(Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str) + "\n";
                                    //}

                                }
                                else
                                {
                                    i2++;
                                    //if (i2 != 0)
                                    //    rightP += ", " + GetStrFixedForDocumemnt(Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str);
                                    //else
                                    //{

                                    rightP += i2.ToString() + ". " + GetStrFixedForDocumemnt(Data.OperationType.Get(Diagnosis.id_operation_type.Value).Str) + "\n";
                                    //}

                                }
                            }
                        }





                        if (Operation.OnWhatLegOp == "0")
                        {
                            operationType = "\n" + leftP + "левой нижней конечности.\n";
                            document.ReplaceText("«IsLeft»", "ЛЕВАЯ");

                        }
                        if (Operation.OnWhatLegOp == "1")
                        {
                            operationType = "\n" + rightP + "правой нижней конечности.\n";
                            document.ReplaceText("«IsLeft»", "ПРАВАЯ");
                        }
                        if (Operation.OnWhatLegOp == "2")
                        {
                            operationType = "\n" + rightP + "правой нижней конечности.\n" + "" + leftP + "левой нижней конечности.\n";
                        }

                        document.ReplaceText("«Операция2»", operationType);


                        document.ReplaceText("«POS1»", numerator + ") Проведены операции: \n" + leftP);




                        document.ReplaceText("«POS2»", numerator + ") Проведены операции: \n" + rightP);

                        //область

                        document.Save();
                        byte[] bteToBD = File.ReadAllBytes(fileName);
                        //Release this document from memory.
                        EpicrizOperation Hv = new EpicrizOperation();

                        bool xtestx = false;
                        foreach (var x in SvetofvodCommentList)
                        {
                            if (x == Svetoootvod)
                            {
                                xtestx = true;
                                break;
                            }
                        }
                        if (!xtestx)
                        {
                            if (!string.IsNullOrWhiteSpace(Svetoootvod))
                            {
                                var bff = new Svetovod();
                                bff.Str = Svetoootvod;
                                Data.Svetovod.Add(bff);
                                Data.Complete();
                            }
                        }


                        if (Operation.EpicrizId != null && Operation.EpicrizId != 0)
                        {
                            Hv = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                            Hv.CountDays = Days;
                            Hv.VT = E1;
                            Hv.DJSM = E2;
                            Hv.Light = Svetoootvod;
                            Hv.Commentary = CommentaryForDock;
                            try
                            {
                                Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                            }
                            catch { }
                            Hv.DocTemplate = bteToBD;
                            Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                            Data.Complete();
                        }
                        else
                        {
                            Hv.Commentary = CommentaryForDock;
                            Hv.DocTemplate = bteToBD;
                            Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                            Hv.CountDays = Days;
                            Hv.VT = E1;
                            Hv.DJSM = E2;
                            Hv.Light = Svetoootvod;
                            try
                            {
                                Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                            }
                            catch { }
                            Data.EpicrizOperation.Add(Hv);

                            Data.Complete();
                            Operation = Data.Operation.Get(Operation.Id);
                            Operation.EpicrizId = Hv.Id;
                            Data.Complete();
                        }
                        //Release this document from memory.
                        IsDocAdded = Visibility.Visible;

                        Process.Start("WINWORD.EXE", fileName);
                        GetOperationid(DoctorsSelected, Operation.Id);
                        TextForDoWhat = "Вы создали новый документ " + _fileNameOnly;
                    }
                    CurrentSelectDoctorPanelViewModel.PanelOpened = false;
                    //MessageBus.Default.Call("GetOperationResultForCreateStatement", this, operationId);
                    // Controller.NavigateTo<ViewModelCreateStatement>();
                }
            );
            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    if (!string.IsNullOrWhiteSpace(FileName))
                    {
                        MessageBoxResult dialogResult = MessageBox.Show("Вы сохранили изменения в документе?", "", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                            //GetObsForOverview
                            Controller.NavigateTo<ViewModelOperationOverview>();
                            FileName = "";
                        }
                    }
                    else
                    {

                        MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                        //GetObsForOverview
                        Controller.NavigateTo<ViewModelOperationOverview>();
                        FileName = "";
                    }
                }
            );
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
            SaveWordDocument = new DelegateCommand(
                () =>
                {
                    try
                    {

                        if (!string.IsNullOrWhiteSpace(FileName))
                        {
                            byte[] bteToBD = File.ReadAllBytes(FileName);
                            EpicrizOperation Hv = new EpicrizOperation();

                            bool xtestx = false;
                            foreach (var x in SvetofvodCommentList)
                            {
                                if (x == Svetoootvod)
                                {
                                    xtestx = true;
                                    break;
                                }
                            }
                            if (!xtestx)
                            {
                                if (!string.IsNullOrWhiteSpace(Svetoootvod))
                                {
                                    var bff = new Svetovod();
                                    bff.Str = Svetoootvod;
                                    Data.Svetovod.Add(bff);
                                    Data.Complete();
                                }
                            }

                            if (CurrentDocument.Id != 0)
                            {
                                Hv = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                                Hv.CountDays = Days;
                                Hv.VT = E1;
                                Hv.DJSM = E2;
                                Hv.Light = Svetoootvod;
                                Hv.Commentary = CommentaryForDock;
                                try
                                {
                                    Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                    Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                                }
                                catch { }
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
                                Hv.Commentary = CommentaryForDock;
                                Hv.DJSM = E2;
                                Hv.Light = Svetoootvod;
                                try
                                {
                                    Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                                    Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                                }
                                catch { }
                                Data.EpicrizOperation.Add(Hv);

                                Data.Complete();
                                CurrentDocument.Id = Hv.Id;
                                CurrentDocument.DocTemplate = Hv.DocTemplate;
                                Operation = Data.Operation.Get(Operation.Id);
                                Operation.EpicrizId = Hv.Id;
                                Data.Complete();
                            }

                            TextForDoWhat = "Изменения в " + _fileNameOnly + " были сохранены";
                        }
                        else
                        {


                        }
                        CurrentSavePanelViewModel.PanelOpened = false;
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
                EpicrizOperation Hv = new EpicrizOperation();
                //CurrentPatient.Sugar = Sugar;
                bool xtestx = false;
                foreach (var x in SvetofvodCommentList)
                {
                    if (x == Svetoootvod)
                    {
                        xtestx = true;
                        break;
                    }
                }
                if (!xtestx)
                {
                    if (!string.IsNullOrWhiteSpace(Svetoootvod))
                    {
                        var bff = new Svetovod();
                        bff.Str = Svetoootvod;
                        Data.Svetovod.Add(bff);
                        Data.Complete();
                    }
                }
                if (CurrentDocument.Id != 0)
                {
                    Hv = Data.EpicrizOperation.Get(Operation.EpicrizId.Value);
                    Hv.CountDays = Days;
                    Hv.VT = E1;
                    Hv.DJSM = E2;
                    Hv.Commentary = CommentaryForDock;
                    Hv.Light = Svetoootvod;
                    try
                    {
                        Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                        Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                    }
                    catch { }
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
                    Hv.Commentary = CommentaryForDock;
                    Hv.Light = Svetoootvod;
                    try
                    {
                        Hv.SclezingId = SclerozSelected[SclezingIdSelected].Id;
                        Hv.AnticogulantId = AnticogulantSelected[AnticogulantIdSelected].Id;
                    }
                    catch { }
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
            TextForDoWhat = "Был открыт документ " + _fileNameOnly + ". Для сохранения изменений в документе сохраните данные в Word, закройте документ и нажмите кнопку \"Сохранить изменения\".";
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
                    SclezingIdSelected = SclerozSelected.Count - 1;
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
                Handled = false;
            });

            OpenAddAnticogulantsCommand = new DelegateCommand(() =>
            {
                CurrentAnticogulantsPanelViewModel.ClearPanel();
                CurrentAnticogulantsPanelViewModel.PanelOpened = true;
            });

            //
            //SaveChangesInDockCommand = new DelegateCommand(() =>
            //{
            //    SaveWordDocument.Execute();
            //});
            //
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
                    AnticogulantIdSelected = AnticogulantSelected.Count - 1; ;
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
        string GetStrFixedForDocumemnt(string str)
        {
            List<char> chararr = str.ToLower().ToCharArray().ToList();
            if (chararr[chararr.Count - 1] == '.')
            {
                chararr.RemoveAt(chararr.Count - 1);

            }
            string result = "";
            foreach (var x in chararr)
            {
                result += x;
            }
            return result;
        }
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToCreateStatementCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand<object> ClickOnAutoComplete { get; set; }
        public DelegateCommand SaveWordDocument { get; private set; }
        public DelegateCommand OpenFile { get; private set; }
        public DelegateCommand OpenWordDocument { get; private set; }
        public DelegateCommand ToSetSclezindCommand { get; private set; }
        public DelegateCommand ToSetAugmentedRealytyCommand { get; }
        public DelegateCommand<object> LostFocus { get; private set; }
        public DelegateCommand<object> LostFocusE1 { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }
        public DelegateCommand<object> LostFocusE2 { get; private set; }
        public object MessageBoxButtons { get; }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}
