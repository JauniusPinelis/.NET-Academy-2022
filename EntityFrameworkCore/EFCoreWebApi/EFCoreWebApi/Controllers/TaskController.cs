using EFCoreWebApi.Data;
using EFCoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi.Controllers
{
    [ApiController]
    [Route("Tasks")]
    public class TaskController : ControllerBase
    {
        private DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Groups.Include(g => g.Tasks).Where(g => g.Id == 1).ToList());
        }


        [HttpPost]
        public IActionResult Create(TaskEntity entity)
        {
            _context.Tasks.Add(entity);
            _context.SaveChanges();

            return Ok(entity.Id);
        }
    }
}
