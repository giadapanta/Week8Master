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
    public class RepositoryLezioniEF : IRepositoryLezioni

    {
        private readonly MasterContext ctx;

        public RepositoryLezioniEF()
        {
        }
        public Lezione Add(Lezione item)
        {
            using(var ctx = new MasterContext())
            {
                ctx.Add(item);
                ctx.SaveChanges();
                return item;
            }
        }

        public bool Delete(Lezione item)
        {
            using(var ctx=new MasterContext())
            {
                ctx.Remove(item);
                ctx.SaveChanges();
                return true;

            }
        }

        public IList<Lezione> GetAll()
        {
          using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(d=>d.Docente).Include(c=>c.Corso).ToList();  
                    }
        }

        public List<Lezione> GetByCorsoCode(string? codice)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Lezioni.Include(d => d.Docente).Include(c => c.Corso).Where(l=>l.CorsoCodice==codice).ToList();
            }
        }

        public Lezione GetById(int id)
        {
            using(var ctx= new MasterContext())
            {
                return ctx.Lezioni.FirstOrDefault(l=>l.LezioneID==id);
            }
        }

        public List<Lezione> GetByNomeCorso(string? nome)
        {
            throw new NotImplementedException();
        }

        public Lezione Update(Lezione item)
        {
            throw new NotImplementedException();
        }
    }
}
