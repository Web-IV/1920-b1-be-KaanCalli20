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
        public Evenement getEvenementById(int Id)
        {
            return getEvenementen().SingleOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Evenement> getEvenementen()
        {
            return _evenementen.Include(m => m.Locatie).Include(p => p.Attracties).OrderBy(m=>m.StartMoment).ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
