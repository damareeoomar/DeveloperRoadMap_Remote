using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.DTOs;
using TaskManagerApi.Services;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService ; 

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet]
    public ActionResult<List<TaskItem>> Get()
    {
        return Ok(_taskService.GetAllTasks());
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem> Get(int id)
    {
        if (_taskService.FindTaskById(id) == null)
        {
            return NotFound($"Task with Id {id} not found.");
        }
        return Ok(_taskService.FindTaskById(id));
   
    }

    [HttpPost]
    public ActionResult<TaskItem> Post([FromBody] CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        TaskItem createdTask  = _taskService.CreateTask(dto);

        return CreatedAtAction(nameof(Get), new { id = createdTask .Id }, createdTask);
    }
}