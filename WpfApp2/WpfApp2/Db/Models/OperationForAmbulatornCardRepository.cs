
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
    [Table("операции_для_амбулаторной_карты")]
    public class OperationForAmbulatornCard
    {

        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("Название")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }


    }
    public class OperationForAmbulatornCardRepository : Repository<OperationForAmbulatornCard>
    {
        public OperationForAmbulatornCardRepository(DbContext context) : base(context)
        {

        }
    }

}
  
