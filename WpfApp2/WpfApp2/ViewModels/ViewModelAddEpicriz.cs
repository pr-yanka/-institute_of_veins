using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Db.Models;
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


        #region Inotify realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //если PropertyChanged не нулевое - оно будет разбужено
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public float E1 { get; set; }
        public float E2 { get; set; }
        public string Антикоагулянты { get; set; }

        public string FullScrelizovanie { get; set; }
        public string Svetoootvod { get; set; }
        public float days { get; set; }

        public List<Docs> Doctors { get; set; }

        public int SelectedDoctor { get; set; }



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
        private void GetOperationid(object sender, object data)
        {
            //MessageBus.Default.Call("SetClearSclazingList", null, null);
            //MessageBus.Default.Call("SetClearAnticogulanyList", null, null);
            days = 0.0f;
            Svetoootvod = "";
            Антикоагулянты = "";
            FullScrelizovanie = "";
            E1 = 0.0f;
            E2 = 0.0f;
            DoctorsSelected = (List<DoctorDataSource>)sender;
            Doctors = new List<Docs>();
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            DateTime bufTime = DateTime.Parse(Operation.Time);

            Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Operation.Date;
            //operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
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
        //private void SetAnticogulantList(object sender, object data)
        //{
        //    AnticogulantSelected = (ObservableCollection<AnticogulanyListDataSource>)data;

        //}
        //private void SetSclezingList(object sender, object data)
        //{
        //    SclerozSelected = (ObservableCollection<SclerozListDataSource>)data;

        //}
        public ViewModelAddEpicriz(NavigationController controller) : base(controller)
        {//SetAnticogulantList
            //MessageBus.Default.Subscribe("SetAnticogulantList", SetAnticogulantList);
            //MessageBus.Default.Subscribe("SetSclazingListForEpicriz", SetSclezingList);
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
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Предоперационный_эпикриз.docx", bte);
                            else
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "Предоперационный_эпикриз" + togle + ".docx", bte);

                            break;
                        }
                        catch
                        {
                            togle += 1;
                            fileName = System.IO.Path.GetTempPath() + "Предоперационный_эпикриз" + togle + ".docx";
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

                        document.ReplaceText("«Заключение_слева»", lettersLeft);

                        document.ReplaceText("«Заключение_справа»", lettersRight);

                        document.ReplaceText("«Дата_операции»", Operation.Date.Day.ToString() + "." + Operation.Date.Month.ToString() + "." + Operation.Date.Year.ToString());

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


                        document.ReplaceText("«сутки»", days.ToString());
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
                        //Release this document from memory.
                        Process.Start("WINWORD.EXE", fileName);
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
        public DelegateCommand ToSetSclezindCommand { get; private set; }
        public DelegateCommand ToSetAugmentedRealytyCommand { get; }
    }
}
