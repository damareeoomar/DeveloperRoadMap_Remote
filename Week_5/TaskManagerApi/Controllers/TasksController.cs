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

    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        TaskItem? FindTaskById(List<TaskItem> taskList, int idOfTask)
        {
            for (int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].Id == idOfTask)
                {
                    return taskList[i];
                }
            }

            return null;
        }
    
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

        var valid_task = FindTaskById(tasks, id);

        if (valid_task!= null)
        {
            return Ok(valid_task);
        }
        else
        {
            return NotFound($"Task with Id {id} Not found.");
        }
    }

}
