using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.SFSHip
{
    public class SFSComboRepository : Repository<SFSHipCombo>
    {
        public SFSComboRepository(DbContext context) : base(context)
        {

        }

        private SFSHipCombo FindCombo(int bpvhipstr1, int? bpvhipstr2, int? bpvhipstr3, int? bpvhipstr4, int? bpvhipstr5, int? bpvhipstr6)
        {
            try
            {
                return dbContext.Set<SFSHipCombo>().Where(
                    x => (x.IdStr1 == bpvhipstr1 &&
                    x.IdStr2 == bpvhipstr2 &&
                    x.IdStr3 == bpvhipstr3 &&
                    x.IdStr4 == bpvhipstr4 &&
                    x.IdStr5 == bpvhipstr5 &&
                    x.IdStr6 == bpvhipstr6)).First();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        //потому что в комбо есть как минимум одна запись
        public SFSHipCombo FindCombo(int str1, List<int?> ids)
        {
            if (ids.Count == 0)
                return FindCombo(str1, null, null, null, null, null);
            if (ids.Count == 1)
                return FindCombo(str1, ids[0], null, null, null, null);
            if (ids.Count == 2)
                return FindCombo(str1, ids[0], ids[1], null, null, null);
            if (ids.Count == 3)
                return FindCombo(str1, ids[0], ids[1], ids[2], null, null);
            if (ids.Count == 4)
                return FindCombo(str1, ids[0], ids[1], ids[2], ids[3], null);
            //значит их 5. по-хорошему тут должна быть ещё одна проверка и эксепшн.
            return FindCombo(str1, ids[0], ids[1], ids[2], ids[3], ids[4]);
        }

        //cогласна, архитектура странновата, разрешаю переписать))
        public void AddCombo(SFSHipCombo newCombo, List<int?> ids)
        {
            //это пример плохого кода
            if (ids.Count >= 1)
                newCombo.IdStr2 = ids[0];
            if (ids.Count >= 2)
                newCombo.IdStr3 = ids[1];
            if (ids.Count >= 3)
                newCombo.IdStr4 = ids[2];
            if (ids.Count >= 4)
                newCombo.IdStr5 = ids[3];
            if (ids.Count >= 5)
                newCombo.IdStr6 = ids[4];
            Add(newCombo);
        }
    }
}
