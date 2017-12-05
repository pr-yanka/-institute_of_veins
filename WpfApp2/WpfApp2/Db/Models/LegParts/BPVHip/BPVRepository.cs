using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

namespace WpfApp2.Db.Models.BPV
{
    public class BPVHipRepository : IRepository<BPVHipStructure>
    {
        private BPVHipContext db;

        public IEnumerable<BPVHipStructure> List
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BPVHipRepository(BPVHipContext context)
        {
            this.db = context;

        }


        public IEnumerable<IEntity> GetAll()
        {
            return db.BPVEntries;
        }

        public BPVHipStructure Get(int id)
        {
            return db.BPVEntries.Find(id);
        }

        public void Create(BPVHipStructure entry)
        {
            //db.BPVEntries.Add(entry);
        }

        public void Update(BPVHipStructure book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            //BPVHipEntryFull book = db.BPVEntries.Find(id);
            //if (book != null)
            //    db.BPVEntries.Remove(book);
        }

        public void Add(BPVHipStructure entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BPVHipStructure entity)
        {
            throw new NotImplementedException();
        }

        public BPVHipStructure FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
