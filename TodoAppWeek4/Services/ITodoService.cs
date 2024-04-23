using TodoAppWeek4.Models;
using TodoAppWeek4.ViewModels;

namespace TodoAppWeek4.Services;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetTodos();

    Task<Todo> GetTodo(int id);

    Task<Todo> CreateTodo(CreateTodoRequest request);
    
    Task<Todo> UpdateTodo(UpdateTodoRequest request);
}