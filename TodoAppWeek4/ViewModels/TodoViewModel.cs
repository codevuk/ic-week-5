namespace TodoAppWeek4.ViewModels;

public class TodoViewModel
{
    public int Id { get; set; }

    public string Item { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? DueOn { get; set; }
}