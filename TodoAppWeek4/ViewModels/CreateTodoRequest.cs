using System.ComponentModel.DataAnnotations;

namespace TodoAppWeek4.ViewModels;

public class CreateTodoRequest
{
    [Required]
    [MinLength(2)]
    public string Item { get; set; }

    public DateTime? DueOn { get; set; } = null;
}