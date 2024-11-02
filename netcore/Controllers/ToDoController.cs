using auth0_poc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auth0_poc.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Protege este endpoint
public class ToDoController : ControllerBase
{
    private static readonly List<ToDoItem> ToDoItems = new List<ToDoItem>
    {
        new ToDoItem { Id = 1, Title = "Comprar leite", IsCompleted = false },
        new ToDoItem { Id = 2, Title = "Estudar Auth0", IsCompleted = false },
        new ToDoItem { Id = 3, Title = "Lavar o carro", IsCompleted = true },
    };

    [HttpGet]
    public IActionResult GetToDoItems()
    {
        return Ok(ToDoItems); // Retorna a lista de tarefas
    }
}