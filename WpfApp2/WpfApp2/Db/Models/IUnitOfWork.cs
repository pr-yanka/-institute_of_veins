using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    public interface IUnitOfWork : IDisposable
    {
        ILegPartRepository BPVHips { get; }

        int Complete();
    }
}
