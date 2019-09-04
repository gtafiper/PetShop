using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.Entity2;

namespace Pets.Api.Conroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petePetService;
        public PetsController(IPetService petService)
        {
            _petePetService = petService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petePetService.GetAllPets();
        }


    }
}