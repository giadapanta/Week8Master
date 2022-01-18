using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Master.Core.Entities
{
    public class Docente: Persona
    {
        public string Telefono { get; set; }

        public IList<Lezione> Lezioni { get; set; }= new List<Lezione>();    //conviene inizializzarla

        public override string ToString()
        {
            return base.ToString() + $" - telefono: {Telefono}";
        }
    }
}
