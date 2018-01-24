using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.MPV
{
    public class MPVComboRepository : Repository<MPVCombo>
    {
        public MPVComboRepository(DbContext context) : base(context)
        {

        }

        private MPVCombo FindCombo(int bpvhipstr1, int? bpvhipstr2, int? bpvhipstr3, int? bpvhipstr4)
        {
            try
            {
                return dbContext.Set<MPVCombo>().Where(
                      x => (x.IdStr1 == bpvhipstr1 &&
                      x.IdStr2 == bpvhipstr2 &&
                      x.IdStr3 == bpvhipstr3 &&
                      x.IdStr4 == bpvhipstr4 )).First();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        //потому что в комбо есть как минимум одна запись
        public MPVCombo FindCombo(int str1, List<int?> ids)
        {
            if (ids.Count == 0)
                return FindCombo(str1, null, null, null);
            if (ids.Count == 1)
                return FindCombo(str1, ids[0], null, null);
            if (ids.Count == 2)
                return FindCombo(str1, ids[0], ids[1], null);

            //значит их 4. по-хорошему тут должна быть ещё одна проверка и эксепшн.
            return FindCombo(str1, ids[0], ids[1], ids[2]);
        }

        //cогласна, архитектура странновата, разрешаю переписать))
        public void AddCombo(MPVCombo newCombo, List<int?> ids)
        {
            //это пример плохого кода
            //это пример плохого кода
            if (ids.Count >= 1)
                newCombo.IdStr2 = ids[0];
            if (ids.Count >= 2)
                newCombo.IdStr3 = ids[1];
            if (ids.Count >= 3)
                newCombo.IdStr4 = ids[2];


            Add(newCombo);
        }
    }
}
