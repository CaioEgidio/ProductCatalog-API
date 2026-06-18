using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.DTOs;
using ProductCatalog.Application.UseCases.CreateProduct;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.API.Controllers;

[ApiController] // digo pro .net que isso é uma api 
[Route("products")] // defino a url base 
public class ProductsController : ControllerBase
{
    private readonly CreateProductHandler _handler;
    
    // Recebe o handler via injeção de dependência
    public ProductsController(CreateProductHandler handler)
    {
        _handler = handler;
    }
    
    [HttpGet] // Requisição do tipo GET
    public IActionResult Get()
    {
        // Lista fixa só para teste (ainda não busca do banco)
        var products = new List<Product>
        {
            new Product("Notebook", "Notebook gamer", 3500, Guid.NewGuid())
        };
        return Ok(products); // Retorna 200 com a lista
    }

    [HttpPost] // Define um requisição do tipo POST 
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        // Pega os dados do corpo da requisição e cria o produto
        var product = _handler.Handle(request);
        return Ok(product); // Retorna 200 com o produto criado
    }
}

