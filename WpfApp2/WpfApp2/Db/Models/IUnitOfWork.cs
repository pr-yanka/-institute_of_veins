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
