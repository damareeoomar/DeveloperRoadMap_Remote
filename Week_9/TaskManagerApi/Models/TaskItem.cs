using System.ComponentModel.DataAnnotations;
namespace TaskManagerApi.Models;

public class TaskItem
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}