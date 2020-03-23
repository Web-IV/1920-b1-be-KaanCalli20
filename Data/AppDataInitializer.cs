using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data
{
    public class AppDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        //private readonly UserManager<Gebruiker> _userManager;
        public AppDataInitializer(ApplicationDbContext context/*, UserManager<Gebruiker> userManager*/)
        {
            this._dbContext = context;
            //this._userManager = userManager;
        }
        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {

                ICollection<Locatie> locaties = new List<Locatie>();
                Locatie locatie1 = new Locatie() { LocatieNaam = "Schotte", Straat = "eenmeistraat", Nr = "15", PlaatsNaam = "Aalst", Postcode = "9300" };

                Locatie locatie2 = new Locatie() { LocatieNaam = "Sporthal", Straat = "paardstraat", Nr = "11", PlaatsNaam = "Gent", Postcode = "9000" };

                locaties.Add(locatie1);
                locaties.Add(locatie2);
                _dbContext.Locaties.AddRange(locaties);

                ICollection<Attractie> attracties1 = new List<Attractie>();
                Attractie attractie1 = new Attractie() { Naam = "Wilde rat", Omschrijving = "Een heel grote attraxtrigorvzoc", TypeAttractie=TypeAttractie.Eenpersoons};
                Attractie attractie2 = new Attractie() { Naam = "Wilde muis", Omschrijving = "Een heel leuke attraxtrigorvzoc" ,TypeAttractie=TypeAttractie.MeerderePersonen};

                attracties1.Add(attractie1);
                attracties1.Add(attractie2);

                _dbContext.Attracties.AddRange(attracties1);

                DateTime datum = new DateTime(2020, 04, 17, 11, 0, 0);

                Evenement evenement = new Evenement()
                {
                    NaamEvent = "Evenement0001",
                    Attracties = attracties1,
                    Locatie = locatie1,
                    StartMoment = datum,
                    MaxAantalDeelnemers = 150

                };
                _dbContext.Evenementen.Add(evenement);
                ICollection<Attractie> attracties2 = new List<Attractie>();

                Attractie attractie3 = new Attractie() { Naam = "Wilde tijger",  Omschrijving = "Een heel kleine attraxtrigorvzoc",TypeAttractie=TypeAttractie.MeerderePersonen };
                Attractie attractie4 = new Attractie() { Naam = "KLeine leeuw", Omschrijving = "Een kleien leeuw attraxtrigorvzoc" ,TypeAttractie=TypeAttractie.Eenpersoons};

                attracties2.Add(attractie3);
                attracties2.Add(attractie4);

                _dbContext.Attracties.AddRange(attracties2);

                datum = new DateTime(2020, 04, 11, 10, 0, 0);

                evenement = new Evenement()
                {
                    NaamEvent = "Evenement0002",
                    Attracties = attracties2,
                    Locatie = locatie2,
                    StartMoment = datum,
                    MaxAantalDeelnemers=25
                };

                _dbContext.Evenementen.Add(evenement);

                _dbContext.SaveChanges();
            }
        }
    }
}
