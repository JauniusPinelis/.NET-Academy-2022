using FirstWebApi.Models;
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
        public IActionResult Create(Person person)
        {
            _personService.Add(person);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_personService.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            return Ok(_personService.Remove())
        }



    }
}
