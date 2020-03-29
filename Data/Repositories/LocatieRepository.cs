using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Repositories
{
    public class LocatieRepository : ILocatieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Locatie> _locaties;

        public LocatieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _locaties = _dbContext.Locaties;
        }

        public Locatie GetLocatieById(int Id)
        {
            return GetLocaties().SingleOrDefault(m => m.Id == Id);
        }

        public IEnumerable<Locatie> GetLocaties()
        {
            return _locaties.ToList();
        }
        public void Add(Locatie locatie)
        {
            _locaties.Add(locatie);
        }

        public void Update(Locatie locatie)
        {
            _locaties.Update(locatie);
        }

        public void Delete(Locatie locatie)
        {
            _locaties.Remove(locatie);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
