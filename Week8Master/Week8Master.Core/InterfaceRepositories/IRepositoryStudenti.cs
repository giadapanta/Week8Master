using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;

namespace Week8Master.Core.InterfaceRepositories
{
    public interface IRepositoryStudenti: IRepository<Studente>
    {
        public Studente GetById(int id);
        public IList<Studente> GetByCorsoCode(string? codice);
        public bool StudenteEsiste(string nome, string cognome, string email);
    }
}
