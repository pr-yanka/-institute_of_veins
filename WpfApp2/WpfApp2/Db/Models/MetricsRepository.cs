using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WpfApp2.Db.Models
{
    public class Metrics
    {
        public int Id { set; get; }
        public string Str { set; get; }
    }

    public class MetricsRepository : Repository<Metrics>
    {
        public MetricsRepository(DbContext context) : base(context)
        {
            
        }
        public string GetStr(int id)
        {
            return base.Get(id).Str;
        }
    }
}