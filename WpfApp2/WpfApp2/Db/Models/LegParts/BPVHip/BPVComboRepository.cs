using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.BPVHip
{
    public class BPVComboRepository : Repository<BPVHipCombo>
    {
        public BPVComboRepository(DbContext context) : base(context)
        {
        }
    }
}
