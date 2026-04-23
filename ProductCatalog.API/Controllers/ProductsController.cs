using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.DTOs;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.API.Controllers;

[ApiController] // digo pro .net que isso é uma api 
[Route("products")] // defino a url base 
public class ProductsController : ControllerBase
{
    [HttpGet] // Requisição do tipo GET
    public IActionResult Get()
    {
        var products = new List<Product>
        {
            new Product("Notebook", "Notebook gamer", 3500, Guid.NewGuid())
        };
        return Ok(products);
    }

    [HttpPost] // Define um requisição do tipo POST 
    public IActionResult Create([FromBody] CreateProductRequest request)
    {
        var product = new Product(request.Nome, request.Descricao, request.Preco, Guid.NewGuid());
        return Ok(product);
    }
}

