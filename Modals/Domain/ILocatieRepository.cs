using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public interface ILocatieRepository
    {
        Locatie getLocatieById(int Id);
        IEnumerable<Locatie> getLocaties();
        void Add(Locatie locatie);
        void Delete(Locatie locatie);
        void Update(Locatie locatie);
        void SaveChanges();
    }
}
