List<TaskItem> tasks = new List<TaskItem>();

tasks.Add(new TaskItem(1, "Learn C# classes"));
tasks.Add(new TaskItem(2, "Practice Git"));
tasks.Add(new TaskItem(3, "Build task manager"));
tasks.Add(new TaskItem(4, "Review Week 3 notes"));

Console.WriteLine("My Tasks");
Console.WriteLine("--------");

for (int i = 0; i < tasks.Count; i++)
{
    Console.WriteLine(tasks[i].GetDisplayText());
}

Console.WriteLine();
Console.Write("Enter the Id of the task to mark complete: ");
string? input = Console.ReadLine();

bool isNumber = int.TryParse(input, out int selectedTaskId);

if (isNumber)
{
    bool foundTask = false;

    for (int i = 0; i < tasks.Count; i++)
    {
        if (tasks[i].Id == selectedTaskId)
        {
            tasks[i].MarkComplete();
            foundTask = true;
        }
    }

    if (foundTask)
    {
        Console.WriteLine("Task marked complete.");
    }
    else
    {
        Console.WriteLine("Task not found.");
    }
}
else
{
    Console.WriteLine("Invalid number.");
}

Console.WriteLine();
Console.WriteLine("Updated Tasks");
Console.WriteLine("-------------");

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