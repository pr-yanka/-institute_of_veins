using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Db.Models
{
    [Table("метрика")]
    public class Metrics
    {
        [Key]
        [Column("id")]
        public int Id { set; get; }
        [Column("название")]
        public string Str { set; get; }
    }

    public class MetricsRepository : Repository<Metrics>
    {
        private int _emptyId;

        public MetricsRepository(DbContext context) : base(context)
        {
            _emptyId = dbContext.Set<Metrics>().Where(entry => (entry.Str == "")).Select(entry => entry.Id).First();
        }
        public string GetStr(int? id)
        {
            if (id == null || id == _emptyId) return "";
            else return Get(id.Value).Str;
        }
    }
}