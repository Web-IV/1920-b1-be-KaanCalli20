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
    [AllowAnonymous]
    public class AttractieController : ControllerBase
    {
        private readonly IAttractieRepository _attractieRepository;

        public AttractieController(IAttractieRepository attractieRepository)
        {
            _attractieRepository = attractieRepository;
        }

        // Get: api/GetAttracties
        /// <summary>
        /// Get alle attracties
        /// </summary>
        /// <param name="typeAttractie">the type of the attractie</param>
        /// <returns>attracties</returns>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Attractie> GetAttracties(TypeAttractie? typeAttractie)
        {
            if (!typeAttractie.HasValue)
                return _attractieRepository.GetAttracties();
            return _attractieRepository.GetAttractiesByType(typeAttractie);
        }

        // Get: api/GetAttractie
        /// <summary>
        /// Get Attractie
        /// </summary>
        /// <param name="id">the id of the attractie</param>
        /// <returns>attractie</returns>
        [HttpGet("{id}")]
        public ActionResult<Attractie> GetAttractie(int id)
        {
            Attractie attractie = _attractieRepository.GetAttractieById(id);
            if (attractie == null) return NotFound();
            return attractie;
        }

        // Post: api/CreateAttracties
        /// <summary>
        /// Create Attracties
        /// </summary>
        /// <returns>attracties</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Attractie> PostAttractie(AttractieDTO attractieDTO)
        {
            Attractie attractie = new Attractie() { Naam = attractieDTO.Naam, Omschrijving = attractieDTO.Omschrijving, TypeAttractie = attractieDTO.TypeAttractie };
            _attractieRepository.Add(attractie);
            _attractieRepository.SaveChanges();

            return CreatedAtAction(nameof(GetAttractie), new { id = attractie.Id }, attractie);
        }

        // Put: api/PutAttractie
        /// <summary>
        /// Put Attractie
        /// </summary>
        /// <param name="id">the id of the attractie</param>
        /// <param name="attractie">the attractie</param>
        /// <returns>attractie</returns>
        [HttpPut("{id}")]
        public IActionResult PutAttractie(int id, Attractie attractie)
        {
            if (id != attractie.Id)
            {
                return BadRequest();
            }
            _attractieRepository.Update(attractie);
            _attractieRepository.SaveChanges();
            return NoContent();
        }


        // Delete: api/DeleteAttractie
        /// <summary>
        /// Put Attracties
        /// </summary>
        /// <param name="id">the id of the attractuie</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLocatie(int id)
        {
            Attractie attractie = _attractieRepository.GetAttractieById(id);
            if (attractie == null)
            {
                return NotFound();
            }
            _attractieRepository.Delete(attractie);
            _attractieRepository.SaveChanges();
            return NoContent();
        }
    }
}