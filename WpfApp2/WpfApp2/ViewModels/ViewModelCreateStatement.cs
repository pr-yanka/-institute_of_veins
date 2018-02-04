﻿using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
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
    public class ViewModelCreateStatement : ViewModelBase
    {

        public List<string> LeftOrRight { get; set; }
        public float days { get; set; }

        public List<Docs> Doctors { get; set; }

        public int SelectedDoctor { get; set; }

        public int SelectedLeg { get; set; }

        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        public string OperationType { get; set; }
        public Patient CurrentPatient;
        private int operationId;

        private void GetOperationid(object sender, object data)
        {
            SelectedLeg = 0;
            Doctors = new List<Docs>();
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            DateTime bufTime = DateTime.Parse(Operation.Time);

            Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Operation.Date;
            OperationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
            //TextResultCancle = "Итоги операции"; 
            using (var context = new MySqlContext())
            {
                PatientsRepository PatientsRep = new PatientsRepository(context);
                CurrentPatient = PatientsRep.Get(Operation.PatientId);
            }
            using (var context = new MySqlContext())
            {
                DoctorRepository DoctorRep = new DoctorRepository(context);


                foreach (var doc in DoctorRep.GetAll)
                {
                    Doctors.Add(new Docs(doc));
                }
            }
        }

        public ViewModelCreateStatement(NavigationController controller) : base(controller)
        {
            LeftOrRight = new List<string>();
            LeftOrRight.Add("Правая нога");
            LeftOrRight.Add("Левая нога");

            MessageBus.Default.Subscribe("GetOperationResultForCreateStatement", GetOperationid);
            HasNavigation = false;
            
            ToCreateStatementCommand = new DelegateCommand(
                () =>
                {
                    //doc_templates docTemp = new doc_templates();
                    //byte[] bte = File.ReadAllBytes(@"Выписка_заготовка.docx");
                    //docTemp.DocTemplate = bte;
                    //Data.doc_template.Add(docTemp);
                    //Data.Complete();
                    int togle = 0;
                    // string fileName = System.IO.Path.GetTeWmpPath() + Guid.NewGuid().ToString() + ".docx";
                    string fileName = System.IO.Path.GetTempPath() + "Выписка_заготовка.docx";
                    byte[] bte = Data.doc_template.Get(1).DocTemplate;
                    //File.WriteAllBytes(fileName, bte);
                    for (; ; )
                    {
                        try
                        {
                            if (togle == 0)
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Выписка_заготовка.docx", bte);
                            else
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Выписка_заготовка" + togle + ".docx", bte);

                            break;
                        }
                        catch
                        {
                            togle += 1;
                            fileName = System.IO.Path.GetTempPath() + "Выписка_заготовка" + togle + ".docx";
                        }
                    }


                    using (DocX document = DocX.Load(fileName))
                    {


                        document.ReplaceText("ФИО", CurrentPatient.Sirname + " " + CurrentPatient.Name + " " + CurrentPatient.Patronimic);
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



                        string lettersLeft = "";
                        string lettersRight = "";

                        using (var context = new MySqlContext())
                        {
                            ExaminationRepository ExamRep = new ExaminationRepository(context);
                            ExaminationLegRepository LegExamRep = new ExaminationLegRepository(context);
                            LettersRepository LettersRep = new LettersRepository(context);
                            var ExamsOfCurrPatient = ExamRep.GetAll.ToList().Where(s => s.PatientId == CurrentPatient.Id).ToList();

                            if (ExamsOfCurrPatient.Count > 0)
                            {
                                DateTime MaxExam = ExamsOfCurrPatient.Max(s => s.Date);
                                var ExamsOfCurrPatientLatest = ExamsOfCurrPatient.Where(s => s.Date == MaxExam).ToList();
                                ExaminationLeg leftLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idLeftLegExamination.Value);
                                ExaminationLeg rightLegExam = LegExamRep.Get(ExamsOfCurrPatientLatest[0].idRightLegExamination.Value);
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

                        }


                        if (SelectedLeg == 0)
                        {
                            document.ReplaceText("«Заключение_1»", "«Заключение_справа»");

                            document.ReplaceText("«Заключение_2»", "«Заключение_слева»");

                            document.ReplaceText("буквы_1", lettersRight);
                            document.ReplaceText("буквы_2", lettersLeft);
                            //буквы_1
                            //буквы_2
                        }
                        else
                        {
                            document.ReplaceText("«Заключение_1»", "«Заключение_слева»");
                            document.ReplaceText("«Заключение_2»", "«Заключение_справа»");
                            document.ReplaceText("буквы_1", lettersLeft);
                            document.ReplaceText("буквы_2", lettersRight);

                        }

                        document.ReplaceText("«Дата_операции»", Operation.Date.Day.ToString() + "." + Operation.Date.Month.ToString() + "." + Operation.Date.Year.ToString());

                        if (!string.IsNullOrWhiteSpace(Data.OperationType.Get(Operation.OperationTypeId).ShortName))
                            document.ReplaceText("«Операция2»", Data.OperationType.Get(Operation.OperationTypeId).ShortName);
                        else
                            document.ReplaceText("«Операция2»", Data.OperationType.Get(Operation.OperationTypeId).LongName);


                        document.ReplaceText("«сутки»", days.ToString());
                        document.ReplaceText("сегодняшнеечисломесяц", DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString());
                        document.ReplaceText("«год»", DateTime.Now.Year.ToString());
                        document.ReplaceText("«Врач»", Doctors[SelectedDoctor].ToString());

                        //область

                        document.Save();
                        //Release this document from memory.
                        Process.Start("WINWORD.EXE",  fileName);
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
    }
}