using Microsoft.AspNetCore.Mvc;
using RestWithAspNetCore2Udemy.Model;
using RestWithAspNetCore2Udemy.Business;

namespace RestFul_AspNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet("v1")]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("v1/{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost("v1")]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return NotFound();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values/5
        [HttpPut("v1")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return NotFound();
            return new ObjectResult(_personBusiness.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("v1/{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
