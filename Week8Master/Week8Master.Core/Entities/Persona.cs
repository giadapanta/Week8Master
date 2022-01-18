using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Master.Core.Entities
{
    public abstract class Persona //public abstract
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{ID} - {Nome} {Cognome} - email: {Email}";
        }
    }
}
