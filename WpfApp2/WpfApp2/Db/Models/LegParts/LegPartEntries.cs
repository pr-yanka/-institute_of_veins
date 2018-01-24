using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.LegParts
{
    public abstract class LegPartEntries
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_хода")]
        public virtual int WayID { get; set; }
        [Column("подзапись1")] 
        public virtual int EntryId1 { get; set; }
        [Column("подзапись2")]
        public virtual int EntryId2 { get; set; }
        [Column("подзапись3")]
        public virtual int EntryId3 { get; set; }
        [Column("подзапись4")]
        public virtual int EntryId4 { get; set; }
        [Column("подзапись5")]
        public virtual int EntryId5 { get; set; }
        [Column("подзапись6")]
        public virtual int EntryId6 { get; set; }



      



    }
}
