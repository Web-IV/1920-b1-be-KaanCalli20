using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web4BackEnd.DTOs;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EvenenemtController : ControllerBase
    {
        private readonly IEvenementRepository _evenementRepository;
        private readonly ILocatieRepository _locatieRepository;
        private readonly IAttractieRepository _attractieRepository;
        public EvenenemtController(IEvenementRepository evenementRepository, ILocatieRepository locatieRepository,
            IAttractieRepository attractieRepository)
        {
            _evenementRepository = evenementRepository;
            _locatieRepository = locatieRepository;
            _attractieRepository = attractieRepository;
        }

        // GET: api/Evenementen
        /// <summary>
        /// Get all evenenmenten ordered by Date
        /// </summary>
        /// <returns>array of evenementen</returns>
        [HttpGet]
        public IEnumerable<Evenement> GetEvenementen()
        {
            return _evenementRepository.getEvenementen().OrderBy(r => r.StartMoment);
        }

        [HttpGet("{id}")]
        public ActionResult<Evenement> GetEvenement(int id)
        {
            Evenement evenement = _evenementRepository.getEvenementById(id);
            if (evenement == null) return NotFound();
            return evenement;
        }

        [HttpPost]
        public ActionResult<Evenement> CreateEvenement(EvenementDTO evenementDTO)
        {
            try
            {
                Locatie locatie = _locatieRepository.getLocatieById(evenementDTO.LocatieId);
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
                    attractie=_attractieRepository.getAttractieById(id);
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
            Evenement evenement = _evenementRepository.getEvenementById(id);
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
            Evenement evenement = _evenementRepository.getEvenementById(id);
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