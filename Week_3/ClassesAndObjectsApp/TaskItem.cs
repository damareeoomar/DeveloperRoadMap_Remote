public class TaskItem
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