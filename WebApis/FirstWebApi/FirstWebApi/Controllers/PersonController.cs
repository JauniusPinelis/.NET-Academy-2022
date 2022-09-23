using FirstWebApi.Dtos;
using FirstWebApi.Entities;
using FirstWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("Persons")]
    public class PersonController : ControllerBase
    {
        //crud
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult Create(CreatePerson person)
        {
            _personService.Add(person);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update(PersonEntity person)
        {
            try
            {
                _personService.Update(person);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_personService.GetById(id));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _personService.Remove(id);
                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
