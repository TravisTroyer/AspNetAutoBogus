using System.Collections.Generic;
using AspNetAutoBogus.Example.Model;
using Microsoft.AspNetCore.Mvc;

namespace AspNetAutoBogus.Example.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PersonsController : ControllerBase
   {
      [HttpGet]
      public ActionResult<IEnumerable<Person>> Get()
      {
         return new Person[0];
      }

      [HttpGet("{id}")]
      public ActionResult<Person> Get(int id)
      {
         return NotFound();
      }

      [HttpGet("person/{id}")]
      [ProducesResponseType(typeof(Person), 200)]
      public IActionResult GetPerson(int id)
      {
         return NotFound();
      }

      [HttpGet("person")]
      [ProducesResponseType(typeof(List<Person>), 200)]
      public IActionResult GetPersons()
      {
         return Ok(new Person[0]);
      }
   }
}
