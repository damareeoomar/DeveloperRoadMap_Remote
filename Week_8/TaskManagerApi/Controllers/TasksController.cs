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
            return InvalidTaskIdProblem(id);
        }

        var task = _taskService.FindTaskById(id);

        if (task == null)
        {
            return TaskNotFoundProblem(id);
        }

        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> Post([FromBody] CreateTaskDto dto)
    {
        TaskItem createdTask  = _taskService.CreateTask(dto);

        return CreatedAtAction(nameof(GetById), new { id = createdTask .Id }, createdTask);
    }

    [HttpPut("{id:int}")]
    // [ValidateAntiForgeryToken]
    
    public ActionResult<TaskItem> Update(int id,[FromBody] UpdateTaskDto dto)
    {
        if (id <= 0)
        {
            InvalidTaskIdProblem(id);
        }

        var updatedTask = _taskService.UpdateTask(id, dto);

        if (updatedTask == null)
        {
            TaskNotFoundProblem(id);
        }

        return Ok(updatedTask);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return InvalidTaskIdProblem(id);
        }

        bool wasDeleted = _taskService.DeleteTask(id);

        if (!wasDeleted)
        {
            return TaskNotFoundProblem(id);
        }

        return NoContent();
    }

    private ObjectResult InvalidTaskIdProblem(int id)
    {
        return Problem(
            statusCode: StatusCodes.Status400BadRequest,
            title: "Invalid task Id",
            detail: $"Task Id {id} is invalid. Task Id must be greater than zero.",
            instance: HttpContext.Request.Path);
    }

    private ObjectResult TaskNotFoundProblem(int id)
    {
        return Problem(
            statusCode: StatusCodes.Status404NotFound,
            title: "Task not found",
            detail: $"Task with Id {id} was not found.",
            instance: HttpContext.Request.Path);
    }
}