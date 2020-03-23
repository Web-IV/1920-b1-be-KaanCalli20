using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data.Repositories
{
    public class AttractieRepository : IAttractieRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Attractie> _attracties;

        public AttractieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _attracties = _dbContext.Attracties;
        }

        public Attractie getAttractieById(int Id)
        {
            return GetAttracties().SingleOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Attractie> GetAttracties()
        {
            return _attracties.ToList();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
