
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using WpfApp2.Messaging;

namespace WpfApp2.Db.Models
{

    [Table("drug_intolerance")]
    // [Table("непереносимость_припаратов")]
    public class PreparateHate
    {

        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("name")]
        public string Str { set { _str = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); } get { return _str; } }
        [NotMapped]
        private string _str;

        public override string ToString()
        {
            return Str;
        }


    }
    public class PreparateHateRepository : Repository<PreparateHate>
    {
        public PreparateHateRepository(DbContext context) : base(context)
        {

        }
    }

}
