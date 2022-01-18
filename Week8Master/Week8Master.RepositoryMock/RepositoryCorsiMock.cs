using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;
using Week8Master.Core.InterfaceRepositories;

namespace Week8Master.RepositoryMock
{
    public class RepositoryCorsiMock : IRepositoryCorsi //ricorda: aggiungi dipendenze!!
    {
        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso { CorsoCodice ="C-01", Nome="Pre-Academy A", Descrizione="C# corso base"},
            new Corso { CorsoCodice ="C-02", Nome="Academy A", Descrizione="C# corso avanzato"},
            new Corso{ CorsoCodice ="C-03", Nome="Pre Academy B", Descrizione ="Bo"}
        };
        public Corso Add(Corso item)
        {
            Corsi.Add(item);
            return item;
        }

        public bool Delete(Corso item)
        {
            Corsi.Remove(item);
            return true;
        }

        public IList<Corso> GetAll()
        {
            return Corsi;
        }

        public Corso GetByCode(string codice)
        {
            return Corsi.FirstOrDefault(c =>c.CorsoCodice == codice);
            //oppure : 
            //    return GetAll().FirstOrDefault()c =>c.CorsoCoduce == codice);

        }

        public Corso Update(Corso item)
        {
           foreach(var c in Corsi)
            {
                if(c.CorsoCodice==item.CorsoCodice)
                {
                    c.Nome = item.Nome;
                    c.Descrizione = item.Descrizione;   
                    return c;
                }


            }
           return null; //non è riuscito ad aggiornare il corso.                                           
        }
    }
}
