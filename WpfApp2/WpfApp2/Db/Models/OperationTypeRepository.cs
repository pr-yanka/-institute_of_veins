
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfApp2.Db.Models
{
    [Table("виды_операции")]
    public class OperationType
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("короткое_название")]
        public string ShortName { set; get; }
        [Column("длинное_название")]
        public string LongName { set; get; }
       
        [NotMapped]
        public string Str { get { return ToString(); } }
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(ShortName))
                return LongName;
            else
                return ShortName;
        }

    }
    public class OperationTypeRepository : Repository<OperationType>
    {
        public OperationTypeRepository(DbContext context) : base(context)
        {

        }
    }

}