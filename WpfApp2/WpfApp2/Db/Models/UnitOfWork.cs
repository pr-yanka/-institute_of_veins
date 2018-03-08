using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.BPV_Tibia;
using WpfApp2.Db.Models.LegParts.BPV_Tibia_Tibia;
using WpfApp2.Db.Models.LegParts.BPVHip;
using WpfApp2.Db.Models.LegParts.GV;
using WpfApp2.Db.Models.LegParts.MPV;
using WpfApp2.Db.Models.LegParts.PDSVHip;
using WpfApp2.Db.Models.LegParts.Perforate_hip;
using WpfApp2.Db.Models.LegParts.Perforate_hip_Tibia;
using WpfApp2.Db.Models.LegParts.Perforate_shin;
using WpfApp2.Db.Models.LegParts.Perforate_shin_Tibia;
using WpfApp2.Db.Models.LegParts.PPV;
using WpfApp2.Db.Models.LegParts.SFSHip;
using WpfApp2.Db.Models.LegParts.SPSHip;
using WpfApp2.Db.Models.LegParts.TEMPV;
using WpfApp2.Db.Models.LegParts.ZDSV;

namespace WpfApp2.Db.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        public OperationTypeOperationsRepository OperationTypeOperations { get; }
        public OperationForAmbulatornCardRepository OperationForAmbulatornCard { get; }
        public OperationForAmbulatornCardPatientsRepository OperationForAmbulatornCardPatients { get; }
        public AlergicAnevrizmRepository AlergicAnevrizm { get; }
        public BloodExchangeRepository BloodExchange { get; }
        public HirurgInteruptRepository HirurgInterup { get; }
        public PreparateHateRepository PreparateHate { get; }

        public AlergicAnevrizmPatientsRepository AlergicAnevrizmPatients { get; }
        public BloodExchangePatientsRepository BloodExchangePatients { get; }
        public HirurgInteruptPatientsRepository HirurgInterupPatients { get; }
        public PreparateHatePatientsRepository PreparateHatePatients { get; }



        public ChangeHistoryRepository ChangeHistory { get; }
        public ComplanesObsRepository ComplanesObs { get; }
        public RecomendationObsRepository RecomendationObs { get; }

        public ChangesInDBTypeRepository ChangesInDBType { get; }

        public ExaminationLegRepository ExaminationLeg { get; }
        public doc_templatesRepository doc_template { get; }

        public BPVHipEntryFullRepository BPVHipsFull { get; }
        public PDSVHipEntryFullRepository PDSVFull { get; }
        public SFSHipEntryFullRepository SFSFull { get; }
        public Perforate_hipEntryFullRepository Perforate_hipFull { get; }
        public BPV_TibiaEntryFullRepository BPV_TibiaFull { get; }
        public SPSHipEntryFullRepository SPSHipFull { get; }
        public Perforate_shinEntryFullRepository Perforate_shinFull { get; }
        public MPVEntryFullRepository MPVFull { get; }
        public TEMPVEntryFullRepository TEMPVFull { get; }
        public PPVEntryFullRepository PPVFull { get; }
        public GVEntryFullRepository GVFull { get; }

        public GVRepository GV { get; }
        public GVComboRepository GVCombos { get; }
        public GVEntryRepository GVEntries { get; }




        public PPVRepository PPV { get; }
        public PPVComboRepository PPVCombos { get; }
        public PPVEntryRepository PPVEntries { get; }
        public LettersRepository Letters { get; }




        public TEMPVRepository TEMPV { get; }
        public TEMPVComboRepository TEMPVCombos { get; }
        public TEMPVEntryRepository TEMPVEntries { get; }





        public MPVRepository MPV { get; }
        public MPVComboRepository MPVCombos { get; }
        public MPVEntryRepository MPVEntries { get; }





        public Perforate_shinRepository Perforate_shin { get; }
        public Perforate_shinComboRepository Perforate_shinCombos { get; }
        public Perforate_shinEntryRepository Perforate_shinEntries { get; }






        public SPSHipRepository SPS { get; }
        public SPSComboRepository SPSCombos { get; }
        public SPSHipEntryRepository SPSEntries { get; }




        public BPV_TibiaRepository BPV_Tibia { get; }
        public BPV_TibiaComboRepository BPV_TibiaCombos { get; }
        public BPV_TibiaEntryRepository BPV_TibiaEntries { get; }

        public Perforate_hipRepository Perforate_hip { get; }
        public Perforate_hipComboRepository Perforate_hipCombos { get; }
        public Perforate_hipEntryRepository Perforate_hipEntries { get; }

        public ZDSVEntryFullRepository ZDSVFull { get; }
        public ZDSVRepository ZDSV { get; }
        public ZDSVComboRepository ZDSVCombos { get; }
        public ZDSVEntryRepository ZDSVEntries { get; }









        public SFSHipRepository SFSHips { get; }
        public SFSComboRepository SFSCombos { get; }
        public SFSHipEntryRepository SFSHipEntries { get; }

        public СategoryTypeRepository СategoryType { get; }

        public PDSVHipRepository PDSVHips { get; }
        public PDSVComboRepository PDSVCombos { get; }
        public PDSVHipEntryRepository PDSVHipEntries { get; }
        public PDSVHipWayRepository PDSVHipWay { get; }



        public BPVHipRepository BPVHips { get; }
        public BPVComboRepository BPVCombos { get; }
        public BPVHipEntryRepository BPVHipEntries { get; }
        public BPVHipWayRepository BPVHipWay { get; }


        public CitiesRepository Cities { get; }
        public DistrictsRepository Districts { get; }
        public RegionsRepository Regions { get; }
        public StreetsRepository Streets { get; }

        public BrigadeMedPersonalRepository BrigadeMedPersonal { get; }
        public ScientificTitlesRepository ScientificTitles { get; }
        public ScientificTitleTypeRepository ScientificTitleType { get; }
        public SpecializationTypeRepository SpecializationType { get; }
        public DoctorsSpecializationsRepository DoctorsSpecializations { get; }


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

        public TEMPVWayRepository TEMPVWay { get; }
        public MPVWayRepository MPVWay { get; }

        public MetricsRepository Metrics { get; }
        public PatientsRepository Patients { get; }
        public AnalizeTypeRepository AnalizeType { get; }
        public AnalizeRepository Analize { get; }
        public ComplainsTypeRepository ComplainsTypes { get; }
        public RecomendationsTypeRepository RecomendationsTypes { get; }
        public DiagnosisTypeRepository DiagnosisTypes { get; }

        public UnitOfWork(MySqlContext context)
        {
            _context = context;
            OperationTypeOperations = new OperationTypeOperationsRepository(_context);
            OperationForAmbulatornCard = new OperationForAmbulatornCardRepository(_context);
            OperationForAmbulatornCardPatients = new OperationForAmbulatornCardPatientsRepository(_context);
            AlergicAnevrizmPatients = new AlergicAnevrizmPatientsRepository(_context);
            BloodExchangePatients = new BloodExchangePatientsRepository(_context);
            HirurgInterupPatients = new HirurgInteruptPatientsRepository(_context);
            PreparateHatePatients = new PreparateHatePatientsRepository(_context);

            AlergicAnevrizm = new AlergicAnevrizmRepository(_context);
            BloodExchange = new BloodExchangeRepository(_context);
            HirurgInterup = new HirurgInteruptRepository(_context);
            PreparateHate = new PreparateHateRepository(_context);


            ChangesInDBType = new ChangesInDBTypeRepository(_context);
            ComplanesObs = new ComplanesObsRepository(_context);
            RecomendationObs = new RecomendationObsRepository(_context);
            ChangeHistory = new ChangeHistoryRepository(_context);
            GVFull = new GVEntryFullRepository(_context);
            PPVFull = new PPVEntryFullRepository(_context);
            TEMPVFull = new TEMPVEntryFullRepository(_context);
            MPVFull = new MPVEntryFullRepository(_context);
            Perforate_shinFull = new Perforate_shinEntryFullRepository(_context);
            SPSHipFull = new SPSHipEntryFullRepository(_context);
            BPV_TibiaFull = new BPV_TibiaEntryFullRepository(_context);
            Perforate_hipFull = new Perforate_hipEntryFullRepository(_context);
            ZDSVFull = new ZDSVEntryFullRepository(_context);
            SFSFull = new SFSHipEntryFullRepository(_context);
            PDSVFull = new PDSVHipEntryFullRepository(_context);
            BPVHipsFull = new BPVHipEntryFullRepository(_context);
            ExaminationLeg = new ExaminationLegRepository(_context);
            doc_template = new doc_templatesRepository(_context);
            GV = new GVRepository(_context);
            GVCombos = new GVComboRepository(_context);
            GVEntries = new GVEntryRepository(_context);

            PPV = new PPVRepository(_context);
            PPVCombos = new PPVComboRepository(_context);
            PPVEntries = new PPVEntryRepository(_context);

            Letters = new LettersRepository(_context);
            TEMPVWay = new TEMPVWayRepository(_context);
            MPVWay = new MPVWayRepository(_context);
            TEMPV = new TEMPVRepository(_context);
            TEMPVCombos = new TEMPVComboRepository(_context);
            TEMPVEntries = new TEMPVEntryRepository(_context);
            MPV = new MPVRepository(_context);
            MPVCombos = new MPVComboRepository(_context);
            MPVEntries = new MPVEntryRepository(_context);





            Perforate_shin = new Perforate_shinRepository(_context);
            Perforate_shinCombos = new Perforate_shinComboRepository(_context);
            Perforate_shinEntries = new Perforate_shinEntryRepository(_context);
            SPS = new SPSHipRepository(_context);
            SPSCombos = new SPSComboRepository(_context);
            SPSEntries = new SPSHipEntryRepository(_context);








            BPV_Tibia = new BPV_TibiaRepository(_context);
            BPV_TibiaCombos = new BPV_TibiaComboRepository(_context);
            BPV_TibiaEntries = new BPV_TibiaEntryRepository(_context);
            Perforate_hip = new Perforate_hipRepository(_context);
            Perforate_hipCombos = new Perforate_hipComboRepository(_context);
            Perforate_hipEntries = new Perforate_hipEntryRepository(_context);
            ZDSV = new ZDSVRepository(_context);
            ZDSVCombos = new ZDSVComboRepository(_context);
            ZDSVEntries = new ZDSVEntryRepository(_context);













            PDSVHips = new PDSVHipRepository(_context);
            PDSVCombos = new PDSVComboRepository(_context);
            PDSVHipEntries = new PDSVHipEntryRepository(_context);
            PDSVHipWay = new PDSVHipWayRepository(_context);

            SFSHips = new SFSHipRepository(_context);
            SFSCombos = new SFSComboRepository(_context);
            SFSHipEntries = new SFSHipEntryRepository(_context);

            СategoryType = new СategoryTypeRepository(_context);
            BPVHipWay = new BPVHipWayRepository(_context);
            Cities = new CitiesRepository(_context);
            Districts = new DistrictsRepository(_context);
            Regions = new RegionsRepository(_context);
            Streets = new StreetsRepository(_context);
            BrigadeMedPersonal = new BrigadeMedPersonalRepository(_context);
            ScientificTitles = new ScientificTitlesRepository(_context);
            ScientificTitleType = new ScientificTitleTypeRepository(_context);
            SpecializationType = new SpecializationTypeRepository(_context);
            DoctorsSpecializations = new DoctorsSpecializationsRepository(_context);

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
