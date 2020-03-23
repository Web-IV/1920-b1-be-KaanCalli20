using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web4BackEnd.Modals.Domain;

namespace Web4BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatieController : ControllerBase
    {
        private readonly ILocatieRepository _locatieRepository;

        LocatieController(ILocatieRepository locatieRepository)
        {
            _locatieRepository = locatieRepository;
        }
    }
}