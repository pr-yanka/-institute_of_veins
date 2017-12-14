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
        BPVHipRepository BPVHips { get; }
        BPVComboRepository BPVCombos { get; }
        MetricsRepository Metrics { get; }

        int Complete();
    }
}
