using System.Net;
using Microsoft.AspNetCore.Mvc;
using TodoAppWeek4.Models;
using TodoAppWeek4.Services;
using TodoAppWeek4.ViewModels;

namespace TodoAppWeek4.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoApiController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoApiController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    
    /*
     * HTTP Status Codes
     * 200-299      -    Indicates success    200 = OK, 201, 204
     * 300-399      -    Redirection
     * 400-499      -    User error            = BadRequest, 401 .....
     * 500          -    Server
     */

    // api/todos
    [HttpGet]
    [ProducesResponseType(200)]
    [Produces(typeof(IEnumerable<TodoViewModel>))]
    public async Task<IActionResult> GetTodos()
    {
        var todos = await _todoService.GetTodos();
  
        return Ok(todos);
    }
    
    // api/todos/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(typeof(TodoViewModel))]
    public async Task<IActionResult> GetTodo([FromRoute] int id)
    {
        try
        {
            var todo = await _todoService.GetTodo(id);
            return Ok(todo);
        }
        catch (Exception ex)
        {
            return NotFound("The todo you are looking for does not exist");
        }
    }

    // api/todos    (HTTP POST)
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces(typeof(Todo))]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var todo = await _todoService.CreateTodo(request);

        return Ok(todo);
    }
}