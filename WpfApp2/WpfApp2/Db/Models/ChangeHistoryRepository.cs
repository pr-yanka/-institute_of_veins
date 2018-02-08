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
        public int Id { set; get; }
        [Column("id_аккаунта")]
        public int AccID { set; get; }
        [Column("id_записи")]
        public string RowId { set; get; }

        [Column("тип_изменения")]
        public int ChangeType { set; get; }

        
        [Column("дата_изменения")]
        public DateTime DataChanged { set; get; }
        [Column("название_таблицы")]
        public string TblName { set; get; }
        [Column("название_столбца")]
        public string TblCollumnName { set; get; }
        [Column("старое_значение")]
        public string OldValue { set; get; }
        [Column("новое_значение")]
        public string NewValue { set; get; }
        [Column("SomeBlobFileNew")]
        public byte[] BlobNew { set; get; }
        [Column("SomeBlobFileOld")]
        public byte[] BlobOld { set; get; }
        
    }
    public class ChangeHistoryRepository : Repository<ChangeHistory>
    {


        public ChangeHistoryRepository(DbContext context) : base(context)
        {

        }

    }

}
