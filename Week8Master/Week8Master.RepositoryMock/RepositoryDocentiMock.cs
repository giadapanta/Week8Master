using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;
using Week8Master.Core.InterfaceRepositories;

namespace Week8Master.RepositoryMock
{
    public class RepositoryDocentiMock : IRepositoryDocenti
    {
        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente(){ ID = 1, Nome = "Marco", Cognome="Rossi", Email="marcorossi@prof.it", Telefono="3401231231" },
            new Docente(){ ID = 2, Nome ="Maria", Cognome="Verdi", Email="mariaverdi@prof.it", Telefono ="3291231231"}
        };

        public Docente Add(Docente item)
        {
            if (Docenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var d in Docenti)
                {
                    if (d.ID > maxId)
                    {
                        maxId = d.ID;
                    }

                }
                item.ID = maxId + 1;
            }
            Docenti.Add(item);  
            return item;
        }

        public bool Delete(Docente item)
        {
            Docenti.Remove(item);
            return true;
        }

        public bool DocenteEsiste(string nome, string cognome, string email)
        {
            foreach (var s in Docenti)
            {
                if (!(s.Nome == nome && s.Cognome == cognome && s.Email == email))
                {
                    return false;
                }

            }
            return true;
        }

        public IList<Docente> GetAll()
        {
           return Docenti;
        }

        public Docente GetById(int iD)
        {
            return Docenti.FirstOrDefault(d => d.ID == iD);
        }

        public Docente Update(Docente item)
        {
           foreach(var d in Docenti)
            {
                d.Email = item.Email;
                d.Telefono = item.Telefono;
                return d;
            }
           return null;
        }
    }
}
