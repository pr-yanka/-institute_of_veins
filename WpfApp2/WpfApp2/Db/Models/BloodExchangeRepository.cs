
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
    [Table("переливание_крови")]
    public class BloodExchange
    {

        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("Дата")]
        public DateTime Date { set; get; }

        [Column("Объём")]
        public float Volume { set; get; }


    }
    public class BloodExchangeRepository : Repository<BloodExchange>
    {
        public BloodExchangeRepository(DbContext context) : base(context)
        {

        }
    }
  
}