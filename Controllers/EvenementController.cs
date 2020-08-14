using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;
using Web4BackEnd.DTOs;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementRepository _evenementRepository;
        private readonly ILocatieRepository _locatieRepository;
        private readonly IAttractieRepository _attractieRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public EvenementController(IEvenementRepository evenementRepository, ILocatieRepository locatieRepository,
            IAttractieRepository attractieRepository, IGebruikerRepository gebruikerRepository)
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
        [EnableCors]
        [AllowAnonymous]
        public IEnumerable<Evenement> GetEvenementen()
        {
            return _evenementRepository.GetEvenementen().OrderBy(r => r.StartMoment);
        }

        // GET: api/Evenement
        /// <summary>
        /// Get evenenment by id
        /// </summary>
        /// <returns>evenement</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Evenement> GetEvenement(int id)
        {
            Evenement evenement = _evenementRepository.GetEvenementById(id);
            if (evenement == null) return NotFound();
            return evenement;
        }



        // Post: api/CreateEvenement
        /// <summary>
        /// Create Evenement
        /// </summary>
        /// <returns>evenement</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
                    Omschrijving = evenementDTO.Omschrijving,
                    Locatie = locatie,
                    MaxAantalDeelnemers = evenementDTO.MaxAantalDeelnemers,
                    EindMoment = evenementDTO.getEindMoment(),
                    StartMoment = evenementDTO.getStartMoment()

                };

                foreach (int attractieId in evenementDTO.AttractiesIds)
                {
                    Attractie attractie = _attractieRepository.GetAttractieById(attractieId);
                    if (attractie != null) evenement.VoegAttractieToe(attractie);
                }

                _evenementRepository.Add(evenement);
                _evenementRepository.SaveChanges();
                return CreatedAtAction(nameof(GetEvenement), new { id = evenement.Id }, evenement);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Put: api/UpdateEvenement
        /// <summary>
        /// Update Evenement
        /// </summary>
        /// <returns>evenement</returns>
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
        // Delete: api/DeleteEvenement
        /// <summary>
        /// Delete Evenement
        /// </summary>
        /// <returns>evenement</returns>
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

        // Post: api/GetEvenement
        /// <summary>
        /// Get Attractie van Evenement
        /// </summary>
        /// <returns>evenement</returns>
        [HttpGet("{id}/attracties/{attractieId}")]
        public ActionResult<Attractie> GetAttractie(int id, int attractieId)
        {
            Evenement evenement = _evenementRepository.GetEvenementById(id);
            if (evenement == null)
            {
                return NotFound();
            }
            Attractie attractie = evenement.GetAttractie(attractieId);
            if (attractie == null)
                return NotFound();
            return attractie;
        }

        // Put: api/Evenement/Inschrijven
        /// <summary>
        /// Deelnemer inschrijven
        /// </summary>
        /// <returns>evenement</returns>
        [HttpPut("inschrijven/{id}")]
        [Authorize(Roles = "Lid")]
        public IActionResult Inschrijven(int id)
        {
            try
            {
                Gebruiker gebruiker = this._gebruikerRepository.GetBy(HttpContext.User.Identity.Name);
                if (gebruiker == null)
                {
                    return NotFound("Gebruiker bestaat niet");
                }

                Evenement evenement = this._evenementRepository.GetEvenementById(id);
                if (evenement == null)
                {
                    return NotFound("Evenement bestaat niet");
                }
                evenement.SchrijfIn(gebruiker);
                _evenementRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// Put: api/Evenement/Uitschrijven
        /// <summary>
        /// Deelnemer Uitschrijven
        /// </summary>
        /// <returns>evenement</returns>
        [HttpPut("uitschrijven/{id}")]
        [Authorize(Roles = "Lid")]
        public IActionResult Uitschrijven(int id)
        {
            try
            {

                Gebruiker gebruiker = this._gebruikerRepository.GetBy(HttpContext.User.Identity.Name);
                if (gebruiker == null)
                {
                    return NotFound("Gebruiker bestaat niet");
                }

                Evenement evenement = this._evenementRepository.GetEvenementById(id);
                if (evenement == null)
                {
                    return NotFound("Evenement bestaat niet");
                }
                evenement.SchrijfUit(gebruiker);
                _evenementRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// Get: api/Evenement/checkIngeschreven
        /// <summary>
        /// checkIngeschreven
        /// </summary>
        /// <returns>boolean</returns>
        [HttpGet("isIngeschreven/{id}")]
        public ActionResult<Boolean> isIngeschreven(int id)
        {
            try
            {
                Gebruiker gebruiker = this._gebruikerRepository.GetBy(HttpContext.User.Identity.Name);
                if (gebruiker == null)
                {
                    return NotFound("Gebruiker bestaat niet");
                }

                Evenement evenement = this._evenementRepository.GetEvenementById(id);
                if (evenement == null)
                {
                    return NotFound("Evenement bestaat niet");
                }

                return evenement.isIngeschreven(gebruiker);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// Get: api/Evenement/aantalIngeschreven
        /// <summary>
        /// Get aantalIngeschreven
        /// </summary>
        /// <returns>int</returns>
        [HttpGet("aantalDeelnemers/{id}")]
        [AllowAnonymous]
        public ActionResult<int> aantalIngeschreven(int id)
        {
            try
            {
             
                Evenement evenement = this._evenementRepository.getEvenementByIdIngeschreven(id);
                if (evenement == null)
                {
                    return NotFound("Evenement bestaat niet");
                }
                
                return evenement.Deelnemers.Count;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}