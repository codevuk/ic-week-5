namespace TodoAppWeek4.ViewModels;

public class UpdateTodoRequest : CreateTodoRequest
{
    public int Id { get; set; }
    
    public bool IsCompleted { get; set; }
}