using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Master.Core.InterfaceRepositories
{
    public interface IRepository<T> //metti public + tipo generico T
    {
        //operazioni in comune a tutte le entità --> CRUD (CREATE, RIMUOVI, UPDATE, DELETE)
        public IList<T> GetAll(); //mi prende tutto di quella entità specifica
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);



    }
}
