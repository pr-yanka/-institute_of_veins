using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.Perforate_shin_Tibia
{
    public class Perforate_shinComboRepository : Repository<Perforate_shinCombo>
    {
        public Perforate_shinComboRepository(DbContext context) : base(context)
        {

        }

        private Perforate_shinCombo FindCombo(int bpvshinstr1, int? bpvshinstr2, int? bpvshinstr3, int? bpvshinstr4, int? bpvshinstr5)
        {
            try
            {
                return dbContext.Set<Perforate_shinCombo>().Where(
                    x => (x.IdStr1 == bpvshinstr1 &&
                    x.IdStr2 == bpvshinstr2 &&
                    x.IdStr3 == bpvshinstr3 &&
                    x.IdStr4 == bpvshinstr4 &&
                    x.IdStr5 == bpvshinstr5)).First();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        //потому что в комбо есть как минимум одна запись
        public Perforate_shinCombo FindCombo(int str1, List<int?> ids)
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

        //cогласна, архитектура странновата, разрешаю переписать))
        public void AddCombo(Perforate_shinCombo newCombo, List<int?> ids)
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
            Add(newCombo);
        }
    }
}
