List<TaskItem> tasks = new List<TaskItem>();

tasks.Add(new TaskItem(1, "Learn C# classes"));
tasks.Add(new TaskItem(2, "Practice Git"));
tasks.Add(new TaskItem(3, "Build task manager"));

Console.WriteLine("My Tasks");
Console.WriteLine("--------");

for (int i = 0; i < tasks.Count; i++)
{
    Console.WriteLine(tasks[i].GetDisplayText());
}

class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public TaskItem(int id, string title)
    {
        Id = id;
        Title = title;
        IsCompleted = false;
        CreatedAt = DateTime.Now;
    }

    public void MarkComplete()
    {
        IsCompleted = true;
    }

    public string GetDisplayText()
    {
        if (IsCompleted)
        {
            return $"{Id}. [Done] {Title}";
        }

        return $"{Id}. [Pending] {Title}";
    }
}