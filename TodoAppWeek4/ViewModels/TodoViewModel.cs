namespace TodoAppWeek4.ViewModels;

public class TodoViewModel
{
    public int Id { get; set; }

    public string Item { get; set; }

    public DateTime? DueOn { get; set; } = null;

    public bool IsCompleted { get; set; }
}