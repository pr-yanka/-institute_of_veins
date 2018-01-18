using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts.PDSVHip
{
    public class PDSVComboRepository : Repository<PDSVHipCombo>
    {
        public PDSVComboRepository(DbContext context) : base(context)
        {

        }

        private PDSVHipCombo FindCombo(int bpvhipstr1, int? bpvhipstr2, int? bpvhipstr3)
        {
            try
            {
                return dbContext.Set<PDSVHipCombo>().Where(
                    x => (x.IdStr1 == bpvhipstr1 &&
                    x.IdStr2 == bpvhipstr2 &&
                    x.IdStr3 == bpvhipstr3 
                   
                   )).First();
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        //потому что в комбо есть как минимум одна запись
        public PDSVHipCombo FindCombo(int str1, List<int?> ids)
        {
            if (ids.Count == 0)
                return FindCombo(str1, null, null);
            if (ids.Count == 1)
                return FindCombo(str1, ids[0], null);
        
            //значит их 2???. по-хорошему тут должна быть ещё одна проверка и эксепшн.
            return FindCombo(str1, ids[0], ids[1]);
        }

        //cогласна, архитектура странновата, разрешаю переписать))
        public void AddCombo(PDSVHipCombo newCombo, List<int?> ids)
        {
            //это пример плохого кода
            if (ids.Count >= 1)
                newCombo.IdStr2 = ids[0];
            if (ids.Count >= 2)
                newCombo.IdStr3 = ids[1];
            
            Add(newCombo);
        }
    }
}
