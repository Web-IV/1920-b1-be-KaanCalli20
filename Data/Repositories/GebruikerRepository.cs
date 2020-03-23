using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _gebruikers = dbContext.Gebruikers;
        }
        public void Add(Gebruiker gebruiker)
        { 
            _gebruikers.Add(gebruiker);
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruikers
                .Include(c => c.IngeschrevenEvenementen)
                .ThenInclude(m => m.Evenement)
                .ThenInclude(p => p.Attracties)
                .SingleOrDefault(e => e.Email == email);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
