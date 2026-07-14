using System.ComponentModel.DataAnnotations; 

namespace TaskManagerApi.DTOs;


public class CreateTaskDto
{
    [Required]
    public string Title { get; set; } ="";
}