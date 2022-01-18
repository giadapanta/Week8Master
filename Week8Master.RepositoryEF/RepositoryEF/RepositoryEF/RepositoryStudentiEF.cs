using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;
using Week8Master.Core.InterfaceRepositories;

namespace Week8Master.RepositoryEF.RepositoryEF
{
    public class RepositoryStudentiEF : IRepositoryStudenti
    {
        private readonly MasterContext ctx;

        public RepositoryStudentiEF()
        {
        }
        public Studente Add(Studente item)
        {
            using(var ctx = new MasterContext())
            {
                ctx.Studenti.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public bool Delete(Studente item)
        {
            throw new NotImplementedException();
        }

        public IList<Studente> GetAll()
        {
          using(var ctx= new MasterContext())
            {
                return ctx.Studenti.Include(c=>c.Corso).ToList();
            }
        }

        public IList<Studente> GetByCorsoCode(string? codice)
        {
            using(var ctx=new MasterContext())
            {
                return ctx.Studenti.Include(c=>c.Corso).Where(s=>s.CorsoCodice == codice).ToList();
            }
           
        }

        public Studente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool StudenteEsiste(string nome, string cognome, string email)
        {
            throw new NotImplementedException();
        }

        public Studente Update(Studente item)
        {
            throw new NotImplementedException();
        }
    }
}
