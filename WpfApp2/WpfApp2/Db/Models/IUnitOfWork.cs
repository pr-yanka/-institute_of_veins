using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;
using WpfApp2.Db.Models.LegParts.BPVHip;

namespace WpfApp2.Db.Models
{
    public interface IUnitOfWork : IDisposable
    {
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

        int Complete();
    }
}
