namespace TaskManagerApi.Services; 
using TaskManagerApi.DTOs;


public class TaskService
{

    private readonly List<TaskItem> Tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learning C#", IsCompleted = true },
        new TaskItem { Id = 2, Title = "Practicing Programming", IsCompleted = false },
        new TaskItem { Id = 3, Title = "Learning and failing", IsCompleted = false }
    };
    public List<TaskItem> GetAllTasks()
    {
        return Tasks;
    }

    private int GetNextTaskId()
    {
        if (Tasks.Count == 0)
        {
            return 1;
        }

        return Tasks.Max(task => task.Id) + 1;
    }

    public TaskItem? FindTaskById(int id)
    {
        return  Tasks.FirstOrDefault(t => t.Id == id);

    }
    public TaskItem CreateTask(CreateTaskDto dto)
    {
        var newTask = new TaskItem
        {
            Id = GetNextTaskId(),
            Title = dto.Title.Trim(),
            IsCompleted = false

        }; 

        Tasks.Add(newTask);
        return newTask;
    }

    public TaskItem? UpdateTask(int id, UpdateTaskDto dto)
    {
        var task = FindTaskById(id);

        if (task == null)
        {
            return null;
        }

        task.Title = dto.Title.Trim();
        task.IsCompleted = dto.IsCompleted.Value;

        return task;
    }

    public bool DeleteTask(int id)
    {
        var task = FindTaskById(id);

        if (task == null)
        {
            return false;
        }

        Tasks.Remove(task);

        return true;
    }
}