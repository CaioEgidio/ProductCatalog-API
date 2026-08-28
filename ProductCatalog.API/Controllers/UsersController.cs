using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.UseCases.CreateUser;
using ProductCatalog.Application.UseCases.GetAllUsers;
using ProductCatalog.Application.UseCases.GetUserById;

namespace ProductCatalog.API.Controllers;

[ApiController] // digo pro .net que isso é uma api 
[Route("users")] // defino a url base 
public class UserController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;
    private readonly GetAllUsersHandler _getAllUsersHandler;
    private readonly GetUserByIdHandler _getUserByIdHandler;
    
    //O .NET entrega o Handler automaticamente.
    public UserController(CreateUserHandler createUserHandler, GetAllUsersHandler getAllUsersHandler, GetUserByIdHandler getUserByIdHandler)
    {
        _createUserHandler = createUserHandler;
        _getAllUsersHandler = getAllUsersHandler;
        _getUserByIdHandler = getUserByIdHandler;
    }
    
    [HttpPost] // defino a requisição como tipo Post
    // Metodos 
    public IActionResult Create([FromBody] CreateUserRequest request) // retorna os codigos de status Http 
    {
        var users = _createUserHandler.Handle(request);
        return Ok(users);
    }
    
    [HttpGet] // requisição GET
    public IActionResult GetAllUsers()
    {
        var users = _getAllUsersHandler.Handle();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _getUserByIdHandler.Handle(id);

        if (user == null)
        {
            return NotFound();
        }
 
        return Ok(User);
    }
    
}

