﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Db.Models.LegParts;

namespace WpfApp2.Db.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext _context;

        public ILegPartRepository BPVHips { get; private set; }

        public UnitOfWork (MySqlContext context)
        {
            _context = context;
            BPVHips = new BPVHipRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
