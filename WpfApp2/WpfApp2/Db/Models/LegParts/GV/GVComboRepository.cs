using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.GV;

namespace WpfApp2.Db.Models.LegParts.GV
{
    public class GVComboRepository : Repository<GVCombo>
    {
        public GVComboRepository(DbContext context) : base(context)
        {

        }

        private GVCombo FindCombo(int bpvstr1, int? bpvstr2, int? bpvstr3)
        {
            try
            {
                return dbContext.Set<GVCombo>().Where(
                    x => (x.IdStr1 == bpvstr1 &&
                    x.IdStr2 == bpvstr2 
                  
                  )).First();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        //потому что в комбо есть как минимум одна запись
        public GVCombo FindCombo(int str1, List<int?> ids)
        {
            if (ids.Count == 0)
                return FindCombo(str1, null, null);
           

            //значит их 2???. по-хорошему тут должна быть ещё одна проверка и эксепшн.
            return FindCombo(str1, ids[0], null);
        }

        //cогласна, архитектура странновата, разрешаю переписать))
        public void AddCombo(GVCombo newCombo, List<int?> ids)
        {
            //это пример плохого кода
            if (ids.Count >= 1)
                newCombo.IdStr2 = ids[0];
           
          
            Add(newCombo);
        }
    }
}
