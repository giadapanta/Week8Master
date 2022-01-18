using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;

namespace Week8Master.Core.InterfaceRepositories
{
    public interface IRepositoryDocenti : IRepository<Docente>
    {
       public Docente GetById(int iD);
       public bool DocenteEsiste(string nome, string cognome, string email);
    }
}
