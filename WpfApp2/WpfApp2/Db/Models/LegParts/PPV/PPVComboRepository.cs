using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.PPV;

namespace WpfApp2.Db.Models.LegParts.PPV
{
    public class PPVComboRepository : Repository<PPVCombo>
    {
        public PPVComboRepository(DbContext context) : base(context)
        {

        }

        private PPVCombo FindCombo(int bpvstr1, int? bpvstr2, int? bpvstr3)
        {
            try
            {
                return dbContext.Set<PPVCombo>().Where(
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
        public PPVCombo FindCombo(int str1, List<int?> ids)
        {
            if (ids.Count == 0)
                return FindCombo(str1, null, null);
           

            //значит их 2???. по-хорошему тут должна быть ещё одна проверка и эксепшн.
            return FindCombo(str1, ids[0], null);
        }

        //cогласна, архитектура странновата, разрешаю переписать))
        public void AddCombo(PPVCombo newCombo, List<int?> ids)
        {
            //это пример плохого кода
            if (ids.Count >= 1)
                newCombo.IdStr2 = ids[0];
           
          
            Add(newCombo);
        }
    }
}
