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
    public interface IUnitOfWork : IDisposable
    {
        AdditionalInfoDocumentRepository AdditionalInfoDocument { get; }
        EpicrizOperationRepository EpicrizOperation { get; }
        StatementOperationRepository StatementOperation { get; }
        StatementObsRepository StatementObs { get; }
        HirurgOverviewRepository HirurgOverview { get; }
        SugarDiabetCommentRepository SugarDiabetComment { get; }
        SclezingRepository Sclezing { get; }
        AnticogulantsRepository Anticogulants { get; }
        PreparateHateCommentRepository PreparateHateComment { get; }
        BloodExchangeCommentRepository BloodExchangeComment { get; }
        OperationTypeOperationsRepository OperationTypeOperations { get; }
        OperationForAmbulatornCardRepository OperationForAmbulatornCard { get; }
        OperationForAmbulatornCardPatientsRepository OperationForAmbulatornCardPatients { get; }
        AlergicAnevrizmRepository AlergicAnevrizm { get; }
        BloodExchangeRepository BloodExchange { get; }
        HirurgInteruptRepository HirurgInterup { get; }
        PreparateHateRepository PreparateHate { get; }


        AlergicAnevrizmPatientsRepository AlergicAnevrizmPatients { get; }
        BloodExchangePatientsRepository BloodExchangePatients { get; }
        HirurgInteruptPatientsRepository HirurgInterupPatients { get; }
        PreparateHatePatientsRepository PreparateHatePatients { get; }


        ChangeHistoryRepository ChangeHistory { get; }
        ComplanesObsRepository ComplanesObs { get; }
        RecomendationObsRepository RecomendationObs { get; }

        ChangesInDBTypeRepository ChangesInDBType { get; }

        BPVHipEntryFullRepository BPVHipsFull { get; }
        PDSVHipEntryFullRepository PDSVFull { get; }
        SFSHipEntryFullRepository SFSFull { get; }
        Perforate_hipEntryFullRepository Perforate_hipFull { get; }
        BPV_TibiaEntryFullRepository BPV_TibiaFull { get; }
        SPSHipEntryFullRepository SPSHipFull { get; }
        Perforate_shinEntryFullRepository Perforate_shinFull { get; }
        MPVEntryFullRepository MPVFull { get; }
        TEMPVEntryFullRepository TEMPVFull { get; }
        PPVEntryFullRepository PPVFull { get; }
        GVEntryFullRepository GVFull { get; }
        ZDSVEntryFullRepository ZDSVFull { get; }



        ExaminationLegRepository ExaminationLeg { get; }
        doc_templatesRepository doc_template { get; }

        GVRepository GV { get; }
        GVComboRepository GVCombos { get; }
        GVEntryRepository GVEntries { get; }

        PPVRepository PPV { get; }
        PPVComboRepository PPVCombos { get; }
        PPVEntryRepository PPVEntries { get; }


        TEMPVRepository TEMPV { get; }
        TEMPVComboRepository TEMPVCombos { get; }
        TEMPVEntryRepository TEMPVEntries { get; }

        LettersRepository Letters { get; }

        TEMPVWayRepository TEMPVWay { get; }
        MPVWayRepository MPVWay { get; }

        MPVRepository MPV { get; }
        MPVComboRepository MPVCombos { get; }
        MPVEntryRepository MPVEntries { get; }

        Perforate_shinRepository Perforate_shin { get; }
        Perforate_shinComboRepository Perforate_shinCombos { get; }
        Perforate_shinEntryRepository Perforate_shinEntries { get; }


        SPSHipRepository SPS { get; }
        SPSComboRepository SPSCombos { get; }
        SPSHipEntryRepository SPSEntries { get; }

        BPV_TibiaRepository BPV_Tibia { get; }
        BPV_TibiaComboRepository BPV_TibiaCombos { get; }
        BPV_TibiaEntryRepository BPV_TibiaEntries { get; }

        Perforate_hipRepository Perforate_hip { get; }
        Perforate_hipComboRepository Perforate_hipCombos { get; }
        Perforate_hipEntryRepository Perforate_hipEntries { get; }


        ZDSVRepository ZDSV { get; }
        ZDSVComboRepository ZDSVCombos { get; }
        ZDSVEntryRepository ZDSVEntries { get; }




        PDSVHipRepository PDSVHips { get; }
        PDSVComboRepository PDSVCombos { get; }
        PDSVHipEntryRepository PDSVHipEntries { get; }
        PDSVHipWayRepository PDSVHipWay { get; }


        СategoryTypeRepository СategoryType { get; }
        BPVHipWayRepository BPVHipWay { get; }

        CitiesRepository Cities { get; }
        DistrictsRepository Districts { get; }
        RegionsRepository Regions { get; }
        StreetsRepository Streets { get; }

        BrigadeMedPersonalRepository BrigadeMedPersonal { get; }
        ScientificTitlesRepository ScientificTitles { get; }
        ScientificTitleTypeRepository ScientificTitleType { get; }
        SpecializationTypeRepository SpecializationType { get; }
        DoctorsSpecializationsRepository DoctorsSpecializations { get; }

        PatologyTypeRepository PatologyType { get; }
        MedPersonalRepository MedPersonal { get; }
        ReasonsOfCancelOperationRepository ReasonsOfCancleOperation { get; }
        PatologyRepository Patology { get; }
        CancelOperationRepository CancelOperation { get; }
        OperationResultRepository OperationResult { get; }
        AccauntRepository Accaunt { get; }
        DiagnosisObsRepository DiagnosisObs { get; }
        ExaminationRepository Examination { get; }

        BrigadeRepository Brigade { get; }
        DiagnosisRepository Diagnosis { get; }

        OperationTypeRepository OperationType { get; }
        OperationRepository Operation { get; }
        AnestethicRepository Anestethic { get; }
        DoctorRepository Doctor { get; }


        BPVHipRepository BPVHips { get; }
        BPVComboRepository BPVCombos { get; }
        BPVHipEntryRepository BPVHipEntries { get; }
        MetricsRepository Metrics { get; }
        PatientsRepository Patients { get; }
        AnalizeTypeRepository AnalizeType { get; }
        AnalizeRepository Analize { get; }
        ComplainsTypeRepository ComplainsTypes { get; }
        RecomendationsTypeRepository RecomendationsTypes { get; }
        DiagnosisTypeRepository DiagnosisTypes { get; }


        SFSHipRepository SFSHips { get; }
        SFSComboRepository SFSCombos { get; }
        SFSHipEntryRepository SFSHipEntries { get; }

        int Complete();
    }
}