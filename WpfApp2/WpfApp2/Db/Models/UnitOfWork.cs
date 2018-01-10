﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.BPVHip;

namespace WpfApp2.Db.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        public MedPersonalRepository MedPersonal { get; }
        public AccauntRepository Accaunt { get; }

        public PatologyRepository Patology { get; }
        public PatologyTypeRepository PatologyType { get; }

        public CancelOperationRepository CancelOperation { get; }
        public OperationResultRepository OperationResult { get; }
        public ReasonsOfCancelOperationRepository ReasonsOfCancleOperation { get; }
        public DiagnosisObsRepository DiagnosisObs { get; }
        private readonly MySqlContext _context;
        public ExaminationRepository Examination { get; }

        public BrigadeRepository Brigade { get; }
        public DiagnosisRepository Diagnosis { get; }

        public OperationTypeRepository OperationType { get; }
        public OperationRepository Operation { get; }
        public AnestethicRepository Anestethic { get; }
        public DoctorRepository Doctor { get; }


        public BPVHipRepository BPVHips { get; private set; }
        public BPVComboRepository BPVCombos { get; private set; }
        public BPVHipEntryRepository BPVHipEntries { get; private set; }
        public MetricsRepository Metrics { get; }
        public PatientsRepository Patients { get; }
        public AnalizeTypeRepository AnalizeType { get; }
        public AnalizeRepository Analize { get; }
        public ComplainsTypeRepository ComplainsTypes { get; }
        public RecomendationsTypeRepository RecomendationsTypes { get; }
        public DiagnosisTypeRepository DiagnosisTypes { get; }

        public UnitOfWork (MySqlContext context)
        {
            _context = context;
            MedPersonal = new MedPersonalRepository(_context);

            Accaunt = new AccauntRepository(_context);
            PatologyType = new PatologyTypeRepository(_context);
            Patology = new PatologyRepository(_context);
            // _context.Configuration.AutoDetectChangesEnabled = false;
            // _context.Set<Operation>().AsNoTracking();
            ReasonsOfCancleOperation = new ReasonsOfCancelOperationRepository(_context);

            OperationResult = new OperationResultRepository(_context);
            CancelOperation = new CancelOperationRepository(_context);
            DiagnosisObs = new DiagnosisObsRepository(_context);

            Examination = new ExaminationRepository(_context);

            Brigade = new BrigadeRepository(_context);
            Diagnosis = new DiagnosisRepository(_context);


            OperationType = new OperationTypeRepository(_context);
            Operation = new OperationRepository(_context);
            Anestethic = new AnestethicRepository(_context);
            Doctor = new DoctorRepository(_context);

            Analize = new AnalizeRepository(_context);
            AnalizeType = new AnalizeTypeRepository(_context);
            BPVHips = new BPVHipRepository(_context);
            BPVCombos = new BPVComboRepository(_context);
            BPVHipEntries = new BPVHipEntryRepository(_context);
            Metrics = new MetricsRepository(_context);
            Patients = new PatientsRepository(_context);
            ComplainsTypes = new ComplainsTypeRepository(_context);
            RecomendationsTypes = new RecomendationsTypeRepository(_context);
            DiagnosisTypes = new DiagnosisTypeRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
