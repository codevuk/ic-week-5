using Microsoft.AspNetCore.Mvc;
using TodoAppWeek4.Services;
using TodoAppWeek4.ViewModels;

namespace TodoAppWeek4.Controllers;

public class TodoController : Controller
{
    private readonly ITodoService _todoService;
    
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<IActionResult> Index()
    {
        var todos = await _todoService.GetTodos();
        
        return View(todos);
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var todos = await _todoService.GetTodo(id);

        return View(todos);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateTodoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _todoService.CreateTodo(request);
            
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var todo = await _todoService.GetTodo(id);
        
        return View(todo);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateTodoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _todoService.UpdateTodo(request);

        return RedirectToAction(nameof(Index));
    }
}