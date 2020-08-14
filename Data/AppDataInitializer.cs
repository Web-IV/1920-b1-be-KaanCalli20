using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Data
{
    public class AppDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppDataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this._dbContext = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {

                ICollection<Locatie> locaties = new List<Locatie>();
                Locatie locatie1 = new Locatie() { LocatieNaam = "Schotte", Straat = "Kapellekensbaan", Nr = "1", PlaatsNaam = "Aalst", Postcode = "9300",Latitude= 50.9263405, Longitude= 4.0423651 };
                Locatie locatie2 = new Locatie() { LocatieNaam = "EDUGO Arena", Straat = "Sint-Jozefstraat", Nr = "16", PlaatsNaam = "Gent", Postcode = "9041",Latitude= 51.0458078, Longitude= 3.6393603 };
                Locatie locatie3 = new Locatie() { LocatieNaam = "Expo", Straat = "Belgiëplein 1 ", Nr = "15", PlaatsNaam = "Brussel", Postcode = "1020",Latitude= 50.8997337,Longitude= 4.3366863 };

                locaties.Add(locatie1);
                locaties.Add(locatie2);
                locaties.Add(locatie3);
                _dbContext.Locaties.AddRange(locaties);

                ICollection<Attractie> attracties1 = new List<Attractie>();
                ICollection<Attractie> attracties2 = new List<Attractie>();
                ICollection<Attractie> attracties3 = new List<Attractie>();
                Attractie attractie1 = new Attractie() { Naam = "Wilde rat", Omschrijving = "Een heel grote attraxtrigorvzoc", TypeAttractie = TypeAttractie.Eenpersoons };
                Attractie attractie2 = new Attractie() { Naam = "Wilde muis", Omschrijving = "Een heel leuke attraxtrigorvzoc", TypeAttractie = TypeAttractie.MeerderePersonen };
                attracties1.Add(attractie1);
                attracties1.Add(attractie2);
                

                Attractie attractie3 = new Attractie() { Naam = "Wilde tijger", Omschrijving = "Een heel kleine attraxtrigorvzoc", TypeAttractie = TypeAttractie.MeerderePersonen };
                Attractie attractie4 = new Attractie() { Naam = "KLeine leeuw", Omschrijving = "Een kleien leeuw attraxtrigorvzoc", TypeAttractie = TypeAttractie.Eenpersoons };
                attracties2.Add(attractie3);
                attracties2.Add(attractie4);

                Attractie attractie5 = new Attractie() { Naam = "Stoute Giraf", Omschrijving = "Een heel kleine attraxtrigorvzoc", TypeAttractie = TypeAttractie.MeerderePersonen };
                Attractie attractie6 = new Attractie() { Naam = "Ranger Shooter", Omschrijving = "Het beste action game die je tot nu toe gaat hebben.", TypeAttractie = TypeAttractie.Eenpersoons };
                Attractie attractie7 = new Attractie() { Naam = "Long Arrow", Omschrijving = "Tis tijd om een boog in je handen te hebben", TypeAttractie = TypeAttractie.MeerderePersonen };
                Attractie attractie8 = new Attractie() { Naam = "Little bad stuf", Omschrijving = "Soms stoute zaken doen is wel leukk", TypeAttractie = TypeAttractie.Eenpersoons };
                Attractie attractie9 = new Attractie() { Naam = "Crazy horses", Omschrijving = "Paarden met rare gedragen. Soms doen ze wel is gek", TypeAttractie = TypeAttractie.MeerderePersonen };
                Attractie attractie10 = new Attractie() { Naam = "Music4u", Omschrijving = "Tijd voor muziek met je vr", TypeAttractie = TypeAttractie.Eenpersoons };
                attracties3.Add(attractie5);
                attracties3.Add(attractie6);
                attracties3.Add(attractie7);
                attracties3.Add(attractie8);
                attracties3.Add(attractie9);
                attracties3.Add(attractie10);

                _dbContext.Attracties.AddRange(attracties1);
                _dbContext.Attracties.AddRange(attracties2);
                _dbContext.Attracties.AddRange(attracties3);
                DateTime startmoment = new DateTime(2020, 04, 17, 11, 0, 0);
                DateTime eindmoment = new DateTime(2020, 04, 22, 22, 0, 0);
                Evenement evenement = new Evenement()
                {
                    NaamEvent = "SpeelHok",
                    Attracties = attracties1,
                    Locatie = locatie1,
                    StartMoment = startmoment,
                    EindMoment=eindmoment,
                    MaxAantalDeelnemers = 150

                };
                _dbContext.Evenementen.Add(evenement);
                

                startmoment = new DateTime(2020, 04, 11, 10, 0, 0);
                eindmoment = new DateTime(2020, 04, 19, 22, 0, 0);
                evenement = new Evenement()
                {
                    NaamEvent = "Expeditie",
                    Attracties = attracties2,
                    Locatie = locatie2,
                    StartMoment = startmoment,
                    EindMoment = eindmoment,
                    MaxAantalDeelnemers = 25
                };

                _dbContext.Evenementen.Add(evenement);

                startmoment = new DateTime(2020, 06, 02, 10, 0, 0);
                eindmoment = new DateTime(2020, 06, 19, 22, 0, 0);
                evenement = new Evenement()
                {
                    NaamEvent = "OlePlay",
                    Locatie = locatie3,
                    StartMoment = startmoment,
                    EindMoment = eindmoment,
                    MaxAantalDeelnemers = 25
                };

                _dbContext.Evenementen.Add(evenement);

                startmoment = new DateTime(2020, 08, 11, 12, 0, 0);
                eindmoment = new DateTime(2020, 09, 02, 18, 0, 0);
                evenement = new Evenement()
                {
                    NaamEvent = "EveryDayAllDay",
                    Locatie = locatie3,
                    StartMoment = startmoment,
                    EindMoment = eindmoment,
                    MaxAantalDeelnemers = 25
                };

                _dbContext.Evenementen.Add(evenement);
                _dbContext.SaveChanges();

                Gebruiker gebruiker1 = new Gebruiker { Email = "Pieter@hogent.be", Voornaam = "Pieter", Achternaam = "De Koning" };
                gebruiker1.IsAdmin = true;
                _dbContext.Gebruikers.Add(gebruiker1);
                await CreateUser(gebruiker1.Email, "P@ssword1111","Admin");
                
                Gebruiker gebruiker2 = new Gebruiker { Email = "John@hogent.be", Voornaam = "John", Achternaam = "Ward" };
                _dbContext.Gebruikers.Add(gebruiker2);
                evenement =_dbContext.Evenementen.First();
                evenement.SchrijfIn(gebruiker2);
                //gebruiker2.VoegIngeschrevenEvenementToe(_dbContext.Evenementen.First());
                await CreateUser(gebruiker2.Email, "P@ssword1111","Lid");

                gebruiker2 = new Gebruiker { Email = "Kaan@hogent.be", Voornaam = "Kaan", Achternaam = "Calli" };
                _dbContext.Gebruikers.Add(gebruiker2);
                await CreateUser(gebruiker2.Email, "P@ssword1111", "Lid");

                gebruiker2 = new Gebruiker { Email = "Bart@hogent.be", Voornaam = "Bart", Achternaam = "pit" };
                _dbContext.Gebruikers.Add(gebruiker2);
                await CreateUser(gebruiker2.Email, "P@ssword1111", "Lid");

                _dbContext.SaveChanges();
            }
        }
        private async Task CreateUser(string email, string password,string rol)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role,rol));
            IdentityRole identityRole = new IdentityRole(rol);
            await _roleManager.CreateAsync(identityRole);
            await _userManager.AddToRoleAsync(user, rol);


        }

    }
}
