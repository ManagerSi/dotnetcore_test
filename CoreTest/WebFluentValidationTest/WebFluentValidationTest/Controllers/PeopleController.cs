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
            //ApiController 默认走不到这里(ModelState.IsValid)，会在base.ResultFilter中验证失败，直接返回
            //所以覆写一个BadRequestResultFilter 
            //if (!ModelState.IsValid)
            //{ // re-render the view when validation failed.
            //    return BadRequest(ModelState);
            //}

            return Ok();
        }
	}
}