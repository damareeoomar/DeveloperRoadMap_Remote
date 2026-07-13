using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.DTOs;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learning C#", IsCompleted = true },
        new TaskItem { Id = 2, Title = "Practicing Programming", IsCompleted = false },
        new TaskItem { Id = 3, Title = "Learning and failing", IsCompleted = false }
    };

    [HttpGet]
    public ActionResult<List<TaskItem>> Get()
    {
        return Ok(Tasks);
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem> Get(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            return NotFound($"Task with Id {id} not found.");
        }

        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> Post([FromBody] CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        TaskItem newTask = new TaskItem
        {
            Id = Tasks.Count + 1,
            Title = dto.Title,
            IsCompleted = false

        }; 

        Tasks.Add(newTask);

        return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
    }
}