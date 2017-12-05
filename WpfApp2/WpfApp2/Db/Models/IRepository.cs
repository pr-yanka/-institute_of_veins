using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Db.Models
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; }
        T Get(int Id);

        void Add(T entity);
        void AddRange(T entities);

        void Remove(T entity);
        void RemoveRange(T entities);
        
    }
}
