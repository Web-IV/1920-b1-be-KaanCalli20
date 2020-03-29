using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public interface ILocatieRepository
    {
        Locatie GetLocatieById(int Id);
        IEnumerable<Locatie> GetLocaties();
        void Add(Locatie locatie);
        void Delete(Locatie locatie);
        void Update(Locatie locatie);
        void SaveChanges();
    }
}
