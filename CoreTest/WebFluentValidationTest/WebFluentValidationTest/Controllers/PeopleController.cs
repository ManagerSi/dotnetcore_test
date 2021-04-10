using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFluentValidationTest.Model;

namespace WebFluentValidationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest();
            }

            return Ok();
        }
	}
}