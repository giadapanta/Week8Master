using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;
using Week8Master.Core.InterfaceRepositories;

namespace Week8Master.RepositoryMock
{
    public class RepositoryLezioniMock : IRepositoryLezioni
    {
        public static List<Lezione> Lezioni = new List<Lezione>()
        {
            new Lezione(){ LezioneID = 1, DataOraInizio= new DateTime(2022,02,10,15,30,0), Aula="6.1",Durata=30, DocenteID=1,CorsoCodice="C-01" },
            new Lezione(){LezioneID = 2,DataOraInizio = new DateTime(2022,02,20,9,0,0), Aula="2.8", Durata=20, CorsoCodice ="C-02", DocenteID=2}
        };
        public Lezione Add(Lezione item)
        {
            if (Lezioni.Count == 0)
            {
                item.LezioneID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var l in Lezioni)
                {
                    if (l.LezioneID > maxId)
                    {
                        maxId = l.LezioneID;
                    }

                }
                item.LezioneID = maxId + 1;
            }

            Lezioni.Add(item);
            return item;
        }

        public bool Delete(Lezione item)
        {
            throw new NotImplementedException();
        }

        public IList<Lezione> GetAll()
        {
            return Lezioni;
        }

        public List<Lezione> GetByCorsoCode(string? codice)
        {
            return Lezioni.Where(l=>l.CorsoCodice==codice).ToList();
        }

        public Lezione GetById(int id)
        {
            return Lezioni.FirstOrDefault(l=>l.LezioneID == id);
        }

       

        public Lezione Update(Lezione item)
        {
           
            foreach(var l in Lezioni)
            {
                if (l.LezioneID == item.LezioneID)
                {
                    l.Aula = item.Aula;
                    return l;
                }
            }
            return null;
        }
    }
}
