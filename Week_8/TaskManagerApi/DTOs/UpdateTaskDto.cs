using System.ComponentModel.DataAnnotations; 

namespace TaskManagerApi.DTOs;

public class UpdateTaskDto
{
    [Required]
    public string Title { get; set; } ="";
    public bool IsCompleted { get; set; }
}