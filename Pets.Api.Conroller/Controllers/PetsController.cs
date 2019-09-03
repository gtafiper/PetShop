using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.Entity;

namespace Pets.Api.Conroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petervice;
        public PetsController(IPetService petService)
        {
            _petervice = petService;
        }

        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return _petervice.GetAllPets();
        }


    }
}