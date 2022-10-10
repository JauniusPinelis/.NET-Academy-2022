using BackkgroundTasksApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackkgroundTasksApi.Controllers
{
    [Route("Tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public List<TaskDto> GetAll()
        {
            return new List<TaskDto>()
            {
                new TaskDto
                {
                    Id = 1,
                    Name = "Test",
                    Type = Enums.TaskType.Easy.ToString()
                }
            };
        }
    }
}
