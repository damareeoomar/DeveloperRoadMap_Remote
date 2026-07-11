using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        
        var tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Id = 1,
                Title = "Learning C#",
                IsCompleted = true
            },
            new TaskItem
            {
                Id = 2,
                Title = "Practicing Programming",
                IsCompleted = false
            },
            new TaskItem
            {
                Id = 3,
                Title = "Learning and failing",
                IsCompleted = false
            }
        };

        return Ok(tasks); 
    }

}
