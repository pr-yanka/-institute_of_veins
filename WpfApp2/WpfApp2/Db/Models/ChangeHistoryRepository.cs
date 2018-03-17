using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    [Table("история_изменений")]
    public class ChangeHistory

    {
        [Key]
        [Column("id")]
        public int id { set; get; }
        [Column("id_аккаунта")]
        public int id_аккаунта { set; get; }
        [Column("id_записи")]
        public string id_записи { set; get; }

        [Column("тип_изменения")]
        public int тип_изменения { set; get; }

        
        [Column("дата_изменения")]
        public DateTime дата_изменения { set; get; }
        [Column("название_таблицы")]
        public string название_таблицы { set; get; }
        [Column("название_столбца")]
        public string название_столбца { set; get; }
        [Column("старое_значение")]
        public string старое_значение { set; get; }
        [Column("новое_значение")]
        public string новое_значение { set; get; }
        [Column("SomeBlobFileNew")]
        public byte[] SomeBlobFileNew { set; get; }
        [Column("SomeBlobFileOld")]
        public byte[] SomeBlobFileOld { set; get; }
        
    }
    public class ChangeHistoryRepository : Repository<ChangeHistory>
    {


        public ChangeHistoryRepository(DbContext context) : base(context)
        {

        }

    }

}
