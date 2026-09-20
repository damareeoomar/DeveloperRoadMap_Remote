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

    [HttpGet("{id:int}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Task Id must be greater than zero.");
        }
        
        var task = _taskService.FindTaskById(id);

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
        TaskItem createdTask  = _taskService.CreateTask(dto);

        return CreatedAtAction(nameof(GetById), new { id = createdTask .Id }, createdTask);
    }

    [HttpPut("{id:int}")]
    // [ValidateAntiForgeryToken]
    
    public ActionResult<TaskItem> Update(int id,[FromBody] UpdateTaskDto dto)
    {
        if (id <= 0)
        {
            return BadRequest("Task Id must be greater than zero.");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedTask = _taskService.UpdateTask(id, dto);

        if (updatedTask == null)
        {
            return NotFound($"Task with Id {id} not found.");
        }

        return Ok(updatedTask);
    }
}