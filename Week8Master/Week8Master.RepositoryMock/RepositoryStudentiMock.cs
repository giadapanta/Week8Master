using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;
using Week8Master.Core.InterfaceRepositories;

namespace Week8Master.RepositoryMock
{
    public class RepositoryStudentiMock : IRepositoryStudenti
    {
        public static List<Studente> Studenti = new List<Studente>()
        {
            new Studente(){ID = 1, Nome="Mario", Cognome="Rossi", DataNascita=new DateTime(2000,02,15),
                Email="mariorossi@uni.it", TitoloStudio="Diploma liceo scientifico", CorsoCodice="C-01"},
            new Studente(){ ID = 2, Nome="Anna", Cognome ="Bianchi", DataNascita=new DateTime(1999,01,13),
            Email="annabianchi@uni.it", TitoloStudio="Diploma liceo classico", CorsoCodice="C-01"}
        };
        public Studente Add(Studente item)
        {
           //vedo se la lista è piena
           if(Studenti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach(var student in Studenti)
                {
                    if(student.ID > maxId)
                    {
                        maxId = student.ID; 
                    }

                }
                item.ID = maxId+1;
            }
                     
            Studenti.Add(item);
            return item;
        }

        public bool Delete(Studente item)
        {
            Studenti.Remove(item);
            return true;
        }

        public IList<Studente> GetAll()
        {
            return Studenti;
        }

        public IList<Studente> GetByCorsoCode(string? codice)
        {
           return (IList<Studente>)Studenti.Where(s => s.CorsoCodice == codice).ToList();
                        
        }

        public Studente GetById(int id)
        {
            return Studenti.FirstOrDefault(s=>s.ID==id);
        }

        public bool StudenteEsiste(string nome, string cognome, string email)
        {
            foreach(var s in Studenti)
            {
                if(!(s.Nome == nome && s.Cognome== cognome && s.Email == email))
                {
                    return false;
                }
                
            }
            return true;
        }

        public Studente Update(Studente item)
        {
            foreach(var s in Studenti)
            {
                if (s.ID == item.ID)
                {
                    s.Email = item.Email;
                    return s;
                }
                
            }
            return null;

        }
    }
}
