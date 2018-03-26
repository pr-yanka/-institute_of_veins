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
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using Xceed.Words.NET;

namespace WpfApp2.ViewModels
{
   
   
    public struct Docs
    {
        public Doctor doc;
        public Docs(Doctor doc)
        {
            this.doc = doc;
        }
        public override string ToString()
        {
            string initials = " " + doc.Name.ToCharArray()[0].ToString() + ". " + doc.Patronimic.ToCharArray()[0].ToString() + ".";
            return doc.Sirname + initials;
        }
    }
    public class ViewModelCreateStatement : ViewModelBase, INotifyPropertyChanged
    {
        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public List<string> LeftOrRight { get; set; }
        private int _days;
        public int Days
        {
            get { return _days; }
            set
            {
                _days = value;

                OnPropertyChanged();
            }
        }
        private StatementOperation _currentDocument;

        public StatementOperation CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                _currentDocument = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isAnalizeLoadedVisibility;
        public Visibility IsAnalizeLoadedVisibility
        {
            get
            {
                return _isAnalizeLoadedVisibility;
            }
            set { _isAnalizeLoadedVisibility = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Docs> _doctors;
        public ObservableCollection<Docs> Doctors { get { return _doctors; } set { _doctors = value; OnPropertyChanged(); } }
       
     //   public int SelectedDoctor { get; set; }
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
        public int SelectedLeg { get; set; }

        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        public string OperationType { get; set; }
        public Patient CurrentPatient;
        private int operationId;
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
        private Visibility _isDocAdded;
        private string _fileNameOnly;

        public Visibility IsDocAdded
        {
            get { return _isDocAdded; }
            set
            {
                _isDocAdded = value;
                OnPropertyChanged();
            }
        }
        private void GetOperationid(object sender, object data)
        {

            Days = 0;

            SelectedLeg = 0;
            Doctors = new ObservableCollection<Docs>();
              //OperationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            //TextResultCancle = "Итоги операции"; 
            CurrentDocument = new StatementOperation();

            using (var context = new MySqlContext())
            {
                OperationRepository Oprep = new OperationRepository(context);
                Operation = Oprep.Get((int)data);
                operationId = (int)data;
                DateTime bufTime = DateTime.Parse(Operation.Time);

                Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
                Date = Operation.Date;

                PatientsRepository PatientsRep = new PatientsRepository(context);
                CurrentPatient = PatientsRep.Get(Operation.PatientId);

                DoctorRepository DoctorRep = new DoctorRepository(context);
                foreach (var doc in DoctorRep.GetAll)
                {
                    Doctors.Add(new Docs(doc));
                }
                if (Operation.StatementId != null && Operation.StatementId != 0)
                {
                    IsDocAdded = Visibility.Visible;
                    TextForDoWhat = "";
                    StatementOperationRepository StatementRep = new StatementOperationRepository(context);
                 
                    CurrentDocument = StatementRep.Get(Operation.StatementId.Value);
                    Days = CurrentDocument.CountDays;
                    SelectedLeg = CurrentDocument.FirstIsRightIfNull;
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
        }
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
        public ViewModelCreateStatement(NavigationController controller) : base(controller)
        {
            LeftOrRight = new List<string>();
            LeftOrRight.Add("Правая нога");
            LeftOrRight.Add("Левая нога");

            MessageBus.Default.Subscribe("GetOperationResultForCreateStatement", GetOperationid);
            HasNavigation = false;
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
                                   StatementOperationRepository HirurgOverviewRep = new StatementOperationRepository(context);
                                   StatementOperation Hv = new StatementOperation();
                            //bool tester = true;

                            if (CurrentDocument.Id != 0)
                                   {
                                       Hv = Data.StatementOperation.Get(CurrentDocument.Id);
                                       CurrentDocument.DocTemplate = bteToBD;
                                       Hv.DocTemplate = bteToBD;
                                       Hv.FirstIsRightIfNull = SelectedLeg;
                                       Hv.CountDays = Days;
                                       Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                       Data.Complete();
                                   }
                                   else
                                   {

                                       Hv.FirstIsRightIfNull = SelectedLeg;
                                       Hv.CountDays = Days;
                                       Hv.DocTemplate = bteToBD;
                                       Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                       CurrentDocument.DocTemplate = bteToBD;
                                       Data.StatementOperation.Add(Hv);

                                       Data.Complete();
                                       Operation = Data.Operation.Get(Operation.Id);
                                       Operation.StatementId = Hv.Id;
                                   //    Operation.StatementId = Hv.Id;
                                       CurrentDocument.Id = Hv.Id;
                                       Data.Complete();
                                       //   MessageBus.Default.Call("SetIdOfOverview", null, CurrentDocument.Id);
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
                      StatementOperationRepository HirurgOverviewRep = new StatementOperationRepository(context);
                      StatementOperation Hv = new StatementOperation();

                      if (CurrentDocument.Id != 0)
                      {
                          Hv = Data.StatementOperation.Get(CurrentDocument.Id);

                          Hv.DocTemplate = bteToBD;
                          Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                          Hv.FirstIsRightIfNull = SelectedLeg;
                          Hv.CountDays = Days;
                          Data.Complete();
                          CurrentDocument.Id = Hv.Id;
                      }
                      else
                      {
                          Hv.DocTemplate = bteToBD;
                          Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                          Hv.FirstIsRightIfNull = SelectedLeg;
                          Hv.CountDays = Days;
                          Data.StatementOperation.Add(Hv);

                          Data.Complete();
                          CurrentDocument.Id = Hv.Id;
                          Operation = Data.Operation.Get(Operation.Id);
                          Operation.StatementId = Hv.Id;
                          Data.Complete();
                      }
                      GetOperationid(null, Operation.Id);
                  }

               //   MessageBus.Default.Call("GetHirurgOverviewForHirurgOverview", null, CurrentDocument.Id);
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
            OpenWordDocument = new DelegateCommand(
          () =>
          {
              int togle = 0;

              FileName = System.IO.Path.GetTempPath() + "Выписка_заготовка.docx";

              _fileNameOnly = "Выписка_заготовка.docx";

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
                      FileName = System.IO.Path.GetTempPath() + "Выписка_заготовка" + togle + ".docx";
                      _fileNameOnly = "Выписка_заготовка" + togle + ".docx";
                  }
              }
              Process.Start("WINWORD.EXE", FileName);
          }
      );


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


            ToCreateStatementCommand = new DelegateCommand(
                () =>
                {
                    int togle = 0;
                    _fileNameOnly = "";
                    // string fileName = System.IO.Path.GetTeWmpPath() + Guid.NewGuid().ToString() + ".docx";
                    _fileNameOnly = "Выписка_заготовка.docx";
                    string fileName = System.IO.Path.GetTempPath() + "Выписка_заготовка.docx";
                    byte[] bte = Data.doc_template.Get(1).DocTemplate;
                    //File.WriteAllBytes(fileName, bte);
                    for (; ; )
                    {
                        try
                        {
                            if (togle == 0)
                            {
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Выписка_заготовка.docx", bte);
                                _fileNameOnly = "Выписка_заготовка.docx";
                            }
                            else
                            {
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Выписка_заготовка" + togle + ".docx", bte);
                                _fileNameOnly = "Выписка_заготовка" + togle + ".docx";
                            }
                            break;
                        }
                        catch
                        {
                            togle += 1;
                            fileName = System.IO.Path.GetTempPath() + "Выписка_заготовка" + togle + ".docx";
                            _fileNameOnly = "Выписка_заготовка" + togle + ".docx";
                        }
                    }


                    using (DocX document = DocX.Load(fileName))
                    {
                        document.ReplaceText("«ФИО»", CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic);
                        string day1 = "0";
                        string day2 = "0";
                        string mnth1 = "0";
                        string mnth2 = "0";
                        string year1 = CurrentPatient.Birthday.Year.ToString();
                        string year2 = CurrentPatient.Birthday.Year.ToString();
                        if (CurrentPatient.Birthday.Day.ToString().ToCharArray().Length == 1)
                        {
                            day1 = "0";
                            day2 = CurrentPatient.Birthday.Day.ToString().ToCharArray()[0].ToString();
                        }
                        else
                        {
                            day1 = CurrentPatient.Birthday.Day.ToString().ToCharArray()[0].ToString();
                            day2 = CurrentPatient.Birthday.Day.ToString().ToCharArray()[1].ToString();
                        }//«сутки»
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

                        }

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


                        string patologis = "";
                        string diabet = "";
                        string lettersLeft = "";
                        string lettersRight = "";
                        string leftDiag = "", rightDiag = "";

                        List<DiagnosisType> LeftDiagnosisList = new List<DiagnosisType>();

                        foreach (var diag in Data.Diagnosis.GetAll.Where(s => s.isLeft == true && s.id_операции == Operation.Id).ToList())
                        {

                            LeftDiagnosisList.Add(Data.DiagnosisTypes.Get(diag.id_диагноз.Value));
                        }

                        List<DiagnosisType> RightDiagnosisList = new List<DiagnosisType>();



                        foreach (var diag in Data.Diagnosis.GetAll.Where(s => s.isLeft == false && s.id_операции == Operation.Id).ToList())
                        {

                            RightDiagnosisList.Add(Data.DiagnosisTypes.Get(diag.id_диагноз.Value));
                        }


                        using (var context = new MySqlContext())
                        {
                            PatologyRepository PtRep = new PatologyRepository(context);
                            PatologyTypeRepository PtTypeRep = new PatologyTypeRepository(context);
                            ExaminationRepository ExamRep = new ExaminationRepository(context);
                            ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);
                            LettersRepository LettersRep = new LettersRepository(context);
                            // LettersRep = new LettersRepository(context);
                            var PatologysOfCurrPatient = PtRep.GetAll.ToList().Where(s => s.id_пациента == CurrentPatient.Id && s.isArchivatied == false).ToList();

                            int zz = 0;
                            foreach (var x in PatologysOfCurrPatient)
                            {
                                //zz++;
                                if (zz != PatologysOfCurrPatient.Count - 1)
                                    patologis += PtTypeRep.Get(x.id_патологии).Str + ", ";
                                else
                                    patologis += PtTypeRep.Get(x.id_патологии).Str;
                                zz++;
                            }

                            char[] chararrbuF12 = patologis.ToCharArray();

                            if (chararrbuF12.Length != 0 && chararrbuF12[0] == ' ')
                            {
                                patologis = patologis.Remove(0, 1);

                            }
                            if (chararrbuF12.Length != 0 && chararrbuF12[chararrbuF12.Length - 1] == '.')
                            { }
                            else
                            {
                                patologis += ".";
                            }
                            if (!string.IsNullOrWhiteSpace(patologis) && patologis != ".")
                            {
                                document.ReplaceText("Патологии", "Патологии: " + patologis + "\n");
                            }
                            else
                            {
                                document.ReplaceText("Патологии", "");
                            }
                            //if(patologis == ".")
                            //{
                            //    document.ReplaceText("Патологии", "");
                            //}
                            diabet += CurrentPatient.Sugar;
                            if (!string.IsNullOrWhiteSpace(diabet))
                            {
                                document.ReplaceText(" Диабет", "Сахарный диабет: " + diabet + "\n");
                            }
                            else
                            {

                                document.ReplaceText(" Диабет", "");
                            }
                            var ExamsOfCurrPatient = ExamRep.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                            if (ExamsOfCurrPatient.Count > 0)
                            {

                                DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                                var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                                ExaminationLeg leftLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                                ExaminationLeg rightLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);
                                List<ComplainsType> ComplainsList = new List<ComplainsType>();


                                //int day12 = ExamsOfCurrPatientLatest[0].Date.Day;
                                //int mnth12 = ExamsOfCurrPatientLatest[0].Date.Month;
                                //string mnthStr1 = "";
                                //string dayStr1 = "";
                                //if (mnth12 < 10)
                                //{
                                //    mnthStr1 += "0" + mnth12.ToString();
                                //}
                                //else
                                //{
                                //    mnthStr1 = mnth12.ToString();
                                //}

                                //if (day12 < 10)
                                //{
                                //    dayStr1 += "0" + day12.ToString();
                                //}
                                //else
                                //{
                                //    dayStr1 = day12.ToString();
                                //}
                                //document.ReplaceText("«Дата»", dayStr1 + "." + mnthStr1 + "." + ExamsOfCurrPatientLatest[0].Date.Year.ToString());



                                foreach (var diag in Data.ComplanesObs.GetAll.Where(s => s.id_обследования == ExamsOfCurrPatientLatest[0].Id).ToList())
                                {
                                    ComplainsList.Add(Data.ComplainsTypes.Get(diag.id_жалобы));
                                }
                                string complanes = "";
                                if (ComplainsList != null)
                                {
                                    int xxx = 0;
                                    foreach (var rec in ComplainsList)
                                    {

                                        if (xxx == 0)
                                        {
                                            complanes += rec.Str;
                                        }
                                        else
                                        {
                                            complanes += ", " + rec.Str;
                                        }
                                        xxx++;



                                    }
                                    char[] chararrbuF1 = complanes.ToCharArray();
                                    if (chararrbuF1.Length != 0 && chararrbuF1[0] == ' ')
                                    {
                                        complanes = complanes.Remove(0, 1);

                                    }
                                    if (chararrbuF1.Length != 0 && chararrbuF1[chararrbuF1.Length - 1] == '.')
                                    { }
                                    else
                                    {
                                        complanes += ".";
                                    }
                                }
                                document.ReplaceText("«Жалобы»", complanes);









                                //document.ReplaceText("«Жалобы»", complanes);







                                Letters bufLetter = new Letters();
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
                            else
                            {
                                document.ReplaceText("«Жалобы»", "");

                            }

                        }


                        int day12 = Operation.Date.Day;
                        int mnth12 = Operation.Date.Month;
                        string mnthStr1 = "";
                        string dayStr1 = "";
                        if (mnth12 < 10)
                        {
                            mnthStr1 += "0" + mnth12.ToString();
                        }
                        else
                        {
                            mnthStr1 = mnth12.ToString();
                        }

                        if (day12 < 10)
                        {
                            dayStr1 += "0" + day12.ToString();
                        }
                        else
                        {
                            dayStr1 = day12.ToString();
                        }
                        document.ReplaceText("«Дата»", dayStr1 + "." + mnthStr1 + "." + Operation.Date.Year.ToString());
                        int xx = 0;
                        foreach (var x in LeftDiagnosisList)
                        {
                            if (xx == 0)
                            {
                                leftDiag += x.Str;
                            }
                            else
                            {
                                leftDiag += ", " + x.Str;
                            }
                            xx++;
                        }
                        char[] chararrbuF = leftDiag.ToCharArray();
                        if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                        {
                            leftDiag = leftDiag.Remove(0, 1);

                        }
                        if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                        { }
                        else
                        {
                            leftDiag += ".";
                        }


                        xx = 0;
                        foreach (var x in RightDiagnosisList)
                        {
                            if (xx == 0)
                            {
                                rightDiag += x.Str;
                            }
                            else
                            {
                                rightDiag += ", " + x.Str;
                            }
                            xx++;
                        }
                        chararrbuF = rightDiag.ToCharArray();
                        if (chararrbuF.Length != 0 && chararrbuF[0] == ' ')
                        {
                            rightDiag = rightDiag.Remove(0, 1);

                        }
                        if (chararrbuF.Length != 0 && chararrbuF[chararrbuF.Length - 1] == '.')
                        { }
                        else
                        {
                            rightDiag += ".";
                        }

                        if (SelectedLeg == 0)
                        {
                            document.ReplaceText("«Заключение_1»", rightDiag + "\n");

                            document.ReplaceText("«Заключение_2»", leftDiag + "\n");

                            //document.ReplaceText("буквы_1", lettersRight);
                            //document.ReplaceText("буквы_2", lettersLeft);
                            //буквы_1
                            //буквы_2
                        }
                        else
                        {
                            document.ReplaceText("«Заключение_1»", leftDiag);
                            document.ReplaceText("«Заключение_2»", rightDiag);
                            //document.ReplaceText("буквы_1", lettersLeft);
                            //document.ReplaceText("буквы_2", lettersRight);

                        }





                        int day = Operation.Date.Day;
                        int mnth = Operation.Date.Month;
                        string mnthStr = "";
                        string dayStr = "";
                        if (mnth < 10)
                        {
                            mnthStr += "0" + mnth.ToString();
                        }
                        else
                        {
                            mnthStr = mnth.ToString();
                        }

                        if (day < 10)
                        {
                            dayStr += "0" + day.ToString();
                        }
                        else
                        {
                            dayStr = day.ToString();
                        }
                        document.ReplaceText("«Дата_операции»", dayStr + "." + mnthStr + "." + Operation.Date.Year.ToString());

                        string leftP = "", rightP = "", operationType = "";
                        int i1 = 0, i2 = 0;

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
                            document.ReplaceText("буквы_2Ж", lettersLeft);
                            document.ReplaceText("буквы_1Ж", "");
                            document.ReplaceText("«Заключение_11Ж»", "");
                            document.ReplaceText("«Заключение_22Ж»", leftDiag + "\n");
                            document.ReplaceText("«Заключение_11»", rightDiag + "\n");

                            document.ReplaceText("«Заключение_22»", "");

                            document.ReplaceText(" буквы_1", lettersRight);
                            document.ReplaceText(" буквы_2", "");

                        }
                        if (Operation.OnWhatLegOp == "1")
                        {
                            document.ReplaceText("буквы_1Ж", lettersRight);
                            document.ReplaceText("буквы_2Ж", "");
                            document.ReplaceText("«Заключение_11Ж»", rightDiag + "\n");

                            document.ReplaceText("«Заключение_22Ж»", "");
                            document.ReplaceText("«Заключение_22»", leftDiag + "\n");
                            document.ReplaceText("«Заключение_11»", "");

                            document.ReplaceText(" буквы_1", "");

                            document.ReplaceText(" буквы_2", lettersLeft);
                        }
                        if (Operation.OnWhatLegOp == "2")
                        {
                            document.ReplaceText("«Заключение_11Ж»", rightDiag + "\n");
                            document.ReplaceText("буквы_1Ж", lettersRight);
                            document.ReplaceText("«Заключение_22Ж»", leftDiag + "\n");
                            document.ReplaceText("буквы_2Ж", lettersLeft);
                            document.ReplaceText("«Заключение_11»", "");
                            document.ReplaceText("«Заключение_22»", "");
                            document.ReplaceText(" буквы_1", "");
                            document.ReplaceText(" буквы_2", "");
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
                        //if (!string.IsNullOrWhiteSpace(Data.OperationType.Get(Operation.OperationTypeId).ShortName))
                        //    document.ReplaceText("«Операция2»", Data.OperationType.Get(Operation.OperationTypeId).ShortName);
                        //else
                        //    document.ReplaceText("«Операция2»", Data.OperationType.Get(Operation.OperationTypeId).LongName);

                        day = DateTime.Now.Day;
                        mnth = DateTime.Now.Month;
                        mnthStr = "";
                        dayStr = "";
                        if (mnth < 10)
                        {
                            mnthStr += "0" + mnth.ToString();
                        }
                        else
                        {
                            mnthStr = mnth.ToString();
                        }

                        if (day < 10)
                        {
                            dayStr += "0" + day.ToString();
                        }
                        else
                        {
                            dayStr = day.ToString();
                        }
                        document.ReplaceText("«сутки»", Days.ToString());
                        document.ReplaceText("сутки", "суток");
                        document.ReplaceText("“сегодняшнеечисломесяц”  ", dayStr + "." + mnthStr);
                        document.ReplaceText("«год»", DateTime.Now.Year.ToString());
                        document.ReplaceText("«Врач»", Doctors[SelectedDoctor].ToString());

                        //область

                        document.Save();
                        byte[] bteToBD = File.ReadAllBytes(fileName);
                        using (var context = new MySqlContext())
                        {
                            StatementOperationRepository HirurgOverviewRep = new StatementOperationRepository(context);
                            StatementOperation Hv = new StatementOperation();
                            if (Operation.StatementId != null && Operation.StatementId != 0)
                            {
                                Hv = Data.StatementOperation.Get(Operation.StatementId.Value);
                                Hv.FirstIsRightIfNull = SelectedLeg;
                                Hv.CountDays = Days;
                                Hv.DocTemplate = bteToBD;
                                Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                Data.Complete();
                            }
                            else
                            {

                                Hv.DocTemplate = bteToBD;
                                Hv.DoctorId = Doctors[SelectedDoctor].doc.Id;
                                Hv.CountDays = Days;
                                Hv.FirstIsRightIfNull = SelectedLeg;
                                Data.StatementOperation.Add(Hv);

                                Data.Complete();
                                Operation = Data.Operation.Get(Operation.Id);
                                Operation.StatementId = Hv.Id;
                                Data.Complete();
                            }
                        }
                        //Release this document from memory.
                        IsDocAdded = Visibility.Visible;
                 
                        Process.Start("WINWORD.EXE", fileName);
                        GetOperationid(null, Operation.Id);
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
        }
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToCreateStatementCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
        public DelegateCommand SetNewOverview { get; private set; }
        public DelegateCommand SaveWordDocument { get; private set; }
        public DelegateCommand OpenFile { get; private set; }
        public DelegateCommand OpenWordDocument { get; private set; }
        public DelegateCommand<object> LostFocus { get; private set; }
        public DelegateCommand<object> ClickOnWeight { get; private set; }
    }
}
