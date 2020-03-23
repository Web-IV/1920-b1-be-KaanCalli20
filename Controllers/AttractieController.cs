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
    [Route("api/[controller]")]
    [ApiController]
    public class AttractieController : ControllerBase
    {
        private readonly IAttractieRepository _attractieRepository;

        public AttractieController(IAttractieRepository attractieRepository)
        {
            _attractieRepository = attractieRepository;
        }

        [HttpGet]
        public IEnumerable<Attractie> GetAttracties(TypeAttractie? typeAttractie)
        {
            if (!typeAttractie.HasValue)
                return _attractieRepository.GetAttracties();
            return _attractieRepository.GetAttractiesByType(typeAttractie);
        }


        [HttpGet("{id}")]
        public ActionResult<Attractie> GetAttractie(int id)
        {
            Attractie attractie = _attractieRepository.getAttractieById(id);
            if (attractie == null) return NotFound();
            return attractie;
        }


        [HttpPost]
        public ActionResult<Attractie> PostAttractie(AttractieDTO attractieDTO)
        {
            Attractie attractie = new Attractie() { Naam = attractieDTO.Naam, Omschrijving = attractieDTO.Omschrijving, TypeAttractie = attractieDTO.TypeAttractie };
            _attractieRepository.Add(attractie);
            _attractieRepository.SaveChanges();

            return CreatedAtAction(nameof(GetAttractie), new { id = attractie.Id }, attractie);
        }


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



        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            Attractie attractie = _attractieRepository.getAttractieById(id);
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