using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Master.Core.Entities
{
    public class Studente: Persona 
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }

        //FK verso codice
        public string CorsoCodice { get; set; }
        public Corso Corso { get; set; } //nav prop

        public override string ToString()
        {
            return base.ToString() + $" nato il {DataNascita.ToShortDateString()} - titolo di studio: " +
                $"{TitoloStudio}";
        }

       
    }
}
