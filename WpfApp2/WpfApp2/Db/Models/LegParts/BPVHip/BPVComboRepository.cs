using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
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

        private BPVHipCombo FindCombo(int bpvhipstr1, int? bpvhipstr2, int? bpvhipstr3, int? bpvhipstr4, int? bpvhipstr5)
        {
            try
            {
                return dbContext.Set<BPVHipCombo>().Where(
                    x => (x.IdStr1 == bpvhipstr1 &&
                    x.IdStr2 == bpvhipstr2 &&
                    x.IdStr3 == bpvhipstr3 &&
                    x.IdStr4 == bpvhipstr4 &&
                    x.IdStr5 == bpvhipstr5)).First();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        //потому что в комбо есть как минимум одна запись
        public BPVHipCombo FindCombo(int str1, List<int?> ids)
        {
            if (ids.Count == 0)
                return FindCombo(str1, null, null, null, null);
            if (ids.Count == 1)
                return FindCombo(str1, ids[0], null, null, null);
            if (ids.Count == 2)
                return FindCombo(str1, ids[0], ids[1], null, null);
            if (ids.Count == 3)
                return FindCombo(str1, ids[0], ids[1], ids[2], null);
            //значит их 4. по-хорошему тут должна быть ещё одна проверка и эксепшн.
            return FindCombo(str1, ids[0], ids[1], ids[2], ids[3]);
        }
    }
}
