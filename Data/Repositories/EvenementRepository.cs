using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Repositories
{
    public class EvenementRepository : IEvenementRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Evenement> _evenementen;

        public EvenementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _evenementen = _dbContext.Evenementen;
        }
        public Evenement GetEvenementById(int Id)
        {
            return GetEvenementen().SingleOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Evenement> GetEvenementen()
        {
            return _evenementen.Include(m => m.Locatie).Include(p => p.Attracties).OrderBy(m=>m.StartMoment).ToList();
        }

        public void Add(Evenement evenement)
        {
            _evenementen.Add(evenement);
        }

        public void Update(Evenement evenement)
        {
            _evenementen.Update(evenement);
        }

        public void Delete(Evenement evenement)
        {
            _evenementen.Remove(evenement);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Evenement getEvenementByIdIngeschreven(int id)
        {
            return  _evenementen.Include(m => m.Locatie).Include(p => p.Attracties).Include(p=>p.Deelnemers)
                .OrderBy(m => m.StartMoment).ToList().SingleOrDefault(p => p.Id == id);


        }


    }
}
