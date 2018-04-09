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
   // [Table("история_изменений")]
    [Table("changes_history")]
    //change history
    public class ChangeHistory

    {
        [Key]
        [Column("id")]
        public int id { set; get; }
        [Column("id_account")]
        public int id_аккаунта { set; get; }
        [Column("id_record")]
        public string id_записи { set; get; }

        [Column("type_change")]
        public int тип_изменения { set; get; }


        [Column("date_of_change")]
        public DateTime дата_изменения { set; get; }
        [Column("table_name")]
        public string название_таблицы { set; get; }
        [Column("column_name")]
        public string название_столбца { set; get; }
        [Column("old_value")]
        public string старое_значение { set; get; }
        [Column("new_value")]
        public string новое_значение { set; get; }
        [Column("someBlobFileNew")]
        public byte[] SomeBlobFileNew { set; get; }
        [Column("someBlobFileOld")]
        public byte[] SomeBlobFileOld { set; get; }
        
    }
    public class ChangeHistoryRepository : Repository<ChangeHistory>
    {


        public ChangeHistoryRepository(DbContext context) : base(context)
        {

        }

    }

}
