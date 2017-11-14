using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models.BPV
{
    public class BPVHipRepository : IRepository<BPVHipEntryFull>
    {
        private BPVHipContext db;

        public BPVHipRepository(BPVHipContext context)
        {
            this.db = context;
        }

        public IEnumerable<BPVHipEntryFull> GetAll()
        {
            return db.BPVEntries;
        }

        public BPVHipEntryFull Get(int id)
        {
            return db.BPVEntries.Find(id);
        }

        public void Create(BPVHipEntryFull entry)
        {
            db.BPVEntries.Add(entry);
        }

        public void Update(BPVHipEntryFull book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BPVHipEntryFull book = db.BPVEntries.Find(id);
            if (book != null)
                db.BPVEntries.Remove(book);
        }
    }
}
