using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Data.Mappers;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Evenement> Evenementen { get; set; }
        public DbSet<Attractie> Attracties { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AttractieConfiguration());
            builder.ApplyConfiguration(new EvenementConfiguration());
            builder.ApplyConfiguration(new LocatieConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new IngeschrevenEvenementConfiguration());

        }
    }
}
