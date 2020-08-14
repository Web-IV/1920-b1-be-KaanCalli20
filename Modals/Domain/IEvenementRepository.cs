using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public interface IEvenementRepository
    {
        Evenement GetEvenementById(int Id);

        IEnumerable<Evenement> GetEvenementen();
        void Add(Evenement evenement);
        void Delete(Evenement evenement);
        void Update(Evenement evenement);
        void SaveChanges();

        Evenement getEvenementByIdIngeschreven(int Id);
    }
}
