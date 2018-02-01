using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using WpfApp2.Db.Models;
using WpfApp2.Messaging;
using WpfApp2.Navigation;
using Xceed.Words.NET;

namespace WpfApp2.ViewModels
{
    public struct docs
    {
        public Doctor doc;
        public docs(Doctor doc)
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

        public List<docs> Doctors { get; set; }

        public int SelectedDoctor { get; set; }

        public int SelectedLeg { get; set; }

        public Operation Operation { get; set; }
        public DateTime Date { get; set; }
        public string operationType { get; set; }
        public Patient CurrentPatient;
        private int operationId;

        private void GetOperationid(object sender, object data)
        {
            SelectedLeg = 0;
            Doctors = new List<docs>();
            Operation = Data.Operation.Get((int)data);
            operationId = (int)data;
            DateTime bufTime = DateTime.Parse(Operation.Time);

            Operation.Date = new DateTime(Operation.Date.Year, Operation.Date.Month, Operation.Date.Day, bufTime.Hour, bufTime.Minute, bufTime.Second);
            Date = Operation.Date;
            operationType = Data.OperationType.Get(Operation.OperationTypeId).LongName;
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
                    Doctors.Add(new docs(doc));
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

                using (DocX document = DocX.Load("Выписка_заготовка.docx"))
                {
                        //doc_templates docTemp = new doc_templates();
                        //byte[] bte = File.ReadAllBytes(@"Выписка_заготовка.docx");
                        //docTemp.DocTemplate = bte;
                        //Data.doc_template.Add(docTemp);
                        //Data.Complete();
                        document.ReplaceText("ФИО", CurrentPatient.Sirname + CurrentPatient.Name + CurrentPatient.Patronimic);
                        document.Save();
                        // Release this document from memory.
                        Process.Start("WINWORD.EXE", @"Выписка_заготовка");
                    }
                    MessageBus.Default.Call("GetOperationResultForCreateStatement", this, operationId);
                    Controller.NavigateTo<ViewModelCreateStatement>();
                }
            );
            ToOperationOverviewCommand = new DelegateCommand(
                () =>
                {
                    MessageBus.Default.Call("GetOperationForOverwiev", this, operationId);
                    Controller.NavigateTo<ViewModelOperationOverview>();
                }
            );
        }
        public DelegateCommand ToOperationCommand { get; protected set; }
        public DelegateCommand ToCreateStatementCommand { get; protected set; }
        public DelegateCommand ToOperationOverviewCommand { get; protected set; }
    }
}
