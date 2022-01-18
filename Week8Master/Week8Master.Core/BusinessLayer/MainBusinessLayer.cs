using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;
using Week8Master.Core.InterfaceRepositories;

namespace Week8Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo; //creo una variabile 
        private readonly IRepositoryStudenti studentiRepo; //devo passare un irepositorystudenti al
        //public mainbusinesslayer
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;

        //faccio il costruttore per ogg di tipo mainbusinesslayer: 
        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryStudenti studenti, IRepositoryDocenti docenti,
            IRepositoryLezioni lezioni) 
        {
            //poi la devo assegnare alla proprietà corsiRepo/studentiRepo
            corsiRepo = corsi;
            studentiRepo = studenti;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
        }

        public Esito AddNuovaLezione(Lezione nuovaLezione)
        {
           lezioniRepo.Add(nuovaLezione);
            return new Esito { Messaggio ="Lezione aggiunta correttamente", IsOK = true };  
        }

        public Esito AddNuovoCorso(Corso nuovoCorso)
        {
            //controllo se il codice inserito dall'utente già esiste. 
           // corsiRepo.GetAll().FirstOrDefault(c => c.CorsoCodice == nuovoCorso.CorsoCodice); //faccio
            //il filtro.
            //OPPURE: 
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoCorso.CorsoCodice);
            if(corsoEsistente == null)
            {

                corsiRepo.Add(nuovoCorso);

                return new Esito { Messaggio = "Corso aggiunto correttamente", IsOK = true };
            }
            else
            {
                return new Esito { Messaggio = "Impossibile aggiungere il corso. Codice già presente", IsOK=false };
            }

        }

        public Esito AddNuovoDocente(Docente nuovoDocente)
        {
            bool exsists = docentiRepo.DocenteEsiste(nuovoDocente.Nome, nuovoDocente.Cognome, nuovoDocente.Email);
            if (exsists == false)
            {
                docentiRepo.Add(nuovoDocente);
                return new Esito { Messaggio = "Docente aggiunto con successo", IsOK = true };

            }
            else
            {
                return new Esito
                {
                    Messaggio = "Impossibile aggiungere docente. Il docente esiste già.",
                    IsOK = false
                };

            }

        }

        public Esito AddNuovoStudente(Studente nuovoStudente)
        {
            //Studente studenteEsistente = studentiRepo.GetById(nuovoStudente.ID);
            bool exsists = studentiRepo.StudenteEsiste(nuovoStudente.Nome, nuovoStudente.Cognome, nuovoStudente.Email);
            if (exsists== false)
            {
                studentiRepo.Add(nuovoStudente);
                return new Esito { Messaggio = "Studente aggiunto con successo", IsOK = true };

            }
            else
            {
                return new Esito
                {
                    Messaggio = "Impossibile aggiungere studente. ID dello studente esiste già.",
                    IsOK = false
                };

            }
        }

        public List<Corso> GetAllCorsi() 
        {
            return corsiRepo.GetAll().ToList(); //tolist per trasformare ilist in list. 
            
        }

        public List<Docente> GetAllDocenti()
        {
            return docentiRepo.GetAll().ToList();
        }

        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.GetAll().ToList();
        }

        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll().ToList();
        }

        public List<Lezione> LezioniCodeCorso(string? codice)
        {
            return lezioniRepo.GetByCorsoCode(codice);
        }

        public List<Lezione> LezioniNomeCorso(string? nome)
        {
            var corso= corsiRepo.GetAll().FirstOrDefault(c=>c.Nome==nome);
            if (corso == null)
            {
                return null;
            }
            else
            {
                return lezioniRepo.GetByCorsoCode(corso.CorsoCodice);
            }
        }

        public Esito ModicaLezione(int id, string? aula)
        {
            var lezioneEsistente = lezioniRepo.GetById(id);
            if (lezioneEsistente == null)
            {
                return new Esito { Messaggio = "Codice inesistente o errato", IsOK = false };

            }
            else
            {
                lezioneEsistente.Aula = aula;
                lezioniRepo.Update(lezioneEsistente); //lo devo anche aggiornare 
                return new Esito { Messaggio = "Aula modificata correttamente", IsOK = true };
            }
        }

        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione)
        {
            //verifico che esiste il codice inserito dall'utente
           var corsoEsistente= corsiRepo.GetByCode(codice);
            if(corsoEsistente==null)
            {
                return new Esito { Messaggio = "Codice inesistente o errato", IsOK = false };

            }else
            {
                corsoEsistente.Nome = nuovoNome;
                corsoEsistente.Descrizione = nuovaDescrizione;
                corsiRepo.Update(corsoEsistente); //lo devo anche aggiornare 
                return new Esito { Messaggio="Corso modificato correttamente", IsOK=true };
            }


        }

        public Esito ModificaDocente(int id, string? email, string? telefono)
        {
            var docenteEsistente =docentiRepo.GetById(id);
            if(docenteEsistente==null)
            {
                return new Esito { Messaggio = "ID inesistente o errato", IsOK = false };
            }
            else
            {
                docenteEsistente.Email = email; 
                docenteEsistente.Telefono=telefono;
                docentiRepo.Update(docenteEsistente);
                return new Esito { Messaggio = "Modifica avvenuta con successo", IsOK = true };
            }
        }

        public Esito ModificaStudente(int id, string? email)
        {
            var studenteEsistente =studentiRepo.GetById(id);
            if(studenteEsistente==null)
            {
                return new Esito { Messaggio = "ID inesistente o errato" ,IsOK=false};
            }
            else
            {
                studenteEsistente.Email = email;
                studentiRepo.Update(studenteEsistente);
                return new Esito { Messaggio = "Modifica avvenuta con successo", IsOK = true };

            }
        }

        public Esito RimuoviCorso(string? codice)
        {
            var corsoEsistente = corsiRepo.GetByCode(codice);
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "Codice inesistente o errato", IsOK = false };

            }
            else
            {
                corsiRepo.Delete(corsoEsistente);
                return new Esito { Messaggio = "Corso eliminato correttamente", IsOK=true };
            }
        }

        public Esito RimuoviDocente(int id)
        {
            var docenteEsistene = docentiRepo.GetById(id);
            if (docenteEsistene == null)
            {
                return new Esito { Messaggio = "Id non presente o errato", IsOK = false };

            }
            else
            {
                docentiRepo.Delete(docenteEsistene);
                return new Esito { Messaggio = "Cancellazione avvenuta con successo.", IsOK = true };
            }
        }

        public Esito RimuoviStudente(int id)
        {
            var studenteEsistene = studentiRepo.GetById(id);
            if(studenteEsistene == null)
            {
                return new Esito { Messaggio = "Id non presente o errato", IsOK = false };

            }
            else
            {
                studentiRepo.Delete(studenteEsistene);
                return new Esito { Messaggio = "Cancellazione avvenuta con successo.", IsOK = true };
            }
        }

        public List<Studente> StudentiCorso(string? codice)
        {
            return (List<Studente>)studentiRepo.GetByCorsoCode(codice);
        }
    }
}
