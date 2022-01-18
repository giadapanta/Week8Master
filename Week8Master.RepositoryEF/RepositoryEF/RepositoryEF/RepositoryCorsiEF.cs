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
    public class RepositoryCorsiEF : IRepositoryCorsi
    {
        private readonly MasterContext ctx;

        public RepositoryCorsiEF()
        {
        }

        //public RepositoryCorsiEF(MasterContext context)
        //{
        //    ctx= context;
        //}
        public Corso Add(Corso item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Corsi.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Corso item)
        {
           using(var ctx = new MasterContext())
            {
                ctx.Corsi.Remove(item);
                ctx.SaveChanges();
            }
           return true;
        }

        public IList<Corso> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Corsi.Include(c => c.Studenti).Include(c => c.Lezioni).ToList();
            }
            //porto dietro tutte le info degli studenti e delle lezioni. 

        }

        public Corso GetByCode(string codice)
        {
            using (var ctx = new MasterContext())
            {

                return ctx.Corsi.Include(c => c.Studenti).Include(c => c.Lezioni).FirstOrDefault(c => c.CorsoCodice == codice);
            }
        }

        public Corso Update(Corso item)
        {
            using(var ctx =new MasterContext())
            {
              ctx.Corsi.Update(item);
                ctx.SaveChanges();
                return item;
            }
        }
    }
}
