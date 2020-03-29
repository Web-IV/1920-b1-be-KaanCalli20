using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Gebruikers
        /// <summary>
        /// Get all gebruikers
        /// </summary>
        /// <returns>gebruiker</returns>
        [HttpGet]
        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikerRepository.GetAll();
        }

        // GET: api/Gebruikers
        /// <summary>
        /// Get the details of the authenticated gebruiker
        /// </summary>
        /// <returns>gebruiker</returns>
        [HttpGet("{email}")]
        public ActionResult<Gebruiker> GetGebruiker(string email)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(email);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return gebruiker;
        }
        // Delete: api/Gebruikers
        /// <summary>
        /// Delete the gebruiker
        /// </summary>
        /// <returns>gebruiker</returns>
        [HttpDelete("{email}")]
        public ActionResult<Gebruiker> DeleteGebruiker(string email)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(email);
            if (gebruiker == null)
            {
                return NotFound();
            }
            _gebruikerRepository.Delete(gebruiker);
            _gebruikerRepository.SaveChanges();

            return gebruiker;
        }
    }
}