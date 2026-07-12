using Microsoft.AspNetCore.Mvc;

namespace TaskManagerApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private List<TaskItem> GetSampleTasks()
    {
        var sampleTasks = new List<TaskItem>
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
        return sampleTasks;
    }
    [HttpGet]
    public ActionResult<List<TaskItem>> Get()
    {
        
        var tasks = GetSampleTasks();

        return Ok(tasks); 
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem?> Get(int id)
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
    
         var tasks = GetSampleTasks();

        var valid_Task = FindTaskById(tasks, id);

        if (valid_Task!= null)
        {
            return Ok(valid_Task);
        }
        else
        {
            return NotFound($"Task with Id {id} Not found.");
        }
    }

}
