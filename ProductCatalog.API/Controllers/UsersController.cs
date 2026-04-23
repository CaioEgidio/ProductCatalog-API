using Microsoft.AspNetCore.Mvc; 
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.API.Controllers;

[ApiController] // digo pro .net que isso é uma api 
[Route("users")] // defino a url base 
public class UserController : ControllerBase
{
    [HttpGet] // defino a requisição como tipo GET
    // Metodos 
    public IActionResult Get() // retorna os codigos de status Http 
    {
        var users = new List<object> 
        {
            new User("Caio", "caio@email.com")
        };
        return Ok(users);
    }
}

