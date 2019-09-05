using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
        public ActionResult<IEnumerable<Pet>> GetAllPets()
        {
            return _petePetService.GetAllPets();
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petePetService.FindPetById(id);
        }

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name) || string.IsNullOrEmpty(pet.Color) || pet.Price <=0)
            {
                return BadRequest("Pets must have a name, a color and a price");
            }
            return _petePetService.CreatePet(pet);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.ID)
            {
                return BadRequest("Parameter id, and pet id must be the same!");
            }
            return Ok(_petePetService.UpdatePet(pet));
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> Delet(int id)
        {
            var pet = _petePetService.DeltedPet(id);
            if (pet == null)
            {
                return StatusCode(404, "Did not find a pet with Id of" + id);
            }
             
            return Ok($"Pet" + id +"was deleted");

        }


    }
}