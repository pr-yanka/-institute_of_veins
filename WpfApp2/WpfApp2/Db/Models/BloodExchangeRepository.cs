
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
    
    //[Table("переливание_крови")]
    [Table("blood_transfer")]
    public class BloodExchange
    {//SetnameOfButtonForAmbCard

        [Key]
        [Column("id")]
        public int Id { set; get; }

        [Column("date")]
        public DateTime Date { set { _date = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); } get { return _date; } }
        [NotMapped]
        private DateTime _date;
        //     [Column("Объём")]
        [Column("amount")]
        public float Volume { set { _volume = value; MessageBus.Default.Call("SetnameOfButtonForAmbCard", null, null); } get { return _volume; } }
        [NotMapped]
        private float _volume;
    }
    public class BloodExchangeRepository : Repository<BloodExchange>
    {
        public BloodExchangeRepository(DbContext context) : base(context)
        {

        }
    }
  
}