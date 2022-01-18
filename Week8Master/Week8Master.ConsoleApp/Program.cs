using Week8Master.Core.BusinessLayer;
using Week8Master.Core.Entities;
using Week8Master.RepositoryEF.RepositoryEF;
using Week8Master.RepositoryMock;

//creo un oggetto bl di tipo ibus per accedere ai metodi che ha l'interface e uso il repo repositorycorsimock

//IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryStudentiMock(),
//    new RepositoryDocentiMock(), new RepositoryLezioniMock()); //creami un oggetto bl
//passandogli repositorycorsimock e repositorystudentimock. 
//che a sua volta è figlio di irepositorycorsi quindi è un irepositorycorsi
//riga 7 mi serve per far parlare i progetti.

//quando lavoro con ENTITYFRAMEWORK -> non devo fare più ibusinesslaYER bl ecc
//vado a mettere: 
IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiEF(), new RepositoryStudentiEF(),
   new RepositoryDocentiEF(), new RepositoryLezioniEF());


bool continua = true;

while (continua)
{
    int scelta = SchermoMenu();
    continua = AnalizzaScelta(scelta);
}
int SchermoMenu()
{
    Console.WriteLine("**********MENU**********");
    Console.WriteLine("\nFunziolità Corsi");
    Console.WriteLine("1.Visualizza Corsi");
    Console.WriteLine("2.Inserire un nuovo corso");
    Console.WriteLine("3.Modificare un corso");
    Console.WriteLine("4.Eliminare un corso");
    Console.WriteLine("\nFunziolità Studenti");
    Console.WriteLine("5.Visualizza elenco completo degli Studenti");
    Console.WriteLine("6.Inserire un nuovo studente");
    Console.WriteLine("7.Modificare l'email di uno studente");
    Console.WriteLine("8.Eliminare uno studente");
    Console.WriteLine("9.Visualizza l'elenco degli studenti iscritti ad un corso");
    Console.WriteLine("\nFunzionalità docenti");
    Console.WriteLine("10.Visualizza tutti i docenti");
    Console.WriteLine("11.Inserisci nuovo docente");
    Console.WriteLine("12.Modifica email e telefono di un docente");
    Console.WriteLine("13.Elimina un docente");
    Console.WriteLine("\nFunzionalità lezioni");
    Console.WriteLine("14.Visualizza tutte le lezioni");
    Console.WriteLine("15.Inserisci una lezione");
    Console.WriteLine("16.Modifica l'aula di una lezione");
    Console.WriteLine("17.Visualizza le lezioni di un corso tramite il codice del corso");
    Console.WriteLine("18.Visualizza le lezioni di un corso tramite il nome del corso");
    Console.WriteLine("0.Exit");
    Console.WriteLine("************************");
    int scelta;
    Console.WriteLine("Inserisci la tua scelta: ");
    while(!(int.TryParse(Console.ReadLine(), out scelta) && scelta >=0 && scelta <=18))
    {
        Console.WriteLine("Scelta errata. Inserisci una scelta corretta: ");
    }
    return scelta;
}
bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaCorsi();
            break;
        case 2:
            InserisciCorso();
            break;
        case 3:
            ModificaCorso();
            break;
        case 4:
            EliminaCorso();
            break;
        case 5:
            VisualizzaStudenti();
            break;
        case 6:
            InserisciStudente();
            break;
        case 7:
            ModificaEmailStudente();
            break;
        case 8:
            EliminaStudente();
            break;
        case 9:
            VisualizzaStudentiCorso();
            break;
        case 10:
            VisualizzaDocenti();
            break;
        case 11:
            InserisciDocente();
            break;
        case 12:
            ModificaDocente();
            break;
        case 13:
            EliminaDocente();
            break;
        case 14:
            VisualizzaLezioni();
            break;
        case 15:
            InserisciLezione();
            break;
        case 16:
            ModificaAulaLezione();
            break;
        case 17:
            VisualizzaLezioniByCodeCorso();
            break;
        case 18:
            VisualizzaLezioniByNomeCorso();
            break;
        case 0:
            return false;

            //default:
            //    break;
    }
    return true;
}

void VisualizzaLezioniByNomeCorso()
{
    Console.WriteLine("Elenco completo dei corsi: ");
    VisualizzaCorsi();
    Console.WriteLine("Di quale corso vuoi visualizzare le lezioni? Inserisci il nome del corso: ");
    string nome = Console.ReadLine();
   
    List<Lezione> listaLezioni = bl.LezioniNomeCorso(nome);
    //TODO: listaLezioni == null
    if (listaLezioni == null)
    {
        Console.WriteLine("Nome inesistente o errato");
    }
    else if (listaLezioni.Count == 0)
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach (var lez in listaLezioni)
        {
            Console.WriteLine(lez);
        }
    }

}

void VisualizzaLezioniByCodeCorso()
{
    Console.WriteLine("Elenco completo dei corsi: ");
    VisualizzaCorsi();
    Console.WriteLine("Di quale corso vuoi visualizzare le lezioni? Inserisci il codice del corso: ");
    string codice= Console.ReadLine();
    List<Lezione> listaLezioni = bl.LezioniCodeCorso(codice);
    if (listaLezioni.Count == 0)
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach(var lez in listaLezioni)
        {
            Console.WriteLine(lez);
        }
    }

}

void ModificaAulaLezione()
{
    Console.WriteLine("Elenco delle lezioni: ");
    VisualizzaLezioni();
    Console.WriteLine("A quale lezione vuoi modificare l'aula? Inserisci il suo ID: ");
    int id;
    int.TryParse(Console.ReadLine(), out id);
    Console.WriteLine("Inserisci la nuova aula: ");
    string aula = Console.ReadLine();
    Esito esito = bl.ModicaLezione(id, aula);
    Console.WriteLine(esito.Messaggio);

}

void InserisciLezione()
{
    Console.WriteLine("Aggiungi data e ora: ");
    DateTime dt;
    DateTime.TryParse(Console.ReadLine(), out dt);
    Console.WriteLine("Aggiungi aula: ");
    string aula = Console.ReadLine();
    Console.WriteLine("Aggiungi durata in giorni:  ");
    int durata;
    int.TryParse(Console.ReadLine(), out durata);
    Console.WriteLine("Quale docente terrà il corso?");
    VisualizzaDocenti();
    Console.WriteLine("Inserisci il suo ID: ");
    int docenteID;
    int.TryParse(Console.ReadLine(),out docenteID);
    VisualizzaCorsi();
    Console.WriteLine("Inserisci il codice del corso: ");
    string codice= Console.ReadLine();
    Lezione nuovaLezione= new Lezione();
    nuovaLezione.DataOraInizio = dt;
    nuovaLezione.Aula = aula;
    nuovaLezione.Durata = durata;
    nuovaLezione.DocenteID=docenteID;
    nuovaLezione.CorsoCodice = codice;
    Esito esito = bl.AddNuovaLezione(nuovaLezione);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaLezioni()
{
    List<Lezione> listaLezioni = bl.GetAllLezioni();
    if (listaLezioni.Count == 0) //se è una lista vuota
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach (var item in listaLezioni)
        {
            Console.WriteLine(item);
        }
    }

}

void EliminaDocente()
{
    Console.WriteLine("Elenco di tutti i docenti: ");
    VisualizzaDocenti();
    Console.WriteLine("Quale docente vuoi eliminare? Inserisci il suo ID: ");
    int id;
    int.TryParse(Console.ReadLine(), out id);
    Esito esito = bl.RimuoviDocente(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaDocente()
{
    Console.WriteLine("Elenco di docenti: ");
    VisualizzaDocenti();
    Console.WriteLine("Di quale docente vuoi modificare il numero di telefono e l'email? Inserisci il suo ID: ");
    int id;
    int.TryParse(Console.ReadLine(), out id);
    Console.WriteLine("Inserisci il nuovo indirizzo email: ");
    string email = Console.ReadLine();
    Console.WriteLine("Inserisci il nuovo numero di telefono: ");
    string telefono = Console.ReadLine();
    Esito esito = bl.ModificaDocente(id,email,telefono);
    Console.WriteLine(esito.Messaggio);
}

void InserisciDocente()
{    
    Console.WriteLine("Inserisci il nome del nuovo docente");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome del nuovo docente");
    string cognome = Console.ReadLine();
    Console.WriteLine("inserisci il numero di telefono");
    string telefono = Console.ReadLine();
    Console.WriteLine("inserisce email");
    string email = Console.ReadLine();
    Docente nuovoDocente= new Docente();
    nuovoDocente.Nome = nome;
    nuovoDocente.Cognome = cognome;
    nuovoDocente.Email = email;
    nuovoDocente.Telefono = telefono;
    Esito esito = bl.AddNuovoDocente(nuovoDocente);
    Console.WriteLine(esito.Messaggio);

}

void VisualizzaDocenti()
{
    List<Docente> listaDocenti = bl.GetAllDocenti();
    if (listaDocenti.Count == 0)
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach (var s in listaDocenti)
        {
            Console.WriteLine(s);
        }
    }
}

void VisualizzaStudentiCorso()
{
    Console.WriteLine("Elenco dei corsi: ");
    VisualizzaCorsi();
    Console.WriteLine("Inserisci il codice del corso di cui vuoi visualizzare la lista di studenti: ");
    string codice = Console.ReadLine();
    List<Studente> studentiCorso = bl.StudentiCorso(codice);
    if (studentiCorso.Count == 0)
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach (var s in studentiCorso)
        {
            Console.WriteLine(s);
        }
    }
}

void EliminaStudente()
{
    Console.WriteLine("Elenco di tutti gli studenti: ");
    VisualizzaStudenti();
    Console.WriteLine("Quale studente vuoi eliminare? Inserisci il suo ID: ");
    int id;
    int.TryParse(Console.ReadLine(), out id);
    Esito esito = bl.RimuoviStudente(id);
    Console.WriteLine(esito.Messaggio);
}

void ModificaEmailStudente()
{
    Console.WriteLine("Elenco degli studenti:");
    VisualizzaStudenti();
    Console.WriteLine("Di quale studente vuoi modificare l'email? Inserisci il suo ID:");
    int id; 
    int.TryParse(Console.ReadLine(), out id);
    Console.WriteLine("Inserisci il nuovo indirizzo email: ");
    string email = Console.ReadLine();

    Esito esito = bl.ModificaStudente(id, email);
    Console.WriteLine(esito.Messaggio);

}

void InserisciStudente()
{
    Console.WriteLine("Inserisci il nome del nuovo studente");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome del nuovo studente");
    string cognome = Console.ReadLine();
    Console.WriteLine("inserisci il titolo di studio");
    string titoloStudio= Console.ReadLine();
    Console.WriteLine("inserisce email");
    string email = Console.ReadLine();
    Console.WriteLine("Inserisci data di nascita");
    DateTime dataNascita;
    DateTime.TryParse(Console.ReadLine(),out dataNascita);
    Studente nuovoStudente= new Studente();
    nuovoStudente.Nome = nome;
    nuovoStudente.Cognome = cognome;
    nuovoStudente.TitoloStudio = titoloStudio;
    nuovoStudente.Email = email;
    nuovoStudente.DataNascita = dataNascita;
    Esito esito = bl.AddNuovoStudente(nuovoStudente);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaStudenti()
{
    List<Studente> listaStudenti = bl.GetAllStudenti();

    if(listaStudenti.Count == 0)
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach(var s in listaStudenti)
        {
            Console.WriteLine(s);
        }
    }
}

void EliminaCorso()
{
    Console.WriteLine("Ecco l'elenco dei corsi disponibili: ");
    VisualizzaCorsi();
    Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice: ");
    string codice= Console.ReadLine();
    Esito esito = bl.RimuoviCorso(codice);
    Console.WriteLine(esito.Messaggio);
}

void ModificaCorso()
{
   Console.WriteLine("Ecco l'elenco dei corsi disponibili: ");
    VisualizzaCorsi();
    Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice: ");
    string codice =Console.ReadLine();
    Console.WriteLine("Inserisci il nuovo nome del corso: ");
    string nuovoNome = Console.ReadLine();
    Console.WriteLine("Inserisci la nuova descrizione del corso: ");
    string nuovaDescrizione= Console.ReadLine();
    //il client e il core parlano tramite il bl 
   Esito esito= bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
    Console.WriteLine(esito.Messaggio);

}

void InserisciCorso()
{
    //chiedo all'utente i dati necessari per creare il nuovo corso da aggiungere
    Console.WriteLine("Inserisci il codice del nuovo corso: ");
    string codice= Console.ReadLine();
    Console.WriteLine("Inserisci il nome del nuovo corso: ");
    string nome = Console.ReadLine(); 
    Console.WriteLine("Inserisci la descrizione del nuovo corso: ");
    string descrizione = Console.ReadLine();

    //creo nuovo corso
    Corso nuovoCorso =new Corso();
    nuovoCorso.CorsoCodice = codice;
    nuovoCorso.Nome = nome;
    nuovoCorso.Descrizione = descrizione;

    //adesso devo aggiungerlo -> 
   Esito esito = bl.AddNuovoCorso(nuovoCorso); //ogetto di tipo esito che contiene sia il booleano che 
    Console.WriteLine(esito.Messaggio);        //il messaggio. 

}

void VisualizzaCorsi()
{
    //reucpera la lista dei corsi
    //stampa la lista.  --> aggiungo nelle dipendenze il progetto CORE (le robe devono essere public)
    List<Corso> listaCorsi = bl.GetAllCorsi(); // deve essere popolata con i corsi
    //bl è di tipo ibusinesslayer per cui vedo tutti i metodi contenuti al suo interno
    //stampa corsi

    if (listaCorsi.Count == 0) //se è una lista vuota
    {
        Console.WriteLine("Lista vuota");
    }
    else
    {
        foreach (var item in listaCorsi)
        {
            Console.WriteLine(item);
        }
    }
}