using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web4BackEnd.DTOs;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EvenenemtController : ControllerBase
    {
        private readonly IEvenementRepository _evenementRepository;
        private readonly ILocatieRepository _locatieRepository;
        private readonly IAttractieRepository _attractieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        public EvenenemtController(IEvenementRepository evenementRepository, ILocatieRepository locatieRepository,
            IAttractieRepository attractieRepository,IGebruikerRepository gebruikerRepository)
        {
            _evenementRepository = evenementRepository;
            _locatieRepository = locatieRepository;
            _attractieRepository = attractieRepository;
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Evenementen
        /// <summary>
        /// Get all evenenmenten ordered by Date
        /// </summary>
        /// <returns>array of evenementen</returns>
        [HttpGet]
       // [AllowAnonymous]
        public IEnumerable<Evenement> GetEvenementen()
        {
            return _evenementRepository.GetEvenementen().OrderBy(r => r.StartMoment);
        }

        [HttpGet("{id}")]
        public ActionResult<Evenement> GetEvenement(int id)
        {
            Evenement evenement = _evenementRepository.GetEvenementById(id);
            if (evenement == null) return NotFound();
            return evenement;
        }

        [HttpGet("IngeschrevenEvenementen")]
        public IEnumerable<IngeschrevenEvenement> GetIngeschrevenEvenementen()
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(User.Identity.Name);
            return gebruiker.IngeschrevenEvenementen;
        }

        [HttpPost]
        public ActionResult<Evenement> CreateEvenement(EvenementDTO evenementDTO)
        {
            try
            {
                Locatie locatie = _locatieRepository.GetLocatieById(evenementDTO.LocatieId);
                if (locatie == null)
                {
                    return BadRequest();
                }
                Evenement evenement = new Evenement()
                {
                    NaamEvent = evenementDTO.NaamEvent,
                    Locatie = locatie,
                    MaxAantalDeelnemers = evenementDTO.MaxAantalDeelnemers,
                    StartMoment = evenementDTO.StartMoment
                };
                Attractie attractie;
                foreach (int id in evenementDTO.AttractiesIDs)
                {
                    attractie=_attractieRepository.GetAttractieById(id);
                    if (attractie != null) evenement.VoegAttractieToe(attractie);
                }
                
                _evenementRepository.Add(evenement);
                _evenementRepository.SaveChanges();
                return CreatedAtAction(nameof(GetEvenement), new { id = evenement.Id }, evenement);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutEvenement(int id, Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return BadRequest();
            }
            _evenementRepository.Update(evenement);
            _evenementRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvenement(int id)
        {
            Evenement evenement = _evenementRepository.GetEvenementById(id);
            if (evenement == null)
            {
                return NotFound();
            }
            _evenementRepository.Delete(evenement);
            _evenementRepository.SaveChanges();
            return NoContent();
        }

        [HttpGet("{id}/attracties/{attractieId}")]
        public ActionResult<Attractie> GetAttractie(int id, int attractieId)
        {
            Evenement evenement = _evenementRepository.GetEvenementById(id);
            if (evenement==null)
            {
                return NotFound();
            }
            Attractie attractie = evenement.GetAttractie(attractieId);
            if (attractie == null)
                return NotFound();
            return attractie;
        }
    }
}