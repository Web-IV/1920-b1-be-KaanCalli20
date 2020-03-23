using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web4BackEnd.Modals.Domain
{
    public interface IAttractieRepository
    {
        Attractie getAttractieById(int Id);

        IEnumerable<Attractie> GetAttracties();
        void Add(Attractie attractie);
        void Delete(Attractie attractie);
        void Update(Attractie attractie);
        void SaveChanges();
    }
}
