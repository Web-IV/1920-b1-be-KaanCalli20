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
    public class LocatieController : ControllerBase
    {
        private readonly ILocatieRepository _locatieRepository;

        public LocatieController(ILocatieRepository locatieRepository)
        {
            _locatieRepository = locatieRepository;
        }
        // GET: api/Locaties
        /// <summary>
        /// Get all Locaties
        /// </summary>
        /// <returns>locaties</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Locatie> GetLocaties()
        {
            return _locatieRepository.GetLocaties();
        }
        // Post: api/Locaties
        /// <summary>
        /// Create Locatie
        /// </summary>
        /// <returns>locatie</returns>
        [HttpPost]
        public ActionResult<Attractie> PostLocatie(LocatieDTO locatieDTO)
        {
            Locatie locatie = new Locatie() { LocatieNaam = locatieDTO.LocatieNaam, Straat = locatieDTO.Straat, Nr = locatieDTO.Nr, Postcode=locatieDTO.Postcode, PlaatsNaam=locatieDTO.PlaatsNaam };
            _locatieRepository.Add(locatie);
            _locatieRepository.SaveChanges();

            return CreatedAtAction(nameof(GetLocaties), new { id = locatie.Id }, locatie);
        }
        // Put: api/Locaties
        /// <summary>
        /// Update Locatie
        /// </summary>
        /// <returns>locatie</returns>
        [HttpPut("{id}")]
        public IActionResult PutLocatie(int id, Locatie locatie)
        {
            if (id != locatie.Id)
            {
                return BadRequest();
            }
            _locatieRepository.Update(locatie);
            _locatieRepository.SaveChanges();
            return NoContent();
        }

        // Put: api/Locaties
        /// <summary>
        /// Delete Locatie
        /// </summary>
        /// <returns>No content </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteLocatie(int id)
        {
            Locatie locatie = _locatieRepository.GetLocatieById(id);
            if (locatie == null)
            {
                return NotFound();
            }
            _locatieRepository.Delete(locatie);
            _locatieRepository.SaveChanges();
            return NoContent();
        }
    }
}