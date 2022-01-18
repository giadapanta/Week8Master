using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Master.Core.Entities
{
    public class Lezione
    {
        public int LezioneID { get; set; }
        public DateTime DataOraInizio { get; set; }
        public int Durata { get; set; }
        public string Aula { get; set; }

        //FK verso docente e corso 
        public int DocenteID { get; set; }
        public Docente Docente { get; set; }
        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; }

        public override string ToString()
        {
            return $"Lezione: {LezioneID} - Data: {DataOraInizio} - Aula: {Aula} - Durata in gg: {Durata} ";
        }

    }
}
