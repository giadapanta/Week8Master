using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;

namespace Week8Master.Core.BusinessLayer
{
    public interface IBusinessLayer //la uso come collegamento
    {
        //deve contenere i metodi che voglio chiamare nel program 
        public List<Corso> GetAllCorsi();
        public Esito AddNuovoCorso(Corso nuovoCorso);
        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione);
        public Esito RimuoviCorso(string? codice);
        public List<Studente> GetAllStudenti();
        public Esito AddNuovoStudente(Studente nuovoStudente);
        public Esito ModificaStudente(int id, string? email);
        public Esito RimuoviStudente(int id);
        public List<Studente> StudentiCorso(string? codice);
        public List<Docente> GetAllDocenti();
        public Esito AddNuovoDocente(Docente nuovoDocente);
        public Esito ModificaDocente(int id, string? email, string? telefono);
        public Esito RimuoviDocente(int id);
        public List<Lezione> GetAllLezioni();
        public Esito AddNuovaLezione(Lezione nuovaLezione);
        public Esito ModicaLezione(int id, string? aula);
        public List<Lezione> LezioniCodeCorso(string? codice);
       public List<Lezione> LezioniNomeCorso(string? nome);
    }
}
