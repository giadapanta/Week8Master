using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;

namespace Week8Master.Core.InterfaceRepositories
{
    public interface IRepositoryLezioni : IRepository<Lezione>
    {
        public Lezione GetById(int id);
        public List<Lezione> GetByCorsoCode(string? codice);
       
    }
}
