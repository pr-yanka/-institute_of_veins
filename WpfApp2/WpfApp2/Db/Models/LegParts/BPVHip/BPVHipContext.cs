﻿using System.Data.Entity;
using MySql;

namespace WpfApp2.Db.Models.BPV
{
    public class BPVHipContext : DbContext
    {
        public DbSet<BPVHipStructureRepository.BPVHipEntryFull> BPVEntries { get; set; }
    }
}
