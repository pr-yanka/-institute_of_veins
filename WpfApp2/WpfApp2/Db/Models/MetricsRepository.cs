using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    //[Table("метрика")]
    [Table("metrics")]
    public class Metrics
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("name")]
        public string Str { set; get; }

        public override string ToString()
        {
            return Str;
        }
    }

    public class MetricsRepository : Repository<Metrics>
    {
        private int _emptyId;

        public MetricsRepository(DbContext context) : base(context)
        {
            dbContext.Set<Metrics>().Load();
            _emptyId = dbContext.Set<Metrics>().Local.Where(entry => (entry.Str == "")).Select(entry => entry.Id).First();
        }
        public string GetStr(int? id)
        {
            if (id == null || id == _emptyId) return "";
            else return dbContext.Set<Metrics>().Local.First(entry => entry.Id == id.Value).Str;
        }

        public override IEnumerable<Metrics> GetAll
        {
            get
            {

                return dbContext.Set<Metrics>().Local.ToList();
            }
        }
    }
}