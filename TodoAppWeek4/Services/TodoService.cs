using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAppWeek4.Models;
using TodoAppWeek4.ViewModels;

namespace TodoAppWeek4.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _context;
    private readonly IMapper _mapper;

    public TodoService(TodoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<TodoViewModel>> GetTodos()
    {
        var todos = await _context.Todos.ToListAsync();

        return _mapper.Map<IEnumerable<TodoViewModel>>(todos);
    }

    public async Task<TodoViewModel> GetTodo(int id)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(record => record.Id == id);

        if (todo == null)
        {
            throw new Exception("Todo not found");
        }

        return _mapper.Map<TodoViewModel>(todo);
    }

    public async Task<Todo> CreateTodo(CreateTodoRequest request)
    {
        var todo = new Todo
        {
            Item = request.Item,
            DueOn = request.DueOn,
            IsCompleted = false,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<Todo> UpdateTodo(UpdateTodoRequest request)
    {
        var foundTodo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == request.Id);

        if (foundTodo == null)
        {
            // Ideally you want have custom exception over here.
            throw new ApplicationException();
        }

        foundTodo.Item = request.Item;
        foundTodo.DueOn = request.DueOn;
        foundTodo.IsCompleted = request.IsCompleted;
        foundTodo.UpdatedAt = DateTime.Now;

        _context.Update(foundTodo);
        await _context.SaveChangesAsync();

        return foundTodo;
    }
}