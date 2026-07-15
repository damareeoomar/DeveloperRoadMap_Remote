namespace TaskManagerApi.Services; 


public class TaskService
{

    private static readonly List<TaskItem> Tasks = new()
    {
        new TaskItem { Id = 1, Title = "Learning C#", IsCompleted = true },
        new TaskItem { Id = 2, Title = "Practicing Programming", IsCompleted = false },
        new TaskItem { Id = 3, Title = "Learning and failing", IsCompleted = false }
    };
    public List<TaskItem> GetAllTasks()
    {
        return Tasks;
    }

    public TaskItem? FindTaskById(int id)
    {
        return  Tasks.FirstOrDefault(t => t.Id == id);

    }
}