using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public interface IEvenementRepository
    {
        Evenement getEvenementById(int Id);

        IEnumerable<Evenement> getEvenementen();

        void SaveChanges();
    }
}
