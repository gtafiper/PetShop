using System.Collections.Generic;
using ApplicationService2;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.Entity;

namespace Pets.Api.Conroller.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class OwnerController : ControllerBase
        {
            private IOwnerService _ownerServices;

            public OwnerController(IOwnerService ownerService
            )
            {
                _ownerServices = ownerService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Owner>> GetAllOwners()
            {
                return _ownerServices.GetOwners();
            }

            [HttpGet("{id}")]
            public ActionResult<Owner> Get(int id)
            {
                return _ownerServices.FindOwnerById(id);
            }

            [HttpPost]
            public ActionResult<Owner> Post([FromBody] Owner owner)
            {
                if (string.IsNullOrEmpty(owner.Firstname))
                {
                    return BadRequest("owner must have a name");
                }

                return _ownerServices.CreateOwner(owner);
            }

            [HttpPut("{id}")]
            public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
            {
                if (id < 1 || id != owner.Id)
                {
                    return BadRequest("Parameter id, and pet id must be the same!");
                }

                return Ok(_ownerServices.UpdateOwner(owner));
            }

            [HttpDelete("{id}")]
            public ActionResult<Owner> Delet(int id)
            {
                var owner = _ownerServices.Delete(id);
                if (owner == null)
                {
                    return StatusCode(404, "Did not find a pet with Id of" + id);
                }

                return Ok($"Pet" + id + "was deleted");

            }


        }
    }




