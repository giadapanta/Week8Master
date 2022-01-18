using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;

namespace Week8Master.Core.InterfaceRepositories
{
    public interface IRepositoryCorsi : IRepository<Corso>
    {
        //posso inserire firme di altri metodi che non sono in comune
        //con le altre entità, come il getbycode
        public Corso GetByCode(string codice);  
        

    }
}
